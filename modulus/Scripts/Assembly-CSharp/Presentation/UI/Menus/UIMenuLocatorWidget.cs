using UnityEngine;

namespace Presentation.UI.Menus
{
	public class UIMenuLocatorWidget : MonoBehaviour
	{
		[SerializeField]
		private UIMenuLocator _uiMenuLocator;

		[SerializeField]
		private UIMenu _uiMenu;

		private void Awake()
		{
			_uiMenuLocator.SetUIMenu(_uiMenu);
		}
	}
}
