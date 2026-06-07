using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

namespace SCPE
{
	public sealed class FogRenderer : PostProcessEffectRenderer<Fog>
	{
		private struct MipLevel
		{
			internal int down;

			internal int up;
		}

		private enum Pass
		{
			Prefilter = 0,
			Downsample = 1,
			Upsample = 2,
			Blend = 3,
			BlendScattering = 4
		}

		private Shader shader;

		private MipLevel[] m_Pyramid;

		private const int k_MaxPyramidSize = 16;

		public static Dictionary<Camera, RenderScreenSpaceSkybox> skyboxCams = new Dictionary<Camera, RenderScreenSpaceSkybox>();

		public override void Init()
		{
			shader = Shader.Find("Hidden/SC Post Effects/Fog");
			m_Pyramid = new MipLevel[16];
			for (int i = 0; i < 16; i++)
			{
				m_Pyramid[i] = new MipLevel
				{
					down = Shader.PropertyToID("_BloomMipDown" + i),
					up = Shader.PropertyToID("_BloomMipUp" + i)
				};
			}
		}

		public override void Release()
		{
			base.Release();
		}

		public override void Render(PostProcessRenderContext context)
		{
			PropertySheet propertySheet = context.propertySheets.Get(shader);
			CommandBuffer command = context.command;
			Camera camera = context.camera;
			if (base.settings.colorSource.value == Fog.FogColorSource.SkyboxColor)
			{
				if (camera.hideFlags != HideFlags.None && camera.name != "SceneCamera")
				{
					return;
				}
				if (!skyboxCams.ContainsKey(camera))
				{
					skyboxCams[camera] = camera.gameObject.GetComponent<RenderScreenSpaceSkybox>();
					if (!skyboxCams[camera])
					{
						skyboxCams[camera] = camera.gameObject.AddComponent<RenderScreenSpaceSkybox>();
					}
					skyboxCams[camera].manuallyAdded = false;
				}
			}
			Matrix4x4 gPUProjectionMatrix = GL.GetGPUProjectionMatrix(camera.projectionMatrix, renderIntoTexture: false);
			float value = (gPUProjectionMatrix[3, 2] = 0f);
			gPUProjectionMatrix[2, 3] = value;
			gPUProjectionMatrix[3, 3] = 1f;
			Matrix4x4 value2 = Matrix4x4.Inverse(gPUProjectionMatrix * camera.worldToCameraMatrix) * Matrix4x4.TRS(new Vector3(0f, 0f, 0f - gPUProjectionMatrix[2, 2]), Quaternion.identity, Vector3.one);
			propertySheet.properties.SetMatrix("clipToWorld", value2);
			float num2 = camera.transform.position.y - (float)base.settings.height;
			float z = ((num2 <= 0f) ? 1f : 0f);
			float x = (base.settings.lightScattering ? 1f : ((float)base.settings.skyboxInfluence));
			float z2 = (base.settings.distanceFog ? 1f : 0f);
			float w = (base.settings.heightFog ? 1f : 0f);
			int num3 = (int)((!base.settings.useSceneSettings) ? base.settings.colorSource.value : Fog.FogColorSource.UniformColor);
			FogMode fogMode = (base.settings.useSceneSettings ? RenderSettings.fogMode : ((FogMode)base.settings.fogMode));
			float num4 = (base.settings.useSceneSettings ? RenderSettings.fogDensity : ((float)base.settings.globalDensity / 100f));
			float num5 = (base.settings.useSceneSettings ? RenderSettings.fogStartDistance : ((float)base.settings.fogStartDistance));
			float num6 = (base.settings.useSceneSettings ? RenderSettings.fogEndDistance : ((float)base.settings.fogEndDistance));
			bool flag = fogMode == FogMode.Linear;
			float num7 = (flag ? (num6 - num5) : 0f);
			float num8 = ((Mathf.Abs(num7) > 0.0001f) ? (1f / num7) : 0f);
			Vector4 value3 = default(Vector4);
			value3.x = num4 * 1.2011224f;
			value3.y = num4 * 1.442695f;
			value3.z = (flag ? (0f - num8) : 0f);
			value3.w = (flag ? (num6 * num8) : 0f);
			float value4 = (base.settings.gradientUseFarClipPlane.value ? ((float)base.settings.gradientDistance) : context.camera.farClipPlane);
			if ((bool)base.settings.heightNoiseTex.value)
			{
				propertySheet.properties.SetTexture("_NoiseTex", base.settings.heightNoiseTex);
			}
			if ((bool)base.settings.fogColorGradient.value)
			{
				propertySheet.properties.SetTexture("_ColorGradient", base.settings.fogColorGradient);
			}
			command.SetGlobalFloat("_FarClippingPlane", value4);
			command.SetGlobalVector("_SceneFogParams", value3);
			command.SetGlobalVector("_SceneFogMode", new Vector4((float)fogMode, base.settings.useRadialDistance ? 1 : 0, num3, base.settings.heightFogNoise ? 1 : 0));
			command.SetGlobalVector("_NoiseParams", new Vector4((float)base.settings.heightNoiseSize * 0.01f, (float)base.settings.heightNoiseSpeed * 0.01f, base.settings.heightNoiseStrength, 0f));
			command.SetGlobalVector("_DensityParams", new Vector4(base.settings.distanceDensity, base.settings.heightNoiseStrength, base.settings.skyboxMipLevel, 0f));
			command.SetGlobalVector("_HeightParams", new Vector4(base.settings.height, num2, z, (float)base.settings.heightDensity * 0.5f));
			command.SetGlobalVector("_DistanceParams", new Vector4(0f - num5, 0f, z2, w));
			command.SetGlobalColor("_FogColor", base.settings.useSceneSettings ? RenderSettings.fogColor : ((Color)base.settings.fogColor));
			command.SetGlobalVector("_SkyboxParams", new Vector4(x, base.settings.skyboxMipLevel, 0f, 0f));
			Vector3 vector = (base.settings.useLightDirection ? Fog.LightDirection : base.settings.lightDirection.value.normalized);
			float num9 = (base.settings.useLightIntensity ? FogLightSource.intensity : base.settings.lightIntensity.value);
			num9 = (base.settings.enableDirectionalLight ? num9 : 0f);
			command.SetGlobalVector("_DirLightParams", new Vector4(vector.x, vector.y, vector.z, num9));
			Color color = (base.settings.useLightColor ? FogLightSource.color : base.settings.lightColor.value);
			command.SetGlobalVector("_DirLightColor", new Vector4(color.r, color.g, color.b, 0f));
			bool flag2 = (base.settings.lightScattering ? true : false);
			if (flag2)
			{
				int num10 = Mathf.FloorToInt((float)context.screenWidth / 2f);
				int num11 = Mathf.FloorToInt((float)context.screenHeight / 2f);
				bool flag3 = context.stereoActive && context.stereoRenderingMode == PostProcessRenderContext.StereoRenderingMode.SinglePass && context.camera.stereoTargetEye == StereoTargetEyeMask.Both;
				int num12 = (flag3 ? (num10 * 2) : num10);
				float num13 = Mathf.Log(Mathf.Max(num10, num11), 2f) + Mathf.Min(base.settings.scatterDiffusion.value, 10f) - 10f;
				int num14 = Mathf.FloorToInt(num13);
				int num15 = Mathf.Clamp(num14, 1, 16);
				float num16 = 0.5f + num13 - (float)num14;
				propertySheet.properties.SetFloat("_SampleScale", num16);
				float num17 = Mathf.GammaToLinearSpace(base.settings.scatterThreshold.value);
				float num18 = num17 * base.settings.scatterSoftKnee.value + 1E-05f;
				Vector4 value5 = new Vector4(num17, num17 - num18, num18 * 2f, 0.25f / num18);
				command.SetGlobalVector("_Threshold", value5);
				RenderTargetIdentifier source = context.source;
				for (int i = 0; i < num15; i++)
				{
					int down = m_Pyramid[i].down;
					int up = m_Pyramid[i].up;
					int pass = ((i != 0) ? 1 : 0);
					context.GetScreenSpaceTemporaryRT(command, down, 0, context.sourceFormat, RenderTextureReadWrite.Default, FilterMode.Bilinear, num12, num11);
					context.GetScreenSpaceTemporaryRT(command, up, 0, context.sourceFormat, RenderTextureReadWrite.Default, FilterMode.Bilinear, num12, num11);
					command.BlitFullscreenTriangle(source, down, propertySheet, pass);
					source = down;
					num12 = ((flag3 && num12 / 2 % 2 > 0) ? (1 + num12 / 2) : (num12 / 2));
					num12 = Mathf.Max(num12, 1);
					num11 = Mathf.Max(num11 / 2, 1);
				}
				int num19 = m_Pyramid[num15 - 1].down;
				for (int num20 = num15 - 2; num20 >= 0; num20--)
				{
					int down2 = m_Pyramid[num20].down;
					int up2 = m_Pyramid[num20].up;
					command.SetGlobalTexture("_BloomTex", down2);
					command.BlitFullscreenTriangle(num19, up2, propertySheet, 2);
					num19 = up2;
				}
				float y = RuntimeUtilities.Exp2(base.settings.scatterIntensity.value / 10f) - 1f;
				Vector4 value6 = new Vector4(num16, y, 0f, num15);
				command.SetGlobalVector("_ScatteringParams", value6);
				command.SetGlobalTexture("_BloomTex", num19);
				for (int j = 0; j < num15; j++)
				{
					if (m_Pyramid[j].down != num19)
					{
						command.ReleaseTemporaryRT(m_Pyramid[j].down);
					}
					if (m_Pyramid[j].up != num19)
					{
						command.ReleaseTemporaryRT(m_Pyramid[j].up);
					}
				}
			}
			context.command.BlitFullscreenTriangle(context.source, context.destination, propertySheet, flag2 ? 4 : 3);
		}

		public override DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.Depth;
		}
	}
}
