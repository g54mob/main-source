using System;
using System.Collections.Generic;
using Restory.Data.Base;
using UnityEngine;

namespace Restory.Data.Tables.Parameters
{
	public abstract class GameEntityParametersTable<TParameters> : GameEntityParametersTableBase where TParameters : GameEntityParameters
	{
		[SerializeField]
		protected GameEntityTableEntry<TParameters>[] entries = Array.Empty<GameEntityTableEntry<TParameters>>();

		[SerializeField]
		protected TParameters defaultValue;

		public IReadOnlyList<GameEntityTableEntry<TParameters>> Entries => entries;

		public override bool Contains(RestoryEntityInfoBase entity)
		{
			GameEntityTableEntry<TParameters>[] array = entries;
			foreach (GameEntityTableEntry<TParameters> gameEntityTableEntry in array)
			{
				if (gameEntityTableEntry != null && gameEntityTableEntry.ItemObject.ID == entity.ID)
				{
					return true;
				}
			}
			return false;
		}

		public bool TryToGetParameters(RestoryEntityInfoBase entity, out TParameters parameters)
		{
			if ((bool)entity)
			{
				GameEntityTableEntry<TParameters>[] array = entries;
				foreach (GameEntityTableEntry<TParameters> gameEntityTableEntry in array)
				{
					if (gameEntityTableEntry != null && gameEntityTableEntry.ItemObject.ID == entity.ID)
					{
						parameters = gameEntityTableEntry.Parameters;
						return true;
					}
				}
			}
			parameters = null;
			return false;
		}

		public void GetParametersOrDefault(RestoryEntityInfoBase entity, out TParameters parameters)
		{
			if (!TryToGetParameters(entity, out parameters))
			{
				parameters = defaultValue;
			}
		}
	}
}
