using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

namespace WaveHarmonic.Crest
{
	internal sealed class UnderwaterEffectPass
	{
		private readonly UnderwaterRenderer _Renderer;

		private RTHandle _ColorTexture;

		private RTHandle _ColorTarget;

		private RTHandle _DepthTarget;

		private readonly Action<CommandBuffer> _CopyColorTexture;

		private readonly Action<CommandBuffer> _SetRenderTargetToBackBuffers;

		private bool _AllocatedColor;

		private GraphicsFormat _GraphicsFormat;

		public UnderwaterEffectPass(UnderwaterRenderer renderer)
		{
			_Renderer = renderer;
			_CopyColorTexture = CopyColorTexture;
			_SetRenderTargetToBackBuffers = SetRenderTargetToBackBuffers;
		}

		private void CopyColorTexture(CommandBuffer buffer)
		{
			Blitter.BlitCameraTexture(buffer, _ColorTarget, _ColorTexture);
			CoreUtils.SetRenderTarget(buffer, _ColorTarget, _DepthTarget, ClearFlag.None);
		}

		private void SetRenderTargetToBackBuffers(CommandBuffer commands)
		{
			CoreUtils.SetRenderTarget(commands, _ColorTarget, _DepthTarget, ClearFlag.None);
		}

		public void Allocate(GraphicsFormat format)
		{
			_GraphicsFormat = format;
			if (!_Renderer.RenderBeforeTransparency || _Renderer.NeedsColorTexture)
			{
				if (_ColorTexture == null)
				{
					Vector2 one = Vector2.one;
					int slices = TextureXR.slices;
					TextureDimension dimension = TextureXR.dimension;
					_ColorTexture = RTHandles.Alloc(one, slices, DepthBits.None, format, FilterMode.Point, TextureWrapMode.Clamp, dimension, enableRandomWrite: false, useMipMap: false, autoGenerateMips: true, isShadowMap: false, 1, 0f, MSAASamples.None, bindTextureMS: false, useDynamicScale: true, useDynamicScaleExplicit: false, RenderTextureMemoryless.None, VRTextureUsage.None, "_Crest_UnderwaterCameraColorTexture");
				}
				_AllocatedColor = true;
			}
		}

		public void ReAllocate(RenderTextureDescriptor descriptor)
		{
			if (!_Renderer.RenderBeforeTransparency || _Renderer.NeedsColorTexture)
			{
				RenderPipelineCompatibilityHelper.ReAllocateIfNeeded(ref _ColorTexture, in descriptor, FilterMode.Point, TextureWrapMode.Repeat, isShadowMap: false, 1, 0f, "_Crest_UnderwaterCameraColorTexture");
			}
		}

		public void Release()
		{
			_ColorTexture?.Release();
			_ColorTexture = null;
		}

		public void Execute(Camera camera, CommandBuffer buffer, RTHandle color, RTHandle depth, MaterialPropertyBlock mpb = null)
		{
			_Renderer.UpdateEffectMaterial(camera);
			_ColorTarget = color;
			_DepthTarget = depth;
			if (!_Renderer.RenderBeforeTransparency || _Renderer.NeedsColorTexture)
			{
				if (!_AllocatedColor)
				{
					Allocate(_GraphicsFormat);
				}
				buffer.SetGlobalTexture(UnderwaterRenderer.ShaderIDs.s_CameraColorTexture, _ColorTexture);
			}
			if (!_Renderer.RenderBeforeTransparency)
			{
				CopyColorTexture(buffer);
			}
			else
			{
				CoreUtils.SetRenderTarget(buffer, _ColorTarget, _DepthTarget, ClearFlag.None);
			}
			_Renderer.ExecuteEffect(camera, buffer, _CopyColorTexture, _SetRenderTargetToBackBuffers, mpb);
			buffer.ResolveAntiAliasedSurface(color);
		}
	}
}
