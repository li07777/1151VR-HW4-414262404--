
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("跟隨目標")]
    public Transform target;

    [Header("攝影機位置")]
    public Vector3 offset = new Vector3(0, 3, -10);

    [Header("跟隨平滑度")]
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 desiredPosition =
            target.position + offset;

        float t = 1f - Mathf.Exp(
            -smoothSpeed * Time.deltaTime);

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            t
        );

        transform.LookAt(
            target.position + Vector3.forward * 5f
        );
    }
}
