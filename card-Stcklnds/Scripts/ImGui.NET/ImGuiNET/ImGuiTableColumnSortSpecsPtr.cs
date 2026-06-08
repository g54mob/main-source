using System;
using System.Runtime.CompilerServices;

namespace ImGuiNET
{
	public struct ImGuiTableColumnSortSpecsPtr
	{
		public unsafe ImGuiTableColumnSortSpecs* NativePtr { get; }

		public unsafe ref uint ColumnUserID => ref Unsafe.AsRef<uint>(&NativePtr->ColumnUserID);

		public unsafe ref short ColumnIndex => ref Unsafe.AsRef<short>(&NativePtr->ColumnIndex);

		public unsafe ref short SortOrder => ref Unsafe.AsRef<short>(&NativePtr->SortOrder);

		public unsafe ref ImGuiSortDirection SortDirection => ref Unsafe.AsRef<ImGuiSortDirection>(&NativePtr->SortDirection);

		public unsafe ImGuiTableColumnSortSpecsPtr(ImGuiTableColumnSortSpecs* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImGuiTableColumnSortSpecsPtr(IntPtr nativePtr)
		{
			NativePtr = (ImGuiTableColumnSortSpecs*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImGuiTableColumnSortSpecsPtr(ImGuiTableColumnSortSpecs* nativePtr)
		{
			return new ImGuiTableColumnSortSpecsPtr(nativePtr);
		}

		public unsafe static implicit operator ImGuiTableColumnSortSpecs*(ImGuiTableColumnSortSpecsPtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImGuiTableColumnSortSpecsPtr(IntPtr nativePtr)
		{
			return new ImGuiTableColumnSortSpecsPtr(nativePtr);
		}

		public unsafe void Destroy()
		{
			ImGuiNative.ImGuiTableColumnSortSpecs_destroy(NativePtr);
		}
	}
}
