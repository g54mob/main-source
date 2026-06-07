using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.Universal.Internal;

namespace space.chikalin.textdecal
{
	internal class TextDecalDBufferCopyDepthPass : CopyDepthPass
	{
		public TextDecalDBufferCopyDepthPass(RenderPassEvent evt, Shader copyDepthShader, bool shouldClear = false, bool copyToDepth = false, bool copyResolvedDepth = false)
			: base(evt, copyDepthShader, shouldClear, copyToDepth, copyResolvedDepth)
		{
			base.profilingSampler = new ProfilingSampler("Text Decal CopyDepth");
		}

		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
		{
			UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
			if (!universalResourceData.dBufferDepth.IsValid())
			{
				UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
				RenderTextureDescriptor cameraTargetDescriptor = universalCameraData.cameraTargetDescriptor;
				cameraTargetDescriptor.graphicsFormat = GraphicsFormat.None;
				cameraTargetDescriptor.depthStencilFormat = universalCameraData.cameraTargetDescriptor.depthStencilFormat;
				cameraTargetDescriptor.msaaSamples = 1;
				universalResourceData.dBufferDepth = UniversalRenderer.CreateRenderGraphTexture(renderGraph, cameraTargetDescriptor, TextDecalDBufferRenderPass.DBufferDepthName, clear: true);
				Render(renderGraph, universalResourceData.dBufferDepth, universalResourceData.cameraDepthTexture, universalResourceData, universalCameraData, bindAsCameraDepth: false, base.passName);
			}
		}

		[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", false)]
		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			base.Execute(context, ref renderingData);
		}
	}
}
