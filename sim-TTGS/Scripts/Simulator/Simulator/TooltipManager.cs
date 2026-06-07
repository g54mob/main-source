using System.Collections.Generic;
using Dhs5.Utility.Updates;
using I2.Loc;
using Simulator.GameWorld;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Simulator
{
	public static class TooltipManager
	{
		private static List<Tooltip> _instantiatedTooltips = new List<Tooltip>();

		private static Dictionary<ITooltipDisplayer, Tooltip> _tooltipDisplayers = new Dictionary<ITooltipDisplayer, Tooltip>();

		private static int _currentTooltipCount;

		private static RectTransform _tooltipParent;

		private static Transform _tooltipCanvas;

		private static ITooltipDisplayer _focusedComponent;

		private static bool _updateRegistered;

		private static float _timeSinceLastMovement;

		private static Vector2 _lastMousePosition;

		private static bool _inputChangeRegistered;

		public static void Init()
		{
			_instantiatedTooltips.Clear();
			_tooltipDisplayers.Clear();
			_currentTooltipCount = 0;
			if (_tooltipCanvas == null)
			{
				_tooltipCanvas = Object.Instantiate(TooltipSettings.TooltipCanvas).transform;
			}
			if (_tooltipParent == null)
			{
				_tooltipParent = Object.Instantiate(TooltipSettings.TooltipLayout, _tooltipCanvas).GetComponent<RectTransform>();
			}
		}

		private static Tooltip GetTooltip()
		{
			if (_instantiatedTooltips.Count <= 0)
			{
				InstantiateTooltip();
			}
			int num = _currentTooltipCount - _instantiatedTooltips.Count;
			if (num > 0)
			{
				for (int i = 0; i < num; i++)
				{
					InstantiateTooltip();
				}
			}
			return _instantiatedTooltips[_currentTooltipCount - 1];
		}

		private static List<Tooltip> GetCurrentTooltips()
		{
			List<Tooltip> list = new List<Tooltip>();
			for (int i = 0; i < _currentTooltipCount; i++)
			{
				list.Add(_instantiatedTooltips[i]);
			}
			return list;
		}

		private static Tooltip InstantiateTooltip()
		{
			Tooltip componentInChildren = Object.Instantiate(TooltipSettings.TooltipPrefab, _tooltipParent).GetComponentInChildren<Tooltip>();
			componentInChildren.SetActive(active: false);
			_instantiatedTooltips.Add(componentInChildren);
			return componentInChildren;
		}

		private static bool TryGetTooltip(ITooltipDisplayer tooltipDisplayer, out Tooltip tooltip)
		{
			_tooltipDisplayers.TryGetValue(tooltipDisplayer, out tooltip);
			return tooltip != null;
		}

		public static void PrepareTooltip(ITooltipDisplayer component)
		{
			if (_focusedComponent != null)
			{
				CancelTooltip(_focusedComponent);
			}
			if (TryAppendTooltip(component))
			{
				_focusedComponent = component;
				RegisterToUpdate(register: true);
				RegisterToInputChange(register: true);
			}
		}

		public static bool TryAppendTooltip(ITooltipDisplayer component)
		{
			if (!CanDisplayTooltip(component, out var tooltipTerm))
			{
				return false;
			}
			_timeSinceLastMovement = 0f;
			_currentTooltipCount++;
			Tooltip tooltip = GetTooltip();
			tooltip.SetTerm(tooltipTerm);
			_tooltipDisplayers.TryAdd(component, tooltip);
			switch (TransientManager<InputManager>.Instance.CurrentDevice)
			{
			case EInputDeviceType.KEYBOARD:
				_lastMousePosition = Mouse.current.position.ReadValue();
				break;
			case EInputDeviceType.GAMEPAD:
				_lastMousePosition = GetTooltipScreenPositionFromRectTransform(component.RectTransform);
				break;
			}
			return true;
		}

		public static void CancelTooltip(ITooltipDisplayer component)
		{
			if (component != null && TryGetTooltip(component, out var tooltip))
			{
				tooltip.SetActive(active: false);
				_focusedComponent = null;
				_tooltipDisplayers.Remove(component);
				_currentTooltipCount--;
				if (_currentTooltipCount < 0)
				{
					_currentTooltipCount = 0;
				}
				if (_currentTooltipCount <= 0)
				{
					RegisterToUpdate(register: false);
					RegisterToInputChange(register: false);
				}
			}
		}

		public static void CancelAllTooltips()
		{
			foreach (ITooltipDisplayer item in new List<ITooltipDisplayer>(_tooltipDisplayers.Keys))
			{
				CancelTooltip(item);
			}
			_tooltipDisplayers.Clear();
			_currentTooltipCount = 0;
			RegisterToUpdate(register: false);
			RegisterToInputChange(register: false);
		}

		private static void ShowTooltip(Tooltip tooltip)
		{
			if (TransientManager<InputManager>.Instance.CurrentMap == InputManager.EMap.UI)
			{
				SetTooltipParentPosition();
				tooltip.SetActive(active: true);
			}
		}

		private static void SetTooltipParentPosition()
		{
			ETooltipDirection tooltipDirectionFromScreenPosition = GetTooltipDirectionFromScreenPosition(_lastMousePosition);
			Vector2 vector = Vector2.zero;
			switch (tooltipDirectionFromScreenPosition)
			{
			case ETooltipDirection.LEFT_BOTTOM:
				_tooltipParent.pivot = Vector2.one;
				break;
			case ETooltipDirection.LEFT_TOP:
				_tooltipParent.pivot = Vector2.right;
				break;
			case ETooltipDirection.RIGHT_BOTTOM:
				_tooltipParent.pivot = Vector2.up;
				vector = new Vector2(25f, -25f);
				break;
			case ETooltipDirection.RIGHT_TOP:
				_tooltipParent.pivot = Vector2.zero;
				break;
			}
			_tooltipParent.anchoredPosition = _lastMousePosition + vector;
		}

		private static void HideTooltips()
		{
			foreach (Tooltip instantiatedTooltip in _instantiatedTooltips)
			{
				instantiatedTooltip.SetActive(active: false);
			}
		}

		private static void ResetCounter()
		{
			_timeSinceLastMovement = 0f;
			HideTooltips();
		}

		private static bool CanDisplayTooltip(ITooltipDisplayer component, out string tooltipTerm)
		{
			if (!component.TryGetTooltipTerm(out tooltipTerm))
			{
				return false;
			}
			if (string.IsNullOrWhiteSpace(tooltipTerm))
			{
				return false;
			}
			if (string.IsNullOrWhiteSpace(LocalizationManager.GetTranslation(tooltipTerm)))
			{
				return false;
			}
			if (_tooltipDisplayers.ContainsKey(component))
			{
				return false;
			}
			return true;
		}

		private static void RegisterToUpdate(bool register)
		{
			if (_updateRegistered != register)
			{
				_updateRegistered = register;
				Updater.RegisterChannelCallback(register, EUpdateChannel.CLASSIC, OnUpdate);
			}
		}

		private static void OnUpdate(float deltaTime)
		{
			_timeSinceLastMovement += deltaTime;
			if (TransientManager<InputManager>.Instance.CurrentDevice == EInputDeviceType.KEYBOARD)
			{
				Vector2 vector = Mouse.current.position.ReadValue();
				if (_lastMousePosition != vector)
				{
					_lastMousePosition = vector;
					ResetCounter();
				}
			}
			if (!(_timeSinceLastMovement >= TooltipSettings.TriggerDuration))
			{
				return;
			}
			foreach (Tooltip currentTooltip in GetCurrentTooltips())
			{
				if (!currentTooltip.IsActive)
				{
					ShowTooltip(currentTooltip);
				}
			}
		}

		private static void RegisterToInputChange(bool register)
		{
			if (_inputChangeRegistered != register)
			{
				_inputChangeRegistered = register;
				if (register)
				{
					InputManager.DeviceChanged += OnDeviceChange;
					InputManager.MapChanged += OnInputMapChange;
				}
				else
				{
					InputManager.DeviceChanged -= OnDeviceChange;
					InputManager.MapChanged -= OnInputMapChange;
				}
			}
		}

		private static void OnDeviceChange(EInputDeviceType deviceType)
		{
			ResetCounter();
		}

		private static void OnInputMapChange(InputManager.EMap map)
		{
			if (map != InputManager.EMap.UI)
			{
				CancelAllTooltips();
			}
		}

		public static ETooltipDirection GetTooltipDirectionFromScreenPosition(Vector2 screenPosition)
		{
			bool num = screenPosition.x < (float)Screen.width / 2f;
			bool flag = screenPosition.y < (float)Screen.height / 2f;
			if (!num)
			{
				if (!flag)
				{
					return ETooltipDirection.LEFT_BOTTOM;
				}
				return ETooltipDirection.LEFT_TOP;
			}
			if (!flag)
			{
				return ETooltipDirection.RIGHT_BOTTOM;
			}
			return ETooltipDirection.RIGHT_TOP;
		}

		public static Vector2 GetTooltipScreenPositionFromRectTransform(RectTransform rectTransform)
		{
			if (rectTransform == null)
			{
				return Vector2.zero;
			}
			if (CanvasManager.CurrentMainCanvas != null && CanvasManager.CurrentMainCanvas.renderMode == RenderMode.WorldSpace)
			{
				Vector3 vector = TransientManager<CameraManager>.Instance.Camera.WorldToScreenPoint(rectTransform.position);
				Vector3[] array = new Vector3[4];
				rectTransform.GetWorldCorners(array);
				return GetTooltipDirectionFromScreenPosition(vector) switch
				{
					ETooltipDirection.LEFT_BOTTOM => TransientManager<CameraManager>.Instance.Camera.WorldToScreenPoint(array[0]), 
					ETooltipDirection.LEFT_TOP => TransientManager<CameraManager>.Instance.Camera.WorldToScreenPoint(array[1]), 
					ETooltipDirection.RIGHT_TOP => TransientManager<CameraManager>.Instance.Camera.WorldToScreenPoint(array[2]), 
					ETooltipDirection.RIGHT_BOTTOM => TransientManager<CameraManager>.Instance.Camera.WorldToScreenPoint(array[3]), 
					_ => vector, 
				};
			}
			Vector3[] array2 = new Vector3[4];
			rectTransform.GetWorldCorners(array2);
			return GetTooltipDirectionFromScreenPosition(rectTransform.position) switch
			{
				ETooltipDirection.LEFT_BOTTOM => array2[0], 
				ETooltipDirection.LEFT_TOP => array2[1], 
				ETooltipDirection.RIGHT_TOP => array2[2], 
				ETooltipDirection.RIGHT_BOTTOM => array2[3], 
				_ => rectTransform.position, 
			};
		}
	}
}
