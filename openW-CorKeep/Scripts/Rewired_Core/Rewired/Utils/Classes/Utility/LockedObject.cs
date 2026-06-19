using System;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class LockedObject<T> : IDisposable
	{
		public T item;

		private readonly object cWKCCwJwxlOiiBUWgBppLrhLfKlm;

		private bool BNzvntOruGOuBeFNgjHhyGwLCfWU;

		public LockedObject()
		{
			cWKCCwJwxlOiiBUWgBppLrhLfKlm = new object();
		}

		public LockedObject(object P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("lockObject");
			}
			cWKCCwJwxlOiiBUWgBppLrhLfKlm = P_0;
		}

		public void Lock()
		{
			if (BNzvntOruGOuBeFNgjHhyGwLCfWU)
			{
				throw new Exception("Already locked. Dispose must be called before Lock can be called again.");
			}
			Monitor.Enter(cWKCCwJwxlOiiBUWgBppLrhLfKlm);
			BNzvntOruGOuBeFNgjHhyGwLCfWU = true;
		}

		public void Unlock()
		{
			if (!BNzvntOruGOuBeFNgjHhyGwLCfWU)
			{
				throw new Exception("Not locked. Lock must be called before Dispose.");
			}
			Monitor.Exit(cWKCCwJwxlOiiBUWgBppLrhLfKlm);
			BNzvntOruGOuBeFNgjHhyGwLCfWU = false;
		}

		void IDisposable.Dispose()
		{
			Unlock();
		}
	}
}
