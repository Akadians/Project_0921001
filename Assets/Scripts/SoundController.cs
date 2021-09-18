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
    public AudioClip PickUpSound;
    public AudioClip Click;
    // Start is called before the first frame update
    void Start()
    {
        Implements();
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
    public void PickUpItem()
    {
        SoundController.instance.PlayOneShot(PickUpSound);
    }
    public void ClickButton()
    {
        SoundController.instance.PlayOneShot(Click);
    }
}
