using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace Linework.SurfaceFill
{
	[ExcludeFromPreset]
	[DisallowMultipleRendererFeature("Surface Fill")]
	[SupportedOnRenderer(typeof(UniversalRendererData))]
	[Tooltip("Surface Fill renders fills by rendering an object with a fill material.")]
	[HelpURL("https://linework.ameye.dev/surface-fill")]
	public class SurfaceFill : ScriptableRendererFeature
	{
		private class SurfaceFillPass : ScriptableRenderPass
		{
			private class PassData
			{
				internal readonly List<RendererListHandle> MaskRendererListHandles;
			}

			private SurfaceFillSettings settings;

			private Material mask;

			private Material fillBase;

			private RenderStateBlock fillRenderStateBlock;

			private int lastActiveFillIndex;

			private readonly ProfilingSampler maskSampler;

			private readonly ProfilingSampler fillSampler;

			private RTHandle cameraDepthRTHandle;

			public bool Setup(ref SurfaceFillSettings surfaceFillSettings, ref Material maskMaterial, ref Material fillMaterial)
			{
				return false;
			}

			public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
			{
			}

			private void InitMaskRendererLists(RenderGraph renderGraph, ContextContainer frameData, ref PassData passData)
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
		private SurfaceFillSettings settings;

		[SerializeField]
		private ShaderResources shaders;

		private Material maskMaterial;

		private Material fillMaterial;

		private SurfaceFillPass surfaceFillPass;

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
