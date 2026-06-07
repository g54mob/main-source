using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ImGuiNET
{
	public struct ImColorPtr
	{
		public unsafe ImColor* NativePtr { get; }

		public unsafe ref Vector4 Value => ref Unsafe.AsRef<Vector4>(&NativePtr->Value);

		public unsafe ImColorPtr(ImColor* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImColorPtr(IntPtr nativePtr)
		{
			NativePtr = (ImColor*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImColorPtr(ImColor* nativePtr)
		{
			return new ImColorPtr(nativePtr);
		}

		public unsafe static implicit operator ImColor*(ImColorPtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImColorPtr(IntPtr nativePtr)
		{
			return new ImColorPtr(nativePtr);
		}

		public unsafe void Destroy()
		{
			ImGuiNative.ImColor_destroy(NativePtr);
		}

		public unsafe ImColor HSV(float h, float s, float v)
		{
			float a = 1f;
			ImColor result = default(ImColor);
			ImGuiNative.ImColor_HSV(&result, h, s, v, a);
			return result;
		}

		public unsafe ImColor HSV(float h, float s, float v, float a)
		{
			ImColor result = default(ImColor);
			ImGuiNative.ImColor_HSV(&result, h, s, v, a);
			return result;
		}

		public unsafe void SetHSV(float h, float s, float v)
		{
			float a = 1f;
			ImGuiNative.ImColor_SetHSV(NativePtr, h, s, v, a);
		}

		public unsafe void SetHSV(float h, float s, float v, float a)
		{
			ImGuiNative.ImColor_SetHSV(NativePtr, h, s, v, a);
		}
	}
}
