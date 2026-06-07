using System;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class LockedObject<T> : IDisposable
	{
		public T item;

		private readonly object cJILdffNkWFzBJyNkCBqOIRvXMBv;

		private bool JSpNUgoEtzlboefKalfqxZKnhYiT;

		public LockedObject()
		{
		}

		public LockedObject(object P_0)
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
