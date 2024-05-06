using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CrashDetector : MonoBehaviour
{

    [SerializeField] float reloadTime = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
             FindObjectOfType<PlayerController>().DisabeControls();
             crashEffect.Play();
             GetComponent<AudioSource>().PlayOneShot(crashSFX);
             Invoke("ReloadScene", reloadTime);
        }
    }

    void ReloadScene()
    {
            SceneManager.LoadScene(0);

    }
}
