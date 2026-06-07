using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

namespace SCPE
{
	public sealed class CausticsRenderer : PostProcessEffectRenderer<Caustics>
	{
		private Shader shader;

		public override void Init()
		{
			shader = Shader.Find("Hidden/SC Post Effects/Caustics");
		}

		public override void Release()
		{
			base.Release();
		}

		public override void Render(PostProcessRenderContext context)
		{
			PropertySheet propertySheet = context.propertySheets.Get(shader);
			CommandBuffer command = context.command;
			Matrix4x4 gPUProjectionMatrix = GL.GetGPUProjectionMatrix(context.camera.projectionMatrix, renderIntoTexture: false);
			float value = (gPUProjectionMatrix[3, 2] = 0f);
			gPUProjectionMatrix[2, 3] = value;
			gPUProjectionMatrix[3, 3] = 1f;
			Matrix4x4 value2 = Matrix4x4.Inverse(gPUProjectionMatrix * context.camera.worldToCameraMatrix) * Matrix4x4.TRS(new Vector3(0f, 0f, 0f - gPUProjectionMatrix[2, 2]), Quaternion.identity, Vector3.one);
			propertySheet.properties.SetMatrix("clipToWorld", value2);
			if ((bool)base.settings.causticsTexture.value)
			{
				propertySheet.properties.SetTexture("_CausticsTex", base.settings.causticsTexture.value);
			}
			propertySheet.properties.SetFloat("_LuminanceThreshold", Mathf.GammaToLinearSpace(base.settings.luminanceThreshold.value));
			propertySheet.properties.SetVector("_CausticsParams", new Vector4(base.settings.size, base.settings.speed, base.settings.projectFromSun.value ? 1 : 0, base.settings.intensity));
			propertySheet.properties.SetVector("_HeightParams", new Vector4(base.settings.minHeight.value, base.settings.minHeightFalloff.value, base.settings.maxHeight.value, base.settings.maxHeightFalloff.value));
			command.SetGlobalVector("_FadeParams", new Vector4(base.settings.startFadeDistance.value, base.settings.endFadeDistance.value, 0f, base.settings.distanceFade.value ? 1 : 0));
			command.BlitFullscreenTriangle(context.source, context.destination, propertySheet, 0);
		}

		public override DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.Depth;
		}
	}
}
