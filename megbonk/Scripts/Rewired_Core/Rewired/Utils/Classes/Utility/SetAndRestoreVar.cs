using System;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct SetAndRestoreVar<T> : IDisposable
	{
		private readonly Action<T> wrETqlLNIcbZjEuvoYBdsADsWfxj;

		private readonly T RyRmwHVMUICKHUNUDFvFAJRyIceAb;

		public SetAndRestoreVar(T P_0, T P_1, Action<T> P_2)
		{
			wrETqlLNIcbZjEuvoYBdsADsWfxj = null;
			RyRmwHVMUICKHUNUDFvFAJRyIceAb = default(T);
		}

		public void Dispose()
		{
		}
	}
}
