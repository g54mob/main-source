using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UniJSON
{
	public static class GenericDeserializer<T, U> where T : IListTreeItem, IValue<T>
	{
		private delegate void FieldSetter(ListTreeNode<T> s, object o);

		public delegate U Deserializer(ListTreeNode<T> node);

		public static Deserializer s_deserializer;

		public static V[] GenericArrayDeserializer<V>(ListTreeNode<T> s)
		{
			if (!s.IsArray())
			{
				throw new ArgumentException("not array: " + s.Value.ValueType);
			}
			V[] array = new V[s.GetArrayCount()];
			int num = 0;
			foreach (ListTreeNode<T> item in s.ArrayItems())
			{
				item.Deserialize(ref array[num++]);
			}
			return array;
		}

		public static List<V> GenericListDeserializer<V>(ListTreeNode<T> s)
		{
			if (!s.IsArray())
			{
				throw new ArgumentException("not array: " + s.Value.ValueType);
			}
			List<V> list = new List<V>(s.GetArrayCount());
			foreach (ListTreeNode<T> item in s.ArrayItems())
			{
				V value = default(V);
				item.Deserialize(ref value);
				list.Add(value);
			}
			return list;
		}

		public static object DefaultDictionaryDeserializer(ListTreeNode<T> s)
		{
			switch (s.Value.ValueType)
			{
			case ValueNodeType.Object:
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				{
					foreach (KeyValuePair<ListTreeNode<T>, ListTreeNode<T>> item in s.ObjectItems())
					{
						dictionary.Add(item.Key.GetString(), DefaultDictionaryDeserializer(item.Value));
					}
					return dictionary;
				}
			}
			case ValueNodeType.Null:
				return null;
			case ValueNodeType.Boolean:
				return s.GetBoolean();
			case ValueNodeType.Integer:
				return s.GetInt32();
			case ValueNodeType.Number:
				return s.GetDouble();
			case ValueNodeType.String:
				return s.GetString();
			default:
				throw new NotImplementedException(s.Value.ValueType.ToString());
			}
		}

		public static Dictionary<string, V> DictionaryDeserializer<V>(ListTreeNode<T> s)
		{
			Dictionary<string, V> dictionary = new Dictionary<string, V>();
			foreach (KeyValuePair<ListTreeNode<T>, ListTreeNode<T>> item in s.ObjectItems())
			{
				V value = default(V);
				GenericDeserializer<T, V>.Deserialize(item.Value, ref value);
				dictionary.Add(item.Key.GetString(), value);
			}
			return dictionary;
		}

		private static FieldSetter GetFieldDeserializer<V>(FieldInfo fi)
		{
			return delegate(ListTreeNode<T> s, object o)
			{
				V value = default(V);
				s.Deserialize(ref value);
				fi.SetValue(o, value);
			};
		}

		private static Func<ListTreeNode<T>, U> GetDeserializer()
		{
			MethodInfo methodInfo = typeof(ListTreeNode<T>).GetMethods().FirstOrDefault(delegate(MethodInfo x)
			{
				if (!x.Name.StartsWith("Get"))
				{
					return false;
				}
				if (!x.Name.EndsWith(typeof(U).Name))
				{
					return false;
				}
				if (x.GetParameters().Length != 0)
				{
					return false;
				}
				return !(x.ReturnType != typeof(U));
			});
			if (methodInfo != null)
			{
				return GenericInvokeCallFactory.StaticFunc<ListTreeNode<T>, U>(methodInfo);
			}
			Type typeFromHandle = typeof(U);
			if (typeFromHandle.IsArray)
			{
				return GenericInvokeCallFactory.StaticFunc<ListTreeNode<T>, U>(typeof(GenericDeserializer<T, U>).GetMethod("GenericArrayDeserializer", BindingFlags.Static | BindingFlags.Public).MakeGenericMethod(typeFromHandle.GetElementType()));
			}
			if (typeFromHandle.IsGenericType)
			{
				if (typeFromHandle.GetGenericTypeDefinition() == typeof(List<>))
				{
					return GenericInvokeCallFactory.StaticFunc<ListTreeNode<T>, U>(typeof(GenericDeserializer<T, U>).GetMethod("GenericListDeserializer", BindingFlags.Static | BindingFlags.Public).MakeGenericMethod(typeFromHandle.GetGenericArguments()));
				}
				if (typeFromHandle == typeof(Dictionary<string, object>))
				{
					return GenericInvokeCallFactory.StaticFunc<ListTreeNode<T>, U>(typeof(GenericDeserializer<T, U>).GetMethod("DefaultDictionaryDeserializer", BindingFlags.Static | BindingFlags.Public));
				}
				if (typeFromHandle.GetGenericTypeDefinition() == typeof(Dictionary<, >) && typeFromHandle.GetGenericArguments()[0] == typeof(string))
				{
					return GenericInvokeCallFactory.StaticFunc<ListTreeNode<T>, U>(typeof(GenericDeserializer<T, U>).GetMethod("DictionaryDeserializer", BindingFlags.Static | BindingFlags.Public).MakeGenericMethod(typeFromHandle.GetGenericArguments()[1]));
				}
			}
			JsonSchema schema = JsonSchema.FromType<U>();
			return delegate(ListTreeNode<T> s)
			{
				U dst = default(U);
				schema.Validator.Deserialize(s, ref dst);
				return dst;
			};
		}

		public static void Deserialize(ListTreeNode<T> node, ref U value)
		{
			if (s_deserializer == null)
			{
				s_deserializer = GetDeserializer().Invoke;
			}
			value = s_deserializer(node);
		}

		public static void SetCustomDeserializer(Deserializer deserializer)
		{
			s_deserializer = deserializer;
		}
	}
}
