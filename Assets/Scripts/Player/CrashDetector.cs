using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{

    PlayerController playerController;

    [SerializeField] float reloadLevelDelay = 2f;
    [SerializeField] ParticleSystem crashParticles;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip crashAudio;
    [SerializeField] float audioClipVolume = 0.5f;

    [SerializeField] bool hasCrashed = false;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") && !hasCrashed)
        {
            hasCrashed = true;
            crashParticles.Play();
            audioSource.PlayOneShot(crashAudio, audioClipVolume);
            playerController.DisableControls();
            Invoke("ReloadScene", reloadLevelDelay);
        } 
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
