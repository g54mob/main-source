using System;
using System.Collections.Generic;
using System.Diagnostics;
using LightJson.Serialization;

namespace LightJson
{
	[DebuggerDisplay("{ToString(),nq}", Type = "JsonValue({Type})")]
	[DebuggerTypeProxy(typeof(JsonValueDebugView))]
	public struct JsonValue
	{
		private class JsonValueDebugView
		{
			private JsonValue jsonValue;

			[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
			public JsonObject ObjectView
			{
				get
				{
					if (jsonValue.IsJsonObject)
					{
						return (JsonObject)jsonValue.reference;
					}
					return null;
				}
			}

			[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
			public JsonArray ArrayView
			{
				get
				{
					if (jsonValue.IsJsonArray)
					{
						return (JsonArray)jsonValue.reference;
					}
					return null;
				}
			}

			public JsonValueType Type => jsonValue.Type;

			public object Value
			{
				get
				{
					if (jsonValue.IsJsonObject)
					{
						return (JsonObject)jsonValue.reference;
					}
					if (jsonValue.IsJsonArray)
					{
						return (JsonArray)jsonValue.reference;
					}
					return jsonValue;
				}
			}

			public JsonValueDebugView(JsonValue jsonValue)
			{
				this.jsonValue = jsonValue;
			}
		}

		private readonly JsonValueType type;

		private readonly object reference;

		private readonly double value;

		public static readonly JsonValue Null = new JsonValue(JsonValueType.Null, 0.0, null);

		public JsonValueType Type => type;

		public bool IsNull => Type == JsonValueType.Null;

		public bool IsBoolean => Type == JsonValueType.Boolean;

		public bool IsInteger
		{
			get
			{
				if (!IsNumber)
				{
					return false;
				}
				double num = value;
				if (num >= -2147483648.0 && num <= 2147483647.0)
				{
					return num % 1.0 == 0.0;
				}
				return false;
			}
		}

		public bool IsNumber => Type == JsonValueType.Number;

		public bool IsString => Type == JsonValueType.String;

		public bool IsJsonObject => Type == JsonValueType.Object;

		public bool IsJsonArray => Type == JsonValueType.Array;

		public bool IsDateTime => AsDateTime.HasValue;

		public bool AsBoolean
		{
			get
			{
				switch (Type)
				{
				case JsonValueType.Boolean:
					return value == 1.0;
				case JsonValueType.Number:
					return value != 0.0;
				case JsonValueType.String:
					return (string)reference != "";
				case JsonValueType.Object:
				case JsonValueType.Array:
					return true;
				default:
					return false;
				}
			}
		}

		public int AsInteger
		{
			get
			{
				double asNumber = AsNumber;
				if (asNumber >= 2147483647.0)
				{
					return int.MaxValue;
				}
				if (asNumber <= -2147483648.0)
				{
					return int.MinValue;
				}
				return (int)asNumber;
			}
		}

		public double AsNumber
		{
			get
			{
				switch (Type)
				{
				case JsonValueType.Boolean:
					return (value == 1.0) ? 1 : 0;
				case JsonValueType.Number:
					return value;
				case JsonValueType.String:
				{
					if (double.TryParse((string)reference, out var result))
					{
						return result;
					}
					break;
				}
				}
				return 0.0;
			}
		}

		public string AsString
		{
			get
			{
				switch (Type)
				{
				case JsonValueType.Boolean:
					if (value != 1.0)
					{
						return "false";
					}
					return "true";
				case JsonValueType.Number:
					return value.ToString();
				case JsonValueType.String:
					return (string)reference;
				default:
					return null;
				}
			}
		}

		public JsonObject AsJsonObject
		{
			get
			{
				if (!IsJsonObject)
				{
					return null;
				}
				return (JsonObject)reference;
			}
		}

		public JsonArray AsJsonArray
		{
			get
			{
				if (!IsJsonArray)
				{
					return null;
				}
				return (JsonArray)reference;
			}
		}

		public DateTime? AsDateTime
		{
			get
			{
				if (IsString && DateTime.TryParse((string)reference, out var result))
				{
					return result;
				}
				return null;
			}
		}

		public object AsObject
		{
			get
			{
				switch (Type)
				{
				case JsonValueType.Boolean:
				case JsonValueType.Number:
					return value;
				case JsonValueType.String:
				case JsonValueType.Object:
				case JsonValueType.Array:
					return reference;
				default:
					return null;
				}
			}
		}

		public JsonValue this[string key]
		{
			get
			{
				if (IsJsonObject)
				{
					return ((JsonObject)reference)[key];
				}
				throw new InvalidOperationException("This value does not represent a JsonObject.");
			}
			set
			{
				if (IsJsonObject)
				{
					((JsonObject)reference)[key] = value;
					return;
				}
				throw new InvalidOperationException("This value does not represent a JsonObject.");
			}
		}

		public JsonValue this[int index]
		{
			get
			{
				if (IsJsonArray)
				{
					return ((JsonArray)reference)[index];
				}
				throw new InvalidOperationException("This value does not represent a JsonArray.");
			}
			set
			{
				if (IsJsonArray)
				{
					((JsonArray)reference)[index] = value;
					return;
				}
				throw new InvalidOperationException("This value does not represent a JsonArray.");
			}
		}

		private JsonValue(JsonValueType type, double value, object reference)
		{
			this.type = type;
			this.value = value;
			this.reference = reference;
		}

		public JsonValue(bool? value)
		{
			if (value.HasValue)
			{
				reference = null;
				type = JsonValueType.Boolean;
				this.value = (value.Value ? 1 : 0);
			}
			else
			{
				this = Null;
			}
		}

		public JsonValue(double? value)
		{
			if (value.HasValue)
			{
				reference = null;
				type = JsonValueType.Number;
				this.value = value.Value;
			}
			else
			{
				this = Null;
			}
		}

		public JsonValue(string value)
		{
			if (value != null)
			{
				this.value = 0.0;
				type = JsonValueType.String;
				reference = value;
			}
			else
			{
				this = Null;
			}
		}

		public JsonValue(JsonObject value)
		{
			if (value != null)
			{
				this.value = 0.0;
				type = JsonValueType.Object;
				reference = value;
			}
			else
			{
				this = Null;
			}
		}

		public JsonValue(JsonArray value)
		{
			if (value != null)
			{
				this.value = 0.0;
				type = JsonValueType.Array;
				reference = value;
			}
			else
			{
				this = Null;
			}
		}

		public static implicit operator JsonValue(bool? value)
		{
			return new JsonValue(value);
		}

		public static implicit operator JsonValue(double? value)
		{
			return new JsonValue(value);
		}

		public static implicit operator JsonValue(string value)
		{
			return new JsonValue(value);
		}

		public static implicit operator JsonValue(JsonObject value)
		{
			return new JsonValue(value);
		}

		public static implicit operator JsonValue(JsonArray value)
		{
			return new JsonValue(value);
		}

		public static implicit operator JsonValue(DateTime? value)
		{
			if (!value.HasValue)
			{
				return Null;
			}
			return new JsonValue(value.Value.ToString("o"));
		}

		public static implicit operator int(JsonValue jsonValue)
		{
			if (jsonValue.IsInteger)
			{
				return jsonValue.AsInteger;
			}
			return 0;
		}

		public static implicit operator int?(JsonValue jsonValue)
		{
			if (jsonValue.IsNull)
			{
				return null;
			}
			return jsonValue;
		}

		public static implicit operator bool(JsonValue jsonValue)
		{
			if (jsonValue.IsBoolean)
			{
				return jsonValue.value == 1.0;
			}
			return false;
		}

		public static implicit operator bool?(JsonValue jsonValue)
		{
			if (jsonValue.IsNull)
			{
				return null;
			}
			return jsonValue;
		}

		public static implicit operator double(JsonValue jsonValue)
		{
			if (jsonValue.IsNumber)
			{
				return jsonValue.value;
			}
			return double.NaN;
		}

		public static implicit operator double?(JsonValue jsonValue)
		{
			if (jsonValue.IsNull)
			{
				return null;
			}
			return jsonValue;
		}

		public static implicit operator string(JsonValue jsonValue)
		{
			if (jsonValue.IsString || jsonValue.IsNull)
			{
				return jsonValue.reference as string;
			}
			return null;
		}

		public static implicit operator JsonObject(JsonValue jsonValue)
		{
			if (jsonValue.IsJsonObject || jsonValue.IsNull)
			{
				return jsonValue.reference as JsonObject;
			}
			return null;
		}

		public static implicit operator JsonArray(JsonValue jsonValue)
		{
			if (jsonValue.IsJsonArray || jsonValue.IsNull)
			{
				return jsonValue.reference as JsonArray;
			}
			return null;
		}

		public static implicit operator DateTime(JsonValue jsonValue)
		{
			DateTime? asDateTime = jsonValue.AsDateTime;
			if (asDateTime.HasValue)
			{
				return asDateTime.Value;
			}
			return DateTime.MinValue;
		}

		public static implicit operator DateTime?(JsonValue jsonValue)
		{
			if (jsonValue.IsDateTime || jsonValue.IsNull)
			{
				return jsonValue.AsDateTime;
			}
			return null;
		}

		public static bool operator ==(JsonValue a, JsonValue b)
		{
			if (a.Type == b.Type && a.value == b.value)
			{
				return object.Equals(a.reference, b.reference);
			}
			return false;
		}

		public static bool operator !=(JsonValue a, JsonValue b)
		{
			return !(a == b);
		}

		public static JsonValue Parse(string text)
		{
			return JsonReader.Parse(text);
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return IsNull;
			}
			JsonValue? jsonValue = obj as JsonValue?;
			if (jsonValue.HasValue)
			{
				return this == jsonValue.Value;
			}
			return false;
		}

		public override int GetHashCode()
		{
			if (IsNull)
			{
				return Type.GetHashCode();
			}
			return Type.GetHashCode() ^ value.GetHashCode() ^ EqualityComparer<object>.Default.GetHashCode(reference);
		}

		public override string ToString()
		{
			return ToString(pretty: false);
		}

		public string ToString(bool pretty)
		{
			using JsonWriter jsonWriter = new JsonWriter(pretty);
			return jsonWriter.Serialize(this);
		}
	}
}
