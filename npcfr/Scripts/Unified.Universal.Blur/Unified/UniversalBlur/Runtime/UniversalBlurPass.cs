using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace Unified.UniversalBlur.Runtime
{
	internal class UniversalBlurPass : ScriptableRenderPass, IDisposable
	{
		private class PassData
		{
			public TextureHandle ColorSource;

			public TextureHandle Source;

			public TextureHandle Destination;

			public MaterialPropertyBlock MaterialPropertyBlock;

			public Material Material;

			public int ShaderPass;

			public float Downsample;

			public float Intensity;

			public float Scale;

			public float Offset;

			public int Iterations;
		}

		private const string k_PassName = "Universal Blur";

		private const string k_BlurTextureSourceName = "Universal Blur - Blur Source";

		private const string k_BlurTextureDestinationName = "Universal Blur - Blur Destination";

		private static readonly Vector4 s_DefaultBlitBias;

		private static readonly int s_BlurOffsetID;

		private static readonly int s_BlitTextureID;

		private static readonly int s_BlitScaleBias;

		private static readonly int s_GlobalFullScreenBlurTextureID;

		private readonly ProfilingSampler _profilingSampler;

		private readonly MaterialPropertyBlock _propertyBlock;

		private BlurPassData _blurPassData;

		public void Setup(BlurPassData blurPassData)
		{
		}

		public void Dispose()
		{
		}

		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
		{
		}

		private static void BlitMaterialRenderFunc(PassData data, UnsafeGraphContext ctx)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static float CalculateOffset(PassData data, int iteration)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void BlitTexture(UnsafeGraphContext context, TextureHandle sourceHandle, TextureHandle destinationHandle, PassData data, MaterialPropertyBlock mpb, float offset)
		{
		}
	}
}
