using System;

namespace MoonSharp.Interpreter.Interop
{
	public class DelegateProxyFactory<TProxy, TTarget> : IProxyFactory<TProxy, TTarget>, IProxyFactory where TProxy : class where TTarget : class
	{
		private Func<TTarget, TProxy> wrapDelegate;

		public Type TargetType => null;

		public Type ProxyType => null;

		public DelegateProxyFactory(Func<TTarget, TProxy> wrapDelegate)
		{
		}

		public TProxy CreateProxyObject(TTarget target)
		{
			return null;
		}

		public object CreateProxyObject(object o)
		{
			return null;
		}
	}
}
