using System;

namespace Libs
{
	public class SwitchExitRequestHandlingSection : IDisposable
	{
		private readonly bool _commit;

		public SwitchExitRequestHandlingSection(bool commit = true)
		{
		}

		public void Dispose()
		{
		}
	}
}
