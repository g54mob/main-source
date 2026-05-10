using System;
using CTS.BBT;
using CTS.Core;
using CTS.StockInventory;
using UnityEngine;

namespace CTS
{
	public abstract class UI_StockItem : CTSBehaviour, IGive<StockItemSO>
	{
		[SerializeField]
		[Inject(false)]
		protected UI_StockItemReferences _refs;

		[SerializeField]
		[Range(0f, 100f)]
		protected int _changePerTick = 1;

		[SerializeField]
		[Range(0f, 100f)]
		protected int _changePerShiftTick = 10;

		[InjectScope(EGetScope.Parent)]
		[SerializeField]
		[Inject(false)]
		private SoftReference<ShopBasket> _basket;

		protected StockItemSO _itemData;

		protected StringKey<StockType> _stockType;

		protected ShopBasket Basket => _basket;

		protected override void OnAwake()
		{
			base.OnAwake();
			if (_stockType == Stocks.HumanStockType)
			{
				_refs.QualityContainer.gameObject.SetActive(value: false);
			}
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_refs.MinusButton.HeldTick += OnMinusButtonTick;
			_refs.PlusButton.HeldTick += OnPlusButtonTick;
			GetStock().StockChanged += OnStockChanged;
			Basket.RegisterToChangedEvent(_itemData, OnBasketChanged);
			SetCountText(GetStock().GetStockedCount(_itemData));
			UpdatePriceText();
			OnBasketChanged();
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_refs.MinusButton.HeldTick -= OnMinusButtonTick;
			_refs.PlusButton.HeldTick -= OnPlusButtonTick;
			GetStock().StockChanged -= OnStockChanged;
			Basket?.UnregisterToChangedEvent(_itemData, OnBasketChanged);
		}

		protected abstract BBTStock GetStock();

		protected void OnBasketChanged()
		{
			if (base.gameObject.scene.isLoaded)
			{
				ShopBasket basket = Basket;
				if (!basket)
				{
					throw new NullReferenceException("Couldn't find a basket");
				}
				int stockedCount = GetStock().GetStockedCount(_itemData);
				UpdateStockInfo(stockedCount);
				bool flag = stockedCount > 0;
				_refs.MinusButton.gameObject.SetActive(flag);
				_refs.PlusButton.gameObject.SetActive(flag);
				int count = basket.GetCount(_itemData);
				_refs.ColorTarget.color = ((count > 0) ? _refs.ActiveColor : _refs.InactiveColor);
				if (!flag)
				{
					SetMinMaxText("0");
					return;
				}
				SetMinMaxText(count.ToString());
				_refs.MinusButton.interactable = count > 0;
				_refs.PlusButton.interactable = !basket.IsAtMaximumCapacity(_itemData);
			}
		}

		private void OnStockChanged(StockInventory<StockStack, StockItemSO>.StockChangedData obj)
		{
			OnBasketChanged();
		}

		private void OnMinusButtonTick()
		{
			OnMinusButtonTick(_refs.ShiftActionReference.action.IsPressed());
		}

		private void OnPlusButtonTick()
		{
			OnPlusButtonTick(_refs.ShiftActionReference.action.IsPressed());
		}

		protected virtual void OnMinusButtonTick(bool isShiftPressed)
		{
			ShopBasket basket = Basket;
			if ((bool)basket)
			{
				int count = basket.GetCount(_itemData);
				int num = (isShiftPressed ? _changePerShiftTick : _changePerTick);
				basket.SetCount(_itemData, count - num);
			}
		}

		protected virtual void OnPlusButtonTick(bool isShiftPressed)
		{
			ShopBasket basket = Basket;
			if ((bool)basket)
			{
				int count = basket.GetCount(_itemData);
				int num = (isShiftPressed ? _changePerShiftTick : _changePerTick);
				int count2 = Math.Min(GetStock().GetStockedCount(_itemData), count + num);
				basket.SetCount(_itemData, count2);
			}
		}

		public void Initialize(StockItemSO itemData, StringKey<StockType> stockType)
		{
			_itemData = itemData;
			_refs.IconImage.sprite = _itemData.Icon;
			_stockType = stockType;
		}

		protected void SetMinMaxText(string text)
		{
			_refs.MinMaxText.text = text;
		}

		protected void SetCountText(string text)
		{
			_refs.CountText.text = text;
		}

		protected virtual void SetPriceText(string text)
		{
			_refs.PriceText.text = text;
		}

		protected virtual void SetCountText(int count)
		{
			if (count > 0)
			{
				SetCountText(count.ToString());
			}
			_refs.CountContainer.gameObject.SetActive(count > 0);
		}

		protected void SetQualityText(string text)
		{
			_refs.QualityText.text = text;
		}

		private void UpdateStockInfo(int stockAmount)
		{
			if (stockAmount <= 0)
			{
				SetPriceText("-");
				_refs.CountContainer.gameObject.SetActive(value: false);
				_refs.QualityContainer.gameObject.SetActive(value: false);
				return;
			}
			GetStock().TryPeekFirst(_stockType, _itemData, out var peekedStack);
			SetQualityText(QualityToString(peekedStack.Quality));
			SetPriceText("$" + GetUnitPrice(peekedStack.Quality));
			SetCountText(stockAmount);
			if (!(_stockType == Stocks.HumanStockType))
			{
				_refs.QualityContainer.SetActive(value: true);
			}
		}

		protected virtual string QualityToString(float quality)
		{
			return Math.Round(quality, 1).ToString("N1");
		}

		protected virtual void UpdatePriceText()
		{
			StockStack peekedStack;
			if (GetStock().GetStockedCount(_stockType, _itemData) <= 0)
			{
				SetPriceText("-");
			}
			else if (GetStock().TryPeekFirst(_stockType, _itemData, out peekedStack))
			{
				SetPriceText("$" + GetUnitPrice(peekedStack.Quality));
			}
			else
			{
				SetPriceText("N/A");
			}
		}

		protected virtual int GetUnitPrice(float quality)
		{
			return _itemData.GetUnitPrice(quality);
		}

		public StockItemSO Get()
		{
			return _itemData;
		}
	}
}
