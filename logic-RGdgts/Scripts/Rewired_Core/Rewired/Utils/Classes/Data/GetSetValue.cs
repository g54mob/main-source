using System;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal sealed class GetSetValue<T> : IGetSetValue<T>, IGetValue<T>, ISetValue<T>
	{
		private Func<T> InODohJgmOnloZBuCoOIuxhhGRop;

		private Action<T> pstiUvYsXktUKIJoMFeTfAVyvoVBA;

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

		public GetSetValue(Func<T> P_0, Action<T> P_1)
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
