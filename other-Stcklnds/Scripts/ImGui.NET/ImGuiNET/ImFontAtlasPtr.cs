using System;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

namespace ImGuiNET
{
	public struct ImFontAtlasPtr
	{
		public unsafe ImFontAtlas* NativePtr { get; }

		public unsafe ref ImFontAtlasFlags Flags => ref Unsafe.AsRef<ImFontAtlasFlags>(&NativePtr->Flags);

		public unsafe ref IntPtr TexID => ref Unsafe.AsRef<IntPtr>(&NativePtr->TexID);

		public unsafe ref int TexDesiredWidth => ref Unsafe.AsRef<int>(&NativePtr->TexDesiredWidth);

		public unsafe ref int TexGlyphPadding => ref Unsafe.AsRef<int>(&NativePtr->TexGlyphPadding);

		public unsafe ref bool Locked => ref Unsafe.AsRef<bool>(&NativePtr->Locked);

		public unsafe IntPtr UserData
		{
			get
			{
				return (IntPtr)NativePtr->UserData;
			}
			set
			{
				NativePtr->UserData = (void*)value;
			}
		}

		public unsafe ref bool TexReady => ref Unsafe.AsRef<bool>(&NativePtr->TexReady);

		public unsafe ref bool TexPixelsUseColors => ref Unsafe.AsRef<bool>(&NativePtr->TexPixelsUseColors);

		public unsafe IntPtr TexPixelsAlpha8
		{
			get
			{
				return (IntPtr)NativePtr->TexPixelsAlpha8;
			}
			set
			{
				NativePtr->TexPixelsAlpha8 = (byte*)(void*)value;
			}
		}

		public unsafe IntPtr TexPixelsRGBA32
		{
			get
			{
				return (IntPtr)NativePtr->TexPixelsRGBA32;
			}
			set
			{
				NativePtr->TexPixelsRGBA32 = (uint*)(void*)value;
			}
		}

		public unsafe ref int TexWidth => ref Unsafe.AsRef<int>(&NativePtr->TexWidth);

		public unsafe ref int TexHeight => ref Unsafe.AsRef<int>(&NativePtr->TexHeight);

		public unsafe ref Vector2 TexUvScale => ref Unsafe.AsRef<Vector2>(&NativePtr->TexUvScale);

		public unsafe ref Vector2 TexUvWhitePixel => ref Unsafe.AsRef<Vector2>(&NativePtr->TexUvWhitePixel);

		public unsafe ImVector<ImFontPtr> Fonts => new ImVector<ImFontPtr>(NativePtr->Fonts);

		public unsafe ImPtrVector<ImFontAtlasCustomRectPtr> CustomRects => new ImPtrVector<ImFontAtlasCustomRectPtr>(NativePtr->CustomRects, Unsafe.SizeOf<ImFontAtlasCustomRect>());

		public unsafe ImPtrVector<ImFontConfigPtr> ConfigData => new ImPtrVector<ImFontConfigPtr>(NativePtr->ConfigData, Unsafe.SizeOf<ImFontConfig>());

		public unsafe RangeAccessor<Vector4> TexUvLines => new RangeAccessor<Vector4>(&NativePtr->TexUvLines_0, 64);

		public unsafe IntPtr FontBuilderIO
		{
			get
			{
				return (IntPtr)NativePtr->FontBuilderIO;
			}
			set
			{
				NativePtr->FontBuilderIO = (IntPtr*)(void*)value;
			}
		}

		public unsafe ref uint FontBuilderFlags => ref Unsafe.AsRef<uint>(&NativePtr->FontBuilderFlags);

		public unsafe ref int PackIdMouseCursors => ref Unsafe.AsRef<int>(&NativePtr->PackIdMouseCursors);

		public unsafe ref int PackIdLines => ref Unsafe.AsRef<int>(&NativePtr->PackIdLines);

		public unsafe ImFontAtlasPtr(ImFontAtlas* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImFontAtlasPtr(IntPtr nativePtr)
		{
			NativePtr = (ImFontAtlas*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImFontAtlasPtr(ImFontAtlas* nativePtr)
		{
			return new ImFontAtlasPtr(nativePtr);
		}

		public unsafe static implicit operator ImFontAtlas*(ImFontAtlasPtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImFontAtlasPtr(IntPtr nativePtr)
		{
			return new ImFontAtlasPtr(nativePtr);
		}

		public unsafe int AddCustomRectFontGlyph(ImFontPtr font, ushort id, int width, int height, float advance_x)
		{
			ImFont* nativePtr = font.NativePtr;
			return ImGuiNative.ImFontAtlas_AddCustomRectFontGlyph(NativePtr, nativePtr, id, width, height, advance_x, default(Vector2));
		}

		public unsafe int AddCustomRectFontGlyph(ImFontPtr font, ushort id, int width, int height, float advance_x, Vector2 offset)
		{
			ImFont* nativePtr = font.NativePtr;
			return ImGuiNative.ImFontAtlas_AddCustomRectFontGlyph(NativePtr, nativePtr, id, width, height, advance_x, offset);
		}

		public unsafe int AddCustomRectRegular(int width, int height)
		{
			return ImGuiNative.ImFontAtlas_AddCustomRectRegular(NativePtr, width, height);
		}

		public unsafe ImFontPtr AddFont(ImFontConfigPtr font_cfg)
		{
			ImFontConfig* nativePtr = font_cfg.NativePtr;
			return new ImFontPtr(ImGuiNative.ImFontAtlas_AddFont(NativePtr, nativePtr));
		}

		public unsafe ImFontPtr AddFontDefault()
		{
			ImFontConfig* font_cfg = null;
			return new ImFontPtr(ImGuiNative.ImFontAtlas_AddFontDefault(NativePtr, font_cfg));
		}

		public unsafe ImFontPtr AddFontDefault(ImFontConfigPtr font_cfg)
		{
			ImFontConfig* nativePtr = font_cfg.NativePtr;
			return new ImFontPtr(ImGuiNative.ImFontAtlas_AddFontDefault(NativePtr, nativePtr));
		}

		public unsafe ImFontPtr AddFontFromFileTTF(string filename, float size_pixels)
		{
			int num = 0;
			byte* ptr;
			if (filename != null)
			{
				num = Encoding.UTF8.GetByteCount(filename);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(filename, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImFontConfig* font_cfg = null;
			ushort* glyph_ranges = null;
			ImFont* nativePtr = ImGuiNative.ImFontAtlas_AddFontFromFileTTF(NativePtr, ptr, size_pixels, font_cfg, glyph_ranges);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return new ImFontPtr(nativePtr);
		}

		public unsafe ImFontPtr AddFontFromFileTTF(string filename, float size_pixels, ImFontConfigPtr font_cfg)
		{
			int num = 0;
			byte* ptr;
			if (filename != null)
			{
				num = Encoding.UTF8.GetByteCount(filename);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(filename, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImFontConfig* nativePtr = font_cfg.NativePtr;
			ushort* glyph_ranges = null;
			ImFont* nativePtr2 = ImGuiNative.ImFontAtlas_AddFontFromFileTTF(NativePtr, ptr, size_pixels, nativePtr, glyph_ranges);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return new ImFontPtr(nativePtr2);
		}

		public unsafe ImFontPtr AddFontFromFileTTF(string filename, float size_pixels, ImFontConfigPtr font_cfg, IntPtr glyph_ranges)
		{
			int num = 0;
			byte* ptr;
			if (filename != null)
			{
				num = Encoding.UTF8.GetByteCount(filename);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(filename, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImFontConfig* nativePtr = font_cfg.NativePtr;
			ushort* glyph_ranges2 = (ushort*)glyph_ranges.ToPointer();
			ImFont* nativePtr2 = ImGuiNative.ImFontAtlas_AddFontFromFileTTF(NativePtr, ptr, size_pixels, nativePtr, glyph_ranges2);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return new ImFontPtr(nativePtr2);
		}

		public unsafe ImFontPtr AddFontFromMemoryCompressedBase85TTF(string compressed_font_data_base85, float size_pixels)
		{
			int num = 0;
			byte* ptr;
			if (compressed_font_data_base85 != null)
			{
				num = Encoding.UTF8.GetByteCount(compressed_font_data_base85);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(compressed_font_data_base85, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImFontConfig* font_cfg = null;
			ushort* glyph_ranges = null;
			ImFont* nativePtr = ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedBase85TTF(NativePtr, ptr, size_pixels, font_cfg, glyph_ranges);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return new ImFontPtr(nativePtr);
		}

		public unsafe ImFontPtr AddFontFromMemoryCompressedBase85TTF(string compressed_font_data_base85, float size_pixels, ImFontConfigPtr font_cfg)
		{
			int num = 0;
			byte* ptr;
			if (compressed_font_data_base85 != null)
			{
				num = Encoding.UTF8.GetByteCount(compressed_font_data_base85);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(compressed_font_data_base85, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImFontConfig* nativePtr = font_cfg.NativePtr;
			ushort* glyph_ranges = null;
			ImFont* nativePtr2 = ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedBase85TTF(NativePtr, ptr, size_pixels, nativePtr, glyph_ranges);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return new ImFontPtr(nativePtr2);
		}

		public unsafe ImFontPtr AddFontFromMemoryCompressedBase85TTF(string compressed_font_data_base85, float size_pixels, ImFontConfigPtr font_cfg, IntPtr glyph_ranges)
		{
			int num = 0;
			byte* ptr;
			if (compressed_font_data_base85 != null)
			{
				num = Encoding.UTF8.GetByteCount(compressed_font_data_base85);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(compressed_font_data_base85, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImFontConfig* nativePtr = font_cfg.NativePtr;
			ushort* glyph_ranges2 = (ushort*)glyph_ranges.ToPointer();
			ImFont* nativePtr2 = ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedBase85TTF(NativePtr, ptr, size_pixels, nativePtr, glyph_ranges2);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return new ImFontPtr(nativePtr2);
		}

		public unsafe ImFontPtr AddFontFromMemoryCompressedTTF(IntPtr compressed_font_data, int compressed_font_size, float size_pixels)
		{
			void* compressed_font_data2 = compressed_font_data.ToPointer();
			ImFontConfig* font_cfg = null;
			ushort* glyph_ranges = null;
			return new ImFontPtr(ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedTTF(NativePtr, compressed_font_data2, compressed_font_size, size_pixels, font_cfg, glyph_ranges));
		}

		public unsafe ImFontPtr AddFontFromMemoryCompressedTTF(IntPtr compressed_font_data, int compressed_font_size, float size_pixels, ImFontConfigPtr font_cfg)
		{
			void* compressed_font_data2 = compressed_font_data.ToPointer();
			ImFontConfig* nativePtr = font_cfg.NativePtr;
			ushort* glyph_ranges = null;
			return new ImFontPtr(ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedTTF(NativePtr, compressed_font_data2, compressed_font_size, size_pixels, nativePtr, glyph_ranges));
		}

		public unsafe ImFontPtr AddFontFromMemoryCompressedTTF(IntPtr compressed_font_data, int compressed_font_size, float size_pixels, ImFontConfigPtr font_cfg, IntPtr glyph_ranges)
		{
			void* compressed_font_data2 = compressed_font_data.ToPointer();
			ImFontConfig* nativePtr = font_cfg.NativePtr;
			ushort* glyph_ranges2 = (ushort*)glyph_ranges.ToPointer();
			return new ImFontPtr(ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedTTF(NativePtr, compressed_font_data2, compressed_font_size, size_pixels, nativePtr, glyph_ranges2));
		}

		public unsafe ImFontPtr AddFontFromMemoryTTF(IntPtr font_data, int font_size, float size_pixels)
		{
			void* font_data2 = font_data.ToPointer();
			ImFontConfig* font_cfg = null;
			ushort* glyph_ranges = null;
			return new ImFontPtr(ImGuiNative.ImFontAtlas_AddFontFromMemoryTTF(NativePtr, font_data2, font_size, size_pixels, font_cfg, glyph_ranges));
		}

		public unsafe ImFontPtr AddFontFromMemoryTTF(IntPtr font_data, int font_size, float size_pixels, ImFontConfigPtr font_cfg)
		{
			void* font_data2 = font_data.ToPointer();
			ImFontConfig* nativePtr = font_cfg.NativePtr;
			ushort* glyph_ranges = null;
			return new ImFontPtr(ImGuiNative.ImFontAtlas_AddFontFromMemoryTTF(NativePtr, font_data2, font_size, size_pixels, nativePtr, glyph_ranges));
		}

		public unsafe ImFontPtr AddFontFromMemoryTTF(IntPtr font_data, int font_size, float size_pixels, ImFontConfigPtr font_cfg, IntPtr glyph_ranges)
		{
			void* font_data2 = font_data.ToPointer();
			ImFontConfig* nativePtr = font_cfg.NativePtr;
			ushort* glyph_ranges2 = (ushort*)glyph_ranges.ToPointer();
			return new ImFontPtr(ImGuiNative.ImFontAtlas_AddFontFromMemoryTTF(NativePtr, font_data2, font_size, size_pixels, nativePtr, glyph_ranges2));
		}

		public unsafe bool Build()
		{
			return ImGuiNative.ImFontAtlas_Build(NativePtr) != 0;
		}

		public unsafe void CalcCustomRectUV(ImFontAtlasCustomRectPtr rect, out Vector2 out_uv_min, out Vector2 out_uv_max)
		{
			ImFontAtlasCustomRect* nativePtr = rect.NativePtr;
			fixed (Vector2* out_uv_min2 = &out_uv_min)
			{
				fixed (Vector2* out_uv_max2 = &out_uv_max)
				{
					ImGuiNative.ImFontAtlas_CalcCustomRectUV(NativePtr, nativePtr, out_uv_min2, out_uv_max2);
				}
			}
		}

		public unsafe void Clear()
		{
			ImGuiNative.ImFontAtlas_Clear(NativePtr);
		}

		public unsafe void ClearFonts()
		{
			ImGuiNative.ImFontAtlas_ClearFonts(NativePtr);
		}

		public unsafe void ClearInputData()
		{
			ImGuiNative.ImFontAtlas_ClearInputData(NativePtr);
		}

		public unsafe void ClearTexData()
		{
			ImGuiNative.ImFontAtlas_ClearTexData(NativePtr);
		}

		public unsafe void Destroy()
		{
			ImGuiNative.ImFontAtlas_destroy(NativePtr);
		}

		public unsafe ImFontAtlasCustomRectPtr GetCustomRectByIndex(int index)
		{
			return new ImFontAtlasCustomRectPtr(ImGuiNative.ImFontAtlas_GetCustomRectByIndex(NativePtr, index));
		}

		public unsafe IntPtr GetGlyphRangesChineseFull()
		{
			return (IntPtr)ImGuiNative.ImFontAtlas_GetGlyphRangesChineseFull(NativePtr);
		}

		public unsafe IntPtr GetGlyphRangesChineseSimplifiedCommon()
		{
			return (IntPtr)ImGuiNative.ImFontAtlas_GetGlyphRangesChineseSimplifiedCommon(NativePtr);
		}

		public unsafe IntPtr GetGlyphRangesCyrillic()
		{
			return (IntPtr)ImGuiNative.ImFontAtlas_GetGlyphRangesCyrillic(NativePtr);
		}

		public unsafe IntPtr GetGlyphRangesDefault()
		{
			return (IntPtr)ImGuiNative.ImFontAtlas_GetGlyphRangesDefault(NativePtr);
		}

		public unsafe IntPtr GetGlyphRangesGreek()
		{
			return (IntPtr)ImGuiNative.ImFontAtlas_GetGlyphRangesGreek(NativePtr);
		}

		public unsafe IntPtr GetGlyphRangesJapanese()
		{
			return (IntPtr)ImGuiNative.ImFontAtlas_GetGlyphRangesJapanese(NativePtr);
		}

		public unsafe IntPtr GetGlyphRangesKorean()
		{
			return (IntPtr)ImGuiNative.ImFontAtlas_GetGlyphRangesKorean(NativePtr);
		}

		public unsafe IntPtr GetGlyphRangesThai()
		{
			return (IntPtr)ImGuiNative.ImFontAtlas_GetGlyphRangesThai(NativePtr);
		}

		public unsafe IntPtr GetGlyphRangesVietnamese()
		{
			return (IntPtr)ImGuiNative.ImFontAtlas_GetGlyphRangesVietnamese(NativePtr);
		}

		public unsafe bool GetMouseCursorTexData(ImGuiMouseCursor cursor, out Vector2 out_offset, out Vector2 out_size, out Vector2 out_uv_border, out Vector2 out_uv_fill)
		{
			fixed (Vector2* out_offset2 = &out_offset)
			{
				fixed (Vector2* out_size2 = &out_size)
				{
					fixed (Vector2* out_uv_border2 = &out_uv_border)
					{
						fixed (Vector2* out_uv_fill2 = &out_uv_fill)
						{
							return ImGuiNative.ImFontAtlas_GetMouseCursorTexData(NativePtr, cursor, out_offset2, out_size2, out_uv_border2, out_uv_fill2) != 0;
						}
					}
				}
			}
		}

		public unsafe void GetTexDataAsAlpha8(out byte* out_pixels, out int out_width, out int out_height)
		{
			int* out_bytes_per_pixel = null;
			fixed (byte** out_pixels2 = &out_pixels)
			{
				fixed (int* out_width2 = &out_width)
				{
					fixed (int* out_height2 = &out_height)
					{
						ImGuiNative.ImFontAtlas_GetTexDataAsAlpha8(NativePtr, out_pixels2, out_width2, out_height2, out_bytes_per_pixel);
					}
				}
			}
		}

		public unsafe void GetTexDataAsAlpha8(out byte* out_pixels, out int out_width, out int out_height, out int out_bytes_per_pixel)
		{
			fixed (byte** out_pixels2 = &out_pixels)
			{
				fixed (int* out_width2 = &out_width)
				{
					fixed (int* out_height2 = &out_height)
					{
						fixed (int* out_bytes_per_pixel2 = &out_bytes_per_pixel)
						{
							ImGuiNative.ImFontAtlas_GetTexDataAsAlpha8(NativePtr, out_pixels2, out_width2, out_height2, out_bytes_per_pixel2);
						}
					}
				}
			}
		}

		public unsafe void GetTexDataAsAlpha8(out IntPtr out_pixels, out int out_width, out int out_height)
		{
			int* out_bytes_per_pixel = null;
			fixed (IntPtr* out_pixels2 = &out_pixels)
			{
				fixed (int* out_width2 = &out_width)
				{
					fixed (int* out_height2 = &out_height)
					{
						ImGuiNative.ImFontAtlas_GetTexDataAsAlpha8(NativePtr, out_pixels2, out_width2, out_height2, out_bytes_per_pixel);
					}
				}
			}
		}

		public unsafe void GetTexDataAsAlpha8(out IntPtr out_pixels, out int out_width, out int out_height, out int out_bytes_per_pixel)
		{
			fixed (IntPtr* out_pixels2 = &out_pixels)
			{
				fixed (int* out_width2 = &out_width)
				{
					fixed (int* out_height2 = &out_height)
					{
						fixed (int* out_bytes_per_pixel2 = &out_bytes_per_pixel)
						{
							ImGuiNative.ImFontAtlas_GetTexDataAsAlpha8(NativePtr, out_pixels2, out_width2, out_height2, out_bytes_per_pixel2);
						}
					}
				}
			}
		}

		public unsafe void GetTexDataAsRGBA32(out byte* out_pixels, out int out_width, out int out_height)
		{
			int* out_bytes_per_pixel = null;
			fixed (byte** out_pixels2 = &out_pixels)
			{
				fixed (int* out_width2 = &out_width)
				{
					fixed (int* out_height2 = &out_height)
					{
						ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32(NativePtr, out_pixels2, out_width2, out_height2, out_bytes_per_pixel);
					}
				}
			}
		}

		public unsafe void GetTexDataAsRGBA32(out byte* out_pixels, out int out_width, out int out_height, out int out_bytes_per_pixel)
		{
			fixed (byte** out_pixels2 = &out_pixels)
			{
				fixed (int* out_width2 = &out_width)
				{
					fixed (int* out_height2 = &out_height)
					{
						fixed (int* out_bytes_per_pixel2 = &out_bytes_per_pixel)
						{
							ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32(NativePtr, out_pixels2, out_width2, out_height2, out_bytes_per_pixel2);
						}
					}
				}
			}
		}

		public unsafe void GetTexDataAsRGBA32(out IntPtr out_pixels, out int out_width, out int out_height)
		{
			int* out_bytes_per_pixel = null;
			fixed (IntPtr* out_pixels2 = &out_pixels)
			{
				fixed (int* out_width2 = &out_width)
				{
					fixed (int* out_height2 = &out_height)
					{
						ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32(NativePtr, out_pixels2, out_width2, out_height2, out_bytes_per_pixel);
					}
				}
			}
		}

		public unsafe void GetTexDataAsRGBA32(out IntPtr out_pixels, out int out_width, out int out_height, out int out_bytes_per_pixel)
		{
			fixed (IntPtr* out_pixels2 = &out_pixels)
			{
				fixed (int* out_width2 = &out_width)
				{
					fixed (int* out_height2 = &out_height)
					{
						fixed (int* out_bytes_per_pixel2 = &out_bytes_per_pixel)
						{
							ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32(NativePtr, out_pixels2, out_width2, out_height2, out_bytes_per_pixel2);
						}
					}
				}
			}
		}

		public unsafe bool IsBuilt()
		{
			return ImGuiNative.ImFontAtlas_IsBuilt(NativePtr) != 0;
		}

		public unsafe void SetTexID(IntPtr id)
		{
			ImGuiNative.ImFontAtlas_SetTexID(NativePtr, id);
		}
	}
}
