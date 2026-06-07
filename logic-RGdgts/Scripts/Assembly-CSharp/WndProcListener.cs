using System;
using System.Runtime.InteropServices;

public class WndProcListener
{
	private delegate IntPtr WndProcDelegate(IntPtr hwnd, uint message, IntPtr wParam, IntPtr lParam);

	public delegate void OnMessage(uint msg, IntPtr wParam, IntPtr lParam);

	private static IntPtr hwndToIntercept;

	private static IntPtr ptrToMyHandler;

	private static IntPtr ptrToOriginalHandler;

	private static OnMessage onMessage;

	[PreserveSig]
	private static extern IntPtr CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

	[PreserveSig]
	private static extern IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

	public static void Listen(IntPtr _hwndToIntercept, OnMessage _onMessage)
	{
	}

	public static void Restore()
	{
	}

	private static IntPtr CustomWndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
	{
		return (IntPtr)0;
	}
}
