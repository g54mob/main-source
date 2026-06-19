using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using MessagePack.Internal;

namespace MessagePack.Formatters
{
	public sealed class DynamicObjectTypeFallbackFormatter : IMessagePackFormatter<object>, IMessagePackFormatter
	{
		private delegate int SerializeMethod(object dynamicFormatter, ref byte[] bytes, int offset, object value, IFormatterResolver formatterResolver);

		private readonly ThreadsafeTypeKeyHashTable<KeyValuePair<object, SerializeMethod>> serializers = new ThreadsafeTypeKeyHashTable<KeyValuePair<object, SerializeMethod>>();

		private readonly IFormatterResolver[] innerResolvers;

		public DynamicObjectTypeFallbackFormatter(params IFormatterResolver[] innerResolvers)
		{
			this.innerResolvers = innerResolvers;
		}

		public int Serialize(ref byte[] bytes, int offset, object value, IFormatterResolver formatterResolver)
		{
			if (value == null)
			{
				return MessagePackBinary.WriteNil(ref bytes, offset);
			}
			Type type = value.GetType();
			TypeInfo typeInfo = type.GetTypeInfo();
			if (type == typeof(object))
			{
				return MessagePackBinary.WriteMapHeader(ref bytes, offset, 0);
			}
			if (!serializers.TryGetValue(type, out var value2))
			{
				lock (serializers)
				{
					if (!serializers.TryGetValue(type, out value2))
					{
						object obj = null;
						IFormatterResolver[] array = innerResolvers;
						for (int i = 0; i < array.Length; i++)
						{
							obj = array[i].GetFormatterDynamic(type);
							if (obj != null)
							{
								break;
							}
						}
						if (obj == null)
						{
							throw new FormatterNotRegisteredException(type.FullName + " is not registered in this resolver. resolvers:" + string.Join(", ", innerResolvers.Select((IFormatterResolver x) => x.GetType().Name).ToArray()));
						}
						Type type2 = type;
						Type type3 = typeof(IMessagePackFormatter<>).MakeGenericType(type2);
						ParameterExpression parameterExpression = Expression.Parameter(typeof(object), "formatter");
						ParameterExpression parameterExpression2 = Expression.Parameter(typeof(byte[]).MakeByRefType(), "bytes");
						ParameterExpression parameterExpression3 = Expression.Parameter(typeof(int), "offset");
						ParameterExpression parameterExpression4 = Expression.Parameter(typeof(object), "value");
						ParameterExpression parameterExpression5 = Expression.Parameter(typeof(IFormatterResolver), "formatterResolver");
						MethodInfo runtimeMethod = type3.GetRuntimeMethod("Serialize", new Type[4]
						{
							typeof(byte[]).MakeByRefType(),
							typeof(int),
							type2,
							typeof(IFormatterResolver)
						});
						SerializeMethod value3 = Expression.Lambda<SerializeMethod>(Expression.Call(Expression.Convert(parameterExpression, type3), runtimeMethod, parameterExpression2, parameterExpression3, typeInfo.IsValueType ? Expression.Unbox(parameterExpression4, type2) : Expression.Convert(parameterExpression4, type2), parameterExpression5), new ParameterExpression[5] { parameterExpression, parameterExpression2, parameterExpression3, parameterExpression4, parameterExpression5 }).Compile();
						value2 = new KeyValuePair<object, SerializeMethod>(obj, value3);
						serializers.TryAdd(type2, value2);
					}
				}
			}
			return value2.Value(value2.Key, ref bytes, offset, value, formatterResolver);
		}

		public object Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			return PrimitiveObjectFormatter.Instance.Deserialize(bytes, offset, formatterResolver, out readSize);
		}
	}
}
