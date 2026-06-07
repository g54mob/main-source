using UnityEngine;

public class RenderScale : MonoBehaviour
{
	public Camera camera;

	[Range(0.01f, 1f)]
	public float renderScale;

	public FilterMode filterMode;

	private Rect originalRect;

	private Rect scaledRect;

	private void OnDestroy()
	{
	}

	private void OnPreRender()
	{
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
	}
}
