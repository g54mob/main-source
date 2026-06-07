using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace SCPE
{
	public sealed class DitheringRenderer : PostProcessEffectRenderer<Dithering>
	{
		private Shader shader;

		public override void Init()
		{
			shader = Shader.Find("Hidden/SC Post Effects/Dithering");
		}

		public override void Release()
		{
			base.Release();
		}

		public override void Render(PostProcessRenderContext context)
		{
			PropertySheet propertySheet = context.propertySheets.Get(shader);
			Texture value = ((base.settings.lut.value == null) ? RuntimeUtilities.blackTexture : base.settings.lut.value);
			propertySheet.properties.SetTexture("_LUT", value);
			float z = ((QualitySettings.activeColorSpace == ColorSpace.Gamma) ? Mathf.LinearToGammaSpace(base.settings.luminanceThreshold.value) : base.settings.luminanceThreshold.value);
			Vector4 value2 = new Vector4(0f, base.settings.tiling, z, base.settings.intensity);
			propertySheet.properties.SetVector("_Dithering_Coords", value2);
			context.command.BlitFullscreenTriangle(context.source, context.destination, propertySheet, 0);
		}
	}
}
