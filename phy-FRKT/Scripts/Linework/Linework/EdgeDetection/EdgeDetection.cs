using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace Linework.EdgeDetection
{
	[ExcludeFromPreset]
	[DisallowMultipleRendererFeature("Edge Detection")]
	[SupportedOnRenderer(typeof(UniversalRendererData))]
	[Tooltip("Edge Detection renders outlines by detecting edges and discontinuities within the scene.")]
	[HelpURL("https://linework.ameye.dev/edge-detection")]
	public class EdgeDetection : ScriptableRendererFeature
	{
		private class EdgeDetectionPass : ScriptableRenderPass
		{
			private class PassData
			{
				internal RendererListHandle SectionRendererListHandle;

				internal List<RendererListHandle> AdditionalSectionRendererListHandles;
			}

			private EdgeDetectionSettings settings;

			private Material outline;

			private Material section;

			private readonly ProfilingSampler sectionSampler;

			private readonly ProfilingSampler outlineSampler;

			private RTHandle cameraDepthRTHandle;

			private RTHandle sectionRTHandle;

			private RTHandle[] handles;

			public bool Setup(ref EdgeDetectionSettings edgeDetectionSettings, ref Material sectionMaterial, ref Material outlineMaterial)
			{
				return false;
			}

			public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
			{
			}

			private void InitSectionRendererList(RenderGraph renderGraph, ContextContainer frameData, ref PassData passData)
			{
			}

			private void CreateRenderGraphTextures(RenderGraph renderGraph, UniversalResourceData resourceData, out TextureHandle sectionHandle, SectionMapPrecision precision, int clearValue)
			{
				sectionHandle = default(TextureHandle);
			}

			public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
			{
			}

			public void CreateHandles(RenderingData renderingData)
			{
			}

			private static GraphicsFormat GetSectionBufferFormat(SectionMapPrecision precision)
			{
				return default(GraphicsFormat);
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
		private EdgeDetectionSettings settings;

		[SerializeField]
		private ShaderResources shaders;

		private Material sectionMaterial;

		private Material outlineMaterial;

		private EdgeDetectionPass edgeDetectionPass;

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
