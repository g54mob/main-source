using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace SCPE
{
	public sealed class TransitionRenderer : PostProcessEffectRenderer<Transition>
	{
		private Shader shader;

		public override void Init()
		{
			shader = Shader.Find("Hidden/SC Post Effects/Transition");
		}

		public override void Release()
		{
			base.Release();
		}

		public override void Render(PostProcessRenderContext context)
		{
			PropertySheet propertySheet = context.propertySheets.Get(shader);
			propertySheet.properties.SetFloat("_Progress", base.settings.progress.value);
			Texture value = ((base.settings.gradientTex.value == null) ? RuntimeUtilities.whiteTexture : base.settings.gradientTex.value);
			propertySheet.properties.SetTexture("_Gradient", value);
			context.command.BlitFullscreenTriangle(context.source, context.destination, propertySheet, 0);
		}
	}
}
