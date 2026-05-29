using System;
using System.Collections.Generic;

namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal class SteamActionSet
	{
		public readonly string name;

		public readonly ulong handle;

		public readonly Dictionary<string, SteamAction> actions;

		public SteamActionSet(string name, ulong handle)
		{
			this.name = name;
			this.handle = handle;
			actions = new Dictionary<string, SteamAction>();
		}

		public void AddAction(SteamAction action)
		{
			if (action == null)
			{
				goto IL_0003;
			}
			goto IL_0032;
			IL_0003:
			int num = -368599715;
			goto IL_0008;
			IL_0008:
			switch (num ^ -368599716)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				throw new ArgumentNullException();
			case 0:
				goto IL_0032;
			case 3:
				return;
			}
			goto IL_0003;
			IL_0032:
			actions.Add(action.name, action);
			num = -368599713;
			goto IL_0008;
		}
	}
}
