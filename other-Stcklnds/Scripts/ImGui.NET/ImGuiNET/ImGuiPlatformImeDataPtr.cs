using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ImGuiNET
{
	public struct ImGuiPlatformImeDataPtr
	{
		public unsafe ImGuiPlatformImeData* NativePtr { get; }

		public unsafe ref bool WantVisible => ref Unsafe.AsRef<bool>(&NativePtr->WantVisible);

		public unsafe ref Vector2 InputPos => ref Unsafe.AsRef<Vector2>(&NativePtr->InputPos);

		public unsafe ref float InputLineHeight => ref Unsafe.AsRef<float>(&NativePtr->InputLineHeight);

		public unsafe ImGuiPlatformImeDataPtr(ImGuiPlatformImeData* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImGuiPlatformImeDataPtr(IntPtr nativePtr)
		{
			NativePtr = (ImGuiPlatformImeData*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImGuiPlatformImeDataPtr(ImGuiPlatformImeData* nativePtr)
		{
			return new ImGuiPlatformImeDataPtr(nativePtr);
		}

		public unsafe static implicit operator ImGuiPlatformImeData*(ImGuiPlatformImeDataPtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImGuiPlatformImeDataPtr(IntPtr nativePtr)
		{
			return new ImGuiPlatformImeDataPtr(nativePtr);
		}

		public unsafe void Destroy()
		{
			ImGuiNative.ImGuiPlatformImeData_destroy(NativePtr);
		}
	}
}
