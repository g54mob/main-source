using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ImGuiNET
{
	public struct ImFontConfigPtr
	{
		public unsafe ImFontConfig* NativePtr { get; }

		public unsafe IntPtr FontData
		{
			get
			{
				return (IntPtr)NativePtr->FontData;
			}
			set
			{
				NativePtr->FontData = (void*)value;
			}
		}

		public unsafe ref int FontDataSize => ref Unsafe.AsRef<int>(&NativePtr->FontDataSize);

		public unsafe ref bool FontDataOwnedByAtlas => ref Unsafe.AsRef<bool>(&NativePtr->FontDataOwnedByAtlas);

		public unsafe ref int FontNo => ref Unsafe.AsRef<int>(&NativePtr->FontNo);

		public unsafe ref float SizePixels => ref Unsafe.AsRef<float>(&NativePtr->SizePixels);

		public unsafe ref int OversampleH => ref Unsafe.AsRef<int>(&NativePtr->OversampleH);

		public unsafe ref int OversampleV => ref Unsafe.AsRef<int>(&NativePtr->OversampleV);

		public unsafe ref bool PixelSnapH => ref Unsafe.AsRef<bool>(&NativePtr->PixelSnapH);

		public unsafe ref Vector2 GlyphExtraSpacing => ref Unsafe.AsRef<Vector2>(&NativePtr->GlyphExtraSpacing);

		public unsafe ref Vector2 GlyphOffset => ref Unsafe.AsRef<Vector2>(&NativePtr->GlyphOffset);

		public unsafe IntPtr GlyphRanges
		{
			get
			{
				return (IntPtr)NativePtr->GlyphRanges;
			}
			set
			{
				NativePtr->GlyphRanges = (ushort*)(void*)value;
			}
		}

		public unsafe ref float GlyphMinAdvanceX => ref Unsafe.AsRef<float>(&NativePtr->GlyphMinAdvanceX);

		public unsafe ref float GlyphMaxAdvanceX => ref Unsafe.AsRef<float>(&NativePtr->GlyphMaxAdvanceX);

		public unsafe ref bool MergeMode => ref Unsafe.AsRef<bool>(&NativePtr->MergeMode);

		public unsafe ref uint FontBuilderFlags => ref Unsafe.AsRef<uint>(&NativePtr->FontBuilderFlags);

		public unsafe ref float RasterizerMultiply => ref Unsafe.AsRef<float>(&NativePtr->RasterizerMultiply);

		public unsafe ref ushort EllipsisChar => ref Unsafe.AsRef<ushort>(&NativePtr->EllipsisChar);

		public unsafe RangeAccessor<byte> Name => new RangeAccessor<byte>(NativePtr->Name, 40);

		public unsafe ImFontPtr DstFont => new ImFontPtr(NativePtr->DstFont);

		public unsafe ImFontConfigPtr(ImFontConfig* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImFontConfigPtr(IntPtr nativePtr)
		{
			NativePtr = (ImFontConfig*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImFontConfigPtr(ImFontConfig* nativePtr)
		{
			return new ImFontConfigPtr(nativePtr);
		}

		public unsafe static implicit operator ImFontConfig*(ImFontConfigPtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImFontConfigPtr(IntPtr nativePtr)
		{
			return new ImFontConfigPtr(nativePtr);
		}

		public unsafe void Destroy()
		{
			ImGuiNative.ImFontConfig_destroy(NativePtr);
		}
	}
}
