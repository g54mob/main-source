using UnityEngine;

namespace Gh.Tk.UI.Dialogs.Merchant
{
	public class WorldMapShopDialog3DUIView : MerchantDialog3DUIView
	{
		[SerializeField]
		private Button3DUIView _fastDeliveryButton;

		[SerializeField]
		private Button3DUIView _normalDeliveryButton;

		private bool _fastDelivery;

		private string _titleTextKey;

		private int _deliveryCost;

		private int _fastDeliveryCost;

		private float _deliveryTimeDaysF;

		private float _fastDeliveryTimeDaysF;

		private ShopMapMarker _shopMapMarker;

		protected override void Awake()
		{
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}

		protected override void Start()
		{
		}

		protected override void SetMaxCost()
		{
		}

		protected override void CostOrMoneyChanged()
		{
		}

		private void RefreshCostUI()
		{
		}

		private void UpdateDeliveryCost()
		{
		}

		protected override void UpdateConfirmButtonTextAndState()
		{
		}

		public void UpdateContent(ShopMapMarker marker)
		{
		}

		private bool BuyItems(bool fastDelivery)
		{
			return false;
		}

		private int GetTotalCost()
		{
			return 0;
		}

		private int GetDeliveryCost()
		{
			return 0;
		}

		protected override void ConfirmButtonClicked()
		{
		}
	}
}
