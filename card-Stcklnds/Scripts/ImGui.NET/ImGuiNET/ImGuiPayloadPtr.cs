using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
	public struct ImGuiPayloadPtr
	{
		public unsafe ImGuiPayload* NativePtr { get; }

		public unsafe IntPtr Data
		{
			get
			{
				return (IntPtr)NativePtr->Data;
			}
			set
			{
				NativePtr->Data = (void*)value;
			}
		}

		public unsafe ref int DataSize => ref Unsafe.AsRef<int>(&NativePtr->DataSize);

		public unsafe ref uint SourceId => ref Unsafe.AsRef<uint>(&NativePtr->SourceId);

		public unsafe ref uint SourceParentId => ref Unsafe.AsRef<uint>(&NativePtr->SourceParentId);

		public unsafe ref int DataFrameCount => ref Unsafe.AsRef<int>(&NativePtr->DataFrameCount);

		public unsafe RangeAccessor<byte> DataType => new RangeAccessor<byte>(NativePtr->DataType, 33);

		public unsafe ref bool Preview => ref Unsafe.AsRef<bool>(&NativePtr->Preview);

		public unsafe ref bool Delivery => ref Unsafe.AsRef<bool>(&NativePtr->Delivery);

		public unsafe ImGuiPayloadPtr(ImGuiPayload* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImGuiPayloadPtr(IntPtr nativePtr)
		{
			NativePtr = (ImGuiPayload*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImGuiPayloadPtr(ImGuiPayload* nativePtr)
		{
			return new ImGuiPayloadPtr(nativePtr);
		}

		public unsafe static implicit operator ImGuiPayload*(ImGuiPayloadPtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImGuiPayloadPtr(IntPtr nativePtr)
		{
			return new ImGuiPayloadPtr(nativePtr);
		}

		public unsafe void Clear()
		{
			ImGuiNative.ImGuiPayload_Clear(NativePtr);
		}

		public unsafe void Destroy()
		{
			ImGuiNative.ImGuiPayload_destroy(NativePtr);
		}

		public unsafe bool IsDataType(string type)
		{
			int num = 0;
			byte* ptr;
			if (type != null)
			{
				num = Encoding.UTF8.GetByteCount(type);
				ptr = ((num <= 2048) ? stackalloc byte[(int)(uint)(num + 1)] : Util.Allocate(num + 1));
				int utf = Util.GetUtf8(type, ptr, num);
				ptr[utf] = 0;
			}
			else
			{
				ptr = null;
			}
			byte num2 = ImGuiNative.ImGuiPayload_IsDataType(NativePtr, ptr);
			if (num > 2048)
			{
				Util.Free(ptr);
			}
			return num2 != 0;
		}

		public unsafe bool IsDelivery()
		{
			return ImGuiNative.ImGuiPayload_IsDelivery(NativePtr) != 0;
		}

		public unsafe bool IsPreview()
		{
			return ImGuiNative.ImGuiPayload_IsPreview(NativePtr) != 0;
		}
	}
}
