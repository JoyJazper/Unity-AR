using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clamping : MonoBehaviour
{
    Vector3 clampedPosition;
    Vector3 FixedPosition;
    int n = 0;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 FixedPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (n < 10)
        {
            FixedPosition = transform.position;
            n++;
        }
        clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, (FixedPosition.y - 0.01f), (FixedPosition.y + 0.01f));
        transform.position = clampedPosition;
    }
}
