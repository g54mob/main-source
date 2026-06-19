using InControl;
using UnityEngine;

public class TitleCamera : MonoBehaviour
{
	private Vector3 rotMov = new Vector3(5f, 5f, 0f);

	private void Update()
	{
		LerpCamera();
	}

	private void LerpCamera()
	{
		Vector3 vector = Camera.main.ScreenToViewportPoint(InputManager.MouseProvider.GetPosition());
		float x = vector.y * rotMov.x - rotMov.x / 2f;
		float y = (1f - vector.x) * rotMov.y - rotMov.y / 2f;
		float z = vector.z * rotMov.z - rotMov.z / 2f;
		base.transform.localEulerAngles = new Vector3(x, y, z);
	}
}
