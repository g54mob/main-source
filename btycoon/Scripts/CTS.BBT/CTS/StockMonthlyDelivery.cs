using CTS.BBT;
using CTS.Core;
using CTS.StockInventory;
using UnityEngine;

namespace CTS
{
	public class StockMonthlyDelivery : CTSBehaviour
	{
		[SerializeField]
		private BBTStock _stockToDeliveryTo;

		[SerializeField]
		private StockDeliveryEvents _events;

		[SerializeField]
		private StringKey<StockType>[] _wipeInventories;

		private StockDeliveryData _currentDeliveryData;

		private StockDeliveryData _customDeliveryData;

		private int _currentEventIndex;

		[field: SerializeField]
		public StockDeliveryData BaseMonthlyDelivery { get; private set; }

		private void Start()
		{
			ResetMonthlyDeliveryToDefault();
			GetNewDeliveryFromChanceData();
		}

		private StockDeliveryData GetCurrentDeliveryData()
		{
			if ((bool)_customDeliveryData)
			{
				return _customDeliveryData;
			}
			if ((bool)_currentDeliveryData)
			{
				return _currentDeliveryData;
			}
			return BaseMonthlyDelivery;
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			CalendarHandlers.NewMonth += OnNewMonth;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			CalendarHandlers.NewMonth -= OnNewMonth;
		}

		public void SetCustomMonthlyDelivery(StockDeliveryData deliveryData)
		{
			_customDeliveryData = deliveryData;
		}

		public void ForceCustomMonthlyDelivery(StockDeliveryData deliveryData)
		{
			_customDeliveryData = deliveryData;
			GetNewDeliveryFromChanceData();
		}

		public void ResetMonthlyDeliveryToDefault()
		{
			_currentDeliveryData = BaseMonthlyDelivery;
		}

		private void OnNewMonth()
		{
			CheckCurrentEvent();
			GetNewDeliveryFromChanceData();
		}

		private void CheckCurrentEvent()
		{
			if (!(_events == null) && _currentEventIndex < _events.Deliveries.Count)
			{
				StockDeliveryEvents.DateEvent dateEvent = _events.Deliveries[_currentEventIndex];
				if (dateEvent.Year >= MonoSingleton<CalendarHandlers>.Instance.CurrentYear && dateEvent.Month + 1 >= MonoSingleton<CalendarHandlers>.Instance.CurrentMonth)
				{
					_currentEventIndex++;
					_currentDeliveryData = dateEvent.Data;
				}
			}
		}

		public void GetNewDeliveryFromChanceData()
		{
			StockDeliveryData currentDeliveryData = GetCurrentDeliveryData();
			if (currentDeliveryData == null)
			{
				return;
			}
			StringKey<StockType>[] wipeInventories = _wipeInventories;
			foreach (StringKey<StockType> stockType in wipeInventories)
			{
				_stockToDeliveryTo.ClearInventory(stockType);
			}
			StockItemSO[] items = currentDeliveryData.Deliverables.Items;
			foreach (StockItemSO stockItemSO in items)
			{
				if (!(stockItemSO == null))
				{
					StockStack stackToAdd = new StockStack(stockItemSO, currentDeliveryData.GetAmount(stockItemSO), currentDeliveryData.GetQuality(stockItemSO));
					_stockToDeliveryTo.TryAdd(stockItemSO.StockType, ref stackToAdd);
				}
			}
		}
	}
}
