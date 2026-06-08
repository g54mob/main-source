using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
	public struct ImGuiInputTextCallbackDataPtr
	{
		public unsafe ImGuiInputTextCallbackData* NativePtr { get; }

		public unsafe ref ImGuiInputTextFlags EventFlag => ref Unsafe.AsRef<ImGuiInputTextFlags>(&NativePtr->EventFlag);

		public unsafe ref ImGuiInputTextFlags Flags => ref Unsafe.AsRef<ImGuiInputTextFlags>(&NativePtr->Flags);

		public unsafe IntPtr UserData
		{
			get
			{
				return (IntPtr)NativePtr->UserData;
			}
			set
			{
				NativePtr->UserData = (void*)value;
			}
		}

		public unsafe ref ushort EventChar => ref Unsafe.AsRef<ushort>(&NativePtr->EventChar);

		public unsafe ref ImGuiKey EventKey => ref Unsafe.AsRef<ImGuiKey>(&NativePtr->EventKey);

		public unsafe IntPtr Buf
		{
			get
			{
				return (IntPtr)NativePtr->Buf;
			}
			set
			{
				NativePtr->Buf = (byte*)(void*)value;
			}
		}

		public unsafe ref int BufTextLen => ref Unsafe.AsRef<int>(&NativePtr->BufTextLen);

		public unsafe ref int BufSize => ref Unsafe.AsRef<int>(&NativePtr->BufSize);

		public unsafe ref bool BufDirty => ref Unsafe.AsRef<bool>(&NativePtr->BufDirty);

		public unsafe ref int CursorPos => ref Unsafe.AsRef<int>(&NativePtr->CursorPos);

		public unsafe ref int SelectionStart => ref Unsafe.AsRef<int>(&NativePtr->SelectionStart);

		public unsafe ref int SelectionEnd => ref Unsafe.AsRef<int>(&NativePtr->SelectionEnd);

		public unsafe ImGuiInputTextCallbackDataPtr(ImGuiInputTextCallbackData* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImGuiInputTextCallbackDataPtr(IntPtr nativePtr)
		{
			NativePtr = (ImGuiInputTextCallbackData*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImGuiInputTextCallbackDataPtr(ImGuiInputTextCallbackData* nativePtr)
		{
			return new ImGuiInputTextCallbackDataPtr(nativePtr);
		}

		public unsafe static implicit operator ImGuiInputTextCallbackData*(ImGuiInputTextCallbackDataPtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImGuiInputTextCallbackDataPtr(IntPtr nativePtr)
		{
			return new ImGuiInputTextCallbackDataPtr(nativePtr);
		}

		public unsafe void ClearSelection()
		{
			ImGuiNative.ImGuiInputTextCallbackData_ClearSelection(NativePtr);
		}

		public unsafe void DeleteChars(int pos, int bytes_count)
		{
			ImGuiNative.ImGuiInputTextCallbackData_DeleteChars(NativePtr, pos, bytes_count);
		}

		public unsafe void Destroy()
		{
			ImGuiNative.ImGuiInputTextCallbackData_destroy(NativePtr);
		}

		public unsafe bool HasSelection()
		{
			return ImGuiNative.ImGuiInputTextCallbackData_HasSelection(NativePtr) != 0;
		}

		public unsafe void InsertChars(int pos, string text)
		{
			int num = 0;
			byte* ptr;
			if (text != null)
			{
				num = Encoding.UTF8.GetByteCount(text);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(text, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte* text_end = null;
			ImGuiNative.ImGuiInputTextCallbackData_InsertChars(NativePtr, pos, ptr, text_end);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe void SelectAll()
		{
			ImGuiNative.ImGuiInputTextCallbackData_SelectAll(NativePtr);
		}
	}
}
