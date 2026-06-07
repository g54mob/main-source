using System;
using System.Runtime.Serialization;

namespace ModApi.Expressions.Exceptions
{
	[Serializable]
	public class ExpressionCompileException : Exception
	{
		public ExpressionCompileException()
		{
		}

		public ExpressionCompileException(string message)
			: base(message)
		{
		}

		public ExpressionCompileException(string message, Exception inner)
			: base(message, inner)
		{
		}

		protected ExpressionCompileException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
