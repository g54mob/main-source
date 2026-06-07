using System;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct SetAndRestoreVar<T> : IDisposable
	{
		private readonly Action<T> AFYSbjhvhClhQFWgYTvtZAurgJpA;

		private readonly T xDQHvFebdPbIXMJqPOcHMsEyRCMvA;

		public SetAndRestoreVar(T P_0, T P_1, Action<T> P_2)
		{
			if (P_2 == null)
			{
				throw new ArgumentNullException("setValueDelegate");
			}
			AFYSbjhvhClhQFWgYTvtZAurgJpA = P_2;
			xDQHvFebdPbIXMJqPOcHMsEyRCMvA = P_0;
			P_2(P_1);
		}

		public void Dispose()
		{
			AFYSbjhvhClhQFWgYTvtZAurgJpA(xDQHvFebdPbIXMJqPOcHMsEyRCMvA);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}
	}
}
