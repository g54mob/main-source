using UnityEngine;

[ExecuteInEditMode]
public class CameraNoProperty : ImageEffectBase
{
	protected override void Start()
	{
		GetComponent<Camera>().depthTextureMode = DepthTextureMode.DepthNormals;
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		GetComponent<Camera>().depthTextureMode = DepthTextureMode.DepthNormals;
		Graphics.Blit(src, dest, base.material);
	}
}
