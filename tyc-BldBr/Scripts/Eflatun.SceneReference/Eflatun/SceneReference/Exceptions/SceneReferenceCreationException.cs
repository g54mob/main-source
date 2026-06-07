using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace Eflatun.SceneReference.Exceptions
{
	[Serializable]
	[PublicAPI]
	public class SceneReferenceCreationException : SceneReferenceException
	{
		private static string PrefixMessage(string message)
		{
			return "An exception occured during the creation of a SceneReference: " + message;
		}

		internal SceneReferenceCreationException(string message)
			: base(PrefixMessage(message))
		{
		}

		internal SceneReferenceCreationException(string message, Exception inner)
			: base(PrefixMessage(message), inner)
		{
		}

		private protected SceneReferenceCreationException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
