using System;
using Dhs5.Utility.Databases;
using Dhs5.Utility.Settings;
using Simulator.GameWorld;
using UnityEngine;

namespace Tabletop
{
	[Settings("Databases", Scope.Project)]
	public class TabletopDatabaseSettings : DatabaseSettings
	{
		[SerializeField]
		private FurnitureDatabase m_furnitureDatabase;

		protected override BaseDataContainer GetDatabase(Type type)
		{
			if (type == typeof(FurnitureDatabase))
			{
				return m_furnitureDatabase;
			}
			return null;
		}
	}
}
