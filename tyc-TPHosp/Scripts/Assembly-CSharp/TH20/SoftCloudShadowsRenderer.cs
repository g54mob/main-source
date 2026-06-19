using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace TH20
{
	public sealed class SoftCloudShadowsRenderer : PostProcessEffectRenderer<SoftCloudShadowsSettings>
	{
		private Shader _shader;

		private string _sampleName = "SoftCloudShadowsRenderer";

		public override void Init()
		{
			base.Init();
			_shader = Shader.Find("Hidden/Soft Cloud Shadows");
		}

		public override void Release()
		{
			base.Release();
		}

		public override void Render(PostProcessRenderContext context)
		{
			context.command.BeginSample(_sampleName);
			if (PostProcessingRendererProxy.Instance.PostProcessRendererData == null)
			{
				context.command.BlitFullscreenTriangle(context.source, context.destination);
				context.command.EndSample(_sampleName);
				return;
			}
			PropertySheet propertySheet = context.propertySheets.Get(_shader);
			propertySheet.properties.SetFloat("_ShadowStrength", base.settings.ShadowAlpha);
			propertySheet.properties.SetFloat("_CloudTextureScale", base.settings.TextureScale);
			propertySheet.properties.SetTexture("_CloudTex", PostProcessingRendererProxy.Instance.PostProcessRendererData.SoftCloudTexture);
			propertySheet.properties.SetVector("_CloudMovementSpeed", new Vector4(base.settings.ScrollSpeedX, base.settings.ScrollSpeedY, 0f, 0f));
			propertySheet.properties.SetMatrix("_ClipToWorld", (context.camera.projectionMatrix * context.camera.worldToCameraMatrix).inverse);
			context.command.BlitFullscreenTriangle(context.source, context.destination, propertySheet, 0);
			context.command.EndSample(_sampleName);
		}
	}
}
