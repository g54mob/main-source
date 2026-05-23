using Presentation.Locators;
using Presentation.UI.Menus;
using Presentation.UI.Menus.FullscreenPage;
using Presentation.UI.Menus.MenuEvents;
using Presentation.UI.Menus.MenuEvents.MenuData;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI
{
	public class FullscreenPageEventButton : MonoBehaviour
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		private ShowUIMenuEvent _showUIMenuEvent;

		[SerializeField]
		private UIMenuLocator _fullscreenPageMenuLocator;

		[SerializeField]
		private UIMenuManagerLocator _uiMenuManagerLocator;

		[SerializeField]
		private FullPagesEnum _pageToOpen;

		[SerializeField]
		private GoBackSourceSO _goBackSource;

		[SerializeField]
		private bool _goBackFirst;

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
			if (_goBackFirst)
			{
				_uiMenuManagerLocator.UIMenuManager.GoBack();
			}
			if (!_uiMenuManagerLocator.UIMenuManager.IsCurrentlyShowing(_fullscreenPageMenuLocator.UIMenu))
			{
				_showUIMenuEvent.Fire(new FullscreenPageUIMenuData(_fullscreenPageMenuLocator.UIMenu, _pageToOpen));
			}
			else if (_fullscreenPageMenuLocator.UIMenu is FullscreenPageUI fullscreenPageUI && fullscreenPageUI.CurrentPage != _pageToOpen)
			{
				fullscreenPageUI.OpenPage(_pageToOpen);
			}
			else
			{
				_uiMenuManagerLocator.UIMenuManager.GoBack(_goBackSource);
			}
		}

		private void Reset()
		{
			TryGetComponent<Button>(out _button);
		}
	}
}
