using System;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class GetSetValue<T> : IGetValue<T>, ISetValue<T>, IGetSetValue<T>
	{
		private Func<T> QAsMKDYGNskwLcVghuDGGkxtzBa;

		private Action<T> zeHenJNPyUVArrgijrQNskLukIX;

		public Func<T> getValueDelegate
		{
			get
			{
				return QAsMKDYGNskwLcVghuDGGkxtzBa;
			}
			set
			{
				QAsMKDYGNskwLcVghuDGGkxtzBa = value;
			}
		}

		public Action<T> setValueDelegate
		{
			get
			{
				return zeHenJNPyUVArrgijrQNskLukIX;
			}
			set
			{
				zeHenJNPyUVArrgijrQNskLukIX = value;
			}
		}

		public GetSetValue(Func<T> getValueDelegate, Action<T> setValueDelegate)
		{
			QAsMKDYGNskwLcVghuDGGkxtzBa = getValueDelegate;
			zeHenJNPyUVArrgijrQNskLukIX = setValueDelegate;
		}

		public T GetValue()
		{
			if (QAsMKDYGNskwLcVghuDGGkxtzBa == null)
			{
				throw new ArgumentNullException("getValueDelegate");
			}
			return QAsMKDYGNskwLcVghuDGGkxtzBa();
		}

		public void SetValue(T value)
		{
			if (zeHenJNPyUVArrgijrQNskLukIX == null)
			{
				throw new ArgumentNullException("setValueDelegate");
			}
			zeHenJNPyUVArrgijrQNskLukIX(value);
		}
	}
}
