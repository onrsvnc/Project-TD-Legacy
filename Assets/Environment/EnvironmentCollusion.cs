using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentCollusion : MonoBehaviour
{
    [SerializeField] GameObject hitSFX;
    [SerializeField] ParticleSystem hitVFX;
    void OnParticleCollision(GameObject other)
    {
        HitSFX();
        HitVFX();
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
}
