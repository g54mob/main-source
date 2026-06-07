using System;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct SetAndRestoreVar<T> : IDisposable
	{
		private readonly Action<T> OIfDfqmlfobfirjIpQXnBkcjkCXi;

		private readonly T WFoVMbrfgtjGEQvmsEIYsDbWfuvh;

		public SetAndRestoreVar(T P_0, T P_1, Action<T> P_2)
		{
			if (P_2 == null)
			{
				throw new ArgumentNullException("setValueDelegate");
			}
			OIfDfqmlfobfirjIpQXnBkcjkCXi = P_2;
			WFoVMbrfgtjGEQvmsEIYsDbWfuvh = P_0;
			P_2(P_1);
		}

		public void Dispose()
		{
			OIfDfqmlfobfirjIpQXnBkcjkCXi(WFoVMbrfgtjGEQvmsEIYsDbWfuvh);
		}
	}
}
