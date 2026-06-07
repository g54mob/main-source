using System;
using System.Collections.Generic;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class CrateMetadataSaveData
	{
		public List<CrateSlotSaveData> slots;
	}
}
