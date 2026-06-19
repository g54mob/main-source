using System.Runtime.InteropServices;
using UnityEngine;

namespace Cookieverse.CursorPos
{
	public class WinCursorPositionAccessor : ICursorPositionAccessor
	{
		private struct Win32Point
		{
			public int x;

			public int y;

			public Win32Point(Vector2 point)
			{
				x = Mathf.RoundToInt(point.x);
				y = Mathf.RoundToInt(point.y);
			}
		}

		[StructLayout(LayoutKind.Sequential)]
		private class Win32Rect
		{
			public int left;

			public int top;

			public int right;

			public int bottom;

			public Win32Rect(Vector2 topLeft, Vector2 bottomRight)
			{
				left = Mathf.RoundToInt(topLeft.x);
				top = Mathf.RoundToInt(topLeft.y);
				right = Mathf.RoundToInt(bottomRight.x);
				bottom = Mathf.RoundToInt(bottomRight.y);
			}
		}

		[DllImport("user32", EntryPoint = "SetCursorPos")]
		private static extern long Win32Set(int x, int y);

		[DllImport("user32", EntryPoint = "GetCursorPos")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool Win32Get(out Win32Point point);

		[DllImport("user32", EntryPoint = "ClipCursor")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool Win32ClipRect(Win32Rect rect);

		public bool IsSupported()
		{
			return true;
		}

		public bool CanConfineToRect()
		{
			return true;
		}

		public void ConfineToRect(Vector2 topLeft, Vector2 bottomRight)
		{
			if (!Win32ClipRect(new Win32Rect(topLeft, bottomRight)))
			{
				throw new OsCursorException("Could not set the confine rect (or it was already released?)");
			}
		}

		public void ReleaseConfine()
		{
			if (!Win32ClipRect(null))
			{
				throw new OsCursorException("Could not release the confine rect (or it was already released?)");
			}
		}

		public void Set(Vector2 position)
		{
			Win32Set((int)position.x, (int)position.y);
		}

		public Vector2 Get()
		{
			if (Win32Get(out var point))
			{
				return new Vector2(point.x, point.y);
			}
			throw new OsCursorException("Could not get the cursor position");
		}
	}
}
