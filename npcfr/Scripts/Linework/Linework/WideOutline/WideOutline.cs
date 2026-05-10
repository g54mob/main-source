using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace Linework.WideOutline
{
	[ExcludeFromPreset]
	[DisallowMultipleRendererFeature("Wide Outline")]
	[SupportedOnRenderer(typeof(UniversalRendererData))]
	[Tooltip("Wide Outline renders an outline by generating a signed distance field (SDF) for each object and then sampling it. This creates consistent outlines that smoothly follows the shape of an object.")]
	[HelpURL("https://linework.ameye.dev/wide-outline")]
	public class WideOutline : ScriptableRendererFeature
	{
		private class WideOutlinePass : ScriptableRenderPass
		{
			private class PassData
			{
				internal readonly List<RendererListHandle> MaskRendererListHandles;

				internal readonly List<(RendererListHandle handle, bool vertexAnimated)> SilhouetteRendererListHandles;

				internal readonly List<(RendererListHandle handle, bool vertexAnimated)> InformationRendererListHandles;
			}

			private WideOutlineSettings settings;

			private Material mask;

			private Material silhouetteBase;

			private Material silhouetteInstancedBase;

			private Material composite;

			private readonly ProfilingSampler maskSampler;

			private readonly ProfilingSampler silhouetteSampler;

			private readonly ProfilingSampler informationSampler;

			private readonly ProfilingSampler floodSampler;

			private readonly ProfilingSampler outlineSampler;

			private float maxwidth;

			private RTHandle cameraDepthRTHandle;

			private RTHandle silhouetteRTHandle;

			private RTHandle silhouetteDepthRTHandle;

			private RTHandle pingRTHandle;

			private RTHandle pongRTHandle;

			public bool Setup(ref WideOutlineSettings wideOutlineSettings, ref Material maskMaterial, ref Material silhouetteMaterial, ref Material silhouetteInstancedMaterial, ref Material compositeMaterial, float renderScale)
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

			private void InitInformationRendererList(RenderGraph renderGraph, ContextContainer frameData, ref PassData passData)
			{
			}

			private static void CreateRenderGraphTextures(RenderGraph renderGraph, UniversalResourceData resourceData, out TextureHandle silhouetteHandle, out TextureHandle silhouetteDepthHandle, out TextureHandle informationHandle, out TextureHandle pingHandle, out TextureHandle pongHandle)
			{
				silhouetteHandle = default(TextureHandle);
				silhouetteDepthHandle = default(TextureHandle);
				informationHandle = default(TextureHandle);
				pingHandle = default(TextureHandle);
				pongHandle = default(TextureHandle);
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
		private WideOutlineSettings settings;

		[SerializeField]
		private ShaderResources shaders;

		private Material maskMaterial;

		private Material silhouetteMaterial;

		private Material silhouetteInstancedMaterial;

		private Material outlineMaterial;

		private WideOutlinePass wideOutlinePass;

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
