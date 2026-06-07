using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class CursorUtils
{
	public struct RECT
	{
		public int Left;

		public int Top;

		public int Right;

		public int Bottom;

		public Vector2 Size => default(Vector2);

		public RECT(int left, int top, int right, int bottom)
		{
			Left = 0;
			Top = 0;
			Right = 0;
			Bottom = 0;
		}
	}

	[PreserveSig]
	private static extern int SetPhysicalCursorPos(int x, int y);

	[PreserveSig]
	private static extern IntPtr GetActiveWindow();

	[PreserveSig]
	private static extern bool GetClientRect(IntPtr hWnd, out RECT rect);

	private static void SetCursorPosition(Vector2Int pixelCoord)
	{
	}

	public static void SetWorldPosition(Vector2 worldPosition)
	{
	}

	public static void SetScreenPosition(Vector2 screenPosition)
	{
	}
}
