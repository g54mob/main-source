using UnityEngine;

[ExecuteInEditMode]
public class CameraDistortionScroller : ImageEffectBase
{
	public Texture DistortionTexture;

	public bool InvertYAxis;

	public float DistortionStrength = 0.075f;

	public float OverlayStrength = 0.25f;

	public float MoveSpeedFactorX = 0.05f;

	public float MoveSpeedFactorY = 0.25f;

	private void OnDestroy()
	{
		DistortionTexture = null;
	}

	private void Update()
	{
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		base.material.SetFloat("_InvertY", (!InvertYAxis) ? 0f : 1f);
		base.material.SetFloat("_DistortionStrength", DistortionStrength);
		base.material.SetFloat("_MoveSpeedFactorX", MoveSpeedFactorX);
		base.material.SetFloat("_MoveSpeedFactorY", MoveSpeedFactorY);
		base.material.SetTexture("_DistTex", DistortionTexture);
		Graphics.Blit(src, dest, base.material);
	}
}
