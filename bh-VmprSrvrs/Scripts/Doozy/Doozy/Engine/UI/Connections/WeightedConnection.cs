using System;
using Doozy.Engine.Nody.Connections;
using Doozy.Engine.Nody.Models;

namespace Doozy.Engine.UI.Connections
{
	[Serializable]
	public class WeightedConnection : PassthroughConnection
	{
		private const int DEFAULT_WEIGHT = 100;

		public int Weight;

		public static WeightedConnection GetValue(Socket socket)
		{
			return null;
		}

		public static void SetValue(Socket socket, WeightedConnection value)
		{
		}
	}
}
