using System;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class LockedObject<T> : IDisposable
	{
		public T item;

		private readonly object ymTeNRyNMyMwvEVdQgfatWCwBeIo;

		private bool HtygmIhHNTcwAAboUpVefEDAygvJB;

		public LockedObject()
		{
			ymTeNRyNMyMwvEVdQgfatWCwBeIo = new object();
		}

		public LockedObject(object P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("lockObject");
			}
			ymTeNRyNMyMwvEVdQgfatWCwBeIo = P_0;
		}

		public void Lock()
		{
			if (HtygmIhHNTcwAAboUpVefEDAygvJB)
			{
				throw new Exception("Already locked. Dispose must be called before Lock can be called again.");
			}
			Monitor.Enter(ymTeNRyNMyMwvEVdQgfatWCwBeIo);
			HtygmIhHNTcwAAboUpVefEDAygvJB = true;
		}

		public void Unlock()
		{
			if (!HtygmIhHNTcwAAboUpVefEDAygvJB)
			{
				throw new Exception("Not locked. Lock must be called before Dispose.");
			}
			Monitor.Exit(ymTeNRyNMyMwvEVdQgfatWCwBeIo);
			HtygmIhHNTcwAAboUpVefEDAygvJB = false;
		}

		void IDisposable.Dispose()
		{
			Unlock();
		}
	}
}
