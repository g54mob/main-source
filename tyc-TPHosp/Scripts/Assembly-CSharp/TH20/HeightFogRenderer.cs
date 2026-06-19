using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

namespace TH20
{
	public sealed class HeightFogRenderer : PostProcessEffectRenderer<HeightFogSettings>
	{
		private Shader _shader;

		public override void Init()
		{
			base.Init();
			_shader = Shader.Find("Hidden/Height Fog");
		}

		public override void Render(PostProcessRenderContext context)
		{
			context.command.BeginSample("Height Fog");
			PropertySheet propertySheet = context.propertySheets.Get(_shader);
			Matrix4x4 inverse = GL.GetGPUProjectionMatrix(context.camera.projectionMatrix, renderIntoTexture: true).inverse;
			if (SystemInfo.graphicsDeviceType != GraphicsDeviceType.OpenGLCore)
			{
				inverse[1, 1] *= -1f;
			}
			propertySheet.properties.SetFloat("_FogFadeInHeight", base.settings.FogFadeInHeight);
			propertySheet.properties.SetFloat("_FogFadeOutHeight", base.settings.FogFadeOutHeight);
			propertySheet.properties.SetColor("_FogColor", base.settings.FogColor);
			propertySheet.properties.SetMatrix("_CameraInvProjection", inverse);
			propertySheet.properties.SetMatrix("_CameraToWorld", context.camera.cameraToWorldMatrix);
			context.command.BlitFullscreenTriangle(context.source, context.destination, propertySheet, 0);
			context.command.EndSample("Height Fog");
		}
	}
}
