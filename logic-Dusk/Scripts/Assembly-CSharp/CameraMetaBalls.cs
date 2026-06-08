using UnityEngine;

[ExecuteInEditMode]
public class CameraMetaBalls : ImageEffectBase
{
	public float WobbleAmount = 1f;

	public float WobbleSpeed = 1f;

	public Texture NoiseTexture;

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		if (NoiseTexture != null)
		{
			base.material.SetTexture("_NoiseTex", NoiseTexture);
		}
		else
		{
			Debug.Log("No/Invalid Noise Texture!");
		}
		base.material.SetFloat("_WobbleAmount", WobbleAmount);
		base.material.SetFloat("_WobbleSpeed", WobbleSpeed);
		Graphics.Blit(src, dest, base.material);
	}
}
