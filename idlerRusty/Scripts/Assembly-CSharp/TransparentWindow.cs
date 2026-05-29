using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Kirurobo;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Camera))]
public class TransparentWindow : MonoBehaviour
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

	private const int HWND_TOPMOST = -1;

	private const int HWND_NOTOPMOST = -2;

	private const int WM_SYSCOMMAND = 274;

	private const int WM_MOUSE_MOVE = 61458;

	private int fWidth;

	private int fHeight;

	private IntPtr hwnd = IntPtr.Zero;

	private Rectangle margins;

	private Rectangle windowRect;

	public CameraZoomAndMove cameraScript;

	public UniWindowController uniWindowController;

	private List<DisplayChanger.DisplayInfo> myDisplays = new List<DisplayChanger.DisplayInfo>();

	private List<DisplayChanger.MyMonitor> myMonitors = new List<DisplayChanger.MyMonitor>();

	private int monitorNumber;

	[SerializeField]
	private RectTransform corner1;

	[SerializeField]
	private RectTransform corner2;

	[SerializeField]
	private RectTransform corner3;

	[SerializeField]
	private RectTransform corner4;

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

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
	internal static extern void MoveWindow(IntPtr hwnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

	private void OnEnable()
	{
		Main = this;
		GameManager.ins.mainCam.backgroundColor = default(Color);
		GameManager.ins.mainCam.clearFlags = CameraClearFlags.Color;
		GameManager.ins.clearCam.backgroundColor = default(Color);
		if (fullscreen && !customResolution)
		{
			screenResolution = new Vector2Int(Screen.currentResolution.width, Screen.currentResolution.height);
		}
		Screen.SetResolution(screenResolution.x, screenResolution.y, FullScreenMode.FullScreenWindow);
		Application.runInBackground = true;
		fWidth = screenResolution.x;
		fHeight = screenResolution.y;
		margins = new Rectangle
		{
			Left = -1
		};
		hwnd = GetActiveWindow();
		if (GetWindowRect(hwnd, out windowRect))
		{
			Debug.LogError("Couldn't get Window Rect");
		}
		SetWindowLong(hwnd, -16, 2415919104u);
		SetWindowPos(hwnd, SaveData.ins.alwaysOnTop ? (-1) : (-2), windowRect.Left, windowRect.Top, fWidth, fHeight, 96);
		DwmExtendFrameIntoClientArea(hwnd, ref margins);
		GetMonitors();
		StartCoroutine(MoveWindow());
	}

	public void SetAlwaysOnTop(bool alwaysOnTop)
	{
		if (base.enabled)
		{
			StartCoroutine(SetTopmost(alwaysOnTop));
		}
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
		hwnd = GetActiveWindow();
		GetWindowRect(hwnd, out windowRect);
		SaveData.ins.alwaysOnTop = alwaysOnTop;
		SetWindowPos(hwnd, SaveData.ins.alwaysOnTop ? (-1) : (-2), windowRect.Left, windowRect.Top, fWidth, fHeight, 96);
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
			StartCoroutine(MoveWindow());
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
		Screen.SetResolution(screenResolution.x, screenResolution.y, FullScreenMode.Windowed);
		yield return null;
		ResetGameResolutionOnCurrentDisplay();
		yield return null;
		ResetGameResolutionOnCurrentDisplay();
		cameraScript.Restart();
	}

	public void ResetGameResolutionOnCurrentDisplay()
	{
		if (base.enabled)
		{
			int width = myMonitors[monitorNumber].width;
			int height = myMonitors[monitorNumber].height;
			Screen.SetResolution(width, height, FullScreenMode.FullScreenWindow);
		}
	}

	private void Update()
	{
		SetClickThrough();
	}

	private bool FocusForInput()
	{
		return EventSystem.current.IsPointerOverGameObject();
	}

	private void SetClickThrough()
	{
		bool num = FocusForInput();
		GetWindowRect(hwnd, out windowRect);
		if (num)
		{
			SetWindowLong(hwnd, -20, 4294442975u);
			SetLayeredWindowAttributes(hwnd, 0, byte.MaxValue, 2);
			SetWindowPos(hwnd, SaveData.ins.alwaysOnTop ? (-1) : (-2), windowRect.Left, windowRect.Top, fWidth, fHeight, 96);
		}
		else
		{
			SetWindowLong(hwnd, -16, 2415919104u);
			SetWindowLong(hwnd, -20, 524320u);
			SetLayeredWindowAttributes(hwnd, 0, byte.MaxValue, 2);
			SetWindowPos(hwnd, SaveData.ins.alwaysOnTop ? (-1) : (-2), windowRect.Left, windowRect.Top, fWidth, fHeight, 96);
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

	public void CheckCutout()
	{
		Vector3 vector = GameManager.ins.mainCam.WorldToScreenPoint(corner1.position);
		Vector3 vector2 = GameManager.ins.mainCam.WorldToScreenPoint(corner2.position);
		Vector3 vector3 = GameManager.ins.mainCam.WorldToScreenPoint(corner3.position);
		Vector3 vector4 = GameManager.ins.mainCam.WorldToScreenPoint(corner4.position);
		DisplayChangerBackup.POINTSTRUCT[] points = new DisplayChangerBackup.POINTSTRUCT[4]
		{
			new DisplayChangerBackup.POINTSTRUCT((int)vector.x, Screen.currentResolution.height - (int)vector.y),
			new DisplayChangerBackup.POINTSTRUCT((int)vector2.x, Screen.currentResolution.height - (int)vector2.y),
			new DisplayChangerBackup.POINTSTRUCT((int)vector3.x, Screen.currentResolution.height - (int)vector3.y),
			new DisplayChangerBackup.POINTSTRUCT((int)vector4.x, Screen.currentResolution.height - (int)vector4.y)
		};
		hwnd = GetActiveWindow();
		Cut(hwnd, points);
	}

	public static void DragWindow()
	{
		if (Screen.fullScreenMode == FullScreenMode.Windowed)
		{
			ReleaseCapture();
			SendMessage(Main.hwnd, 274, 61458, 0);
			Input.ResetInputAxes();
		}
	}
}
