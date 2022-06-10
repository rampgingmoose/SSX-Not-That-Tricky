using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float reloadLevelDelay = 2f;
    [SerializeField] ParticleSystem finishParticles;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip finishAudio;
    [SerializeField] float audioClipVolume = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            finishParticles.Play();
            audioSource.PlayOneShot(finishAudio, audioClipVolume);
            Invoke("ReloadScene", reloadLevelDelay);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
