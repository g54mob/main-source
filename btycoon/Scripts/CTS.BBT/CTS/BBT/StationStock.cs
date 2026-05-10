using System;
using CTS.BBT.AI;
using CTS.Core;
using CTS.StockInventory;
using UnityEngine;

namespace CTS.BBT
{
	public class StationStock : WorkerFurnitureInteractor
	{
		[SerializeField]
		protected StringKey<StockType> _stockType;

		[SerializeField]
		protected int _maxItemCount = 20;

		public static readonly Func<StationStock, bool> IsFridge = (StationStock station) => station._stockType == Stocks.VampireStockType;

		public static readonly Func<StationStock, bool> IsShelf = (StationStock station) => station._stockType == Stocks.HumanStockType;

		public static readonly Func<StationStock, StringKey<StockType>, bool> IsCorrectStorageType = (StationStock station, StringKey<StockType> type) => station._stockType == type;

		public static readonly Func<StationStock, Worker, bool> IsFridgeAndInAssignation = (StationStock station, Worker worker) => IsFridge(station) && worker.RoomAssignations.HasRoom(station.RoomObject.CurrentRoom);

		public StringKey<StockType> Type => _stockType;

		public int MaxItemCount => _maxItemCount;

		[field: InjectScope(EGetScope.Children)]
		[field: Inject(false)]
		public ObjectSwapOnPercent VisualSwapper { get; }
	}
}
