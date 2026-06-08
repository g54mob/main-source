using UnityEngine;

[ExecuteInEditMode]
public class CameraGrayscale : ImageEffectBase
{
	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		Graphics.Blit(src, dest, base.material);
	}
}
