using System;
using System.Runtime.CompilerServices;

namespace ImGuiNET
{
	public struct ImGuiPlatformIOPtr
	{
		public unsafe ImGuiPlatformIO* NativePtr { get; }

		public unsafe ref IntPtr Platform_CreateWindow => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_CreateWindow);

		public unsafe ref IntPtr Platform_DestroyWindow => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_DestroyWindow);

		public unsafe ref IntPtr Platform_ShowWindow => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_ShowWindow);

		public unsafe ref IntPtr Platform_SetWindowPos => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_SetWindowPos);

		public unsafe ref IntPtr Platform_GetWindowPos => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_GetWindowPos);

		public unsafe ref IntPtr Platform_SetWindowSize => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_SetWindowSize);

		public unsafe ref IntPtr Platform_GetWindowSize => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_GetWindowSize);

		public unsafe ref IntPtr Platform_SetWindowFocus => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_SetWindowFocus);

		public unsafe ref IntPtr Platform_GetWindowFocus => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_GetWindowFocus);

		public unsafe ref IntPtr Platform_GetWindowMinimized => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_GetWindowMinimized);

		public unsafe ref IntPtr Platform_SetWindowTitle => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_SetWindowTitle);

		public unsafe ref IntPtr Platform_SetWindowAlpha => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_SetWindowAlpha);

		public unsafe ref IntPtr Platform_UpdateWindow => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_UpdateWindow);

		public unsafe ref IntPtr Platform_RenderWindow => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_RenderWindow);

		public unsafe ref IntPtr Platform_SwapBuffers => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_SwapBuffers);

		public unsafe ref IntPtr Platform_GetWindowDpiScale => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_GetWindowDpiScale);

		public unsafe ref IntPtr Platform_OnChangedViewport => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_OnChangedViewport);

		public unsafe ref IntPtr Platform_CreateVkSurface => ref Unsafe.AsRef<IntPtr>(&NativePtr->Platform_CreateVkSurface);

		public unsafe ref IntPtr Renderer_CreateWindow => ref Unsafe.AsRef<IntPtr>(&NativePtr->Renderer_CreateWindow);

		public unsafe ref IntPtr Renderer_DestroyWindow => ref Unsafe.AsRef<IntPtr>(&NativePtr->Renderer_DestroyWindow);

		public unsafe ref IntPtr Renderer_SetWindowSize => ref Unsafe.AsRef<IntPtr>(&NativePtr->Renderer_SetWindowSize);

		public unsafe ref IntPtr Renderer_RenderWindow => ref Unsafe.AsRef<IntPtr>(&NativePtr->Renderer_RenderWindow);

		public unsafe ref IntPtr Renderer_SwapBuffers => ref Unsafe.AsRef<IntPtr>(&NativePtr->Renderer_SwapBuffers);

		public unsafe ImPtrVector<ImGuiPlatformMonitorPtr> Monitors => new ImPtrVector<ImGuiPlatformMonitorPtr>(NativePtr->Monitors, Unsafe.SizeOf<ImGuiPlatformMonitor>());

		public unsafe ImVector<ImGuiViewportPtr> Viewports => new ImVector<ImGuiViewportPtr>(NativePtr->Viewports);

		public unsafe ImGuiPlatformIOPtr(ImGuiPlatformIO* nativePtr)
		{
			NativePtr = nativePtr;
		}

		public unsafe ImGuiPlatformIOPtr(IntPtr nativePtr)
		{
			NativePtr = (ImGuiPlatformIO*)(void*)nativePtr;
		}

		public unsafe static implicit operator ImGuiPlatformIOPtr(ImGuiPlatformIO* nativePtr)
		{
			return new ImGuiPlatformIOPtr(nativePtr);
		}

		public unsafe static implicit operator ImGuiPlatformIO*(ImGuiPlatformIOPtr wrappedPtr)
		{
			return wrappedPtr.NativePtr;
		}

		public static implicit operator ImGuiPlatformIOPtr(IntPtr nativePtr)
		{
			return new ImGuiPlatformIOPtr(nativePtr);
		}

		public unsafe void Destroy()
		{
			ImGuiNative.ImGuiPlatformIO_destroy(NativePtr);
		}
	}
}
