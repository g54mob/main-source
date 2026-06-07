using System;
using System.Collections.Generic;
using I18n;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs.Merchant
{
	public class MerchantDialog3DUIView : BaseDialog3DUIView
	{
		[SerializeField]
		private Button3DUIView _closeButton;

		[SerializeField]
		private TextMeshProI18n _title;

		[SerializeField]
		protected ShopContent _shopContent;

		[SerializeField]
		protected BuyButton3DUIView _confirmButton;

		[SerializeField]
		protected TextMeshProI18n _confirmButtonText;

		public Action<IEnumerable<Tuple<UIController.PickableStock, int>>> FinishedCallback;

		public bool CloseLarderInfoOnClose { get; set; }

		protected override void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		private void OnCostsChanged(object sender, EventArgs eventArgs)
		{
		}

		protected virtual void CostOrMoneyChanged()
		{
		}

		protected virtual void SetMaxCost()
		{
		}

		protected virtual void UpdateConfirmButtonTextAndState()
		{
		}

		protected virtual bool IsAffordable()
		{
			return false;
		}

		private void OnMoneyChanged(object sender, EventArgs<int> e)
		{
		}

		protected virtual void ConfirmButtonClicked()
		{
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}

		public void UpdateContent(string titleKey, IEnumerable<UIController.PickableStock> pickableStock)
		{
		}

		protected override void CloseInternal(ShowHideAnimationSpeed speed)
		{
		}
	}
}
