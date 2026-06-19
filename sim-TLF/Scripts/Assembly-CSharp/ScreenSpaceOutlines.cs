using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ScreenSpaceOutlines : ScriptableRendererFeature
{
	[Serializable]
	private class ScreenSpaceOutlineSettings
	{
		[Header("General Outline Settings")]
		public Color outlineColor = Color.black;

		[Range(0f, 20f)]
		public float outlineScale = 1f;

		[Header("Depth Settings")]
		[Range(0f, 100f)]
		public float depthThreshold = 1.5f;

		[Range(0f, 500f)]
		public float robertsCrossMultiplier = 100f;

		[Header("Normal Settings")]
		[Range(0f, 1f)]
		public float normalThreshold = 0.4f;

		[Header("Depth Normal Relation Settings")]
		[Range(0f, 2f)]
		public float steepAngleThreshold = 0.2f;

		[Range(0f, 500f)]
		public float steepAngleMultiplier = 25f;

		[Header("General Scene View Space Normal Texture Settings")]
		public RenderTextureFormat colorFormat;

		public int depthBufferBits;

		public FilterMode filterMode;

		public Color backgroundColor = Color.clear;

		[Header("View Space Normal Texture Object Draw Settings")]
		public PerObjectData perObjectData;

		public bool enableDynamicBatching;

		public bool enableInstancing;
	}

	private class ScreenSpaceOutlinePass : ScriptableRenderPass
	{
		private readonly Material screenSpaceOutlineMaterial;

		private ScreenSpaceOutlineSettings settings;

		private FilteringSettings filteringSettings;

		private readonly List<ShaderTagId> shaderTagIdList;

		private readonly Material normalsMaterial;

		private RTHandle normals;

		private RendererList normalsRenderersList;

		private RTHandle temporaryBuffer;

		public ScreenSpaceOutlinePass(RenderPassEvent renderPassEvent, LayerMask layerMask, ScreenSpaceOutlineSettings settings)
		{
			this.settings = settings;
			base.renderPassEvent = renderPassEvent;
			screenSpaceOutlineMaterial = new Material(Shader.Find("Hidden/Outlines"));
			screenSpaceOutlineMaterial.SetColor("_OutlineColor", settings.outlineColor);
			screenSpaceOutlineMaterial.SetFloat("_OutlineScale", settings.outlineScale);
			screenSpaceOutlineMaterial.SetFloat("_DepthThreshold", settings.depthThreshold);
			screenSpaceOutlineMaterial.SetFloat("_RobertsCrossMultiplier", settings.robertsCrossMultiplier);
			screenSpaceOutlineMaterial.SetFloat("_NormalThreshold", settings.normalThreshold);
			screenSpaceOutlineMaterial.SetFloat("_SteepAngleThreshold", settings.steepAngleThreshold);
			screenSpaceOutlineMaterial.SetFloat("_SteepAngleMultiplier", settings.steepAngleMultiplier);
			filteringSettings = new FilteringSettings(RenderQueueRange.opaque, layerMask);
			shaderTagIdList = new List<ShaderTagId>
			{
				new ShaderTagId("UniversalForward"),
				new ShaderTagId("UniversalForwardOnly"),
				new ShaderTagId("LightweightForward"),
				new ShaderTagId("SRPDefaultUnlit")
			};
			normalsMaterial = new Material(Shader.Find("Hidden/ViewSpaceNormals"));
		}

		public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
		{
			RenderTextureDescriptor descriptor = renderingData.cameraData.cameraTargetDescriptor;
			descriptor.colorFormat = settings.colorFormat;
			descriptor.depthBufferBits = settings.depthBufferBits;
			RenderingUtils.ReAllocateIfNeeded(ref normals, in descriptor, settings.filterMode);
			descriptor.depthBufferBits = 0;
			RenderingUtils.ReAllocateIfNeeded(ref temporaryBuffer, in descriptor, FilterMode.Bilinear);
			ConfigureTarget(normals, renderingData.cameraData.renderer.cameraDepthTargetHandle);
			ConfigureClear(ClearFlag.Color, settings.backgroundColor);
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			if ((bool)screenSpaceOutlineMaterial && (bool)normalsMaterial && !(renderingData.cameraData.renderer.cameraColorTargetHandle.rt == null) && !(temporaryBuffer.rt == null))
			{
				CommandBuffer commandBuffer = CommandBufferPool.Get();
				context.ExecuteCommandBuffer(commandBuffer);
				commandBuffer.Clear();
				DrawingSettings drawSettings = CreateDrawingSettings(shaderTagIdList, ref renderingData, renderingData.cameraData.defaultOpaqueSortFlags);
				drawSettings.perObjectData = settings.perObjectData;
				drawSettings.enableDynamicBatching = settings.enableDynamicBatching;
				drawSettings.enableInstancing = settings.enableInstancing;
				drawSettings.overrideMaterial = normalsMaterial;
				RendererListParams param = new RendererListParams(renderingData.cullResults, drawSettings, filteringSettings);
				normalsRenderersList = context.CreateRendererList(ref param);
				commandBuffer.DrawRendererList(normalsRenderersList);
				commandBuffer.SetGlobalTexture(Shader.PropertyToID("_SceneViewSpaceNormals"), normals.rt);
				using (new ProfilingScope(commandBuffer, new ProfilingSampler("ScreenSpaceOutlines")))
				{
					Blitter.BlitCameraTexture(commandBuffer, renderingData.cameraData.renderer.cameraColorTargetHandle, temporaryBuffer, screenSpaceOutlineMaterial, 0);
					Blitter.BlitCameraTexture(commandBuffer, temporaryBuffer, renderingData.cameraData.renderer.cameraColorTargetHandle);
				}
				context.ExecuteCommandBuffer(commandBuffer);
				CommandBufferPool.Release(commandBuffer);
			}
		}

		public void Release()
		{
			CoreUtils.Destroy(screenSpaceOutlineMaterial);
			CoreUtils.Destroy(normalsMaterial);
			normals?.Release();
			temporaryBuffer?.Release();
		}
	}

	[SerializeField]
	private RenderPassEvent renderPassEvent = RenderPassEvent.BeforeRenderingSkybox;

	[SerializeField]
	private LayerMask outlinesLayerMask;

	[SerializeField]
	private ScreenSpaceOutlineSettings outlineSettings = new ScreenSpaceOutlineSettings();

	private ScreenSpaceOutlinePass screenSpaceOutlinePass;

	public override void Create()
	{
		if (renderPassEvent < RenderPassEvent.BeforeRenderingPrePasses)
		{
			renderPassEvent = RenderPassEvent.BeforeRenderingPrePasses;
		}
		screenSpaceOutlinePass = new ScreenSpaceOutlinePass(renderPassEvent, outlinesLayerMask, outlineSettings);
	}

	public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
	{
		renderer.EnqueuePass(screenSpaceOutlinePass);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			screenSpaceOutlinePass?.Release();
		}
	}
}
