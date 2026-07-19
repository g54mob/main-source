using UnityEngine;
using UnityEngine.UI;

public class RenderCamera : MonoBehaviour
{
	public bool render = true;

	public RawImage target;

	private RenderTexture renderTexture;

	private Camera gizmoCamera;

	private void Awake()
	{
		gizmoCamera = GetComponent<Camera>();
		if (render)
		{
			Global.onWindowResize += WindowResize;
			WindowResize();
		}
	}

	private void WindowResize()
	{
		if (gizmoCamera.targetTexture != null)
		{
			gizmoCamera.targetTexture.Release();
		}
		renderTexture = new RenderTexture(Screen.width, Screen.height, 24, RenderTextureFormat.ARGB32);
		gizmoCamera.targetTexture = renderTexture;
		target.texture = renderTexture;
	}
}
