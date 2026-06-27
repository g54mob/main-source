using System.Collections.Generic;
using Restory.Data.Base;
using UnityEngine;

namespace Restory.Data.Tables.Balances
{
	public abstract class GameEntityBalanceTable<TParameters> : GameEntityBalanceTableBase where TParameters : BalanceParametersBase
	{
		[SerializeField]
		private TParameters defaultValue;

		[SerializeField]
		protected GameEntityBalanceEntry<TParameters>[] entries = new GameEntityBalanceEntry<TParameters>[0];

		public TParameters DefaultValue => defaultValue;

		public IReadOnlyList<GameEntityBalanceEntry<TParameters>> Entries => entries;

		public override bool Contains(RestoryEntityInfoBase entity)
		{
			GameEntityBalanceEntry<TParameters>[] array = entries;
			foreach (GameEntityBalanceEntry<TParameters> gameEntityBalanceEntry in array)
			{
				if (gameEntityBalanceEntry != null && gameEntityBalanceEntry.ItemObject.ID == entity.ID)
				{
					return true;
				}
			}
			return false;
		}

		public void GetBalanceDataOrDefault(RestoryEntityInfoBase entity, out TParameters balanceParameters)
		{
			if ((bool)entity)
			{
				GameEntityBalanceEntry<TParameters>[] array = entries;
				foreach (GameEntityBalanceEntry<TParameters> gameEntityBalanceEntry in array)
				{
					if (gameEntityBalanceEntry != null && gameEntityBalanceEntry.ItemObject.ID == entity.ID)
					{
						balanceParameters = gameEntityBalanceEntry.Parameters;
						return;
					}
				}
			}
			balanceParameters = defaultValue;
		}

		public bool TryToGetBalanceData(RestoryEntityInfoBase entity, out TParameters balanceParameters)
		{
			if ((bool)entity)
			{
				GameEntityBalanceEntry<TParameters>[] array = entries;
				foreach (GameEntityBalanceEntry<TParameters> gameEntityBalanceEntry in array)
				{
					if (gameEntityBalanceEntry != null && gameEntityBalanceEntry.ItemObject.ID == entity.ID)
					{
						balanceParameters = gameEntityBalanceEntry.Parameters;
						return true;
					}
				}
			}
			balanceParameters = null;
			return false;
		}
	}
}
