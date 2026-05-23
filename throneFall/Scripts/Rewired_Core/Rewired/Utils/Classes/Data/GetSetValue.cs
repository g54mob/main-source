using System;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class GetSetValue<T> : IGetSetValue<T>, IGetValue<T>, ISetValue<T>
	{
		private Func<T> VWfGNFFAEmHVXYcZYDUiGxvCYSwj;

		private Action<T> YmKzcxknKnaemfJjdVUXuMLtZGdr;

		public Func<T> getValueDelegate
		{
			get
			{
				return VWfGNFFAEmHVXYcZYDUiGxvCYSwj;
			}
			set
			{
				VWfGNFFAEmHVXYcZYDUiGxvCYSwj = value;
			}
		}

		public Action<T> setValueDelegate
		{
			get
			{
				return YmKzcxknKnaemfJjdVUXuMLtZGdr;
			}
			set
			{
				YmKzcxknKnaemfJjdVUXuMLtZGdr = value;
			}
		}

		public GetSetValue(Func<T> P_0, Action<T> P_1)
		{
			VWfGNFFAEmHVXYcZYDUiGxvCYSwj = P_0;
			YmKzcxknKnaemfJjdVUXuMLtZGdr = P_1;
		}

		public T GetValue()
		{
			if (VWfGNFFAEmHVXYcZYDUiGxvCYSwj == null)
			{
				throw new ArgumentNullException("getValueDelegate");
			}
			return VWfGNFFAEmHVXYcZYDUiGxvCYSwj();
		}

		T IGetValue<T>.GetValue()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetValue
			return this.GetValue();
		}

		public void SetValue(T value)
		{
			if (YmKzcxknKnaemfJjdVUXuMLtZGdr == null)
			{
				throw new ArgumentNullException("setValueDelegate");
			}
			YmKzcxknKnaemfJjdVUXuMLtZGdr(value);
		}

		void ISetValue<T>.SetValue(T value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetValue
			this.SetValue(value);
		}
	}
}
