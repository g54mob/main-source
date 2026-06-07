using System.Collections.Generic;
using Motorways.Constants;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Rendering.RenderFeatures
{
	public class ShadowFadeoutPass : ScriptableRenderPass
	{
		private readonly ProfilingSampler _profilingSampler;

		private FilteringSettings _mFilteringSettings;

		private RenderStateBlock _renderStateBlock;

		private readonly List<ShaderTagId> _shaderTagIdList = new List<ShaderTagId>();

		private readonly Material _material;

		public ShadowFadeoutPass(Shader shadowFadeoutShader)
		{
			base.profilingSampler = new ProfilingSampler("HighestMotorwayPass");
			_profilingSampler = new ProfilingSampler("Shadow Type Pass");
			base.renderPassEvent = RenderPassEvent.AfterRenderingTransparents;
			if (Diagnostics.Verify(shadowFadeoutShader != null, "Shadow Fadeout Shader is null!"))
			{
				_material = new Material(shadowFadeoutShader);
			}
			_mFilteringSettings = new FilteringSettings(null, LayerConstants.MotorwayMask);
			_shaderTagIdList.Add(new ShaderTagId("SRPDefaultUnlit"));
			_renderStateBlock = new RenderStateBlock(RenderStateMask.Nothing);
		}

		~ShadowFadeoutPass()
		{
			Dispose();
		}

		public void Dispose()
		{
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
	}
}
