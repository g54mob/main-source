using System.Collections.Generic;
using Motorways.Constants;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Rendering.RenderFeatures
{
	public class HeadlightOcclusionPass : ScriptableRenderPass
	{
		private readonly ProfilingSampler _headlightOcclusionProfilingSampler;

		private FilteringSettings _headlightOcclusionFilteringSettings;

		private FilteringSettings _mountainFilteringSettings;

		private RenderStateBlock _renderStateBlock;

		private readonly List<ShaderTagId> _shaderTagIdList = new List<ShaderTagId>();

		private readonly Material _headlightOcclusionMaterial;

		private RTHandle _renderTargetHandle;

		public HeadlightOcclusionPass(Shader headlightOcclusionShader)
		{
			base.profilingSampler = new ProfilingSampler("HighestMotorwayPass");
			_headlightOcclusionProfilingSampler = new ProfilingSampler("Headlight Occlusion Pass");
			base.renderPassEvent = RenderPassEvent.BeforeRendering;
			if (Diagnostics.Verify(headlightOcclusionShader != null))
			{
				_headlightOcclusionMaterial = new Material(headlightOcclusionShader)
				{
					enableInstancing = true
				};
			}
			_headlightOcclusionFilteringSettings = new FilteringSettings(null, LayerConstants.HeadlightOcclusionLayerMask);
			_mountainFilteringSettings = new FilteringSettings(null, LayerConstants.HeadlightOcclusionMountainLayerNameLayerMask);
			_shaderTagIdList.Add(new ShaderTagId("SRPDefaultUnlit"));
			_renderStateBlock = new RenderStateBlock(RenderStateMask.Nothing);
			_renderTargetHandle = RTHandles.Alloc(new RenderTargetIdentifier(ShaderConstants.HeadlightOcclusionTexture));
		}

		~HeadlightOcclusionPass()
		{
			Dispose();
		}

		public void Dispose()
		{
			_renderTargetHandle?.Release();
			_renderTargetHandle = null;
		}

		public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
		{
			cmd.GetTemporaryRT(desc: new RenderTextureDescriptor(renderingData.cameraData.camera.pixelWidth, renderingData.cameraData.camera.pixelHeight, GraphicsFormat.R32_SFloat, 0), nameID: ShaderConstants.HeadlightOcclusionTexture);
			ConfigureTarget(_renderTargetHandle);
			ConfigureClear(ClearFlag.All, Color.black);
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			SortingCriteria sortingCriteria = SortingCriteria.CommonTransparent;
			DrawingSettings drawingSettings = CreateDrawingSettings(_shaderTagIdList, ref renderingData, sortingCriteria);
			drawingSettings.overrideMaterial = _headlightOcclusionMaterial;
			CommandBuffer commandBuffer = CommandBufferPool.Get();
			using (new ProfilingScope(commandBuffer, _headlightOcclusionProfilingSampler))
			{
				context.DrawRenderers(renderingData.cullResults, ref drawingSettings, ref _headlightOcclusionFilteringSettings, ref _renderStateBlock);
				_headlightOcclusionMaterial.SetFloat(ShaderConstants.MotorwayIdShaderId, 0f);
				_headlightOcclusionMaterial.SetFloat(ShaderConstants.HeadlightOcclusionTypeId, ShaderConstants.HeadlightNonVehicleOcclusionTypeId);
				context.DrawRenderers(renderingData.cullResults, ref drawingSettings, ref _mountainFilteringSettings, ref _renderStateBlock);
			}
			context.ExecuteCommandBuffer(commandBuffer);
			CommandBufferPool.Release(commandBuffer);
		}

		public override void OnCameraCleanup(CommandBuffer cmd)
		{
			base.OnCameraCleanup(cmd);
			cmd.ReleaseTemporaryRT(ShaderConstants.HeadlightOcclusionTexture);
		}
	}
}
