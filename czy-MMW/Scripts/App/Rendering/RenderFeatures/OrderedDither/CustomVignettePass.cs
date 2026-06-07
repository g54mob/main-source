using Motorways.Constants;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Rendering.RenderFeatures.OrderedDither
{
	public class CustomVignettePass : ScriptableRenderPass
	{
		private const float IntensityMultiplier = 3f;

		private const float SmoothnessMultiplier = 5f;

		private const float RoundnessMultiplier = 6f;

		private readonly int _temporaryVignetteTextureId = Shader.PropertyToID("_TemporaryVignetteTexture");

		private static readonly Mesh Quad = new Mesh
		{
			vertices = new Vector3[4]
			{
				new Vector3(1f, 1f, 0f),
				new Vector3(-1f, -1f, 0f),
				new Vector3(-1f, 1f, 0f),
				new Vector3(1f, -1f, 0f)
			},
			triangles = new int[6] { 1, 0, 2, 1, 3, 0 },
			uv = new Vector2[4]
			{
				new Vector2(1f, 0f),
				new Vector2(0f, 1f),
				new Vector2(0f, 0f),
				new Vector2(1f, 1f)
			}
		};

		private readonly CustomPostProcessRenderFeature.FeatureSettings _settings;

		private readonly ProfilingSampler _profilingSampler;

		public CustomVignettePass(CustomPostProcessRenderFeature.FeatureSettings settings)
		{
			_settings = settings;
			_profilingSampler = new ProfilingSampler("Vignette Pass");
			base.renderPassEvent = RenderPassEvent.AfterRendering;
		}

		public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
		{
			base.Configure(cmd, cameraTextureDescriptor);
			cmd.GetTemporaryRT(_temporaryVignetteTextureId, cameraTextureDescriptor, FilterMode.Bilinear);
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			CommandBuffer commandBuffer = CommandBufferPool.Get();
			using (new ProfilingScope(commandBuffer, _profilingSampler))
			{
				if (Quad != null)
				{
					context.ExecuteCommandBuffer(commandBuffer);
					commandBuffer.Clear();
					commandBuffer.SetRenderTarget(_temporaryVignetteTextureId);
					_settings.vignetteMaterial.SetFloat(ShaderConstants.Blend, _settings.tintBlend);
					_settings.vignetteMaterial.SetTexture(ShaderConstants.TintTex, _settings.tintTexture);
					_settings.vignetteMaterial.SetTexture(ShaderConstants.PaperTex, _settings.paperTexture);
					_settings.vignetteMaterial.SetColor(ShaderConstants.VignetteColor, _settings.color);
					_settings.vignetteMaterial.SetVector(ShaderConstants.VignetteCenter, _settings.center);
					float z = (1f - _settings.roundness) * 6f + _settings.roundness;
					_settings.vignetteMaterial.SetVector(ShaderConstants.VignetteSettings, new Vector4(3f * _settings.intensity, 5f * _settings.smoothness, z, _settings.rounded ? 1f : 0f));
					commandBuffer.DrawMesh(Quad, Matrix4x4.identity, _settings.vignetteMaterial);
					commandBuffer.Blit(_temporaryVignetteTextureId, renderingData.cameraData.renderer.cameraColorTargetHandle.nameID);
				}
			}
			context.ExecuteCommandBuffer(commandBuffer);
			CommandBufferPool.Release(commandBuffer);
		}

		public override void FrameCleanup(CommandBuffer cmd)
		{
			base.OnCameraCleanup(cmd);
			cmd.ReleaseTemporaryRT(_temporaryVignetteTextureId);
		}
	}
}
