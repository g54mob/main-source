using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

namespace SCPE
{
	public sealed class SunshaftsRenderer : PostProcessEffectRenderer<Sunshafts>
	{
		private enum Pass
		{
			SkySource = 0,
			RadialBlur = 1,
			Blend = 2
		}

		private Shader shader;

		private int skyboxBufferID;

		private Vector4[] sunPosition_Stereo = new Vector4[2];

		public override void Init()
		{
			shader = Shader.Find("Hidden/SC Post Effects/Sun Shafts");
			skyboxBufferID = Shader.PropertyToID("_SkyboxBuffer");
		}

		public override void Release()
		{
			base.Release();
		}

		public override void Render(PostProcessRenderContext context)
		{
			PropertySheet propertySheet = context.propertySheets.Get(shader);
			CommandBuffer command = context.command;
			float num = (base.settings.useCasterIntensity ? SunshaftCaster.intensity : base.settings.sunShaftIntensity.value);
			Vector3 vector = Vector3.one * 0.5f;
			if (Sunshafts.sunPosition != Vector3.zero)
			{
				Vector3 vector2 = context.camera.WorldToViewportPoint(Sunshafts.sunPosition, (!context.stereoActive) ? Camera.MonoOrStereoscopicEye.Mono : Camera.MonoOrStereoscopicEye.Left);
				Vector3 vector3 = context.camera.WorldToViewportPoint(Sunshafts.sunPosition, context.stereoActive ? Camera.MonoOrStereoscopicEye.Right : Camera.MonoOrStereoscopicEye.Mono);
				sunPosition_Stereo[0].x = vector2.x;
				sunPosition_Stereo[0].y = vector2.y;
				sunPosition_Stereo[1].x = vector3.x;
				sunPosition_Stereo[1].y = vector3.y;
			}
			else
			{
				sunPosition_Stereo[0].x = 0.5f;
				sunPosition_Stereo[0].y = 0.5f;
				sunPosition_Stereo[1].x = 0.5f;
				sunPosition_Stereo[1].y = 0.5f;
			}
			float num2 = Mathf.Clamp01(Mathf.Sign(Vector3.Dot(context.camera.transform.forward, Sunshafts.sunPosition - context.camera.transform.position)));
			sunPosition_Stereo[0].z = (sunPosition_Stereo[1].z = num * num2);
			sunPosition_Stereo[0].w = (sunPosition_Stereo[1].w = base.settings.falloff);
			propertySheet.properties.SetVectorArray("_SunPosition_Stereo", sunPosition_Stereo);
			Color color = (base.settings.useCasterColor ? SunshaftCaster.color : base.settings.sunColor.value);
			propertySheet.properties.SetFloat("_BlendMode", (float)base.settings.blendMode.value);
			propertySheet.properties.SetColor("_SunColor", (vector.z >= 0f) ? color : new Color(0f, 0f, 0f, 0f));
			propertySheet.properties.SetColor("_SunThreshold", base.settings.sunThreshold);
			propertySheet.properties.SetFloat("_SunZ", 1f - 0.9f * Mathf.InverseLerp(context.camera.nearClipPlane, context.camera.farClipPlane, (Sunshafts.sunPosition - context.camera.transform.position).magnitude));
			int value = (int)base.settings.resolution.value;
			context.command.GetTemporaryRT(skyboxBufferID, context.width / 2, context.height / 2, 0, FilterMode.Bilinear, context.sourceFormat);
			context.command.BlitFullscreenTriangle(context.source, skyboxBufferID, propertySheet, 0);
			command.SetGlobalTexture("_SunshaftBuffer", skyboxBufferID);
			command.BeginSample("Sunshafts blur");
			int num3 = Shader.PropertyToID("_Temp1");
			int num4 = Shader.PropertyToID("_Temp2");
			command.GetTemporaryRT(num3, context.width / value, context.height / value, 0, FilterMode.Bilinear);
			command.GetTemporaryRT(num4, context.width / value, context.height / value, 0, FilterMode.Bilinear);
			command.Blit(skyboxBufferID, num3);
			float num5 = (float)base.settings.length * 0.0013020834f;
			int num6 = ((!base.settings.highQuality) ? 1 : 2);
			float num7 = (base.settings.highQuality ? ((float)base.settings.length / 2.5f) : ((float)base.settings.length));
			for (int i = 0; i < num6; i++)
			{
				context.command.BlitFullscreenTriangle(num3, num4, propertySheet, 1);
				num5 = num7 * (((float)i * 2f + 1f) * 6f) / (float)context.screenWidth;
				propertySheet.properties.SetFloat("_BlurRadius", num5);
				context.command.BlitFullscreenTriangle(num4, num3, propertySheet, 1);
				num5 = num7 * (((float)i * 2f + 2f) * 6f) / (float)context.screenWidth;
				propertySheet.properties.SetFloat("_BlurRadius", num5);
			}
			command.EndSample("Sunshafts blur");
			command.SetGlobalTexture("_SunshaftBuffer", num3);
			context.command.BlitFullscreenTriangle(context.source, context.destination, propertySheet, 2);
			command.ReleaseTemporaryRT(num3);
			command.ReleaseTemporaryRT(num4);
			command.ReleaseTemporaryRT(skyboxBufferID);
		}
	}
}
