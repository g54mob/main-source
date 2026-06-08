using System;

namespace NSubstitute.Core
{
	public class ConfiguredCall
	{
		private readonly Action<Action<CallInfo>> _addAction;

		public ConfiguredCall(Action<Action<CallInfo>> addAction)
		{
			_addAction = addAction;
		}

		public ConfiguredCall AndDoes(Action<CallInfo> action)
		{
			_addAction(action);
			return this;
		}
	}
}
