using UnityEngine;

[AddComponentMenu("Image Effects/HeatWave")]
[ExecuteInEditMode]
public class GlitchOffset : ImageEffectBase
{
	public float xStrength = 0.1f;

	public float yStrength = 1f;

	public float radialStrength = 1f;

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetVector("_Shape", new Vector4(xStrength, yStrength, radialStrength, 0f));
		Graphics.Blit(source, destination, base.material);
	}
}
