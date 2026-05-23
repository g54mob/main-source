using System;
using System.Text;

namespace ImGuiNET
{
	public struct ImGuiTextBufferPtr
	{
		public unsafe ImGuiTextBuffer* NativePtr { get; }

		public unsafe ImVector<byte> Buf => new ImVector<byte>(NativePtr->Buf);

		public unsafe ImGuiTextBufferPtr(ImGuiTextBuffer* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImGuiTextBufferPtr(IntPtr nativePtr)
		{
			NativePtr = (ImGuiTextBuffer*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImGuiTextBufferPtr(ImGuiTextBuffer* nativePtr)
		{
			return new ImGuiTextBufferPtr(nativePtr);
		}

		public unsafe static implicit operator ImGuiTextBuffer*(ImGuiTextBufferPtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImGuiTextBufferPtr(IntPtr nativePtr)
		{
			return new ImGuiTextBufferPtr(nativePtr);
		}

		public unsafe void append(string str)
		{
			int num = 0;
			byte* ptr;
			if (str != null)
			{
				num = Encoding.UTF8.GetByteCount(str);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(str, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte* str_end = null;
			ImGuiNative.ImGuiTextBuffer_append(NativePtr, ptr, str_end);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe void appendf(string fmt)
		{
			int num = 0;
			byte* ptr;
			if (fmt != null)
			{
				num = Encoding.UTF8.GetByteCount(fmt);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(fmt, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			ImGuiNative.ImGuiTextBuffer_appendf(NativePtr, ptr);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
		}

		public unsafe string begin()
		{
			return Util.StringFromPtr(ImGuiNative.ImGuiTextBuffer_begin(NativePtr));
		}

		public unsafe string c_str()
		{
			return Util.StringFromPtr(ImGuiNative.ImGuiTextBuffer_c_str(NativePtr));
		}

		public unsafe void clear()
		{
			ImGuiNative.ImGuiTextBuffer_clear(NativePtr);
		}

		public unsafe void Destroy()
		{
			ImGuiNative.ImGuiTextBuffer_destroy(NativePtr);
		}

		public unsafe bool empty()
		{
			return ImGuiNative.ImGuiTextBuffer_empty(NativePtr) != 0;
		}

		public unsafe string end()
		{
			return Util.StringFromPtr(ImGuiNative.ImGuiTextBuffer_end(NativePtr));
		}

		public unsafe void reserve(int capacity)
		{
			ImGuiNative.ImGuiTextBuffer_reserve(NativePtr, capacity);
		}

		public unsafe int size()
		{
			return ImGuiNative.ImGuiTextBuffer_size(NativePtr);
		}
	}
}
