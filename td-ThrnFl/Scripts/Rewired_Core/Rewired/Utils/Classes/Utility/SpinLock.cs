using System;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class SpinLock : IDisposable
	{
		private const int RSVdwfSEtdjYNXkVrHuKfPWUXtqA = 1;

		private const int vLRtCeSqNMRxFWRECrrwwRKyOEs = 0;

		private int RpyNzIYvJEjzjyuyBdKbKyXkeube;

		void IDisposable.Dispose()
		{
			bCkCfHeRrAZxZbEkQAEYRqFitePf();
		}

		private void BxnVsohADGdSWfciICJmXXUgLDj()
		{
			while (Interlocked.Exchange(ref RpyNzIYvJEjzjyuyBdKbKyXkeube, 1) != 0)
			{
				Thread.SpinWait(1);
			}
		}

		private void bCkCfHeRrAZxZbEkQAEYRqFitePf()
		{
			Interlocked.Exchange(ref RpyNzIYvJEjzjyuyBdKbKyXkeube, 0);
		}

		public SpinLock Lock()
		{
			BxnVsohADGdSWfciICJmXXUgLDj();
			return this;
		}
	}
}
