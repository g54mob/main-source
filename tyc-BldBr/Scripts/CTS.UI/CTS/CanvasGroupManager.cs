using System;
using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace CTS
{
	public class CanvasGroupManager : MonoSingleton<CanvasGroupManager>
	{
		private List<CanvasGroupController> _openedControllers = new List<CanvasGroupController>();

		private Dictionary<StringKey, CanvasGroupController> _activeControllers = new Dictionary<StringKey, CanvasGroupController>();

		[SerializeField]
		private InputActionReference _quitescapePanel;

		[SerializeField]
		private InputActionReference _quitmousebuttonPanel;

		public ReadOnlyList<CanvasGroupController> OpenedControllers => _openedControllers;

		public static event Action OpenedControllersChanged;

		protected override void SingletonAwake()
		{
			CanvasGroupController.SlidingPanel += OnPanelOpen;
			SceneManager.sceneLoaded += OnSceneLoaded;
			_quitescapePanel.action.performed += OnInputEscape;
			_quitmousebuttonPanel.action.performed += OnInputMouse;
		}

		protected override void OnSingletonDestroy()
		{
			CanvasGroupController.SlidingPanel -= OnPanelOpen;
			SceneManager.sceneLoaded -= OnSceneLoaded;
			_quitescapePanel.action.performed -= OnInputEscape;
			_quitmousebuttonPanel.action.performed -= OnInputMouse;
		}

		private void OnInputEscape(InputAction.CallbackContext obj)
		{
			if (OpenedControllers.Count <= 0)
			{
				if (WorldSelector.IsAnythingSelected())
				{
					WorldSelector.DeselectAll();
				}
			}
			else
			{
				TryExitCurrentWithEscape();
			}
		}

		private void OnInputMouse(InputAction.CallbackContext obj)
		{
			if (OpenedControllers.Count > 0 && !WorldSelector.PointerIsOverUI && !WorldSelector.IsHoveringSomething() && !WorldSelector.IsAnythingSelected())
			{
				TryExitCurrentWithMouse();
			}
		}

		private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
		{
			CleanCanvases();
		}

		public void AddController(StringKey key, CanvasGroupController controller)
		{
			if (_activeControllers.TryGetValue(key, out var value) && value != null)
			{
				Debug.LogError("Cannot add canvas " + controller.name + ". A canvas with the key " + key.ToString() + " is already present (" + value.name + ")!", value);
			}
			else
			{
				_activeControllers[key] = controller;
			}
		}

		public void RemoveController(StringKey key)
		{
			_activeControllers.Remove(key);
		}

		public bool TryGet(StringKey key, out CanvasGroupController controller)
		{
			return _activeControllers.TryGetValue(key, out controller);
		}

		public void CleanCanvases()
		{
			for (int num = OpenedControllers.Count - 1; num >= 0; num--)
			{
				if (OpenedControllers[num] == null)
				{
					_openedControllers.RemoveAt(num);
				}
			}
		}

		private CanvasGroupController GetLastOpenedPanel()
		{
			CanvasGroupController canvasGroupController = null;
			while (canvasGroupController == null && OpenedControllers.Count > 0)
			{
				canvasGroupController = OpenedControllers[^1];
				if (canvasGroupController == null)
				{
					_openedControllers.RemoveAt(OpenedControllers.Count - 1);
				}
			}
			return canvasGroupController;
		}

		private void TryExitCurrentWithEscape()
		{
			if (OpenedControllers.Count <= 0)
			{
				return;
			}
			CanvasGroupController lastOpenedPanel = GetLastOpenedPanel();
			if (lastOpenedPanel == null || (lastOpenedPanel.TryGetComponent<CanvasExitCondition>(out var component) && !component.CanBeExitedWithEscape()))
			{
				return;
			}
			if (WorldSelector.IsAnythingSelected())
			{
				WorldSelector.Deselect(WorldSelector.GetLastSelected());
				return;
			}
			lastOpenedPanel.QuickHide();
			if (_openedControllers.Remove(lastOpenedPanel))
			{
				CanvasGroupManager.OpenedControllersChanged?.Invoke();
			}
		}

		private void TryExitCurrentWithMouse()
		{
			if (OpenedControllers.Count <= 0)
			{
				return;
			}
			CanvasGroupController lastOpenedPanel = GetLastOpenedPanel();
			if (!(lastOpenedPanel == null) && (!lastOpenedPanel.TryGetComponent<CanvasExitCondition>(out var component) || component.CanBeExitedWithMouse()))
			{
				lastOpenedPanel.QuickHide();
				if (_openedControllers.Remove(lastOpenedPanel))
				{
					CanvasGroupManager.OpenedControllersChanged?.Invoke();
				}
			}
		}

		private void OnPanelOpen(CanvasGroupController controller, bool value)
		{
			if (!controller.TryGetComponent<CanvasExitCondition>(out var _))
			{
				return;
			}
			if (value)
			{
				if (!OpenedControllers.Contains(controller))
				{
					_openedControllers.Add(controller);
					CanvasGroupManager.OpenedControllersChanged?.Invoke();
				}
			}
			else if (_openedControllers.Remove(controller))
			{
				CanvasGroupManager.OpenedControllersChanged?.Invoke();
			}
		}
	}
}
