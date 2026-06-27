using System;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class SpinLock : IDisposable
	{
		private const int hKHTGLXkStWSeOqhYcIFIQzPydTuA = 1;

		private const int ZiUuYtNcyZhkXSLYVSqIZOnHFmat = 0;

		private int fddGerBFfOgOBBrneUmGCtQWzENfb;

		void IDisposable.Dispose()
		{
			TnjetkzKhWkyjqIJXXXlmiOhRvnL();
		}

		private void xPcTOLbKxTYxgRxfvWRoHelRMWbP()
		{
			while (Interlocked.Exchange(ref fddGerBFfOgOBBrneUmGCtQWzENfb, 1) != 0)
			{
				Thread.SpinWait(1);
			}
		}

		private void TnjetkzKhWkyjqIJXXXlmiOhRvnL()
		{
			Interlocked.Exchange(ref fddGerBFfOgOBBrneUmGCtQWzENfb, 0);
		}

		public SpinLock Lock()
		{
			xPcTOLbKxTYxgRxfvWRoHelRMWbP();
			return this;
		}
	}
}
