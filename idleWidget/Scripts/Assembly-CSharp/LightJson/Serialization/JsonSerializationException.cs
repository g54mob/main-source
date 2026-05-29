using System;

namespace LightJson.Serialization
{
	public sealed class JsonSerializationException : Exception
	{
		public enum ErrorType
		{
			Unknown = 0,
			InvalidNumber = 1,
			InvalidValueType = 2,
			CircularReference = 3
		}

		public ErrorType Type { get; private set; }

		public JsonSerializationException()
			: base(GetDefaultMessage(ErrorType.Unknown))
		{
		}

		public JsonSerializationException(ErrorType type)
			: this(GetDefaultMessage(type), type)
		{
		}

		public JsonSerializationException(string message, ErrorType type)
			: base(message)
		{
			Type = type;
		}

		private static string GetDefaultMessage(ErrorType type)
		{
			return type switch
			{
				ErrorType.InvalidNumber => "The value been serialized contains an invalid number value (NAN, infinity).", 
				ErrorType.InvalidValueType => "The value been serialized contains (or is) an invalid JSON type.", 
				ErrorType.CircularReference => "The value been serialized contains circular references.", 
				_ => "An error occurred during serialization.", 
			};
		}
	}
}
