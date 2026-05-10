using System;
using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.StockInventory;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class Deliveries : MonoSingleton<Deliveries>
	{
		private List<Delivery> _currentDeliveries = new List<Delivery>();

		private Dictionary<float, Delivery> _deliveriesThisFrame = new Dictionary<float, Delivery>();

		private readonly Stack<Delivery> _deliveryPool = new Stack<Delivery>();

		public ReadOnlyList<Delivery> CurrentDeliveries => _currentDeliveries;

		public static event Action<Delivery> DeliveryCreated;

		public static event Action<Delivery> DeliveryCompleted;

		public int GetStockTypeAmountInCurrentDeliveries(StringKey<StockType> stockType)
		{
			int num = 0;
			foreach (Delivery currentDelivery in _currentDeliveries)
			{
				if (currentDelivery.DeliveryAmounts.TryGetValue(stockType, out var value))
				{
					num += value;
				}
			}
			return num;
		}

		private void Update()
		{
			for (int num = _currentDeliveries.Count - 1; num >= 0; num--)
			{
				UpdateDelivery(_currentDeliveries[num]);
			}
		}

		private void LateUpdate()
		{
			if (_deliveriesThisFrame.Count > 0)
			{
				_deliveriesThisFrame.Clear();
			}
		}

		private void GameData_OnLoadingFinished()
		{
			for (int i = 0; i < _currentDeliveries.Count; i++)
			{
				Deliveries.DeliveryCreated?.Invoke(_currentDeliveries[i]);
				_currentDeliveries[i].RecreateAmount();
			}
		}

		private void UpdateDelivery(Delivery delivery)
		{
			delivery.ArrivalTime -= Time.deltaTime;
			if (delivery.ArrivalTime > 0f)
			{
				return;
			}
			foreach (var (stockType, amount) in delivery.DeliveryAmounts)
			{
				if (!Stocks.BarStock.GetStockTypeCapacity(stockType).HasCapacityFor(amount))
				{
					return;
				}
			}
			for (int num2 = delivery.Deliverables.Count - 1; num2 >= 0; num2--)
			{
				StockStack itemStack = delivery.Deliverables[num2];
				Stocks.TryAdd(ref itemStack);
			}
			_currentDeliveries.Remove(delivery);
			Deliveries.DeliveryCompleted?.Invoke(delivery);
			_deliveryPool.Push(delivery);
		}

		private Delivery GetDelivery()
		{
			Delivery delivery = ((_deliveryPool.Count <= 0) ? new Delivery() : _deliveryPool.Pop());
			delivery.Reset();
			return delivery;
		}

		public void CreateDeliveries(List<StockStack> deliverables)
		{
			foreach (StockStack deliverable in deliverables)
			{
				if (_deliveriesThisFrame.TryGetValue(deliverable.ItemData.TimeForCommand, out var value))
				{
					value.AddDeliverable(deliverable, fireEvent: true);
					continue;
				}
				value = GetDelivery();
				value.SetDuration(deliverable.ItemData.TimeForCommand);
				value.AddDeliverable(deliverable, fireEvent: false);
				_currentDeliveries.Add(value);
				_deliveriesThisFrame.Add(deliverable.ItemData.TimeForCommand, value);
				Deliveries.DeliveryCreated?.Invoke(value);
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		private void GetDeliveriesToConsole()
		{
			for (int i = 0; i < _currentDeliveries.Count; i++)
			{
				_currentDeliveries[i].GetToConsole();
			}
		}

		protected override void SingletonAwake()
		{
			SaveManager.OnLoadingFinished += GameData_OnLoadingFinished;
		}

		protected override void OnSingletonDestroy()
		{
			SaveManager.OnLoadingFinished -= GameData_OnLoadingFinished;
		}
	}
}
