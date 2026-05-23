using System;
using System.Runtime.CompilerServices;

namespace ImGuiNET
{
	public struct STB_TexteditStatePtr
	{
		public unsafe STB_TexteditState* NativePtr { get; }

		public unsafe ref int cursor => ref Unsafe.AsRef<int>(&NativePtr->cursor);

		public unsafe ref int select_start => ref Unsafe.AsRef<int>(&NativePtr->select_start);

		public unsafe ref int select_end => ref Unsafe.AsRef<int>(&NativePtr->select_end);

		public unsafe ref byte insert_mode => ref Unsafe.AsRef<byte>(&NativePtr->insert_mode);

		public unsafe ref int row_count_per_page => ref Unsafe.AsRef<int>(&NativePtr->row_count_per_page);

		public unsafe ref byte cursor_at_end_of_line => ref Unsafe.AsRef<byte>(&NativePtr->cursor_at_end_of_line);

		public unsafe ref byte initialized => ref Unsafe.AsRef<byte>(&NativePtr->initialized);

		public unsafe ref byte has_preferred_x => ref Unsafe.AsRef<byte>(&NativePtr->has_preferred_x);

		public unsafe ref byte single_line => ref Unsafe.AsRef<byte>(&NativePtr->single_line);

		public unsafe ref byte padding1 => ref Unsafe.AsRef<byte>(&NativePtr->padding1);

		public unsafe ref byte padding2 => ref Unsafe.AsRef<byte>(&NativePtr->padding2);

		public unsafe ref byte padding3 => ref Unsafe.AsRef<byte>(&NativePtr->padding3);

		public unsafe ref float preferred_x => ref Unsafe.AsRef<float>(&NativePtr->preferred_x);

		public unsafe ref StbUndoState undostate => ref Unsafe.AsRef<StbUndoState>(&NativePtr->undostate);

		public unsafe STB_TexteditStatePtr(STB_TexteditState* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe STB_TexteditStatePtr(IntPtr nativePtr)
		{
			NativePtr = (STB_TexteditState*)(void*)nativePtr;
		}

		public unsafe static implicit operator STB_TexteditStatePtr(STB_TexteditState* nativePtr)
		{
			return new STB_TexteditStatePtr(nativePtr);
		}

		public unsafe static implicit operator STB_TexteditState*(STB_TexteditStatePtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator STB_TexteditStatePtr(IntPtr nativePtr)
		{
			return new STB_TexteditStatePtr(nativePtr);
		}
	}
}
