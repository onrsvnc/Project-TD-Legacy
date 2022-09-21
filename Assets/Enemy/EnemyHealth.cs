using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))] 
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    
    [Tooltip("Adds amount to maxHitPoints when enemy dies")]
    [SerializeField] int difficultyRamp = 1;
    [SerializeField] ParticleSystem hitVFX;
    [SerializeField] GameObject hitSFX;
    [SerializeField] GameObject deathSFX;
    
    int currentHitPoints = 0;
    Enemy enemy;
    
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        HitSFX();
        HitVFX();
    }
    void ProcessHit()
    {
        currentHitPoints--;
        if(currentHitPoints <= Mathf.Epsilon)
        {
            DeathSFX();
            enemy.GoldRewarded();
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
        }
    }

    void HitSFX()
    {
        if(hitSFX != null)
        {
            GameObject instance = Instantiate(hitSFX, transform.position, Quaternion.identity);
        }
    }
    void HitVFX()
    {
        if(hitVFX != null)
        {
            ParticleSystem instance = Instantiate(hitVFX, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
    void DeathSFX()
    {
        if(deathSFX != null)
        {
            GameObject instance = Instantiate(deathSFX, transform.position, Quaternion.identity);
        }
    }

}
