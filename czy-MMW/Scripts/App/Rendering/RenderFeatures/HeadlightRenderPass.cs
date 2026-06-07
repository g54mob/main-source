using System.Collections.Generic;
using Motorways.Constants;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Rendering.RenderFeatures
{
	public class HeadlightRenderPass : ScriptableRenderPass
	{
		private readonly ProfilingSampler _profilingSampler;

		private FilteringSettings _mFilteringSettings;

		private RenderStateBlock _renderStateBlock;

		private readonly List<ShaderTagId> _shaderTagIdList = new List<ShaderTagId>();

		private readonly Material _material;

		public HeadlightRenderPass(Material headlightMaterial)
		{
			base.profilingSampler = new ProfilingSampler("HeadlightRenderPass");
			_profilingSampler = new ProfilingSampler("Headlight Pass");
			base.renderPassEvent = RenderPassEvent.AfterRenderingTransparents;
			_material = headlightMaterial;
			_mFilteringSettings = new FilteringSettings(null, LayerConstants.HeadlightMask);
			_shaderTagIdList.Add(new ShaderTagId("SRPDefaultUnlit"));
			_renderStateBlock = new RenderStateBlock(RenderStateMask.Nothing);
		}

		~HeadlightRenderPass()
		{
			Dispose();
		}

		public void Dispose()
		{
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			renderingData.cameraData.camera.TryGetCullingParameters(out var cullingParameters);
			cullingParameters.cullingMask = (uint)LayerConstants.HeadlightMask;
			CullingResults cullingResults = context.Cull(ref cullingParameters);
			SortingCriteria sortingCriteria = SortingCriteria.CommonTransparent;
			DrawingSettings drawingSettings = CreateDrawingSettings(_shaderTagIdList, ref renderingData, sortingCriteria);
			drawingSettings.overrideMaterial = _material;
			CommandBuffer commandBuffer = CommandBufferPool.Get();
			using (new ProfilingScope(commandBuffer, _profilingSampler))
			{
				context.DrawRenderers(cullingResults, ref drawingSettings, ref _mFilteringSettings, ref _renderStateBlock);
			}
			context.ExecuteCommandBuffer(commandBuffer);
			CommandBufferPool.Release(commandBuffer);
		}
	}
}
