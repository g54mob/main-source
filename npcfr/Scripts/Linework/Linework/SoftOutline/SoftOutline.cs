using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace Linework.SoftOutline
{
	[ExcludeFromPreset]
	[DisallowMultipleRendererFeature("Soft Outline")]
	[SupportedOnRenderer(typeof(UniversalRendererData))]
	[Tooltip("Soft Outline renders outlines by generating a silhouette of an object and applying a dilation/blur effect, resulting in smooth, soft-edged contours around objects.")]
	[HelpURL("https://linework.ameye.dev/soft-outline")]
	public class SoftOutline : ScriptableRendererFeature
	{
		private class SoftOutlinePass : ScriptableRenderPass
		{
			private class PassData
			{
				internal readonly List<RendererListHandle> MaskRendererListHandles;

				internal readonly List<(RendererListHandle handle, bool vertexAnimated)> SilhouetteRendererListHandles;
			}

			private SoftOutlineSettings settings;

			private Material mask;

			private Material silhouetteBase;

			private Material silhouetteInstancedBase;

			private Material blur;

			private Material composite;

			private readonly ProfilingSampler maskSampler;

			private readonly ProfilingSampler silhouetteSampler;

			private readonly ProfilingSampler blurSampler;

			private readonly ProfilingSampler outlineSampler;

			private RTHandle cameraDepthRTHandle;

			private RTHandle silhouetteRTHandle;

			private RTHandle blurRTHandle;

			private RTHandle[] handles;

			public bool Setup(ref SoftOutlineSettings softOutlineSettings, ref Material maskMaterial, ref Material silhouetteMaterial, ref Material silhouetteInstancedMaterial, ref Material blurMaterial, ref Material compositeMaterial)
			{
				return false;
			}

			private static bool ShouldRenderOutline(Outline outline)
			{
				return false;
			}

			private static bool ShouldRenderStencilMask(Outline outline)
			{
				return false;
			}

			public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
			{
			}

			private void InitMaskRendererLists(RenderGraph renderGraph, ContextContainer frameData, ref PassData passData)
			{
			}

			private void InitSilhouetteRendererLists(RenderGraph renderGraph, ContextContainer frameData, ref PassData passData)
			{
			}

			private void CreateRenderGraphTextures(RenderGraph renderGraph, UniversalResourceData resourceData, out TextureHandle silhouetteHandle, out TextureHandle blurHandle)
			{
				silhouetteHandle = default(TextureHandle);
				blurHandle = default(TextureHandle);
			}

			public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
			{
			}

			public void CreateHandles(RenderingData renderingData)
			{
			}

			public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
			{
			}

			public void SetTarget(RTHandle depth)
			{
			}

			public override void OnCameraCleanup(CommandBuffer cmd)
			{
			}

			public void Dispose()
			{
			}
		}

		[SerializeField]
		private SoftOutlineSettings settings;

		[SerializeField]
		private ShaderResources shaders;

		private Material maskMaterial;

		private Material silhouetteMaterial;

		private Material silhouetteInstancedMaterial;

		private Material blurMaterial;

		private Material outlineMaterial;

		private SoftOutlinePass softOutlinePass;

		public override void Create()
		{
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
		}

		public override void SetupRenderPasses(ScriptableRenderer renderer, in RenderingData renderingData)
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		private void OnDestroy()
		{
		}

		private void DestroyMaterials()
		{
		}

		private bool CreateMaterials()
		{
			return false;
		}
	}
}
