using System;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class LockedObject<T> : IDisposable
	{
		public T item;

		private readonly object RdtpEIEjuiOYUejCuvEcoZpwZnMc;

		private bool UnlLiCgstxOrVHHIlWJGEWGUTyfC;

		public LockedObject()
		{
			RdtpEIEjuiOYUejCuvEcoZpwZnMc = new object();
		}

		public LockedObject(object P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("lockObject");
			}
			RdtpEIEjuiOYUejCuvEcoZpwZnMc = P_0;
		}

		public void Lock()
		{
			if (UnlLiCgstxOrVHHIlWJGEWGUTyfC)
			{
				throw new Exception("Already locked. Dispose must be called before Lock can be called again.");
			}
			Monitor.Enter(RdtpEIEjuiOYUejCuvEcoZpwZnMc);
			UnlLiCgstxOrVHHIlWJGEWGUTyfC = true;
		}

		public void Unlock()
		{
			if (!UnlLiCgstxOrVHHIlWJGEWGUTyfC)
			{
				throw new Exception("Not locked. Lock must be called before Dispose.");
			}
			Monitor.Exit(RdtpEIEjuiOYUejCuvEcoZpwZnMc);
			UnlLiCgstxOrVHHIlWJGEWGUTyfC = false;
		}

		void IDisposable.Dispose()
		{
			Unlock();
		}
	}
}
