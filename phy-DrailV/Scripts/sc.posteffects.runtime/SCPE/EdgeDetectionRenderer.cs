using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace SCPE
{
	public sealed class EdgeDetectionRenderer : PostProcessEffectRenderer<EdgeDetection>
	{
		private Shader shader;

		public override void Init()
		{
			shader = Shader.Find("Hidden/SC Post Effects/Edge Detection");
		}

		public override void Release()
		{
			base.Release();
		}

		public override void Render(PostProcessRenderContext context)
		{
			PropertySheet propertySheet = context.propertySheets.Get(shader);
			_ = context.command;
			Vector2 vector = new Vector2(base.settings.sensitivityDepth, base.settings.sensitivityNormals);
			propertySheet.properties.SetVector("_Sensitivity", vector);
			propertySheet.properties.SetFloat("_BackgroundFade", base.settings.debug ? 1f : 0f);
			propertySheet.properties.SetFloat("_EdgeSize", (int)base.settings.edgeSize);
			propertySheet.properties.SetFloat("_Exponent", base.settings.edgeExp);
			propertySheet.properties.SetFloat("_Threshold", base.settings.lumThreshold);
			propertySheet.properties.SetColor("_EdgeColor", base.settings.edgeColor);
			propertySheet.properties.SetFloat("_EdgeOpacity", base.settings.edgeOpacity);
			propertySheet.properties.SetVector("_FadeParams", new Vector4(base.settings.startFadeDistance.value, base.settings.endFadeDistance.value, base.settings.invertFadeDistance.value ? 1 : 0, base.settings.distanceFade.value ? 1 : 0));
			propertySheet.properties.SetVector("_SobelParams", new Vector4(base.settings.sobelThin ? 1 : 0, 0f, 0f, 0f));
			context.command.BlitFullscreenTriangle(context.source, context.destination, propertySheet, (int)base.settings.mode.value);
		}

		public override DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.DepthNormals;
		}
	}
}
