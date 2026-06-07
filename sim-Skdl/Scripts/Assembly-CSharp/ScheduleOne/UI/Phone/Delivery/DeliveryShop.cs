using System;
using System.Collections.Generic;
using ScheduleOne.Delivery;
using ScheduleOne.Property;
using ScheduleOne.UI.Shop;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI.Phone.Delivery
{
	public class DeliveryShop : MonoBehaviour
	{
		[Header("References")]
		public Button BackButton;

		public RectTransform ListingContainer;

		public Text DeliveryFeeLabel;

		public Text ItemTotalLabel;

		public Text OrderTotalLabel;

		public Text DeliveryTimeLabel;

		public Button OrderButton;

		public Text OrderButtonNote;

		public Dropdown DestinationDropdown;

		public Dropdown LoadingDockDropdown;

		[Header("Settings")]
		public string MatchingShopInterfaceName;

		public Color ShopColor;

		public bool AvailableByDefault;

		public ListingEntry ListingEntryPrefab;

		private List<ListingEntry> listingEntries;

		private ScheduleOne.Property.Property destinationProperty;

		private int loadingDockIndex;

		private Action<DeliveryShop> _onSelect;

		public ShopInterface MatchingShop { get; private set; }

		public bool IsOpen { get; private set; }

		public Action<DeliveryShop> OnSelect
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Initialize()
		{
		}

		private void FixedUpdate()
		{
		}

		public void Open()
		{
		}

		public void Close()
		{
		}

		public void SubmitOrder(string originalDeliveryID)
		{
		}

		private int GetDeliveryTime(int itemCount)
		{
			return 0;
		}

		public void Reorder(DeliveryReceipt receipt)
		{
		}

		public bool CanReorder(DeliveryReceipt receipt, out string reason)
		{
			reason = null;
			return false;
		}

		public float GetDeliveryCost(DeliveryReceipt receipt)
		{
			return 0f;
		}

		public void RefreshShop()
		{
		}

		public void ResetCart()
		{
		}

		private void RefreshCart()
		{
		}

		private void RefreshOrderButton()
		{
		}

		public bool CanOrder(out string reason)
		{
			reason = null;
			return false;
		}

		public bool HasActiveDelivery()
		{
			return false;
		}

		public bool WillCartFitInVehicle()
		{
			return false;
		}

		public void RefreshDestinationUI()
		{
		}

		private void DestinationDropdownSelected(int index)
		{
		}

		private List<ScheduleOne.Property.Property> GetPotentialDestinations()
		{
			return null;
		}

		public void RefreshLoadingDockUI()
		{
		}

		private void LoadingDockDropdownSelected(int index)
		{
		}

		private float GetCartCost()
		{
			return 0f;
		}

		private float GetDeliveryFee()
		{
			return 0f;
		}

		private int GetOrderItemCount()
		{
			return 0;
		}

		private void RefreshEntryOrder()
		{
		}

		private void RefreshEntriesLocked()
		{
		}
	}
}
