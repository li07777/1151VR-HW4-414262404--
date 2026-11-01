
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class AircraftController : MonoBehaviour
{
    [Header("飛行速度")]
    public float forwardSpeed = 5f;
    public float moveSpeed = 4f;

    [Header("飛行範圍")]
    public float minX = -4f;
    public float maxX = 4f;
    public float minY = 0.5f;
    public float maxY = 6f;

    private Rigidbody rb;
    private Vector2 moveInput;
    private bool canFly = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        rb.useGravity = false;
        rb.isKinematic = true;
        rb.collisionDetectionMode =
            CollisionDetectionMode.ContinuousSpeculative;

        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    void Update()
    {
        moveInput = Vector2.zero;

        if (!canFly)
            return;

        Keyboard keyboard = Keyboard.current;

        if (keyboard == null)
            return;

        // 左右移動
        if (keyboard.aKey.isPressed ||
            keyboard.leftArrowKey.isPressed)
        {
            moveInput.x -= 1f;
        }

        if (keyboard.dKey.isPressed ||
            keyboard.rightArrowKey.isPressed)
        {
            moveInput.x += 1f;
        }

        // 上下移動
        if (keyboard.wKey.isPressed ||
            keyboard.upArrowKey.isPressed)
        {
            moveInput.y += 1f;
        }

        if (keyboard.sKey.isPressed ||
            keyboard.downArrowKey.isPressed)
        {
            moveInput.y -= 1f;
        }

        // 避免斜向速度過快
        moveInput = Vector2.ClampMagnitude(moveInput, 1f);
    }

    void FixedUpdate()
    {
        if (!canFly)
            return;

        Vector3 movement = new Vector3(
            moveInput.x * moveSpeed,
            moveInput.y * moveSpeed,
            forwardSpeed
        );

        Vector3 nextPosition =
            rb.position + movement * Time.fixedDeltaTime;

        nextPosition.x = Mathf.Clamp(
            nextPosition.x, minX, maxX);

        nextPosition.y = Mathf.Clamp(
            nextPosition.y, minY, maxY);

        rb.MovePosition(nextPosition);
    }

    public void StopFlying()
    {
        canFly = false;
        moveInput = Vector2.zero;
        Debug.Log("飛機停止飛行");
    }

    public void StartFlying()
    {
        canFly = true;
    }
}
