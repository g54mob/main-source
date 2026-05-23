using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace FlatKit
{
	internal class BlitTexturePass : ScriptableRenderPass
	{
		public static readonly string CopyEffectShaderName = "Hidden/FlatKit/CopyTexture";

		private ProfilingSampler _profilingSampler;

		private Material _effectMaterial;

		private Material _copyMaterial;

		private RenderTargetHandle _temporaryColorTexture;

		public void Setup(Material effectMaterial, bool useDepth, bool useNormals, bool useColor)
		{
			_effectMaterial = effectMaterial;
			string text = effectMaterial.name.Substring(effectMaterial.name.LastIndexOf('/') + 1);
			_profilingSampler = new ProfilingSampler("Blit " + text);
			_copyMaterial = CoreUtils.CreateEngineMaterial(CopyEffectShaderName);
			ConfigureInput((ScriptableRenderPassInput)((useColor ? 4 : 0) | (useDepth ? 1 : 0) | (useNormals ? 2 : 0)));
		}

		public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
		{
			ConfigureTarget(new RenderTargetIdentifier(renderingData.cameraData.renderer.cameraColorTarget, 0, CubemapFace.Unknown, -1));
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			if (_effectMaterial == null || renderingData.cameraData.camera.cameraType != CameraType.Game)
			{
				return;
			}
			_temporaryColorTexture = default(RenderTargetHandle);
			CommandBuffer commandBuffer = CommandBufferPool.Get();
			using (new ProfilingScope(commandBuffer, _profilingSampler))
			{
				RenderTextureDescriptor cameraTargetDescriptor = renderingData.cameraData.cameraTargetDescriptor;
				cameraTargetDescriptor.depthBufferBits = 0;
				SetSourceSize(commandBuffer, cameraTargetDescriptor);
				RTHandle cameraColorTargetHandle = renderingData.cameraData.renderer.cameraColorTargetHandle;
				commandBuffer.GetTemporaryRT(_temporaryColorTexture.id, cameraTargetDescriptor);
				if (renderingData.cameraData.xrRendering)
				{
					_effectMaterial.EnableKeyword("_USE_DRAW_PROCEDURAL");
					commandBuffer.SetRenderTarget(_temporaryColorTexture.Identifier());
					commandBuffer.DrawMesh(RenderingUtils.fullscreenMesh, Matrix4x4.identity, _effectMaterial, 0, 0);
					commandBuffer.SetGlobalTexture("_EffectTexture", _temporaryColorTexture.Identifier());
					commandBuffer.SetRenderTarget(new RenderTargetIdentifier(cameraColorTargetHandle, 0, CubemapFace.Unknown, -1));
					commandBuffer.DrawMesh(RenderingUtils.fullscreenMesh, Matrix4x4.identity, _copyMaterial, 0, 0);
				}
				else
				{
					_effectMaterial.DisableKeyword("_USE_DRAW_PROCEDURAL");
					commandBuffer.Blit(cameraColorTargetHandle, _temporaryColorTexture.Identifier(), _effectMaterial, 0);
					commandBuffer.Blit(_temporaryColorTexture.Identifier(), cameraColorTargetHandle);
				}
			}
			context.ExecuteCommandBuffer(commandBuffer);
			commandBuffer.Clear();
			CommandBufferPool.Release(commandBuffer);
		}

		private static void SetSourceSize(CommandBuffer cmd, RenderTextureDescriptor desc)
		{
			float num = desc.width;
			float num2 = desc.height;
			if (desc.useDynamicScale)
			{
				num *= ScalableBufferManager.widthScaleFactor;
				num2 *= ScalableBufferManager.heightScaleFactor;
			}
			cmd.SetGlobalVector("_SourceSize", new Vector4(num, num2, 1f / num, 1f / num2));
		}
	}
}
