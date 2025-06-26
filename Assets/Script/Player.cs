using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleVRMove : MonoBehaviour
{
    public InputActionReference moveInput;  // 조이스틱 입력 연결
    public float moveSpeed = 1.5f;

    void Update()
    {
        if (moveInput == null) return;

        Vector2 input = moveInput.action.ReadValue<Vector2>();
        Vector3 direction = new Vector3(input.x, 0, input.y);

        // HMD 바라보는 방향 기준으로 이동 (전방 이동 처리)
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();

        Vector3 cameraRight = Camera.main.transform.right;
        cameraRight.y = 0;
        cameraRight.Normalize();

        Vector3 move = cameraForward * direction.y + cameraRight * direction.x;
        transform.position += move * moveSpeed * Time.deltaTime;
    }
}
