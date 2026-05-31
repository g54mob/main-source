using System;
using System.Collections.Generic;

namespace V1
{
	[Serializable]
	public class BuildingData
	{
		public int Index;

		public int BuildingType;

		public List<SaveKeyValueItem> Data = new List<SaveKeyValueItem>();
	}
}
