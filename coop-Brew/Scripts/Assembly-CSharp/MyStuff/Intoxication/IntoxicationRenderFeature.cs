using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace MyStuff.Intoxication
{
	public class IntoxicationRenderFeature : ScriptableRendererFeature
	{
		private class IntoxicationPass : ScriptableRenderPass
		{
			private class PassData
			{
				public TextureHandle colorTexture;

				public Material material;

				public RenderTextureDescriptor desc;
			}

			private readonly Material _material;

			private static bool IsEffectActive => false;

			public IntoxicationPass(Material material)
			{
			}

			public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
			{
			}
		}

		[SerializeField]
		private Shader intoxicationShader;

		private IntoxicationPass _pass;

		private Material _material;

		public static bool FeatureCreated { get; private set; }

		public static bool MaterialValid { get; private set; }

		public static int AddRenderPassesCalls { get; private set; }

		public static int PassEnqueuedCount { get; private set; }

		public static int RecordRenderGraphCalls { get; private set; }

		public static string LastSkipReason { get; private set; }

		private static bool IsEffectActive => false;

		public override void Create()
		{
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
}
