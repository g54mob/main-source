using System;

namespace NSubstitute.Core
{
	public class ConfiguredCall
	{
		public ConfiguredCall(Action<Action<CallInfo>> addAction)
		{
			_003CaddAction_003EP = addAction;
			base._002Ector();
		}

		public ConfiguredCall AndDoes(Action<CallInfo> action)
		{
			_003CaddAction_003EP(action);
			return this;
		}
	}
}
