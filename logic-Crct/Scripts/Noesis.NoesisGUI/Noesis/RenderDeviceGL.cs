using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class RenderDeviceGL : NativeRenderDevice
	{
		public RenderDeviceGL()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public static Texture WrapTexture(object texture, IntPtr nativePointer, int width, int height, int numMipMaps, bool isInverted, bool hasAlpha)
		{
			return null;
		}

		[PreserveSig]
		private static extern IntPtr Noesis_RenderDeviceGL_Create();

		[PreserveSig]
		private static extern IntPtr Noesis_RenderDeviceGL_WrapTexture(IntPtr nativePointer, int width, int height, int numMipMaps, bool isInverted, bool hasAlpha);
	}
}
