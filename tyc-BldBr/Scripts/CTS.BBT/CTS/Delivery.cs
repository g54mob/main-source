using System;
using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.StockInventory;
using UnityEngine;

namespace CTS
{
	public class Delivery
	{
		private List<StockStack> _deliverables = new List<StockStack>();

		public float ArrivalTime;

		public ReadOnlyList<StockStack> Deliverables => _deliverables;

		public Dictionary<StringKey<StockType>, int> DeliveryAmounts { get; } = new Dictionary<StringKey<StockType>, int>();

		public event Action DeliverablesChanged;

		public void Reset()
		{
			_deliverables.Clear();
			DeliveryAmounts.Clear();
		}

		public void GetToConsole()
		{
			string text = "Arrival : " + ArrivalTime + "\n";
			text += "Content : \n";
			for (int i = 0; i < _deliverables.Count; i++)
			{
				text = text + _deliverables[i].ItemData.Name + " / " + _deliverables[i].StackCount + "\n";
			}
			Debug.Log(text);
		}

		public void RecreateAmount()
		{
			DeliveryAmounts.Clear();
			for (int i = 0; i < _deliverables.Count; i++)
			{
				if (!DeliveryAmounts.ContainsKey(_deliverables[i].ItemData.StockType))
				{
					DeliveryAmounts[_deliverables[i].ItemData.StockType] = _deliverables[i].StackCount;
				}
				else
				{
					DeliveryAmounts[_deliverables[i].ItemData.StockType] += _deliverables[i].StackCount;
				}
			}
		}

		public void AddDeliverable(StockStack deliverable, bool fireEvent)
		{
			if (deliverable.StackCount > 0)
			{
				_deliverables.Add(deliverable);
				if (!DeliveryAmounts.ContainsKey(deliverable.ItemData.StockType))
				{
					DeliveryAmounts[deliverable.ItemData.StockType] = deliverable.StackCount;
				}
				else
				{
					DeliveryAmounts[deliverable.ItemData.StockType] += deliverable.StackCount;
				}
				if (fireEvent)
				{
					this.DeliverablesChanged?.Invoke();
				}
			}
		}

		public void SetDuration(float duration)
		{
			ArrivalTime = duration;
		}
	}
}
