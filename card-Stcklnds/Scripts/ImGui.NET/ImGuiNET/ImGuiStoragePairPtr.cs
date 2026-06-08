using System;

namespace ImGuiNET
{
	public struct ImGuiStoragePairPtr
	{
		public unsafe ImGuiStoragePair* NativePtr { get; }

		public unsafe ImGuiStoragePairPtr(ImGuiStoragePair* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImGuiStoragePairPtr(IntPtr nativePtr)
		{
			NativePtr = (ImGuiStoragePair*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImGuiStoragePairPtr(ImGuiStoragePair* nativePtr)
		{
			return new ImGuiStoragePairPtr(nativePtr);
		}

		public unsafe static implicit operator ImGuiStoragePair*(ImGuiStoragePairPtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImGuiStoragePairPtr(IntPtr nativePtr)
		{
			return new ImGuiStoragePairPtr(nativePtr);
		}
	}
}
