using System;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal sealed class GetSetValue<T> : IGetValue<T>, ISetValue<T>, IGetSetValue<T>
	{
		private Func<T> TenHBVpYBIaGtZIcXHrwKtCLyfF;

		private Action<T> ujMbJDgzZmBgiUCLNjbcgVBWBaG;

		public Func<T> getValueDelegate
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Action<T> setValueDelegate
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public GetSetValue(Func<T> getValueDelegate, Action<T> setValueDelegate)
		{
		}

		public T GetValue()
		{
			return default(T);
		}

		public void SetValue(T value)
		{
		}
	}
}
