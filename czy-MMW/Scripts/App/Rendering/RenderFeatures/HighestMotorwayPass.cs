using System.Collections.Generic;
using Motorways.Constants;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Rendering.RenderFeatures
{
	public class HighestMotorwayPass : ScriptableRenderPass
	{
		private readonly ProfilingSampler _profilingSampler;

		private FilteringSettings _mFilteringSettings;

		private RenderStateBlock _renderStateBlock;

		private readonly List<ShaderTagId> _shaderTagIdList = new List<ShaderTagId>();

		private readonly Material _material;

		private RTHandle _renderTargetHandle;

		public HighestMotorwayPass(Shader highestMotorwayShader)
		{
			base.profilingSampler = new ProfilingSampler("HighestMotorwayPass");
			_profilingSampler = new ProfilingSampler("Highest Motorway Pass");
			base.renderPassEvent = RenderPassEvent.BeforeRendering;
			if (Diagnostics.Verify(highestMotorwayShader != null, "Highest Motorway Shader is null!"))
			{
				_material = new Material(highestMotorwayShader);
			}
			_mFilteringSettings = new FilteringSettings(null, LayerConstants.MotorwayMask);
			_shaderTagIdList.Add(new ShaderTagId("SRPDefaultUnlit"));
			_renderStateBlock = new RenderStateBlock(RenderStateMask.Nothing);
			_renderTargetHandle = RTHandles.Alloc(new RenderTargetIdentifier(ShaderConstants.HighestMotorwayTexture));
		}

		~HighestMotorwayPass()
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
			cmd.GetTemporaryRT(desc: new RenderTextureDescriptor(renderingData.cameraData.camera.pixelWidth, renderingData.cameraData.camera.pixelHeight, GraphicsFormat.R32_SFloat, 16), nameID: ShaderConstants.HighestMotorwayTexture);
			ConfigureTarget(_renderTargetHandle);
			ConfigureClear(ClearFlag.All, Color.black);
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			SortingCriteria sortingCriteria = SortingCriteria.CommonTransparent;
			DrawingSettings drawingSettings = CreateDrawingSettings(_shaderTagIdList, ref renderingData, sortingCriteria);
			drawingSettings.overrideMaterial = _material;
			CommandBuffer commandBuffer = CommandBufferPool.Get();
			using (new ProfilingScope(commandBuffer, _profilingSampler))
			{
				context.DrawRenderers(renderingData.cullResults, ref drawingSettings, ref _mFilteringSettings, ref _renderStateBlock);
			}
			context.ExecuteCommandBuffer(commandBuffer);
			CommandBufferPool.Release(commandBuffer);
		}

		public override void OnCameraCleanup(CommandBuffer cmd)
		{
			base.OnCameraCleanup(cmd);
			cmd.ReleaseTemporaryRT(ShaderConstants.HighestMotorwayTexture);
		}
	}
}
