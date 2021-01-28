using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctavePitch : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The number of semitones to raise the pitch. An octave is 12 semitones")]
    int numberOfSemitones;

    [SerializeField]
    private AudioSource audioSource;
    
    void Start()
    {
        RaisePitchBySemitone();
    }

   public void RaisePitchBySemitone()
    {
        // general rule of thumb is to multiply frequency by 1.05946^n
        // where n is the number of semitones
        float multiply = audioSource.pitch * Mathf.Pow(1.05946f, numberOfSemitones);

        audioSource.pitch = multiply;
    }
}
