using System;
using System.Runtime.CompilerServices;

namespace ImGuiNET
{
	public struct StbUndoRecordPtr
	{
		public unsafe StbUndoRecord* NativePtr { get; }

		public unsafe ref int where => ref Unsafe.AsRef<int>(&NativePtr->where);

		public unsafe ref int insert_length => ref Unsafe.AsRef<int>(&NativePtr->insert_length);

		public unsafe ref int delete_length => ref Unsafe.AsRef<int>(&NativePtr->delete_length);

		public unsafe ref int char_storage => ref Unsafe.AsRef<int>(&NativePtr->char_storage);

		public unsafe StbUndoRecordPtr(StbUndoRecord* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe StbUndoRecordPtr(IntPtr nativePtr)
		{
			NativePtr = (StbUndoRecord*)(void*)nativePtr;
		}

		public unsafe static implicit operator StbUndoRecordPtr(StbUndoRecord* nativePtr)
		{
			return new StbUndoRecordPtr(nativePtr);
		}

		public unsafe static implicit operator StbUndoRecord*(StbUndoRecordPtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator StbUndoRecordPtr(IntPtr nativePtr)
		{
			return new StbUndoRecordPtr(nativePtr);
		}
	}
}
