using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

namespace SCPE
{
	public sealed class TiltShiftRenderer : PostProcessEffectRenderer<TiltShift>
	{
		private enum Pass
		{
			FragHorizontal = 0,
			FragHorizontalHQ = 1,
			FragRadial = 2,
			FragRadialHQ = 3,
			FragBlend = 4,
			FragDebug = 5
		}

		private Shader shader;

		private int screenCopyID;

		public override void Init()
		{
			shader = Shader.Find("Hidden/SC Post Effects/Tilt Shift");
			screenCopyID = Shader.PropertyToID("_ScreenCopyTexture");
		}

		public override void Render(PostProcessRenderContext context)
		{
			PropertySheet propertySheet = context.propertySheets.Get(shader);
			CommandBuffer command = context.command;
			propertySheet.properties.SetVector("_Params", new Vector4(base.settings.areaSize.value, base.settings.areaFalloff.value, base.settings.amount.value, (float)base.settings.mode.value));
			propertySheet.properties.SetFloat("_Offset", base.settings.offset.value);
			propertySheet.properties.SetFloat("_Angle", base.settings.angle.value * ((float)Math.PI / 180f));
			context.command.GetTemporaryRT(screenCopyID, context.width, context.height, 0, FilterMode.Bilinear, context.sourceFormat);
			int pass = (int)base.settings.mode.value + (int)base.settings.quality.value;
			switch ((int)base.settings.mode.value)
			{
			case 0:
				pass = (int)base.settings.quality.value;
				break;
			case 1:
				pass = (int)(2 + base.settings.quality.value);
				break;
			}
			command.BlitFullscreenTriangle(context.source, screenCopyID, propertySheet, pass);
			command.SetGlobalTexture("_BlurredTex", screenCopyID);
			command.BlitFullscreenTriangle(context.source, context.destination, propertySheet, TiltShift.debug ? 5 : 4);
			command.ReleaseTemporaryRT(screenCopyID);
		}
	}
}
