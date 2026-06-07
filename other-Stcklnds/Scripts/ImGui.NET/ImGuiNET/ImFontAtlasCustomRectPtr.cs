using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ImGuiNET
{
	public struct ImFontAtlasCustomRectPtr
	{
		public unsafe ImFontAtlasCustomRect* NativePtr { get; }

		public unsafe ref ushort Width => ref Unsafe.AsRef<ushort>(&NativePtr->Width);

		public unsafe ref ushort Height => ref Unsafe.AsRef<ushort>(&NativePtr->Height);

		public unsafe ref ushort X => ref Unsafe.AsRef<ushort>(&NativePtr->X);

		public unsafe ref ushort Y => ref Unsafe.AsRef<ushort>(&NativePtr->Y);

		public unsafe ref uint GlyphID => ref Unsafe.AsRef<uint>(&NativePtr->GlyphID);

		public unsafe ref float GlyphAdvanceX => ref Unsafe.AsRef<float>(&NativePtr->GlyphAdvanceX);

		public unsafe ref Vector2 GlyphOffset => ref Unsafe.AsRef<Vector2>(&NativePtr->GlyphOffset);

		public unsafe ImFontPtr Font => new ImFontPtr(NativePtr->Font);

		public unsafe ImFontAtlasCustomRectPtr(ImFontAtlasCustomRect* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImFontAtlasCustomRectPtr(IntPtr nativePtr)
		{
			NativePtr = (ImFontAtlasCustomRect*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImFontAtlasCustomRectPtr(ImFontAtlasCustomRect* nativePtr)
		{
			return new ImFontAtlasCustomRectPtr(nativePtr);
		}

		public unsafe static implicit operator ImFontAtlasCustomRect*(ImFontAtlasCustomRectPtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImFontAtlasCustomRectPtr(IntPtr nativePtr)
		{
			return new ImFontAtlasCustomRectPtr(nativePtr);
		}

		public unsafe void Destroy()
		{
			ImGuiNative.ImFontAtlasCustomRect_destroy(NativePtr);
		}

		public unsafe bool IsPacked()
		{
			return ImGuiNative.ImFontAtlasCustomRect_IsPacked(NativePtr) != 0;
		}
	}
}
