using System;
using System.Collections.Generic;
using NSubstitute.Core.Arguments;
using NSubstitute.Exceptions;
using NSubstitute.Routing;

namespace NSubstitute.Core
{
	public class ThreadLocalContext : IThreadLocalContext
	{
		private class PendingSpecificationWrapper : IPendingSpecification
		{
			private readonly RobustThreadLocal<PendingSpecInfoData> _valueHolder;

			public PendingSpecificationWrapper(RobustThreadLocal<PendingSpecInfoData> valueHolder)
			{
				_valueHolder = valueHolder;
			}

			public bool HasPendingCallSpecInfo()
			{
				return _valueHolder.Value.HasValue;
			}

			public PendingSpecificationInfo? UseCallSpecInfo()
			{
				PendingSpecInfoData value = _valueHolder.Value;
				Clear();
				return value.ToPendingSpecificationInfo();
			}

			public void SetCallSpecification(ICallSpecification callSpecification)
			{
				_valueHolder.Value = PendingSpecInfoData.FromCallSpecification(callSpecification);
			}

			public void SetLastCall(ICall lastCall)
			{
				_valueHolder.Value = PendingSpecInfoData.FromLastCall(lastCall);
			}

			public void Clear()
			{
				_valueHolder.Value = default(PendingSpecInfoData);
			}
		}

		private readonly struct PendingSpecInfoData
		{
			private readonly ICallSpecification? _callSpecification;

			private readonly ICall? _lastCall;

			public bool HasValue
			{
				get
				{
					if (_lastCall == null)
					{
						return _callSpecification != null;
					}
					return true;
				}
			}

			private PendingSpecInfoData(ICallSpecification? callSpecification, ICall? lastCall)
			{
				_callSpecification = callSpecification;
				_lastCall = lastCall;
			}

			public PendingSpecificationInfo? ToPendingSpecificationInfo()
			{
				if (_callSpecification != null)
				{
					return PendingSpecificationInfo.FromCallSpecification(_callSpecification);
				}
				if (_lastCall != null)
				{
					return PendingSpecificationInfo.FromLastCall(_lastCall);
				}
				return null;
			}

			public static PendingSpecInfoData FromLastCall(ICall lastCall)
			{
				return new PendingSpecInfoData(null, lastCall);
			}

			public static PendingSpecInfoData FromCallSpecification(ICallSpecification callSpecification)
			{
				return new PendingSpecInfoData(callSpecification, null);
			}
		}

		private static readonly IArgumentSpecification[] EmptySpecifications = new IArgumentSpecification[0];

		private readonly RobustThreadLocal<ICallRouter?> _lastCallRouter;

		private readonly RobustThreadLocal<IList<IArgumentSpecification>> _argumentSpecifications;

		private readonly RobustThreadLocal<Func<ICall, object?[]>?> _getArgumentsForRaisingEvent;

		private readonly RobustThreadLocal<IQuery?> _currentQuery;

		private readonly RobustThreadLocal<PendingSpecInfoData> _pendingSpecificationInfo;

		private readonly RobustThreadLocal<Tuple<ICallRouter, Func<ISubstituteState, IRoute>>?> _nextRouteFactory;

		public IPendingSpecification PendingSpecification { get; }

		public bool IsQuerying => _currentQuery.Value != null;

		public ThreadLocalContext()
		{
			_lastCallRouter = new RobustThreadLocal<ICallRouter>();
			_argumentSpecifications = new RobustThreadLocal<IList<IArgumentSpecification>>(() => new List<IArgumentSpecification>());
			_getArgumentsForRaisingEvent = new RobustThreadLocal<Func<ICall, object[]>>();
			_currentQuery = new RobustThreadLocal<IQuery>();
			_pendingSpecificationInfo = new RobustThreadLocal<PendingSpecInfoData>();
			_nextRouteFactory = new RobustThreadLocal<Tuple<ICallRouter, Func<ISubstituteState, IRoute>>>();
			PendingSpecification = new PendingSpecificationWrapper(_pendingSpecificationInfo);
		}

		public void SetLastCallRouter(ICallRouter callRouter)
		{
			_lastCallRouter.Value = callRouter;
		}

		public ConfiguredCall LastCallShouldReturn(IReturn value, MatchArgs matchArgs)
		{
			ICallRouter? obj = _lastCallRouter.Value ?? throw new CouldNotSetReturnDueToNoLastCallException();
			if (!PendingSpecification.HasPendingCallSpecInfo())
			{
				throw new CouldNotSetReturnDueToMissingInfoAboutLastCallException();
			}
			if (_argumentSpecifications.Value.Count > 0)
			{
				_argumentSpecifications.Value.Clear();
				throw new UnexpectedArgumentMatcherException();
			}
			PendingSpecificationInfo pendingSpecInfo = PendingSpecification.UseCallSpecInfo();
			ConfiguredCall result = obj.LastCallShouldReturn(value, matchArgs, pendingSpecInfo);
			ClearLastCallRouter();
			return result;
		}

		public void SetNextRoute(ICallRouter callRouter, Func<ISubstituteState, IRoute> nextRouteFactory)
		{
			_nextRouteFactory.Value = Tuple.Create(callRouter, nextRouteFactory);
		}

		public Func<ISubstituteState, IRoute>? UseNextRoute(ICallRouter callRouter)
		{
			Tuple<ICallRouter, Func<ISubstituteState, IRoute>> value = _nextRouteFactory.Value;
			if (value != null && callRouter == value.Item1)
			{
				_nextRouteFactory.Value = null;
				return value.Item2;
			}
			return null;
		}

		public void ClearLastCallRouter()
		{
			_lastCallRouter.Value = null;
		}

		public void EnqueueArgumentSpecification(IArgumentSpecification spec)
		{
			(_argumentSpecifications.Value ?? throw new SubstituteInternalException("Argument specification queue is null.")).Add(spec);
		}

		public IList<IArgumentSpecification> DequeueAllArgumentSpecifications()
		{
			IList<IArgumentSpecification> list = _argumentSpecifications.Value;
			if (list == null)
			{
				throw new SubstituteInternalException("Argument specification queue is null.");
			}
			if (list.Count == 0)
			{
				list = EmptySpecifications;
			}
			else
			{
				_argumentSpecifications.Value = new List<IArgumentSpecification>();
			}
			return list;
		}

		public void SetPendingRaisingEventArgumentsFactory(Func<ICall, object?[]> getArguments)
		{
			_getArgumentsForRaisingEvent.Value = getArguments;
		}

		public Func<ICall, object?[]>? UsePendingRaisingEventArgumentsFactory()
		{
			Func<ICall, object?[]>? value = _getArgumentsForRaisingEvent.Value;
			if (value != null)
			{
				_getArgumentsForRaisingEvent.Value = null;
			}
			return value;
		}

		public void RunInQueryContext(Action calls, IQuery query)
		{
			_currentQuery.Value = query;
			try
			{
				calls();
			}
			finally
			{
				_currentQuery.Value = null;
			}
		}

		public void RegisterInContextQuery(ICall call)
		{
			(_currentQuery.Value ?? throw new NotRunningAQueryException()).RegisterCall(call);
		}
	}
}
