using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace SCPE
{
	public sealed class HueShift3DRenderer : PostProcessEffectRenderer<HueShift3D>
	{
		private enum Pass
		{
			ColorSpectrum = 0,
			GradientTexture = 1
		}

		private Shader shader;

		public override void Init()
		{
			shader = Shader.Find("Hidden/SC Post Effects/3D Hue Shift");
		}

		public override void Release()
		{
			base.Release();
		}

		public override void Render(PostProcessRenderContext context)
		{
			PropertySheet propertySheet = context.propertySheets.Get(shader);
			HueShift3D.isOrtho = context.camera.orthographic;
			propertySheet.properties.SetVector("_Params", new Vector4(base.settings.speed.value, base.settings.size.value, base.settings.geoInfluence.value, base.settings.intensity.value));
			if ((bool)base.settings.gradientTex.value)
			{
				propertySheet.properties.SetTexture("_GradientTex", base.settings.gradientTex.value);
			}
			context.command.BlitFullscreenTriangle(context.source, context.destination, propertySheet, (base.settings.colorSource.value != HueShift3D.ColorSource.RGBSpectrum) ? 1 : 0);
		}

		public override DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.DepthNormals;
		}
	}
}
