using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
	public float moveSpeed = 5f;

	public float mouseSensitivity = 2f;

	private float rotationX;

	private Transform cameraTransform;

	private void Start()
	{
		cameraTransform = Camera.main.transform;
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void Update()
	{
		float axis = Input.GetAxis("Horizontal");
		float axis2 = Input.GetAxis("Vertical");
		Vector3 vector = base.transform.right * axis + base.transform.forward * axis2;
		base.transform.position += vector * moveSpeed * Time.deltaTime;
		float num = Input.GetAxis("Mouse X") * mouseSensitivity;
		float num2 = Input.GetAxis("Mouse Y") * mouseSensitivity;
		base.transform.Rotate(Vector3.up * num);
		rotationX -= num2;
		rotationX = Mathf.Clamp(rotationX, -80f, 80f);
		cameraTransform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
	}
}
