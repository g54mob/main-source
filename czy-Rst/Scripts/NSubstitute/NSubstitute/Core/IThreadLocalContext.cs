using System;
using System.Collections.Generic;
using NSubstitute.Core.Arguments;
using NSubstitute.Routing;

namespace NSubstitute.Core
{
	public interface IThreadLocalContext
	{
		IPendingSpecification PendingSpecification { get; }

		bool IsQuerying { get; }

		void SetLastCallRouter(ICallRouter callRouter);

		void ClearLastCallRouter();

		ConfiguredCall LastCallShouldReturn(IReturn value, MatchArgs matchArgs);

		void SetNextRoute(ICallRouter callRouter, Func<ISubstituteState, IRoute> nextRouteFactory);

		Func<ISubstituteState, IRoute>? UseNextRoute(ICallRouter callRouter);

		void EnqueueArgumentSpecification(IArgumentSpecification spec);

		IList<IArgumentSpecification> DequeueAllArgumentSpecifications();

		void SetPendingRaisingEventArgumentsFactory(Func<ICall, object?[]> getArguments);

		Func<ICall, object?[]>? UsePendingRaisingEventArgumentsFactory();

		void RunInQueryContext(Action calls, IQuery query);

		void RegisterInContextQuery(ICall call);
	}
}
