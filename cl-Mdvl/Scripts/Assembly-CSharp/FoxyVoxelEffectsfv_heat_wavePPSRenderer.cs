using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public sealed class FoxyVoxelEffectsfv_heat_wavePPSRenderer : PostProcessEffectRenderer<HeatWavePPSSettings>
{
	public override void Render(PostProcessRenderContext context)
	{
		PropertySheet propertySheet = context.propertySheets.Get(Shader.Find("FoxyVoxel/Effects/fv_heat_wave"));
		if (base.settings._vignette.value != null)
		{
			propertySheet.properties.SetTexture("_vignette", base.settings._vignette);
		}
		propertySheet.properties.SetFloat("_BlurSize", base.settings._BlurSize);
		context.command.BlitFullscreenTriangle(context.source, context.destination, propertySheet, 0);
	}
}
