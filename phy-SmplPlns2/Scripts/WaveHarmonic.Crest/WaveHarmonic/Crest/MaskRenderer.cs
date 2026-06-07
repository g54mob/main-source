using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	internal abstract class MaskRenderer
	{
		public static class ShaderIDs
		{
			public static readonly int s_WaterMaskTexture = Shader.PropertyToID("_Crest_WaterMaskTexture");

			public static readonly int s_WaterMaskDepthTexture = Shader.PropertyToID("_Crest_WaterMaskDepthTexture");
		}

		[Flags]
		public enum MaskInput
		{
			None = 0,
			Zero = 1,
			Color = 2,
			Depth = 4,
			Both = 6
		}

		public interface IMaskProvider
		{
			MaskInput Allocate();

			MaskInput Write(Camera camera);

			void OnMaskPass(CommandBuffer commands, Camera camera, MaskRenderer mask);
		}

		public interface IMaskReceiver
		{
			MaskInput Allocate();
		}

		protected const string k_MaskColor = "_Crest_MaskColor";

		protected const string k_MaskDepth = "_Crest_MaskDepth";

		public static Action s_OnAllocate;

		public static Action s_OnRelease;

		public static Action<RenderTextureDescriptor> s_OnReAllocate;

		internal RenderTargetIdentifier _ColorRTI;

		internal RenderTargetIdentifier _DepthRTI;

		protected MaskInput _Inputs;

		protected readonly WaterRenderer _Water;

		internal readonly WaveHarmonic.Crest.Utility.SortedList<int, IMaskProvider> _Providers = new WaveHarmonic.Crest.Utility.SortedList<int, IMaskProvider>(Helpers.DuplicateComparison);

		internal readonly List<IMaskReceiver> _Receivers = new List<IMaskReceiver>();

		internal RTHandle _ColorRTH;

		internal RTHandle _DepthRTH;

		public bool Enabled => true;

		public RenderTextureDescriptor ColorDescriptor => ColorRT.descriptor;

		public RenderTextureDescriptor DepthDescriptor => DepthRT.descriptor;

		public Texture ColorT => _ColorRTH?.rt;

		public Texture DepthT => _DepthRTH?.rt;

		public RTHandle ColorRTH => _ColorRTH;

		public RTHandle DepthRTH => _DepthRTH;

		public RenderTexture ColorRT => _ColorRTH;

		public RenderTexture DepthRT => _DepthRTH;

		public static MaskRenderer Instantiate(WaterRenderer water)
		{
			if (RenderPipelineHelper.IsUniversal)
			{
				return new MaskRendererURP(water);
			}
			return new MaskRendererBIRP(water);
		}

		public MaskRenderer(WaterRenderer water)
		{
			_Water = water;
		}

		public abstract void OnBeginCameraRendering(Camera camera);

		public abstract void OnEndCameraRendering(Camera camera);

		public virtual void Enable()
		{
		}

		public virtual void Disable()
		{
		}

		public virtual void Destroy()
		{
			Release();
		}

		protected void UpdateColor(Texture color)
		{
			_ColorRTI = new RenderTargetIdentifier(color, 0, CubemapFace.Unknown, -1);
			Shader.SetGlobalTexture(ShaderIDs.s_WaterMaskTexture, color);
		}

		protected void UpdateDepth(Texture depth)
		{
			_DepthRTI = new RenderTargetIdentifier(depth, 0, CubemapFace.Unknown, -1);
			Shader.SetGlobalTexture(ShaderIDs.s_WaterMaskDepthTexture, depth);
		}

		private void Initialize()
		{
			_Inputs = MaskInput.None;
			foreach (IMaskReceiver receiver in _Receivers)
			{
				_Inputs |= receiver.Allocate();
			}
		}

		internal void Add(IMaskReceiver receiver)
		{
			if (!_Receivers.Contains(receiver))
			{
				_Receivers.Add(receiver);
				Initialize();
			}
		}

		internal void Remove(IMaskReceiver receiver)
		{
			if (_Receivers.Remove(receiver))
			{
				Initialize();
			}
		}

		internal void Add(int queue, IMaskProvider provider)
		{
			if (!_Providers.Contains(provider))
			{
				_Providers.Add(queue, provider);
				Initialize();
			}
		}

		internal void Remove(IMaskProvider provider)
		{
			if (_Providers.Remove(provider))
			{
				Initialize();
			}
		}

		public void Execute(Camera camera, CommandBuffer commands)
		{
			foreach (KeyValuePair<int, IMaskProvider> provider in _Providers)
			{
				if (provider.Value.Write(camera) != MaskInput.None)
				{
					provider.Value.OnMaskPass(commands, camera, this);
				}
			}
		}

		internal bool ShouldExecute(Camera camera)
		{
			MaskInput maskInput = MaskInput.None;
			foreach (KeyValuePair<int, IMaskProvider> provider in _Providers)
			{
				maskInput |= provider.Value.Write(camera);
			}
			return maskInput != MaskInput.None;
		}

		public void ResetRenderTarget(CommandBuffer commands)
		{
			CoreUtils.SetRenderTarget(commands, ColorRTH, DepthRTH);
		}

		public void Allocate()
		{
			if (_Inputs.HasFlag(MaskInput.Color) && _ColorRTH == null)
			{
				_ColorRTH = UnityEngine.Rendering.RTHandles.Alloc(Vector2.one, TextureXR.slices, DepthBits.None, dimension: TextureXR.dimension, colorFormat: Helpers.GetCompatibleTextureFormat(GraphicsFormat.R16_SFloat, randomWrite: true), filterMode: FilterMode.Point, wrapMode: TextureWrapMode.Repeat, enableRandomWrite: true, useMipMap: false, autoGenerateMips: true, isShadowMap: false, anisoLevel: 1, mipMapBias: 0f, msaaSamples: MSAASamples.None, bindTextureMS: false, useDynamicScale: true, useDynamicScaleExplicit: false, memoryless: RenderTextureMemoryless.None, vrUsage: VRTextureUsage.None, name: "_Crest_MaskColor");
				UpdateColor(_ColorRTH);
			}
			if (_Inputs.HasFlag(MaskInput.Depth) && _DepthRTH == null)
			{
				_DepthRTH = UnityEngine.Rendering.RTHandles.Alloc(Vector2.one, TextureXR.slices, dimension: TextureXR.dimension, depthBufferBits: Rendering.GetDefaultDepthBufferBits(), colorFormat: GraphicsFormat.None, filterMode: FilterMode.Point, wrapMode: TextureWrapMode.Repeat, enableRandomWrite: false, useMipMap: false, autoGenerateMips: true, isShadowMap: false, anisoLevel: 1, mipMapBias: 0f, msaaSamples: MSAASamples.None, bindTextureMS: false, useDynamicScale: true, useDynamicScaleExplicit: false, memoryless: RenderTextureMemoryless.None, vrUsage: VRTextureUsage.None, name: "_Crest_MaskDepth");
				UpdateDepth(_DepthRTH);
			}
			s_OnAllocate?.Invoke();
		}

		public void ReAllocate(RenderTextureDescriptor descriptor)
		{
			descriptor.bindMS = false;
			descriptor.msaaSamples = 1;
			s_OnReAllocate?.Invoke(descriptor);
			if (_Inputs.HasFlag(MaskInput.Depth))
			{
				descriptor.graphicsFormat = GraphicsFormat.None;
				descriptor.depthBufferBits = (int)Rendering.GetDefaultDepthBufferBits();
				if (RenderPipelineCompatibilityHelper.ReAllocateIfNeeded(ref _DepthRTH, in descriptor, FilterMode.Point, TextureWrapMode.Repeat, isShadowMap: false, 1, 0f, "_Crest_MaskDepth"))
				{
					UpdateDepth(_DepthRTH);
				}
			}
			if (_Inputs.HasFlag(MaskInput.Color))
			{
				descriptor.graphicsFormat = Helpers.GetCompatibleTextureFormat(GraphicsFormat.R16_SFloat, randomWrite: true);
				descriptor.depthStencilFormat = GraphicsFormat.None;
				descriptor.depthBufferBits = 0;
				descriptor.enableRandomWrite = true;
				if (RenderPipelineCompatibilityHelper.ReAllocateIfNeeded(ref _ColorRTH, in descriptor, FilterMode.Point, TextureWrapMode.Repeat, isShadowMap: false, 1, 0f, "_Crest_MaskColor"))
				{
					UpdateColor(_ColorRTH);
				}
			}
		}

		public void Release()
		{
			_ColorRTH?.Release();
			_DepthRTH?.Release();
			_ColorRTH = null;
			_DepthRTH = null;
			s_OnRelease?.Invoke();
		}
	}
}
