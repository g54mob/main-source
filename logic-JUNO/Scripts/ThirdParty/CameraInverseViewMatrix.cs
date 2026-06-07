using UnityEngine;

[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
public class CameraInverseViewMatrix : MonoBehaviour
{
	protected Camera camCamera;

	public Camera TargetCamera
	{
		get
		{
			if (camCamera == null)
			{
				camCamera = GetComponent<Camera>();
			}
			return camCamera;
		}
	}

	public void OnPreCull()
	{
		Shader.SetGlobalMatrix("_Camera2World", TargetCamera.cameraToWorldMatrix);
	}
}
