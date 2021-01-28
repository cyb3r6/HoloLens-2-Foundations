using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Physics;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities;

public class HoverAudio : MonoBehaviour
{
    private ObjectManipulator objectManipulator;
    private ObjectManipulatorDynamicHover objectManipulatorDynamic;
    private AudioSource audioSource;
    public AudioClip audioClip;
    public GameObject manipulationSourceIndicator;
    
    void Awake()
    {
        objectManipulator = GetComponent<ObjectManipulator>();
        objectManipulatorDynamic = GetComponent<ObjectManipulatorDynamicHover>();
        audioSource = GetComponent<AudioSource>();

        //objectManipulator.OnHoverEntered.AddListener(HoverDistance);
    }
  
    private void HoverDistance(ManipulationEventData args)
    {
        // the position of the object that has the object manipulator script
        var manipulationSource = args.ManipulationSource.transform.position;

        var positionSource = args.Pointer.Position;

        // visual for seeing the pointer position on hover
        manipulationSourceIndicator.transform.position = positionSource;

        // the distance between the pointer position and the object maniulator object
        Vector3 distance = positionSource - transform.position;

        Debug.Log($"the distance between manipulation source and object is {distance.magnitude}");

        //ChangeAudioVolume(distance.magnitude);
    } 

    public void ChangeAudioVolume(float normalizedDistance)
    {
        float volumeRatio = normalizedDistance/objectManipulatorDynamic.initialHoverDistance.magnitude;

        //audioSource.volume = 1-normalizedDistance;
        audioSource.volume = volumeRatio;
        if (audioSource.isPlaying)
        {
            return;
        }
        else
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
