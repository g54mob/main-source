using System;
using System.Runtime.Serialization;

namespace Castle.DynamicProxy
{
	[Serializable]
	public sealed class DynamicProxyException : Exception
	{
		internal DynamicProxyException(string message)
			: base(message)
		{
		}

		internal DynamicProxyException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		internal DynamicProxyException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
