using System;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class GetSetValue<T> : IGetSetValue<T>, IGetValue<T>, ISetValue<T>
	{
		private Func<T> sqFfnojLneYjmAboxfmqZKQXDvxl;

		private Action<T> fiaqBWUWrpvnNdhEKulFbJcqILyJA;

		public Func<T> getValueDelegate
		{
			get
			{
				return sqFfnojLneYjmAboxfmqZKQXDvxl;
			}
			set
			{
				sqFfnojLneYjmAboxfmqZKQXDvxl = value;
			}
		}

		public Action<T> setValueDelegate
		{
			get
			{
				return fiaqBWUWrpvnNdhEKulFbJcqILyJA;
			}
			set
			{
				fiaqBWUWrpvnNdhEKulFbJcqILyJA = value;
			}
		}

		public GetSetValue(Func<T> P_0, Action<T> P_1)
		{
			sqFfnojLneYjmAboxfmqZKQXDvxl = P_0;
			fiaqBWUWrpvnNdhEKulFbJcqILyJA = P_1;
		}

		public T GetValue()
		{
			if (sqFfnojLneYjmAboxfmqZKQXDvxl == null)
			{
				throw new ArgumentNullException("getValueDelegate");
			}
			return sqFfnojLneYjmAboxfmqZKQXDvxl();
		}

		T IGetValue<T>.GetValue()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetValue
			return this.GetValue();
		}

		public void SetValue(T value)
		{
			if (fiaqBWUWrpvnNdhEKulFbJcqILyJA == null)
			{
				throw new ArgumentNullException("setValueDelegate");
			}
			fiaqBWUWrpvnNdhEKulFbJcqILyJA(value);
		}

		void ISetValue<T>.SetValue(T value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetValue
			this.SetValue(value);
		}
	}
}
