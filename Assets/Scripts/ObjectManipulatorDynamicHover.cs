using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Input;

public class ObjectManipulatorDynamicHover : ObjectManipulator
{
    [Serializable]
    public class HoverChangedEvent : UnityEvent<float> { }

    public HoverChangedEvent OnHoverChanged;

    private bool hover;

    private ManipulationEventData globalArgs;

    public Vector3 initialHoverDistance;

    private void Awake()
    {
        OnHoverEntered.AddListener(StartHover);
        OnHoverExited.AddListener(StopHover);
    }

    void Update()
    {
        if (hover)
        {
            HoverDistance(globalArgs);
        }
    }

    public void StartHover(ManipulationEventData args)
    {
        hover = true;

        globalArgs = args;

        // the position of the object that has the object manipulator script
        var manipulationSource = args.ManipulationSource.transform.position;

        var positionSource = args.Pointer.Position;

        initialHoverDistance = positionSource - transform.position;

    }
    public void StopHover(ManipulationEventData args)
    {
        hover = false;

        globalArgs = args;

        // the position of the object that has the object manipulator script
        var manipulationSource = args.ManipulationSource.transform.position;

        var positionSource = args.Pointer.Position;

        initialHoverDistance = positionSource - transform.position;
    }

    public void HoverDistance(ManipulationEventData args)
    {
        // the position of the object that has the object manipulator script
        var manipulationSource = args.ManipulationSource.transform.position;

        var positionSource = args.Pointer.Position;

        // the distance between the pointer position and the object maniulator object
        Vector3 distance = positionSource - transform.position;

        Debug.Log($"the distance between manipulation source and object is {distance.magnitude}");

        OnHoverChanged.Invoke(distance.magnitude);
    }

    public void OnFocusUpdate(FocusEventData eventData)
    {

    }
}
