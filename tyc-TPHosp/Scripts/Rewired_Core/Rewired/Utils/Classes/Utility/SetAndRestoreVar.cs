using System;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct SetAndRestoreVar<T> : IDisposable
	{
		private readonly Action<T> VitDvlkPaVchvwAimrYtgsjCsfr;

		private readonly T PGePwwbWFYoIPTaMftpRVpAthkH;

		public SetAndRestoreVar(T oldValue, T newValue, Action<T> setValueDelegate)
		{
			if (setValueDelegate == null)
			{
				throw new ArgumentNullException("setValueDelegate");
			}
			VitDvlkPaVchvwAimrYtgsjCsfr = setValueDelegate;
			PGePwwbWFYoIPTaMftpRVpAthkH = oldValue;
			setValueDelegate(newValue);
		}

		public void Dispose()
		{
			VitDvlkPaVchvwAimrYtgsjCsfr(PGePwwbWFYoIPTaMftpRVpAthkH);
		}
	}
}
