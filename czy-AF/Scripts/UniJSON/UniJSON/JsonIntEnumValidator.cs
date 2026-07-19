using System;
using System.Collections.Generic;
using System.Linq;

namespace UniJSON
{
	public class JsonIntEnumValidator : IJsonSchemaValidator
	{
		private static class GenericDeserializer<T, U> where T : IListTreeItem, IValue<T>
		{
			private delegate U Deserializer(ListTreeNode<T> src);

			private static Deserializer s_d;

			public static void Deserialize(ListTreeNode<T> src, ref U dst)
			{
				if (s_d == null)
				{
					s_d = (ListTreeNode<T> s) => GenericCast<int, U>.Cast(s.GetInt32());
				}
				dst = s_d(src);
			}
		}

		public int[] Values { get; set; }

		public static JsonIntEnumValidator Create(IEnumerable<int> values)
		{
			return new JsonIntEnumValidator
			{
				Values = values.ToArray()
			};
		}

		public override int GetHashCode()
		{
			return 7;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is JsonIntEnumValidator jsonIntEnumValidator))
			{
				return false;
			}
			if (Values.Length != jsonIntEnumValidator.Values.Length)
			{
				return false;
			}
			IEnumerator<int> enumerator = Values.OrderBy((int x) => x).GetEnumerator();
			IEnumerator<int> enumerator2 = jsonIntEnumValidator.Values.OrderBy((int x) => x).GetEnumerator();
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
			f.Value("integer");
		}

		public JsonSchemaValidationException Validate<T>(JsonSchemaValidationContext c, T o)
		{
			if (Values.Contains(GenericCast<T, int>.Cast(o)))
			{
				return null;
			}
			return new JsonSchemaValidationException(c, $"{o} is not valid enum");
		}

		public void Serialize<T>(IFormatter f, JsonSchemaValidationContext c, T o)
		{
			f.Serialize(GenericCast<T, int>.Cast(o));
		}

		public void Deserialize<T, U>(ListTreeNode<T> src, ref U dst) where T : IListTreeItem, IValue<T>
		{
			GenericDeserializer<T, U>.Deserialize(src, ref dst);
		}
	}
}
