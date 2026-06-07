using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class RenderDeviceMTL : NativeRenderDevice
	{
		public RenderDeviceMTL(IntPtr device, bool sRGB)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public static Texture WrapTexture(object texture, IntPtr textureId, int width, int height, int numMipMaps, bool isInverted, bool hasAlpha)
		{
			return null;
		}

		public void SetOffscreenCommandBuffer(IntPtr commandBuffer)
		{
		}

		public void SetOnScreenEncoder(IntPtr encoder, uint colorFormat, uint stencilFormat, uint sampleCount)
		{
		}

		[PreserveSig]
		private static extern IntPtr Noesis_RenderDeviceMTL_Create(IntPtr device, bool sRGB);

		[PreserveSig]
		private static extern IntPtr Noesis_RenderDeviceMTL_WrapTexture(IntPtr textureId, int width, int height, int numMipMaps, bool isInverted, bool hasAlpha);

		[PreserveSig]
		private static extern void Noesis_RenderDeviceMTL_SetOffScreenCommandBuffer(HandleRef renderDevice, IntPtr commandBuffer);

		[PreserveSig]
		private static extern void Noesis_RenderDeviceMTL_SetOnScreenEncoder(HandleRef renderDevice, IntPtr encoder, uint colorFormat, uint stencilFormat, uint sampleCount);
	}
}
