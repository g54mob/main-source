using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace SCPE
{
	public sealed class RadialBlurRenderer : PostProcessEffectRenderer<RadialBlur>
	{
		private Shader shader;

		public override void Init()
		{
			shader = Shader.Find("Hidden/SC Post Effects/Radial Blur");
		}

		public override void Release()
		{
			base.Release();
		}

		public override void Render(PostProcessRenderContext context)
		{
			PropertySheet propertySheet = context.propertySheets.Get(shader);
			_ = context.command;
			propertySheet.properties.SetFloat("_Amount", base.settings.amount.value / 50f);
			propertySheet.properties.SetFloat("_Iterations", base.settings.iterations.value);
			context.command.BlitFullscreenTriangle(context.source, context.destination, propertySheet, 0);
		}
	}
}
