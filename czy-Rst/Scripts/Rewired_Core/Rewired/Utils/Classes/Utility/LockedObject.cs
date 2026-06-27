using System;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class LockedObject<T> : IDisposable
	{
		public T item;

		private readonly object blvFCafwKfsmncGeIOxOHnwJQOULA;

		private bool StSBllhrXYbySbmjQIFYcUlXKYxUA;

		public LockedObject()
		{
			blvFCafwKfsmncGeIOxOHnwJQOULA = new object();
		}

		public LockedObject(object P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("lockObject");
			}
			blvFCafwKfsmncGeIOxOHnwJQOULA = P_0;
		}

		public void Lock()
		{
			if (StSBllhrXYbySbmjQIFYcUlXKYxUA)
			{
				throw new Exception("Already locked. Dispose must be called before Lock can be called again.");
			}
			Monitor.Enter(blvFCafwKfsmncGeIOxOHnwJQOULA);
			StSBllhrXYbySbmjQIFYcUlXKYxUA = true;
		}

		public void Unlock()
		{
			if (!StSBllhrXYbySbmjQIFYcUlXKYxUA)
			{
				throw new Exception("Not locked. Lock must be called before Dispose.");
			}
			Monitor.Exit(blvFCafwKfsmncGeIOxOHnwJQOULA);
			StSBllhrXYbySbmjQIFYcUlXKYxUA = false;
		}

		void IDisposable.Dispose()
		{
			Unlock();
		}
	}
}
