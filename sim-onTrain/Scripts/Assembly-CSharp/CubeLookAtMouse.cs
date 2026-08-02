using UnityEngine;

public class CubeLookAtMouse : MonoBehaviour
{
	public Transform cameraTransform;

	private void Update()
	{
		base.transform.LookAt(cameraTransform.position + new Vector3((0f - ((float)(Screen.width / 2) - Input.mousePosition.x)) / (float)Screen.width, (0f - ((float)(Screen.height / 2) - Input.mousePosition.y)) / (float)Screen.height, 0.1f) * 15f);
	}
}
