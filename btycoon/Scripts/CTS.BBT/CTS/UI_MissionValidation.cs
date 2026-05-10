using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class UI_MissionValidation : UI_StoreValidation<MissionBasket>
	{
		[SerializeField]
		private LocalizedString _reserveString;

		[SerializeField]
		private LocalizedString _sendString;

		private bool? _canSend;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			base.Basket.BasketChanged += OnBasketChanged;
			OnBasketChanged();
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			MissionBasket basket = base.Basket;
			if ((bool)basket)
			{
				basket.BasketChanged -= OnBasketChanged;
			}
			_canSend = null;
		}

		private void OnBasketChanged()
		{
			MissionBasket basket = base.Basket;
			if (basket.GetTotalCount() <= 0)
			{
				_buttons.ValidateText.text = _reserveString.GetLocalizedString();
				_buttons.ValidateButton.interactable = false;
				return;
			}
			_buttons.ValidateButton.interactable = true;
			bool flag = basket.WillCurrentBasketFinishMission();
			if (_canSend != flag)
			{
				_canSend = flag;
				if (_canSend.Value)
				{
					_buttons.ValidateText.text = _sendString.GetLocalizedString();
				}
				else
				{
					_buttons.ValidateText.text = _reserveString.GetLocalizedString();
				}
			}
		}
	}
}
