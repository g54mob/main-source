using System;

namespace ImGuiNET
{
	public struct ImGuiTextRangePtr
	{
		public unsafe ImGuiTextRange* NativePtr { get; }

		public unsafe IntPtr b
		{
			get
			{
				return (IntPtr)NativePtr->b;
			}
			set
			{
				NativePtr->b = (byte*)(void*)value;
			}
		}

		public unsafe IntPtr e
		{
			get
			{
				return (IntPtr)NativePtr->e;
			}
			set
			{
				NativePtr->e = (byte*)(void*)value;
			}
		}

		public unsafe ImGuiTextRangePtr(ImGuiTextRange* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImGuiTextRangePtr(IntPtr nativePtr)
		{
			NativePtr = (ImGuiTextRange*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImGuiTextRangePtr(ImGuiTextRange* nativePtr)
		{
			return new ImGuiTextRangePtr(nativePtr);
		}

		public unsafe static implicit operator ImGuiTextRange*(ImGuiTextRangePtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImGuiTextRangePtr(IntPtr nativePtr)
		{
			return new ImGuiTextRangePtr(nativePtr);
		}

		public unsafe void Destroy()
		{
			ImGuiNative.ImGuiTextRange_destroy(NativePtr);
		}

		public unsafe bool empty()
		{
			return ImGuiNative.ImGuiTextRange_empty(NativePtr) != 0;
		}

		public unsafe void split(byte separator, out ImVector @out)
		{
			fixed (ImVector* ptr = &@out)
			{
				ImGuiNative.ImGuiTextRange_split(NativePtr, separator, ptr);
			}
		}
	}
}
