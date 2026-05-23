using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
	public struct ImGuiTextFilterPtr
	{
		public unsafe ImGuiTextFilter* NativePtr { get; }

		public unsafe RangeAccessor<byte> InputBuf => new RangeAccessor<byte>(NativePtr->InputBuf, 256);

		public unsafe ImPtrVector<ImGuiTextRangePtr> Filters => new ImPtrVector<ImGuiTextRangePtr>(NativePtr->Filters, Unsafe.SizeOf<ImGuiTextRange>());

		public unsafe ref int CountGrep => ref Unsafe.AsRef<int>(&NativePtr->CountGrep);

		public unsafe ImGuiTextFilterPtr(ImGuiTextFilter* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImGuiTextFilterPtr(IntPtr nativePtr)
		{
			NativePtr = (ImGuiTextFilter*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImGuiTextFilterPtr(ImGuiTextFilter* nativePtr)
		{
			return new ImGuiTextFilterPtr(nativePtr);
		}

		public unsafe static implicit operator ImGuiTextFilter*(ImGuiTextFilterPtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImGuiTextFilterPtr(IntPtr nativePtr)
		{
			return new ImGuiTextFilterPtr(nativePtr);
		}

		public unsafe void Build()
		{
			ImGuiNative.ImGuiTextFilter_Build(NativePtr);
		}

		public unsafe void Clear()
		{
			ImGuiNative.ImGuiTextFilter_Clear(NativePtr);
		}

		public unsafe void Destroy()
		{
			ImGuiNative.ImGuiTextFilter_destroy(NativePtr);
		}

		public unsafe bool Draw()
		{
			int num = 0;
			num = Encoding.UTF8.GetByteCount("Filter(inc,-exc)");
			byte* ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
			int utf = Util.GetUtf8("Filter(inc,-exc)", ptr, num);
			ptr[utf] = 0;
			float width = 0f;
			byte num2 = ImGuiNative.ImGuiTextFilter_Draw(NativePtr, ptr, width);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe bool Draw(string label)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			float width = 0f;
			byte num2 = ImGuiNative.ImGuiTextFilter_Draw(NativePtr, ptr, width);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe bool Draw(string label, float width)
		{
			int num = 0;
			byte* ptr;
			if (label != null)
			{
				num = Encoding.UTF8.GetByteCount(label);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(label, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte num2 = ImGuiNative.ImGuiTextFilter_Draw(NativePtr, ptr, width);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe bool IsActive()
		{
			return ImGuiNative.ImGuiTextFilter_IsActive(NativePtr) != 0;
		}

		public unsafe bool PassFilter(string text)
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
			byte num2 = ImGuiNative.ImGuiTextFilter_PassFilter(NativePtr, ptr, text_end);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}
	}
}
