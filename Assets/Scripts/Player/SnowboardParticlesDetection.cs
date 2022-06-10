using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowboardParticlesDetection : MonoBehaviour
{
    [SerializeField] ParticleSystem snowboardParticles;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            snowboardParticles.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        snowboardParticles.Stop();
    }
}
