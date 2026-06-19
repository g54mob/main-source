using System.Collections.Generic;
using Loxodon.Framework.Binding.Paths;
using Loxodon.Framework.Binding.Proxy.Sources.Text;

namespace Loxodon.Framework.Binding.Proxy.Sources.Object
{
	public class ObjectSourceProxyFactory : TypedSourceProxyFactory<ObjectSourceDescription>, INodeProxyFactory, INodeProxyFactoryRegister
	{
		private struct PriorityFactoryPair
		{
			public int priority;

			public INodeProxyFactory factory;

			public PriorityFactoryPair(INodeProxyFactory factory, int priority)
			{
				this.factory = factory;
				this.priority = priority;
			}
		}

		private List<PriorityFactoryPair> factories = new List<PriorityFactoryPair>();

		protected override bool TryCreateProxy(object source, ObjectSourceDescription description, out ISourceProxy proxy)
		{
			proxy = null;
			Path path = description.Path;
			if (path.Count <= 0)
			{
				proxy = new LiteralSourceProxy(source);
				return true;
			}
			if (path.Count == 1)
			{
				proxy = Create(source, path.AsPathToken());
				if (proxy != null)
				{
					return true;
				}
				return false;
			}
			proxy = new ChainedObjectSourceProxy(source, path.AsPathToken(), this);
			return true;
		}

		public virtual ISourceProxy Create(object source, PathToken token)
		{
			ISourceProxy sourceProxy = null;
			foreach (PriorityFactoryPair factory2 in factories)
			{
				INodeProxyFactory factory = factory2.factory;
				if (factory != null)
				{
					sourceProxy = factory.Create(source, token);
					if (sourceProxy != null)
					{
						return sourceProxy;
					}
				}
			}
			return sourceProxy;
		}

		public virtual void Register(INodeProxyFactory factory, int priority = 100)
		{
			if (factory != null)
			{
				factories.Add(new PriorityFactoryPair(factory, priority));
				factories.Sort((PriorityFactoryPair x, PriorityFactoryPair y) => y.priority.CompareTo(x.priority));
			}
		}

		public virtual void Unregister(INodeProxyFactory factory)
		{
			if (factory != null)
			{
				factories.RemoveAll((PriorityFactoryPair pair) => pair.factory == factory);
			}
		}
	}
}
