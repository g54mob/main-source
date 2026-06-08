using System;
using System.Runtime.Serialization;

namespace Castle.DynamicProxy
{
	[Serializable]
	public class InvalidMixinConfigurationException : Exception
	{
		public InvalidMixinConfigurationException(string message)
			: base(message)
		{
		}

		public InvalidMixinConfigurationException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected InvalidMixinConfigurationException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
