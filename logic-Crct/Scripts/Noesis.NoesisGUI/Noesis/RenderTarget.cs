using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public abstract class RenderTarget : BaseComponent
	{
		private delegate IntPtr Callback_GetTexture(IntPtr cPtr);

		private static Callback_GetTexture _getTexture;

		public abstract Texture Texture { get; }

		static RenderTarget()
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}

		protected RenderTarget()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal RenderTarget(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		[MonoPInvokeCallback(typeof(Callback_GetTexture))]
		private static IntPtr GetTexture(IntPtr cPtr)
		{
			return (IntPtr)0;
		}

		[PreserveSig]
		private static extern void Noesis_RenderTarget_SetCallbacks(Callback_GetTexture getTexture);

		[PreserveSig]
		private static extern IntPtr Noesis_RenderTarget_Extend(IntPtr typeName);
	}
}
