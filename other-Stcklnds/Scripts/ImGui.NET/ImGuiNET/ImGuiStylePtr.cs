using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ImGuiNET
{
	public struct ImGuiStylePtr
	{
		public unsafe ImGuiStyle* NativePtr { get; }

		public unsafe ref float Alpha => ref Unsafe.AsRef<float>(&NativePtr->Alpha);

		public unsafe ref float DisabledAlpha => ref Unsafe.AsRef<float>(&NativePtr->DisabledAlpha);

		public unsafe ref Vector2 WindowPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->WindowPadding);

		public unsafe ref float WindowRounding => ref Unsafe.AsRef<float>(&NativePtr->WindowRounding);

		public unsafe ref float WindowBorderSize => ref Unsafe.AsRef<float>(&NativePtr->WindowBorderSize);

		public unsafe ref Vector2 WindowMinSize => ref Unsafe.AsRef<Vector2>(&NativePtr->WindowMinSize);

		public unsafe ref Vector2 WindowTitleAlign => ref Unsafe.AsRef<Vector2>(&NativePtr->WindowTitleAlign);

		public unsafe ref ImGuiDir WindowMenuButtonPosition => ref Unsafe.AsRef<ImGuiDir>(&NativePtr->WindowMenuButtonPosition);

		public unsafe ref float ChildRounding => ref Unsafe.AsRef<float>(&NativePtr->ChildRounding);

		public unsafe ref float ChildBorderSize => ref Unsafe.AsRef<float>(&NativePtr->ChildBorderSize);

		public unsafe ref float PopupRounding => ref Unsafe.AsRef<float>(&NativePtr->PopupRounding);

		public unsafe ref float PopupBorderSize => ref Unsafe.AsRef<float>(&NativePtr->PopupBorderSize);

		public unsafe ref Vector2 FramePadding => ref Unsafe.AsRef<Vector2>(&NativePtr->FramePadding);

		public unsafe ref float FrameRounding => ref Unsafe.AsRef<float>(&NativePtr->FrameRounding);

		public unsafe ref float FrameBorderSize => ref Unsafe.AsRef<float>(&NativePtr->FrameBorderSize);

		public unsafe ref Vector2 ItemSpacing => ref Unsafe.AsRef<Vector2>(&NativePtr->ItemSpacing);

		public unsafe ref Vector2 ItemInnerSpacing => ref Unsafe.AsRef<Vector2>(&NativePtr->ItemInnerSpacing);

		public unsafe ref Vector2 CellPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->CellPadding);

		public unsafe ref Vector2 TouchExtraPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->TouchExtraPadding);

		public unsafe ref float IndentSpacing => ref Unsafe.AsRef<float>(&NativePtr->IndentSpacing);

		public unsafe ref float ColumnsMinSpacing => ref Unsafe.AsRef<float>(&NativePtr->ColumnsMinSpacing);

		public unsafe ref float ScrollbarSize => ref Unsafe.AsRef<float>(&NativePtr->ScrollbarSize);

		public unsafe ref float ScrollbarRounding => ref Unsafe.AsRef<float>(&NativePtr->ScrollbarRounding);

		public unsafe ref float GrabMinSize => ref Unsafe.AsRef<float>(&NativePtr->GrabMinSize);

		public unsafe ref float GrabRounding => ref Unsafe.AsRef<float>(&NativePtr->GrabRounding);

		public unsafe ref float LogSliderDeadzone => ref Unsafe.AsRef<float>(&NativePtr->LogSliderDeadzone);

		public unsafe ref float TabRounding => ref Unsafe.AsRef<float>(&NativePtr->TabRounding);

		public unsafe ref float TabBorderSize => ref Unsafe.AsRef<float>(&NativePtr->TabBorderSize);

		public unsafe ref float TabMinWidthForCloseButton => ref Unsafe.AsRef<float>(&NativePtr->TabMinWidthForCloseButton);

		public unsafe ref ImGuiDir ColorButtonPosition => ref Unsafe.AsRef<ImGuiDir>(&NativePtr->ColorButtonPosition);

		public unsafe ref Vector2 ButtonTextAlign => ref Unsafe.AsRef<Vector2>(&NativePtr->ButtonTextAlign);

		public unsafe ref Vector2 SelectableTextAlign => ref Unsafe.AsRef<Vector2>(&NativePtr->SelectableTextAlign);

		public unsafe ref Vector2 DisplayWindowPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->DisplayWindowPadding);

		public unsafe ref Vector2 DisplaySafeAreaPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->DisplaySafeAreaPadding);

		public unsafe ref float MouseCursorScale => ref Unsafe.AsRef<float>(&NativePtr->MouseCursorScale);

		public unsafe ref bool AntiAliasedLines => ref Unsafe.AsRef<bool>(&NativePtr->AntiAliasedLines);

		public unsafe ref bool AntiAliasedLinesUseTex => ref Unsafe.AsRef<bool>(&NativePtr->AntiAliasedLinesUseTex);

		public unsafe ref bool AntiAliasedFill => ref Unsafe.AsRef<bool>(&NativePtr->AntiAliasedFill);

		public unsafe ref float CurveTessellationTol => ref Unsafe.AsRef<float>(&NativePtr->CurveTessellationTol);

		public unsafe ref float CircleTessellationMaxError => ref Unsafe.AsRef<float>(&NativePtr->CircleTessellationMaxError);

		public unsafe RangeAccessor<Vector4> Colors => new RangeAccessor<Vector4>(&NativePtr->Colors_0, 55);

		public unsafe ImGuiStylePtr(ImGuiStyle* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImGuiStylePtr(IntPtr nativePtr)
		{
			NativePtr = (ImGuiStyle*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImGuiStylePtr(ImGuiStyle* nativePtr)
		{
			return new ImGuiStylePtr(nativePtr);
		}

		public unsafe static implicit operator ImGuiStyle*(ImGuiStylePtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImGuiStylePtr(IntPtr nativePtr)
		{
			return new ImGuiStylePtr(nativePtr);
		}

		public unsafe void Destroy()
		{
			ImGuiNative.ImGuiStyle_destroy(NativePtr);
		}

		public unsafe void ScaleAllSizes(float scale_factor)
		{
			ImGuiNative.ImGuiStyle_ScaleAllSizes(NativePtr, scale_factor);
		}
	}
}
