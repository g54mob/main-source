using UnityEngine;

namespace DV.UIFramework
{
	public class UIMenuRequester : MonoBehaviour
	{
		public UIMenuController targetMenuController;

		public int requestedMenuIndex;

		private IMarkable button;

		private UIMenu targetMenu;

		private void Awake()
		{
			if (targetMenuController == null)
			{
				Debug.LogError("UIMenuRequester '" + base.name + "' is missing a UIMenuController reference", this);
				base.enabled = false;
				return;
			}
			button = GetComponent<IMarkable>();
			if (button == null)
			{
				Debug.LogError("UIMenuRequester '" + base.name + "' couldn't find IMarkable component.", this);
				base.enabled = false;
				return;
			}
			if (requestedMenuIndex < 0 || requestedMenuIndex >= targetMenuController.controlledMenus.Count)
			{
				Debug.LogWarning(string.Format("{0} '{1}' {2} {3} is out of target menu's range ({4})", "UIMenuRequester", base.name, "requestedMenuIndex", requestedMenuIndex, targetMenuController.controlledMenus.Count - 1), this);
			}
			requestedMenuIndex = Mathf.Clamp(requestedMenuIndex, 0, targetMenuController.controlledMenus.Count - 1);
			targetMenu = targetMenuController.controlledMenus[requestedMenuIndex];
		}

		private void OnEnable()
		{
			if (button != null)
			{
				button.Clicked += OnButtonClicked;
			}
			if ((bool)targetMenuController)
			{
				targetMenuController.MenuChanged += OnMenuChanged;
			}
			OnMenuChanged();
		}

		private void OnDisable()
		{
			if (button != null)
			{
				button.Clicked -= OnButtonClicked;
			}
			if ((bool)targetMenuController)
			{
				targetMenuController.MenuChanged -= OnMenuChanged;
			}
		}

		private void OnMenuChanged(UIMenu _ = null)
		{
			bool marked = targetMenuController.ActiveMenu == targetMenu && targetMenu != null;
			button.ToggleMarked(marked);
		}

		private void OnButtonClicked(IClickable clickable)
		{
			if (clickable.IsInteractable && targetMenuController != null)
			{
				targetMenuController.SwitchMenu(requestedMenuIndex);
			}
		}
	}
}
