using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Cookieverse.CursorPos
{
	public class X11CursorPositionAccessor : ICursorPositionAccessor
	{
		[DllImport("libX11")]
		private static extern IntPtr XOpenDisplay(IntPtr display);

		[DllImport("libX11")]
		private static extern int XCloseDisplay(IntPtr display);

		[DllImport("libX11")]
		private static extern uint XWarpPointer(IntPtr display, IntPtr srcWindow, IntPtr destWindow, int srcX, int srcY, uint srcW, uint srcH, int destX, int destY);

		[DllImport("libX11")]
		private static extern IntPtr XDefaultRootWindow(IntPtr display);

		[DllImport("libX11")]
		private static extern int XFlush(IntPtr display);

		[DllImport("libX11")]
		private static extern bool XQueryPointer(IntPtr display, IntPtr window, out IntPtr root, out IntPtr child, out int globalX, out int globalY, out int windowX, out int windowY, out int buttons);

		public bool IsSupported()
		{
			return false;
		}

		public bool CanConfineToRect()
		{
			return false;
		}

		public void ConfineToRect(Vector2 topLeft, Vector2 bottomRight)
		{
			throw new OsCursorException("Unsupported");
		}

		public void ReleaseConfine()
		{
			throw new OsCursorException("Unsupported");
		}

		public void Set(Vector2 position)
		{
			IntPtr intPtr = XOpenDisplay(IntPtr.Zero);
			if (intPtr == IntPtr.Zero)
			{
				throw new OsCursorException("No X display");
			}
			XWarpPointer(intPtr, IntPtr.Zero, XDefaultRootWindow(intPtr), 0, 0, 0u, 0u, (int)position.x, (int)position.y);
			XFlush(intPtr);
			XCloseDisplay(intPtr);
		}

		public Vector2 Get()
		{
			IntPtr intPtr = XOpenDisplay(IntPtr.Zero);
			if (intPtr == IntPtr.Zero)
			{
				throw new OsCursorException("No X display");
			}
			XQueryPointer(intPtr, XDefaultRootWindow(intPtr), out var _, out var _, out var globalX, out var globalY, out var _, out var _, out var _);
			XCloseDisplay(intPtr);
			return new Vector2(globalX, globalY);
		}
	}
}
