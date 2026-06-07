using System;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal struct Locker : IDisposable
	{
		private object kxVVfsEvIkmogZXRbQDbWrFdzRdN;

		public Locker(object P_0)
		{
			kxVVfsEvIkmogZXRbQDbWrFdzRdN = P_0;
			if (P_0 != null)
			{
				Monitor.Enter(P_0);
			}
		}

		public void Dispose()
		{
			if (kxVVfsEvIkmogZXRbQDbWrFdzRdN != null)
			{
				Monitor.Exit(kxVVfsEvIkmogZXRbQDbWrFdzRdN);
				kxVVfsEvIkmogZXRbQDbWrFdzRdN = null;
			}
		}
	}
}
