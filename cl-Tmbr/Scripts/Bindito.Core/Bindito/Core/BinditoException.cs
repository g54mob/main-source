using System;
using System.Runtime.Serialization;

namespace Bindito.Core
{
	public class BinditoException : Exception
	{
		public BinditoException()
		{
		}

		protected BinditoException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		public BinditoException(string message)
			: base(message)
		{
		}

		public BinditoException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
