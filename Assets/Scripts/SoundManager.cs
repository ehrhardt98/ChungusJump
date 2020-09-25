using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip bounce, carrot, play, defeat;
    static AudioSource audioSource;

    void Start()
    {

        bounce = Resources.Load<AudioClip>("Bounce");
        carrot = Resources.Load<AudioClip>("Carrot");
        play = Resources.Load<AudioClip>("Play");
        defeat = Resources.Load<AudioClip>("Defeat");
        audioSource = GetComponent<AudioSource>();

    }


    public static void PlaySound(string clip)
    {
        switch (clip)
        {

            case "Bounce":
                audioSource.PlayOneShot(bounce);
                break;

            case "Carrot":
                audioSource.PlayOneShot(carrot);
                break;

            case "Play":
                audioSource.PlayOneShot(play);
                break;

            case "Defeat":
                audioSource.PlayOneShot(defeat);
                break;
        }
    }
}