using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace Eflatun.SceneReference.Exceptions
{
	[Serializable]
	[PublicAPI]
	public class SceneReferenceException : Exception
	{
		internal SceneReferenceException()
		{
		}

		internal SceneReferenceException(string message)
			: base("[Eflatun.SceneReference] " + message)
		{
		}

		internal SceneReferenceException(string message, Exception inner)
			: base("[Eflatun.SceneReference] " + message, inner)
		{
		}

		private protected SceneReferenceException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
