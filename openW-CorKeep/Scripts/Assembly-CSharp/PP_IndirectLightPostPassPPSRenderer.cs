using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Scripting;

[Preserve]
public sealed class PP_IndirectLightPostPassPPSRenderer : PostProcessEffectRenderer<PP_IndirectLightPostPassPPSSettings>
{
	public override void Render(PostProcessRenderContext context)
	{
		PropertySheet propertySheet = context.propertySheets.Get(Shader.Find("PP_IndirectLightPostPass"));
		propertySheet.properties.SetFloat("_Strength", base.settings.strength);
		context.command.BlitFullscreenTriangle(context.source, context.destination, propertySheet, 0);
	}
}
