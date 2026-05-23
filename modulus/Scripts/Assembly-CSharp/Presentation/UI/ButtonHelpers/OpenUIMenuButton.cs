using NaughtyAttributes;
using Presentation.UI.Menus;
using Presentation.UI.Menus.MenuEvents;
using Presentation.UI.Menus.MenuEvents.MenuData;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.ButtonHelpers
{
	public class OpenUIMenuButton : MonoBehaviour
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		private ShowUIMenuEvent _showUIMenuEvent;

		[SerializeField]
		private UIMenuLocator _uiMenuLocator;

		[SerializeField]
		[EnumFlags]
		private AbstractUIMenuData.ToggleTypes _uiToggles;

		[SerializeField]
		private AbstractUIMenuData.UIDomain _uiDomain;

		private void Awake()
		{
			_button.onClick.AddListener(OnButtonClicked);
		}

		private void OnDestroy()
		{
			_button.onClick.RemoveListener(OnButtonClicked);
		}

		private void OnButtonClicked()
		{
			_showUIMenuEvent.Fire(new UIMenuEmptyData(_uiMenuLocator.UIMenu, _uiDomain, _uiToggles));
		}
	}
}
