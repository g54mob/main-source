using System;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class LockedObject<T> : IDisposable
	{
		public T item;

		private readonly object yISTMXhqPCYTuCPkccMjHHafcAsFb;

		private bool VzjWnWcMSdQFBbwrmLsfaQxnAOFT;

		public LockedObject()
		{
			yISTMXhqPCYTuCPkccMjHHafcAsFb = new object();
		}

		public LockedObject(object P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("lockObject");
			}
			yISTMXhqPCYTuCPkccMjHHafcAsFb = P_0;
		}

		public void Lock()
		{
			if (VzjWnWcMSdQFBbwrmLsfaQxnAOFT)
			{
				throw new Exception("Already locked. Dispose must be called before Lock can be called again.");
			}
			Monitor.Enter(yISTMXhqPCYTuCPkccMjHHafcAsFb);
			VzjWnWcMSdQFBbwrmLsfaQxnAOFT = true;
		}

		public void Unlock()
		{
			if (!VzjWnWcMSdQFBbwrmLsfaQxnAOFT)
			{
				throw new Exception("Not locked. Lock must be called before Dispose.");
			}
			Monitor.Exit(yISTMXhqPCYTuCPkccMjHHafcAsFb);
			VzjWnWcMSdQFBbwrmLsfaQxnAOFT = false;
		}

		void IDisposable.Dispose()
		{
			Unlock();
		}
	}
}
