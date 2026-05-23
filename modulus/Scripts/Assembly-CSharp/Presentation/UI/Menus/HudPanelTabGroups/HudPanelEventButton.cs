using Presentation.UI.Menus.MenuEvents;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.Menus.HudPanelTabGroups
{
	public class HudPanelEventButton : MonoBehaviour
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		protected ShowHudPanelEvent _showHudPanelEvent;

		[SerializeField]
		protected TabGroupPanelSO _tabGroupPanelSo;

		[SerializeField]
		protected bool _isToggle;

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
			_showHudPanelEvent.Fire(new EmptyHudPanelData(_tabGroupPanelSo, _isToggle));
		}
	}
}
