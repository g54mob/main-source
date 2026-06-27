using System;
using System.Collections.Generic;
using NSubstitute.Core.Arguments;
using NSubstitute.Routing;

namespace NSubstitute.Core
{
	public interface ISubstitutionContext
	{
		ISubstituteFactory SubstituteFactory { get; }

		IRouteFactory RouteFactory { get; }

		ICallSpecificationFactory CallSpecificationFactory { get; }

		IThreadLocalContext ThreadContext { get; }

		[Obsolete("This property is obsolete and will be removed in a future version of the product.")]
		SequenceNumberGenerator SequenceNumberGenerator { get; }

		[Obsolete("This property is obsolete and will be removed in a future version of the product. Use the ThreadContext.PendingSpecification property instead. For example: SubstitutionContext.Current.ThreadContext.PendingSpecification.")]
		PendingSpecificationInfo? PendingSpecificationInfo { get; set; }

		[Obsolete("This property is obsolete and will be removed in a future version of the product. Use the ThreadContext.IsQuerying property instead. For example: SubstitutionContext.Current.ThreadContext.IsQuerying.")]
		bool IsQuerying { get; }

		ICallRouter GetCallRouterFor(object substitute);

		[Obsolete("This method is obsolete and will be removed in a future version of the product. Use the ThreadContext.LastCallShouldReturn() method instead. For example: SubstitutionContext.Current.ThreadContext.LastCallShouldReturn(...).")]
		ConfiguredCall LastCallShouldReturn(IReturn value, MatchArgs matchArgs);

		[Obsolete("This method is obsolete and will be removed in a future version of the product. Use the ThreadContext.SetLastCallRouter() method instead. For example: SubstitutionContext.Current.ThreadContext.SetLastCallRouter(...).")]
		void LastCallRouter(ICallRouter callRouter);

		[Obsolete("This method is obsolete and will be removed in a future version of the product. Use the ThreadContext.EnqueueArgumentSpecification() method instead. For example: SubstitutionContext.Current.ThreadContext.EnqueueArgumentSpecification(...).")]
		void EnqueueArgumentSpecification(IArgumentSpecification spec);

		[Obsolete("This method is obsolete and will be removed in a future version of the product. Use the ThreadContext.DequeueAllArgumentSpecifications() method instead. For example: SubstitutionContext.Current.ThreadContext.DequeueAllArgumentSpecifications().")]
		IList<IArgumentSpecification> DequeueAllArgumentSpecifications();

		[Obsolete("This method is obsolete and will be removed in a future version of the product. Use the ThreadContext.SetPendingRaisingEventArgumentsFactory() method instead. For example: SubstitutionContext.Current.ThreadContext.SetPendingRaisingEventArgumentsFactory(...).")]
		void RaiseEventForNextCall(Func<ICall, object[]> getArguments);

		[Obsolete("This method is obsolete and will be removed in a future version of the product. Use the ThreadContext.UsePendingRaisingEventArgumentsFactory() method instead. For example: SubstitutionContext.Current.ThreadContext.UsePendingRaisingEventArgumentsFactory().")]
		Func<ICall, object?[]>? DequeuePendingRaisingEventArguments();

		[Obsolete("This method is obsolete and will be removed in a future version of the product. Use the ThreadContext.RunInQueryContext() method instead. For example: SubstitutionContext.Current.ThreadContext.RunInQueryContext(...).")]
		IQueryResults RunQuery(Action calls);

		[Obsolete("This method is obsolete and will be removed in a future version of the product. Use the ThreadContext.RegisterInContextQuery() method instead. For example: SubstitutionContext.Current.ThreadContext.RegisterInContextQuery().", true)]
		void AddToQuery(object target, ICallSpecification callSpecification);

		[Obsolete("This method is obsolete and will be removed in a future version of the product. Use the ThreadContext.ClearLastCallRouter() method instead. For example: SubstitutionContext.Current.ThreadContext.ClearLastCallRouter().")]
		void ClearLastCallRouter();

		[Obsolete("This method is obsolete and will be removed in a future version of the product. Use the RouteFactory property instead.")]
		IRouteFactory GetRouteFactory();
	}
}
