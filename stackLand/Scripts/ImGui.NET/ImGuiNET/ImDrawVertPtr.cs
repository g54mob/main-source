using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ImGuiNET
{
	public struct ImDrawVertPtr
	{
		public unsafe ImDrawVert* NativePtr { get; }

		public unsafe ref Vector2 pos => ref Unsafe.AsRef<Vector2>(&NativePtr->pos);

		public unsafe ref Vector2 uv => ref Unsafe.AsRef<Vector2>(&NativePtr->uv);

		public unsafe ref uint col => ref Unsafe.AsRef<uint>(&NativePtr->col);

		public unsafe ImDrawVertPtr(ImDrawVert* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImDrawVertPtr(IntPtr nativePtr)
		{
			NativePtr = (ImDrawVert*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImDrawVertPtr(ImDrawVert* nativePtr)
		{
			return new ImDrawVertPtr(nativePtr);
		}

		public unsafe static implicit operator ImDrawVert*(ImDrawVertPtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImDrawVertPtr(IntPtr nativePtr)
		{
			return new ImDrawVertPtr(nativePtr);
		}
	}
}
