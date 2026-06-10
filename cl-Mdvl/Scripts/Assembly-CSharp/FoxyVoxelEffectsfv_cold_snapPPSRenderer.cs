using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public sealed class FoxyVoxelEffectsfv_cold_snapPPSRenderer : PostProcessEffectRenderer<ColdSnapPPSSettings>
{
	public override void Render(PostProcessRenderContext context)
	{
		PropertySheet propertySheet = context.propertySheets.Get(Shader.Find("FoxyVoxel/Effects/fv_cold_snap"));
		if (base.settings._vignette.value != null)
		{
			propertySheet.properties.SetTexture("_vignette", base.settings._vignette);
		}
		if (base.settings._FrostNormal.value != null)
		{
			propertySheet.properties.SetTexture("_FrostNormal", base.settings._FrostNormal);
		}
		propertySheet.properties.SetVector("_VignetteScaleOffset", base.settings._VignetteScaleOffset);
		propertySheet.properties.SetFloat("_NormalScale", base.settings._NormalScale);
		propertySheet.properties.SetColor("_SnowColor", base.settings._SnowColor);
		propertySheet.properties.SetVector("_FrostWhiteScaleOffset", base.settings._FrostWhiteScaleOffset);
		propertySheet.properties.SetVector("_ShineScaleOffset", base.settings._ShineScaleOffset);
		context.command.BlitFullscreenTriangle(context.source, context.destination, propertySheet, 0);
	}
}
