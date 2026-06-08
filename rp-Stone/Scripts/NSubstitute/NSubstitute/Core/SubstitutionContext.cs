using System;
using System.Collections.Generic;
using NSubstitute.Core.Arguments;
using NSubstitute.Core.DependencyInjection;
using NSubstitute.Routing;

namespace NSubstitute.Core
{
	public class SubstitutionContext : ISubstitutionContext
	{
		private readonly ICallRouterResolver _callRouterResolver;

		public static ISubstitutionContext Current { get; set; }

		public ISubstituteFactory SubstituteFactory { get; }

		public IRouteFactory RouteFactory { get; }

		public IThreadLocalContext ThreadContext { get; }

		public ICallSpecificationFactory CallSpecificationFactory { get; }

		[Obsolete("This property is obsolete and will be removed in a future version of the product.")]
		public SequenceNumberGenerator SequenceNumberGenerator { get; }

		[Obsolete("This property is obsolete and will be removed in a future version of the product. Use the ThreadContext.IsQuerying property instead. For example: SubstitutionContext.Current.ThreadContext.IsQuerying.")]
		public bool IsQuerying => ThreadContext.IsQuerying;

		[Obsolete("This property is obsolete and will be removed in a future version of the product. Use the ThreadContext.PendingSpecification property instead. For example: SubstitutionContext.Current.ThreadContext.PendingSpecification.")]
		public PendingSpecificationInfo? PendingSpecificationInfo
		{
			get
			{
				if (!ThreadContext.PendingSpecification.HasPendingCallSpecInfo())
				{
					return null;
				}
				return PendingSpecificationInfo = ThreadContext.PendingSpecification.UseCallSpecInfo();
			}
			set
			{
				if (value == null)
				{
					ThreadContext.PendingSpecification.Clear();
					return;
				}
				Tuple<ICallSpecification, ICall> tuple = value.Handle((ICallSpecification spec) => Tuple.Create<ICallSpecification, ICall>(spec, null), (ICall call) => Tuple.Create<ICallSpecification, ICall>(null, call));
				if (tuple.Item1 != null)
				{
					ThreadContext.PendingSpecification.SetCallSpecification(tuple.Item1);
				}
				else
				{
					ThreadContext.PendingSpecification.SetLastCall(tuple.Item2);
				}
			}
		}

		static SubstitutionContext()
		{
			Current = NSubstituteDefaultFactory.CreateSubstitutionContext();
		}

		public SubstitutionContext(ISubstituteFactory substituteFactory, IRouteFactory routeFactory, ICallSpecificationFactory callSpecificationFactory, IThreadLocalContext threadLocalContext, ICallRouterResolver callRouterResolver, SequenceNumberGenerator sequenceNumberGenerator)
		{
			SubstituteFactory = substituteFactory;
			RouteFactory = routeFactory;
			CallSpecificationFactory = callSpecificationFactory;
			ThreadContext = threadLocalContext;
			_callRouterResolver = callRouterResolver;
			SequenceNumberGenerator = sequenceNumberGenerator;
		}

		public ICallRouter GetCallRouterFor(object substitute)
		{
			return _callRouterResolver.ResolveFor(substitute);
		}

		[Obsolete("This method is obsolete and will be removed in a future version of the product. Use the ThreadContext.LastCallShouldReturn() method instead. For example: SubstitutionContext.Current.ThreadContext.LastCallShouldReturn(...).")]
		public ConfiguredCall LastCallShouldReturn(IReturn value, MatchArgs matchArgs)
		{
			return ThreadContext.LastCallShouldReturn(value, matchArgs);
		}

		[Obsolete("This method is obsolete and will be removed in a future version of the product. Use the ThreadContext.ClearLastCallRouter() method instead. For example: SubstitutionContext.Current.ThreadContext.ClearLastCallRouter().")]
		public void ClearLastCallRouter()
		{
			ThreadContext.ClearLastCallRouter();
		}

		[Obsolete("This method is obsolete and will be removed in a future version of the product. Use the RouteFactory property instead.")]
		public IRouteFactory GetRouteFactory()
		{
			return RouteFactory;
		}

		[Obsolete("This method is obsolete and will be removed in a future version of the product. Use the ThreadContext.SetLastCallRouter() method instead. For example: SubstitutionContext.Current.ThreadContext.SetLastCallRouter(...).")]
		public void LastCallRouter(ICallRouter callRouter)
		{
			ThreadContext.SetLastCallRouter(callRouter);
		}

		[Obsolete("This method is obsolete and will be removed in a future version of the product. Use the ThreadContext.EnqueueArgumentSpecification() method instead. For example: SubstitutionContext.Current.ThreadContext.EnqueueArgumentSpecification(...).")]
		public void EnqueueArgumentSpecification(IArgumentSpecification spec)
		{
			ThreadContext.EnqueueArgumentSpecification(spec);
		}

		[Obsolete("This method is obsolete and will be removed in a future version of the product. Use the ThreadContext.DequeueAllArgumentSpecifications() method instead. For example: SubstitutionContext.Current.ThreadContext.DequeueAllArgumentSpecifications().")]
		public IList<IArgumentSpecification> DequeueAllArgumentSpecifications()
		{
			return ThreadContext.DequeueAllArgumentSpecifications();
		}

		[Obsolete("This method is obsolete and will be removed in a future version of the product. Use the ThreadContext.SetPendingRaisingEventArgumentsFactory() method instead. For example: SubstitutionContext.Current.ThreadContext.SetPendingRaisingEventArgumentsFactory(...).")]
		public void RaiseEventForNextCall(Func<ICall, object[]> getArguments)
		{
			ThreadContext.SetPendingRaisingEventArgumentsFactory(getArguments);
		}

		[Obsolete("This method is obsolete and will be removed in a future version of the product. Use the ThreadContext.UsePendingRaisingEventArgumentsFactory() method instead. For example: SubstitutionContext.Current.ThreadContext.UsePendingRaisingEventArgumentsFactory().")]
		public Func<ICall, object?[]>? DequeuePendingRaisingEventArguments()
		{
			return ThreadContext.UsePendingRaisingEventArgumentsFactory();
		}

		[Obsolete("This method is obsolete and will be removed in a future version of the product. Use the ThreadContext.RegisterInContextQuery() method instead. For example: SubstitutionContext.Current.ThreadContext.RegisterInContextQuery().", true)]
		public void AddToQuery(object target, ICallSpecification callSpecification)
		{
			throw new NotSupportedException("This API was obsolete and is not supported anymore. Please use the ThreadContext.RegisterInContextQuery() method instead. For example: SubstitutionContext.Current.ThreadContext.RegisterInContextQuery().");
		}

		[Obsolete("This method is obsolete and will be removed in a future version of the product. Use the ThreadContext.RunInQueryContext() method instead. For example: SubstitutionContext.Current.ThreadContext.RunInQueryContext(...).")]
		public IQueryResults RunQuery(Action calls)
		{
			Query query = new Query(CallSpecificationFactory);
			ThreadContext.RunInQueryContext(calls, query);
			return query.Result();
		}
	}
}
