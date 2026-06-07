using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class DynamicTextureSource : ImageSource
	{
		public delegate Texture TextureRenderCallback(RenderDevice device, object user);

		private delegate IntPtr NoesisTextureRenderCallback(int callbackId, IntPtr devicePtr, IntPtr userPtr);

		private delegate void NoesisRemoveCallback(int callbackId);

		private static NoesisTextureRenderCallback _renderCallback;

		private static NoesisRemoveCallback _removeCallback;

		private static int CallbackId;

		private static Dictionary<int, TextureRenderCallback> _callbacks;

		public int PixelWidth => 0;

		public int PixelHeight => 0;

		internal new static DynamicTextureSource CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal DynamicTextureSource(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(DynamicTextureSource obj)
		{
			return default(HandleRef);
		}

		protected DynamicTextureSource()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public DynamicTextureSource(uint width, uint height, TextureRenderCallback callback, object user)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		private static IntPtr Create(uint width, uint height, TextureRenderCallback callback, object user)
		{
			return (IntPtr)0;
		}

		[MonoPInvokeCallback(typeof(NoesisTextureRenderCallback))]
		private static IntPtr OnTextureRender(int callbackId, IntPtr devicePtr, IntPtr userPtr)
		{
			return (IntPtr)0;
		}

		[MonoPInvokeCallback(typeof(NoesisRemoveCallback))]
		private static void OnRemoveCallback(int callbackId)
		{
		}

		[PreserveSig]
		private static extern IntPtr DynamicTextureSource_Create(uint width, uint height, int callbackId, NoesisRemoveCallback removeCallback, NoesisTextureRenderCallback renderCallback, IntPtr user);

		public void Resize(uint width, uint height)
		{
		}
	}
}
