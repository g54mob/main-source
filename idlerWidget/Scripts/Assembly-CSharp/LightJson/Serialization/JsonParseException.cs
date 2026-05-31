using System;

namespace LightJson.Serialization
{
	public sealed class JsonParseException : Exception
	{
		public enum ErrorType
		{
			Unknown = 0,
			IncompleteMessage = 1,
			DuplicateObjectKeys = 2,
			InvalidOrUnexpectedCharacter = 3
		}

		public TextPosition Position { get; private set; }

		public ErrorType Type { get; private set; }

		public JsonParseException()
			: base(GetDefaultMessage(ErrorType.Unknown))
		{
		}

		public JsonParseException(ErrorType type, TextPosition position)
			: this(GetDefaultMessage(type), type, position)
		{
		}

		public JsonParseException(string message, ErrorType type, TextPosition position)
			: base(message)
		{
			Type = type;
			Position = position;
		}

		private static string GetDefaultMessage(ErrorType type)
		{
			return type switch
			{
				ErrorType.IncompleteMessage => "The string ended before a value could be parsed.", 
				ErrorType.InvalidOrUnexpectedCharacter => "The parser encountered an invalid or unexpected character.", 
				ErrorType.DuplicateObjectKeys => "The parser encountered a JsonObject with duplicate keys.", 
				_ => "An error occurred while parsing the JSON message.", 
			};
		}
	}
}
