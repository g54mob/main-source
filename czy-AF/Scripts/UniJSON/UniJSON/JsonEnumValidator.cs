using System;
using System.Collections.Generic;
using System.Linq;

namespace UniJSON
{
	public static class JsonEnumValidator
	{
		public static IJsonSchemaValidator Create(ListTreeNode<JsonValue> value)
		{
			foreach (ListTreeNode<JsonValue> item in value.ArrayItems())
			{
				if (item.IsInteger() || item.IsFloat())
				{
					return JsonIntEnumValidator.Create(from y in value.ArrayItems()
						where y.IsInteger() || y.IsFloat()
						select y.GetInt32());
				}
				if (item.IsString())
				{
					return JsonStringEnumValidator.Create(from y in value.ArrayItems()
						where y.IsString()
						select y.GetString(), EnumSerializationType.AsString);
				}
			}
			throw new NotImplementedException();
		}

		public static IJsonSchemaValidator Create(IEnumerable<JsonSchema> composition, EnumSerializationType type)
		{
			foreach (JsonSchema item in composition)
			{
				if (item.Validator is JsonStringEnumValidator)
				{
					return JsonStringEnumValidator.Create((from y in composition
						select y.Validator as JsonStringEnumValidator into y
						where y != null
						select y).SelectMany((JsonStringEnumValidator y) => y.Values), type);
				}
				if (item.Validator is JsonIntEnumValidator)
				{
					return JsonIntEnumValidator.Create((from y in composition
						select y.Validator as JsonIntEnumValidator into y
						where y != null
						select y).SelectMany((JsonIntEnumValidator y) => y.Values));
				}
			}
			throw new NotImplementedException();
		}

		private static IEnumerable<string> GetStringValues(Type t, object[] excludes, Func<string, string> filter)
		{
			foreach (object value in Enum.GetValues(t))
			{
				if (excludes == null || !excludes.Contains(value))
				{
					yield return filter(value.ToString());
				}
			}
		}

		private static IEnumerable<int> GetIntValues(Type t, object[] excludes)
		{
			foreach (object value in Enum.GetValues(t))
			{
				if (excludes == null || !excludes.Contains(value))
				{
					yield return (int)value;
				}
			}
		}

		public static IJsonSchemaValidator Create(Type t, EnumSerializationType serializationType, object[] excludes)
		{
			return serializationType switch
			{
				EnumSerializationType.AsInt => JsonIntEnumValidator.Create(GetIntValues(t, excludes)), 
				EnumSerializationType.AsString => JsonStringEnumValidator.Create(GetStringValues(t, excludes, (string x) => x), serializationType), 
				EnumSerializationType.AsLowerString => JsonStringEnumValidator.Create(GetStringValues(t, excludes, (string x) => x.ToLower()), serializationType), 
				EnumSerializationType.AsUpperString => JsonStringEnumValidator.Create(GetStringValues(t, excludes, (string x) => x.ToUpper()), serializationType), 
				_ => throw new NotImplementedException(), 
			};
		}

		public static IJsonSchemaValidator Create(object[] values, EnumSerializationType type)
		{
			foreach (object obj in values)
			{
				if (obj is string)
				{
					return JsonStringEnumValidator.Create(values.Select((object y) => (string)y), type);
				}
				if (obj is int)
				{
					return JsonIntEnumValidator.Create(values.Select((object y) => (int)y));
				}
			}
			throw new NotImplementedException();
		}
	}
}
