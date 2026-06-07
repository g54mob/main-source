using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace SCPE
{
	public sealed class LUTRenderer : PostProcessEffectRenderer<LUT>
	{
		private Shader shader;

		public override void Init()
		{
			shader = Shader.Find("Hidden/SC Post Effects/LUT");
		}

		public override void Release()
		{
			base.Release();
		}

		public override void Render(PostProcessRenderContext context)
		{
			if (LUT.Bypass)
			{
				return;
			}
			PropertySheet propertySheet = context.propertySheets.Get(shader);
			if ((bool)base.settings.lutNear.value)
			{
				propertySheet.properties.SetTexture("_LUT_Near", base.settings.lutNear);
				propertySheet.properties.SetVector("_LUT_Params", new Vector4(1f / (float)base.settings.lutNear.value.width, 1f / (float)base.settings.lutNear.value.height, (float)base.settings.lutNear.value.height - 1f, base.settings.intensity));
			}
			if (base.settings.mode.value == LUT.Mode.DistanceBased)
			{
				context.command.SetGlobalVector("_FadeParams", new Vector4(base.settings.startFadeDistance.value, base.settings.endFadeDistance.value, 0f, 0f));
				if ((bool)base.settings.lutFar.value)
				{
					propertySheet.properties.SetTexture("_LUT_Far", base.settings.lutFar);
				}
			}
			propertySheet.properties.SetFloat("_Invert", base.settings.invert);
			context.command.BlitFullscreenTriangle(context.source, context.destination, propertySheet, (int)base.settings.mode.value);
		}
	}
}
