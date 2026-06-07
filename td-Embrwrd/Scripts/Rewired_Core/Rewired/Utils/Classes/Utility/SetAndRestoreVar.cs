using System;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct SetAndRestoreVar<T> : IDisposable
	{
		private readonly Action<T> hYHLZfIIixoSzeNfLAoVieTULAwIA;

		private readonly T MRYeiNGLiLhoZelZoFYzHNrOmFlG;

		public SetAndRestoreVar(T P_0, T P_1, Action<T> P_2)
		{
			hYHLZfIIixoSzeNfLAoVieTULAwIA = null;
			MRYeiNGLiLhoZelZoFYzHNrOmFlG = default(T);
		}

		public void Dispose()
		{
		}
	}
}
