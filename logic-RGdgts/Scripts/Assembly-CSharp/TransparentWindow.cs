using System;
using System.Runtime.InteropServices;
using Steamworks;
using UnityEngine;

public class TransparentWindow : MonoBehaviour
{
	private struct MARGINS
	{
		public int cxLeftWidth;

		public int cxRightWidth;

		public int cyTopHeight;

		public int cyBottomHeight;
	}

	private const int GWL_EXSTYLE = -20;

	private const uint WS_EX_LAYERED = 524288u;

	private const uint WS_EX_TRANSPARENT = 32u;

	private static readonly IntPtr HWND_TOPMOST;

	private static readonly IntPtr HWND_NOT_TOPMOST;

	private const uint SWP_NOMOVE = 2u;

	private const uint SWP_NOSIZE = 1u;

	private const uint LWA_COLORKEY = 1u;

	private IntPtr hWnd;

	private bool isTransparent;

	private Callback<GameOverlayActivated_t> _steamOverlayActivated;

	private bool wasClicktrough;

	[PreserveSig]
	private static extern bool SetForegroundWindow(IntPtr hWnd);

	[PreserveSig]
	public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

	private static IntPtr GetWindowHandle()
	{
		return (IntPtr)0;
	}

	[PreserveSig]
	private static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

	[PreserveSig]
	private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

	[PreserveSig]
	private static extern bool SetWindowText(IntPtr hwnd, string lpString);

	[PreserveSig]
	private static extern int SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

	[PreserveSig]
	private static extern uint DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS margins);

	public void SetTransparent()
	{
	}

	public void SetWindowText(string text)
	{
	}

	private void Start()
	{
	}

	private void OnSteamOverlayActivated(GameOverlayActivated_t pCallback)
	{
	}

	public void SetDefault()
	{
	}

	public static void SetMonitorIndex(int newMonitorIndex)
	{
	}

	private void Update()
	{
	}

	private void SetClickthrough(bool clickthrough)
	{
	}

	public static Vector3 GetMouseWorldPosition()
	{
		return default(Vector3);
	}

	public static Vector3 GetMouseWorldPositionWithZ()
	{
		return default(Vector3);
	}

	public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
	{
		return default(Vector3);
	}

	public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
	{
		return default(Vector3);
	}
}
