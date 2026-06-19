using System;
using System.Collections.Generic;
using System.Reflection;
using Loxodon.Framework.Binding.Reflection;
using Loxodon.Framework.Commands;
using Loxodon.Log;
using UnityEngine.Events;

namespace Loxodon.Framework.Binding.Proxy.Targets
{
	public class UnityEventProxy : UnityEventProxyBase<UnityEvent>
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(UnityEventProxy));

		public override Type Type => typeof(UnityEvent);

		public UnityEventProxy(object target, UnityEvent unityEvent)
			: base(target, unityEvent)
		{
		}

		protected override void BindEvent()
		{
			unityEvent.AddListener(OnEvent);
		}

		protected override void UnbindEvent()
		{
			unityEvent.RemoveListener(OnEvent);
		}

		protected override bool IsValid(Delegate handler)
		{
			if (handler is UnityAction || handler is Action)
			{
				return true;
			}
			MethodInfo method = handler.Method;
			if (!method.ReturnType.Equals(typeof(void)))
			{
				return false;
			}
			if (method.GetParameterTypes().Count != 0)
			{
				return false;
			}
			return true;
		}

		protected override bool IsValid(IProxyInvoker invoker)
		{
			IProxyMethodInfo proxyMethodInfo = invoker.ProxyMethodInfo;
			if (!proxyMethodInfo.ReturnType.Equals(typeof(void)))
			{
				return false;
			}
			ParameterInfo[] parameters = proxyMethodInfo.Parameters;
			if (parameters != null && parameters.Length != 0)
			{
				return false;
			}
			return true;
		}

		protected virtual void OnEvent()
		{
			try
			{
				if (command != null)
				{
					command.Execute(null);
				}
				else if (invoker != null)
				{
					invoker.Invoke();
				}
				else if ((object)handler != null)
				{
					if (handler is Action action)
					{
						action();
					}
					else if (handler is UnityAction unityAction)
					{
						unityAction();
					}
					else
					{
						handler.DynamicInvoke();
					}
				}
			}
			catch (Exception ex)
			{
				if (log.IsErrorEnabled)
				{
					log.ErrorFormat("{0}", ex);
				}
			}
		}
	}
	public class UnityEventProxy<T> : UnityEventProxyBase<UnityEvent<T>>
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(UnityEventProxy<T>));

		public override Type Type => typeof(UnityEvent<T>);

		public UnityEventProxy(object target, UnityEvent<T> unityEvent)
			: base(target, unityEvent)
		{
		}

		protected override void BindEvent()
		{
			unityEvent.AddListener(OnEvent);
		}

		protected override void UnbindEvent()
		{
			unityEvent.RemoveListener(OnEvent);
		}

		protected override bool IsValid(Delegate handler)
		{
			if (handler is UnityAction<T> || handler is Action<T>)
			{
				return true;
			}
			MethodInfo method = handler.Method;
			if (!method.ReturnType.Equals(typeof(void)))
			{
				return false;
			}
			List<Type> parameterTypes = method.GetParameterTypes();
			if (parameterTypes.Count != 1)
			{
				return false;
			}
			return parameterTypes[0].IsAssignableFrom(typeof(T));
		}

		protected override bool IsValid(IProxyInvoker invoker)
		{
			IProxyMethodInfo proxyMethodInfo = invoker.ProxyMethodInfo;
			if (!proxyMethodInfo.ReturnType.Equals(typeof(void)))
			{
				return false;
			}
			ParameterInfo[] parameters = proxyMethodInfo.Parameters;
			if (parameters == null || parameters.Length != 1)
			{
				return false;
			}
			return parameters[0].ParameterType.IsAssignableFrom(typeof(T));
		}

		protected virtual void OnEvent(T parameter)
		{
			try
			{
				if (base.command != null)
				{
					if (base.command is ICommand<T> command)
					{
						command.Execute(parameter);
					}
					else
					{
						base.command.Execute(parameter);
					}
				}
				else if (base.invoker != null)
				{
					if (base.invoker is IInvoker<T> invoker)
					{
						invoker.Invoke(parameter);
						return;
					}
					base.invoker.Invoke(parameter);
				}
				else if ((object)handler != null)
				{
					if (handler is Action<T> action)
					{
						action(parameter);
						return;
					}
					if (handler is UnityAction<T> unityAction)
					{
						unityAction(parameter);
						return;
					}
					handler.DynamicInvoke(parameter);
				}
			}
			catch (Exception ex)
			{
				if (log.IsErrorEnabled)
				{
					log.ErrorFormat("{0}", ex);
				}
			}
		}
	}
	public class UnityEventProxy<T0, T1> : UnityEventProxyBase<UnityEvent<T0, T1>>
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(UnityEventProxy<T0, T1>));

		public override Type Type => typeof(UnityEvent<T0, T1>);

		public UnityEventProxy(object target, UnityEvent<T0, T1> unityEvent)
			: base(target, unityEvent)
		{
		}

		protected override void BindEvent()
		{
			unityEvent.AddListener(OnEvent);
		}

		protected override void UnbindEvent()
		{
			unityEvent.RemoveListener(OnEvent);
		}

		protected override bool IsValid(Delegate handler)
		{
			if (handler is UnityAction<T0, T1> || handler is Action<T0, T1>)
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
			if (parameterTypes[0].IsAssignableFrom(typeof(T0)))
			{
				return parameterTypes[1].IsAssignableFrom(typeof(T1));
			}
			return false;
		}

		protected override bool IsValid(IProxyInvoker invoker)
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
			if (parameters[0].ParameterType.IsAssignableFrom(typeof(T0)))
			{
				return parameters[1].ParameterType.IsAssignableFrom(typeof(T1));
			}
			return false;
		}

		protected virtual void OnEvent(T0 t0, T1 t1)
		{
			try
			{
				if (command != null)
				{
					command.Execute(new object[2] { t0, t1 });
				}
				else if (base.invoker != null)
				{
					if (base.invoker is IInvoker<T0, T1> invoker)
					{
						invoker.Invoke(t0, t1);
						return;
					}
					base.invoker.Invoke(t0, t1);
				}
				else if ((object)handler != null)
				{
					if (handler is Action<T0, T1> action)
					{
						action(t0, t1);
						return;
					}
					if (handler is UnityAction<T0, T1> unityAction)
					{
						unityAction(t0, t1);
						return;
					}
					handler.DynamicInvoke(t0, t1);
				}
			}
			catch (Exception ex)
			{
				if (log.IsErrorEnabled)
				{
					log.ErrorFormat("{0}", ex);
				}
			}
		}
	}
	public class UnityEventProxy<T0, T1, T2> : UnityEventProxyBase<UnityEvent<T0, T1, T2>>
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(UnityEventProxy<T0, T1, T2>));

		public override Type Type => typeof(UnityEvent<T0, T1, T2>);

		public UnityEventProxy(object target, UnityEvent<T0, T1, T2> unityEvent)
			: base(target, unityEvent)
		{
		}

		protected override void BindEvent()
		{
			unityEvent.AddListener(OnEvent);
		}

		protected override void UnbindEvent()
		{
			unityEvent.RemoveListener(OnEvent);
		}

		protected override bool IsValid(Delegate handler)
		{
			if (handler is UnityAction<T0, T1, T2> || handler is Action<T0, T1, T2>)
			{
				return true;
			}
			MethodInfo method = handler.Method;
			if (!method.ReturnType.Equals(typeof(void)))
			{
				return false;
			}
			List<Type> parameterTypes = method.GetParameterTypes();
			if (parameterTypes.Count != 3)
			{
				return false;
			}
			if (parameterTypes[0].IsAssignableFrom(typeof(T0)) && parameterTypes[1].IsAssignableFrom(typeof(T1)))
			{
				return parameterTypes[2].IsAssignableFrom(typeof(T2));
			}
			return false;
		}

		protected override bool IsValid(IProxyInvoker invoker)
		{
			IProxyMethodInfo proxyMethodInfo = invoker.ProxyMethodInfo;
			if (!proxyMethodInfo.ReturnType.Equals(typeof(void)))
			{
				return false;
			}
			ParameterInfo[] parameters = proxyMethodInfo.Parameters;
			if (parameters == null || parameters.Length != 3)
			{
				return false;
			}
			if (parameters[0].ParameterType.IsAssignableFrom(typeof(T0)) && parameters[1].ParameterType.IsAssignableFrom(typeof(T1)))
			{
				return parameters[2].ParameterType.IsAssignableFrom(typeof(T2));
			}
			return false;
		}

		protected virtual void OnEvent(T0 t0, T1 t1, T2 t2)
		{
			try
			{
				if (command != null)
				{
					command.Execute(new object[3] { t0, t1, t2 });
				}
				else if (base.invoker != null)
				{
					if (base.invoker is IInvoker<T0, T1, T2> invoker)
					{
						invoker.Invoke(t0, t1, t2);
						return;
					}
					base.invoker.Invoke(t0, t1, t2);
				}
				else if ((object)handler != null)
				{
					if (handler is Action<T0, T1, T2> action)
					{
						action(t0, t1, t2);
						return;
					}
					if (handler is UnityAction<T0, T1, T2> unityAction)
					{
						unityAction(t0, t1, t2);
						return;
					}
					handler.DynamicInvoke(t0, t1, t2);
				}
			}
			catch (Exception ex)
			{
				if (log.IsErrorEnabled)
				{
					log.ErrorFormat("{0}", ex);
				}
			}
		}
	}
	public class UnityEventProxy<T0, T1, T2, T3> : UnityEventProxyBase<UnityEvent<T0, T1, T2, T3>>
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(UnityEventProxy<T0, T1, T2, T3>));

		public override Type Type => typeof(UnityEvent<T0, T1, T2, T3>);

		public UnityEventProxy(object target, UnityEvent<T0, T1, T2, T3> unityEvent)
			: base(target, unityEvent)
		{
		}

		protected override void BindEvent()
		{
			unityEvent.AddListener(OnEvent);
		}

		protected override void UnbindEvent()
		{
			unityEvent.RemoveListener(OnEvent);
		}

		protected override bool IsValid(Delegate handler)
		{
			if (handler is UnityAction<T0, T1, T2, T3> || handler is Action<T0, T1, T2, T3>)
			{
				return true;
			}
			MethodInfo method = handler.Method;
			if (!method.ReturnType.Equals(typeof(void)))
			{
				return false;
			}
			List<Type> parameterTypes = method.GetParameterTypes();
			if (parameterTypes.Count != 4)
			{
				return false;
			}
			if (parameterTypes[0].IsAssignableFrom(typeof(T0)) && parameterTypes[1].IsAssignableFrom(typeof(T1)) && parameterTypes[2].IsAssignableFrom(typeof(T2)))
			{
				return parameterTypes[3].IsAssignableFrom(typeof(T3));
			}
			return false;
		}

		protected override bool IsValid(IProxyInvoker invoker)
		{
			IProxyMethodInfo proxyMethodInfo = invoker.ProxyMethodInfo;
			if (!proxyMethodInfo.ReturnType.Equals(typeof(void)))
			{
				return false;
			}
			ParameterInfo[] parameters = proxyMethodInfo.Parameters;
			if (parameters == null || parameters.Length != 4)
			{
				return false;
			}
			if (parameters[0].ParameterType.IsAssignableFrom(typeof(T0)) && parameters[1].ParameterType.IsAssignableFrom(typeof(T1)) && parameters[2].ParameterType.IsAssignableFrom(typeof(T2)))
			{
				return parameters[3].ParameterType.IsAssignableFrom(typeof(T3));
			}
			return false;
		}

		protected virtual void OnEvent(T0 t0, T1 t1, T2 t2, T3 t3)
		{
			try
			{
				if (command != null)
				{
					command.Execute(new object[4] { t0, t1, t2, t3 });
				}
				else if (base.invoker != null)
				{
					if (base.invoker is IInvoker<T0, T1, T2, T3> invoker)
					{
						invoker.Invoke(t0, t1, t2, t3);
						return;
					}
					base.invoker.Invoke(t0, t1, t2, t3);
				}
				else if ((object)handler != null)
				{
					if (handler is UnityAction<T0, T1, T2, T3> unityAction)
					{
						unityAction(t0, t1, t2, t3);
						return;
					}
					if (handler is UnityAction<T0, T1, T2, T3> unityAction2)
					{
						unityAction2(t0, t1, t2, t3);
						return;
					}
					handler.DynamicInvoke(t0, t1, t2, t3);
				}
			}
			catch (Exception ex)
			{
				if (log.IsErrorEnabled)
				{
					log.ErrorFormat("{0}", ex);
				}
			}
		}
	}
}
