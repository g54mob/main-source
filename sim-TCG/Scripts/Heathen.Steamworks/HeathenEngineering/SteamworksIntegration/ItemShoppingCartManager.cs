using System;
using System.Collections.Generic;
using System.Linq;
using HeathenEngineering.SteamworksIntegration.API;
using Steamworks;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.SteamworksIntegration
{
	public class ItemShoppingCartManager : MonoBehaviour
	{
		[Serializable]
		public class StartPurchaseError : UnityEvent<EResult>
		{
		}

		[Serializable]
		public class StartPurchaseSuccess : UnityEvent<SteamInventoryStartPurchaseResult_t>
		{
		}

		[Serializable]
		public class OrderAuthorization : UnityEvent<ItemEntry[], bool>
		{
		}

		[Serializable]
		public struct ItemEntry
		{
			public ItemDefinitionObject item;

			public int quantity;
		}

		public StartPurchaseError evtStartPurchaseError;

		public StartPurchaseSuccess evtStartPurchaseSuccess;

		public OrderAuthorization evtOrderAuthorization;

		private SteamInventoryStartPurchaseResult_t? _result;

		public List<ItemEntry> items = new List<ItemEntry>();

		public bool OrderPending => _result.HasValue;

		public ulong OrderId
		{
			get
			{
				if (!_result.HasValue)
				{
					return 0uL;
				}
				return _result.Value.m_ulOrderID;
			}
		}

		public ulong TransactionId
		{
			get
			{
				if (!_result.HasValue)
				{
					return 0uL;
				}
				return _result.Value.m_ulTransID;
			}
		}

		private void Start()
		{
			Inventory.Client.EventSteamMicroTransactionAuthorizationResponse.AddListener(HandleAuthorizationResponce);
		}

		private void OnDestroy()
		{
			Inventory.Client.EventSteamMicroTransactionAuthorizationResponse.RemoveListener(HandleAuthorizationResponce);
		}

		private void HandleAuthorizationResponce(AppId_t appId, ulong orderId, bool authorized)
		{
			if (OrderPending && appId == App.Id && orderId == OrderId)
			{
				ItemEntry[] arg = items.ToArray();
				if (authorized)
				{
					items.Clear();
				}
				_result = null;
				evtOrderAuthorization.Invoke(arg, authorized);
			}
		}

		public void Add(ItemDefinitionObject item, int count)
		{
			if (OrderPending)
			{
				Debug.LogWarning("Add - Attempted to add items with a purchase pending, wait for order authorization responce or call ClearPending before starting a new one.");
				return;
			}
			ItemEntry item2 = items.FirstOrDefault((ItemEntry x) => x.item == item);
			items.RemoveAll((ItemEntry p) => p.item == item);
			item2.item = item;
			item2.quantity += count;
			if (item2.quantity > 0)
			{
				items.Add(item2);
			}
		}

		public void Set(ItemDefinitionObject item, int count)
		{
			if (OrderPending)
			{
				Debug.LogWarning("Set - Attempted to set item quantity with a purchase pending, wait for order authorization responce or call ClearPending before starting a new one.");
				return;
			}
			if (count <= 0)
			{
				items.RemoveAll((ItemEntry p) => p.item == item);
				return;
			}
			ItemEntry item2 = items.FirstOrDefault((ItemEntry x) => x.item == item);
			if (item2.quantity != count)
			{
				items.RemoveAll((ItemEntry p) => p.item == item);
				item2.item = item;
				item2.quantity = count;
				items.Add(item2);
			}
		}

		public int Get(ItemDefinitionObject item)
		{
			return items.FirstOrDefault((ItemEntry x) => x.item == item).quantity;
		}

		public ulong TotalPrice()
		{
			ulong num = 0uL;
			foreach (ItemEntry item in items)
			{
				if (item.item != null && item.quantity > 0)
				{
					num += (ulong)((long)item.item.CurrentPrice * (long)item.quantity);
				}
			}
			return num;
		}

		public string TotalPriceSymbolledString()
		{
			ulong num = TotalPrice();
			return Inventory.Client.LocalCurrencySymbol + ((double)num * 0.01).ToString("0.00");
		}

		public string TotalPriceCurrencyCodeString()
		{
			return ((double)TotalPrice() * 0.01).ToString("0.00") + " " + Inventory.Client.LocalCurrencyCode;
		}

		public void StartPurchase()
		{
			StartPurchase(null);
		}

		public void StartPurchase(Action<SteamInventoryStartPurchaseResult_t, bool> callback)
		{
			if (OrderPending)
			{
				Debug.LogWarning("StartPurchase - Attempted to start a purcahse with a purchase pending, wait for order authorization responce or call ClearPending before starting a new one.");
				return;
			}
			items.RemoveAll((ItemEntry p) => p.item == null || p.quantity <= 0);
			SteamItemDef_t[] array = new SteamItemDef_t[items.Count];
			uint[] array2 = new uint[items.Count];
			for (int num = 0; num < items.Count; num++)
			{
				ItemEntry itemEntry = items[num];
				array[num] = itemEntry.item.Id;
				array2[num] = ((itemEntry.quantity > 0) ? ((uint)itemEntry.quantity) : 0u);
			}
			Inventory.Client.StartPurchase(array, array2, delegate(SteamInventoryStartPurchaseResult_t result, bool error)
			{
				if (error)
				{
					Debug.LogError("StartPurchase - IO Error reported by Steam");
					evtStartPurchaseError.Invoke(EResult.k_EResultIOFailure);
				}
				else if (result.m_result != EResult.k_EResultOK)
				{
					Debug.LogError(string.Format("{0} - Error reported by Steam: {1}", "StartPurchase", result.m_result));
					evtStartPurchaseError.Invoke(result.m_result);
				}
				else
				{
					_result = result;
					evtStartPurchaseSuccess.Invoke(result);
				}
				callback?.Invoke(result, error);
			});
		}

		public void ClearPending(bool clearCart = false)
		{
			if (OrderPending)
			{
				Debug.LogWarning(string.Format("{0}(clearCart = {1}) - Clearing a pending order before the Authorization Responce is returned does not cancel the order, the order may still complete at a later time but will be ignored by the cart.", "ClearPending", clearCart));
				_result = null;
				if (clearCart)
				{
					items.Clear();
				}
			}
		}
	}
}
