using System;
using System.Runtime.Serialization;

namespace Jundroo.Common.Expressions.Exceptions
{
	[Serializable]
	public class ExpressionParseException : Exception
	{
		public ExpressionParseException()
		{
		}

		public ExpressionParseException(string message)
			: base(message)
		{
		}

		public ExpressionParseException(string message, Exception inner)
			: base(message, inner)
		{
		}

		protected ExpressionParseException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
