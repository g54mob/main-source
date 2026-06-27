using NSubstitute.Core;

namespace NSubstitute.Routing.Handlers
{
	public class RecordCallHandler : ICallHandler
	{
		public RecordCallHandler(ICallCollection callCollection, SequenceNumberGenerator generator)
		{
			_003CcallCollection_003EP = callCollection;
			_003Cgenerator_003EP = generator;
			base._002Ector();
		}

		public RouteAction Handle(ICall call)
		{
			call.AssignSequenceNumber(_003Cgenerator_003EP.Next());
			_003CcallCollection_003EP.Add(call);
			return RouteAction.Continue();
		}
	}
}
