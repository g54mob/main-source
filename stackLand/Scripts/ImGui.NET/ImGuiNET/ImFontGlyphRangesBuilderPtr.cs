using System;
using System.Text;

namespace ImGuiNET
{
	public struct ImFontGlyphRangesBuilderPtr
	{
		public unsafe ImFontGlyphRangesBuilder* NativePtr { get; }

		public unsafe ImVector<uint> UsedChars => new ImVector<uint>(NativePtr->UsedChars);

		public unsafe ImFontGlyphRangesBuilderPtr(ImFontGlyphRangesBuilder* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImFontGlyphRangesBuilderPtr(IntPtr nativePtr)
		{
			NativePtr = (ImFontGlyphRangesBuilder*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImFontGlyphRangesBuilderPtr(ImFontGlyphRangesBuilder* nativePtr)
		{
			return new ImFontGlyphRangesBuilderPtr(nativePtr);
		}

		public unsafe static implicit operator ImFontGlyphRangesBuilder*(ImFontGlyphRangesBuilderPtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImFontGlyphRangesBuilderPtr(IntPtr nativePtr)
		{
			return new ImFontGlyphRangesBuilderPtr(nativePtr);
		}

		public unsafe void AddChar(ushort c)
		{
			ImGuiNative.ImFontGlyphRangesBuilder_AddChar(NativePtr, c);
		}

		public unsafe void AddRanges(IntPtr ranges)
		{
			ushort* ranges2 = (ushort*)ranges.ToPointer();
			ImGuiNative.ImFontGlyphRangesBuilder_AddRanges(NativePtr, ranges2);
		}

		public unsafe void AddText(string text)
		{
			int num = 0;
			byte* ptr;
			if (text != null)
			{
				num = Encoding.UTF8.GetByteCount(text);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(text, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte* text_end = null;
			ImGuiNative.ImFontGlyphRangesBuilder_AddText(NativePtr, ptr, text_end);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe void BuildRanges(out ImVector out_ranges)
		{
			fixed (ImVector* out_ranges2 = &out_ranges)
			{
				ImGuiNative.ImFontGlyphRangesBuilder_BuildRanges(NativePtr, out_ranges2);
			}
		}

		public unsafe void Clear()
		{
			ImGuiNative.ImFontGlyphRangesBuilder_Clear(NativePtr);
		}

		public unsafe void Destroy()
		{
			ImGuiNative.ImFontGlyphRangesBuilder_destroy(NativePtr);
		}

		public unsafe bool GetBit(uint n)
		{
			return ImGuiNative.ImFontGlyphRangesBuilder_GetBit(NativePtr, n) != 0;
		}

		public unsafe void SetBit(uint n)
		{
			ImGuiNative.ImFontGlyphRangesBuilder_SetBit(NativePtr, n);
		}
	}
}
