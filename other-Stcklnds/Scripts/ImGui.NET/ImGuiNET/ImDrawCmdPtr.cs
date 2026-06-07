using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ImGuiNET
{
	public struct ImDrawCmdPtr
	{
		public unsafe ImDrawCmd* NativePtr { get; }

		public unsafe ref Vector4 ClipRect => ref Unsafe.AsRef<Vector4>(&NativePtr->ClipRect);

		public unsafe ref IntPtr TextureId => ref Unsafe.AsRef<IntPtr>(&NativePtr->TextureId);

		public unsafe ref uint VtxOffset => ref Unsafe.AsRef<uint>(&NativePtr->VtxOffset);

		public unsafe ref uint IdxOffset => ref Unsafe.AsRef<uint>(&NativePtr->IdxOffset);

		public unsafe ref uint ElemCount => ref Unsafe.AsRef<uint>(&NativePtr->ElemCount);

		public unsafe ref IntPtr UserCallback => ref Unsafe.AsRef<IntPtr>(&NativePtr->UserCallback);

		public unsafe IntPtr UserCallbackData
		{
			get
			{
				return (IntPtr)NativePtr->UserCallbackData;
			}
			set
			{
				NativePtr->UserCallbackData = (void*)value;
			}
		}

		public unsafe ImDrawCmdPtr(ImDrawCmd* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImDrawCmdPtr(IntPtr nativePtr)
		{
			NativePtr = (ImDrawCmd*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImDrawCmdPtr(ImDrawCmd* nativePtr)
		{
			return new ImDrawCmdPtr(nativePtr);
		}

		public unsafe static implicit operator ImDrawCmd*(ImDrawCmdPtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImDrawCmdPtr(IntPtr nativePtr)
		{
			return new ImDrawCmdPtr(nativePtr);
		}

		public unsafe void Destroy()
		{
			ImGuiNative.ImDrawCmd_destroy(NativePtr);
		}

		public unsafe IntPtr GetTexID()
		{
			return ImGuiNative.ImDrawCmd_GetTexID(NativePtr);
		}
	}
}
