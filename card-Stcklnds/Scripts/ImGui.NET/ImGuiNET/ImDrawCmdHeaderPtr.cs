using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ImGuiNET
{
	public struct ImDrawCmdHeaderPtr
	{
		public unsafe ImDrawCmdHeader* NativePtr { get; }

		public unsafe ref Vector4 ClipRect => ref Unsafe.AsRef<Vector4>(&NativePtr->ClipRect);

		public unsafe ref IntPtr TextureId => ref Unsafe.AsRef<IntPtr>(&NativePtr->TextureId);

		public unsafe ref uint VtxOffset => ref Unsafe.AsRef<uint>(&NativePtr->VtxOffset);

		public unsafe ImDrawCmdHeaderPtr(ImDrawCmdHeader* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImDrawCmdHeaderPtr(IntPtr nativePtr)
		{
			NativePtr = (ImDrawCmdHeader*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImDrawCmdHeaderPtr(ImDrawCmdHeader* nativePtr)
		{
			return new ImDrawCmdHeaderPtr(nativePtr);
		}

		public unsafe static implicit operator ImDrawCmdHeader*(ImDrawCmdHeaderPtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImDrawCmdHeaderPtr(IntPtr nativePtr)
		{
			return new ImDrawCmdHeaderPtr(nativePtr);
		}
	}
}
