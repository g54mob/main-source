using System;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class GetSetValue<T> : IGetValue<T>, ISetValue<T>, IGetSetValue<T>
	{
		private Func<T> wkGzazliBvLdFdElaLyPQKXJFWA;

		private Action<T> VitDvlkPaVchvwAimrYtgsjCsfr;

		public Func<T> getValueDelegate
		{
			get
			{
				return wkGzazliBvLdFdElaLyPQKXJFWA;
			}
			set
			{
				wkGzazliBvLdFdElaLyPQKXJFWA = value;
			}
		}

		public Action<T> setValueDelegate
		{
			get
			{
				return VitDvlkPaVchvwAimrYtgsjCsfr;
			}
			set
			{
				VitDvlkPaVchvwAimrYtgsjCsfr = value;
			}
		}

		public GetSetValue(Func<T> getValueDelegate, Action<T> setValueDelegate)
		{
			wkGzazliBvLdFdElaLyPQKXJFWA = getValueDelegate;
			VitDvlkPaVchvwAimrYtgsjCsfr = setValueDelegate;
		}

		public T GetValue()
		{
			if (wkGzazliBvLdFdElaLyPQKXJFWA == null)
			{
				throw new ArgumentNullException("getValueDelegate");
			}
			return wkGzazliBvLdFdElaLyPQKXJFWA();
		}

		public void SetValue(T value)
		{
			if (VitDvlkPaVchvwAimrYtgsjCsfr == null)
			{
				throw new ArgumentNullException("setValueDelegate");
			}
			VitDvlkPaVchvwAimrYtgsjCsfr(value);
		}
	}
}
