using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace SCPE
{
	public sealed class SharpenRenderer : PostProcessEffectRenderer<Sharpen>
	{
		private Shader shader;

		public override void Init()
		{
			shader = Shader.Find("Hidden/SC Post Effects/Sharpen");
		}

		public override void Release()
		{
			base.Release();
		}

		public override void Render(PostProcessRenderContext context)
		{
			PropertySheet propertySheet = context.propertySheets.Get(shader);
			propertySheet.properties.SetVector("_Params", new Vector4(base.settings.amount, base.settings.radius, 0f, 0f));
			context.command.BlitFullscreenTriangle(context.source, context.destination, propertySheet, 0);
		}
	}
}
