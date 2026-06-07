using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class BorderlessWindow
{
	private struct WinRect
	{
		public int left;

		public int top;

		public int right;

		public int bottom;
	}

	public static bool framed = true;

	private const int GWL_STYLE = -16;

	private const int SW_MINIMIZE = 6;

	private const int SW_MAXIMIZE = 3;

	private const int SW_RESTORE = 9;

	private const uint WS_VISIBLE = 268435456u;

	private const uint WS_POPUP = 2147483648u;

	private const uint WS_BORDER = 8388608u;

	private const uint WS_OVERLAPPED = 0u;

	private const uint WS_CAPTION = 12582912u;

	private const uint WS_SYSMENU = 524288u;

	private const uint WS_THICKFRAME = 262144u;

	private const uint WS_MINIMIZEBOX = 131072u;

	private const uint WS_MAXIMIZEBOX = 65536u;

	private const uint WS_OVERLAPPEDWINDOW = 13565952u;

	[DllImport("user32.dll")]
	private static extern IntPtr GetActiveWindow();

	[DllImport("user32.dll")]
	private static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

	[DllImport("user32.dll")]
	private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);

	[DllImport("user32.dll")]
	private static extern bool MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool bRepaint);

	[DllImport("user32.dll")]
	private static extern bool GetWindowRect(IntPtr hwnd, out WinRect lpRect);

	public static void InitializeOnLoad()
	{
		SetFramelessWindow();
	}

	public static void SetFramelessWindow()
	{
		SetWindowLong(GetActiveWindow(), -16, 2415919104u);
		framed = false;
	}

	public static void SetFramedWindow()
	{
		SetWindowLong(GetActiveWindow(), -16, 282001408u);
		framed = true;
	}

	public static void MinimizeWindow()
	{
		ShowWindow(GetActiveWindow(), 6);
	}

	public static void MaximizeWindow()
	{
		ShowWindow(GetActiveWindow(), 3);
	}

	public static void RestoreWindow()
	{
		ShowWindow(GetActiveWindow(), 9);
	}

	public static void MoveWindowPos(Vector2 posDelta, int newWidth, int newHeight)
	{
		IntPtr activeWindow = GetActiveWindow();
		GetWindowRect(activeWindow, out var lpRect);
		int x = lpRect.left + (int)posDelta.x;
		int y = lpRect.top - (int)posDelta.y;
		MoveWindow(activeWindow, x, y, newWidth, newHeight, bRepaint: false);
	}
}
