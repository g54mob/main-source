using System;
using System.Runtime.CompilerServices;

namespace ImGuiNET
{
	public struct ImDrawChannelPtr
	{
		public unsafe ImDrawChannel* NativePtr { get; }

		public unsafe ImPtrVector<ImDrawCmdPtr> _CmdBuffer => new ImPtrVector<ImDrawCmdPtr>(NativePtr->_CmdBuffer, Unsafe.SizeOf<ImDrawCmd>());

		public unsafe ImVector<ushort> _IdxBuffer => new ImVector<ushort>(NativePtr->_IdxBuffer);

		public unsafe ImDrawChannelPtr(ImDrawChannel* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImDrawChannelPtr(IntPtr nativePtr)
		{
			NativePtr = (ImDrawChannel*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImDrawChannelPtr(ImDrawChannel* nativePtr)
		{
			return new ImDrawChannelPtr(nativePtr);
		}

		public unsafe static implicit operator ImDrawChannel*(ImDrawChannelPtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImDrawChannelPtr(IntPtr nativePtr)
		{
			return new ImDrawChannelPtr(nativePtr);
		}
	}
}
