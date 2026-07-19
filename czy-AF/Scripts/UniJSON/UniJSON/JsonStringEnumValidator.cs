using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UniJSON
{
	public class JsonStringEnumValidator : IJsonSchemaValidator
	{
		public static class GenericSerializer<T>
		{
			private delegate void Serializer(JsonStringEnumValidator v, IFormatter f, JsonSchemaValidationContext c, T o);

			private static Serializer s_serializer;

			public static void Serialize(JsonStringEnumValidator validator, IFormatter f, JsonSchemaValidationContext c, T o)
			{
				if (s_serializer == null)
				{
					Type t = typeof(T);
					if (t.IsEnum)
					{
						s_serializer = delegate(JsonStringEnumValidator vv, IFormatter ff, JsonSchemaValidationContext cc, T oo)
						{
							string text = Enum.GetName(t, oo);
							if (vv.SerializationType == EnumSerializationType.AsLowerString)
							{
								text = text.ToLower();
							}
							else if (vv.SerializationType == EnumSerializationType.AsUpperString)
							{
								text = text.ToUpper();
							}
							ff.Value(text);
						};
					}
					else
					{
						if (!(t == typeof(string)))
						{
							throw new NotImplementedException();
						}
						s_serializer = delegate(JsonStringEnumValidator vv, IFormatter ff, JsonSchemaValidationContext cc, T oo)
						{
							string text = GenericCast<T, string>.Cast(oo);
							if (vv.SerializationType == EnumSerializationType.AsLowerString)
							{
								text = text.ToLower();
							}
							else if (vv.SerializationType == EnumSerializationType.AsUpperString)
							{
								text = text.ToUpper();
							}
							ff.Value(text);
						};
					}
				}
				s_serializer(validator, f, c, o);
			}
		}

		private static class GenericDeserializer<T, U> where T : IListTreeItem, IValue<T>
		{
			private delegate U Deserializer(ListTreeNode<T> src);

			private static Deserializer s_d;

			public static void Deserialize(ListTreeNode<T> src, ref U t)
			{
				if (s_d == null)
				{
					if (typeof(U).IsEnum)
					{
						MethodInfo m = typeof(Enum).GetMethods(BindingFlags.Static | BindingFlags.Public).First((MethodInfo x) => x.Name == "Parse" && x.GetParameters().Length == 3);
						Func<Type, string, bool, object> enumParse = GenericInvokeCallFactory.StaticFunc<Type, string, bool, object>(m);
						s_d = (ListTreeNode<T> x) => GenericCast<object, U>.Cast(enumParse(typeof(U), x.GetString(), arg3: true));
					}
					else
					{
						s_d = (ListTreeNode<T> x) => GenericCast<string, U>.Cast(x.GetString());
					}
				}
				t = s_d(src);
			}
		}

		private EnumSerializationType SerializationType;

		public string[] Values { get; set; }

		private JsonStringEnumValidator(IEnumerable<string> values, EnumSerializationType type)
		{
			SerializationType = type;
			switch (SerializationType)
			{
			case EnumSerializationType.AsString:
				Values = values.ToArray();
				break;
			case EnumSerializationType.AsLowerString:
				Values = values.Select((string x) => x.ToLower()).ToArray();
				break;
			case EnumSerializationType.AsUpperString:
				Values = values.Select((string x) => x.ToUpper()).ToArray();
				break;
			case EnumSerializationType.AsInt:
				throw new ArgumentException("JsonStringEnumValidator not allow AsInt");
			default:
				throw new NotImplementedException("");
			}
		}

		public static JsonStringEnumValidator Create(IEnumerable<string> values, EnumSerializationType type)
		{
			return new JsonStringEnumValidator(values, type);
		}

		public override int GetHashCode()
		{
			return 7;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is JsonStringEnumValidator jsonStringEnumValidator))
			{
				return false;
			}
			if (Values.Length != jsonStringEnumValidator.Values.Length)
			{
				return false;
			}
			IEnumerator<string> enumerator = Values.OrderBy((string x) => x).GetEnumerator();
			IEnumerator<string> enumerator2 = jsonStringEnumValidator.Values.OrderBy((string x) => x).GetEnumerator();
			while (enumerator.MoveNext() && enumerator2.MoveNext())
			{
				if (enumerator.Current != enumerator2.Current)
				{
					return false;
				}
			}
			return true;
		}

		public void Merge(IJsonSchemaValidator obj)
		{
			throw new NotImplementedException();
		}

		public bool FromJsonSchema(IFileSystemAccessor fs, string key, ListTreeNode<JsonValue> value)
		{
			throw new NotImplementedException();
		}

		public void ToJsonSchema(IFormatter f)
		{
			f.Key("type");
			f.Value("string");
			f.Key("enum");
			f.BeginList(Values.Length);
			string[] values = Values;
			foreach (string x in values)
			{
				f.Value(x);
			}
			f.EndList();
		}

		public JsonSchemaValidationException Validate<T>(JsonSchemaValidationContext c, T o)
		{
			if (o == null)
			{
				return new JsonSchemaValidationException(c, "null");
			}
			Type type = o.GetType();
			string text = null;
			text = ((!type.IsEnum) ? GenericCast<T, string>.Cast(o) : Enum.GetName(type, o));
			if (SerializationType == EnumSerializationType.AsLowerString)
			{
				text = text.ToLower();
			}
			else if (SerializationType == EnumSerializationType.AsUpperString)
			{
				text = text.ToUpper();
			}
			if (Values.Contains(text))
			{
				return null;
			}
			return new JsonSchemaValidationException(c, $"{o} is not valid enum");
		}

		public void Serialize<T>(IFormatter f, JsonSchemaValidationContext c, T o)
		{
			GenericSerializer<T>.Serialize(this, f, c, o);
		}

		public void Deserialize<T, U>(ListTreeNode<T> src, ref U dst) where T : IListTreeItem, IValue<T>
		{
			GenericDeserializer<T, U>.Deserialize(src, ref dst);
		}
	}
}
