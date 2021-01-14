using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.MixedReality.Toolkit.Input;

public class TestInputData : MonoBehaviour
{
    public GameObject indexGameObject;
    public Text text;
    
   public void TestFingerPoint()
    {
        text.text = $"finger has pointed ";
    }
}
