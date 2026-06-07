using System;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal struct SetAndRestoreVar<T> : IDisposable
	{
		private readonly Action<T> ujMbJDgzZmBgiUCLNjbcgVBWBaG;

		private readonly T cGFdvKniovTlGrLmKzlNZvWhYsk;

		public SetAndRestoreVar(T oldValue, T newValue, Action<T> setValueDelegate)
		{
			ujMbJDgzZmBgiUCLNjbcgVBWBaG = null;
			cGFdvKniovTlGrLmKzlNZvWhYsk = default(T);
		}

		public void Dispose()
		{
		}
	}
}
