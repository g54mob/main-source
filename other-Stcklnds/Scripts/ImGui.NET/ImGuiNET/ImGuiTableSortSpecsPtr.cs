using System;
using System.Runtime.CompilerServices;

namespace ImGuiNET
{
	public struct ImGuiTableSortSpecsPtr
	{
		public unsafe ImGuiTableSortSpecs* NativePtr { get; }

		public unsafe ImGuiTableColumnSortSpecsPtr Specs => new ImGuiTableColumnSortSpecsPtr(NativePtr->Specs);

		public unsafe ref int SpecsCount => ref Unsafe.AsRef<int>(&NativePtr->SpecsCount);

		public unsafe ref bool SpecsDirty => ref Unsafe.AsRef<bool>(&NativePtr->SpecsDirty);

		public unsafe ImGuiTableSortSpecsPtr(ImGuiTableSortSpecs* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImGuiTableSortSpecsPtr(IntPtr nativePtr)
		{
			NativePtr = (ImGuiTableSortSpecs*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImGuiTableSortSpecsPtr(ImGuiTableSortSpecs* nativePtr)
		{
			return new ImGuiTableSortSpecsPtr(nativePtr);
		}

		public unsafe static implicit operator ImGuiTableSortSpecs*(ImGuiTableSortSpecsPtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImGuiTableSortSpecsPtr(IntPtr nativePtr)
		{
			return new ImGuiTableSortSpecsPtr(nativePtr);
		}

		public unsafe void Destroy()
		{
			ImGuiNative.ImGuiTableSortSpecs_destroy(NativePtr);
		}
	}
}
