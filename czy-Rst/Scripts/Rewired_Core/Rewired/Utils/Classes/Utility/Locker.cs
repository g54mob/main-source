using System;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct Locker : IDisposable
	{
		private object aSobowdwWpGqUFvgsDjnyydqUlNuA;

		public Locker(object P_0)
		{
			aSobowdwWpGqUFvgsDjnyydqUlNuA = P_0;
			if (P_0 != null)
			{
				Monitor.Enter(P_0);
			}
		}

		public void Dispose()
		{
			if (aSobowdwWpGqUFvgsDjnyydqUlNuA != null)
			{
				Monitor.Exit(aSobowdwWpGqUFvgsDjnyydqUlNuA);
				aSobowdwWpGqUFvgsDjnyydqUlNuA = null;
			}
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}
	}
}
