using System;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct SetAndRestoreVar<T> : IDisposable
	{
		private readonly Action<T> vXbzOSJWIjyzUPCfBsIzEEzhxlOL;

		private readonly T QuuhWqTIULCNsHpNwhZJdLdbdHLBA;

		public SetAndRestoreVar(T P_0, T P_1, Action<T> P_2)
		{
			if (P_2 == null)
			{
				throw new ArgumentNullException("setValueDelegate");
			}
			vXbzOSJWIjyzUPCfBsIzEEzhxlOL = P_2;
			QuuhWqTIULCNsHpNwhZJdLdbdHLBA = P_0;
			P_2(P_1);
		}

		public void Dispose()
		{
			vXbzOSJWIjyzUPCfBsIzEEzhxlOL(QuuhWqTIULCNsHpNwhZJdLdbdHLBA);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}
	}
}
