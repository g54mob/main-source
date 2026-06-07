using System;
using CTS.BBT;
using UnityEngine;

namespace CTS
{
	[Serializable]
	internal struct StockAlertsStruct
	{
		[SerializeField]
		public StockItemSO StockItemSO;

		[SerializeField]
		public float WhenTheStockIsLow;

		[SerializeField]
		public float WhenTheStockIsVeryLow;

		[NonSerialized]
		public StocksAlerts.EState CurrentState;
	}
}
