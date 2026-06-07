using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace Brewery.Map.V2
{
	public class MapUnlitOverrideFeature : ScriptableRendererFeature
	{
		private class MapUnlitOpaquePass : ScriptableRenderPass
		{
			private class PassData
			{
				public RendererListHandle rendererList;
			}

			private Material material;

			private static readonly ShaderTagId[] s_ShaderTags;

			public MapUnlitOpaquePass(Material mat)
			{
			}

			public void SetMaterial(Material mat)
			{
			}

			public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
			{
			}

			public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
			{
			}
		}

		[Tooltip("Simple unlit material (URP/Unlit, white). All opaque objects render with this instead of PBR.")]
		public Material overrideMaterial;

		private MapUnlitOpaquePass opaquePass;

		public override void Create()
		{
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
		}
	}
}
