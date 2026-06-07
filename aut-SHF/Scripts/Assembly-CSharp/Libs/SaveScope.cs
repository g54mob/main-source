using System;

namespace Libs
{
	public class SaveScope : IDisposable
	{
		public static bool PermitSave;

		public void Dispose()
		{
		}
	}
}
