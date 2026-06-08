using UnityEngine;

[ExecuteInEditMode]
public class CameraQuickDepth : ImageEffectBase
{
	public static CameraQuickDepth Instance;

	public RenderTexture depthTexture;

	private void OnPreRender()
	{
		Instance = this;
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		if (depthTexture != null)
		{
			base.material.SetTexture("_DepthTex", depthTexture);
		}
		Graphics.Blit(src, dest, base.material);
	}
}
