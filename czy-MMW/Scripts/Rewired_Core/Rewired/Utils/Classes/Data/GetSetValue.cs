using System;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class GetSetValue<T> : IGetSetValue<T>, IGetValue<T>, ISetValue<T>
	{
		private Func<T> qNEgwZIyIjOczTQLXtUdhQloQKIq;

		private Action<T> dXfMMbdHCedNUcnfodTQdTRBiURbb;

		public Func<T> getValueDelegate
		{
			get
			{
				return qNEgwZIyIjOczTQLXtUdhQloQKIq;
			}
			set
			{
				qNEgwZIyIjOczTQLXtUdhQloQKIq = value;
			}
		}

		public Action<T> setValueDelegate
		{
			get
			{
				return dXfMMbdHCedNUcnfodTQdTRBiURbb;
			}
			set
			{
				dXfMMbdHCedNUcnfodTQdTRBiURbb = value;
			}
		}

		public GetSetValue(Func<T> P_0, Action<T> P_1)
		{
			qNEgwZIyIjOczTQLXtUdhQloQKIq = P_0;
			dXfMMbdHCedNUcnfodTQdTRBiURbb = P_1;
		}

		public T GetValue()
		{
			if (qNEgwZIyIjOczTQLXtUdhQloQKIq == null)
			{
				throw new ArgumentNullException("getValueDelegate");
			}
			return qNEgwZIyIjOczTQLXtUdhQloQKIq();
		}

		T IGetValue<T>.GetValue()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetValue
			return this.GetValue();
		}

		public void SetValue(T value)
		{
			if (dXfMMbdHCedNUcnfodTQdTRBiURbb == null)
			{
				throw new ArgumentNullException("setValueDelegate");
			}
			dXfMMbdHCedNUcnfodTQdTRBiURbb(value);
		}

		void ISetValue<T>.SetValue(T value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetValue
			this.SetValue(value);
		}
	}
}
