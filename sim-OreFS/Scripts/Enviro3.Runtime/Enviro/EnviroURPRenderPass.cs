using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.XR;

namespace Enviro
{
	public class EnviroURPRenderPass : ScriptableRenderPass
	{
		private Material blitThroughMat;

		private string pName;

		private List<EnviroVolumetricCloudRenderer> volumetricCloudsRender = new List<EnviroVolumetricCloudRenderer>();

		private Vector3 floatingPointOriginMod = Vector3.zero;

		public ScriptableRenderer scriptableRenderer { get; set; }

		public EnviroURPRenderPass(string name)
		{
			base.renderPassEvent = (RenderPassEvent)449;
			pName = name;
		}

		public void CustomBlit(CommandBuffer cmd, Matrix4x4 matrix, RenderTargetIdentifier source, RenderTargetIdentifier target, Material mat, int pass)
		{
			cmd.SetGlobalTexture("_MainTex", source);
			cmd.SetRenderTarget(target, 0, CubemapFace.Unknown, -1);
			cmd.DrawMesh(RenderingUtils.fullscreenMesh, matrix, mat, 0, pass);
		}

		public void CustomBlit(CommandBuffer cmd, Matrix4x4 matrix, RenderTargetIdentifier source, RenderTargetIdentifier target, Material mat)
		{
			cmd.SetGlobalTexture("_MainTex", source);
			cmd.SetRenderTarget(target, 0, CubemapFace.Unknown, -1);
			cmd.DrawMesh(RenderingUtils.fullscreenMesh, matrix, mat, 0);
		}

		public void CustomBlit(CommandBuffer cmd, Matrix4x4 matrix, RenderTargetIdentifier source, RenderTargetIdentifier target)
		{
			if (blitThroughMat == null)
			{
				blitThroughMat = new Material(Shader.Find("Hidden/EnviroBlitThrough"));
			}
			cmd.SetGlobalTexture("_MainTex", source);
			cmd.SetRenderTarget(target, 0, CubemapFace.Unknown, -1);
			cmd.DrawMesh(RenderingUtils.fullscreenMesh, matrix, blitThroughMat);
		}

		public void CustomBlit(CommandBuffer cmd, RTHandle source, RTHandle target, Material mat)
		{
			Blitter.BlitCameraTexture(cmd, source, target, mat, 0);
		}

		public void CustomBlit(CommandBuffer cmd, RTHandle source, RTHandle target, Material mat, int pass)
		{
			Blitter.BlitCameraTexture(cmd, source, target, mat, pass);
		}

		public void CustomBlit(CommandBuffer cmd, RTHandle source, RTHandle target)
		{
			Blitter.BlitCameraTexture(cmd, source, target);
		}

		[Obsolete]
		public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
		{
			ConfigureTarget(scriptableRenderer.cameraColorTargetHandle);
			ConfigureInput(ScriptableRenderPassInput.Depth);
		}

		[Obsolete]
		public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
		{
			if (GetCloudsRenderer(renderingData.cameraData.camera) == null)
			{
				CreateCloudsRenderer(renderingData.cameraData.camera);
			}
		}

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

		[Obsolete]
		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			if (EnviroManager.instance == null)
			{
				return;
			}
			CommandBuffer commandBuffer = CommandBufferPool.Get(pName);
			if (EnviroHelper.ResetMatrix(renderingData.cameraData.camera))
			{
				renderingData.cameraData.camera.ResetProjectionMatrix();
			}
			EnviroQuality qualityForCamera = EnviroHelper.GetQualityForCamera(renderingData.cameraData.camera);
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
			SetMatrix(renderingData.cameraData.camera);
			RenderTexture temporary = RenderTexture.GetTemporary(renderingData.cameraData.cameraTargetDescriptor);
			RenderTargetIdentifier nameID = scriptableRenderer.cameraColorTargetHandle.nameID;
			CustomBlit(commandBuffer, Matrix4x4.identity, nameID, new RenderTargetIdentifier(temporary));
			if (EnviroManager.instance.Fog != null && flag2)
			{
				EnviroManager.instance.Fog.RenderVolumetricsURP(renderingData.cameraData.camera, this, commandBuffer, temporary);
			}
			if (EnviroManager.instance.Fog != null && EnviroManager.instance.VolumetricClouds != null && flag && flag2)
			{
				RenderTexture temporary2 = RenderTexture.GetTemporary(renderingData.cameraData.cameraTargetDescriptor);
				if (renderingData.cameraData.camera.transform.position.y - floatingPointOriginMod.y < EnviroManager.instance.VolumetricClouds.settingsVolume.bottomCloudsHeight)
				{
					EnviroVolumetricCloudRenderer cloudsRenderer = GetCloudsRenderer(renderingData.cameraData.camera);
					EnviroManager.instance.VolumetricClouds.RenderVolumetricCloudsURP(renderingData, this, commandBuffer, temporary, temporary2, cloudsRenderer, qualityForCamera);
					if (EnviroManager.instance.VolumetricClouds.settingsGlobal.cloudShadows && renderingData.cameraData.camera.cameraType != CameraType.Reflection)
					{
						RenderTexture temporary3 = RenderTexture.GetTemporary(renderingData.cameraData.cameraTargetDescriptor);
						EnviroManager.instance.VolumetricClouds.RenderCloudsShadowsURP(this, renderingData.cameraData.camera, commandBuffer, temporary2, temporary3, cloudsRenderer);
						EnviroManager.instance.Fog.RenderHeightFogURP(renderingData.cameraData.camera, this, commandBuffer, temporary3, nameID);
						RenderTexture.ReleaseTemporary(temporary3);
					}
					else
					{
						EnviroManager.instance.Fog.RenderHeightFogURP(renderingData.cameraData.camera, this, commandBuffer, temporary2, nameID);
					}
				}
				else
				{
					EnviroManager.instance.Fog.RenderHeightFogURP(renderingData.cameraData.camera, this, commandBuffer, temporary, temporary2);
					EnviroVolumetricCloudRenderer cloudsRenderer2 = GetCloudsRenderer(renderingData.cameraData.camera);
					if (EnviroManager.instance.VolumetricClouds.settingsGlobal.cloudShadows && renderingData.cameraData.camera.cameraType != CameraType.Reflection)
					{
						RenderTexture temporary4 = RenderTexture.GetTemporary(renderingData.cameraData.cameraTargetDescriptor);
						EnviroManager.instance.VolumetricClouds.RenderCloudsShadowsURP(this, renderingData.cameraData.camera, commandBuffer, temporary2, temporary4, cloudsRenderer2);
						EnviroManager.instance.VolumetricClouds.RenderVolumetricCloudsURP(renderingData, this, commandBuffer, temporary4, nameID, cloudsRenderer2, qualityForCamera);
						RenderTexture.ReleaseTemporary(temporary4);
					}
					else
					{
						EnviroManager.instance.VolumetricClouds.RenderVolumetricCloudsURP(renderingData, this, commandBuffer, temporary2, nameID, cloudsRenderer2, qualityForCamera);
					}
				}
				context.ExecuteCommandBuffer(commandBuffer);
				RenderTexture.ReleaseTemporary(temporary2);
			}
			else if (EnviroManager.instance.VolumetricClouds != null && flag && !flag2)
			{
				EnviroVolumetricCloudRenderer cloudsRenderer3 = GetCloudsRenderer(renderingData.cameraData.camera);
				if (EnviroManager.instance.VolumetricClouds.settingsGlobal.cloudShadows && renderingData.cameraData.camera.cameraType != CameraType.Reflection)
				{
					RenderTexture temporary5 = RenderTexture.GetTemporary(renderingData.cameraData.cameraTargetDescriptor);
					EnviroManager.instance.VolumetricClouds.RenderCloudsShadowsURP(this, renderingData.cameraData.camera, commandBuffer, temporary, temporary5, cloudsRenderer3);
					EnviroManager.instance.VolumetricClouds.RenderVolumetricCloudsURP(renderingData, this, commandBuffer, temporary5, nameID, cloudsRenderer3, qualityForCamera);
					RenderTexture.ReleaseTemporary(temporary5);
				}
				else
				{
					EnviroManager.instance.VolumetricClouds.RenderVolumetricCloudsURP(renderingData, this, commandBuffer, temporary, nameID, cloudsRenderer3, qualityForCamera);
				}
				context.ExecuteCommandBuffer(commandBuffer);
			}
			else if (EnviroManager.instance.Fog != null && flag2)
			{
				EnviroManager.instance.Fog.RenderHeightFogURP(renderingData.cameraData.camera, this, commandBuffer, temporary, nameID);
				context.ExecuteCommandBuffer(commandBuffer);
			}
			if (!flag)
			{
				Shader.SetGlobalTexture("_EnviroClouds", Texture2D.blackTexture);
			}
			CommandBufferPool.Release(commandBuffer);
			RenderTexture.ReleaseTemporary(temporary);
		}
	}
}
