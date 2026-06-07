using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using ImGuiNET;

namespace UImGui
{
	internal static class ImGuiExtension
	{
		private static readonly HashSet<IntPtr> _managedAllocations = new HashSet<IntPtr>();

		internal unsafe static void SetBackendPlatformName(this ImGuiIOPtr io, string name)
		{
			if (io.NativePtr->BackendPlatformName != null)
			{
				if (_managedAllocations.Contains((IntPtr)io.NativePtr->BackendPlatformName))
				{
					Marshal.FreeHGlobal(new IntPtr(io.NativePtr->BackendPlatformName));
				}
				io.NativePtr->BackendPlatformName = null;
			}
			if (name != null)
			{
				int byteCount = Encoding.UTF8.GetByteCount(name);
				byte* ptr = (byte*)(void*)Marshal.AllocHGlobal(byteCount + 1);
				int utf = Utils.GetUtf8(name, ptr, byteCount);
				ptr[utf] = 0;
				io.NativePtr->BackendPlatformName = ptr;
				_managedAllocations.Add((IntPtr)ptr);
			}
		}

		internal unsafe static void SetIniFilename(this ImGuiIOPtr io, string name)
		{
			if (io.NativePtr->IniFilename != null)
			{
				if (_managedAllocations.Contains((IntPtr)io.NativePtr->IniFilename))
				{
					Marshal.FreeHGlobal((IntPtr)io.NativePtr->IniFilename);
				}
				io.NativePtr->IniFilename = null;
			}
			if (name != null)
			{
				int byteCount = Encoding.UTF8.GetByteCount(name);
				byte* ptr = (byte*)(void*)Marshal.AllocHGlobal(byteCount + 1);
				int utf = Utils.GetUtf8(name, ptr, byteCount);
				ptr[utf] = 0;
				io.NativePtr->IniFilename = ptr;
				_managedAllocations.Add((IntPtr)ptr);
			}
		}

		public unsafe static void SetBackendRendererName(this ImGuiIOPtr io, string name)
		{
			if (io.NativePtr->BackendRendererName != null && _managedAllocations.Contains((IntPtr)io.NativePtr->BackendRendererName))
			{
				Marshal.FreeHGlobal((IntPtr)io.NativePtr->BackendRendererName);
				io.NativePtr->BackendRendererName = null;
			}
			if (name != null)
			{
				int byteCount = Encoding.UTF8.GetByteCount(name);
				byte* ptr = (byte*)(void*)Marshal.AllocHGlobal(byteCount + 1);
				int utf = Utils.GetUtf8(name, ptr, byteCount);
				ptr[utf] = 0;
				io.NativePtr->BackendRendererName = ptr;
				_managedAllocations.Add((IntPtr)ptr);
			}
		}
	}
}
