using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

namespace SCPE
{
	public sealed class CloudShadowsRenderer : PostProcessEffectRenderer<CloudShadows>
	{
		private Shader shader;

		public override void Init()
		{
			shader = Shader.Find("Hidden/SC Post Effects/Cloud Shadows");
		}

		public override void Render(PostProcessRenderContext context)
		{
			PropertySheet propertySheet = context.propertySheets.Get(shader);
			CommandBuffer command = context.command;
			Camera camera = context.camera;
			CloudShadows.isOrtho = context.camera.orthographic;
			Texture value = ((base.settings.texture.value == null) ? RuntimeUtilities.whiteTexture : base.settings.texture.value);
			propertySheet.properties.SetTexture("_NoiseTex", value);
			Matrix4x4 gPUProjectionMatrix = GL.GetGPUProjectionMatrix(camera.projectionMatrix, renderIntoTexture: false);
			float value2 = (gPUProjectionMatrix[3, 2] = 0f);
			gPUProjectionMatrix[2, 3] = value2;
			gPUProjectionMatrix[3, 3] = 1f;
			Matrix4x4 value3 = Matrix4x4.Inverse(gPUProjectionMatrix * camera.worldToCameraMatrix) * Matrix4x4.TRS(new Vector3(0f, 0f, 0f - gPUProjectionMatrix[2, 2]), Quaternion.identity, Vector3.one);
			propertySheet.properties.SetMatrix("clipToWorld", value3);
			float num2 = (float)base.settings.speed * 0.1f;
			propertySheet.properties.SetVector("_CloudParams", new Vector4((float)base.settings.size * 0.01f, base.settings.direction.value.x * num2, base.settings.direction.value.y * num2, base.settings.density));
			propertySheet.properties.SetFloat("_ProjectionEnabled", base.settings.projectFromSun.value ? 1 : 0);
			command.SetGlobalVector("_FadeParams", new Vector4(base.settings.startFadeDistance.value, base.settings.endFadeDistance.value, 0f, 0f));
			context.command.BlitFullscreenTriangle(context.source, context.destination, propertySheet, 0);
		}

		public override DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.Depth;
		}
	}
}
