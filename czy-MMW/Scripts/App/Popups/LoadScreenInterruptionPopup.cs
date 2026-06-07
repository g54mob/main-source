using System;
using Factory;
using UnityEngine;
using UnityEngine.UI;

namespace Popups
{
	public class LoadScreenInterruptionPopup : BasePopup
	{
		[Dependency]
		private IScope _scope;

		[Dependency]
		private PopupStack _popupStack;

		[SerializeField]
		private TouchButton _closeButton;

		[SerializeField]
		private LocalizedTextUI _mainPromptText;

		[SerializeField]
		private LocalizedTextUI _additionalText;

		private Action _onClose;

		public void Initialise(StringId headerStringId, StringId contentStringId, Action onClose)
		{
			_mainPromptText.SetStringId(_scope, headerStringId);
			_additionalText.SetStringId(_scope, contentStringId);
			_onClose = onClose;
		}

		public void OnCloseButtonPressed()
		{
			_popupStack.PopPopup();
		}

		public override void OnPopupClosed()
		{
			base.OnPopupClosed();
			_onClose?.Invoke();
		}
	}
}
