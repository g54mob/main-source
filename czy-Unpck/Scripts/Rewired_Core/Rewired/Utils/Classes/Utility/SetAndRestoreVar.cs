using System;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal struct SetAndRestoreVar<T> : IDisposable
	{
		private readonly Action<T> PEyACEieifjOTAXmBlIZNCgUPLmT;

		private readonly T HLbIGBbobsQfdyjAQbYubcpnCGE;

		public SetAndRestoreVar(T oldValue, T newValue, Action<T> setValueDelegate)
		{
			if (setValueDelegate == null)
			{
				throw new ArgumentNullException("setValueDelegate");
			}
			PEyACEieifjOTAXmBlIZNCgUPLmT = setValueDelegate;
			HLbIGBbobsQfdyjAQbYubcpnCGE = oldValue;
			setValueDelegate(newValue);
		}

		public void Dispose()
		{
			PEyACEieifjOTAXmBlIZNCgUPLmT(HLbIGBbobsQfdyjAQbYubcpnCGE);
		}
	}
}
