using UnityEngine;

[ExecuteInEditMode]
public class CameraDebugMerge : ImageEffectBase
{
	[Header("Debug Options ---")]
	public bool DebugShowTextureBombResult;

	public bool DebugShowDepthResult;

	public bool DebugShowDepthBandResult;

	public bool DebugShowDepthColorResult;

	public bool DebugShowLightMaskResult;

	public bool DebugShowNormalResult;

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		if (CameraReplacementTest.Instance != null)
		{
			base.material.SetTexture("_TextureBombTex", CameraReplacementTest.TextureBombRT);
			base.material.SetTexture("_OtherTex", CameraReplacementTest.NormalRT);
			base.material.SetTexture("_LightMaskTex", CameraReplacementTest.Instance.lightRT);
			if (DebugShowTextureBombResult)
			{
				base.material.SetFloat("_RenderJustTextureBomb", 1f);
			}
			else
			{
				base.material.SetFloat("_RenderJustTextureBomb", 0f);
			}
			if (DebugShowDepthResult)
			{
				base.material.SetTexture("_DepthTex", CameraReplacementTest.Instance.depthRT);
				base.material.SetFloat("_RenderJustDepth", 1f);
			}
			else
			{
				base.material.SetFloat("_RenderJustDepth", 0f);
			}
			if (DebugShowDepthBandResult)
			{
				base.material.SetTexture("_DepthTex", CameraReplacementTest.Instance.depthRT);
				base.material.SetFloat("_RenderJustDepth", 0f);
				base.material.SetFloat("_RenderJustDepthBand", 1f);
			}
			else
			{
				base.material.SetFloat("_RenderJustDepthBand", 0f);
			}
			if (DebugShowDepthColorResult)
			{
				base.material.SetTexture("_DepthTex", CameraReplacementTest.Instance.depthRT);
				base.material.SetFloat("_RenderJustDepth", 0f);
				base.material.SetFloat("_RenderJustDepthBand", 0f);
				base.material.SetFloat("_RenderJustDepthColor", 1f);
			}
			else
			{
				base.material.SetFloat("_RenderJustDepthColor", 0f);
			}
			if (DebugShowNormalResult)
			{
				base.material.SetFloat("_RenderJustOther", 1f);
			}
			else
			{
				base.material.SetFloat("_RenderJustOther", 0f);
			}
			if (DebugShowLightMaskResult)
			{
				base.material.SetFloat("_RenderJustLightMask", 1f);
			}
			else
			{
				base.material.SetFloat("_RenderJustLightMask", 0f);
			}
		}
		else
		{
			Debug.Log("Do not include or enable this component without first inclusing and enabling CameraReplacementTest");
		}
		Graphics.Blit(src, dest, base.material);
	}
}
