using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading;
using HeathenEngineering.SteamworksIntegration.API;
using Steamworks;
using UnityEngine;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public struct ItemData : IEquatable<ItemData>, IEquatable<int>, IEquatable<SteamItemDef_t>, IComparable<ItemData>, IComparable<int>, IComparable<SteamItemDef_t>
	{
		public int id;

		[NonSerialized]
		private ItemDefinitionObject _so;

		public ItemDefinitionObject ScriptableObject
		{
			get
			{
				if (SteamSettings.current == null)
				{
					return null;
				}
				if (_so == null)
				{
					ItemData nId = this;
					_so = SteamSettings.Client.inventory.items.FirstOrDefault((ItemDefinitionObject p) => p.id == nId);
				}
				return _so;
			}
			set
			{
				_so = value;
				id = value.id;
			}
		}

		public readonly string Name => Inventory.Client.GetItemDefinitionProperty(new SteamItemDef_t(id), "name");

		public readonly bool HasPrice
		{
			get
			{
				ulong currentPrice;
				ulong basePrice;
				return Inventory.Client.GetItemPrice(new SteamItemDef_t(id), out currentPrice, out basePrice);
			}
		}

		public static Currency.Code CurrencyCode => Inventory.Client.LocalCurrencyCode;

		public static string CurrencySymbol => Inventory.Client.LocalCurrencySymbol;

		public readonly ulong CurrentPrice
		{
			get
			{
				if (Inventory.Client.GetItemPrice(new SteamItemDef_t(id), out var currentPrice, out var _))
				{
					return currentPrice;
				}
				return 0uL;
			}
		}

		public readonly ulong BasePrice
		{
			get
			{
				if (Inventory.Client.GetItemPrice(new SteamItemDef_t(id), out var _, out var basePrice))
				{
					return basePrice;
				}
				return 0uL;
			}
		}

		public readonly List<ItemDetail> GetDetails()
		{
			return Inventory.Client.Details(this);
		}

		public readonly long GetTotalQuantity()
		{
			return Inventory.Client.ItemTotalQuantity(this);
		}

		public readonly bool AddPromoItem(Action<InventoryResult> callback)
		{
			return Inventory.Client.AddPromoItem(new SteamItemDef_t(id), callback);
		}

		public readonly ConsumeOrder[] GetConsumeOrders(uint quantity)
		{
			List<ItemDetail> details = GetDetails();
			if (((IEnumerable<ItemDetail>)details).Sum((Func<ItemDetail, long>)((ItemDetail p) => p.Quantity)) < quantity)
			{
				return null;
			}
			List<ConsumeOrder> list = new List<ConsumeOrder>();
			uint num = 0u;
			int index = 0;
			while (num < quantity)
			{
				uint num2 = (uint)Mathf.Min((int)details[index].Quantity, quantity - num);
				num += num2;
				list.Add(new ConsumeOrder
				{
					detail = details[index].itemDetails,
					quantity = num2
				});
			}
			return list.ToArray();
		}

		public readonly bool Consume(Action<InventoryResult> callback)
		{
			List<ItemDetail> details = GetDetails();
			if (((IEnumerable<ItemDetail>)details).Sum((Func<ItemDetail, long>)((ItemDetail p) => p.Quantity)) < 1)
			{
				return false;
			}
			Inventory.Client.ConsumeItem(details.First((ItemDetail p) => p.Quantity > 0).itemDetails.m_itemId, 1u, callback);
			return true;
		}

		public readonly void Consume(ConsumeOrder order, Action<InventoryResult> callback)
		{
			Inventory.Client.ConsumeItem(order.detail.m_itemId, order.quantity, callback);
		}

		public readonly bool Consume(uint quantity, Action<InventoryResult> callback)
		{
			ConsumeOrder[] orders = GetConsumeOrders(quantity);
			if (orders == null || orders.Length < 1)
			{
				return false;
			}
			List<ItemDetail> details = new List<ItemDetail>();
			EResult eResult = EResult.k_EResultOK;
			BackgroundWorker worker = new BackgroundWorker();
			worker.DoWork += delegate(object sender, DoWorkEventArgs eventArgs)
			{
				ConsumeOrder[] array = orders;
				for (int i = 0; i < array.Length; i++)
				{
					ConsumeOrder consumeOrder = array[i];
					bool wait = true;
					Inventory.Client.ConsumeItem(consumeOrder.detail.m_itemId, consumeOrder.quantity, delegate(InventoryResult r)
					{
						eResult = r.result;
						if (eResult == EResult.k_EResultOK)
						{
							details.AddRange(r.items);
						}
						wait = false;
					});
					while (wait)
					{
						Thread.Sleep(50);
					}
					if (eResult != EResult.k_EResultOK)
					{
						break;
					}
				}
				eventArgs.Result = new InventoryResult
				{
					result = eResult,
					items = details.ToArray()
				};
			};
			worker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs eventArgs)
			{
				InventoryResult obj = (InventoryResult)eventArgs.Result;
				callback?.Invoke(obj);
				worker.Dispose();
			};
			return true;
		}

		public readonly bool GetExchangeEntry(uint quantity, out ExchangeEntry[] entries)
		{
			List<ItemDetail> details = GetDetails();
			if (((IEnumerable<ItemDetail>)details).Sum((Func<ItemDetail, long>)((ItemDetail p) => p.Quantity)) < quantity)
			{
				entries = new ExchangeEntry[0];
				return false;
			}
			List<ExchangeEntry> list = new List<ExchangeEntry>();
			uint num = 0u;
			int num2 = 0;
			while (num < quantity)
			{
				if (details[num2].Quantity <= quantity - num)
				{
					if (details[num2].Quantity > 0)
					{
						list.Add(new ExchangeEntry
						{
							instance = details[num2].ItemId,
							quantity = details[num2].Quantity
						});
						num += details[num2].Quantity;
					}
				}
				else if (details[num2].Quantity > 0)
				{
					uint num3 = quantity - num;
					list.Add(new ExchangeEntry
					{
						instance = details[num2].ItemId,
						quantity = num3
					});
					num += num3;
				}
				num2++;
			}
			entries = list.ToArray();
			return true;
		}

		public readonly void Exchange(IEnumerable<ExchangeEntry> recipeEntries, Action<InventoryResult> callback)
		{
			ExchangeEntry[] array = recipeEntries.ToArray();
			SteamItemInstanceID_t[] array2 = new SteamItemInstanceID_t[array.Length];
			uint[] array3 = new uint[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = array[i].instance;
				array3[i] = array[i].quantity;
			}
			Inventory.Client.ExchangeItems(new SteamItemDef_t(id), array2, array3, callback);
		}

		public readonly void GenerateItem(Action<InventoryResult> callback)
		{
			Inventory.Client.GenerateItems(new SteamItemDef_t[1]
			{
				new SteamItemDef_t(id)
			}, new uint[1] { 1u }, callback);
		}

		public readonly void GenerateItem(uint quantity, Action<InventoryResult> callback)
		{
			Inventory.Client.GenerateItems(new SteamItemDef_t[1]
			{
				new SteamItemDef_t(id)
			}, new uint[1] { quantity }, callback);
		}

		public readonly void StartPurchase(Action<SteamInventoryStartPurchaseResult_t, bool> callback)
		{
			Inventory.Client.StartPurchase(new SteamItemDef_t[1]
			{
				new SteamItemDef_t(id)
			}, new uint[1] { 1u }, callback);
		}

		public readonly void StartPurchase(uint count, Action<SteamInventoryStartPurchaseResult_t, bool> callback)
		{
			Inventory.Client.StartPurchase(new SteamItemDef_t[1]
			{
				new SteamItemDef_t(id)
			}, new uint[1] { count }, callback);
		}

		public readonly bool GetPrice(out ulong currentPrice, out ulong basePrice)
		{
			return Inventory.Client.GetItemPrice(new SteamItemDef_t(id), out currentPrice, out basePrice);
		}

		public readonly void TriggerDrop(Action<InventoryResult> callback)
		{
			Inventory.Client.TriggerItemDrop(new SteamItemDef_t(id), callback);
		}

		public readonly string CurrentPriceString()
		{
			NumberFormatInfo numberFormatInfo = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
			numberFormatInfo.CurrencySymbol = CurrencySymbol;
			return ((double)CurrentPrice / 100.0).ToString("c", numberFormatInfo);
		}

		public readonly string BasePriceString()
		{
			NumberFormatInfo numberFormatInfo = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
			numberFormatInfo.CurrencySymbol = CurrencySymbol;
			return ((double)BasePrice / 100.0).ToString("c", numberFormatInfo);
		}

		public static void RequestPrices(Action<SteamInventoryRequestPricesResult_t, bool> callback)
		{
			Inventory.Client.RequestPrices(callback);
		}

		public static void Update(Action<InventoryResult> callback)
		{
			Inventory.Client.GetAllItems(callback);
		}

		public static ItemData Get(int id)
		{
			return id;
		}

		public static ItemData Get(SteamItemDef_t id)
		{
			return id;
		}

		public static ItemData Get(ItemDefinitionObject item)
		{
			return item.id;
		}

		public readonly int CompareTo(ItemData other)
		{
			return id.CompareTo(other.id);
		}

		public readonly int CompareTo(int other)
		{
			return id.CompareTo(other);
		}

		public readonly int CompareTo(SteamItemDef_t other)
		{
			return id.CompareTo(other);
		}

		public readonly bool Equals(ItemData other)
		{
			return id.Equals(other.id);
		}

		public readonly bool Equals(int other)
		{
			return id.Equals(other);
		}

		public readonly bool Equals(SteamItemDef_t other)
		{
			return id.Equals(other);
		}

		public override readonly bool Equals(object obj)
		{
			return id.Equals(obj);
		}

		public override readonly int GetHashCode()
		{
			return id.GetHashCode();
		}

		public static bool operator ==(ItemData l, ItemData r)
		{
			return l.id == r.id;
		}

		public static bool operator ==(ItemData l, int r)
		{
			return l.id == r;
		}

		public static bool operator ==(ItemData l, SteamItemDef_t r)
		{
			return l.id == r.m_SteamItemDef;
		}

		public static bool operator !=(ItemData l, ItemData r)
		{
			return l.id != r.id;
		}

		public static bool operator !=(ItemData l, int r)
		{
			return l.id != r;
		}

		public static bool operator !=(ItemData l, SteamItemDef_t r)
		{
			return l.id != r.m_SteamItemDef;
		}

		public static implicit operator int(ItemData c)
		{
			return c.id;
		}

		public static implicit operator ItemData(int id)
		{
			return new ItemData
			{
				id = id
			};
		}

		public static implicit operator SteamItemDef_t(ItemData c)
		{
			return new SteamItemDef_t(c.id);
		}

		public static implicit operator ItemData(SteamItemDef_t id)
		{
			return new ItemData
			{
				id = id.m_SteamItemDef
			};
		}
	}
}
