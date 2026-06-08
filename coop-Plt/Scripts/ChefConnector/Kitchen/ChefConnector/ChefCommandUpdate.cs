using System;

namespace Kitchen.ChefConnector
{
	[Serializable]
	public struct ChefCommandUpdate
	{
		public string Type;

		public string Data;
	}
}
