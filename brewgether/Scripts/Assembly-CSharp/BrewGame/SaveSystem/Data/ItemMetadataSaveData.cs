using System;
using System.Collections.Generic;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class ItemMetadataSaveData
	{
		public List<BarrelMetadataEntry> barrels;

		public List<BeverageMetadataEntry> beverages;

		public List<CrateMetadataEntry> crates;
	}
}
