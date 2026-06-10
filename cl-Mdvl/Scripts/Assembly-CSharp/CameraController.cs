using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField]
	private float cameraMoveSpeed;

	[SerializeField]
	private float minFov;

	[SerializeField]
	private float maxFov;

	[SerializeField]
	private float zoomSensitivity;

	[SerializeField]
	private float rotateH;

	[SerializeField]
	private float rotateV;

	[SerializeField]
	private float minPitch;

	[SerializeField]
	private float maxPitch;

	private float yaw;

	private float pitch;

	private float yposition;

	private void Start()
	{
		yposition = base.transform.position.y;
	}

	private void Update()
	{
		Transform transform = base.transform;
		transform.position += transform.forward * (cameraMoveSpeed * Time.deltaTime * Input.GetAxis("Vertical"));
		transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0f, 0f) * (cameraMoveSpeed * Time.deltaTime), Space.Self);
		Vector3 eulerAngles = transform.eulerAngles;
		pitch = eulerAngles.x;
		yaw = eulerAngles.y;
		if (Input.GetMouseButton(2))
		{
			yaw += rotateH * Input.GetAxis("Mouse X");
			pitch -= rotateV * Input.GetAxis("Mouse Y");
			transform.eulerAngles = new Vector3(Mathf.Clamp(pitch, minPitch, maxPitch), yaw, 0f);
		}
		float fieldOfView = Camera.main.fieldOfView;
		fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;
		fieldOfView = Mathf.Clamp(fieldOfView, minFov, maxFov);
		Camera.main.fieldOfView = fieldOfView;
		Vector3 position = transform.position;
		position = new Vector3(position.x, yposition, position.z);
		transform.position = position;
	}
}
