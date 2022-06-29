using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundries : MonoBehaviour
{
    private Vector3 viewPos;

    // Update is called once per frame
    void LateUpdate()
    {
        viewPos = transform.position;
        viewPos = Camera.main.WorldToViewportPoint(viewPos);
        viewPos.x = Mathf.Clamp(viewPos.x, 0.1f, 0.92f);
        viewPos.y = Mathf.Clamp(viewPos.y, 0.06f, 0.94f);
        transform.position = Camera.main.ViewportToWorldPoint(viewPos);
    }
}
