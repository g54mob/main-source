using System;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct SetAndRestoreVar<T> : IDisposable
	{
		private readonly Action<T> FhsfgSwDPrEyhcWGmXxImfCVYVCD;

		private readonly T LMxOaLhLIoWoNjNwfdWtYgVmHOo;

		public SetAndRestoreVar(T oldValue, T newValue, Action<T> setValueDelegate)
		{
			if (setValueDelegate == null)
			{
				throw new ArgumentNullException("setValueDelegate");
			}
			FhsfgSwDPrEyhcWGmXxImfCVYVCD = setValueDelegate;
			LMxOaLhLIoWoNjNwfdWtYgVmHOo = oldValue;
			setValueDelegate(newValue);
		}

		public void Dispose()
		{
			FhsfgSwDPrEyhcWGmXxImfCVYVCD(LMxOaLhLIoWoNjNwfdWtYgVmHOo);
		}
	}
}
