using System;
using NSubstitute.Routing;

namespace NSubstitute.Core
{
	public class WhenCalled<T>
	{
		private readonly T _substitute;

		private readonly Action<T> _call;

		private readonly MatchArgs _matchArgs;

		private readonly ICallRouter _callRouter;

		private readonly IThreadLocalContext _threadContext;

		private readonly IRouteFactory _routeFactory;

		public WhenCalled(ISubstitutionContext context, T substitute, Action<T> call, MatchArgs matchArgs)
		{
			_substitute = substitute;
			_call = call;
			_matchArgs = matchArgs;
			_callRouter = context.GetCallRouterFor(substitute);
			_routeFactory = context.RouteFactory;
			_threadContext = context.ThreadContext;
		}

		public void Do(Action<CallInfo> callbackWithArguments)
		{
			_threadContext.SetNextRoute(_callRouter, (ISubstituteState x) => _routeFactory.DoWhenCalled(x, callbackWithArguments, _matchArgs));
			_call(_substitute);
		}

		public void Do(Callback callback)
		{
			_threadContext.SetNextRoute(_callRouter, (ISubstituteState x) => _routeFactory.DoWhenCalled(x, callback.Call, _matchArgs));
			_call(_substitute);
		}

		public void DoNotCallBase()
		{
			_threadContext.SetNextRoute(_callRouter, (ISubstituteState x) => _routeFactory.DoNotCallBase(x, _matchArgs));
			_call(_substitute);
		}

		public void CallBase()
		{
			_threadContext.SetNextRoute(_callRouter, (ISubstituteState x) => _routeFactory.CallBase(x, _matchArgs));
			_call(_substitute);
		}

		public void Throw(Exception exception)
		{
			Do(delegate
			{
				throw exception;
			});
		}

		public TException Throw<TException>() where TException : Exception, new()
		{
			TException exception = new TException();
			Do(delegate
			{
				throw exception;
			});
			return exception;
		}

		public void Throw(Func<CallInfo, Exception> createException)
		{
			Do(delegate(CallInfo ci)
			{
				throw createException(ci);
			});
		}
	}
}
