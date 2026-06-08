using System;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class LockedObject<T> : IDisposable
	{
		public T item;

		private readonly object YpuegkWxujbfnMfHUlVMrfRPfuG;

		private bool JagKvuuXnkzWKdruJGhsDbKbkLK;

		public LockedObject()
		{
			YpuegkWxujbfnMfHUlVMrfRPfuG = new object();
		}

		public LockedObject(object lockObject)
		{
			while (true)
			{
				switch (0x232F45FE ^ 0x232F45FF)
				{
				case 2:
					continue;
				case 1:
					if (lockObject == null)
					{
						throw new ArgumentNullException("lockObject");
					}
					break;
				}
				break;
			}
			YpuegkWxujbfnMfHUlVMrfRPfuG = lockObject;
		}

		public void Lock()
		{
			if (JagKvuuXnkzWKdruJGhsDbKbkLK)
			{
				while (true)
				{
					switch (-1242533927 ^ -1242533925)
					{
					case 0:
						continue;
					case 2:
						throw new Exception("Already locked. Dispose must be called before Lock can be called again.");
					}
					break;
				}
			}
			Monitor.Enter(YpuegkWxujbfnMfHUlVMrfRPfuG);
			JagKvuuXnkzWKdruJGhsDbKbkLK = true;
		}

		public void Unlock()
		{
			if (!JagKvuuXnkzWKdruJGhsDbKbkLK)
			{
				throw new Exception("Not locked. Lock must be called before Dispose.");
			}
			Monitor.Exit(YpuegkWxujbfnMfHUlVMrfRPfuG);
			JagKvuuXnkzWKdruJGhsDbKbkLK = false;
		}

		void IDisposable.Dispose()
		{
			Unlock();
		}
	}
}
