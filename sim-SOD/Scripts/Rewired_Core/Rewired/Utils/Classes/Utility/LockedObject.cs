using System;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class LockedObject<T> : IDisposable
	{
		public T item;

		private readonly object kozdzYBoHUkrULLrOwvPbpZsjeaa;

		private bool pmpbBMIvGDefxaoZRpAzFVMIMygU;

		public LockedObject()
		{
		}

		public LockedObject(object lockObject)
		{
		}

		public void Lock()
		{
		}

		public void Unlock()
		{
		}

		void IDisposable.Dispose()
		{
		}
	}
}
