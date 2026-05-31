using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Kirurobo;
using UnityEngine;
using UnityEngine.UI;

public class DisplayChangerBackup : MonoBehaviour
{
	private delegate bool MonitorEnumDelegate(IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, IntPtr dwData);

	public struct RECT
	{
		public int left;

		public int top;

		public int right;

		public int bottom;
	}

	public class DisplayInfo
	{
		public string Availability { get; set; }

		public string ScreenHeight { get; set; }

		public string ScreenWidth { get; set; }

		public RECT MonitorArea { get; set; }

		public RECT WorkArea { get; set; }
	}

	public class DisplayInfoCollection : List<DisplayInfo>
	{
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
	public class MONITORINFOEX
	{
		public int cbSize = Marshal.SizeOf(typeof(MONITORINFOEX));

		public RECT rcMonitor;

		public RECT rcWork;

		public int dwFlags;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		public char[] szDevice = new char[32];
	}

	public struct POINTSTRUCT
	{
		public int x;

		public int y;

		public POINTSTRUCT(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}

	public class MyMonitor
	{
		public int targetX;

		public int targetY;

		public int monitorNumber;

		public int height;

		public int width;

		public MyMonitor(int targetX, int targetY, int monitorNumber, int height, int width)
		{
			this.targetX = targetX;
			this.targetY = targetY;
			this.monitorNumber = monitorNumber;
			this.height = height;
			this.width = width;
		}
	}

	public struct MARGINS
	{
		public int cxLeftWidth;

		public int cxRightWidth;

		public int cyTopHeight;

		public int cyBottomHeight;
	}

	[Flags]
	internal enum SetWindowPosFlags : uint
	{
		AsyncWindowPositioning = 0x4000u,
		DeferErase = 0x2000u,
		DrawFrame = 0x20u,
		FrameChanged = 0x20u,
		HideWindow = 0x80u,
		NoActivate = 0x10u,
		NoCopyBits = 0x100u,
		NoMove = 2u,
		NoOwnerZOrder = 0x200u,
		NoRedraw = 8u,
		NoReposition = 0x200u,
		NoSendChanging = 0x400u,
		NoSize = 1u,
		NoZOrder = 4u,
		ShowWindow = 0x40u
	}

	public CameraZoomAndMove cameraScript;

	public UniWindowController uniWindowController;

	public Transform corner1;

	public Transform corner2;

	public Transform corner3;

	public Transform corner4;

	public Image bottombar;

	public Image sidebar;

	private List<DisplayInfo> myDisplays = new List<DisplayInfo>();

	private List<MyMonitor> myMonitors = new List<MyMonitor>();

	private int monitorNumber;

	private const int GWL_EXSTYLE = -20;

	private const uint WS_EX_LAYERED = 524288u;

	private const uint WS_EX_TRANSPARENT = 32u;

	private const uint SHOW_WINDOW = 64u;

	private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);

	private static readonly IntPtr HWND_NORMAL = new IntPtr(-2);

	private const uint LWA_COLORKEY = 1u;

	private const uint rgbGreen = 65280u;

	private Vector3 c1;

	private Vector3 c2;

	private Vector3 c3;

	private Vector3 c4;

	private Vector3 w1;

	private Vector3 w2;

	private Vector3 w3;

	private Vector3 w4;

	private int screenW;

	private int screenH;

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
	internal static extern void MoveWindow(IntPtr hwnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

	[DllImport("user32.dll")]
	private static extern IntPtr GetActiveWindow();

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
	internal static extern bool GetWindowRect(IntPtr hWnd, ref RECT rect);

	[DllImport("user32.dll")]
	private static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, MonitorEnumDelegate lpfnEnum, IntPtr dwData);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern bool GetMonitorInfo(IntPtr hmonitor, [In][Out] MONITORINFOEX info);

	[DllImport("User32.dll", ExactSpelling = true)]
	public static extern IntPtr MonitorFromPoint(POINTSTRUCT pt, int flags);

	public DisplayInfoCollection GetDisplays()
	{
		DisplayInfoCollection col = new DisplayInfoCollection();
		EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, delegate(IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, IntPtr dwData)
		{
			MONITORINFOEX mONITORINFOEX = new MONITORINFOEX();
			mONITORINFOEX.cbSize = Marshal.SizeOf(mONITORINFOEX);
			if (GetMonitorInfo(hMonitor, mONITORINFOEX))
			{
				DisplayInfo item = new DisplayInfo
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

	[DllImport("user32.dll", SetLastError = true)]
	internal static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, SetWindowPosFlags uFlags);

	[DllImport("user32.dll")]
	private static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

	[DllImport("user32.dll")]
	private static extern int SetLayeredWindowAttributes(IntPtr hWnd, uint crKey, byte bAlpha, uint dwFlags);

	[DllImport("Dwmapi.dll")]
	private static extern uint DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS margins);

	private void Awake()
	{
	}

	private void Start()
	{
		SetTransparentWindow(SaveData.ins.greenScreen);
		GetMonitors();
	}

	private void GetMonitors()
	{
		myDisplays = GetDisplays();
		for (int i = 0; i < myDisplays.Count; i++)
		{
			myMonitors.Add(new MyMonitor(myDisplays[i].WorkArea.left, myDisplays[i].WorkArea.top, i, Convert.ToInt32(myDisplays[i].ScreenHeight), Convert.ToInt32(myDisplays[i].ScreenWidth)));
		}
	}

	public void SetTransparentWindow(bool greenScreen)
	{
		IntPtr activeWindow = GetActiveWindow();
		MARGINS margins = new MARGINS
		{
			cxLeftWidth = -1
		};
		DwmExtendFrameIntoClientArea(activeWindow, ref margins);
		if (greenScreen)
		{
			GameManager.ins.mainCam.backgroundColor = Color.green;
			bottombar.color = Color.green;
			sidebar.color = Color.green;
			SetWindowLong(activeWindow, -20, 524288u);
			SetLayeredWindowAttributes(activeWindow, 65280u, 0, 1u);
		}
		else
		{
			GameManager.ins.mainCam.backgroundColor = Color.black;
			bottombar.color = Color.black;
			sidebar.color = Color.black;
			SetWindowLong(activeWindow, -20, 524288u);
			SetLayeredWindowAttributes(activeWindow, 0u, 0, 1u);
		}
	}

	private void LateUpdate()
	{
	}

	public void CheckCutout()
	{
		c1 = GameManager.ins.mainCam.WorldToScreenPoint(corner1.position);
		c2 = GameManager.ins.mainCam.WorldToScreenPoint(corner2.position);
		c3 = GameManager.ins.mainCam.WorldToScreenPoint(corner3.position);
		c4 = GameManager.ins.mainCam.WorldToScreenPoint(corner4.position);
		w1 = corner1.position;
		w2 = corner2.position;
		w3 = corner3.position;
		w4 = corner4.position;
		Vector3 vector = c1;
		Debug.Log("c1 " + vector.ToString());
		vector = c2;
		Debug.Log("c2 " + vector.ToString());
		vector = c3;
		Debug.Log("c3 " + vector.ToString());
		vector = c4;
		Debug.Log("c4 " + vector.ToString());
		vector = w1;
		Debug.Log("w1 " + vector.ToString());
		vector = w2;
		Debug.Log("w2 " + vector.ToString());
		vector = w3;
		Debug.Log("w3 " + vector.ToString());
		vector = w4;
		Debug.Log("w4 " + vector.ToString());
		POINTSTRUCT[] points = new POINTSTRUCT[4]
		{
			new POINTSTRUCT((int)c1.x, myMonitors[monitorNumber].height - (int)c1.y),
			new POINTSTRUCT((int)c2.x, myMonitors[monitorNumber].height - (int)c2.y),
			new POINTSTRUCT((int)c3.x, myMonitors[monitorNumber].height - (int)c3.y),
			new POINTSTRUCT((int)c4.x, myMonitors[monitorNumber].height - (int)c4.y)
		};
		Cut(GetActiveWindow(), points);
	}

	private bool cornersInScreenHaveChanged()
	{
		bool result = false;
		if (GameManager.ins.mainCam.WorldToScreenPoint(corner1.position) != c1)
		{
			result = true;
		}
		if (GameManager.ins.mainCam.WorldToScreenPoint(corner2.position) != c2)
		{
			result = true;
		}
		if (GameManager.ins.mainCam.WorldToScreenPoint(corner3.position) != c3)
		{
			result = true;
		}
		if (GameManager.ins.mainCam.WorldToScreenPoint(corner4.position) != c4)
		{
			result = true;
		}
		Debug.Log("has Changed: " + result);
		return result;
	}

	private bool cornersInWorldHaveChanged()
	{
		bool result = false;
		if (corner1.position != w1)
		{
			result = true;
		}
		if (corner2.position != w2)
		{
			result = true;
		}
		if (corner3.position != w3)
		{
			result = true;
		}
		if (corner4.position != w4)
		{
			result = true;
		}
		return result;
	}

	private void CheckResolution()
	{
		if (screenW != Screen.currentResolution.width || screenH != Screen.currentResolution.height)
		{
			Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, FullScreenMode.FullScreenWindow);
			cameraScript.Restart();
			screenW = Screen.currentResolution.width;
			screenH = Screen.currentResolution.height;
		}
	}

	public void ResetGameResolutionOnCurrentDisplay()
	{
		int width = myMonitors[monitorNumber].width;
		int height = myMonitors[monitorNumber].height;
		Screen.SetResolution(width, height, FullScreenMode.FullScreenWindow);
		cameraScript.Restart();
	}

	public void ChangeDisplayClicked()
	{
		monitorNumber++;
		if (monitorNumber >= myDisplays.Count)
		{
			monitorNumber = 0;
		}
		StartCoroutine(MoveWindow());
	}

	private IEnumerator MoveWindow()
	{
		RECT rect = default(RECT);
		IntPtr activeWindow = GetActiveWindow();
		GetWindowRect(activeWindow, ref rect);
		int targetX = myMonitors[monitorNumber].targetX;
		int targetY = myMonitors[monitorNumber].targetY;
		int width = myMonitors[monitorNumber].width;
		int height = myMonitors[monitorNumber].height;
		MoveWindow(activeWindow, targetX, targetY, width, height, bRepaint: true);
		MARGINS margins = new MARGINS
		{
			cxLeftWidth = -1
		};
		DwmExtendFrameIntoClientArea(activeWindow, ref margins);
		SetWindowPos(activeWindow, HWND_NORMAL, targetX, targetY, width, height, SetWindowPosFlags.ShowWindow);
		if (SaveData.ins.greenScreen)
		{
			GameManager.ins.mainCam.backgroundColor = Color.green;
			SetWindowLong(activeWindow, -20, 524288u);
			SetLayeredWindowAttributes(activeWindow, 65280u, 0, 1u);
		}
		else
		{
			GameManager.ins.mainCam.backgroundColor = Color.black;
			SetWindowLong(activeWindow, -20, 524288u);
			SetLayeredWindowAttributes(activeWindow, 0u, 0, 1u);
		}
		SaveData.ins.SetAlwaysOnTopInUI(newAlwaysOnTop: false);
		yield return null;
		cameraScript.Restart();
	}

	public void SetAlwaysOnTop(bool alwaysOnTop)
	{
		StartCoroutine(SetTopmost(alwaysOnTop));
	}

	private IEnumerator SetTopmost(bool alwaysOnTop)
	{
		RECT rect = default(RECT);
		IntPtr activeWindow = GetActiveWindow();
		GetWindowRect(activeWindow, ref rect);
		int targetX = myMonitors[monitorNumber].targetX;
		int targetY = myMonitors[monitorNumber].targetY;
		int width = myMonitors[monitorNumber].width;
		int height = myMonitors[monitorNumber].height;
		SaveData.ins.alwaysOnTop = alwaysOnTop;
		if (SaveData.ins.alwaysOnTop)
		{
			SetWindowPos(activeWindow, HWND_TOPMOST, targetX, targetY, width, height, SetWindowPosFlags.ShowWindow);
		}
		else
		{
			SetWindowPos(activeWindow, HWND_NORMAL, targetX, targetY, width, height, SetWindowPosFlags.ShowWindow);
		}
		yield return null;
	}

	[DllImport("user32.dll")]
	public static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);

	[DllImport("gdi32.dll")]
	public static extern IntPtr CreatePolygonRgn(POINTSTRUCT[] lpPoint, int nCount, int nPolyFillMode);

	[DllImport("gdi32.dll", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeleteObject(IntPtr hObject);

	public static void Cut(nint hwnd, POINTSTRUCT[] points)
	{
		IntPtr intPtr = CreatePolygonRgn(points, points.Length, 2);
		SetWindowRgn(hwnd, intPtr, bRedraw: true);
		DeleteObject(intPtr);
	}
}
