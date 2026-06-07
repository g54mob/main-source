using Presentation.UI.Menus;
using Presentation.UI.Menus.MenuEvents;
using Presentation.UI.Menus.MenuEvents.MenuData;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.SaveUI
{
	public class CampaignSaveUI : MonoBehaviour
	{
		[SerializeField]
		private Button _saveButton;

		[SerializeField]
		private ShowUIMenuEvent _showUIMenuEvent;

		[SerializeField]
		private UIMenuLocator _loadMenuLocator;

		[SerializeField]
		private TextInfoPanelContent _tooltip;

		[SerializeField]
		private GameObject _lockedIcon;

		private void Start()
		{
			_saveButton.onClick.AddListener(GoToSaveMenu);
		}

		private void OnDestroy()
		{
			_saveButton.onClick.RemoveListener(GoToSaveMenu);
		}

		private void GoToSaveMenu()
		{
			_showUIMenuEvent.Fire(new UIMenuMenuData(_loadMenuLocator.UIMenu));
		}
	}
}
