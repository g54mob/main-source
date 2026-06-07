using System;
using System.Collections.Generic;
using Factory;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace Popups
{
	public class GenericPopup : BasePopup
	{
		[Dependency]
		private IScope _scope;

		[Dependency]
		private PopupStack _popupStack;

		[SerializeField]
		private LocalizedTextUI _headerText;

		[SerializeField]
		private LocalizedTextUI _infoText;

		[SerializeField]
		private LocalizedTextUI _paginationText;

		[SerializeField]
		private TouchButton _tickButton;

		[SerializeField]
		private TouchButton _crossButton;

		[SerializeField]
		private TouchButton _closeButton;

		[SerializeField]
		private TouchButton _leftButton;

		[SerializeField]
		private TouchButton _rightButton;

		private Action _onTick;

		private Action _onCross;

		private List<StringId> _pages;

		private int _currentPageIndex;

		public void Initialise(StringId headerStringId, StringId contentStringId)
		{
			_headerText.SetStringId(_scope, headerStringId);
			_infoText.SetStringId(_scope, contentStringId);
		}

		public void Initialise(StringId headerStringId, [NotNull] StringId[] contentStringIds)
		{
			_tickButton.gameObject.SetActive(value: false);
			_crossButton.gameObject.SetActive(value: false);
			_headerText.SetStringId(_scope, headerStringId);
			_pages = new List<StringId>(contentStringIds);
			SelectPage(0);
		}

		private void SelectPage(int pageIndex)
		{
			_currentPageIndex = Mathf.Clamp(pageIndex, 0, _pages.Count - 1);
			_infoText.SetStringId(_scope, _pages[pageIndex]);
			_paginationText.LocString = StandaloneLocString.CreateNonLocalizedString(_scope, $"{_currentPageIndex + 1} / {_pages.Count}");
		}

		public void OnClosePressed()
		{
			_popupStack.PopPopup();
		}

		public void OnTickPressed()
		{
			_popupStack.PopPopup();
			_onTick?.Invoke();
		}

		public void OnCrossPressed()
		{
			_popupStack.PopPopup();
		}

		public void OnLeftPressed()
		{
			SelectPage(_currentPageIndex - 1);
		}

		public void OnRightPressed()
		{
			SelectPage(_currentPageIndex + 1);
		}
	}
}
