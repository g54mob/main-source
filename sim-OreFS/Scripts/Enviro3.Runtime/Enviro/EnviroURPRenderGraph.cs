using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;
using UnityEngine.XR;

namespace Enviro
{
	public class EnviroURPRenderGraph : ScriptableRenderPass
	{
		public class PassData
		{
			internal TextureHandle src;

			internal TextureHandle target;

			internal TextureHandle read1;

			internal TextureHandle read2;

			internal Vector4 scaleBias;

			internal string srcName;

			internal string read1Name;

			internal string read2Name;

			internal int pass;

			internal Material material;
		}

		private Vector4 m_ScaleBias = new Vector4(1f, 1f, 0f, 0f);

		private List<EnviroVolumetricCloudRenderer> volumetricCloudsRender = new List<EnviroVolumetricCloudRenderer>();

		private Material blitThroughMat;

		private Material fogMat;

		private Vector3 floatingPointOriginMod = Vector3.zero;

		private EnviroVolumetricCloudRenderer CreateCloudsRenderer(Camera cam)
		{
			EnviroVolumetricCloudRenderer enviroVolumetricCloudRenderer = new EnviroVolumetricCloudRenderer();
			enviroVolumetricCloudRenderer.camera = cam;
			volumetricCloudsRender.Add(enviroVolumetricCloudRenderer);
			return enviroVolumetricCloudRenderer;
		}

		private EnviroVolumetricCloudRenderer GetCloudsRenderer(Camera cam)
		{
			for (int i = 0; i < volumetricCloudsRender.Count; i++)
			{
				if (volumetricCloudsRender[i].camera == cam)
				{
					return volumetricCloudsRender[i];
				}
			}
			return CreateCloudsRenderer(cam);
		}

		public void Blit(string passName, RenderGraph renderGraph, Material mat, TextureHandle src, TextureHandle target, int pass)
		{
			PassData passData;
			using IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<PassData>(passName, out passData, "C:\\Unity Projects\\Digging Project\\Assets\\Plugins\\Enviro 3 - Sky and Weather\\Scripts\\Runtime\\Base\\Renderer\\EnviroURPRenderGraph.cs", 52);
			passData.src = src;
			passData.target = target;
			passData.material = mat;
			passData.pass = pass;
			passData.scaleBias = m_ScaleBias;
			passData.srcName = "_MainTex";
			rasterRenderGraphBuilder.UseTexture(in passData.src);
			rasterRenderGraphBuilder.SetRenderAttachment(passData.target, 0);
			rasterRenderGraphBuilder.SetRenderFunc(delegate(PassData data, RasterGraphContext context)
			{
				if (data.src.IsValid())
				{
					data.material.SetTexture(data.srcName, data.src);
				}
				Blitter.BlitTexture(context.cmd, data.scaleBias, data.material, data.pass);
			});
		}

		public void Blit(string passName, RenderGraph renderGraph, Material mat, TextureHandle src, TextureHandle target, int pass, TextureHandle read1, string read1Name)
		{
			PassData passData;
			using IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<PassData>(passName, out passData, "C:\\Unity Projects\\Digging Project\\Assets\\Plugins\\Enviro 3 - Sky and Weather\\Scripts\\Runtime\\Base\\Renderer\\EnviroURPRenderGraph.cs", 76);
			passData.src = src;
			passData.target = target;
			passData.read1 = read1;
			passData.read1Name = read1Name;
			passData.material = mat;
			passData.pass = pass;
			passData.scaleBias = m_ScaleBias;
			passData.srcName = "_MainTex";
			rasterRenderGraphBuilder.UseTexture(in passData.src);
			rasterRenderGraphBuilder.UseTexture(in passData.read1);
			rasterRenderGraphBuilder.SetRenderAttachment(passData.target, 0);
			rasterRenderGraphBuilder.SetRenderFunc(delegate(PassData data, RasterGraphContext context)
			{
				if (data.src.IsValid())
				{
					data.material.SetTexture(data.srcName, data.src);
				}
				if (data.read1.IsValid())
				{
					data.material.SetTexture(data.read1Name, data.read1);
				}
				Blitter.BlitTexture(context.cmd, data.scaleBias, data.material, data.pass);
			});
		}

		public void Blit(string passName, RenderGraph renderGraph, Material mat, TextureHandle src, TextureHandle target, int pass, TextureHandle read1, string read1Name, TextureHandle read2, string read2Name)
		{
			PassData passData;
			using IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<PassData>(passName, out passData, "C:\\Unity Projects\\Digging Project\\Assets\\Plugins\\Enviro 3 - Sky and Weather\\Scripts\\Runtime\\Base\\Renderer\\EnviroURPRenderGraph.cs", 109);
			passData.src = src;
			passData.target = target;
			passData.read1 = read1;
			passData.read1Name = read1Name;
			passData.read2 = read2;
			passData.read2Name = read2Name;
			passData.material = mat;
			passData.pass = pass;
			passData.scaleBias = m_ScaleBias;
			passData.srcName = "_MainTex";
			rasterRenderGraphBuilder.UseTexture(in passData.src);
			rasterRenderGraphBuilder.UseTexture(in passData.read1);
			rasterRenderGraphBuilder.UseTexture(in passData.read2);
			rasterRenderGraphBuilder.SetRenderAttachment(passData.target, 0);
			rasterRenderGraphBuilder.SetRenderFunc(delegate(PassData data, RasterGraphContext context)
			{
				if (data.src.IsValid())
				{
					data.material.SetTexture(data.srcName, data.src);
				}
				if (data.read1.IsValid())
				{
					data.material.SetTexture(data.read1Name, data.read1);
				}
				if (data.read2.IsValid())
				{
					data.material.SetTexture(data.read2Name, data.read2);
				}
				Blitter.BlitTexture(context.cmd, data.scaleBias, data.material, data.pass);
			});
		}

		private void SetMatrix(Camera myCam)
		{
			if (XRSettings.enabled && XRSettings.stereoRenderingMode == XRSettings.StereoRenderingMode.SinglePassInstanced && myCam.stereoEnabled)
			{
				Matrix4x4 inverse = myCam.GetStereoViewMatrix(Camera.StereoscopicEye.Left).inverse;
				Matrix4x4 inverse2 = myCam.GetStereoViewMatrix(Camera.StereoscopicEye.Right).inverse;
				Matrix4x4 stereoProjectionMatrix = myCam.GetStereoProjectionMatrix(Camera.StereoscopicEye.Left);
				Matrix4x4 stereoProjectionMatrix2 = myCam.GetStereoProjectionMatrix(Camera.StereoscopicEye.Right);
				Matrix4x4 inverse3 = GL.GetGPUProjectionMatrix(stereoProjectionMatrix, renderIntoTexture: true).inverse;
				Matrix4x4 inverse4 = GL.GetGPUProjectionMatrix(stereoProjectionMatrix2, renderIntoTexture: true).inverse;
				if (SystemInfo.graphicsDeviceType != GraphicsDeviceType.OpenGLCore && SystemInfo.graphicsDeviceType != GraphicsDeviceType.OpenGLES3)
				{
					inverse3[1, 1] *= -1f;
					inverse4[1, 1] *= -1f;
				}
				Shader.SetGlobalMatrix("_LeftWorldFromView", inverse);
				Shader.SetGlobalMatrix("_RightWorldFromView", inverse2);
				Shader.SetGlobalMatrix("_LeftViewFromScreen", inverse3);
				Shader.SetGlobalMatrix("_RightViewFromScreen", inverse4);
			}
			else
			{
				Matrix4x4 cameraToWorldMatrix = myCam.cameraToWorldMatrix;
				Matrix4x4 inverse5 = GL.GetGPUProjectionMatrix(myCam.projectionMatrix, renderIntoTexture: true).inverse;
				if (SystemInfo.graphicsDeviceType != GraphicsDeviceType.OpenGLCore && SystemInfo.graphicsDeviceType != GraphicsDeviceType.OpenGLES3)
				{
					inverse5[1, 1] *= -1f;
				}
				Shader.SetGlobalMatrix("_LeftWorldFromView", cameraToWorldMatrix);
				Shader.SetGlobalMatrix("_LeftViewFromScreen", inverse5);
			}
		}

		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
		{
			if (EnviroManager.instance == null)
			{
				return;
			}
			UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
			UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
			if (EnviroHelper.ResetMatrix(universalCameraData.camera))
			{
				universalCameraData.camera.ResetProjectionMatrix();
			}
			EnviroQuality qualityForCamera = EnviroHelper.GetQualityForCamera(universalCameraData.camera);
			bool flag = false;
			bool flag2 = false;
			if (EnviroManager.instance.Quality != null)
			{
				if (EnviroManager.instance.VolumetricClouds != null)
				{
					flag = qualityForCamera.volumetricCloudsOverride.volumetricClouds;
				}
				if (EnviroManager.instance.Fog != null)
				{
					flag2 = qualityForCamera.fogOverride.fog;
				}
			}
			else
			{
				if (EnviroManager.instance.VolumetricClouds != null)
				{
					flag = EnviroManager.instance.VolumetricClouds.settingsQuality.volumetricClouds;
				}
				if (EnviroManager.instance.Fog != null)
				{
					flag2 = EnviroManager.instance.Fog.Settings.fog;
				}
			}
			if (EnviroManager.instance.Objects.worldAnchor != null)
			{
				floatingPointOriginMod = EnviroManager.instance.Objects.worldAnchor.transform.position;
			}
			else
			{
				floatingPointOriginMod = Vector3.zero;
			}
			SetMatrix(universalCameraData.camera);
			RenderTextureDescriptor cameraTargetDescriptor = universalCameraData.cameraTargetDescriptor;
			cameraTargetDescriptor.colorFormat = RenderTextureFormat.ARGBHalf;
			cameraTargetDescriptor.msaaSamples = 1;
			cameraTargetDescriptor.depthBufferBits = 0;
			TextureHandle textureHandle = UniversalRenderer.CreateRenderGraphTexture(renderGraph, cameraTargetDescriptor, "CopyTexture", clear: false);
			TextureHandle activeColorTexture = universalResourceData.activeColorTexture;
			if (blitThroughMat == null)
			{
				blitThroughMat = new Material(Shader.Find("Hidden/EnviroBlitThroughURP17"));
			}
			if (!activeColorTexture.IsValid() || !textureHandle.IsValid())
			{
				return;
			}
			PassData passData;
			using (IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<PassData>("Enviro 3 Copy Texture", out passData, "C:\\Unity Projects\\Digging Project\\Assets\\Plugins\\Enviro 3 - Sky and Weather\\Scripts\\Runtime\\Base\\Renderer\\EnviroURPRenderGraph.cs", 267))
			{
				passData.src = activeColorTexture;
				passData.target = textureHandle;
				passData.material = blitThroughMat;
				passData.scaleBias = m_ScaleBias;
				rasterRenderGraphBuilder.UseTexture(in passData.src);
				rasterRenderGraphBuilder.SetRenderAttachment(passData.target, 0);
				rasterRenderGraphBuilder.SetRenderFunc(delegate(PassData data, RasterGraphContext context)
				{
					data.material.SetTexture("_MainTex", data.src);
					Blitter.BlitTexture(context.cmd, data.scaleBias, data.material, 0);
				});
			}
			if (EnviroManager.instance.Fog != null && flag2)
			{
				EnviroManager.instance.Fog.RenderVolumetricsURP(this, renderGraph, universalResourceData, universalCameraData, textureHandle);
			}
			if (EnviroManager.instance.Fog != null && EnviroManager.instance.VolumetricClouds != null && flag && flag2)
			{
				TextureHandle textureHandle2 = UniversalRenderer.CreateRenderGraphTexture(renderGraph, cameraTargetDescriptor, "Temp1", clear: false);
				if (universalCameraData.camera.transform.position.y - floatingPointOriginMod.y < EnviroManager.instance.VolumetricClouds.settingsVolume.bottomCloudsHeight)
				{
					EnviroVolumetricCloudRenderer cloudsRenderer = GetCloudsRenderer(universalCameraData.camera);
					EnviroManager.instance.VolumetricClouds.RenderVolumetricCloudsURP(this, renderGraph, universalResourceData, universalCameraData, textureHandle, textureHandle2, cloudsRenderer, qualityForCamera);
					if (EnviroManager.instance.VolumetricClouds.settingsGlobal.cloudShadows && universalCameraData.camera.cameraType != CameraType.Reflection)
					{
						TextureHandle textureHandle3 = UniversalRenderer.CreateRenderGraphTexture(renderGraph, cameraTargetDescriptor, "Temp2", clear: false);
						EnviroManager.instance.VolumetricClouds.RenderCloudsShadowsURP(this, renderGraph, universalResourceData, universalCameraData, textureHandle2, textureHandle3, cloudsRenderer);
						EnviroManager.instance.Fog.RenderHeightFogURP(this, renderGraph, universalResourceData, universalCameraData, textureHandle3, universalResourceData.activeColorTexture);
					}
					else
					{
						EnviroManager.instance.Fog.RenderHeightFogURP(this, renderGraph, universalResourceData, universalCameraData, textureHandle2, universalResourceData.activeColorTexture);
					}
				}
				else
				{
					EnviroManager.instance.Fog.RenderHeightFogURP(this, renderGraph, universalResourceData, universalCameraData, textureHandle, textureHandle2);
					EnviroVolumetricCloudRenderer cloudsRenderer2 = GetCloudsRenderer(universalCameraData.camera);
					if (EnviroManager.instance.VolumetricClouds.settingsGlobal.cloudShadows && universalCameraData.camera.cameraType != CameraType.Reflection)
					{
						TextureHandle textureHandle4 = UniversalRenderer.CreateRenderGraphTexture(renderGraph, cameraTargetDescriptor, "Temp2", clear: false);
						EnviroManager.instance.VolumetricClouds.RenderCloudsShadowsURP(this, renderGraph, universalResourceData, universalCameraData, textureHandle2, textureHandle4, cloudsRenderer2);
						EnviroManager.instance.VolumetricClouds.RenderVolumetricCloudsURP(this, renderGraph, universalResourceData, universalCameraData, textureHandle4, universalResourceData.activeColorTexture, cloudsRenderer2, qualityForCamera);
					}
					else
					{
						EnviroManager.instance.VolumetricClouds.RenderVolumetricCloudsURP(this, renderGraph, universalResourceData, universalCameraData, textureHandle2, universalResourceData.activeColorTexture, cloudsRenderer2, qualityForCamera);
					}
				}
			}
			else if (EnviroManager.instance.VolumetricClouds != null && flag && !flag2)
			{
				EnviroVolumetricCloudRenderer cloudsRenderer3 = GetCloudsRenderer(universalCameraData.camera);
				if (EnviroManager.instance.VolumetricClouds.settingsGlobal.cloudShadows && universalCameraData.camera.cameraType != CameraType.Reflection)
				{
					TextureHandle textureHandle5 = UniversalRenderer.CreateRenderGraphTexture(renderGraph, cameraTargetDescriptor, "Temp1", clear: false);
					EnviroManager.instance.VolumetricClouds.RenderCloudsShadowsURP(this, renderGraph, universalResourceData, universalCameraData, textureHandle, textureHandle5, cloudsRenderer3);
					EnviroManager.instance.VolumetricClouds.RenderVolumetricCloudsURP(this, renderGraph, universalResourceData, universalCameraData, textureHandle5, universalResourceData.activeColorTexture, cloudsRenderer3, qualityForCamera);
				}
				else
				{
					EnviroManager.instance.VolumetricClouds.RenderVolumetricCloudsURP(this, renderGraph, universalResourceData, universalCameraData, textureHandle, universalResourceData.activeColorTexture, cloudsRenderer3, qualityForCamera);
				}
			}
			else if (EnviroManager.instance.Fog != null && flag2)
			{
				EnviroManager.instance.Fog.RenderHeightFogURP(this, renderGraph, universalResourceData, universalCameraData, textureHandle, universalResourceData.activeColorTexture);
			}
		}
	}
}
