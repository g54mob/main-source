using System;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class SpinLock : IDisposable
	{
		private const int gteICQALpjmGHakzrlrNjwkwBZcJ = 1;

		private const int SyhOgtEvgTCkmkCHoNtEkumcGvRD = 0;

		private int yAUoUaSmFYqCqRFnnNxCOGJKyGyK;

		void IDisposable.Dispose()
		{
			QpCxadafmIfQWSSXmclzJvJWpHMh();
		}

		private void gmJQCQkcHRTGJvBvAchmsxgmovEg()
		{
			while (Interlocked.Exchange(ref yAUoUaSmFYqCqRFnnNxCOGJKyGyK, 1) != 0)
			{
				Thread.SpinWait(1);
			}
		}

		private void QpCxadafmIfQWSSXmclzJvJWpHMh()
		{
			Interlocked.Exchange(ref yAUoUaSmFYqCqRFnnNxCOGJKyGyK, 0);
		}

		public SpinLock Lock()
		{
			gmJQCQkcHRTGJvBvAchmsxgmovEg();
			return this;
		}
	}
}
