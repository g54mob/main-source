using System;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class GetSetValue<T> : IGetSetValue<T>, IGetValue<T>, ISetValue<T>
	{
		private Func<T> lskGbsCMSemynYJGLNWNIzJVIuUNA;

		private Action<T> irFFCEdOKdPeOihgqPWeFNhqumZJ;

		public Func<T> getValueDelegate
		{
			get
			{
				return lskGbsCMSemynYJGLNWNIzJVIuUNA;
			}
			set
			{
				lskGbsCMSemynYJGLNWNIzJVIuUNA = value;
			}
		}

		public Action<T> setValueDelegate
		{
			get
			{
				return irFFCEdOKdPeOihgqPWeFNhqumZJ;
			}
			set
			{
				irFFCEdOKdPeOihgqPWeFNhqumZJ = value;
			}
		}

		public GetSetValue(Func<T> P_0, Action<T> P_1)
		{
			lskGbsCMSemynYJGLNWNIzJVIuUNA = P_0;
			irFFCEdOKdPeOihgqPWeFNhqumZJ = P_1;
		}

		public T GetValue()
		{
			if (lskGbsCMSemynYJGLNWNIzJVIuUNA == null)
			{
				throw new ArgumentNullException("getValueDelegate");
			}
			return lskGbsCMSemynYJGLNWNIzJVIuUNA();
		}

		T IGetValue<T>.GetValue()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetValue
			return this.GetValue();
		}

		public void SetValue(T value)
		{
			if (irFFCEdOKdPeOihgqPWeFNhqumZJ == null)
			{
				throw new ArgumentNullException("setValueDelegate");
			}
			irFFCEdOKdPeOihgqPWeFNhqumZJ(value);
		}

		void ISetValue<T>.SetValue(T value)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetValue
			this.SetValue(value);
		}
	}
}
