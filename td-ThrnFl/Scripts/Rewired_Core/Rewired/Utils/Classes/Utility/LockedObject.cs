using System;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class LockedObject<T> : IDisposable
	{
		public T item;

		private readonly object TVyxWXzMifXiRJvTXeKjCEGQiSmD;

		private bool wfVKOAuZTWDpgmwEZCQvlRCAwKPE;

		public LockedObject()
		{
			TVyxWXzMifXiRJvTXeKjCEGQiSmD = new object();
		}

		public LockedObject(object P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("lockObject");
			}
			TVyxWXzMifXiRJvTXeKjCEGQiSmD = P_0;
		}

		public void Lock()
		{
			if (wfVKOAuZTWDpgmwEZCQvlRCAwKPE)
			{
				throw new Exception("Already locked. Dispose must be called before Lock can be called again.");
			}
			Monitor.Enter(TVyxWXzMifXiRJvTXeKjCEGQiSmD);
			wfVKOAuZTWDpgmwEZCQvlRCAwKPE = true;
		}

		public void Unlock()
		{
			if (!wfVKOAuZTWDpgmwEZCQvlRCAwKPE)
			{
				throw new Exception("Not locked. Lock must be called before Dispose.");
			}
			Monitor.Exit(TVyxWXzMifXiRJvTXeKjCEGQiSmD);
			wfVKOAuZTWDpgmwEZCQvlRCAwKPE = false;
		}

		void IDisposable.Dispose()
		{
			Unlock();
		}
	}
}
