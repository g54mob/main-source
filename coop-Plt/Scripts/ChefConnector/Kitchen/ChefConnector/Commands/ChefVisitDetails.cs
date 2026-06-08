using System;

namespace Kitchen.ChefConnector.Commands
{
	[Serializable]
	public struct ChefVisitDetails
	{
		public string Name;

		public int Order;

		public int Bits;

		public bool IsTrick;

		public bool IsTreat;
	}
}
