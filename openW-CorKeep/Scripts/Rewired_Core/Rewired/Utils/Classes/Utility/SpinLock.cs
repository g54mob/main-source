using System;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class SpinLock : IDisposable
	{
		private const int kXoOqPkjrzcapVsTwroakIeFDAoz = 1;

		private const int IezGwzuwPNGRKXtszYZzxqqFTPPH = 0;

		private int kZKcAzkEAOhaYozNqBWtBxVdShqo;

		void IDisposable.Dispose()
		{
			ALCxxmKMwIKQwxfJdpAEMDJpyXOd();
		}

		private void gLJAWHIEOTBTffEDZrzHZpgZXpGiA()
		{
			while (Interlocked.Exchange(ref kZKcAzkEAOhaYozNqBWtBxVdShqo, 1) != 0)
			{
				Thread.SpinWait(1);
			}
		}

		private void ALCxxmKMwIKQwxfJdpAEMDJpyXOd()
		{
			Interlocked.Exchange(ref kZKcAzkEAOhaYozNqBWtBxVdShqo, 0);
		}

		public SpinLock Lock()
		{
			gLJAWHIEOTBTffEDZrzHZpgZXpGiA();
			return this;
		}
	}
}
