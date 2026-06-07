using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class NativeTexture : Texture
	{
		public override uint Width => 0u;

		public override uint Height => 0u;

		public override bool HasMipMaps => false;

		public override bool IsInverted => false;

		public override bool HasAlpha => false;

		internal new static NativeTexture CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal NativeTexture(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		[PreserveSig]
		private static extern uint Noesis_Texture_GetWidth(HandleRef tex);

		[PreserveSig]
		private static extern uint Noesis_Texture_GetHeight(HandleRef tex);

		[PreserveSig]
		private static extern bool Noesis_Texture_HasMipMaps(HandleRef tex);

		[PreserveSig]
		private static extern bool Noesis_Texture_IsInverted(HandleRef tex);

		[PreserveSig]
		private static extern bool Noesis_Texture_HasAlpha(HandleRef tex);
	}
}
