using System;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal struct Locker : IDisposable
	{
		private object vGQnsSUmFrTJHfYhJtHRHxFCImW;

		public Locker(object target)
		{
			vGQnsSUmFrTJHfYhJtHRHxFCImW = target;
			if (target != null)
			{
				Monitor.Enter(target);
			}
		}

		public void Dispose()
		{
			if (vGQnsSUmFrTJHfYhJtHRHxFCImW != null)
			{
				Monitor.Exit(vGQnsSUmFrTJHfYhJtHRHxFCImW);
				vGQnsSUmFrTJHfYhJtHRHxFCImW = null;
			}
		}
	}
}
