using System;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct SetAndRestoreVar<T> : IDisposable
	{
		private readonly Action<T> zeHenJNPyUVArrgijrQNskLukIX;

		private readonly T tMAcNUOfpNaXNCRCuCdmDaGLztf;

		public SetAndRestoreVar(T oldValue, T newValue, Action<T> setValueDelegate)
		{
			if (setValueDelegate == null)
			{
				throw new ArgumentNullException("setValueDelegate");
			}
			zeHenJNPyUVArrgijrQNskLukIX = setValueDelegate;
			tMAcNUOfpNaXNCRCuCdmDaGLztf = oldValue;
			setValueDelegate(newValue);
		}

		public void Dispose()
		{
			zeHenJNPyUVArrgijrQNskLukIX(tMAcNUOfpNaXNCRCuCdmDaGLztf);
		}
	}
}
