using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AOT;
using R3;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class WindowedHeaderController : MonoBehaviour
{
	private delegate IntPtr WndProcDelegate(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

	private struct RECT
	{
		public int Left;

		public int Top;

		public int Right;

		public int Bottom;
	}

	private struct POINT
	{
		public int X;

		public int Y;
	}

	private const int GWL_STYLE = -16;

	private const int GWL_EXSTYLE = -20;

	private const int WS_CAPTION = 12582912;

	private const int WS_THICKFRAME = 262144;

	private const int WS_SYSMENU = 524288;

	private const int WS_MINIMIZEBOX = 131072;

	private const int WS_MAXIMIZEBOX = 65536;

	private const int WS_POPUP = int.MinValue;

	private const int WS_VISIBLE = 268435456;

	private const int WS_CLIPSIBLINGS = 67108864;

	private const int WS_CLIPCHILDREN = 33554432;

	private const int WS_EX_DLGMODALFRAME = 1;

	private const int WS_EX_WINDOWEDGE = 256;

	private const int WS_EX_CLIENTEDGE = 512;

	private const int WS_EX_STATICEDGE = 131072;

	private const uint SWP_FRAMECHANGED = 32u;

	private const uint SWP_NOMOVE = 2u;

	private const uint SWP_NOSIZE = 1u;

	private const uint SWP_NOZORDER = 4u;

	private const uint SWP_SHOWWINDOW = 64u;

	private const int SW_MINIMIZE = 6;

	private const int SW_MAXIMIZE = 3;

	private const int SW_RESTORE = 9;

	private const uint WM_NCLBUTTONDOWN = 161u;

	private const int HT_CAPTION = 2;

	private const float DOUBLE_CLICK_TIME = 0.3f;

	private const int DWMWA_NCRENDERING_POLICY = 2;

	private const int DWMNCRP_DISABLED = 1;

	private const int GWLP_WNDPROC = -4;

	private const uint WM_NCHITTEST = 132u;

	private const int HTLEFT = 10;

	private const int HTRIGHT = 11;

	private const int HTTOP = 12;

	private const int HTTOPLEFT = 13;

	private const int HTTOPRIGHT = 14;

	private const int HTBOTTOM = 15;

	private const int HTBOTTOMLEFT = 16;

	private const int HTBOTTOMRIGHT = 17;

	private const int RESIZE_BORDER_PX = 6;

	private const int DEFAULT_WINDOWED_WIDTH = 1280;

	private const int DEFAULT_WINDOWED_HEIGHT = 720;

	private const int REAPPLY_FRAME_DELAY = 4;

	[SerializeField]
	private RectTransform topBar;

	[SerializeField]
	private Button minimizeButton;

	[SerializeField]
	private Button maximizeButton;

	[SerializeField]
	private Button closeButton;

	private CanvasGroup _canvasGroup;

	private Canvas _canvas;

	private Coroutine _applyCoroutine;

	private readonly List<RaycastResult> _raycastResults = new List<RaycastResult>();

	private readonly Vector3[] _corners = new Vector3[4];

	private HashSet<GameObject> _buttonGameObjects;

	private static bool _isQuitting;

	private IntPtr _hWnd;

	private int _originalStyle;

	private int _originalExStyle;

	private bool _isMaximized;

	private float _lastClickTime;

	private bool _barApplied;

	private IntPtr _originalWndProc;

	private WndProcDelegate _customWndProcDelegate;

	public static int TopOffsetPixels { get; private set; }

	public static bool IsActive { get; private set; }

	[DllImport("user32.dll")]
	private static extern IntPtr GetActiveWindow();

	[DllImport("user32.dll")]
	private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

	[DllImport("user32.dll")]
	private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

	[DllImport("user32.dll")]
	private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

	[DllImport("user32.dll")]
	private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

	[DllImport("user32.dll")]
	private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

	[DllImport("user32.dll")]
	private static extern bool ReleaseCapture();

	[DllImport("user32.dll")]
	private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

	[DllImport("dwmapi.dll")]
	private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

	[DllImport("user32.dll")]
	private static extern bool GetCursorPos(out POINT lpPoint);

	[DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
	private static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

	[DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
	private static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, int nIndex);

	[DllImport("user32.dll")]
	private static extern IntPtr CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

	private void Awake()
	{
		_canvasGroup = GetComponent<CanvasGroup>();
		_canvas = GetComponent<Canvas>();
		_buttonGameObjects = new HashSet<GameObject>();
		CacheButtonGameObjects(minimizeButton);
		CacheButtonGameObjects(maximizeButton);
		CacheButtonGameObjects(closeButton);
		Application.quitting += OnApplicationQuitting;
		SetCanvasGroupVisible(visible: false);
	}

	private void CacheButtonGameObjects(Button button)
	{
		if (!(button == null))
		{
			Transform[] componentsInChildren = button.GetComponentsInChildren<Transform>(includeInactive: true);
			foreach (Transform transform in componentsInChildren)
			{
				_buttonGameObjects.Add(transform.gameObject);
			}
		}
	}

	private void OnEnable()
	{
		ReactiveSettings.FullscreenMode.Subscribe(OnFullscreenModeChanged).AddTo(this);
	}

	private void OnDisable()
	{
		StopPendingApply();
		if (!_isQuitting)
		{
			RestoreNativeTitleBar();
		}
		ClearButtonListeners();
		SetCanvasGroupVisible(visible: false);
		TopOffsetPixels = 0;
		IsActive = false;
	}

	private void OnDestroy()
	{
		Application.quitting -= OnApplicationQuitting;
	}

	private static void OnApplicationQuitting()
	{
		_isQuitting = true;
	}

	private void Update()
	{
		if (IsActive)
		{
			TopOffsetPixels = CalculateBarPixelHeight();
			HandleDragAndDoubleClick();
		}
	}

	private void OnFullscreenModeChanged(FullScreenMode mode)
	{
		StopPendingApply();
		if (mode == FullScreenMode.Windowed)
		{
			_applyCoroutine = StartCoroutine(ApplyWindowedModeDelayed());
		}
		else
		{
			ApplyFullscreenMode();
		}
	}

	private IEnumerator ApplyWindowedModeDelayed()
	{
		float timeout = 3f;
		float elapsed = 0f;
		while (Screen.fullScreenMode != FullScreenMode.Windowed && elapsed < timeout)
		{
			elapsed += Time.unscaledDeltaTime;
			yield return null;
		}
		for (int i = 0; i < 4; i++)
		{
			yield return null;
		}
		ApplyWindowedMode();
		_applyCoroutine = null;
	}

	private void ApplyWindowedMode()
	{
		try
		{
			_hWnd = GetActiveWindow();
			if (_hWnd == IntPtr.Zero)
			{
				Debug.LogWarning("[WindowedHeaderController] GetActiveWindow returned zero. Skipping Win32 operations.");
				return;
			}
			_originalStyle = GetWindowLong(_hWnd, -16);
			StripNativeCaption();
			int num = 1280;
			int num2 = 720;
			int width = Screen.currentResolution.width;
			int height = Screen.currentResolution.height;
			int x = (width - num) / 2;
			int y = (height - num2) / 2;
			SetWindowPos(_hWnd, IntPtr.Zero, x, y, num, num2, 68u);
			_isMaximized = false;
			_barApplied = true;
		}
		catch (Exception ex)
		{
			Debug.LogWarning("[WindowedHeaderController] Win32 error in ApplyWindowedMode: " + ex.Message);
			return;
		}
		IsActive = true;
		SetCanvasGroupVisible(visible: true);
		WireButtonListeners();
	}

	private void ApplyFullscreenMode()
	{
		RestoreNativeTitleBar();
		ClearButtonListeners();
		SetCanvasGroupVisible(visible: false);
		TopOffsetPixels = 0;
		IsActive = false;
	}

	private void StripNativeCaption()
	{
		if (!(_hWnd == IntPtr.Zero))
		{
			int windowLong = GetWindowLong(_hWnd, -16);
			windowLong &= -13565953;
			windowLong |= -1778384896;
			SetWindowLong(_hWnd, -16, windowLong);
			_originalExStyle = GetWindowLong(_hWnd, -20);
			int originalExStyle = _originalExStyle;
			originalExStyle &= -131842;
			SetWindowLong(_hWnd, -20, originalExStyle);
			int attrValue = 1;
			DwmSetWindowAttribute(_hWnd, 2, ref attrValue, 4);
			SetWindowPos(_hWnd, IntPtr.Zero, 0, 0, 0, 0, 103u);
			InstallWndProcHook();
		}
	}

	private void InstallWndProcHook()
	{
		if (!(_originalWndProc != IntPtr.Zero))
		{
			_customWndProcDelegate = CustomWndProc;
			IntPtr functionPointerForDelegate = Marshal.GetFunctionPointerForDelegate(_customWndProcDelegate);
			_originalWndProc = GetWindowLongPtr64(_hWnd, -4);
			SetWindowLongPtr64(_hWnd, -4, functionPointerForDelegate);
		}
	}

	private void RemoveWndProcHook()
	{
		if (!(_originalWndProc == IntPtr.Zero) && !(_hWnd == IntPtr.Zero))
		{
			SetWindowLongPtr64(_hWnd, -4, _originalWndProc);
			_originalWndProc = IntPtr.Zero;
			_customWndProcDelegate = null;
		}
	}

	[MonoPInvokeCallback(typeof(WndProcDelegate))]
	private IntPtr CustomWndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
	{
		if (msg == 132 && GetCursorPos(out var lpPoint) && GetWindowRect(hWnd, out var lpRect))
		{
			int num = lpPoint.X - lpRect.Left;
			int num2 = lpPoint.Y - lpRect.Top;
			int num3 = lpRect.Right - lpRect.Left;
			int num4 = lpRect.Bottom - lpRect.Top;
			bool flag = num < 6;
			bool flag2 = num >= num3 - 6;
			bool flag3 = num2 < 6;
			bool flag4 = num2 >= num4 - 6;
			if (flag3 && flag)
			{
				return (IntPtr)13;
			}
			if (flag3 && flag2)
			{
				return (IntPtr)14;
			}
			if (flag4 && flag)
			{
				return (IntPtr)16;
			}
			if (flag4 && flag2)
			{
				return (IntPtr)17;
			}
			if (flag)
			{
				return (IntPtr)10;
			}
			if (flag2)
			{
				return (IntPtr)11;
			}
			if (flag3)
			{
				return (IntPtr)12;
			}
			if (flag4)
			{
				return (IntPtr)15;
			}
		}
		return CallWindowProc(_originalWndProc, hWnd, msg, wParam, lParam);
	}

	private void RestoreNativeTitleBar()
	{
		try
		{
			if (!(_hWnd == IntPtr.Zero) && _barApplied)
			{
				RemoveWndProcHook();
				SetWindowLong(_hWnd, -16, _originalStyle);
				SetWindowLong(_hWnd, -20, _originalExStyle);
				int attrValue = 0;
				DwmSetWindowAttribute(_hWnd, 2, ref attrValue, 4);
				SetWindowPos(_hWnd, IntPtr.Zero, 0, 0, 0, 0, 103u);
				_hWnd = IntPtr.Zero;
				_barApplied = false;
			}
		}
		catch (Exception ex)
		{
			Debug.LogWarning("[WindowedHeaderController] Win32 error in RestoreNativeTitleBar: " + ex.Message);
		}
	}

	private void HandleDragAndDoubleClick()
	{
		if (topBar == null || _hWnd == IntPtr.Zero)
		{
			return;
		}
		Mouse current = Mouse.current;
		if (current == null || !current.leftButton.wasPressedThisFrame)
		{
			return;
		}
		Vector2 vector = current.position.ReadValue();
		if (IsPointerOverAnyButton(vector) || !RectTransformUtility.RectangleContainsScreenPoint(topBar, vector, null))
		{
			return;
		}
		if (Time.unscaledTime - _lastClickTime <= 0.3f)
		{
			ToggleMaximize();
			_lastClickTime = 0f;
			return;
		}
		_lastClickTime = Time.unscaledTime;
		try
		{
			ReleaseCapture();
			SendMessage(_hWnd, 161u, (IntPtr)2, IntPtr.Zero);
		}
		catch (Exception ex)
		{
			Debug.LogWarning("[WindowedHeaderController] Win32 error during drag: " + ex.Message);
		}
	}

	private bool IsPointerOverAnyButton(Vector2 screenPos)
	{
		EventSystem current = EventSystem.current;
		if (current == null)
		{
			return false;
		}
		_raycastResults.Clear();
		PointerEventData eventData = new PointerEventData(current)
		{
			position = screenPos
		};
		current.RaycastAll(eventData, _raycastResults);
		foreach (RaycastResult raycastResult in _raycastResults)
		{
			if (raycastResult.gameObject != null && _buttonGameObjects.Contains(raycastResult.gameObject))
			{
				return true;
			}
		}
		return false;
	}

	private void ToggleMaximize()
	{
		try
		{
			if (!(_hWnd == IntPtr.Zero))
			{
				if (_isMaximized)
				{
					ShowWindow(_hWnd, 9);
					_isMaximized = false;
				}
				else
				{
					ShowWindow(_hWnd, 3);
					_isMaximized = true;
				}
			}
		}
		catch (Exception ex)
		{
			Debug.LogWarning("[WindowedHeaderController] Win32 error in ToggleMaximize: " + ex.Message);
		}
	}

	private int CalculateBarPixelHeight()
	{
		if (topBar == null)
		{
			return 0;
		}
		topBar.GetWorldCorners(_corners);
		float y = _corners[0].y;
		return Mathf.RoundToInt((float)Screen.height - y);
	}

	private void WireButtonListeners()
	{
		ClearButtonListeners();
		if (minimizeButton != null)
		{
			minimizeButton.onClick.AddListener(OnMinimizeClicked);
		}
		if (maximizeButton != null)
		{
			maximizeButton.onClick.AddListener(OnMaximizeClicked);
		}
		if (closeButton != null)
		{
			closeButton.onClick.AddListener(OnCloseClicked);
		}
	}

	private void ClearButtonListeners()
	{
		if (minimizeButton != null)
		{
			minimizeButton.onClick.RemoveListener(OnMinimizeClicked);
		}
		if (maximizeButton != null)
		{
			maximizeButton.onClick.RemoveListener(OnMaximizeClicked);
		}
		if (closeButton != null)
		{
			closeButton.onClick.RemoveListener(OnCloseClicked);
		}
	}

	private void OnMinimizeClicked()
	{
		try
		{
			if (_hWnd != IntPtr.Zero)
			{
				ShowWindow(_hWnd, 6);
			}
		}
		catch (Exception ex)
		{
			Debug.LogWarning("[WindowedHeaderController] Win32 error in Minimize: " + ex.Message);
		}
	}

	private void OnMaximizeClicked()
	{
		ToggleMaximize();
	}

	private void OnCloseClicked()
	{
		ApplicationController.Quit();
	}

	private void SetCanvasGroupVisible(bool visible)
	{
		if (!(_canvasGroup == null))
		{
			_canvasGroup.alpha = (visible ? 1f : 0f);
			_canvasGroup.interactable = visible;
			_canvasGroup.blocksRaycasts = visible;
		}
	}

	private void StopPendingApply()
	{
		if (_applyCoroutine != null)
		{
			StopCoroutine(_applyCoroutine);
			_applyCoroutine = null;
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void ResetStatics()
	{
		TopOffsetPixels = 0;
		IsActive = false;
		_isQuitting = false;
	}
}
