using UnityEngine;

[ExecuteInEditMode]
public class CameraDistortion : ImageEffectBase
{
	public Texture DistortionTexture;

	public bool InvertYAxis;

	public float NoiseStrength = 0.075f;

	public bool EnableMovement = true;

	public float MoveSpeedFactorX = 0.05f;

	public float MoveSpeedFactorY = 0.25f;

	private void Update()
	{
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		base.material.SetFloat("_InvertY", (!InvertYAxis) ? 0f : 1f);
		base.material.SetFloat("_NoiseStrength", NoiseStrength);
		base.material.SetFloat("_EnableMovement", (!EnableMovement) ? 0f : 1f);
		base.material.SetFloat("_MoveSpeedFactorX", MoveSpeedFactorX);
		base.material.SetFloat("_MoveSpeedFactorY", MoveSpeedFactorY);
		if (DistortionTexture != null)
		{
			base.material.SetTexture("_DistTex", DistortionTexture);
		}
		else
		{
			Debug.Log("No/Invalid Distortion Texture!");
		}
		Graphics.Blit(src, dest, base.material);
	}
}
