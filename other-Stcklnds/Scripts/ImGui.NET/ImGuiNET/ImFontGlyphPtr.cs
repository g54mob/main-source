using System;
using System.Runtime.CompilerServices;

namespace ImGuiNET
{
	public struct ImFontGlyphPtr
	{
		public unsafe ImFontGlyph* NativePtr { get; }

		public unsafe ref uint Colored => ref Unsafe.AsRef<uint>(&NativePtr->Colored);

		public unsafe ref uint Visible => ref Unsafe.AsRef<uint>(&NativePtr->Visible);

		public unsafe ref uint Codepoint => ref Unsafe.AsRef<uint>(&NativePtr->Codepoint);

		public unsafe ref float AdvanceX => ref Unsafe.AsRef<float>(&NativePtr->AdvanceX);

		public unsafe ref float X0 => ref Unsafe.AsRef<float>(&NativePtr->X0);

		public unsafe ref float Y0 => ref Unsafe.AsRef<float>(&NativePtr->Y0);

		public unsafe ref float X1 => ref Unsafe.AsRef<float>(&NativePtr->X1);

		public unsafe ref float Y1 => ref Unsafe.AsRef<float>(&NativePtr->Y1);

		public unsafe ref float U0 => ref Unsafe.AsRef<float>(&NativePtr->U0);

		public unsafe ref float V0 => ref Unsafe.AsRef<float>(&NativePtr->V0);

		public unsafe ref float U1 => ref Unsafe.AsRef<float>(&NativePtr->U1);

		public unsafe ref float V1 => ref Unsafe.AsRef<float>(&NativePtr->V1);

		public unsafe ImFontGlyphPtr(ImFontGlyph* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImFontGlyphPtr(IntPtr nativePtr)
		{
			NativePtr = (ImFontGlyph*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImFontGlyphPtr(ImFontGlyph* nativePtr)
		{
			return new ImFontGlyphPtr(nativePtr);
		}

		public unsafe static implicit operator ImFontGlyph*(ImFontGlyphPtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImFontGlyphPtr(IntPtr nativePtr)
		{
			return new ImFontGlyphPtr(nativePtr);
		}
	}
}
