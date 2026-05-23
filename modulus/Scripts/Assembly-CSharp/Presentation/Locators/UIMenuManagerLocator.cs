using Presentation.UI.Menus;
using UnityEngine;

namespace Presentation.Locators
{
	[CreateAssetMenu(menuName = "Locators/UIMenuManagerLocator", fileName = "UIMenuManagerLocator", order = 0)]
	public class UIMenuManagerLocator : ScriptableObject
	{
		private UIMenuManager _uiMenuManager;

		public UIMenuManager UIMenuManager => _uiMenuManager;

		public void SetUIMenuManager(UIMenuManager uiMenuManager)
		{
			_uiMenuManager = uiMenuManager;
		}
	}
}
