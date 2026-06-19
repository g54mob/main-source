using UnityEngine;

public class CameraMatrixScaler : MonoBehaviour
{
	public Camera gameCamera;

	public bool update = true;

	private void Update()
	{
		if (update)
		{
			Matrix4x4 projectionMatrix = gameCamera.projectionMatrix;
			projectionMatrix[1, 1] *= Mathf.Sqrt(2f);
			gameCamera.projectionMatrix = projectionMatrix;
			update = false;
		}
	}
}
