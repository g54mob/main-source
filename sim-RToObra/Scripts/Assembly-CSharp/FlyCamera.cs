using UnityEngine;

public class FlyCamera : MonoBehaviour
{
	public float cameraSensitivity = 90f;

	public float climbSpeed = 4f;

	public float normalMoveSpeed = 10f;

	public float slowMoveFactor = 0.25f;

	public float fastMoveFactor = 3f;

	private float rotationX;

	private float rotationY;

	private void Start()
	{
	}

	private void Update()
	{
		rotationX += RInput.GetAxis(2) * cameraSensitivity * Time.deltaTime;
		rotationY += RInput.GetAxis(3) * cameraSensitivity * Time.deltaTime;
		rotationY = Mathf.Clamp(rotationY, -90f, 90f);
		base.transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
		base.transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);
		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
		{
			base.transform.position += base.transform.forward * (normalMoveSpeed * fastMoveFactor) * RInput.GetAxis(1) * Time.deltaTime;
			base.transform.position += base.transform.right * (normalMoveSpeed * fastMoveFactor) * RInput.GetAxis(0) * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
		{
			base.transform.position += base.transform.forward * (normalMoveSpeed * slowMoveFactor) * RInput.GetAxis(1) * Time.deltaTime;
			base.transform.position += base.transform.right * (normalMoveSpeed * slowMoveFactor) * RInput.GetAxis(0) * Time.deltaTime;
		}
		else
		{
			base.transform.position += base.transform.forward * normalMoveSpeed * RInput.GetAxis(1) * Time.deltaTime;
			base.transform.position += base.transform.right * normalMoveSpeed * RInput.GetAxis(0) * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.E))
		{
			base.transform.position += base.transform.up * climbSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.X))
		{
			base.transform.position -= base.transform.up * climbSpeed * Time.deltaTime;
		}
	}
}
