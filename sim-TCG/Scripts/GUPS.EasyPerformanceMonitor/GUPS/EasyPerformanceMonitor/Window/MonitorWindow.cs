using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace GUPS.EasyPerformanceMonitor.Window
{
	[Obfuscation(Exclude = true)]
	public class MonitorWindow : MonoBehaviour
	{
		[Header("Monitor Window - Settings")]
		public string Name;

		[Header("Monitor Window - Toggle Keys")]
		[Tooltip("Required input action to perform to toggle the monitor window (New Input system).")]
		public InputAction ToggleAction;

		[Tooltip("Require the user to press also the 'control'-key to toggle the monitor window (Old Input system).")]
		public bool UseControl;

		[Tooltip("Require the user to press also the 'shift'-key to toggle the monitor window (Old Input system).")]
		public bool UseShift;

		[Tooltip("Require the user to press also the 'alt'-key to toggle the monitor window (Old Input system).")]
		public bool UseAlt;

		[Tooltip("Required key to press to toggle the monitor window (Old Input system).")]
		public KeyCode ToggleKey = KeyCode.F1;

		[Header("Monitor Window - Rendering")]
		[Tooltip("The monitor canvas, rendering the monitor window.")]
		public Canvas MonitorCanvas;

		[Tooltip("The monitor window position.")]
		public EMonitorWindowPosition MonitorPosition = EMonitorWindowPosition.Top_Left;

		[Tooltip("The monitor elements initial x offset.")]
		public int InitialOffsetX;

		[Tooltip("The monitor elements initial y offset.")]
		public int InitialOffsetY;

		[Tooltip("The monitor elements width.")]
		public int ElementWidth = 100;

		[Tooltip("The monitor elements height.")]
		public int ElementHeight = 100;

		[Tooltip("The monitor elements spacing / margin.")]
		public int ElementSpacing = 10;

		private RectTransform RectTransform => MonitorCanvas.GetComponent<RectTransform>();

		private CanvasScaler CanvasScaler => MonitorCanvas.GetComponent<CanvasScaler>();

		private Vector2 ReferenceResolution
		{
			get
			{
				if (MonitorCanvas.renderMode == RenderMode.WorldSpace)
				{
					return RectTransform.rect.size;
				}
				return CanvasScaler.referenceResolution;
			}
		}

		protected virtual void OnEnable()
		{
			ToggleAction.Enable();
			ToggleAction.performed += ToggleActionOnPerformed;
		}

		private void ToggleActionOnPerformed(InputAction.CallbackContext context)
		{
			Toggle();
		}

		protected virtual void Start()
		{
			PlaceMonitorElements();
		}

		protected virtual void Update()
		{
			if (GetToggleKeysPressed())
			{
				Toggle();
			}
		}

		private bool GetToggleKeysPressed()
		{
			if (UseControl && !Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl))
			{
				return false;
			}
			if (UseShift && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
			{
				return false;
			}
			if (UseAlt && !Input.GetKey(KeyCode.LeftAlt) && !Input.GetKey(KeyCode.RightAlt))
			{
				return false;
			}
			return Input.GetKeyUp(ToggleKey);
		}

		public void Toggle()
		{
			Toggle(!MonitorCanvas.enabled);
		}

		public void Toggle(bool _Show)
		{
			MonitorCanvas.enabled = _Show;
		}

		public void PlaceMonitorElements()
		{
			if (MonitorPosition == EMonitorWindowPosition.Free)
			{
				return;
			}
			List<RectTransform> list = new List<RectTransform>();
			foreach (Transform item in MonitorCanvas.transform)
			{
				if (item.gameObject.activeSelf)
				{
					list.Add(item as RectTransform);
				}
			}
			float num = 0f;
			float num2 = 0f;
			switch (MonitorPosition)
			{
			case EMonitorWindowPosition.Top:
				num = ElementSpacing + InitialOffsetX;
				num2 = -(ElementSpacing + InitialOffsetY);
				break;
			case EMonitorWindowPosition.Top_Left:
				num = ElementSpacing + InitialOffsetX;
				num2 = -(ElementSpacing + InitialOffsetY);
				break;
			case EMonitorWindowPosition.Top_Right:
				num = -(ElementWidth + ElementSpacing + InitialOffsetX);
				num2 = -(ElementSpacing + InitialOffsetY);
				break;
			}
			for (int i = 0; i < list.Count; i++)
			{
				list[i].sizeDelta = new Vector2(ElementWidth, ElementHeight);
				switch (MonitorPosition)
				{
				case EMonitorWindowPosition.Top:
					list[i].anchorMin = new Vector2(0f, 1f);
					list[i].anchorMax = new Vector2(0f, 1f);
					list[i].pivot = new Vector2(0f, 1f);
					list[i].anchoredPosition = new Vector3(num, num2, 0f);
					if (num + (float)(ElementWidth * 2) > ReferenceResolution.x)
					{
						num2 -= (float)(ElementHeight + ElementSpacing);
						num = ElementSpacing;
					}
					else
					{
						num += (float)(ElementWidth + ElementSpacing);
					}
					break;
				case EMonitorWindowPosition.Top_Left:
					list[i].anchorMin = new Vector2(0f, 1f);
					list[i].anchorMax = new Vector2(0f, 1f);
					list[i].pivot = new Vector2(0f, 1f);
					list[i].anchoredPosition = new Vector3(num, num2, 0f);
					if (num2 - (float)(ElementHeight * 2) < 0f - ReferenceResolution.y)
					{
						num += (float)(ElementWidth + ElementSpacing);
						num2 = -ElementSpacing;
					}
					else
					{
						num2 -= (float)(ElementHeight + ElementSpacing);
					}
					break;
				case EMonitorWindowPosition.Top_Right:
					list[i].anchorMin = new Vector2(1f, 1f);
					list[i].anchorMax = new Vector2(1f, 1f);
					list[i].pivot = new Vector2(0f, 1f);
					list[i].anchoredPosition = new Vector3(num, num2, 0f);
					if (num2 - (float)(ElementHeight * 2) < 0f - ReferenceResolution.y)
					{
						num -= (float)(ElementWidth + ElementSpacing);
						num2 = -ElementSpacing;
					}
					else
					{
						num2 -= (float)(ElementHeight + ElementSpacing);
					}
					break;
				}
			}
			switch (MonitorPosition)
			{
			case EMonitorWindowPosition.Bottom:
				num = ElementSpacing + InitialOffsetX;
				num2 = ElementHeight + ElementSpacing + InitialOffsetY;
				break;
			case EMonitorWindowPosition.Bottom_Left:
				num = ElementSpacing + InitialOffsetX;
				num2 = ElementHeight + ElementSpacing + InitialOffsetY;
				break;
			case EMonitorWindowPosition.Bottom_Right:
				num = -(ElementWidth + ElementSpacing + InitialOffsetX);
				num2 = ElementHeight + ElementSpacing + InitialOffsetY;
				break;
			}
			for (int num3 = list.Count - 1; num3 >= 0; num3--)
			{
				switch (MonitorPosition)
				{
				case EMonitorWindowPosition.Bottom:
					list[num3].anchorMin = new Vector2(0f, 0f);
					list[num3].anchorMax = new Vector2(0f, 0f);
					list[num3].pivot = new Vector2(0f, 1f);
					list[num3].anchoredPosition = new Vector3(num, num2, 0f);
					if (num + (float)(ElementWidth * 2) > ReferenceResolution.x)
					{
						num2 += (float)(ElementHeight + ElementSpacing);
						num = ElementSpacing;
					}
					else
					{
						num += (float)(ElementWidth + ElementSpacing);
					}
					break;
				case EMonitorWindowPosition.Bottom_Left:
					list[num3].anchorMin = new Vector2(0f, 0f);
					list[num3].anchorMax = new Vector2(0f, 0f);
					list[num3].pivot = new Vector2(0f, 1f);
					list[num3].anchoredPosition = new Vector3(num, num2, 0f);
					if (num2 + (float)(ElementHeight * 2) > ReferenceResolution.y)
					{
						num += (float)(ElementWidth + ElementSpacing);
						num2 = ElementHeight + ElementSpacing;
					}
					else
					{
						num2 += (float)(ElementHeight + ElementSpacing);
					}
					break;
				case EMonitorWindowPosition.Bottom_Right:
					list[num3].anchorMin = new Vector2(1f, 0f);
					list[num3].anchorMax = new Vector2(1f, 0f);
					list[num3].pivot = new Vector2(0f, 1f);
					list[num3].anchoredPosition = new Vector3(num, num2, 0f);
					if (num2 + (float)(ElementHeight * 2) > ReferenceResolution.y)
					{
						num -= (float)(ElementWidth + ElementSpacing);
						num2 = ElementHeight + ElementSpacing;
					}
					else
					{
						num2 += (float)(ElementHeight + ElementSpacing);
					}
					break;
				}
			}
		}

		public virtual void RefreshWindow()
		{
			PlaceMonitorElements();
		}

		protected virtual void OnDisable()
		{
			ToggleAction.Disable();
			ToggleAction.performed -= ToggleActionOnPerformed;
		}
	}
}
