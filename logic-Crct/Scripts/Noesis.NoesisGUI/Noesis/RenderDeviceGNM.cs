using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class RenderDeviceGNM : NativeRenderDevice
	{
		public struct GPUAllocator
		{
			public Func<uint, uint, IntPtr> AllocateGarlic;

			public Action<IntPtr> ReleaseGarlic;

			public Func<uint, uint, IntPtr> AllocateOnion;

			public Action<IntPtr> ReleaseOnion;
		}

		private delegate IntPtr Callback_Alloc(IntPtr user, uint size, uint alignment);

		private delegate void Callback_Free(IntPtr user, IntPtr address);

		private static Callback_Alloc _garlicAlloc;

		private static Callback_Free _garlicFree;

		private static Callback_Alloc _onionAlloc;

		private static Callback_Free _onionFree;

		private static GPUAllocator _allocator;

		public RenderDeviceGNM(bool sRGB, GPUAllocator allocator)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public static Texture WrapTexture(object texture, IntPtr nativePointer, int width, int height, int numMipMaps, bool isInverted, bool hasAlpha)
		{
			return null;
		}

		public void SetContext(IntPtr context)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_Alloc))]
		private static IntPtr GarlicAlloc(IntPtr user, uint size, uint alignment)
		{
			return (IntPtr)0;
		}

		[MonoPInvokeCallback(typeof(Callback_Free))]
		private static void GarlicFree(IntPtr user, IntPtr address)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_Alloc))]
		private static IntPtr OnionAlloc(IntPtr user, uint size, uint alignment)
		{
			return (IntPtr)0;
		}

		[MonoPInvokeCallback(typeof(Callback_Free))]
		private static void OnionFree(IntPtr user, IntPtr address)
		{
		}

		[PreserveSig]
		private static extern IntPtr Noesis_RenderDeviceGNM_Create(bool sRGB, Callback_Alloc garlicAlloc, Callback_Free garlicFree, Callback_Alloc onionAlloc, Callback_Free onionFree);

		[PreserveSig]
		private static extern IntPtr Noesis_RenderDeviceGNM_WrapTexture(IntPtr nativePointer, int width, int height, int numMipMaps, bool isInverted, bool hasAlpha);

		[PreserveSig]
		private static extern IntPtr Noesis_RenderDeviceGNM_SetContext(HandleRef device, IntPtr context);
	}
}
