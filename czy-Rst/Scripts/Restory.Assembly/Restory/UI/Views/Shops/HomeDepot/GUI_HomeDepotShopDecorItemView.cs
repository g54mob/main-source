using System;
using UnityEngine;

namespace Restory.UI.Views.Shops.HomeDepot
{
	public sealed class GUI_HomeDepotShopDecorItemView : GUI_HomeDepotShopItemView
	{
		[SerializeField]
		private GUI_HomeDepotShopItemCartInteractionIncreaseDecreaseView cartInteractionView;

		public event Action OnAddToCartButtonClicked;

		public event Action OnIncreaseCountInCartButtonClicked;

		public event Action OnDecreaseCountInCartButtonClicked;

		public event Action<int> OnInputValueChanged;

		protected override void OnEnable()
		{
			base.OnEnable();
			cartInteractionView.OnAddToCartButtonClicked += ResolveAddToCartButtonClicked;
			cartInteractionView.OnIncreaseCountInCartButtonClicked += ResolveIncreaseCountInCartButtonClicked;
			cartInteractionView.OnDecreaseCountInCartButtonClicked += ResolveDecreaseCountInCartButtonClicked;
			cartInteractionView.OnInputValueChanged += ResolveInputValueChanged;
		}

		protected override void OnDisable()
		{
			cartInteractionView.OnAddToCartButtonClicked -= ResolveAddToCartButtonClicked;
			cartInteractionView.OnIncreaseCountInCartButtonClicked -= ResolveIncreaseCountInCartButtonClicked;
			cartInteractionView.OnDecreaseCountInCartButtonClicked -= ResolveDecreaseCountInCartButtonClicked;
			cartInteractionView.OnInputValueChanged -= ResolveInputValueChanged;
			base.OnDisable();
		}

		protected override void SetUpViewButtons(int countInCart, bool insufficientFunds)
		{
			cartInteractionView.Initialize(countInCart, insufficientFunds);
		}

		public int UpdateCartInfo(int countInCart, bool insufficientFunds)
		{
			return cartInteractionView.UpdateCartInfo(countInCart, insufficientFunds);
		}

		private void ResolveAddToCartButtonClicked()
		{
			this.OnAddToCartButtonClicked?.Invoke();
		}

		private void ResolveIncreaseCountInCartButtonClicked()
		{
			this.OnIncreaseCountInCartButtonClicked?.Invoke();
		}

		private void ResolveDecreaseCountInCartButtonClicked()
		{
			this.OnDecreaseCountInCartButtonClicked?.Invoke();
		}

		private void ResolveInputValueChanged(int value)
		{
			this.OnInputValueChanged?.Invoke(value);
		}
	}
}
