using System;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal struct Locker : IDisposable
	{
		private object LNFmGxqdskDZYydfYKbBBRoonLzv;

		public Locker(object P_0)
		{
			LNFmGxqdskDZYydfYKbBBRoonLzv = P_0;
			if (P_0 != null)
			{
				Monitor.Enter(P_0);
			}
		}

		public void Dispose()
		{
			if (LNFmGxqdskDZYydfYKbBBRoonLzv != null)
			{
				Monitor.Exit(LNFmGxqdskDZYydfYKbBBRoonLzv);
				LNFmGxqdskDZYydfYKbBBRoonLzv = null;
			}
		}
	}
}
