using System;
using System.Runtime.Serialization;

namespace ModApi.Craft.Program
{
	[Serializable]
	public class ProgramException : Exception
	{
		public ProgramException()
		{
		}

		public ProgramException(string message)
			: base(message)
		{
		}

		public ProgramException(string message, Exception inner)
			: base(message, inner)
		{
		}

		protected ProgramException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
