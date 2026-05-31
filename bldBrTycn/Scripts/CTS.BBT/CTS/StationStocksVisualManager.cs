using System;
using System.Collections.Generic;
using CTS.BBT;
using CTS.Core;
using CTS.StockInventory;
using UnityEngine;

namespace CTS
{
	public class StationStocksVisualManager : CTSSingleton<StationStocksVisualManager>
	{
		[SerializeField]
		[Range(0f, 1f)]
		private float _randomRange = 0.2f;

		private int seed;

		private readonly HashSet<StationStock> _stationStocks = new HashSet<StationStock>();

		protected override void SingletonAwake()
		{
			seed = (int)DateTime.Now.Ticks;
		}

		protected override void OnSingletonDestroy()
		{
		}

		protected override void OnEnabled()
		{
			BarFurnitures.OnFurnitureAdded += OnFurnitureAdded;
			BarFurnitures.OnFurnitureRemoved += OnFurnitureRemoved;
			Stocks.BarStock.StockChanged += OnStockChanged;
		}

		protected override void OnDisabled()
		{
			BarFurnitures.OnFurnitureAdded -= OnFurnitureAdded;
			BarFurnitures.OnFurnitureRemoved -= OnFurnitureRemoved;
			Stocks.BarStock.StockChanged -= OnStockChanged;
		}

		private void OnFurnitureAdded(Furniture furniture)
		{
			if ((bool)furniture.Interactor && furniture.Interactor is StationStock stationStock && !(stationStock.VisualSwapper == null))
			{
				_stationStocks.Add(stationStock);
				RecalculateStock(stationStock.Type);
			}
		}

		private void OnFurnitureRemoved(Furniture furniture)
		{
			if ((bool)furniture.Interactor && furniture.Interactor is StationStock stationStock)
			{
				_stationStocks.Remove(stationStock);
				RecalculateStock(stationStock.Type);
			}
		}

		private void OnStockChanged(StockInventory<StockStack, StockItemSO>.StockChangedData stockChangedData)
		{
			UpdateVisuals(stockChangedData.StockCapacity, stockChangedData.StockType);
		}

		public void Refresh()
		{
			RecalculateStock(Stocks.HumanStockType);
			RecalculateStock(Stocks.VampireStockType);
		}

		private void RecalculateStock(StringKey<StockType> stockType)
		{
			if (!base.gameObject.scene.isLoaded)
			{
				return;
			}
			int num = 0;
			foreach (StationStock item in CTSSingleton<BarFurnitures>.Instance.Enumerate<StationStock>())
			{
				if (!(item.Type != stockType))
				{
					num += item.MaxItemCount;
				}
			}
			Stocks.BarStock.SetStockTypeCapacity(stockType, num);
		}

		private void UpdateVisuals(StockCapacity stockCapacity, StringKey<StockType> stockType)
		{
			if (!stockCapacity.MaxCapacity.HasValue)
			{
				return;
			}
			UnityEngine.Random.State state = UnityEngine.Random.state;
			UnityEngine.Random.InitState(seed);
			float num = (float)stockCapacity.CurrentCapacity / (float)stockCapacity.MaxCapacity.Value;
			bool flag = num > 0f && num < 1f;
			foreach (StationStock stationStock in _stationStocks)
			{
				if ((object)stationStock == null)
				{
					Debug.LogException(new NullReferenceException("Station stock is null"));
				}
				else if (!(stationStock.Type != stockType))
				{
					float num2 = num;
					if (flag)
					{
						num2 += UnityEngine.Random.Range(0f - _randomRange, _randomRange);
						num2 = Mathf.Clamp(num2, 0.001f, 0.999f);
					}
					stationStock.VisualSwapper.SwapByPercent(num2);
				}
			}
			UnityEngine.Random.state = state;
		}
	}
}
