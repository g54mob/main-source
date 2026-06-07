using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace SCPE
{
	public sealed class PosterizeRenderer : PostProcessEffectRenderer<Posterize>
	{
		private Shader shader;

		public override void Init()
		{
			shader = Shader.Find("Hidden/SC Post Effects/Posterize");
		}

		public override void Render(PostProcessRenderContext context)
		{
			PropertySheet propertySheet = context.propertySheets.Get(shader);
			propertySheet.properties.SetVector("_Params", new Vector4(base.settings.hue.value, base.settings.saturation.value, base.settings.value.value, base.settings.levels.value));
			context.command.BlitFullscreenTriangle(context.source, context.destination, propertySheet, base.settings.hsvMode.value ? 1 : 0);
		}
	}
}
