using System.Collections.Generic;

namespace Rewired
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal class SteamActionSet
	{
		public readonly string name;

		public readonly ulong handle;

		public readonly Dictionary<string, SteamAction> actions;

		public SteamActionSet(string name, ulong handle)
		{
		}

		public void AddAction(SteamAction action)
		{
		}
	}
}
