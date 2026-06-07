using System;

namespace Jundroo.Common.DataTypes
{
	public class DisposableAction : IDisposable
	{
		private readonly Action _action;

		public DisposableAction(Action disposeAction)
		{
			_action = disposeAction;
		}

		public void Dispose()
		{
			_action?.Invoke();
		}
	}
}
