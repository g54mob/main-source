using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Data.Variables;
using Presentation.Locators;
using Presentation.UI.Menus.MenuEvents.MenuData;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.Menus.FullscreenPage
{
	public class FullscreenPageUI : UIMenu
	{
		[Serializable]
		private struct ButtonPagePair
		{
			public PageButton PageButton;

			public FullPage Page;

			public int SortingOrder;
		}

		[SerializeField]
		private Button _exitButton;

		[SerializeField]
		private UIMenuManagerLocator _uiMenuManagerLocator;

		[SerializeField]
		private Canvas _canvas;

		[SerializeField]
		private BoolVariableRefSO _fullscreenPageIsActive;

		[SerializeField]
		private SerializedDictionary<FullPagesEnum, ButtonPagePair> _pages = new SerializedDictionary<FullPagesEnum, ButtonPagePair>();

		private FullPagesEnum _currentPage;

		public FullPagesEnum CurrentPage => _currentPage;

		private void Start()
		{
			_exitButton.onClick.AddListener(Exit);
			foreach (KeyValuePair<FullPagesEnum, ButtonPagePair> page in _pages)
			{
				page.Value.Page.Initialize();
				page.Value.Page.HidePage();
				page.Value.PageButton.ID = (int)page.Key;
				PageButton pageButton = page.Value.PageButton;
				pageButton.OnClick = (Action<int>)Delegate.Combine(pageButton.OnClick, new Action<int>(OpenPage));
			}
		}

		private void OnDestroy()
		{
			_exitButton.onClick.RemoveListener(Exit);
			foreach (ButtonPagePair value in _pages.Values)
			{
				PageButton pageButton = value.PageButton;
				pageButton.OnClick = (Action<int>)Delegate.Remove(pageButton.OnClick, new Action<int>(OpenPage));
			}
		}

		private void Exit()
		{
			_uiMenuManagerLocator.UIMenuManager.GoBack();
		}

		public override void ShowMenu(AbstractUIMenuData menuData)
		{
			FullscreenPageUIMenuData fullscreenPageUIMenuData = menuData as FullscreenPageUIMenuData;
			_canvas.gameObject.SetActive(value: true);
			OpenPage(fullscreenPageUIMenuData.PageToOpen);
			_fullscreenPageIsActive.SetValue(value: true);
		}

		public void OpenPage(FullPagesEnum pageToOpen)
		{
			if (pageToOpen != _currentPage)
			{
				HideCurrentPage();
				_currentPage = pageToOpen;
				_pages[pageToOpen].PageButton.ActiveState = true;
				_pages[pageToOpen].Page.ShowPage();
				_canvas.sortingOrder = _pages[pageToOpen].SortingOrder;
			}
		}

		private void HideCurrentPage()
		{
			if (_currentPage != FullPagesEnum.None)
			{
				_pages[_currentPage].PageButton.ActiveState = false;
				_pages[_currentPage].Page.HidePage();
			}
		}

		private void OpenPage(int pageIDToOpen)
		{
			OpenPage((FullPagesEnum)pageIDToOpen);
		}

		public override void HideMenu()
		{
			HideCurrentPage();
			_currentPage = FullPagesEnum.None;
			_canvas.gameObject.SetActive(value: false);
			_fullscreenPageIsActive.SetValue(value: false);
		}
	}
}
