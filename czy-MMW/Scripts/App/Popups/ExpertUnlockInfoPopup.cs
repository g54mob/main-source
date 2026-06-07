using System;
using Factory;
using UnityEngine;

namespace Popups
{
	public class ExpertUnlockInfoPopup : BasePopup
	{
		[Dependency]
		private PopupStack _popupStack;

		[SerializeField]
		private GameObject _tickButton;

		[SerializeField]
		private LocalizedTextUI _infoText;

		private Action _onTick;

		public LocalizedTextUI InfoText => _infoText;

		public void Initialize(Action onConfirmed = null)
		{
			_tickButton.SetActive(value: true);
			_onTick = onConfirmed;
		}

		public void OnTickPressed()
		{
			_popupStack.PopPopup();
			_onTick?.Invoke();
		}
	}
}
