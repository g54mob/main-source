using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class BootProgram : MonoBehaviour
{
	public delegate bool WNDENUMPROC(IntPtr hwnd, uint lParam);

	private readonly int GWL_EXSTYLE;

	private readonly uint WS_EX_APPWINDOW;

	private readonly int SW_SHOWMAXIMIZED;

	private void Start()
	{
	}

	[PreserveSig]
	private static extern IntPtr SendMessage(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);

	[PreserveSig]
	private static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

	[PreserveSig]
	private static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

	[PreserveSig]
	public static extern bool EnumWindows(WNDENUMPROC lpEnumFunc, uint lParam);

	[PreserveSig]
	public static extern IntPtr GetParent(IntPtr hWnd);

	[PreserveSig]
	public static extern uint GetWindowThreadProcessId(IntPtr hWnd, ref uint lpdwProcessId);

	[PreserveSig]
	public static extern void SetLastError(uint dwErrCode);

	private IntPtr GetProcessWnd()
	{
		return (IntPtr)0;
	}
}
