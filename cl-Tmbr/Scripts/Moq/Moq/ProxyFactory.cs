using System;
using System.Reflection;

namespace Moq
{
	internal abstract class ProxyFactory
	{
		public static ProxyFactory Instance { get; } = new CastleProxyFactory();

		public abstract object CreateProxy(Type mockType, IInterceptor interceptor, Type[] interfaces, object[] arguments);

		public abstract bool IsMethodVisible(MethodInfo method, out string messageIfNotVisible);

		public abstract bool IsTypeVisible(Type type);
	}
}
