using Castle.DynamicProxy;
using NSubstitute.Core;

namespace NSubstitute.Proxies.CastleDynamicProxy
{
	public class CastleForwardingInterceptor : IInterceptor
	{
		private bool _fullDispatchMode;

		public CastleForwardingInterceptor(CastleInvocationMapper invocationMapper, ICallRouter callRouter)
		{
			_003CinvocationMapper_003EP = invocationMapper;
			_003CcallRouter_003EP = callRouter;
			base._002Ector();
		}

		public void Intercept(IInvocation invocation)
		{
			ICall call = _003CinvocationMapper_003EP.Map(invocation);
			if (_fullDispatchMode)
			{
				invocation.ReturnValue = _003CcallRouter_003EP.Route(call);
			}
			else if (_003CcallRouter_003EP.CallBaseByDefault)
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
