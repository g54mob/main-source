using System;
using System.Collections.Generic;
using System.Reflection;
using Loxodon.Framework.Binding.Reflection;
using Loxodon.Framework.Interactivity;
using Loxodon.Log;

namespace Loxodon.Framework.Binding.Proxy.Sources.Object
{
	public class InteractionNodeProxy : SourceProxyBase, IModifiable
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(InteractionNodeProxy));

		private readonly IInteractionRequest request;

		private bool disposed;

		protected IInvoker invoker;

		protected Delegate handler;

		public override Type Type => typeof(EventHandler<InteractionEventArgs>);

		public InteractionNodeProxy(IInteractionRequest request)
			: this(null, request)
		{
		}

		public InteractionNodeProxy(object source, IInteractionRequest request)
			: base(source)
		{
			this.request = request;
			BindEvent();
		}

		public virtual void SetValue<TValue>(TValue value)
		{
			SetValue((object)value);
		}

		public virtual void SetValue(object value)
		{
			if (value != null && !(value is IInvoker) && !(value is Delegate))
			{
				throw new ArgumentException("Binding object to InteractionRequest failed, unsupported object type", "value");
			}
			if (this.invoker != null)
			{
				this.invoker = null;
			}
			if ((object)handler != null)
			{
				handler = null;
			}
			if (value == null)
			{
				return;
			}
			if (value is IProxyInvoker proxyInvoker)
			{
				if (IsValid(proxyInvoker))
				{
					this.invoker = proxyInvoker;
					return;
				}
				throw new ArgumentException("Binding the IProxyInvoker to InteractionRequest failed, mismatched parameter type.");
			}
			if (value is IInvoker invoker)
			{
				this.invoker = invoker;
			}
			if (value is Delegate obj)
			{
				if (!IsValid(obj))
				{
					throw new ArgumentException("Binding the Delegate to InteractionRequest failed, mismatched parameter type.");
				}
				handler = obj;
			}
		}

		protected virtual bool IsValid(Delegate handler)
		{
			if (handler is EventHandler<InteractionEventArgs>)
			{
				return true;
			}
			MethodInfo method = handler.Method;
			if (!method.ReturnType.Equals(typeof(void)))
			{
				return false;
			}
			List<Type> parameterTypes = method.GetParameterTypes();
			if (parameterTypes.Count != 2)
			{
				return false;
			}
			if (parameterTypes[0].IsAssignableFrom(typeof(object)))
			{
				return parameterTypes[1].IsAssignableFrom(typeof(InteractionEventArgs));
			}
			return false;
		}

		protected virtual bool IsValid(IProxyInvoker invoker)
		{
			IProxyMethodInfo proxyMethodInfo = invoker.ProxyMethodInfo;
			if (!proxyMethodInfo.ReturnType.Equals(typeof(void)))
			{
				return false;
			}
			ParameterInfo[] parameters = proxyMethodInfo.Parameters;
			if (parameters == null || parameters.Length != 2)
			{
				return false;
			}
			if (parameters[0].ParameterType.IsAssignableFrom(typeof(object)))
			{
				return parameters[1].ParameterType.IsAssignableFrom(typeof(InteractionEventArgs));
			}
			return false;
		}

		protected virtual void BindEvent()
		{
			if (request != null)
			{
				request.Raised += OnRaised;
			}
		}

		protected virtual void UnbindEvent()
		{
			if (request != null)
			{
				request.Raised -= OnRaised;
			}
		}

		protected virtual void OnRaised(object sender, InteractionEventArgs args)
		{
			try
			{
				if (invoker != null)
				{
					invoker.Invoke(sender, args);
				}
				else if ((object)handler != null)
				{
					if (handler is EventHandler<InteractionEventArgs> eventHandler)
					{
						eventHandler(sender, args);
						return;
					}
					handler.DynamicInvoke(sender, args);
				}
			}
			catch (Exception exception)
			{
				if (log.IsErrorEnabled)
				{
					log.Error("", exception);
				}
				if (args is AsyncInteractionEventArgs e)
				{
					e.Source.SetException(exception);
				}
				else
				{
					args.Callback?.Invoke();
				}
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				UnbindEvent();
				handler = null;
				invoker = null;
				disposed = true;
				base.Dispose(disposing);
			}
		}
	}
}
