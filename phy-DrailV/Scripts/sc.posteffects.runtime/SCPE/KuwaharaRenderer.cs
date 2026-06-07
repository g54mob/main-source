using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace SCPE
{
	public sealed class KuwaharaRenderer : PostProcessEffectRenderer<Kuwahara>
	{
		private Shader shader;

		private int mode;

		public override void Init()
		{
			shader = Shader.Find("Hidden/SC Post Effects/Kuwahara");
		}

		public override void Release()
		{
			base.Release();
		}

		public override void Render(PostProcessRenderContext context)
		{
			mode = (int)base.settings.mode.value;
			if (context.camera.orthographic)
			{
				mode = 0;
			}
			PropertySheet propertySheet = context.propertySheets.Get(shader);
			propertySheet.properties.SetFloat("_Radius", (int)base.settings.radius);
			if (mode == 1)
			{
				context.command.SetGlobalVector("_FadeParams", new Vector4(base.settings.startFadeDistance.value, base.settings.endFadeDistance.value, 0f, 0f));
			}
			context.command.BlitFullscreenTriangle(context.source, context.destination, propertySheet, mode);
		}

		public override DepthTextureMode GetCameraFlags()
		{
			if (base.settings.mode.value == Kuwahara.KuwaharaMode.DepthFade)
			{
				return DepthTextureMode.Depth;
			}
			return DepthTextureMode.None;
		}
	}
}
