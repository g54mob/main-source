using System;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class LockedObject<T> : IDisposable
	{
		public T item;

		private readonly object ShlfPKvVVHQTrWnjCOXDiNVPDL;

		private bool BnbHHwkYJWVgLKRhsxtEpCBdZiB;

		public LockedObject()
		{
			ShlfPKvVVHQTrWnjCOXDiNVPDL = new object();
		}

		public LockedObject(object lockObject)
		{
			if (lockObject == null)
			{
				throw new ArgumentNullException("lockObject");
			}
			ShlfPKvVVHQTrWnjCOXDiNVPDL = lockObject;
		}

		public void Lock()
		{
			if (BnbHHwkYJWVgLKRhsxtEpCBdZiB)
			{
				throw new Exception("Already locked. Dispose must be called before Lock can be called again.");
			}
			Monitor.Enter(ShlfPKvVVHQTrWnjCOXDiNVPDL);
			BnbHHwkYJWVgLKRhsxtEpCBdZiB = true;
		}

		public void Unlock()
		{
			if (!BnbHHwkYJWVgLKRhsxtEpCBdZiB)
			{
				throw new Exception("Not locked. Lock must be called before Dispose.");
			}
			Monitor.Exit(ShlfPKvVVHQTrWnjCOXDiNVPDL);
			BnbHHwkYJWVgLKRhsxtEpCBdZiB = false;
		}

		void IDisposable.Dispose()
		{
			Unlock();
		}
	}
}
