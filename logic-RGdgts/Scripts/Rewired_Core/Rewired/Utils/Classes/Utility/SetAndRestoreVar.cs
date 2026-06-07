using System;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal struct SetAndRestoreVar<T> : IDisposable
	{
		private readonly Action<T> pstiUvYsXktUKIJoMFeTfAVyvoVBA;

		private readonly T jCcUCkLPMxJIgjXUBQsejvQRejrp;

		public SetAndRestoreVar(T P_0, T P_1, Action<T> P_2)
		{
			pstiUvYsXktUKIJoMFeTfAVyvoVBA = null;
			jCcUCkLPMxJIgjXUBQsejvQRejrp = default(T);
		}

		public void Dispose()
		{
		}
	}
}
