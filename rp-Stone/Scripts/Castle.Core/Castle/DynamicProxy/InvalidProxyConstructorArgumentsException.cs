using System;

namespace Castle.DynamicProxy
{
	[Serializable]
	public class InvalidProxyConstructorArgumentsException : ArgumentException
	{
		public Type ClassToProxy { get; private set; }

		public Type ProxyType { get; private set; }

		public InvalidProxyConstructorArgumentsException(string message, Type proxyType, Type classToProxy)
			: base(message)
		{
			ProxyType = proxyType;
			ClassToProxy = classToProxy;
		}
	}
}
