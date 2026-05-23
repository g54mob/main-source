using System;
using System.Runtime.CompilerServices;

namespace ImGuiNET
{
	public struct ImGuiStoragePtr
	{
		public unsafe ImGuiStorage* NativePtr { get; }

		public unsafe ImPtrVector<ImGuiStoragePairPtr> Data => new ImPtrVector<ImGuiStoragePairPtr>(NativePtr->Data, Unsafe.SizeOf<ImGuiStoragePair>());

		public unsafe ImGuiStoragePtr(ImGuiStorage* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImGuiStoragePtr(IntPtr nativePtr)
		{
			NativePtr = (ImGuiStorage*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImGuiStoragePtr(ImGuiStorage* nativePtr)
		{
			return new ImGuiStoragePtr(nativePtr);
		}

		public unsafe static implicit operator ImGuiStorage*(ImGuiStoragePtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImGuiStoragePtr(IntPtr nativePtr)
		{
			return new ImGuiStoragePtr(nativePtr);
		}

		public unsafe void BuildSortByKey()
		{
			ImGuiNative.ImGuiStorage_BuildSortByKey(NativePtr);
		}

		public unsafe void Clear()
		{
			ImGuiNative.ImGuiStorage_Clear(NativePtr);
		}

		public unsafe bool GetBool(uint key)
		{
			byte default_val = 0;
			return ImGuiNative.ImGuiStorage_GetBool(NativePtr, key, default_val) != 0;
		}

		public unsafe bool GetBool(uint key, bool default_val)
		{
			byte default_val2 = (byte)(default_val ? 1 : 0);
			return ImGuiNative.ImGuiStorage_GetBool(NativePtr, key, default_val2) != 0;
		}

		public unsafe byte* GetBoolRef(uint key)
		{
			byte default_val = 0;
			return ImGuiNative.ImGuiStorage_GetBoolRef(NativePtr, key, default_val);
		}

		public unsafe byte* GetBoolRef(uint key, bool default_val)
		{
			byte default_val2 = (byte)(default_val ? 1 : 0);
			return ImGuiNative.ImGuiStorage_GetBoolRef(NativePtr, key, default_val2);
		}

		public unsafe float GetFloat(uint key)
		{
			float default_val = 0f;
			return ImGuiNative.ImGuiStorage_GetFloat(NativePtr, key, default_val);
		}

		public unsafe float GetFloat(uint key, float default_val)
		{
			return ImGuiNative.ImGuiStorage_GetFloat(NativePtr, key, default_val);
		}

		public unsafe float* GetFloatRef(uint key)
		{
			float default_val = 0f;
			return ImGuiNative.ImGuiStorage_GetFloatRef(NativePtr, key, default_val);
		}

		public unsafe float* GetFloatRef(uint key, float default_val)
		{
			return ImGuiNative.ImGuiStorage_GetFloatRef(NativePtr, key, default_val);
		}

		public unsafe int GetInt(uint key)
		{
			int default_val = 0;
			return ImGuiNative.ImGuiStorage_GetInt(NativePtr, key, default_val);
		}

		public unsafe int GetInt(uint key, int default_val)
		{
			return ImGuiNative.ImGuiStorage_GetInt(NativePtr, key, default_val);
		}

		public unsafe int* GetIntRef(uint key)
		{
			int default_val = 0;
			return ImGuiNative.ImGuiStorage_GetIntRef(NativePtr, key, default_val);
		}

		public unsafe int* GetIntRef(uint key, int default_val)
		{
			return ImGuiNative.ImGuiStorage_GetIntRef(NativePtr, key, default_val);
		}

		public unsafe IntPtr GetVoidPtr(uint key)
		{
			return (IntPtr)ImGuiNative.ImGuiStorage_GetVoidPtr(NativePtr, key);
		}

		public unsafe void** GetVoidPtrRef(uint key)
		{
			void* default_val = null;
			return ImGuiNative.ImGuiStorage_GetVoidPtrRef(NativePtr, key, default_val);
		}

		public unsafe void** GetVoidPtrRef(uint key, IntPtr default_val)
		{
			void* default_val2 = default_val.ToPointer();
			return ImGuiNative.ImGuiStorage_GetVoidPtrRef(NativePtr, key, default_val2);
		}

		public unsafe void SetAllInt(int val)
		{
			ImGuiNative.ImGuiStorage_SetAllInt(NativePtr, val);
		}

		public unsafe void SetBool(uint key, bool val)
		{
			byte val2 = (byte)(val ? 1 : 0);
			ImGuiNative.ImGuiStorage_SetBool(NativePtr, key, val2);
		}

		public unsafe void SetFloat(uint key, float val)
		{
			ImGuiNative.ImGuiStorage_SetFloat(NativePtr, key, val);
		}

		public unsafe void SetInt(uint key, int val)
		{
			ImGuiNative.ImGuiStorage_SetInt(NativePtr, key, val);
		}

		public unsafe void SetVoidPtr(uint key, IntPtr val)
		{
			void* val2 = val.ToPointer();
			ImGuiNative.ImGuiStorage_SetVoidPtr(NativePtr, key, val2);
		}
	}
}
