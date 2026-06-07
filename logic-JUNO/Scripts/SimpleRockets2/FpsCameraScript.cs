using UnityEngine;

public class FpsCameraScript : MonoBehaviour
{
	public float mainSpeed = 100f;

	public float shiftAdd = 250f;

	public float maxShift = 1000f;

	public float camSens = 0.25f;

	private float totalRun = 1f;

	private bool isRotating;

	private float speedMultiplier;

	public float mouseSensitivity = 5f;

	private float rotationY;

	private float rotationZ;

	private void Update()
	{
		if (Input.GetMouseButtonDown(1))
		{
			isRotating = true;
		}
		if (Input.GetMouseButtonUp(1))
		{
			isRotating = false;
		}
		if (isRotating)
		{
			float y = base.transform.localEulerAngles.y + Input.GetAxis("MouseAxis1") * mouseSensitivity;
			rotationY += Input.GetAxis("MouseAxis2") * mouseSensitivity;
			if (Input.GetKey(KeyCode.Q))
			{
				rotationZ += 360f * Time.deltaTime * speedMultiplier * 30f;
			}
			if (Input.GetKey(KeyCode.E))
			{
				rotationZ -= 360f * Time.deltaTime * speedMultiplier * 30f;
			}
			base.transform.localEulerAngles = new Vector3(0f - rotationY, y, rotationZ);
		}
		Vector3 vector = GetBaseInput();
		if (Input.GetKey(KeyCode.LeftShift))
		{
			totalRun += Time.deltaTime;
			vector = vector * totalRun * shiftAdd;
			vector.x = Mathf.Clamp(vector.x, 0f - maxShift, maxShift);
			vector.y = Mathf.Clamp(vector.y, 0f - maxShift, maxShift);
			vector.z = Mathf.Clamp(vector.z, 0f - maxShift, maxShift);
			speedMultiplier = totalRun * shiftAdd * Time.deltaTime;
			speedMultiplier = Mathf.Clamp(speedMultiplier, 0f - maxShift, maxShift);
		}
		else
		{
			totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
			vector *= mainSpeed;
			speedMultiplier = mainSpeed * Time.deltaTime;
		}
		vector *= Time.deltaTime;
		Vector3 position = base.transform.position;
		base.transform.Translate(vector);
		position.x = base.transform.position.x;
		position.z = base.transform.position.z;
		base.transform.localPosition += base.transform.TransformDirection(vector);
	}

	public bool amIRotating()
	{
		return isRotating;
	}

	private Vector3 GetBaseInput()
	{
		Vector3 result = default(Vector3);
		if (Input.GetKey(KeyCode.W))
		{
			result += new Vector3(0f, 0f, 1f);
		}
		if (Input.GetKey(KeyCode.S))
		{
			result += new Vector3(0f, 0f, -1f);
		}
		if (Input.GetKey(KeyCode.A))
		{
			result += new Vector3(-1f, 0f, 0f);
		}
		if (Input.GetKey(KeyCode.D))
		{
			result += new Vector3(1f, 0f, 0f);
		}
		return result;
	}
}
