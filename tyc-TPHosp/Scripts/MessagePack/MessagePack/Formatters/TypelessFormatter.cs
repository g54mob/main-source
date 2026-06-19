using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using MessagePack.Internal;
using MessagePack.Resolvers;

namespace MessagePack.Formatters
{
	public sealed class TypelessFormatter : IMessagePackFormatter<object>, IMessagePackFormatter
	{
		private delegate int SerializeMethod(object dynamicContractlessFormatter, ref byte[] bytes, int offset, object value, IFormatterResolver formatterResolver);

		private delegate object DeserializeMethod(object dynamicContractlessFormatter, byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize);

		public const sbyte ExtensionTypeCode = 100;

		private static readonly Regex SubtractFullNameRegex;

		public static readonly IMessagePackFormatter<object> Instance;

		private static readonly ThreadsafeTypeKeyHashTable<KeyValuePair<object, SerializeMethod>> serializers;

		private static readonly ThreadsafeTypeKeyHashTable<KeyValuePair<object, DeserializeMethod>> deserializers;

		private static readonly ThreadsafeTypeKeyHashTable<byte[]> typeNameCache;

		private static readonly AsymmetricKeyHashTable<byte[], ArraySegment<byte>, Type> typeCache;

		private static readonly HashSet<string> blacklistCheck;

		private static readonly HashSet<Type> useBuiltinTypes;

		private static bool isMscorlib;

		public static volatile bool RemoveAssemblyVersion;

		public static Func<string, Type> BindToType { get; set; }

		private static Type DefaultBindToType(string typeName)
		{
			return Type.GetType(typeName, throwOnError: false);
		}

		static TypelessFormatter()
		{
			SubtractFullNameRegex = new Regex(", Version=\\d+.\\d+.\\d+.\\d+, Culture=\\w+, PublicKeyToken=\\w+", RegexOptions.Compiled);
			Instance = new TypelessFormatter();
			serializers = new ThreadsafeTypeKeyHashTable<KeyValuePair<object, SerializeMethod>>();
			deserializers = new ThreadsafeTypeKeyHashTable<KeyValuePair<object, DeserializeMethod>>();
			typeNameCache = new ThreadsafeTypeKeyHashTable<byte[]>();
			typeCache = new AsymmetricKeyHashTable<byte[], ArraySegment<byte>, Type>(new StringArraySegmentByteAscymmetricEqualityComparer());
			useBuiltinTypes = new HashSet<Type>
			{
				typeof(bool),
				typeof(sbyte),
				typeof(byte),
				typeof(short),
				typeof(ushort),
				typeof(int),
				typeof(uint),
				typeof(long),
				typeof(ulong),
				typeof(float),
				typeof(double),
				typeof(string),
				typeof(byte[]),
				typeof(bool[]),
				typeof(sbyte[]),
				typeof(short[]),
				typeof(ushort[]),
				typeof(int[]),
				typeof(uint[]),
				typeof(long[]),
				typeof(ulong[]),
				typeof(float[]),
				typeof(double[]),
				typeof(string[]),
				typeof(bool?),
				typeof(sbyte?),
				typeof(byte?),
				typeof(short?),
				typeof(ushort?),
				typeof(int?),
				typeof(uint?),
				typeof(long?),
				typeof(ulong?),
				typeof(float?),
				typeof(double?)
			};
			isMscorlib = typeof(int).AssemblyQualifiedName.Contains("mscorlib");
			RemoveAssemblyVersion = true;
			blacklistCheck = new HashSet<string> { "System.CodeDom.Compiler.TempFileCollection", "System.IO.FileSystemInfo", "System.Management.IWbemClassObjectFreeThreaded" };
			serializers.TryAdd(typeof(object), (Type _) => new KeyValuePair<object, SerializeMethod>(null, delegate
			{
				return 0;
			}));
			deserializers.TryAdd(typeof(object), (Type _) => new KeyValuePair<object, DeserializeMethod>(null, delegate(object p1, byte[] p2, int p3, IFormatterResolver p4, out int p5)
			{
				p5 = 0;
				return new object();
			}));
			BindToType = DefaultBindToType;
		}

		private static string BuildTypeName(Type type)
		{
			if (RemoveAssemblyVersion)
			{
				string assemblyQualifiedName = type.AssemblyQualifiedName;
				string text = SubtractFullNameRegex.Replace(assemblyQualifiedName, "");
				if (Type.GetType(text, throwOnError: false) == null)
				{
					text = assemblyQualifiedName;
				}
				return text;
			}
			return type.AssemblyQualifiedName;
		}

		public int Serialize(ref byte[] bytes, int offset, object value, IFormatterResolver formatterResolver)
		{
			if (value == null)
			{
				return MessagePackBinary.WriteNil(ref bytes, offset);
			}
			Type type = value.GetType();
			if (!typeNameCache.TryGetValue(type, out var value2))
			{
				if (blacklistCheck.Contains(type.FullName))
				{
					throw new InvalidOperationException("Type is in blacklist:" + type.FullName);
				}
				value2 = ((!type.GetTypeInfo().IsAnonymous() && !useBuiltinTypes.Contains(type)) ? StringEncoding.UTF8.GetBytes(BuildTypeName(type)) : null);
				typeNameCache.TryAdd(type, value2);
			}
			if (value2 == null)
			{
				return TypelessFormatterFallbackResolver.Instance.GetFormatter<object>().Serialize(ref bytes, offset, value, formatterResolver);
			}
			if (!serializers.TryGetValue(type, out var value3))
			{
				lock (serializers)
				{
					if (!serializers.TryGetValue(type, out value3))
					{
						TypeInfo typeInfo = type.GetTypeInfo();
						object formatterDynamic = formatterResolver.GetFormatterDynamic(type);
						if (formatterDynamic == null)
						{
							throw new FormatterNotRegisteredException(type.FullName + " is not registered in this resolver. resolver:" + formatterResolver.GetType().Name);
						}
						Type type2 = typeof(IMessagePackFormatter<>).MakeGenericType(type);
						ParameterExpression parameterExpression = Expression.Parameter(typeof(object), "formatter");
						ParameterExpression parameterExpression2 = Expression.Parameter(typeof(byte[]).MakeByRefType(), "bytes");
						ParameterExpression parameterExpression3 = Expression.Parameter(typeof(int), "offset");
						ParameterExpression parameterExpression4 = Expression.Parameter(typeof(object), "value");
						ParameterExpression parameterExpression5 = Expression.Parameter(typeof(IFormatterResolver), "formatterResolver");
						MethodInfo runtimeMethod = type2.GetRuntimeMethod("Serialize", new Type[4]
						{
							typeof(byte[]).MakeByRefType(),
							typeof(int),
							type,
							typeof(IFormatterResolver)
						});
						SerializeMethod value4 = Expression.Lambda<SerializeMethod>(Expression.Call(Expression.Convert(parameterExpression, type2), runtimeMethod, parameterExpression2, parameterExpression3, typeInfo.IsValueType ? Expression.Unbox(parameterExpression4, type) : Expression.Convert(parameterExpression4, type), parameterExpression5), new ParameterExpression[5] { parameterExpression, parameterExpression2, parameterExpression3, parameterExpression4, parameterExpression5 }).Compile();
						value3 = new KeyValuePair<object, SerializeMethod>(formatterDynamic, value4);
						serializers.TryAdd(type, value3);
					}
				}
			}
			int num = offset;
			offset += 6;
			offset += MessagePackBinary.WriteStringBytes(ref bytes, offset, value2);
			offset += value3.Value(value3.Key, ref bytes, offset, value, formatterResolver);
			MessagePackBinary.WriteExtensionFormatHeaderForceExt32Block(ref bytes, num, 100, offset - num - 6);
			return offset - num;
		}

		public object Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			int num = offset;
			if (MessagePackBinary.GetMessagePackType(bytes, offset) == MessagePackType.Extension && MessagePackBinary.ReadExtensionFormatHeader(bytes, offset, out readSize).TypeCode == 100)
			{
				offset += readSize;
				ArraySegment<byte> typeName = MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
				offset += readSize;
				object result = DeserializeByTypeName(typeName, bytes, offset, formatterResolver, out readSize);
				offset += readSize;
				readSize = offset - num;
				return result;
			}
			return TypelessFormatterFallbackResolver.Instance.GetFormatter<object>().Deserialize(bytes, num, formatterResolver, out readSize);
		}

		private object DeserializeByTypeName(ArraySegment<byte> typeName, byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (!typeCache.TryGetValue(typeName, out var value))
			{
				byte[] array = new byte[typeName.Count];
				Buffer.BlockCopy(typeName.Array, typeName.Offset, array, 0, array.Length);
				string text = StringEncoding.UTF8.GetString(array);
				value = BindToType(text);
				if (value == null)
				{
					if (isMscorlib && text.Contains("System.Private.CoreLib"))
					{
						text = text.Replace("System.Private.CoreLib", "mscorlib");
						value = Type.GetType(text, throwOnError: true);
					}
					else if (!isMscorlib && text.Contains("mscorlib"))
					{
						text = text.Replace("mscorlib", "System.Private.CoreLib");
						value = Type.GetType(text, throwOnError: true);
					}
					else
					{
						value = Type.GetType(text, throwOnError: true);
					}
				}
				typeCache.TryAdd(array, value);
			}
			if (!deserializers.TryGetValue(value, out var value2))
			{
				lock (deserializers)
				{
					if (!deserializers.TryGetValue(value, out value2))
					{
						TypeInfo typeInfo = value.GetTypeInfo();
						object formatterDynamic = formatterResolver.GetFormatterDynamic(value);
						if (formatterDynamic == null)
						{
							throw new FormatterNotRegisteredException(value.FullName + " is not registered in this resolver. resolver:" + formatterResolver.GetType().Name);
						}
						Type type = typeof(IMessagePackFormatter<>).MakeGenericType(value);
						ParameterExpression parameterExpression = Expression.Parameter(typeof(object), "formatter");
						ParameterExpression parameterExpression2 = Expression.Parameter(typeof(byte[]), "bytes");
						ParameterExpression parameterExpression3 = Expression.Parameter(typeof(int), "offset");
						ParameterExpression parameterExpression4 = Expression.Parameter(typeof(IFormatterResolver), "formatterResolver");
						ParameterExpression parameterExpression5 = Expression.Parameter(typeof(int).MakeByRefType(), "readSize");
						MethodInfo runtimeMethod = type.GetRuntimeMethod("Deserialize", new Type[4]
						{
							typeof(byte[]),
							typeof(int),
							typeof(IFormatterResolver),
							typeof(int).MakeByRefType()
						});
						MethodCallExpression methodCallExpression = Expression.Call(Expression.Convert(parameterExpression, type), runtimeMethod, parameterExpression2, parameterExpression3, parameterExpression4, parameterExpression5);
						Expression body = methodCallExpression;
						if (typeInfo.IsValueType)
						{
							body = Expression.Convert(methodCallExpression, typeof(object));
						}
						DeserializeMethod value3 = Expression.Lambda<DeserializeMethod>(body, new ParameterExpression[5] { parameterExpression, parameterExpression2, parameterExpression3, parameterExpression4, parameterExpression5 }).Compile();
						value2 = new KeyValuePair<object, DeserializeMethod>(formatterDynamic, value3);
						deserializers.TryAdd(value, value2);
					}
				}
			}
			return value2.Value(value2.Key, bytes, offset, formatterResolver, out readSize);
		}
	}
}
