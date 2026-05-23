using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ImGuiNET
{
	public struct ImGuiPlatformMonitorPtr
	{
		public unsafe ImGuiPlatformMonitor* NativePtr { get; }

		public unsafe ref Vector2 MainPos => ref Unsafe.AsRef<Vector2>(&NativePtr->MainPos);

		public unsafe ref Vector2 MainSize => ref Unsafe.AsRef<Vector2>(&NativePtr->MainSize);

		public unsafe ref Vector2 WorkPos => ref Unsafe.AsRef<Vector2>(&NativePtr->WorkPos);

		public unsafe ref Vector2 WorkSize => ref Unsafe.AsRef<Vector2>(&NativePtr->WorkSize);

		public unsafe ref float DpiScale => ref Unsafe.AsRef<float>(&NativePtr->DpiScale);

		public unsafe ImGuiPlatformMonitorPtr(ImGuiPlatformMonitor* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImGuiPlatformMonitorPtr(IntPtr nativePtr)
		{
			NativePtr = (ImGuiPlatformMonitor*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImGuiPlatformMonitorPtr(ImGuiPlatformMonitor* nativePtr)
		{
			return new ImGuiPlatformMonitorPtr(nativePtr);
		}

		public unsafe static implicit operator ImGuiPlatformMonitor*(ImGuiPlatformMonitorPtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImGuiPlatformMonitorPtr(IntPtr nativePtr)
		{
			return new ImGuiPlatformMonitorPtr(nativePtr);
		}

		public unsafe void Destroy()
		{
			ImGuiNative.ImGuiPlatformMonitor_destroy(NativePtr);
		}
	}
}
