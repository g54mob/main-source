using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class RenderDeviceD3D12 : NativeRenderDevice
	{
		public RenderDeviceD3D12(IntPtr device, IntPtr frameFence, int colorFormat, int stencilFormat, int samples)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public RenderDeviceD3D12(IntPtr device, IntPtr frameFence, int colorFormat, int stencilFormat, int samples, bool sRGB)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public static Texture WrapTexture(object texture, IntPtr nativePointer, int width, int height, int numMipMaps, bool isInverted, bool hasAlpha)
		{
			return null;
		}

		public static IntPtr GetTextureNativePointer(Texture texture)
		{
			return (IntPtr)0;
		}

		public void SetCommandList(IntPtr commands, long fenceValue)
		{
		}

		[PreserveSig]
		private static extern IntPtr Noesis_RenderDeviceD3D12_Create(IntPtr device, IntPtr frameFence, int colorFormat, int stencilFormat, int samples, bool sRGB);

		[PreserveSig]
		private static extern IntPtr Noesis_RenderDeviceD3D12_WrapTexture(IntPtr nativePointer, int width, int height, int numMipMaps, bool isInverted, bool hasAlpha);

		[PreserveSig]
		private static extern IntPtr Noesis_RenderDeviceD3D12_GetTextureNativePointer(HandleRef texture);

		[PreserveSig]
		private static extern void Noesis_RenderDeviceD3D12_SetCommandList(HandleRef device, IntPtr commands, long fenceValue);
	}
}
