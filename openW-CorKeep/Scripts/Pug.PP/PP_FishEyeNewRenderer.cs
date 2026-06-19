using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Scripting;

[Preserve]
public sealed class PP_FishEyeNewRenderer : PostProcessEffectRenderer<PP_FishEyeNew>
{
	public override void Render(PostProcessRenderContext context)
	{
		PropertySheet propertySheet = context.propertySheets.Get(Shader.Find("Radical/PostProcessing/PP_FishEyeNew"));
		propertySheet.properties.SetFloat("_Scale", base.settings._scale);
		propertySheet.properties.SetFloat("_PlayerX", base.settings.playerX);
		propertySheet.properties.SetFloat("_PlayerY", base.settings.playerY);
		context.command.BlitFullscreenTriangle(context.source, context.destination, propertySheet, 0);
	}
}
