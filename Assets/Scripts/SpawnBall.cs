using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;

public class SpawnBall : MonoBehaviour
{
    public GameObject spawnPrefab;
    public float shootforce;

    private InputActionHandler inputActionHandler;

    private void Awake()
    {
        inputActionHandler = GetComponent<InputActionHandler>();
    }

    public void Spawn()
    {
        if (spawnPrefab != null)
        {
            Vector3 forwardPosition = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z + 0.2f);
            GameObject spawnedObject = Instantiate(spawnPrefab, forwardPosition, Quaternion.LookRotation(Camera.main.transform.forward));
            spawnedObject.GetComponent<Rigidbody>().AddForce(spawnedObject.transform.forward * shootforce);
        }
    }
}
