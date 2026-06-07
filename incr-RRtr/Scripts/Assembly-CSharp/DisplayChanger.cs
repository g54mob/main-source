using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Kirurobo;
using UnityEngine;
using UnityEngine.UI;

public class DisplayChanger : MonoBehaviour
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

	public void Awake()
	{
	}

	private IEnumerator EnableCoroutine()
	{
		SetTransparentWindow(SaveData.ins.greenScreen);
		myDisplays = GetDisplays();
		for (int i = 0; i < myDisplays.Count; i++)
		{
			myMonitors.Add(new MyMonitor(myDisplays[i].WorkArea.left, myDisplays[i].WorkArea.top, i, Convert.ToInt32(myDisplays[i].ScreenHeight), Convert.ToInt32(myDisplays[i].ScreenWidth)));
		}
		yield return 0;
		ResetGameResolutionOnCurrentDisplay();
		cameraScript.Restart();
		yield return 0;
		ResetGameResolutionOnCurrentDisplay();
		cameraScript.Restart();
	}

	private void OnEnable()
	{
		StartCoroutine(EnableCoroutine());
	}

	public void SetTransparentWindow(bool greenScreen)
	{
		IntPtr activeWindow = GetActiveWindow();
		MARGINS margins = new MARGINS
		{
			cxLeftWidth = -1
		};
		if (greenScreen)
		{
			GameManager.ins.mainCam.backgroundColor = Color.green;
			GameManager.ins.clearCam.backgroundColor = Color.green;
			bottombar.color = Color.green;
			sidebar.color = Color.green;
			SetWindowLong(activeWindow, -20, 524288u);
			SetLayeredWindowAttributes(activeWindow, 65280u, 0, 1u);
		}
		else
		{
			GameManager.ins.mainCam.backgroundColor = Color.black;
			GameManager.ins.clearCam.backgroundColor = Color.black;
			bottombar.color = Color.black;
			sidebar.color = Color.black;
			SetWindowLong(activeWindow, -20, 524288u);
			SetLayeredWindowAttributes(activeWindow, 0u, 0, 1u);
		}
		DwmExtendFrameIntoClientArea(activeWindow, ref margins);
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
			GameManager.ins.clearCam.backgroundColor = Color.green;
			SetWindowLong(activeWindow, -20, 524288u);
			SetLayeredWindowAttributes(activeWindow, 65280u, 0, 1u);
		}
		else
		{
			GameManager.ins.mainCam.backgroundColor = Color.black;
			GameManager.ins.clearCam.backgroundColor = Color.black;
			SetWindowLong(activeWindow, -20, 524288u);
			SetLayeredWindowAttributes(activeWindow, 0u, 0, 1u);
		}
		SaveData.ins.SetAlwaysOnTopInUI(newAlwaysOnTop: false);
		yield return null;
		cameraScript.Start();
	}

	public void SetAlwaysOnTop(bool alwaysOnTop)
	{
		if (base.enabled)
		{
			StartCoroutine(SetTopmost(alwaysOnTop));
		}
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
}
