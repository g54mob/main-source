using UnityEngine;

public class UIFaceCamera : MonoBehaviour
{
	private Camera mainCamera;

	private void Start()
	{
		mainCamera = Camera.main;
	}

	private void LateUpdate()
	{
		if (mainCamera != null)
		{
			base.transform.LookAt(base.transform.position + mainCamera.transform.forward);
		}
	}
}
