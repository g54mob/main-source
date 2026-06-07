using Presentation.UI.Menus;
using Presentation.UI.Menus.MenuEvents;
using Presentation.UI.Menus.MenuEvents.MenuData;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.SaveUI
{
	public class CampaignLoadUI : MonoBehaviour
	{
		[SerializeField]
		private Button _loadButton;

		[SerializeField]
		private ShowUIMenuEvent _showUIMenuEvent;

		[SerializeField]
		private UIMenuLocator _loadMenuLocator;

		private void Start()
		{
			_loadButton.onClick.AddListener(ShowLoadUI);
		}

		private void OnDestroy()
		{
			_loadButton.onClick.RemoveListener(ShowLoadUI);
		}

		private void ShowLoadUI()
		{
			_showUIMenuEvent.Fire(new UIMenuMenuData(_loadMenuLocator.UIMenu, AbstractUIMenuData.ToggleTypes.DisableFactoryActions | AbstractUIMenuData.ToggleTypes.DisableUIActions));
		}
	}
}
