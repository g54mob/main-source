using System;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class SpinLock : IDisposable
	{
		private const int KSHnOpxGblMtnpsCrlqedDRUggY = 1;

		private const int uaZdCYSFBUDpXCGBtziithdqAscn = 0;

		private int CTRtJmWIWOCaDqgjXpQJREtEkbOR;

		void IDisposable.Dispose()
		{
			OmlqmzxGTwiCJaejPlHMfbLSvTMh();
		}

		private void ekTFqchTGFaoGDCHcBbJsxRtqhnjB()
		{
			while (Interlocked.Exchange(ref CTRtJmWIWOCaDqgjXpQJREtEkbOR, 1) != 0)
			{
				Thread.SpinWait(1);
			}
		}

		private void OmlqmzxGTwiCJaejPlHMfbLSvTMh()
		{
			Interlocked.Exchange(ref CTRtJmWIWOCaDqgjXpQJREtEkbOR, 0);
		}

		public SpinLock Lock()
		{
			ekTFqchTGFaoGDCHcBbJsxRtqhnjB();
			return this;
		}
	}
}
