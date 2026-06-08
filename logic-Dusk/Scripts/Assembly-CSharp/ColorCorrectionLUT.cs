using UnityEngine;

[AddComponentMenu("Image Effects/Cale/Color Correction LUT")]
[ExecuteInEditMode]
public class ColorCorrectionLUT : ImageEffectBase
{
	public Texture textureRamp;

	public Vector4 offset;

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetTexture("_RampTex", textureRamp);
		base.material.SetVector("_Off", offset);
		Graphics.Blit(source, destination, base.material);
	}
}
