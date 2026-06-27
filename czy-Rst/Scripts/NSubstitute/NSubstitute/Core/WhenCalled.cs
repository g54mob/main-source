using System;
using NSubstitute.Routing;

namespace NSubstitute.Core
{
	public class WhenCalled<T>
	{
		private readonly ICallRouter _callRouter;

		private readonly IThreadLocalContext _threadContext;

		private readonly IRouteFactory _routeFactory;

		public WhenCalled(ISubstitutionContext context, T substitute, Action<T> call, MatchArgs matchArgs)
		{
			_003Csubstitute_003EP = substitute;
			_003Ccall_003EP = call;
			_003CmatchArgs_003EP = matchArgs;
			_callRouter = context.GetCallRouterFor(_003Csubstitute_003EP);
			_threadContext = context.ThreadContext;
			_routeFactory = context.RouteFactory;
			base._002Ector();
		}

		public void Do(Action<CallInfo> callbackWithArguments)
		{
			_threadContext.SetNextRoute(_callRouter, (ISubstituteState x) => _routeFactory.DoWhenCalled(x, callbackWithArguments, _003CmatchArgs_003EP));
			_003Ccall_003EP(_003Csubstitute_003EP);
		}

		public void Do(Callback callback)
		{
			_threadContext.SetNextRoute(_callRouter, (ISubstituteState x) => _routeFactory.DoWhenCalled(x, callback.Call, _003CmatchArgs_003EP));
			_003Ccall_003EP(_003Csubstitute_003EP);
		}

		public void DoNotCallBase()
		{
			_threadContext.SetNextRoute(_callRouter, (ISubstituteState x) => _routeFactory.DoNotCallBase(x, _003CmatchArgs_003EP));
			_003Ccall_003EP(_003Csubstitute_003EP);
		}

		public void CallBase()
		{
			_threadContext.SetNextRoute(_callRouter, (ISubstituteState x) => _routeFactory.CallBase(x, _003CmatchArgs_003EP));
			_003Ccall_003EP(_003Csubstitute_003EP);
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

		public void Throws(Exception exception)
		{
			Throw(exception);
		}

		public TException Throws<TException>() where TException : Exception, new()
		{
			return Throw<TException>();
		}

		public void Throws(Func<CallInfo, Exception> createException)
		{
			Throw(createException);
		}
	}
}
