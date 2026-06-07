using System;
using ScheduleOne.Delivery;
using ScheduleOne.DevUtilities;
using ScheduleOne.UI.Items;
using ScheduleOne.UI.Tooltips;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI.Phone.Delivery
{
	public class DeliveryReceiptDisplay : MonoBehaviour
	{
		[SerializeField]
		[Header("Prefabs")]
		private ItemEntryUI ItemEntryPrefab;

		[SerializeField]
		[Header("References")]
		private Text _DestinationLabel;

		[SerializeField]
		private Text _loadingDockLabel;

		[SerializeField]
		private Text _shopLabel;

		[SerializeField]
		private Text _shopDescriptionLabel;

		[SerializeField]
		private RectTransform _ItemEntryContainer;

		[SerializeField]
		private Button _ReorderButton;

		[SerializeField]
		private Tooltip _ReorderTooltip;

		[SerializeField]
		private Text _reorderPriceLabel;

		[SerializeField]
		[Header("Settings")]
		private int _maxItemsShown;

		[SerializeField]
		[Header("Fonts")]
		private ColorFont _generalColorFont;

		[SerializeField]
		private ColorFont _shopTextColorFont;

		private DeliveryReceipt _receipt;

		private ItemEntryUI[] _itemEntries;

		private Action<DeliveryReceipt> _onSelect;

		public Button ReorderButton => null;

		public DeliveryReceipt Receipt => null;

		public void Initialise()
		{
		}

		public void Set(DeliveryReceipt receipt, float deliveryCost, bool canAfford)
		{
		}

		public void SetTooltip(string tooltip)
		{
		}

		public void SetActiveTooltip(bool active)
		{
		}

		public void SubscribeToOnSelect(Action<DeliveryReceipt> callback)
		{
		}

		public void UnsubscribeFromOnSelect(Action<DeliveryReceipt> callback)
		{
		}
	}
}
