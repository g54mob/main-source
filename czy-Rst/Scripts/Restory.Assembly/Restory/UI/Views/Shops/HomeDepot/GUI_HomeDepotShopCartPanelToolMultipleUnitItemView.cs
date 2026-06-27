using System;
using Restory.UserInterface.CommonElements;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UI.Views.Shops.HomeDepot
{
	public sealed class GUI_HomeDepotShopCartPanelToolMultipleUnitItemView : GUI_HomeDepotShopCartPanelItemView
	{
		[SerializeField]
		private GUI_NumberInputField countInCartInputField;

		[SerializeField]
		private Button increaseCountInCartButton;

		[SerializeField]
		private Button decreaseCountInCartButton;

		[SerializeField]
		private Button removeFromCartButton;

		public event Action OnIncreaseCountInCartButtonClicked;

		public event Action OnDecreaseCountInCartButtonClicked;

		public event Action OnRemoveFromCartButtonClicked;

		public event Action<int> OnInputValueChanged;

		protected override void Subscribe()
		{
			base.Subscribe();
			increaseCountInCartButton.onClick.AddListener(ResolveIncreaseCountInCartButtonClicked);
			decreaseCountInCartButton.onClick.AddListener(ResolveDecreaseCountInCartButtonClicked);
			removeFromCartButton.onClick.AddListener(ResolveRemoveFromCartButtonClicked);
			countInCartInputField.OnValueChanged += ResolveInputValueChanged;
		}

		protected override void Unsubscribe()
		{
			increaseCountInCartButton.onClick.RemoveListener(ResolveIncreaseCountInCartButtonClicked);
			decreaseCountInCartButton.onClick.RemoveListener(ResolveDecreaseCountInCartButtonClicked);
			removeFromCartButton.onClick.RemoveListener(ResolveRemoveFromCartButtonClicked);
			countInCartInputField.OnValueChanged -= ResolveInputValueChanged;
			base.Unsubscribe();
		}

		public int UpdateCartInfo(int countInCart)
		{
			return countInCartInputField.ValidateAddApplyCountValue(countInCart);
		}

		private void ResolveIncreaseCountInCartButtonClicked()
		{
			this.OnIncreaseCountInCartButtonClicked?.Invoke();
		}

		private void ResolveDecreaseCountInCartButtonClicked()
		{
			this.OnDecreaseCountInCartButtonClicked?.Invoke();
		}

		private void ResolveRemoveFromCartButtonClicked()
		{
			this.OnRemoveFromCartButtonClicked?.Invoke();
		}

		private void ResolveInputValueChanged(int value)
		{
			this.OnInputValueChanged?.Invoke(value);
		}
	}
}
