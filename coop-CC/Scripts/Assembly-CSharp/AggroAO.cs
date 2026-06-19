using System;
using System.Collections.Generic;
using Aggro.Core;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class AggroAO : ScriptableRendererFeature
{
	public enum Target
	{
		CameraColor = 0,
		TextureID = 1
	}

	[Serializable]
	public class BlitPassSettings
	{
		public bool showInSceneView = true;

		public RenderPassEvent _event = RenderPassEvent.AfterRenderingOpaques;

		public Target srcType;

		public string colorTargetDestinationID = "";

		public Material blitMaterial;

		public int passIndex;
	}

	private class BlitPass : ScriptableRenderPass
	{
		private BlitPassSettings _blitPassSettings;

		private FilteringSettings filteringSettings;

		private ProfilingSampler _profilingSampler;

		private List<ShaderTagId> shaderTagsList = new List<ShaderTagId>();

		private RTHandle rtCustomColor;

		private RTHandle rtHalfDepth;

		public BlitPass(BlitPassSettings blitPassSettings, string name)
		{
			_blitPassSettings = blitPassSettings;
			shaderTagsList.Add(new ShaderTagId("SRPDefaultUnlit"));
			shaderTagsList.Add(new ShaderTagId("UniversalForward"));
			shaderTagsList.Add(new ShaderTagId("UniversalForwardOnly"));
			_profilingSampler = new ProfilingSampler(name);
		}

		public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
		{
			RenderTextureDescriptor descriptor = renderingData.cameraData.cameraTargetDescriptor;
			descriptor.width /= 4;
			descriptor.height /= 4;
			descriptor.depthBufferBits = 0;
			RenderingUtils.ReAllocateIfNeeded(ref rtCustomColor, in descriptor, FilterMode.Point, TextureWrapMode.Repeat, isShadowMap: false, 1, 0f, _blitPassSettings.colorTargetDestinationID);
			ConfigureTarget(rtCustomColor);
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			CommandBuffer commandBuffer = CommandBufferPool.Get();
			using (new ProfilingScope(commandBuffer, _profilingSampler))
			{
				context.ExecuteCommandBuffer(commandBuffer);
				commandBuffer.Clear();
				ScriptableRenderer renderer = renderingData.cameraData.renderer;
				if (_blitPassSettings.blitMaterial != null)
				{
					if (_blitPassSettings.srcType == Target.CameraColor)
					{
						RTHandle cameraColorTargetHandle = renderingData.cameraData.renderer.cameraColorTargetHandle;
						if (cameraColorTargetHandle != null)
						{
							Blitter.BlitCameraTexture(commandBuffer, cameraColorTargetHandle, renderer.cameraColorTargetHandle, _blitPassSettings.blitMaterial, _blitPassSettings.passIndex);
						}
					}
					else if (_blitPassSettings.srcType == Target.TextureID)
					{
						RTHandle cameraColorTargetHandle2 = renderingData.cameraData.renderer.cameraColorTargetHandle;
						if (cameraColorTargetHandle2 != null)
						{
							Blitter.BlitCameraTexture(commandBuffer, cameraColorTargetHandle2, rtCustomColor, _blitPassSettings.blitMaterial, _blitPassSettings.passIndex);
						}
					}
				}
				if (_blitPassSettings.colorTargetDestinationID != "")
				{
					commandBuffer.SetGlobalTexture(_blitPassSettings.colorTargetDestinationID, rtCustomColor);
				}
			}
			context.ExecuteCommandBuffer(commandBuffer);
			commandBuffer.Clear();
			CommandBufferPool.Release(commandBuffer);
		}

		public override void OnCameraCleanup(CommandBuffer cmd)
		{
		}

		public void Dispose()
		{
			if (rtHalfDepth != null)
			{
				rtHalfDepth.Release();
				rtHalfDepth = null;
			}
			if (_blitPassSettings.colorTargetDestinationID != "" && rtCustomColor != null)
			{
				rtCustomColor.Release();
				rtCustomColor = null;
			}
		}
	}

	private static readonly int AGGROAO_SETTING_ID = AggroSettings.IdToHash("video-aggroao");

	public BlitPassSettings AOPassSettings = new BlitPassSettings();

	private BlitPass AOPass;

	public BlitPassSettings blurPassSettings = new BlitPassSettings();

	private BlitPass blurPass;

	public BlitPassSettings compositePassSettings = new BlitPassSettings();

	private BlitPass compositePass;

	public override void Create()
	{
		AOPass = new BlitPass(AOPassSettings, base.name);
		AOPass.renderPassEvent = AOPassSettings._event;
		blurPass = new BlitPass(blurPassSettings, base.name);
		blurPass.renderPassEvent = blurPassSettings._event;
		compositePass = new BlitPass(compositePassSettings, base.name);
		compositePass.renderPassEvent = compositePassSettings._event;
	}

	public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
	{
		CameraType cameraType = renderingData.cameraData.cameraType;
		if (cameraType != CameraType.Preview && (AOPassSettings.showInSceneView || cameraType != CameraType.SceneView) && (!Application.isPlaying || !AggroSettings.isInitialized || AggroSettings.GetSetting<ToggleSetting>(AGGROAO_SETTING_ID).value))
		{
			AOPass.ConfigureInput(ScriptableRenderPassInput.Color);
			AOPass.ConfigureInput(ScriptableRenderPassInput.Depth);
			AOPass.ConfigureInput(ScriptableRenderPassInput.Normal);
			renderer.EnqueuePass(AOPass);
			renderer.EnqueuePass(blurPass);
			compositePass.ConfigureInput(ScriptableRenderPassInput.Color);
			renderer.EnqueuePass(compositePass);
		}
	}

	protected override void Dispose(bool disposing)
	{
		AOPass.Dispose();
		blurPass.Dispose();
		compositePass.Dispose();
	}
}
