using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTabScript : MonoBehaviour
{
    public float speed;

    private Camera cameraComponent;

    private float targetPosition;

    private Vector2 startPosition;

    void Start()
    {
        cameraComponent = GetComponent<Camera>();
        targetPosition = transform.position.x;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            startPosition = cameraComponent.WorldToScreenPoint(Input.mousePosition);
        else
        {
            float pos = cameraComponent.ScreenToWorldPoint(Input.mousePosition).x - startPosition.x;
            targetPosition = Mathf.Clamp(transform.position.x - pos, -60f, 60f);
        }
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetPosition, speed * Time.deltaTime), transform.position.y, transform.position.z);
    }
}
