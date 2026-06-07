using System;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class LockedObject<T> : IDisposable
	{
		public T item;

		private readonly object cajlaBiSXyFrieRVPNVUXzkvaTxz;

		private bool vWbGIXGdYnbfZhwdQJqeMLbDVFpvA;

		public LockedObject()
		{
			cajlaBiSXyFrieRVPNVUXzkvaTxz = new object();
		}

		public LockedObject(object P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("lockObject");
			}
			cajlaBiSXyFrieRVPNVUXzkvaTxz = P_0;
		}

		public void Lock()
		{
			if (vWbGIXGdYnbfZhwdQJqeMLbDVFpvA)
			{
				throw new Exception("Already locked. Dispose must be called before Lock can be called again.");
			}
			Monitor.Enter(cajlaBiSXyFrieRVPNVUXzkvaTxz);
			vWbGIXGdYnbfZhwdQJqeMLbDVFpvA = true;
		}

		public void Unlock()
		{
			if (!vWbGIXGdYnbfZhwdQJqeMLbDVFpvA)
			{
				throw new Exception("Not locked. Lock must be called before Dispose.");
			}
			Monitor.Exit(cajlaBiSXyFrieRVPNVUXzkvaTxz);
			vWbGIXGdYnbfZhwdQJqeMLbDVFpvA = false;
		}

		void IDisposable.Dispose()
		{
			Unlock();
		}
	}
}
