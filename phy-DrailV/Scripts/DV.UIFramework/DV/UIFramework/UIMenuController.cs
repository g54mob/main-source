using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DV.Utils;
using UnityEngine;

namespace DV.UIFramework
{
	[ExecuteAfter(typeof(DefaultOrder))]
	public class UIMenuController : MonoBehaviour
	{
		public List<UIMenu> controlledMenus = new List<UIMenu>();

		public int defaultMenuIndex;

		public bool openDefaultMenuOnEnable = true;

		public UIMenu ActiveMenu { get; protected set; }

		public int ActiveIndex => controlledMenus.IndexOf(ActiveMenu);

		public event Action<UIMenu> MenuChanged;

		private void Start()
		{
			for (int num = controlledMenus.Count - 1; num >= 0; num--)
			{
				if (controlledMenus[num] == null)
				{
					Debug.LogError(string.Format("{0} '{1}' had null menu at index {2}, it was removed from the list", "UIMenuController", base.name, num), this);
					controlledMenus.RemoveAt(num);
				}
			}
			if (controlledMenus.Count == 0)
			{
				Debug.LogError("UIMenuController '" + base.name + "' doesn't have any menus assigned", this);
			}
			else if (openDefaultMenuOnEnable && (defaultMenuIndex < 0 || defaultMenuIndex >= controlledMenus.Count))
			{
				Debug.LogError("UIMenuController '" + base.name + "' defaultMenuIndex is out of range, will be clamped", this);
				defaultMenuIndex = Mathf.Clamp(defaultMenuIndex, 0, controlledMenus.Count - 1);
			}
			if (openDefaultMenuOnEnable && controlledMenus.Count != 0)
			{
				SwitchMenu(defaultMenuIndex);
			}
			else if (ActiveMenu == null)
			{
				CloseAllMenus();
			}
		}

		public static UniTask WaitForSwitchPreventer(GameObject root)
		{
			IUIMenuSwitchPreventer[] componentsInChildren = root.GetComponentsInChildren<IUIMenuSwitchPreventer>();
			foreach (IUIMenuSwitchPreventer iUIMenuSwitchPreventer in componentsInChildren)
			{
				UniTask result = iUIMenuSwitchPreventer.RequestSwitch();
				if (!result.Status.IsCompleted())
				{
					GameObject gameObject = iUIMenuSwitchPreventer.GetGameObject();
					string text = gameObject?.name ?? "(unknown)";
					Debug.Log("UIMenuController was prevented from switching by '" + text + "', waiting for the request to be resolved", gameObject);
					return result;
				}
			}
			return UniTask.CompletedTask;
		}

		public void SwitchMenu(int index)
		{
			SwitchMenuTask(index).Forget();
		}

		public UniTask SwitchMenuTask(int index)
		{
			return WaitForSwitchPreventer(base.gameObject).ContinueWith(delegate
			{
				Debug.Log(string.Format("{0} proceeding with switching the menu to index {1}", "UIMenuController", index));
				if (controlledMenus.Count == 0)
				{
					Debug.LogWarning("UIMenuController '" + base.name + "' doesn't have any menus assigned", this);
				}
				else
				{
					index = Mathf.Clamp(index, 0, controlledMenus.Count - 1);
					OpenMenu(controlledMenus[index]);
				}
			});
		}

		public void CloseAllMenus()
		{
			foreach (UIMenu controlledMenu in controlledMenus)
			{
				controlledMenu.ToggleMenu(open: false);
			}
			ActiveMenu = null;
		}

		private void OnMenuOpenRequested(UIMenu requestedMenu)
		{
			OpenMenu(requestedMenu);
		}

		private void OpenMenu(UIMenu menuToOpen)
		{
			if (ActiveMenu == menuToOpen)
			{
				return;
			}
			ActiveMenu = null;
			foreach (UIMenu controlledMenu in controlledMenus)
			{
				if (!(controlledMenu == null))
				{
					if (controlledMenu == menuToOpen)
					{
						controlledMenu.ToggleMenu(open: true);
						ActiveMenu = menuToOpen;
					}
					else
					{
						controlledMenu.ToggleMenu(open: false);
					}
				}
			}
			this.MenuChanged?.Invoke(ActiveMenu);
		}
	}
}
