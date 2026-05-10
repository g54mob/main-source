using CTS.Core;
using UnityEngine;

namespace CTS
{
	public abstract class UI_StoreValidation<TBasket> : CTSBehaviour where TBasket : ShopBasket
	{
		[SerializeField]
		[Inject(false)]
		protected UI_StoreValidateButtons _buttons;

		[InjectScope(EGetScope.Parent)]
		[SerializeField]
		[Inject(false)]
		private SoftReference<ShopBasket> _basket;

		protected TBasket Basket => _basket.Value as TBasket;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_buttons.ValidateButton.onClick.AddListener(OnValidateClick);
			_buttons.ResetButton.onClick.AddListener(OnResetClick);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_buttons.ValidateButton.onClick.RemoveListener(OnValidateClick);
			_buttons.ResetButton.onClick.RemoveListener(OnResetClick);
		}

		protected void OnValidateClick()
		{
			Basket.ValidateBasket();
		}

		protected void OnResetClick()
		{
			Basket.ClearBasket();
		}

		protected void SetInfoText(string text)
		{
			_buttons.InfoText?.SetText(text);
		}

		protected void EnableInfoText(bool active)
		{
			_buttons.InfoTextContainer.SetActive(active);
		}
	}
}
