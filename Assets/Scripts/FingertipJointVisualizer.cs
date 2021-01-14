using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Experimental.SurfacePulse;

public class FingertipJointVisualizer : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Finger tip prefab")]
    private GameObject fingerTipPrefab;

    [SerializeField]
    private Text debugTextOne = null;

    [SerializeField]
    private SurfacePulse surfacePulse;

    public bool onTouch = false;

    private Transform indexJointTransform,middleJointTransform, ringJointTransform, pinkyJointTransform, thumbJointTransform;

    public Transform IndexJointTransform
    {
        get { return indexJointTransform; }
    }
    public Transform MiddleJointTransform
    {
        get { return middleJointTransform; }
    }
    public Transform RingJointTransform
    {
        get { return ringJointTransform; }
    }
    public Transform ThumbJointTransform
    {
        get { return thumbJointTransform; }
    }
    public Transform PinkyJointTransform
    {
        get { return pinkyJointTransform; }
    }

    void Update()
    {
        var handJointService = CoreServices.GetInputSystemDataProvider<IMixedRealityHandJointService>();

        if (handJointService != null)
        {
            indexJointTransform = handJointService.RequestJointTransform(TrackedHandJoint.IndexTip, Handedness.Right);
            middleJointTransform = handJointService.RequestJointTransform(TrackedHandJoint.MiddleTip, Handedness.Any);
            ringJointTransform = handJointService.RequestJointTransform(TrackedHandJoint.RingTip, Handedness.Any);
            thumbJointTransform = handJointService.RequestJointTransform(TrackedHandJoint.ThumbTip, Handedness.Any);
            pinkyJointTransform = handJointService.RequestJointTransform(TrackedHandJoint.PinkyTip, Handedness.Any);

            if (onTouch)
            {
                PulseOnTouch(indexJointTransform.position);
            }
        }
    }

    public static bool HasFoundTip()
    {
        foreach (IMixedRealityController c in CoreServices.InputSystem.DetectedControllers)
        {
            if (c.ControllerHandedness.IsMatch(Handedness.Both))
            {
                // condition
                return true;
            }
        }
        return false;
    }

    public void Touch()
    {
        onTouch = true;
    }
    public void NoTouch()
    {
        onTouch = false;
    }

    public void PulseOnTouch(Vector3 position)
    {
        debugTextOne.text = $"Pulse at fingertips {position}";
        surfacePulse.SetLocalOrigin(position);
        surfacePulse.PulseOnce();        
    }
}
