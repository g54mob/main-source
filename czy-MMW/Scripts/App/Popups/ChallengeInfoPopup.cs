using System;
using Factory;
using JetBrains.Annotations;
using UnityEngine;

namespace Popups
{
	public class ChallengeInfoPopup : BasePopup
	{
		[Dependency]
		private PopupStack _popupStack;

		[SerializeField]
		private LocalizedTextUI _headerText;

		[SerializeField]
		private LocalizedTextUI _infoText;

		private Action _onConfirmed;

		public void Initialise(IScope scope, StringId headerStringId, StringId contentStringId, Action onConfirmed = null)
		{
			_headerText.SetStringId(scope, headerStringId);
			_infoText.SetStringId(scope, contentStringId);
			_onConfirmed = onConfirmed;
		}

		public override void OnPopupClosed()
		{
			base.OnPopupClosed();
			_onConfirmed?.Invoke();
		}

		[UsedImplicitly]
		public void ClosePressed()
		{
			_popupStack.PopPopup();
		}

		public override void Reset()
		{
			base.Reset();
		}
	}
}
