using UnityEngine;

namespace Presentation.UI.Menus
{
	[CreateAssetMenu(menuName = "Locators/UIMenuLocator", fileName = "UIMenuLocator", order = 0)]
	public class UIMenuLocator : ScriptableObject
	{
		private UIMenu _uiMenu;

		public UIMenu UIMenu => _uiMenu;

		public void SetUIMenu(UIMenu uiMenu)
		{
			_uiMenu = uiMenu;
		}
	}
}
