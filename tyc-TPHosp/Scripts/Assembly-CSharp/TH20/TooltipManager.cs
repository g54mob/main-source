using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TH20
{
	[DontSave]
	public class TooltipManager
	{
		private static TooltipManager _instance;

		private readonly InputManager _inputManager;

		private readonly List<TooltipSpawner> _tooltips = new List<TooltipSpawner>();

		private readonly List<Transform> _guiRootStack = new List<Transform>();

		private Transform _topmostGUIRoot;

		private TooltipSpawner _activeTooltip;

		public static TooltipManager Instance => _instance;

		public static void CreateInstance(InputManager inputManager)
		{
			if (_instance != null)
			{
				throw new Exception("TooltipManager has already been created");
			}
			_instance = new TooltipManager(inputManager);
		}

		public static void DestroyInstance()
		{
			if (_instance == null)
			{
				throw new Exception("TooltipManager hasn't been created");
			}
			_instance = null;
		}

		private TooltipManager(InputManager inputManager)
		{
			_inputManager = inputManager;
		}

		public void PushGUIRoot(Transform guiRoot)
		{
			_guiRootStack.Add(guiRoot);
			_topmostGUIRoot = guiRoot;
		}

		public void PopGUIRoot(Transform guiRoot)
		{
			_guiRootStack.RemoveAt(_guiRootStack.Count - 1);
			_topmostGUIRoot = ((_guiRootStack.Count == 0) ? null : _guiRootStack[_guiRootStack.Count - 1]);
		}

		public void Update()
		{
			_activeTooltip = null;
			if (_inputManager.RaycastResultsRaw.Count > 0 && _inputManager.RaycastResultsRaw[0].gameObject != null)
			{
				Canvas componentInParent = _inputManager.RaycastResultsRaw[0].gameObject.transform.GetComponentInParent<Canvas>();
				foreach (RaycastResult item in _inputManager.RaycastResultsRaw)
				{
					if (!(item.gameObject != null) || !(item.gameObject.transform.GetComponentInParent<Canvas>() == componentInParent))
					{
						continue;
					}
					TooltipSpawner component = item.gameObject.GetComponent<TooltipSpawner>();
					if (component != null && component.enabled)
					{
						MenuBase componentInParent2 = item.gameObject.GetComponentInParent<MenuBase>();
						if (componentInParent2 == null || componentInParent2.AreTooltipsEnabled())
						{
							_activeTooltip = component;
							break;
						}
					}
				}
			}
			if (_activeTooltip != null)
			{
				_activeTooltip.CursorOver(GetTransformForTooltip(), _inputManager.GetMousePos());
			}
			if (Camera.main != null && !_inputManager.IsMouseOverGui)
			{
				float num = float.MaxValue;
				TooltipSpawner tooltipSpawner = null;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				foreach (TooltipSpawner tooltip in _tooltips)
				{
					if (tooltip.enabled && tooltip.RayCast(ray, 4000f, out var distance) && distance < num)
					{
						tooltipSpawner = tooltip;
						num = distance;
					}
				}
				if (tooltipSpawner != null)
				{
					tooltipSpawner.CursorOver(GetTransformForTooltip(), _inputManager.GetMousePos());
					_activeTooltip = tooltipSpawner;
				}
			}
			foreach (TooltipSpawner tooltip2 in _tooltips)
			{
				if (tooltip2 != _activeTooltip)
				{
					tooltip2.CursorOut();
				}
			}
		}

		public void Register(TooltipSpawner tooltipSpawner)
		{
			_tooltips.Add(tooltipSpawner);
		}

		public void Unregister(TooltipSpawner tooltipSpawner)
		{
			_tooltips.Remove(tooltipSpawner);
		}

		private Transform GetTransformForTooltip()
		{
			Transform result = _topmostGUIRoot;
			if (_topmostGUIRoot != null)
			{
				string drawOrderGameObjectName = MenuBase.GetDrawOrderGameObjectName(MenuBase.EDrawOrderSlot.Tooltips);
				Transform transform = _topmostGUIRoot.Find(drawOrderGameObjectName);
				if (transform != null)
				{
					result = transform;
				}
			}
			return result;
		}
	}
}
