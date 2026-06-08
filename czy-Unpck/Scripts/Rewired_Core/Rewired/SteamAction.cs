namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class SteamAction
	{
		public readonly string name;

		public readonly ulong handle;

		public SteamAction(string name, ulong handle)
		{
			while (true)
			{
				int num = -56719079;
				while (true)
				{
					switch (num ^ -56719077)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						this.name = name;
						num = -56719080;
						continue;
					case 3:
						this.handle = handle;
						num = -56719078;
						continue;
					case 1:
						return;
					}
					break;
				}
			}
		}
	}
}
