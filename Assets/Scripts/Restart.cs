using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public GameObject prefab;
    public GameObject newObj;
    public bool playerRestarting = false;
    // Start is called before the first frame update

    public void restoreNewInstance(Vector3 startPos)
    {
        newObj = Instantiate(prefab, startPos, Quaternion.identity);
        playerRestarting = true;
    }

    public void setRestart(bool state)
    {
        playerRestarting = state;
    }
}
