using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Scripting;

[Preserve]
public sealed class PP_IndirectLightPassPPSRenderer : PostProcessEffectRenderer<PP_IndirectLightPassPPSSettings>
{
	public override void Render(PostProcessRenderContext context)
	{
		PropertySheet propertySheet = context.propertySheets.Get(Shader.Find("PP_MergeFakeLightPass"));
		context.command.BlitFullscreenTriangle(context.source, context.destination, propertySheet, 0);
		propertySheet = context.propertySheets.Get(Shader.Find("PP_IndirectLightPass"));
		bool flag = false;
		for (int i = 0; i <= Mathf.Clamp(base.settings.passes, 0, 10000); i++)
		{
			propertySheet.properties.SetInt("_Pass", i);
			if (flag)
			{
				context.command.BlitFullscreenTriangle(context.source, context.destination, propertySheet, 0);
			}
			else
			{
				context.command.BlitFullscreenTriangle(context.destination, context.source, propertySheet, 0);
			}
			flag = !flag;
		}
	}
}
