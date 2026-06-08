using System;
using System.Runtime.CompilerServices;

namespace ImGuiNET
{
	public struct ImDrawListSplitterPtr
	{
		public unsafe ImDrawListSplitter* NativePtr { get; }

		public unsafe ref int _Current => ref Unsafe.AsRef<int>(&NativePtr->_Current);

		public unsafe ref int _Count => ref Unsafe.AsRef<int>(&NativePtr->_Count);

		public unsafe ImPtrVector<ImDrawChannelPtr> _Channels => new ImPtrVector<ImDrawChannelPtr>(NativePtr->_Channels, Unsafe.SizeOf<ImDrawChannel>());

		public unsafe ImDrawListSplitterPtr(ImDrawListSplitter* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImDrawListSplitterPtr(IntPtr nativePtr)
		{
			NativePtr = (ImDrawListSplitter*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImDrawListSplitterPtr(ImDrawListSplitter* nativePtr)
		{
			return new ImDrawListSplitterPtr(nativePtr);
		}

		public unsafe static implicit operator ImDrawListSplitter*(ImDrawListSplitterPtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImDrawListSplitterPtr(IntPtr nativePtr)
		{
			return new ImDrawListSplitterPtr(nativePtr);
		}

		public unsafe void Clear()
		{
			ImGuiNative.ImDrawListSplitter_Clear(NativePtr);
		}

		public unsafe void ClearFreeMemory()
		{
			ImGuiNative.ImDrawListSplitter_ClearFreeMemory(NativePtr);
		}

		public unsafe void Destroy()
		{
			ImGuiNative.ImDrawListSplitter_destroy(NativePtr);
		}

		public unsafe void Merge(ImDrawListPtr draw_list)
		{
			ImDrawList* nativePtr = draw_list.NativePtr;
			ImGuiNative.ImDrawListSplitter_Merge(NativePtr, nativePtr);
		}

		public unsafe void SetCurrentChannel(ImDrawListPtr draw_list, int channel_idx)
		{
			ImDrawList* nativePtr = draw_list.NativePtr;
			ImGuiNative.ImDrawListSplitter_SetCurrentChannel(NativePtr, nativePtr, channel_idx);
		}

		public unsafe void Split(ImDrawListPtr draw_list, int count)
		{
			ImDrawList* nativePtr = draw_list.NativePtr;
			ImGuiNative.ImDrawListSplitter_Split(NativePtr, nativePtr, count);
		}
	}
}
