using System;

namespace MoonSharp.Interpreter.Interop
{
	public sealed class ProxyUserDataDescriptor : IUserDataDescriptor
	{
		private IUserDataDescriptor m_ProxyDescriptor;

		private IProxyFactory m_ProxyFactory;

		public IUserDataDescriptor InnerDescriptor => null;

		public string Name { get; private set; }

		public Type Type => null;

		internal ProxyUserDataDescriptor(IProxyFactory proxyFactory, IUserDataDescriptor proxyDescriptor, string friendlyName = null)
		{
		}

		private object Proxy(object obj)
		{
			return null;
		}

		public DynValue Index(Script script, object obj, DynValue index, bool isDirectIndexing)
		{
			return null;
		}

		public bool SetIndex(Script script, object obj, DynValue index, DynValue value, bool isDirectIndexing)
		{
			return false;
		}

		public string AsString(object obj)
		{
			return null;
		}

		public DynValue MetaIndex(Script script, object obj, string metaname)
		{
			return null;
		}

		public bool IsTypeCompatible(Type type, object obj)
		{
			return false;
		}
	}
}
