using System.Collections.Generic;
using System.Linq;
using Heathen.SteamworksIntegration.API;
using UnityEngine;

namespace Heathen.SteamworksIntegration
{
	public class InventoryManager : MonoBehaviour
	{
		public InventoryChangedEvent evtChanged;

		public SteamMicroTransactionAuthorizationResponce evtTransactionResponce;

		public Currency.Code CurrencyCode => Inventory.Client.LocalCurrencyCode;

		public string CurrencySymbol => Inventory.Client.LocalCurrencySymbol;

		public List<ItemDefinitionObject> Items
		{
			get
			{
				if (SteamSettings.current != null)
				{
					return SteamSettings.Client.inventory.items;
				}
				Debug.LogWarning("You can only fetch the list of items if your using a SteamSettings object");
				return null;
			}
		}

		private void OnEnable()
		{
			if (SteamSettings.current != null)
			{
				SteamSettings.Client.inventory.EventChanged.AddListener(evtChanged.Invoke);
			}
			Inventory.Client.EventSteamMicroTransactionAuthorizationResponse.AddListener(evtTransactionResponce.Invoke);
		}

		private void OnDisable()
		{
			if (SteamSettings.current != null)
			{
				SteamSettings.Client.inventory.EventChanged.RemoveListener(evtChanged.Invoke);
			}
			Inventory.Client.EventSteamMicroTransactionAuthorizationResponse.RemoveListener(evtTransactionResponce.Invoke);
		}

		public ItemDefinitionObject[] GetStoreItems()
		{
			return Items.Where((ItemDefinitionObject i) => !i.Hidden && !i.StoreHidden && i.item_price.Valid).ToArray();
		}
	}
}
