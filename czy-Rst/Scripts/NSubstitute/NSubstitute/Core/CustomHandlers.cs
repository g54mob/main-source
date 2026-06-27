using System.Collections.Generic;

namespace NSubstitute.Core
{
	public class CustomHandlers : ICustomHandlers
	{
		private readonly List<ICallHandler> _handlers;

		public IReadOnlyCollection<ICallHandler> Handlers => _handlers;

		public CustomHandlers(ISubstituteState substituteState)
		{
			_003CsubstituteState_003EP = substituteState;
			_handlers = new List<ICallHandler>();
			base._002Ector();
		}

		public void AddCustomHandlerFactory(CallHandlerFactory factory)
		{
			_handlers.Add(factory(_003CsubstituteState_003EP));
		}
	}
}
