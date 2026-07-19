using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace UniJSON
{
	public class JsonArrayValidator : IJsonSchemaValidator
	{
		private static class GenericCounter<T>
		{
			private delegate int Counter(T value);

			private static Counter s_counter;

			public static int Count(T value)
			{
				if (s_counter == null)
				{
					Type typeFromHandle = typeof(T);
					if (typeFromHandle.IsArray)
					{
						PropertyInfo pi = typeFromHandle.GetProperty("Length");
						s_counter = ((Func<T, int>)((T array) => (int)pi.GetValue(array, null))).Invoke;
					}
					else
					{
						if (!typeFromHandle.GetIsGenericList())
						{
							throw new NotImplementedException();
						}
						PropertyInfo pi2 = typeFromHandle.GetProperty("Count");
						s_counter = ((Func<T, int>)((T list) => (int)pi2.GetValue(list, null))).Invoke;
					}
				}
				return s_counter(value);
			}
		}

		private static class GenericSerializer<T>
		{
			private delegate void Serializer(IJsonSchemaValidator v, IFormatter f, JsonSchemaValidationContext c, T o);

			private static Serializer s_serializer;

			public static void Serialize(IJsonSchemaValidator v, IFormatter f, JsonSchemaValidationContext c, T o)
			{
				if (s_serializer == null)
				{
					Type typeFromHandle = typeof(T);
					MethodInfo methodInfo = null;
					if (typeFromHandle.IsArray)
					{
						methodInfo = typeof(JsonArrayValidator).GetMethod("ArraySerializer", BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(typeFromHandle.GetElementType());
					}
					else
					{
						if (!typeFromHandle.GetIsGenericList())
						{
							throw new NotImplementedException();
						}
						methodInfo = typeof(JsonArrayValidator).GetMethod("ListSerializer", BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(typeFromHandle.GetGenericArguments());
					}
					s_serializer = GenericInvokeCallFactory.StaticAction<IJsonSchemaValidator, IFormatter, JsonSchemaValidationContext, T>(methodInfo).Invoke;
				}
				s_serializer(v, f, c, o);
			}
		}

		public JsonSchema Items { get; set; }

		public int? MaxItems { get; set; }

		public int? MinItems { get; set; }

		public override int GetHashCode()
		{
			return 5;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is JsonArrayValidator jsonArrayValidator))
			{
				return false;
			}
			if (Items != jsonArrayValidator.Items)
			{
				return false;
			}
			if (MaxItems != jsonArrayValidator.MaxItems)
			{
				return false;
			}
			if (MinItems != jsonArrayValidator.MinItems)
			{
				return false;
			}
			return true;
		}

		public void Merge(IJsonSchemaValidator rhs)
		{
			throw new NotImplementedException();
		}

		public bool FromJsonSchema(IFileSystemAccessor fs, string key, ListTreeNode<JsonValue> value)
		{
			switch (key)
			{
			case "items":
			{
				if (value.IsArray())
				{
					throw new NotImplementedException();
				}
				JsonSchema jsonSchema = new JsonSchema();
				jsonSchema.Parse(fs, value, "items");
				Items = jsonSchema;
				return true;
			}
			case "additionalItems":
				return true;
			case "maxItems":
				MaxItems = value.GetInt32();
				return true;
			case "minItems":
				MinItems = value.GetInt32();
				return true;
			case "uniqueItems":
				return true;
			case "contains":
				return true;
			default:
				return false;
			}
		}

		public JsonSchemaValidationException Validate<T>(JsonSchemaValidationContext context, T o)
		{
			if (o == null)
			{
				return new JsonSchemaValidationException(context, "null");
			}
			int num = GenericCounter<T>.Count(o);
			if (MaxItems.HasValue && num > MaxItems.Value)
			{
				return new JsonSchemaValidationException(context, "maxItems");
			}
			if (MinItems.HasValue && num < MinItems.Value)
			{
				return new JsonSchemaValidationException(context, "minItems");
			}
			if (Items == null)
			{
				return null;
			}
			IJsonSchemaValidator validator = Items.Validator;
			Type type = o.GetType();
			IEnumerable enumerable = null;
			if (type.IsArray)
			{
				enumerable = o as Array;
			}
			else
			{
				if (!type.GetIsGenericList())
				{
					return new JsonSchemaValidationException(context, "non iterable object");
				}
				enumerable = o as IList;
			}
			foreach (object item in enumerable)
			{
				JsonSchemaValidationException ex = validator.Validate(context, item);
				if (ex != null)
				{
					return ex;
				}
			}
			return null;
		}

		private static void ArraySerializer<U>(IJsonSchemaValidator v, IFormatter f, JsonSchemaValidationContext c, U[] array)
		{
			f.BeginList(array.Length);
			foreach (U value in array)
			{
				v.Serialize(f, c, value);
			}
			f.EndList();
		}

		private static void ListSerializer<U>(IJsonSchemaValidator v, IFormatter f, JsonSchemaValidationContext c, List<U> list)
		{
			f.BeginList(list.Count);
			foreach (U item in list)
			{
				v.Serialize(f, c, item);
			}
			f.EndList();
		}

		public void Serialize<T>(IFormatter f, JsonSchemaValidationContext c, T o)
		{
			GenericSerializer<T>.Serialize(Items.Validator, f, c, o);
		}

		public void ToJsonSchema(IFormatter f)
		{
			f.Key("type");
			f.Value("array");
			if (Items != null)
			{
				f.Key("items");
				Items.ToJson(f);
			}
		}

		public void Deserialize<T, U>(ListTreeNode<T> src, ref U dst) where T : IListTreeItem, IValue<T>
		{
			src.Deserialize(ref dst);
		}
	}
}
