using System;
using System.Collections.Generic;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class SteamActionSet
	{
		public readonly string name;

		public readonly ulong handle;

		public readonly Dictionary<string, SteamAction> actions;

		public SteamActionSet(string name, ulong handle)
		{
			while (true)
			{
				int num = -2044715220;
				while (true)
				{
					switch (num ^ -2044715219)
					{
					case 2:
						break;
					case 1:
						goto IL_0024;
					default:
						this.handle = handle;
						actions = new Dictionary<string, SteamAction>();
						return;
					}
					break;
					IL_0024:
					this.name = name;
					num = -2044715219;
				}
			}
		}

		public void AddAction(SteamAction action)
		{
			if (action == null)
			{
				throw new ArgumentNullException();
			}
			while (true)
			{
				actions.Add(action.name, action);
				int num = 1963586511;
				while (true)
				{
					switch (num ^ 0x7509F3CD)
					{
					case 0:
						goto IL_0009;
					default:
						return;
					case 1:
						break;
					case 2:
						return;
					}
					break;
					IL_0009:
					num = 1963586508;
				}
			}
		}
	}
}
