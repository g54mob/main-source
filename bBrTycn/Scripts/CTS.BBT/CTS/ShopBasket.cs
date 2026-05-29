using System;
using System.Collections.Generic;
using CTS.BBT;
using CTS.Core;
using CTS.StockInventory;
using UnityEngine;

namespace CTS
{
	public abstract class ShopBasket : CTSBehaviour
	{
		public struct BasketValidation
		{
			public ReadOnlyMemory<StockStack> StockValidated;

			public ReadOnlySpan<StockStack>.Enumerator GetEnumerator()
			{
				return StockValidated.Span.GetEnumerator();
			}
		}

		[SerializeField]
		protected BBTStock _stock;

		private readonly Dictionary<StockItemSO, int> _basket = new Dictionary<StockItemSO, int>();

		private readonly Dictionary<StockItemSO, Action> _basketChangedEvents = new Dictionary<StockItemSO, Action>();

		private static readonly List<StockItemSO> _clearedItems = new List<StockItemSO>();

		protected static readonly List<StockStack> _stackRetriever = new List<StockStack>();

		private static StockStack[] _basketValidationAlloc = new StockStack[10];

		public int CurrentTotalPrice { get; private set; }

		public event Action BasketChanged;

		public event Action<BasketValidation> BasketValidated;

		public event Action<int> ValidationPriceChanged;

		public Dictionary<StockItemSO, int>.Enumerator GetEnumerator()
		{
			return _basket.GetEnumerator();
		}

		protected static StockStack[] GetBasketValidationAlloc(int size)
		{
			if (_basketValidationAlloc.Length < size)
			{
				_basketValidationAlloc = new StockStack[size + 5];
			}
			return _basketValidationAlloc;
		}

		protected override void OnAwake()
		{
			_stock.StockChanged += OnStockChanged;
		}

		private void OnDestroy()
		{
			_stock.StockChanged -= OnStockChanged;
		}

		private void OnStockChanged(StockInventory<StockStack, StockItemSO>.StockChangedData changedData)
		{
			RecalculateValidationPrice();
		}

		private void RecalculateValidationPrice()
		{
			int num = CalculatePrice();
			if (num != CurrentTotalPrice)
			{
				CurrentTotalPrice = num;
				this.ValidationPriceChanged?.Invoke(CurrentTotalPrice);
			}
		}

		protected virtual int CalculatePrice()
		{
			int num = 0;
			foreach (KeyValuePair<StockItemSO, int> item in _basket)
			{
				item.Deconstruct(out var key, out var _);
				StockItemSO itemData = key;
				int count = GetCount(itemData);
				count = Math.Min(count, _stock.GetStockedCount(itemData));
				if (count > 0 && _stock.TryPeekFirst(itemData, out var peekedStack))
				{
					int unitPrice = GetUnitPrice(itemData, peekedStack.Quality);
					num += unitPrice * count;
				}
			}
			return num;
		}

		protected virtual int GetUnitPrice(StockItemSO itemData, float quality)
		{
			return itemData.GetUnitPrice(quality);
		}

		public int GetTotalCount(StringKey<StockType> stockType)
		{
			int num = 0;
			foreach (var (stockItemSO2, num3) in _basket)
			{
				if (!(stockItemSO2.StockType != stockType))
				{
					num += num3;
				}
			}
			return num;
		}

		public void ValidateBasket()
		{
			BasketValidation obj = OnValidateBasket();
			this.BasketValidated?.Invoke(obj);
		}

		public abstract BasketValidation OnValidateBasket();

		public bool TryGet(out StockItemSO itemData, out int count)
		{
			using (Dictionary<StockItemSO, int>.Enumerator enumerator = _basket.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					enumerator.Current.Deconstruct(out var key, out var value);
					StockItemSO stockItemSO = key;
					int num = value;
					itemData = stockItemSO;
					count = num;
					SetCount(itemData, 0);
					_basket.Remove(itemData);
					return true;
				}
			}
			itemData = null;
			count = 0;
			return false;
		}

		public int GetTotalCount()
		{
			int num = 0;
			foreach (KeyValuePair<StockItemSO, int> item in _basket)
			{
				item.Deconstruct(out var _, out var value);
				int num2 = value;
				num += num2;
			}
			return num;
		}

		public void RemoveAllFromStock()
		{
			foreach (var (itemData, count) in _basket)
			{
				_stock.RetrieveStock(itemData, count, _stackRetriever, canGetLessThanCount: true);
			}
			ClearBasket();
		}

		public void RegisterToChangedEvent(StockItemSO itemData, Action action)
		{
			if (!_basketChangedEvents.ContainsKey(itemData))
			{
				_basketChangedEvents[itemData] = action;
				return;
			}
			Dictionary<StockItemSO, Action> basketChangedEvents = _basketChangedEvents;
			basketChangedEvents[itemData] = (Action)Delegate.Combine(basketChangedEvents[itemData], action);
		}

		public void UnregisterToChangedEvent(StockItemSO itemData, Action action)
		{
			if (_basketChangedEvents.ContainsKey(itemData))
			{
				Dictionary<StockItemSO, Action> basketChangedEvents = _basketChangedEvents;
				basketChangedEvents[itemData] = (Action)Delegate.Remove(basketChangedEvents[itemData], action);
			}
		}

		private void SendBasketChangedEvent(StockItemSO itemData)
		{
			RecalculateValidationPrice();
			this.BasketChanged?.Invoke();
			if (_basketChangedEvents.TryGetValue(itemData, out var value))
			{
				value?.Invoke();
			}
		}

		public void SetCount(StockItemSO itemData, int count)
		{
			count = ClampItemCount(itemData, count);
			if (!_basket.TryGetValue(itemData, out var value) || value != count)
			{
				_basket[itemData] = count;
				SendBasketChangedEvent(itemData);
			}
		}

		public virtual bool IsAtMaximumCapacity(StockItemSO itemData)
		{
			return GetCount(itemData) >= 100000;
		}

		protected virtual int ClampItemCount(StockItemSO itemData, int count)
		{
			return Math.Clamp(count, 0, 100000);
		}

		public int GetCount(StockItemSO itemData)
		{
			if (!_basket.TryGetValue(itemData, out var value))
			{
				return 0;
			}
			return value;
		}

		public int GetDifferentItemCount()
		{
			int num = 0;
			foreach (KeyValuePair<StockItemSO, int> item in _basket)
			{
				item.Deconstruct(out var _, out var value);
				if (value > 0)
				{
					num++;
				}
			}
			return num;
		}

		public void ClearBasket()
		{
			_clearedItems.Clear();
			foreach (var (item, num2) in _basket)
			{
				if (num2 > 0)
				{
					_clearedItems.Add(item);
				}
			}
			foreach (StockItemSO clearedItem in _clearedItems)
			{
				SetCount(clearedItem, 0);
			}
			_basket.Clear();
		}
	}
}
