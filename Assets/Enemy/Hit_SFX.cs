using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_SFX : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip[] audioClips;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.Play();
        Destroy(gameObject, audioSource.clip.length);
    }

    void Update()
    {
        
    }
    
}
