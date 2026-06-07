using System.Collections.Generic;

namespace Rewired
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal class SteamActionSet
	{
		public readonly string name;

		public readonly ulong handle;

		public readonly Dictionary<string, SteamAction> actions;

		public SteamActionSet(string P_0, ulong P_1)
		{
		}

		public void AddAction(SteamAction action)
		{
		}
	}
}
