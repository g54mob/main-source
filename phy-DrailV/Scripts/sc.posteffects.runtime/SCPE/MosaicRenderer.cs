using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace SCPE
{
	public sealed class MosaicRenderer : PostProcessEffectRenderer<Mosaic>
	{
		private Shader shader;

		public override void Init()
		{
			shader = Shader.Find("Hidden/SC Post Effects/Mosaic");
		}

		public override void Release()
		{
			base.Release();
		}

		public override void Render(PostProcessRenderContext context)
		{
			PropertySheet propertySheet = context.propertySheets.Get(shader);
			float num = base.settings.size.value;
			switch ((Mosaic.MosaicMode)base.settings.mode)
			{
			case Mosaic.MosaicMode.Triangles:
				num = 10f / base.settings.size.value;
				break;
			case Mosaic.MosaicMode.Hexagons:
				num = base.settings.size.value / 10f;
				break;
			case Mosaic.MosaicMode.Circles:
				num = (1f - base.settings.size.value) * 100f;
				break;
			}
			Vector4 value = new Vector4(num, (float)(context.screenWidth * 2 / context.screenHeight) * num / Mathf.Sqrt(3f), 0f, 0f);
			propertySheet.properties.SetVector("_Params", value);
			context.command.BlitFullscreenTriangle(context.source, context.destination, propertySheet, (int)base.settings.mode.value);
		}
	}
}
