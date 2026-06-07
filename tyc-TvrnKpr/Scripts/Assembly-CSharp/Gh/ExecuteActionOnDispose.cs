using System;

namespace Gh
{
	public class ExecuteActionOnDispose : IDisposable
	{
		private Action _dispose;

		public ExecuteActionOnDispose(Action dispose)
		{
		}

		public void Dispose()
		{
		}
	}
}
