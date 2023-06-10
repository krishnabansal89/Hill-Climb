using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioPlay : MonoBehaviour
{
    public AudioSource aud;

    public void play()
    {
        aud = GetComponent<AudioSource>();
        aud.Play();
    }
}
