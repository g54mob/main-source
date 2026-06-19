using System;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal struct Locker : IDisposable
	{
		private object jWJUzdYygPEtnMmJufqABlNORLBB;

		public Locker(object target)
		{
			jWJUzdYygPEtnMmJufqABlNORLBB = target;
			if (target != null)
			{
				Monitor.Enter(target);
			}
		}

		public void Dispose()
		{
			if (jWJUzdYygPEtnMmJufqABlNORLBB != null)
			{
				Monitor.Exit(jWJUzdYygPEtnMmJufqABlNORLBB);
				jWJUzdYygPEtnMmJufqABlNORLBB = null;
			}
		}
	}
}
