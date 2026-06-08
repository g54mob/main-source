using System;

namespace Kitchen.ChefConnector
{
	[Serializable]
	public struct ChefUpdate
	{
		public string Type;

		public int Value;

		public bool IsIntegration;
	}
}
