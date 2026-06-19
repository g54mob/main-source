using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace UnityCursorControl
{
	internal class CursorControlWindows : ICursorControl
	{
		private struct Point
		{
			public int X;

			public int Y;
		}

		[Flags]
		private enum MouseEventFlags
		{
			MOUSEEVENTF_ABSOLUTE = 0x8000,
			MOUSEEVENTF_LEFTDOWN = 2,
			MOUSEEVENTF_LEFTUP = 4,
			MOUSEEVENTF_MIDDLEDOWN = 0x20,
			MOUSEEVENTF_MIDDLEUP = 0x40,
			MOUSEEVENTF_MOVE = 1,
			MOUSEEVENTF_RIGHTDOWN = 8,
			MOUSEEVENTF_RIGHTUP = 0x10,
			MOUSEEVENTF_XDOWN = 0x80,
			MOUSEEVENTF_XUP = 0x100,
			MOUSEEVENTF_WHEEL = 0x800,
			MOUSEEVENTF_HWHEEL = 0x1000
		}

		[DllImport("user32.dll")]
		private static extern bool SetCursorPos(int X, int Y);

		[DllImport("user32.dll")]
		private static extern bool GetCursorPos(out Point pos);

		[DllImport("user32.dll")]
		private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

		private Vector2 LocalToGlobal(Vector2 pos)
		{
			Vector2 vector = Input.mousePosition;
			Vector2 globalCursorPos = GetGlobalCursorPos();
			int num = (int)globalCursorPos.x - (int)vector.x;
			vector.y = (float)Screen.height - vector.y;
			int num2 = (int)globalCursorPos.y - (int)vector.y;
			return new Vector2(pos.x + (float)num, (float)Screen.height - pos.y + (float)num2);
		}

		public Vector2 GetGlobalCursorPos()
		{
			GetCursorPos(out var pos);
			return new Vector2(pos.X, pos.Y);
		}

		public void SetGlobalCursorPos(Vector2 pos)
		{
			SetCursorPos((int)pos.x, (int)pos.y);
		}

		public void SetLocalCursorPos(Vector2 pos)
		{
			pos = LocalToGlobal(pos);
			SetCursorPos((int)pos.x, (int)pos.y);
		}

		public void SimulateLeftClick()
		{
			mouse_event(2u, (uint)GetGlobalCursorPos().x, (uint)GetGlobalCursorPos().y, 0u, UIntPtr.Zero);
			mouse_event(4u, (uint)GetGlobalCursorPos().x, (uint)GetGlobalCursorPos().y, 0u, UIntPtr.Zero);
		}

		public void SimulateMiddleClick()
		{
			mouse_event(32u, (uint)GetGlobalCursorPos().x, (uint)GetGlobalCursorPos().y, 0u, UIntPtr.Zero);
			mouse_event(64u, (uint)GetGlobalCursorPos().x, (uint)GetGlobalCursorPos().y, 0u, UIntPtr.Zero);
		}

		public void SimulateRightClick()
		{
			mouse_event(8u, (uint)GetGlobalCursorPos().x, (uint)GetGlobalCursorPos().y, 0u, UIntPtr.Zero);
			mouse_event(16u, (uint)GetGlobalCursorPos().x, (uint)GetGlobalCursorPos().y, 0u, UIntPtr.Zero);
		}
	}
}
