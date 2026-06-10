using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public sealed class PostProcessHighlightRenderer : PostProcessEffectRenderer<PostProcessHighlight>
{
	public override void Render(PostProcessRenderContext context)
	{
		PropertySheet propertySheet = context.propertySheets.Get(Shader.Find("Hidden/Harryh___h/Highlight"));
		propertySheet.properties.SetFloat("_Scale", base.settings.scale);
		propertySheet.properties.SetFloat("_Shine", base.settings.shine);
		propertySheet.properties.SetFloat("_Shadow", base.settings.shadow);
		propertySheet.properties.SetFloat("_Rotations", (int)base.settings.rotations);
		propertySheet.properties.SetFloat("_DepthThreshold", base.settings.depthThreshold);
		context.command.BlitFullscreenTriangle(context.source, context.destination, propertySheet, 0);
	}
}
