using System;
using System.Runtime.Serialization;

namespace Borodar.FarlandSkies.Core.Json
{
	[Serializable]
	public class JsonException : Exception
	{
		public JsonException()
		{
		}

		public JsonException(string message)
		{
		}

		public JsonException(string message, Exception innerException)
		{
		}

		protected JsonException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
