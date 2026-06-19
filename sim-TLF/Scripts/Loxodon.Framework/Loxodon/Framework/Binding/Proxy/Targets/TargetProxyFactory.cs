using System;
using System.Collections.Generic;
using Loxodon.Log;

namespace Loxodon.Framework.Binding.Proxy.Targets
{
	public class TargetProxyFactory : ITargetProxyFactory, ITargetProxyFactoryRegister
	{
		private struct PriorityFactoryPair
		{
			public int priority;

			public ITargetProxyFactory factory;

			public PriorityFactoryPair(ITargetProxyFactory factory, int priority)
			{
				this.factory = factory;
				this.priority = priority;
			}
		}

		private static readonly ILog log = LogManager.GetLogger(typeof(TargetProxyFactory));

		private List<PriorityFactoryPair> factories = new List<PriorityFactoryPair>();

		public ITargetProxy CreateProxy(object target, BindingDescription description)
		{
			try
			{
				ITargetProxy proxy = null;
				if (TryCreateProxy(target, description, out proxy))
				{
					return proxy;
				}
				throw new NotSupportedException("Not found available proxy factory.");
			}
			catch (Exception exception)
			{
				throw new ProxyException(exception, "Unable to bind the \"{0}\".An exception occurred while creating a proxy for the \"{1}\" property of class \"{2}\".", description.ToString(), description.TargetName, target.GetType().Name);
			}
		}

		protected virtual bool TryCreateProxy(object target, BindingDescription description, out ITargetProxy proxy)
		{
			proxy = null;
			foreach (PriorityFactoryPair factory2 in factories)
			{
				ITargetProxyFactory factory = factory2.factory;
				if (factory == null)
				{
					continue;
				}
				try
				{
					proxy = factory.CreateProxy(target, description);
					if (proxy != null)
					{
						return true;
					}
				}
				catch (MissingMemberException ex)
				{
					if (!TargetNameUtil.IsCollection(description.TargetName))
					{
						throw ex;
					}
				}
				catch (NullReferenceException ex2)
				{
					throw ex2;
				}
				catch (Exception ex3)
				{
					if (log.IsWarnEnabled)
					{
						log.WarnFormat("An exception occurred when using the \"{0}\" factory to create a proxy for the \"{1}\" property of class \"{2}\";exception:{3}", factory.GetType().Name, description.TargetName, target.GetType().Name, ex3);
					}
				}
			}
			return false;
		}

		public void Register(ITargetProxyFactory factory, int priority = 100)
		{
			if (factory != null)
			{
				factories.Add(new PriorityFactoryPair(factory, priority));
				factories.Sort((PriorityFactoryPair x, PriorityFactoryPair y) => y.priority.CompareTo(x.priority));
			}
		}

		public void Unregister(ITargetProxyFactory factory)
		{
			if (factory != null)
			{
				factories.RemoveAll((PriorityFactoryPair pair) => pair.factory == factory);
			}
		}
	}
}
