using System;
using System.Collections.Generic;

namespace Kitchen.ChefConnector
{
	[Serializable]
	public struct ChefDataUpdate
	{
		public string Type;

		public List<ChefDataValue> Appliances;

		public List<ChefDataValue> Cards;
	}
}
