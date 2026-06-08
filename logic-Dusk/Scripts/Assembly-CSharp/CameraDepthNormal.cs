using UnityEngine;

[ExecuteInEditMode]
public class CameraDepthNormal : ImageEffectBase
{
	public Texture2D dotTexture;

	private new void Start()
	{
		GetComponent<Camera>().depthTextureMode = DepthTextureMode.DepthNormals;
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (dotTexture != null)
		{
			base.material.SetTexture("_ProjectTex", dotTexture);
		}
		Graphics.Blit(source, destination, base.material);
	}
}
