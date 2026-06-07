using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace SCPE
{
	public sealed class SpeedLinesRenderer : PostProcessEffectRenderer<SpeedLines>
	{
		private Shader shader;

		public override void Init()
		{
			shader = Shader.Find("Hidden/SC Post Effects/SpeedLines");
		}

		public override void Release()
		{
			base.Release();
		}

		public override void Render(PostProcessRenderContext context)
		{
			PropertySheet propertySheet = context.propertySheets.Get(shader);
			float y = 2f + (base.settings.falloff.value - 0f) * 14f / 1f;
			propertySheet.properties.SetVector("_Params", new Vector4(base.settings.intensity.value, y, base.settings.size.value * 2f, 0f));
			if ((bool)base.settings.noiseTex.value)
			{
				propertySheet.properties.SetTexture("_NoiseTex", base.settings.noiseTex.value);
			}
			context.command.BlitFullscreenTriangle(context.source, context.destination, propertySheet, 0);
		}
	}
}
