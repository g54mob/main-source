using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MatchMainCamera : MonoBehaviour
{
	public Camera mainCamera;

	private Camera thisWaterCamera;

	private void Start()
	{
		thisWaterCamera = GetComponent<Camera>();
	}

	private void LateUpdate()
	{
		if (mainCamera == null)
		{
			Debug.LogError("Main Camera is not assigned to MatchMainCamera script!");
			return;
		}
		base.transform.position = mainCamera.transform.position;
		if (thisWaterCamera.orthographic)
		{
			thisWaterCamera.orthographicSize = mainCamera.orthographicSize;
		}
	}
}
