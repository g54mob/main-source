using Castle.DynamicProxy;
using NSubstitute.Core;

namespace NSubstitute.Proxies.CastleDynamicProxy
{
	public class CastleForwardingInterceptor : IInterceptor
	{
		private readonly CastleInvocationMapper _invocationMapper;

		private readonly ICallRouter _callRouter;

		private bool _fullDispatchMode;

		public CastleForwardingInterceptor(CastleInvocationMapper invocationMapper, ICallRouter callRouter)
		{
			_invocationMapper = invocationMapper;
			_callRouter = callRouter;
		}

		public void Intercept(IInvocation invocation)
		{
			ICall call = _invocationMapper.Map(invocation);
			if (_fullDispatchMode)
			{
				invocation.ReturnValue = _callRouter.Route(call);
			}
			else if (_callRouter.CallBaseByDefault)
			{
				invocation.ReturnValue = call.TryCallBase().ValueOrDefault();
			}
		}

		public void SwitchToFullDispatchMode()
		{
			_fullDispatchMode = true;
		}
	}
}
