using System;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class GetSetValue<T> : IGetSetValue<T>, IGetValue<T>, ISetValue<T>
	{
		private Func<T> InODohJgmOnloZBuCoOIuxhhGRop;

		private Action<T> pstiUvYsXktUKIJoMFeTfAVyvoVBA;

		public Func<T> getValueDelegate
		{
			get
			{
				return InODohJgmOnloZBuCoOIuxhhGRop;
			}
			set
			{
				InODohJgmOnloZBuCoOIuxhhGRop = value;
			}
		}

		public Action<T> setValueDelegate
		{
			get
			{
				return pstiUvYsXktUKIJoMFeTfAVyvoVBA;
			}
			set
			{
				pstiUvYsXktUKIJoMFeTfAVyvoVBA = value;
			}
		}

		public GetSetValue(Func<T> P_0, Action<T> P_1)
		{
			InODohJgmOnloZBuCoOIuxhhGRop = P_0;
			pstiUvYsXktUKIJoMFeTfAVyvoVBA = P_1;
		}

		public T GetValue()
		{
			if (InODohJgmOnloZBuCoOIuxhhGRop == null)
			{
				throw new ArgumentNullException("getValueDelegate");
			}
			return InODohJgmOnloZBuCoOIuxhhGRop();
		}

		public void SetValue(T value)
		{
			if (pstiUvYsXktUKIJoMFeTfAVyvoVBA == null)
			{
				throw new ArgumentNullException("setValueDelegate");
			}
			pstiUvYsXktUKIJoMFeTfAVyvoVBA(value);
		}
	}
}
