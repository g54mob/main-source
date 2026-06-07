using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Kirurobo;
using UnityEngine;

public class PlainWindow : MonoBehaviour
{
	private delegate bool MonitorEnumDelegate(IntPtr hMonitor, IntPtr hdcMonitor, ref Rectangle lprcMonitor, IntPtr dwData);

	public struct Rectangle
	{
		public int Left;

		public int Top;

		public int Right;

		public int Bottom;
	}

	public static TransparentWindow Main;

	[Tooltip("What GameObject layers should trigger window focus when the mouse passes over objects?")]
	[SerializeField]
	private LayerMask clickLayerMask = -1;

	[Tooltip("Allows Input to be detected even when focus is lost")]
	[SerializeField]
	private bool useSystemInput;

	[Tooltip("Should the window be fullscreen?")]
	[SerializeField]
	private bool fullscreen = true;

	[Tooltip("Force the window to match ScreenResolution")]
	[SerializeField]
	private bool customResolution = true;

	[Tooltip("Resolution the overlay should run at")]
	[SerializeField]
	private Vector2Int screenResolution = new Vector2Int(1280, 720);

	private const int GWL_STYLE = -16;

	private const uint WS_POPUP = 2147483648u;

	private const uint WS_VISIBLE = 268435456u;

	private const int SW_RESTORE = 9;

	private const int HWND_TOPMOST = -1;

	private const int HWND_NOTOPMOST = -2;

	private const int WM_SYSCOMMAND = 274;

	private const int WM_MOUSE_MOVE = 61458;

	private const int SW_MINIMIZE = 6;

	private const int SW_MAXIMIZE = 3;

	private const uint WS_BORDER = 8388608u;

	private const uint WS_OVERLAPPED = 0u;

	private const uint WS_CAPTION = 12582912u;

	private const uint WS_SYSMENU = 524288u;

	private const uint WS_THICKFRAME = 262144u;

	private const uint WS_MINIMIZEBOX = 131072u;

	private const uint WS_MAXIMIZEBOX = 65536u;

	private const uint WS_OVERLAPPEDWINDOW = 13565952u;

	private int fWidth;

	private int fHeight;

	private IntPtr hwnd = IntPtr.Zero;

	private Rectangle margins;

	private Rectangle windowRect;

	public CameraZoomAndMove cameraScript;

	public UniWindowController uniWindowController;

	public static bool framed;

	private const int heightSize = 334;

	private const int widthSize = 504;

	public RectTransform stickyCanvas;

	public static PlainWindow Instance;

	public GameObject blackBars;

	private List<DisplayChanger.DisplayInfo> myDisplays = new List<DisplayChanger.DisplayInfo>();

	private List<DisplayChanger.MyMonitor> myMonitors = new List<DisplayChanger.MyMonitor>();

	private int monitorNumber;

	[DllImport("user32.dll")]
	private static extern IntPtr GetActiveWindow();

	[DllImport("user32.dll")]
	private static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

	[DllImport("user32.dll")]
	private static extern int SetLayeredWindowAttributes(IntPtr hwnd, int crKey, byte bAlpha, int dwFlags);

	[DllImport("user32.dll")]
	private static extern bool GetWindowRect(IntPtr hwnd, out Rectangle rect);

	[DllImport("user32.dll")]
	private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

	[DllImport("user32.dll")]
	private static extern bool ReleaseCapture();

	[DllImport("user32.dll")]
	private static extern int SetWindowPos(IntPtr hwnd, int hwndInsertAfter, int x, int y, int cx, int cy, int uFlags);

	[DllImport("user32.dll")]
	private static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, MonitorEnumDelegate lpfnEnum, IntPtr dwData);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern bool GetMonitorInfo(IntPtr hmonitor, [In][Out] DisplayChanger.MONITORINFOEX info);

	[DllImport("Dwmapi.dll")]
	private static extern uint DwmExtendFrameIntoClientArea(IntPtr hWnd, ref Rectangle margins);

	[DllImport("user32.dll")]
	private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
	internal static extern void MoveWindow(IntPtr hwnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

	private void OnEnable()
	{
		Instance = this;
		GetMonitors();
		blackBars.SetActive(value: false);
		StartCoroutine(EnableDelay());
	}

	public static void MinimizeWindow()
	{
		GetActiveWindow();
	}

	public static void MaximizeWindow()
	{
		ShowWindow(GetActiveWindow(), 3);
	}

	public void SetFramelessWindow(int width, int height, int x = 0, int y = 0)
	{
		SetWindowLong(GetActiveWindow(), -16, 2415919104u);
		MoveWindowPos(new Vector2Int(x, y), width, height);
	}

	public void SetZoom()
	{
		MoveWindowPos(new Vector2Int(myMonitors[monitorNumber].targetX, myMonitors[monitorNumber].targetY), SaveData.ins.verticalMode ? Mathf.RoundToInt(504f * ((float)Instance.cameraScript.scale / 2f)) : myMonitors[monitorNumber].width, SaveData.ins.verticalMode ? myMonitors[monitorNumber].height : Mathf.RoundToInt(334f * ((float)Instance.cameraScript.scale / 2f)));
	}

	public static void SetFramedWindow()
	{
		SetWindowLong(GetActiveWindow(), -16, 282001408u);
		framed = true;
	}

	public static void RestoreWindow()
	{
		ShowWindow(GetActiveWindow(), 9);
	}

	private IEnumerator EnableDelay()
	{
		yield return null;
		yield return null;
		RestoreWindow();
		if (!SaveData.ins.verticalMode)
		{
			screenResolution = new Vector2Int(myMonitors[monitorNumber].width, 334 * (Instance.cameraScript.scale / 2));
		}
		else
		{
			screenResolution = new Vector2Int(504, myMonitors[monitorNumber].height);
		}
		Screen.SetResolution(screenResolution.x, screenResolution.y, FullScreenMode.Windowed);
		Application.runInBackground = true;
		yield return null;
		SetFramelessWindow(screenResolution.x, screenResolution.y);
		yield return null;
		cameraScript.Restart();
		cameraScript.UpdateCameraPosition(0);
		yield return null;
		yield return null;
		cameraScript.Restart();
		cameraScript.UpdateCameraPosition(0);
		yield return null;
		cameraScript.UpdateCameraPosition(0);
		yield return null;
	}

	public void SetAlwaysOnTop(bool alwaysOnTop)
	{
		if (base.enabled)
		{
			StartCoroutine(SetTopmost(alwaysOnTop));
		}
	}

	public void MoveWindowPos(Vector2Int posDelta, int newWidth, int newHeight)
	{
		IntPtr activeWindow = GetActiveWindow();
		int x = (SaveData.ins.verticalMode ? (posDelta.x + myMonitors[monitorNumber].width - newWidth) : posDelta.x) - SaveData.ins.sidebarWidth;
		int y = (SaveData.ins.verticalMode ? posDelta.y : (posDelta.y + myMonitors[monitorNumber].height - newHeight)) - SaveData.ins.taskbarHeight;
		MoveWindow(activeWindow, x, y, newWidth, newHeight, bRepaint: false);
		SetWindowPos(activeWindow, SaveData.ins.alwaysOnTop ? (-1) : (-2), x, y, newWidth, newHeight, 96);
	}

	private void GetMonitors()
	{
		myDisplays = GetDisplays();
		for (int i = 0; i < myDisplays.Count; i++)
		{
			myMonitors.Add(new DisplayChanger.MyMonitor(myDisplays[i].WorkArea.left, myDisplays[i].WorkArea.top, i, Convert.ToInt32(myDisplays[i].ScreenHeight), Convert.ToInt32(myDisplays[i].ScreenWidth)));
		}
	}

	public DisplayChanger.DisplayInfoCollection GetDisplays()
	{
		DisplayChanger.DisplayInfoCollection col = new DisplayChanger.DisplayInfoCollection();
		EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, delegate(IntPtr hMonitor, IntPtr hdcMonitor, ref Rectangle lprcMonitor, IntPtr dwData)
		{
			DisplayChanger.MONITORINFOEX mONITORINFOEX = new DisplayChanger.MONITORINFOEX();
			mONITORINFOEX.cbSize = Marshal.SizeOf(mONITORINFOEX);
			if (GetMonitorInfo(hMonitor, mONITORINFOEX))
			{
				DisplayChanger.DisplayInfo item = new DisplayChanger.DisplayInfo
				{
					ScreenWidth = (mONITORINFOEX.rcMonitor.right - mONITORINFOEX.rcMonitor.left).ToString(),
					ScreenHeight = (mONITORINFOEX.rcMonitor.bottom - mONITORINFOEX.rcMonitor.top).ToString(),
					MonitorArea = mONITORINFOEX.rcMonitor,
					WorkArea = mONITORINFOEX.rcWork,
					Availability = mONITORINFOEX.dwFlags.ToString()
				};
				col.Add(item);
			}
			return true;
		}, IntPtr.Zero);
		return col;
	}

	private IEnumerator SetTopmost(bool alwaysOnTop)
	{
		SaveData.ins.alwaysOnTop = alwaysOnTop;
		StartCoroutine(EnableDelay());
		yield return null;
	}

	public void ChangeDisplayClicked()
	{
		if (base.enabled)
		{
			monitorNumber++;
			if (monitorNumber >= myDisplays.Count)
			{
				monitorNumber = 0;
			}
			StartCoroutine(EnableDelay());
		}
	}

	private IEnumerator MoveWindow()
	{
		Rectangle rect = default(Rectangle);
		IntPtr activeWindow = GetActiveWindow();
		GetWindowRect(activeWindow, out rect);
		int targetX = myMonitors[monitorNumber].targetX;
		int targetY = myMonitors[monitorNumber].targetY;
		int width = myMonitors[monitorNumber].width;
		int height = myMonitors[monitorNumber].height;
		MoveWindow(activeWindow, targetX, targetY, width, height, bRepaint: true);
		yield return null;
		cameraScript.Restart();
	}

	public void ResetGameResolutionOnCurrentDisplay()
	{
		if (base.enabled)
		{
			StartCoroutine(EnableDelay());
		}
	}

	[DllImport("user32.dll")]
	public static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);

	[DllImport("gdi32.dll")]
	public static extern IntPtr CreatePolygonRgn(DisplayChangerBackup.POINTSTRUCT[] lpPoint, int nCount, int nPolyFillMode);

	[DllImport("gdi32.dll", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeleteObject(IntPtr hObject);

	public static void Cut(nint hwnd, DisplayChangerBackup.POINTSTRUCT[] points)
	{
		IntPtr intPtr = CreatePolygonRgn(points, points.Length, 2);
		SetWindowRgn(hwnd, intPtr, bRedraw: true);
		DeleteObject(intPtr);
	}
}
