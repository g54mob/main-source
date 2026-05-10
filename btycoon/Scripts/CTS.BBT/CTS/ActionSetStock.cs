using System.Collections.Generic;
using CTS.BBT;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class ActionSetStock : InstantAction
	{
		[SerializeField]
		private SerializableDictionary<StockItemSO, int> _stockToAdd = new SerializableDictionary<StockItemSO, int>();

		protected override bool PlayAction(ActionSequence sequence)
		{
			foreach (var (itemData, stackCount) in _stockToAdd)
			{
				Stocks.ForceAdd(new StockStack(itemData, stackCount, 5f));
			}
			return true;
		}
	}
}
