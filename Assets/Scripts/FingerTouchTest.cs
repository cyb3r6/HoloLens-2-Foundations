using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;

public class FingerTouchTest : MonoBehaviour, IMixedRealityTouchHandler
{
    [SerializeField]
    private TextMesh debugTextOne = null;
    [SerializeField]
    private TextMesh debugTextTwo = null;

    #region Event handlers

    public TouchEvent OnTouchCompleted;
    public TouchEvent OnTouchStarted;
    public TouchEvent OnTouchUpdated;

    #endregion

    void IMixedRealityTouchHandler.OnTouchCompleted(HandTrackingInputEventData eventData)
    {
        OnTouchCompleted.Invoke(eventData);

        if (debugTextOne != null)
        {
            debugTextOne.text = "OnTouchCompleted: " + Time.unscaledTime.ToString();
        }

        OnTouchCompleted.Invoke(eventData);
    }

    void IMixedRealityTouchHandler.OnTouchStarted(HandTrackingInputEventData eventData)
    {
        OnTouchStarted.Invoke(eventData);

        if (debugTextOne != null)
        {
            debugTextOne.text = "OnTouchStarted: " + Time.unscaledTime.ToString();
        }

        OnTouchStarted.Invoke(eventData);
    }

    void IMixedRealityTouchHandler.OnTouchUpdated(HandTrackingInputEventData eventData)
    {
        OnTouchUpdated.Invoke(eventData);

        if (debugTextTwo != null)
        {
            debugTextTwo.text = "OnTouchUpdated: " + Time.unscaledTime.ToString();
        }

        OnTouchUpdated.Invoke(eventData);
    }
    
}
