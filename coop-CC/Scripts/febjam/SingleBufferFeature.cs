using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SingleBufferFeature : ScriptableRendererFeature
{
	public class CustomRenderPass : ScriptableRenderPass
	{
		private Settings settings;

		private FilteringSettings filteringSettings;

		private ProfilingSampler _profilingSampler;

		private List<ShaderTagId> shaderTagsList = new List<ShaderTagId>();

		private RTHandle rtCustomColor;

		private RTHandle rtTempColor;

		public CustomRenderPass(Settings settings, string name)
		{
			this.settings = settings;
			filteringSettings = new FilteringSettings(RenderQueueRange.all, settings.layerMask);
			shaderTagsList.Add(new ShaderTagId("SRPDefaultUnlit"));
			shaderTagsList.Add(new ShaderTagId("UniversalForward"));
			shaderTagsList.Add(new ShaderTagId("UniversalForwardOnly"));
			_profilingSampler = new ProfilingSampler(name);
		}

		public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
		{
			RenderTextureDescriptor descriptor = renderingData.cameraData.cameraTargetDescriptor;
			descriptor.colorFormat = RenderTextureFormat.ARGB32;
			descriptor.depthBufferBits = 0;
			RenderingUtils.ReAllocateIfNeeded(ref rtTempColor, in descriptor, FilterMode.Point, TextureWrapMode.Repeat, isShadowMap: false, 1, 0f, "_TemporaryColorTexture");
			if (settings.colorTargetDestinationID != "")
			{
				RenderingUtils.ReAllocateIfNeeded(ref rtCustomColor, in descriptor, FilterMode.Point, TextureWrapMode.Clamp, isShadowMap: false, 1, 0f, settings.colorTargetDestinationID);
			}
			else
			{
				rtCustomColor = renderingData.cameraData.renderer.cameraColorTargetHandle;
			}
			RTHandle cameraDepthTargetHandle = renderingData.cameraData.renderer.cameraDepthTargetHandle;
			ConfigureTarget(rtCustomColor, cameraDepthTargetHandle);
			ConfigureClear(ClearFlag.Color, new Color(0f, 0f, 0f, 0f));
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			CommandBuffer commandBuffer = CommandBufferPool.Get();
			using (new ProfilingScope(commandBuffer, _profilingSampler))
			{
				context.ExecuteCommandBuffer(commandBuffer);
				commandBuffer.Clear();
				SortingCriteria sortingCriteria = settings.sortingCriteria;
				DrawingSettings drawingSettings = CreateDrawingSettings(shaderTagsList, ref renderingData, sortingCriteria);
				if (settings.overrideMaterial != null)
				{
					drawingSettings.overrideMaterialPassIndex = settings.overrideMaterialPass;
					drawingSettings.overrideMaterial = settings.overrideMaterial;
				}
				context.DrawRenderers(renderingData.cullResults, ref drawingSettings, ref filteringSettings);
				if (settings.colorTargetDestinationID != "")
				{
					commandBuffer.SetGlobalTexture(settings.colorTargetDestinationID, rtCustomColor);
				}
				if (settings.blitMaterial != null)
				{
					RTHandle cameraColorTargetHandle = renderingData.cameraData.renderer.cameraColorTargetHandle;
					if (cameraColorTargetHandle != null && rtTempColor != null)
					{
						Blitter.BlitCameraTexture(commandBuffer, cameraColorTargetHandle, rtTempColor, settings.blitMaterial, 0);
						Blitter.BlitCameraTexture(commandBuffer, rtTempColor, cameraColorTargetHandle);
					}
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
			if (settings.colorTargetDestinationID != "")
			{
				rtCustomColor?.Release();
			}
			rtTempColor?.Release();
		}
	}

	[Serializable]
	public class Settings
	{
		public bool showInSceneView = true;

		public bool showInGameView = true;

		public RenderPassEvent _event = RenderPassEvent.AfterRenderingOpaques;

		public bool transparent = true;

		public SortingCriteria sortingCriteria = SortingCriteria.CommonTransparent;

		[Header("Draw Renderers Settings")]
		public LayerMask layerMask = 1;

		public Material overrideMaterial;

		public int overrideMaterialPass;

		public string colorTargetDestinationID = "";

		[Header("Blit Settings")]
		public Material blitMaterial;
	}

	public Settings settings = new Settings();

	private CustomRenderPass m_ScriptablePass;

	public override void Create()
	{
		m_ScriptablePass = new CustomRenderPass(settings, base.name);
		m_ScriptablePass.renderPassEvent = settings._event;
	}

	public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
	{
		CameraType cameraType = renderingData.cameraData.cameraType;
		if (cameraType != CameraType.Preview && (settings.showInSceneView || cameraType != CameraType.SceneView) && (settings.showInGameView || cameraType != CameraType.Game))
		{
			renderer.EnqueuePass(m_ScriptablePass);
		}
	}

	protected override void Dispose(bool disposing)
	{
		m_ScriptablePass.Dispose();
	}
}
