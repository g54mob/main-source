using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public struct CMoneyTrackRecord : IComponentData
	{
		public int Day;

		public DataObjectList Identifiers;

		public DataObjectList Amounts;

		public void Add(CMoneyTrackEvent evt)
		{
			Add(evt.Identifier, evt.Amount);
		}

		public void Add(int identifier, int amount)
		{
			if (amount == 0)
			{
				return;
			}
			if (Identifiers.Count != Amounts.Count)
			{
				Debug.LogWarning("Money tracker out of sync");
				return;
			}
			for (int i = 0; i < Identifiers.Count; i++)
			{
				if (Identifiers[i] == identifier)
				{
					Amounts[i] += amount;
					return;
				}
			}
			Identifiers.Add(identifier);
			Amounts.Add(amount);
		}

		public int Get(int identifier)
		{
			if (Identifiers.Count != Amounts.Count)
			{
				Debug.LogWarning("Money tracker out of sync");
				return 0;
			}
			for (int i = 0; i < Identifiers.Count; i++)
			{
				if (Identifiers[i] == identifier)
				{
					return Amounts[i];
				}
			}
			return 0;
		}
	}
}
