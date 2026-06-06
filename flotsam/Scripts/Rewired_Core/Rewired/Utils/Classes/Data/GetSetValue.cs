using System;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class GetSetValue<T> : IGetSetValue<T>, IGetValue<T>, ISetValue<T>
	{
		private Func<T> ymFfmpFHoiCcIlQtixSJGWoyGBxE;

		private Action<T> vKgTDRwIRtErnKAcLSikHgoJEGqvA;

		public Func<T> getValueDelegate
		{
			get
			{
				return ymFfmpFHoiCcIlQtixSJGWoyGBxE;
			}
			set
			{
				ymFfmpFHoiCcIlQtixSJGWoyGBxE = value;
			}
		}

		public Action<T> setValueDelegate
		{
			get
			{
				return vKgTDRwIRtErnKAcLSikHgoJEGqvA;
			}
			set
			{
				vKgTDRwIRtErnKAcLSikHgoJEGqvA = value;
			}
		}

		public GetSetValue(Func<T> P_0, Action<T> P_1)
		{
			ymFfmpFHoiCcIlQtixSJGWoyGBxE = P_0;
			vKgTDRwIRtErnKAcLSikHgoJEGqvA = P_1;
		}

		public T GetValue()
		{
			if (ymFfmpFHoiCcIlQtixSJGWoyGBxE == null)
			{
				throw new ArgumentNullException("getValueDelegate");
			}
			return ymFfmpFHoiCcIlQtixSJGWoyGBxE();
		}

		T IGetValue<T>.GetValue()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetValue
			return this.GetValue();
		}

		public void SetValue(T value)
		{
			if (vKgTDRwIRtErnKAcLSikHgoJEGqvA == null)
			{
				throw new ArgumentNullException("setValueDelegate");
			}
			vKgTDRwIRtErnKAcLSikHgoJEGqvA(value);
		}

		void ISetValue<T>.SetValue(T value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetValue
			this.SetValue(value);
		}
	}
}
