using System.Collections.Generic;
using Motorways.Constants;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Rendering.RenderFeatures
{
	public class ShadowTypeRenderPass : ScriptableRenderPass
	{
		public enum ShadowType
		{
			Destination = 1,
			House = 2,
			Tree = 3,
			Motorway = 4,
			Mountain = 5
		}

		private readonly ProfilingSampler _profilingSampler;

		private FilteringSettings _mFilteringSettings;

		private RenderStateBlock _renderStateBlock;

		private readonly List<ShaderTagId> _shaderTagIdList = new List<ShaderTagId>();

		private readonly Material _material;

		private RTHandle _renderTargetHandle;

		public ShadowTypeRenderPass(Shader shadowTypeShader)
		{
			base.profilingSampler = new ProfilingSampler("HighestMotorwayPass");
			_profilingSampler = new ProfilingSampler("Shadow Type Pass");
			base.renderPassEvent = RenderPassEvent.BeforeRendering;
			if (Diagnostics.Verify(shadowTypeShader != null, "Highest Motorway Shader is null!"))
			{
				_material = new Material(shadowTypeShader);
			}
			_mFilteringSettings = new FilteringSettings(null, LayerConstants.ShadowMask);
			_shaderTagIdList.Add(new ShaderTagId("SRPDefaultUnlit"));
			_renderStateBlock = new RenderStateBlock(RenderStateMask.Nothing);
			_renderTargetHandle = RTHandles.Alloc(new RenderTargetIdentifier(ShaderConstants.ShadowTypeTexture));
		}

		~ShadowTypeRenderPass()
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
			cmd.GetTemporaryRT(desc: new RenderTextureDescriptor(renderingData.cameraData.camera.pixelWidth, renderingData.cameraData.camera.pixelHeight, GraphicsFormat.R32_SFloat, 0), nameID: ShaderConstants.ShadowTypeTexture);
			ConfigureTarget(_renderTargetHandle);
			ConfigureClear(ClearFlag.All, Color.black);
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			SortingCriteria sortingCriteria = SortingCriteria.None;
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
			cmd.ReleaseTemporaryRT(ShaderConstants.ShadowTypeTexture);
		}
	}
}
