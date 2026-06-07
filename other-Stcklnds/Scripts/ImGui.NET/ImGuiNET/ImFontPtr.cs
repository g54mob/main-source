using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ImGuiNET
{
	public struct ImFontPtr
	{
		public unsafe ImFont* NativePtr { get; }

		public unsafe ImVector<float> IndexAdvanceX => new ImVector<float>(NativePtr->IndexAdvanceX);

		public unsafe ref float FallbackAdvanceX => ref Unsafe.AsRef<float>(&NativePtr->FallbackAdvanceX);

		public unsafe ref float FontSize => ref Unsafe.AsRef<float>(&NativePtr->FontSize);

		public unsafe ImVector<ushort> IndexLookup => new ImVector<ushort>(NativePtr->IndexLookup);

		public unsafe ImPtrVector<ImFontGlyphPtr> Glyphs => new ImPtrVector<ImFontGlyphPtr>(NativePtr->Glyphs, Unsafe.SizeOf<ImFontGlyph>());

		public unsafe ImFontGlyphPtr FallbackGlyph => new ImFontGlyphPtr(NativePtr->FallbackGlyph);

		public unsafe ImFontAtlasPtr ContainerAtlas => new ImFontAtlasPtr(NativePtr->ContainerAtlas);

		public unsafe ImFontConfigPtr ConfigData => new ImFontConfigPtr(NativePtr->ConfigData);

		public unsafe ref short ConfigDataCount => ref Unsafe.AsRef<short>(&NativePtr->ConfigDataCount);

		public unsafe ref ushort FallbackChar => ref Unsafe.AsRef<ushort>(&NativePtr->FallbackChar);

		public unsafe ref ushort EllipsisChar => ref Unsafe.AsRef<ushort>(&NativePtr->EllipsisChar);

		public unsafe ref ushort DotChar => ref Unsafe.AsRef<ushort>(&NativePtr->DotChar);

		public unsafe ref bool DirtyLookupTables => ref Unsafe.AsRef<bool>(&NativePtr->DirtyLookupTables);

		public unsafe ref float Scale => ref Unsafe.AsRef<float>(&NativePtr->Scale);

		public unsafe ref float Ascent => ref Unsafe.AsRef<float>(&NativePtr->Ascent);

		public unsafe ref float Descent => ref Unsafe.AsRef<float>(&NativePtr->Descent);

		public unsafe ref int MetricsTotalSurface => ref Unsafe.AsRef<int>(&NativePtr->MetricsTotalSurface);

		public unsafe RangeAccessor<byte> Used4kPagesMap => new RangeAccessor<byte>(NativePtr->Used4kPagesMap, 2);

		public unsafe ImFontPtr(ImFont* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImFontPtr(IntPtr nativePtr)
		{
			NativePtr = (ImFont*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImFontPtr(ImFont* nativePtr)
		{
			return new ImFontPtr(nativePtr);
		}

		public unsafe static implicit operator ImFont*(ImFontPtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImFontPtr(IntPtr nativePtr)
		{
			return new ImFontPtr(nativePtr);
		}

		public unsafe void AddGlyph(ImFontConfigPtr src_cfg, ushort c, float x0, float y0, float x1, float y1, float u0, float v0, float u1, float v1, float advance_x)
		{
			ImFontConfig* nativePtr = src_cfg.NativePtr;
			ImGuiNative.ImFont_AddGlyph(NativePtr, nativePtr, c, x0, y0, x1, y1, u0, v0, u1, v1, advance_x);
		}

		public unsafe void AddRemapChar(ushort dst, ushort src)
		{
			byte overwrite_dst = 1;
			ImGuiNative.ImFont_AddRemapChar(NativePtr, dst, src, overwrite_dst);
		}

		public unsafe void AddRemapChar(ushort dst, ushort src, bool overwrite_dst)
		{
			byte overwrite_dst2 = (byte)(overwrite_dst ? 1 : 0);
			ImGuiNative.ImFont_AddRemapChar(NativePtr, dst, src, overwrite_dst2);
		}

		public unsafe void BuildLookupTable()
		{
			ImGuiNative.ImFont_BuildLookupTable(NativePtr);
		}

		public unsafe void ClearOutputData()
		{
			ImGuiNative.ImFont_ClearOutputData(NativePtr);
		}

		public unsafe void Destroy()
		{
			ImGuiNative.ImFont_destroy(NativePtr);
		}

		public unsafe ImFontGlyphPtr FindGlyph(ushort c)
		{
			return new ImFontGlyphPtr(ImGuiNative.ImFont_FindGlyph(NativePtr, c));
		}

		public unsafe ImFontGlyphPtr FindGlyphNoFallback(ushort c)
		{
			return new ImFontGlyphPtr(ImGuiNative.ImFont_FindGlyphNoFallback(NativePtr, c));
		}

		public unsafe float GetCharAdvance(ushort c)
		{
			return ImGuiNative.ImFont_GetCharAdvance(NativePtr, c);
		}

		public unsafe string GetDebugName()
		{
			return Util.StringFromPtr(ImGuiNative.ImFont_GetDebugName(NativePtr));
		}

		public unsafe void GrowIndex(int new_size)
		{
			ImGuiNative.ImFont_GrowIndex(NativePtr, new_size);
		}

		public unsafe bool IsLoaded()
		{
			return ImGuiNative.ImFont_IsLoaded(NativePtr) != 0;
		}

		public unsafe void RenderChar(ImDrawListPtr draw_list, float size, Vector2 pos, uint col, ushort c)
		{
			ImDrawList* nativePtr = draw_list.NativePtr;
			ImGuiNative.ImFont_RenderChar(NativePtr, nativePtr, size, pos, col, c);
		}

		public unsafe void SetGlyphVisible(ushort c, bool visible)
		{
			byte visible2 = (byte)(visible ? 1 : 0);
			ImGuiNative.ImFont_SetGlyphVisible(NativePtr, c, visible2);
		}
	}
}
