using System;
using System.Runtime.CompilerServices;

namespace ImGuiNET
{
	public struct ImGuiOnceUponAFramePtr
	{
		public unsafe ImGuiOnceUponAFrame* NativePtr { get; }

		public unsafe ref int RefFrame => ref Unsafe.AsRef<int>(&NativePtr->RefFrame);

		public unsafe ImGuiOnceUponAFramePtr(ImGuiOnceUponAFrame* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImGuiOnceUponAFramePtr(IntPtr nativePtr)
		{
			NativePtr = (ImGuiOnceUponAFrame*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImGuiOnceUponAFramePtr(ImGuiOnceUponAFrame* nativePtr)
		{
			return new ImGuiOnceUponAFramePtr(nativePtr);
		}

		public unsafe static implicit operator ImGuiOnceUponAFrame*(ImGuiOnceUponAFramePtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImGuiOnceUponAFramePtr(IntPtr nativePtr)
		{
			return new ImGuiOnceUponAFramePtr(nativePtr);
		}

		public unsafe void Destroy()
		{
			ImGuiNative.ImGuiOnceUponAFrame_destroy(NativePtr);
		}
	}
}
