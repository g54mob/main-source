using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Restory.Data.Tables.Balances;
using UnityEngine;

namespace Restory.Data.Money
{
	[CreateAssetMenu(menuName = "Restory/Money/WorkOrdersPricesTable", fileName = "WorkOrdersPricesTable")]
	public class WorkOrdersPricesTable : ScriptableObject, IGameBalanceEntity
	{
		[Serializable]
		private class Entry
		{
			public string ID;

			public int MoneyAmount;
		}

		[SerializeField]
		private Entry[] tableEntries = new Entry[0];

		private Dictionary<string, int> dictionary;

		public bool TryGetWorkOrderPaymentAmount(string sumSizeID, out int moneyAmount)
		{
			if (dictionary == null)
			{
				dictionary = InitializeDictionary();
			}
			return dictionary.TryGetValue(sumSizeID, out moneyAmount);
		}

		private Dictionary<string, int> InitializeDictionary()
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			Entry[] array = tableEntries;
			foreach (Entry entry in array)
			{
				if (entry != null)
				{
					dictionary.Add(entry.ID, entry.MoneyAmount);
				}
			}
			return dictionary;
		}

		[UsedImplicitly]
		private bool AreIdsUnique()
		{
			return (from x in tableEntries
				select x.ID into x
				where !string.IsNullOrEmpty(x)
				select x).Distinct().Count() == tableEntries.Select((Entry x) => x.ID).Count((string x) => !string.IsNullOrEmpty(x));
		}
	}
}
