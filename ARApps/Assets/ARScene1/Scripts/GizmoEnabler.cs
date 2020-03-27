using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoEnabler : MonoBehaviour
{
    public bool gizmoEnabled = false;
    public GameObject gizmoPrefab;
    // Start is called before the first frame update

    public void EnableGizmo()
    {
        if(gizmoEnabled)
        {
            gizmoEnabled = false;
            gizmoPrefab.gameObject.SetActive(true);
        }
        else
        {
            gizmoEnabled = true;
            gizmoPrefab.gameObject.SetActive(false);
        }
    }
}
