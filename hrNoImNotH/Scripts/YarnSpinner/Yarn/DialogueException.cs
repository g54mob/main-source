using System;
using System.Runtime.Serialization;

namespace Yarn
{
	[Serializable]
	public class DialogueException : Exception
	{
		internal DialogueException()
		{
		}

		internal DialogueException(string message)
		{
		}

		internal DialogueException(string message, Exception inner)
		{
		}

		protected DialogueException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
