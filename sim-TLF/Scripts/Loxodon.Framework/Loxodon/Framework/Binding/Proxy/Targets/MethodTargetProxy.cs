using System;
using System.Threading;
using Loxodon.Framework.Binding.Reflection;
using Loxodon.Framework.Interactivity;
using Loxodon.Log;
using UnityEngine;

namespace Loxodon.Framework.Binding.Proxy.Targets
{
	public class MethodTargetProxy : TargetProxyBase, IObtainable, IProxyInvoker, IInvoker
	{
		protected static readonly ILog log = LogManager.GetLogger(typeof(MethodTargetProxy));

		protected static readonly Exception INVALID_OPERATION_EXCEPTION = new InvalidOperationException("The window or view has been disabled, so the operation is invalid.");

		protected readonly IProxyMethodInfo methodInfo;

		protected SendOrPostCallback postCallback;

		public override BindingMode DefaultMode => BindingMode.OneWayToSource;

		public override Type Type => typeof(IProxyInvoker);

		public IProxyMethodInfo ProxyMethodInfo => methodInfo;

		public MethodTargetProxy(object target, IProxyMethodInfo methodInfo)
			: base(target)
		{
			this.methodInfo = methodInfo;
			if (!methodInfo.ReturnType.Equals(typeof(void)))
			{
				throw new ArgumentException("methodInfo");
			}
		}

		public object GetValue()
		{
			return this;
		}

		public TValue GetValue<TValue>()
		{
			return (TValue)GetValue();
		}

		public object Invoke(params object[] args)
		{
			if (UISynchronizationContext.InThread)
			{
				object obj = (methodInfo.IsStatic ? null : Target);
				if (!Check(obj, args))
				{
					return null;
				}
				return methodInfo.Invoke(obj, args);
			}
			if (postCallback == null)
			{
				postCallback = delegate(object state)
				{
					object[] args2 = (object[])state;
					object obj2 = (methodInfo.IsStatic ? null : Target);
					if (Check(obj2, args2))
					{
						methodInfo.Invoke(obj2, args2);
					}
				};
			}
			UISynchronizationContext.Post(postCallback, args);
			return null;
		}

		private bool Check(object target, object[] args)
		{
			if (!methodInfo.IsStatic && (target == null || target is Behaviour { isActiveAndEnabled: false }))
			{
				if (log.IsErrorEnabled)
				{
					log.Error("The window or view has been disabled, so the operation is invalid.", INVALID_OPERATION_EXCEPTION);
				}
				if (args != null && args.Length == 2 && args[0] != null && args[1] is InteractionEventArgs e)
				{
					if (e is AsyncInteractionEventArgs e2)
					{
						e2.Source.SetException(INVALID_OPERATION_EXCEPTION);
					}
					else
					{
						e.Callback?.Invoke();
					}
				}
				return false;
			}
			return true;
		}
	}
}
