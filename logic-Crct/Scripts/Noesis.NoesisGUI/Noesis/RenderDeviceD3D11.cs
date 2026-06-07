using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class RenderDeviceD3D11 : NativeRenderDevice
	{
		public RenderDeviceD3D11(IntPtr deviceContext)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public RenderDeviceD3D11(IntPtr deviceContext, bool sRGB)
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

		[PreserveSig]
		private static extern IntPtr Noesis_RenderDeviceD3D11_Create(IntPtr deviceContext, bool sRGB);

		[PreserveSig]
		private static extern IntPtr Noesis_RenderDeviceD3D11_WrapTexture(IntPtr nativePointer, int width, int height, int numMipMaps, bool isInverted, bool hasAlpha);

		[PreserveSig]
		private static extern IntPtr Noesis_RenderDeviceD3D11_GetTextureNativePointer(HandleRef texture);
	}
}
