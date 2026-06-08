using System;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class GetSetValue<T> : IGetValue<T>, ISetValue<T>, IGetSetValue<T>
	{
		private Func<T> gbPDaGjyXRjKfIzuXktAcUGDsrN;

		private Action<T> PEyACEieifjOTAXmBlIZNCgUPLmT;

		public Func<T> getValueDelegate
		{
			get
			{
				return gbPDaGjyXRjKfIzuXktAcUGDsrN;
			}
			set
			{
				gbPDaGjyXRjKfIzuXktAcUGDsrN = value;
			}
		}

		public Action<T> setValueDelegate
		{
			get
			{
				return PEyACEieifjOTAXmBlIZNCgUPLmT;
			}
			set
			{
				PEyACEieifjOTAXmBlIZNCgUPLmT = value;
			}
		}

		public GetSetValue(Func<T> getValueDelegate, Action<T> setValueDelegate)
		{
			gbPDaGjyXRjKfIzuXktAcUGDsrN = getValueDelegate;
			PEyACEieifjOTAXmBlIZNCgUPLmT = setValueDelegate;
		}

		public T GetValue()
		{
			if (gbPDaGjyXRjKfIzuXktAcUGDsrN == null)
			{
				throw new ArgumentNullException("getValueDelegate");
			}
			return gbPDaGjyXRjKfIzuXktAcUGDsrN();
		}

		public void SetValue(T value)
		{
			if (PEyACEieifjOTAXmBlIZNCgUPLmT == null)
			{
				throw new ArgumentNullException("setValueDelegate");
			}
			PEyACEieifjOTAXmBlIZNCgUPLmT(value);
		}
	}
}
