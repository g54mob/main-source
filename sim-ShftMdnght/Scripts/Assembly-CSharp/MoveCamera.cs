using UnityEngine;

public class MoveCamera : MonoBehaviour
{
	public float turnSpeed = 4f;

	public float panSpeed = 4f;

	public float zoomSpeed = 4f;

	private Vector3 mouseOrigin;

	private bool isPanning;

	private bool isRotating;

	private bool isZooming;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			mouseOrigin = Input.mousePosition;
			isRotating = true;
		}
		if (Input.GetMouseButtonDown(1))
		{
			mouseOrigin = Input.mousePosition;
			isPanning = true;
		}
		if (Input.GetMouseButtonDown(2))
		{
			mouseOrigin = Input.mousePosition;
			isZooming = true;
		}
		if (!Input.GetMouseButton(0))
		{
			isRotating = false;
		}
		if (!Input.GetMouseButton(1))
		{
			isPanning = false;
		}
		if (!Input.GetMouseButton(2))
		{
			isZooming = false;
		}
		if (isRotating)
		{
			Vector3 vector = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
			base.transform.RotateAround(base.transform.position, base.transform.right, (0f - vector.y) * turnSpeed);
			base.transform.RotateAround(base.transform.position, Vector3.up, vector.x * turnSpeed);
		}
		if (isPanning)
		{
			Vector3 vector2 = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
			Vector3 translation = new Vector3(vector2.x * panSpeed, vector2.y * panSpeed, 0f);
			base.transform.Translate(translation, Space.Self);
		}
		if (isZooming)
		{
			Vector3 translation2 = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin).y * zoomSpeed * base.transform.forward;
			base.transform.Translate(translation2, Space.World);
		}
	}
}
