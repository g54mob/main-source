using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Rendering.RenderFeatures
{
	public class CustomBlurPass : ScriptableRenderPass
	{
		private readonly Material _blurMaterial;

		private int _passCount;

		private readonly int _originalTextureId = Shader.PropertyToID("_Original");

		private readonly int _pongTextureId = Shader.PropertyToID("_Pong");

		private readonly int _pingTextureId = Shader.PropertyToID("_Ping");

		private readonly int _pingPongTextureLongestSide = 512;

		private int TapCount = 5;

		public CustomBlurPass(Material blurMaterial)
		{
			_blurMaterial = blurMaterial;
			base.renderPassEvent = RenderPassEvent.AfterRendering;
		}

		public void Setup(float strength, float levelRange, float levelOffset)
		{
			_blurMaterial.SetFloat("_Strength", strength);
			_blurMaterial.SetFloat("_LevelsRange", levelRange);
			_blurMaterial.SetFloat("_LevelsOffset", levelOffset);
		}

		public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
		{
			cmd.GetTemporaryRT(_originalTextureId, cameraTextureDescriptor, FilterMode.Bilinear);
			Vector2Int zero = Vector2Int.zero;
			if (cameraTextureDescriptor.width > cameraTextureDescriptor.height)
			{
				zero.x = _pingPongTextureLongestSide;
				zero.y = (int)((float)cameraTextureDescriptor.height / (float)cameraTextureDescriptor.width * (float)zero.x);
			}
			else
			{
				zero.x = (int)((float)cameraTextureDescriptor.width / (float)cameraTextureDescriptor.height * (float)zero.y);
				zero.y = _pingPongTextureLongestSide;
			}
			cmd.GetTemporaryRT(_pingTextureId, zero.x, zero.y, 0, FilterMode.Bilinear);
			cmd.GetTemporaryRT(_pongTextureId, zero.x, zero.y, 0, FilterMode.Bilinear);
			if (TapCount == 5)
			{
				float[] array = new float[2] { 1.3846154f, 3.2307692f };
				for (int i = 0; i < array.Length; i++)
				{
					_blurMaterial.SetFloat($"_OffsetX{i + 1}", array[i] / (float)zero.x);
					_blurMaterial.SetFloat($"_OffsetY{i + 1}", array[i] / (float)zero.y);
				}
			}
			else if (TapCount == 3)
			{
				float num = 1.2857143f;
				_blurMaterial.SetFloat("_OffsetX", num / (float)zero.x);
				_blurMaterial.SetFloat("_OffsetY", num / (float)zero.y);
			}
			_blurMaterial.SetFloat("_Weight0", 42f / 185f);
			_blurMaterial.SetFloat("_Weight1", 0.31621623f);
			_blurMaterial.SetFloat("_Weight2", 13f / 185f);
			_passCount = ((TapCount == 3) ? 2 : Mathf.Clamp(cameraTextureDescriptor.width / _pingPongTextureLongestSide, 1, 4));
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			CommandBuffer commandBuffer = CommandBufferPool.Get("Custom Blur Pass");
			commandBuffer.Clear();
			RenderTargetIdentifier renderTargetIdentifier = renderingData.cameraData.renderer.cameraColorTargetHandle;
			commandBuffer.BeginSample("Source to Original");
			commandBuffer.Blit(renderTargetIdentifier, _originalTextureId);
			commandBuffer.EndSample("Source to Original");
			commandBuffer.BeginSample("Source to Ping");
			commandBuffer.Blit(renderTargetIdentifier, _pingTextureId);
			commandBuffer.EndSample("Source to Ping");
			for (int i = 0; i < _passCount; i++)
			{
				string name = $"Pass {i}";
				commandBuffer.BeginSample(name);
				commandBuffer.BeginSample("Ping to Pong");
				commandBuffer.Blit(_pingTextureId, _pongTextureId, _blurMaterial, 0);
				commandBuffer.EndSample("Ping to Pong");
				if (i < _passCount - 1)
				{
					commandBuffer.BeginSample("Pong to Ping");
					commandBuffer.Blit(_pongTextureId, _pingTextureId, _blurMaterial, 1);
					commandBuffer.EndSample("Pong to Ping");
				}
				else
				{
					commandBuffer.BeginSample("Pong to Source");
					commandBuffer.Blit(_pongTextureId, renderTargetIdentifier, _blurMaterial, 2);
					commandBuffer.EndSample("Pong to Source");
				}
				commandBuffer.EndSample(name);
			}
			context.ExecuteCommandBuffer(commandBuffer);
			commandBuffer.Clear();
			CommandBufferPool.Release(commandBuffer);
		}

		public override void FrameCleanup(CommandBuffer cmd)
		{
			base.FrameCleanup(cmd);
			cmd.ReleaseTemporaryRT(_originalTextureId);
			cmd.ReleaseTemporaryRT(_pingTextureId);
			cmd.ReleaseTemporaryRT(_pongTextureId);
		}
	}
}
