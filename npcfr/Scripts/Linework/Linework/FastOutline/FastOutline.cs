using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace Linework.FastOutline
{
	[ExcludeFromPreset]
	[DisallowMultipleRendererFeature("Fast Outline")]
	[SupportedOnRenderer(typeof(UniversalRendererData))]
	[Tooltip("Fast Outline renders outlines by rendering an extruded version of an object behind the original object.")]
	[HelpURL("https://linework.ameye.dev/fast-outline")]
	public class FastOutline : ScriptableRendererFeature
	{
		private class FastOutlinePass : ScriptableRenderPass
		{
			private class PassData
			{
				internal RendererListHandle MaskRendererListHandle;

				internal readonly List<RendererListHandle> OutlineRendererListHandles;
			}

			private FastOutlineSettings settings;

			private Material mask;

			private Material outlineBase;

			private Material outlineInstancedBase;

			private Material clear;

			private readonly ProfilingSampler maskSampler;

			private readonly ProfilingSampler outlineSampler;

			private RTHandle cameraDepthRTHandle;

			public bool Setup(ref FastOutlineSettings fastOutlineSettings, ref Material maskMaterial, ref Material outlineMaterial, ref Material outlineInstancedMaterial, ref Material clearMaterial)
			{
				return false;
			}

			private static bool ShouldRenderStencilMask(Outline outline)
			{
				return false;
			}

			private static bool ShouldRenderOutline(Outline outline)
			{
				return false;
			}

			public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
			{
			}

			private void InitMaskRendererList(RenderGraph renderGraph, ContextContainer frameData, ref PassData passData)
			{
			}

			private void InitOutlineRendererLists(RenderGraph renderGraph, ContextContainer frameData, ref PassData passData)
			{
			}

			public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
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
		private FastOutlineSettings settings;

		[SerializeField]
		private ShaderResources shaders;

		private Material maskMaterial;

		private Material outlineMaterial;

		private Material outlineInstancedMaterial;

		private Material clearMaterial;

		private FastOutlinePass fastOutlinePass;

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
