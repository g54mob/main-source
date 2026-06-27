using System;
using Restory.UserInterface.CommonElements;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UI.Views.Shops.HomeDepot
{
	public abstract class GUI_HomeDepotShopCartPanelSingleUnitItemView : GUI_HomeDepotShopCartPanelItemView
	{
		[SerializeField]
		private GUI_AnimatedButtonView removeFromCartButton;

		[SerializeField]
		private Button deleteFromCartButton;

		public event Action OnRemoveFromCartButtonClicked;

		protected override void Subscribe()
		{
			base.Subscribe();
			removeFromCartButton.OnAnimationStart += ResolveRemoveFromCartButtonClicked;
			deleteFromCartButton.onClick.AddListener(ResolveRemoveFromCartButtonClicked);
		}

		protected override void Unsubscribe()
		{
			removeFromCartButton.OnAnimationStart -= ResolveRemoveFromCartButtonClicked;
			deleteFromCartButton.onClick.RemoveListener(ResolveRemoveFromCartButtonClicked);
			base.Unsubscribe();
		}

		private void ResolveRemoveFromCartButtonClicked()
		{
			this.OnRemoveFromCartButtonClicked?.Invoke();
		}
	}
}
