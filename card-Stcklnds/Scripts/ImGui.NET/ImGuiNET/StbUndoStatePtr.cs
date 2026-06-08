using System;
using System.Runtime.CompilerServices;

namespace ImGuiNET
{
	public struct StbUndoStatePtr
	{
		public unsafe StbUndoState* NativePtr { get; }

		public unsafe RangeAccessor<StbUndoRecord> undo_rec => new RangeAccessor<StbUndoRecord>(&NativePtr->undo_rec_0, 99);

		public unsafe RangeAccessor<ushort> undo_char => new RangeAccessor<ushort>(NativePtr->undo_char, 999);

		public unsafe ref short undo_point => ref Unsafe.AsRef<short>(&NativePtr->undo_point);

		public unsafe ref short redo_point => ref Unsafe.AsRef<short>(&NativePtr->redo_point);

		public unsafe ref int undo_char_point => ref Unsafe.AsRef<int>(&NativePtr->undo_char_point);

		public unsafe ref int redo_char_point => ref Unsafe.AsRef<int>(&NativePtr->redo_char_point);

		public unsafe StbUndoStatePtr(StbUndoState* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe StbUndoStatePtr(IntPtr nativePtr)
		{
			NativePtr = (StbUndoState*)(void*)nativePtr;
		}

		public unsafe static implicit operator StbUndoStatePtr(StbUndoState* nativePtr)
		{
			return new StbUndoStatePtr(nativePtr);
		}

		public unsafe static implicit operator StbUndoState*(StbUndoStatePtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator StbUndoStatePtr(IntPtr nativePtr)
		{
			return new StbUndoStatePtr(nativePtr);
		}
	}
}
