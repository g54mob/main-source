using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class NativeRenderTarget : RenderTarget
	{
		public override Texture Texture => null;

		internal new static NativeRenderTarget CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal NativeRenderTarget(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		[PreserveSig]
		private static extern IntPtr Noesis_RenderTarget_GetTexture(HandleRef rt);
	}
}
