using System;
using System.Runtime.CompilerServices;

namespace ImGuiNET
{
	public struct ImGuiWindowClassPtr
	{
		public unsafe ImGuiWindowClass* NativePtr { get; }

		public unsafe ref uint ClassId => ref Unsafe.AsRef<uint>(&NativePtr->ClassId);

		public unsafe ref uint ParentViewportId => ref Unsafe.AsRef<uint>(&NativePtr->ParentViewportId);

		public unsafe ref ImGuiViewportFlags ViewportFlagsOverrideSet => ref Unsafe.AsRef<ImGuiViewportFlags>(&NativePtr->ViewportFlagsOverrideSet);

		public unsafe ref ImGuiViewportFlags ViewportFlagsOverrideClear => ref Unsafe.AsRef<ImGuiViewportFlags>(&NativePtr->ViewportFlagsOverrideClear);

		public unsafe ref ImGuiTabItemFlags TabItemFlagsOverrideSet => ref Unsafe.AsRef<ImGuiTabItemFlags>(&NativePtr->TabItemFlagsOverrideSet);

		public unsafe ref ImGuiDockNodeFlags DockNodeFlagsOverrideSet => ref Unsafe.AsRef<ImGuiDockNodeFlags>(&NativePtr->DockNodeFlagsOverrideSet);

		public unsafe ref bool DockingAlwaysTabBar => ref Unsafe.AsRef<bool>(&NativePtr->DockingAlwaysTabBar);

		public unsafe ref bool DockingAllowUnclassed => ref Unsafe.AsRef<bool>(&NativePtr->DockingAllowUnclassed);

		public unsafe ImGuiWindowClassPtr(ImGuiWindowClass* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImGuiWindowClassPtr(IntPtr nativePtr)
		{
			NativePtr = (ImGuiWindowClass*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImGuiWindowClassPtr(ImGuiWindowClass* nativePtr)
		{
			return new ImGuiWindowClassPtr(nativePtr);
		}

		public unsafe static implicit operator ImGuiWindowClass*(ImGuiWindowClassPtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImGuiWindowClassPtr(IntPtr nativePtr)
		{
			return new ImGuiWindowClassPtr(nativePtr);
		}

		public unsafe void Destroy()
		{
			ImGuiNative.ImGuiWindowClass_destroy(NativePtr);
		}
	}
}
