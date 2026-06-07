using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

namespace SCPE
{
	public sealed class BlurRenderer : PostProcessEffectRenderer<Blur>
	{
		private enum Pass
		{
			Blend = 0,
			BlendDepthFade = 1,
			Gaussian = 2,
			Box = 3
		}

		private Shader shader;

		private int screenCopyID;

		public override void Init()
		{
			shader = Shader.Find("Hidden/SC Post Effects/Blur");
			screenCopyID = Shader.PropertyToID("_ScreenCopyTexture");
		}

		public override void Render(PostProcessRenderContext context)
		{
			PropertySheet propertySheet = context.propertySheets.Get(shader);
			CommandBuffer command = context.command;
			command.GetTemporaryRT(screenCopyID, context.width, context.height, 0, FilterMode.Bilinear, context.sourceFormat);
			command.Blit(context.source, screenCopyID);
			int num = Shader.PropertyToID("_Temp1");
			int num2 = Shader.PropertyToID("_Temp2");
			command.GetTemporaryRT(num, context.screenWidth / (int)base.settings.downscaling, context.screenHeight / (int)base.settings.downscaling, 0, FilterMode.Bilinear);
			command.GetTemporaryRT(num2, context.screenWidth / (int)base.settings.downscaling, context.screenHeight / (int)base.settings.downscaling, 0, FilterMode.Bilinear);
			command.Blit(screenCopyID, num);
			int pass = (((Blur.BlurMethod)base.settings.mode == Blur.BlurMethod.Gaussian) ? 2 : 3);
			for (int i = 0; i < (int)base.settings.iterations; i++)
			{
				if ((int)base.settings.iterations > 12)
				{
					return;
				}
				command.SetGlobalVector("_BlurOffsets", new Vector4((float)base.settings.amount / (float)context.screenWidth, 0f, 0f, 0f));
				context.command.BlitFullscreenTriangle(num, num2, propertySheet, pass);
				command.SetGlobalVector("_BlurOffsets", new Vector4(0f, (float)base.settings.amount / (float)context.screenHeight, 0f, 0f));
				context.command.BlitFullscreenTriangle(num2, num, propertySheet, pass);
				if ((bool)base.settings.highQuality)
				{
					command.SetGlobalVector("_BlurOffsets", new Vector4((float)base.settings.amount / (float)context.screenWidth, 0f, 0f, 0f));
					context.command.BlitFullscreenTriangle(num, num2, propertySheet, pass);
					command.SetGlobalVector("_BlurOffsets", new Vector4(0f, (float)base.settings.amount / (float)context.screenHeight, 0f, 0f));
					context.command.BlitFullscreenTriangle(num2, num, propertySheet, pass);
				}
			}
			command.SetGlobalTexture("_BlurredTex", num);
			if (base.settings.distanceFade.value)
			{
				command.SetGlobalVector("_FadeParams", new Vector4(base.settings.startFadeDistance.value, base.settings.endFadeDistance.value, 0f, 0f));
			}
			command.BlitFullscreenTriangle(context.source, context.destination, propertySheet, base.settings.distanceFade.value ? 1 : 0);
			command.ReleaseTemporaryRT(screenCopyID);
			command.ReleaseTemporaryRT(num);
			command.ReleaseTemporaryRT(num2);
		}
	}
}
