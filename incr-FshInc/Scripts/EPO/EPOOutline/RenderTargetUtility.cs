using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.XR;

namespace EPOOutline
{
	public static class RenderTargetUtility
	{
		public struct RenderTextureInfo
		{
			public readonly RenderTextureDescriptor Descriptor;

			public RenderTextureInfo(RenderTextureDescriptor descriptor)
			{
				Descriptor = descriptor;
			}
		}

		private static RenderTextureFormat? hdrFormat;

		public static RenderTextureFormat GetRTFormat(bool useHDR)
		{
			if (!useHDR)
			{
				return RenderTextureFormat.ARGB32;
			}
			return GetHDRTextureFormat();
		}

		public static int GetDepthSliceForEye(StereoTargetEyeMask mask)
		{
			switch (mask)
			{
			case StereoTargetEyeMask.Both:
				return -1;
			case StereoTargetEyeMask.None:
			case StereoTargetEyeMask.Left:
				return 0;
			case StereoTargetEyeMask.Right:
				return 1;
			default:
				throw new ArgumentException("Unknown mode");
			}
		}

		public static RenderTargetIdentifier ComposeTarget(OutlineParameters parameters, RenderTargetIdentifier target)
		{
			return new RenderTargetIdentifier(target, 0, CubemapFace.Unknown, GetDepthSliceForEye(parameters.EyeMask));
		}

		public static RenderTextureInfo GetTargetInfo(OutlineParameters parameters, int width, int height)
		{
			RenderTextureFormat rTFormat = GetRTFormat(parameters.UseHDR);
			if (XRUtility.IsUsingVR(parameters))
			{
				RenderTextureDescriptor eyeTextureDesc = XRSettings.eyeTextureDesc;
				eyeTextureDesc.colorFormat = rTFormat;
				eyeTextureDesc.width = width;
				eyeTextureDesc.height = height;
				eyeTextureDesc.depthBufferBits = 0;
				eyeTextureDesc.msaaSamples = Mathf.Max(parameters.Antialiasing, 1);
				VRTextureUsage vrUsage = ((parameters.EyeMask != StereoTargetEyeMask.Both) ? VRTextureUsage.OneEye : VRTextureUsage.TwoEyes);
				eyeTextureDesc.vrUsage = vrUsage;
				return new RenderTextureInfo(eyeTextureDesc);
			}
			RenderTextureDescriptor descriptor = new RenderTextureDescriptor(width, height, rTFormat, 0);
			descriptor.dimension = TextureDimension.Tex2D;
			descriptor.msaaSamples = Mathf.Max(parameters.Antialiasing, 1);
			return new RenderTextureInfo(descriptor);
		}

		public static RTHandle GetRT(OutlineParameters parameters, int width, int height, string name)
		{
			RenderTextureInfo targetInfo = GetTargetInfo(parameters, width, height);
			return OutlineEffect.HandleSystem.Alloc(width, height, colorFormat: targetInfo.Descriptor.graphicsFormat, slices: targetInfo.Descriptor.volumeDepth, depthBufferBits: DepthBits.None, filterMode: FilterMode.Bilinear, wrapMode: TextureWrapMode.Clamp, dimension: targetInfo.Descriptor.dimension, enableRandomWrite: targetInfo.Descriptor.enableRandomWrite, useMipMap: targetInfo.Descriptor.useMipMap, autoGenerateMips: targetInfo.Descriptor.autoGenerateMips, isShadowMap: false, anisoLevel: 1, mipMapBias: 0f, msaaSamples: (MSAASamples)targetInfo.Descriptor.msaaSamples, bindTextureMS: targetInfo.Descriptor.bindMS, useDynamicScale: targetInfo.Descriptor.useDynamicScale, useDynamicScaleExplicit: targetInfo.Descriptor.useDynamicScaleExplicit, memoryless: targetInfo.Descriptor.memoryless, vrUsage: targetInfo.Descriptor.vrUsage, name: name);
		}

		public static RenderTextureFormat GetHDRTextureFormat()
		{
			if (hdrFormat.HasValue)
			{
				return hdrFormat.Value;
			}
			if (SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.ARGBHalf))
			{
				hdrFormat = RenderTextureFormat.ARGBHalf;
			}
			else if (SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.ARGBFloat))
			{
				hdrFormat = RenderTextureFormat.ARGBFloat;
			}
			else if (SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.ARGB64))
			{
				hdrFormat = RenderTextureFormat.ARGB64;
			}
			else
			{
				hdrFormat = RenderTextureFormat.ARGB32;
			}
			return hdrFormat.Value;
		}

		public static GraphicsFormat GetHDRGraphicsFormat()
		{
			return GraphicsFormatUtility.GetGraphicsFormat(GetHDRTextureFormat(), RenderTextureReadWrite.Default);
		}
	}
}
