using System;
using System.Runtime.Serialization;

namespace Borodar.FarlandSkies.Core.Json
{
	[Serializable]
	public class JsonParserException : JsonException
	{
		private string message;

		public override string Message => null;

		public int LineNumber { get; private set; }

		public int LinePosition { get; private set; }

		public JsonParserException(string message, int lineNumber, int linePosition)
		{
		}

		protected JsonParserException(SerializationInfo info, StreamingContext context)
		{
		}

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
