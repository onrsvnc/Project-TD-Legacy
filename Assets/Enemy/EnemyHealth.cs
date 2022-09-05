using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))] 
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    
    [Tooltip("Adds amount to maxHitPoints when enemy dies")]
    [SerializeField] int difficultyRamp = 1;
    [SerializeField] AudioClip[] audioClips;
    
    int currentHitPoints = 0;
    Enemy enemy;
    AudioSource audioSource;
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }
    void Start()
    {
        enemy = GetComponent<Enemy>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        HitSFX();
    }

    void ProcessHit()
    {
        currentHitPoints--;
        if(currentHitPoints <= Mathf.Epsilon)
        {
            enemy.GoldRewarded();
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
        }
    }

    void HitSFX()
    {
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.Play();
    }
}
