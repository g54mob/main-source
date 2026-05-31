using System;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal struct Locker : IDisposable
	{
		private object FGdfYZnSDUbKvZGpdheRKxuypZdG;

		public Locker(object target)
		{
			FGdfYZnSDUbKvZGpdheRKxuypZdG = target;
			if (target != null)
			{
				Monitor.Enter(target);
			}
		}

		public void Dispose()
		{
			if (FGdfYZnSDUbKvZGpdheRKxuypZdG != null)
			{
				Monitor.Exit(FGdfYZnSDUbKvZGpdheRKxuypZdG);
				FGdfYZnSDUbKvZGpdheRKxuypZdG = null;
			}
		}
	}
}
