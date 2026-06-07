using System;

namespace MiscUtil.Threading
{
	public struct LockToken : IDisposable
	{
		private SyncLock parent;

		internal LockToken(SyncLock parent)
		{
			this.parent = parent;
		}

		public void Dispose()
		{
			if (parent != null)
			{
				parent.Unlock();
				parent = null;
			}
		}
	}
}
