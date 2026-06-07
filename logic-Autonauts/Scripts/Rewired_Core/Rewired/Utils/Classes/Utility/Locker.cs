using System;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal struct Locker : IDisposable
	{
		private object GCQHnJkXanMbWWcIAkqAJMfPbnz;

		public Locker(object target)
		{
			GCQHnJkXanMbWWcIAkqAJMfPbnz = target;
			if (target != null)
			{
				Monitor.Enter(target);
			}
		}

		public void Dispose()
		{
			if (GCQHnJkXanMbWWcIAkqAJMfPbnz == null)
			{
				return;
			}
			while (true)
			{
				Monitor.Exit(GCQHnJkXanMbWWcIAkqAJMfPbnz);
				int num = -1222864108;
				while (true)
				{
					switch (num ^ -1222864108)
					{
					case 2:
						goto IL_0009;
					case 1:
						break;
					default:
						GCQHnJkXanMbWWcIAkqAJMfPbnz = null;
						return;
					}
					break;
					IL_0009:
					num = -1222864107;
				}
			}
		}
	}
}
