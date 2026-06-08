using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ImGuiNET
{
	public struct ImDrawDataPtr
	{
		public unsafe ImDrawData* NativePtr { get; }

		public unsafe ref bool Valid => ref Unsafe.AsRef<bool>(&NativePtr->Valid);

		public unsafe ref int CmdListsCount => ref Unsafe.AsRef<int>(&NativePtr->CmdListsCount);

		public unsafe ref int TotalIdxCount => ref Unsafe.AsRef<int>(&NativePtr->TotalIdxCount);

		public unsafe ref int TotalVtxCount => ref Unsafe.AsRef<int>(&NativePtr->TotalVtxCount);

		public unsafe IntPtr CmdLists
		{
			get
			{
				return (IntPtr)NativePtr->CmdLists;
			}
			set
			{
				NativePtr->CmdLists = (ImDrawList**)(void*)value;
			}
		}

		public unsafe ref Vector2 DisplayPos => ref Unsafe.AsRef<Vector2>(&NativePtr->DisplayPos);

		public unsafe ref Vector2 DisplaySize => ref Unsafe.AsRef<Vector2>(&NativePtr->DisplaySize);

		public unsafe ref Vector2 FramebufferScale => ref Unsafe.AsRef<Vector2>(&NativePtr->FramebufferScale);

		public unsafe ImGuiViewportPtr OwnerViewport => new ImGuiViewportPtr(NativePtr->OwnerViewport);

		public unsafe RangePtrAccessor<ImDrawListPtr> CmdListsRange => new RangePtrAccessor<ImDrawListPtr>(CmdLists.ToPointer(), CmdListsCount);

		public unsafe ImDrawDataPtr(ImDrawData* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImDrawDataPtr(IntPtr nativePtr)
		{
			NativePtr = (ImDrawData*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImDrawDataPtr(ImDrawData* nativePtr)
		{
			return new ImDrawDataPtr(nativePtr);
		}

		public unsafe static implicit operator ImDrawData*(ImDrawDataPtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImDrawDataPtr(IntPtr nativePtr)
		{
			return new ImDrawDataPtr(nativePtr);
		}

		public unsafe void Clear()
		{
			ImGuiNative.ImDrawData_Clear(NativePtr);
		}

		public unsafe void DeIndexAllBuffers()
		{
			ImGuiNative.ImDrawData_DeIndexAllBuffers(NativePtr);
		}

		public unsafe void Destroy()
		{
			ImGuiNative.ImDrawData_destroy(NativePtr);
		}

		public unsafe void ScaleClipRects(Vector2 fb_scale)
		{
			ImGuiNative.ImDrawData_ScaleClipRects(NativePtr, fb_scale);
		}
	}
}
