using System;

namespace Google.Protobuf
{
	internal sealed class JsonToken : IEquatable<JsonToken>
	{
		internal enum TokenType
		{
			Null = 0,
			False = 1,
			True = 2,
			StringValue = 3,
			Number = 4,
			Name = 5,
			StartObject = 6,
			EndObject = 7,
			StartArray = 8,
			EndArray = 9,
			EndDocument = 10
		}

		private readonly TokenType type;

		private readonly string stringValue;

		private readonly double numberValue;

		internal static JsonToken Null { get; }

		internal static JsonToken False { get; }

		internal static JsonToken True { get; }

		internal static JsonToken StartObject { get; }

		internal static JsonToken EndObject { get; }

		internal static JsonToken StartArray { get; }

		internal static JsonToken EndArray { get; }

		internal static JsonToken EndDocument { get; }

		internal TokenType Type => default(TokenType);

		internal string StringValue => null;

		internal double NumberValue => 0.0;

		internal static JsonToken Name(string name)
		{
			return null;
		}

		internal static JsonToken Value(string value)
		{
			return null;
		}

		internal static JsonToken Value(double value)
		{
			return null;
		}

		private JsonToken(TokenType type, string stringValue = null, double numberValue = 0.0)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}

		public bool Equals(JsonToken other)
		{
			return false;
		}
	}
}
