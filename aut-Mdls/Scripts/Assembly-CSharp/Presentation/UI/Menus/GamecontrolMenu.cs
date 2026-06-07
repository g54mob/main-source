using Data.GameState;
using Presentation.Locators;
using Presentation.UI.Menus.MenuEvents.MenuData;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.Menus
{
	public class GamecontrolMenu : UIMenu
	{
		[SerializeField]
		protected UIMenuManagerLocator _uiMenuManagerLocator;

		[SerializeField]
		protected PauseStateData _pauseState;

		[SerializeField]
		private Button _backgroundButton;

		[SerializeField]
		private GoBackSourceSO _gameControlMenuGoBackSource;

		protected void GoBack()
		{
			_uiMenuManagerLocator.UIMenuManager.GoBack(_gameControlMenuGoBackSource);
		}

		public override void ShowMenu(AbstractUIMenuData menuData)
		{
			base.gameObject.SetActive(value: true);
			if (_pauseState != null && _pauseState.CanSetPauseState())
			{
				_pauseState.SetPauseState(active: true);
			}
		}

		public override void HideMenu()
		{
			if (_pauseState != null && _pauseState.CanSetPauseState())
			{
				_pauseState.SetPauseState(active: false);
			}
			base.gameObject.SetActive(value: false);
		}

		protected virtual void Awake()
		{
			_backgroundButton.onClick.AddListener(GoBack);
		}

		protected virtual void OnDestroy()
		{
			_backgroundButton.onClick.RemoveListener(GoBack);
		}
	}
}
