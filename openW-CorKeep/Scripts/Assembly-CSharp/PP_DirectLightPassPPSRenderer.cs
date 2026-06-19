using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Scripting;

[Preserve]
public sealed class PP_DirectLightPassPPSRenderer : PostProcessEffectRenderer<PP_DirectLightPassPPSSettings>
{
	private readonly int occlusionId = Shader.PropertyToID("OcclusionID");

	private readonly int directLightId = Shader.PropertyToID("DirectLightID");

	public override void Render(PostProcessRenderContext context)
	{
		PropertySheet propertySheet = context.propertySheets.Get(Shader.Find("PP_OcclusionFilter"));
		context.command.BlitFullscreenTriangle(context.source, context.destination, propertySheet, 0);
		context.command.GetTemporaryRT(occlusionId, 576, 336, 1, FilterMode.Point, RenderTextureFormat.DefaultHDR);
		context.command.CopyTexture(context.destination, occlusionId);
		context.command.SetGlobalTexture("OcclusionTex", occlusionId);
		propertySheet = context.propertySheets.Get(Shader.Find("PP_DirectLightPass"));
		context.command.BlitFullscreenTriangle(context.source, context.destination, propertySheet, 0);
		context.command.GetTemporaryRT(directLightId, 576, 336, 1, FilterMode.Point, RenderTextureFormat.DefaultHDR);
		context.command.CopyTexture(context.destination, directLightId);
		context.command.SetGlobalTexture("DirectLightTex", directLightId);
	}
}
