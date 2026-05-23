using System;
using System.Runtime.CompilerServices;

namespace ImGuiNET
{
	public struct ImGuiKeyDataPtr
	{
		public unsafe ImGuiKeyData* NativePtr { get; }

		public unsafe ref bool Down => ref Unsafe.AsRef<bool>(&NativePtr->Down);

		public unsafe ref float DownDuration => ref Unsafe.AsRef<float>(&NativePtr->DownDuration);

		public unsafe ref float DownDurationPrev => ref Unsafe.AsRef<float>(&NativePtr->DownDurationPrev);

		public unsafe ref float AnalogValue => ref Unsafe.AsRef<float>(&NativePtr->AnalogValue);

		public unsafe ImGuiKeyDataPtr(ImGuiKeyData* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImGuiKeyDataPtr(IntPtr nativePtr)
		{
			NativePtr = (ImGuiKeyData*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImGuiKeyDataPtr(ImGuiKeyData* nativePtr)
		{
			return new ImGuiKeyDataPtr(nativePtr);
		}

		public unsafe static implicit operator ImGuiKeyData*(ImGuiKeyDataPtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImGuiKeyDataPtr(IntPtr nativePtr)
		{
			return new ImGuiKeyDataPtr(nativePtr);
		}
	}
}
