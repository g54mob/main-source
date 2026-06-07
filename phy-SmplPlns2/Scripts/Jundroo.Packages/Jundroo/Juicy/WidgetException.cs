using System;
using System.Runtime.Serialization;

namespace Jundroo.Juicy
{
	[Serializable]
	public class WidgetException : Exception
	{
		public WidgetException()
		{
		}

		public WidgetException(string message)
			: base(message)
		{
		}

		public WidgetException(string message, Exception inner)
			: base(message, inner)
		{
		}

		protected WidgetException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
