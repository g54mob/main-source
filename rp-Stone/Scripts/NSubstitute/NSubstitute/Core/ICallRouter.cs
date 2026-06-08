using System;
using System.Collections.Generic;
using NSubstitute.Routing;

namespace NSubstitute.Core
{
	public interface ICallRouter
	{
		bool CallBaseByDefault { get; set; }

		ConfiguredCall LastCallShouldReturn(IReturn returnValue, MatchArgs matchArgs, PendingSpecificationInfo pendingSpecInfo);

		object? Route(ICall call);

		IEnumerable<ICall> ReceivedCalls();

		[Obsolete("This method is deprecated and will be removed in future versions of the product. Please use IThreadLocalContext.SetNextRoute method instead.")]
		void SetRoute(Func<ISubstituteState, IRoute> getRoute);

		void SetReturnForType(Type type, IReturn returnValue);

		void RegisterCustomCallHandlerFactory(CallHandlerFactory factory);

		void Clear(ClearOptions clear);
	}
}
