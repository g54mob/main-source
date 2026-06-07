using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
	public LayerMask cameraCollision;

	private RaycastHit hit;

	public Transform linecastTarget;

	public Transform target;

	private float mouseX;

	private float mouseY;

	public float zOffset = 2f;

	public float scrollSpeed;

	public float yMin;

	public float yMax;

	private void Update()
	{
		if (Input.GetAxis("Mouse ScrollWheel") != 0f)
		{
			zOffset -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
		}
		zOffset = Mathf.Clamp(zOffset, 1f, 3f);
		linecastTarget.localPosition = new Vector3(linecastTarget.localPosition.x, linecastTarget.localPosition.y, zOffset);
		NormalCamControl();
		if (Physics.Linecast(target.position, linecastTarget.position, out hit, cameraCollision))
		{
			base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(0f, 0f, hit.distance * 0.52f), Time.deltaTime * 25f);
		}
		else
		{
			base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(0f, 0f, zOffset), Time.deltaTime * 20f);
		}
	}

	private void NormalCamControl()
	{
		mouseX += Input.GetAxisRaw("Mouse X") * 1f * PlayerPrefs.GetFloat("Sensitivity");
		mouseY += Input.GetAxisRaw("Mouse Y") * 1f * PlayerPrefs.GetFloat("Sensitivity");
		mouseY = Mathf.Clamp(mouseY, yMin, yMax);
		base.transform.LookAt(target);
		target.rotation = Quaternion.Euler(mouseY, mouseX, 0f);
	}
}
