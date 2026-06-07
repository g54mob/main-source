using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Noesis
{
	public abstract class Texture : BaseComponent
	{
		private delegate uint Callback_GetWidth(IntPtr cPtr);

		private delegate uint Callback_GetHeight(IntPtr cPtr);

		private delegate bool Callback_HasMipMaps(IntPtr cPtr);

		private delegate bool Callback_IsInverted(IntPtr cPtr);

		private delegate bool Callback_HasAlpha(IntPtr cPtr);

		private delegate void UnregisterTextureCallback(IntPtr texturePtr);

		private static Callback_GetWidth _getWidth;

		private static Callback_GetHeight _getHeight;

		private static Callback_HasMipMaps _hasMipMaps;

		private static Callback_IsInverted _isInverted;

		private static Callback_HasAlpha _hasAlpha;

		private static Dictionary<long, object> Textures;

		private static UnregisterTextureCallback _unregisterTexture;

		public abstract uint Width { get; }

		public abstract uint Height { get; }

		public abstract bool HasMipMaps { get; }

		public abstract bool IsInverted { get; }

		public abstract bool HasAlpha { get; }

		public void SetPrivateData(object data)
		{
		}

		static Texture()
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}

		protected Texture()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_GetWidth))]
		private static uint GetWidth(IntPtr cPtr)
		{
			return 0u;
		}

		[MonoPInvokeCallback(typeof(Callback_GetHeight))]
		private static uint GetHeight(IntPtr cPtr)
		{
			return 0u;
		}

		[MonoPInvokeCallback(typeof(Callback_HasMipMaps))]
		private static bool GetHasMipMaps(IntPtr cPtr)
		{
			return false;
		}

		[MonoPInvokeCallback(typeof(Callback_IsInverted))]
		private static bool GetIsInverted(IntPtr cPtr)
		{
			return false;
		}

		[MonoPInvokeCallback(typeof(Callback_HasAlpha))]
		private static bool GetHasAlpha(IntPtr cPtr)
		{
			return false;
		}

		[PreserveSig]
		private static extern void Noesis_Texture_SetCallbacks(Callback_GetWidth getWidth, Callback_GetHeight getHeight, Callback_HasMipMaps hasMipMaps, Callback_IsInverted isInverted, Callback_HasAlpha hasAlpha);

		[PreserveSig]
		private static extern void Noesis_Texture_SetPrivateData(HandleRef tex, HandleRef data);

		[PreserveSig]
		private static extern IntPtr Noesis_Texture_Extend(IntPtr typeName);

		internal Texture(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Texture obj)
		{
			return default(HandleRef);
		}

		public static void RegisterCallbacks()
		{
		}

		internal static Texture WrapTexture(UnityEngine.Texture tex)
		{
			return null;
		}

		internal static Texture WrapTexture(Texture2D tex)
		{
			return null;
		}

		private static Texture WrapTexture(object texture, IntPtr nativePointer, int width, int height, int numLevels)
		{
			return null;
		}

		internal static IntPtr EnsureNativePointer(UnityEngine.Texture tex)
		{
			return (IntPtr)0;
		}

		[MonoPInvokeCallback(typeof(UnregisterTextureCallback))]
		private static void UnregisterTexture(IntPtr texturePtr)
		{
		}

		[PreserveSig]
		private static extern void Noesis_RemoveEnqueuedTexture(IntPtr texturePtr);

		[PreserveSig]
		private static extern IntPtr Noesis_WrapTexture(IntPtr texture, int width, int height, int numLevels);

		[PreserveSig]
		private static extern void Noesis_SetUnregisterTextureCallback(UnregisterTextureCallback callback);
	}
}
