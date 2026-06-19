using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace TH20
{
	[Serializable]
	[PostProcess(typeof(SoftCloudShadowsRenderer), PostProcessEvent.AfterStack, "Custom/Soft Cloud Shadows", false)]
	public sealed class SoftCloudShadowsSettings : PostProcessEffectSettings
	{
		[Range(0f, 1f)]
		public FloatParameter ShadowAlpha = new FloatParameter
		{
			value = 0.5f
		};

		[Range(0f, 10f)]
		public FloatParameter TextureScale = new FloatParameter
		{
			value = 1f
		};

		[Range(0f, 10f)]
		public FloatParameter ScrollSpeedX = new FloatParameter
		{
			value = 1f
		};

		[Range(0f, 10f)]
		public FloatParameter ScrollSpeedY = new FloatParameter
		{
			value = 1f
		};

		public override bool IsEnabledAndSupported(PostProcessRenderContext context)
		{
			if (PostProcessingRendererProxy.Instance.PostProcessRendererData != null && PostProcessingRendererProxy.Instance.PostProcessRendererData.EnableSoftCloudShadows)
			{
				return base.IsEnabledAndSupported(context);
			}
			return false;
		}
	}
}
