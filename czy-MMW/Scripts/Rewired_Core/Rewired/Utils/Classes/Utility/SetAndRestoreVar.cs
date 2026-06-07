using System;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct SetAndRestoreVar<T> : IDisposable
	{
		private readonly Action<T> rHaQwvinncWGRGSKvJMeewAOGwlr;

		private readonly T KOxHiDwtdUdihIAsWhrUNPAQVUqU;

		public SetAndRestoreVar(T P_0, T P_1, Action<T> P_2)
		{
			if (P_2 == null)
			{
				throw new ArgumentNullException("setValueDelegate");
			}
			rHaQwvinncWGRGSKvJMeewAOGwlr = P_2;
			KOxHiDwtdUdihIAsWhrUNPAQVUqU = P_0;
			P_2(P_1);
		}

		public void Dispose()
		{
			rHaQwvinncWGRGSKvJMeewAOGwlr(KOxHiDwtdUdihIAsWhrUNPAQVUqU);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}
	}
}
