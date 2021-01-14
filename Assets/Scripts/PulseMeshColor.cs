using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Experimental.SurfacePulse;

public class PulseMeshColor : MonoBehaviour
{
    public SurfacePulse surfacePulse;
    private Color objectColor;

    
    void Start()
    {
        objectColor = GetComponent<Renderer>().material.color;
    }

    public void SendColor()
    {
        surfacePulse.SendColor(objectColor);
    }
}
