using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    private AudioSource audioSound;
    public static AudioSource instance;

    public AudioClip RightSound;
    public AudioClip WrongSound;
    // Start is called before the first frame update
    void Start()
    {
        Implements();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Implements()
    {
        audioSound = GetComponent<AudioSource>();
        instance = audioSound;
    }
    public void RightDelivery ()
    {
        SoundController.instance.PlayOneShot(RightSound);
    }
    public void WrongDelivery ()
    {
        SoundController.instance.PlayOneShot(WrongSound);
    }

}
