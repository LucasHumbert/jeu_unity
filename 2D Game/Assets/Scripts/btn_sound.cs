using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btn_sound : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip click;

    public void ClickSound() {
        audioSource.PlayOneShot(click);
    }
}
