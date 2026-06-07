using System;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct SetAndRestoreVar<T> : IDisposable
	{
		private readonly Action<T> qDwObFCABtjNABsRCLvSOUONaWXd;

		private readonly T wptfvYRvQugLgNktNdvdrwTikHl;

		public SetAndRestoreVar(T oldValue, T newValue, Action<T> setValueDelegate)
		{
			if (setValueDelegate == null)
			{
				throw new ArgumentNullException("setValueDelegate");
			}
			qDwObFCABtjNABsRCLvSOUONaWXd = setValueDelegate;
			wptfvYRvQugLgNktNdvdrwTikHl = oldValue;
			setValueDelegate(newValue);
		}

		public void Dispose()
		{
			qDwObFCABtjNABsRCLvSOUONaWXd(wptfvYRvQugLgNktNdvdrwTikHl);
		}
	}
}
