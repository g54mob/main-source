using System;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal struct Locker : IDisposable
	{
		private object lvGhbVdMUyXaWbXfyWjHwcFNcVFEA;

		public Locker(object P_0)
		{
			lvGhbVdMUyXaWbXfyWjHwcFNcVFEA = P_0;
			if (P_0 != null)
			{
				Monitor.Enter(P_0);
			}
		}

		public void Dispose()
		{
			if (lvGhbVdMUyXaWbXfyWjHwcFNcVFEA != null)
			{
				Monitor.Exit(lvGhbVdMUyXaWbXfyWjHwcFNcVFEA);
				lvGhbVdMUyXaWbXfyWjHwcFNcVFEA = null;
			}
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}
	}
}
