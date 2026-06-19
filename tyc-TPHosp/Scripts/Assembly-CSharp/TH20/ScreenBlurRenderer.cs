using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

namespace TH20
{
	public sealed class ScreenBlurRenderer : PostProcessEffectRenderer<ScreenBlurSettings>
	{
		private Shader _shader;

		private int _blurTemp_RT_ID;

		private int _sizeID;

		private int _guiBackgroundBlurID;

		private RenderTexture _guiBackgroundBlurRT;

		public override void Init()
		{
			base.Init();
			_shader = Shader.Find("Hidden/Screen Blur");
			_blurTemp_RT_ID = Shader.PropertyToID("_GuiBackgroundBlurTempRT");
			_sizeID = Shader.PropertyToID("_Size");
			_guiBackgroundBlurID = Shader.PropertyToID("_GuiBackgroundBlur");
		}

		public override void Release()
		{
			if (_guiBackgroundBlurRT != null)
			{
				_guiBackgroundBlurRT.Release();
				_guiBackgroundBlurRT = null;
			}
			base.Release();
		}

		public override void Render(PostProcessRenderContext context)
		{
			PropertySheet propertySheet = context.propertySheets.Get(_shader);
			int num = base.settings.renderTaragetFraction;
			if (_guiBackgroundBlurRT == null || _guiBackgroundBlurRT.width != context.width / num || _guiBackgroundBlurRT.height != context.height / num)
			{
				if (_guiBackgroundBlurRT != null)
				{
					_guiBackgroundBlurRT.Release();
					_guiBackgroundBlurRT = null;
				}
				_guiBackgroundBlurRT = new RenderTexture(context.width / num, context.height / num, 0, context.sourceFormat);
				Shader.SetGlobalTexture(_guiBackgroundBlurID, _guiBackgroundBlurRT);
			}
			context.command.GetTemporaryRT(_blurTemp_RT_ID, context.width / num, context.height / num, 0, FilterMode.Bilinear, context.sourceFormat);
			if ((bool)base.settings.resolutionIndependent)
			{
				float num2 = base.settings.resolutionIndependentBlurSize;
				propertySheet.properties.SetVector(_sizeID, new Vector2(num2, num2));
			}
			else
			{
				float num3 = base.settings.resolutionDependentBlurSize;
				propertySheet.properties.SetVector(_sizeID, new Vector2(num3 / (float)context.width, num3 / (float)context.height));
			}
			RenderTargetIdentifier renderTargetIdentifier;
			RenderTargetIdentifier renderTargetIdentifier2;
			if ((int)base.settings.blurSteps % 2 == 0)
			{
				renderTargetIdentifier = _blurTemp_RT_ID;
				renderTargetIdentifier2 = _guiBackgroundBlurRT;
			}
			else
			{
				renderTargetIdentifier = _guiBackgroundBlurRT;
				renderTargetIdentifier2 = _blurTemp_RT_ID;
			}
			context.command.BlitFullscreenTriangle(context.source, renderTargetIdentifier, propertySheet, 0);
			for (int i = 0; i < (int)base.settings.blurSteps; i++)
			{
				context.command.BlitFullscreenTriangle(renderTargetIdentifier, renderTargetIdentifier2, propertySheet, 0);
				RenderTargetIdentifier renderTargetIdentifier3 = renderTargetIdentifier;
				renderTargetIdentifier = renderTargetIdentifier2;
				renderTargetIdentifier2 = renderTargetIdentifier3;
			}
			context.command.ReleaseTemporaryRT(_blurTemp_RT_ID);
			context.command.BlitFullscreenTriangle(context.source, context.destination);
		}
	}
}
