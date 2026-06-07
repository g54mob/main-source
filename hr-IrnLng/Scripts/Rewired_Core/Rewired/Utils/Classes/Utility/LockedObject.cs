using System;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class LockedObject<T> : IDisposable
	{
		public T item;

		private readonly object wNZEYhjgeGerJsKZeEXADbalVOv;

		private bool tZDyzfHGbFqZsTmvzriapHfPiNz;

		public LockedObject()
		{
			wNZEYhjgeGerJsKZeEXADbalVOv = new object();
		}

		public LockedObject(object lockObject)
		{
			if (lockObject == null)
			{
				throw new ArgumentNullException("lockObject");
			}
			wNZEYhjgeGerJsKZeEXADbalVOv = lockObject;
		}

		public void Lock()
		{
			if (tZDyzfHGbFqZsTmvzriapHfPiNz)
			{
				throw new Exception("Already locked. Dispose must be called before Lock can be called again.");
			}
			Monitor.Enter(wNZEYhjgeGerJsKZeEXADbalVOv);
			tZDyzfHGbFqZsTmvzriapHfPiNz = true;
		}

		public void Unlock()
		{
			if (!tZDyzfHGbFqZsTmvzriapHfPiNz)
			{
				throw new Exception("Not locked. Lock must be called before Dispose.");
			}
			Monitor.Exit(wNZEYhjgeGerJsKZeEXADbalVOv);
			tZDyzfHGbFqZsTmvzriapHfPiNz = false;
		}

		void IDisposable.Dispose()
		{
			Unlock();
		}
	}
}
