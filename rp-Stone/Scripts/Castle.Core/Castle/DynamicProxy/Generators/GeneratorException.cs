using System;
using System.Runtime.Serialization;

namespace Castle.DynamicProxy.Generators
{
	[Serializable]
	public class GeneratorException : Exception
	{
		public GeneratorException(string message)
			: base(message)
		{
		}

		public GeneratorException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public GeneratorException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
