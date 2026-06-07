using System;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class GetSetValue<T> : IGetSetValue<T>, IGetValue<T>, ISetValue<T>
	{
		private Func<T> cKLxdJBcLPBLeIVUritoZLRnxioWA;

		private Action<T> hboNZfmFaKmdLydcOeOPzNnCqDfm;

		public Func<T> getValueDelegate
		{
			get
			{
				return cKLxdJBcLPBLeIVUritoZLRnxioWA;
			}
			set
			{
				cKLxdJBcLPBLeIVUritoZLRnxioWA = value;
			}
		}

		public Action<T> setValueDelegate
		{
			get
			{
				return hboNZfmFaKmdLydcOeOPzNnCqDfm;
			}
			set
			{
				hboNZfmFaKmdLydcOeOPzNnCqDfm = value;
			}
		}

		public GetSetValue(Func<T> P_0, Action<T> P_1)
		{
			cKLxdJBcLPBLeIVUritoZLRnxioWA = P_0;
			hboNZfmFaKmdLydcOeOPzNnCqDfm = P_1;
		}

		public T GetValue()
		{
			if (cKLxdJBcLPBLeIVUritoZLRnxioWA == null)
			{
				throw new ArgumentNullException("getValueDelegate");
			}
			return cKLxdJBcLPBLeIVUritoZLRnxioWA();
		}

		T IGetValue<T>.GetValue()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetValue
			return this.GetValue();
		}

		public void SetValue(T value)
		{
			if (hboNZfmFaKmdLydcOeOPzNnCqDfm == null)
			{
				throw new ArgumentNullException("setValueDelegate");
			}
			hboNZfmFaKmdLydcOeOPzNnCqDfm(value);
		}

		void ISetValue<T>.SetValue(T value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetValue
			this.SetValue(value);
		}
	}
}
