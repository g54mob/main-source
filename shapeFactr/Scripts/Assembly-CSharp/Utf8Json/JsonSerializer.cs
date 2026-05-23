using System;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using Utf8Json.Internal;

namespace Utf8Json
{
	public static class JsonSerializer
	{
		private static class MemoryPool
		{
			[ThreadStatic]
			private static byte[] buffer;

			public static byte[] GetBuffer()
			{
				return null;
			}
		}

		public static class NonGeneric
		{
			private delegate void SerializeJsonWriter(ref JsonWriter writer, object value, IJsonFormatterResolver resolver);

			private delegate object DeserializeJsonReader(ref JsonReader reader, IJsonFormatterResolver resolver);

			private class CompiledMethods
			{
				public readonly Func<object, IJsonFormatterResolver, byte[]> serialize1;

				public readonly Action<Stream, object, IJsonFormatterResolver> serialize2;

				public readonly SerializeJsonWriter serialize3;

				public readonly Func<object, IJsonFormatterResolver, ArraySegment<byte>> serializeUnsafe;

				public readonly Func<object, IJsonFormatterResolver, string> toJsonString;

				public readonly Func<string, IJsonFormatterResolver, object> deserialize1;

				public readonly Func<byte[], int, IJsonFormatterResolver, object> deserialize2;

				public readonly Func<Stream, IJsonFormatterResolver, object> deserialize3;

				public readonly DeserializeJsonReader deserialize4;

				public CompiledMethods(Type type)
				{
				}

				private static T CreateDelegate<T>(DynamicMethod dm)
				{
					return default(T);
				}

				private static MethodInfo GetMethod(Type type, string name, Type[] arguments)
				{
					return null;
				}
			}

			private static readonly Func<Type, CompiledMethods> CreateCompiledMethods;

			private static readonly ThreadsafeTypeKeyHashTable<CompiledMethods> serializes;

			static NonGeneric()
			{
			}

			private static CompiledMethods GetOrAdd(Type type)
			{
				return null;
			}

			public static byte[] Serialize(object value)
			{
				return null;
			}

			public static byte[] Serialize(Type type, object value)
			{
				return null;
			}

			public static byte[] Serialize(object value, IJsonFormatterResolver resolver)
			{
				return null;
			}

			public static byte[] Serialize(Type type, object value, IJsonFormatterResolver resolver)
			{
				return null;
			}

			public static void Serialize(Stream stream, object value)
			{
			}

			public static void Serialize(Type type, Stream stream, object value)
			{
			}

			public static void Serialize(Stream stream, object value, IJsonFormatterResolver resolver)
			{
			}

			public static void Serialize(Type type, Stream stream, object value, IJsonFormatterResolver resolver)
			{
			}

			public static void Serialize(ref JsonWriter writer, object value, IJsonFormatterResolver resolver)
			{
			}

			public static void Serialize(Type type, ref JsonWriter writer, object value)
			{
			}

			public static void Serialize(Type type, ref JsonWriter writer, object value, IJsonFormatterResolver resolver)
			{
			}

			public static ArraySegment<byte> SerializeUnsafe(object value)
			{
				return default(ArraySegment<byte>);
			}

			public static ArraySegment<byte> SerializeUnsafe(Type type, object value)
			{
				return default(ArraySegment<byte>);
			}

			public static ArraySegment<byte> SerializeUnsafe(object value, IJsonFormatterResolver resolver)
			{
				return default(ArraySegment<byte>);
			}

			public static ArraySegment<byte> SerializeUnsafe(Type type, object value, IJsonFormatterResolver resolver)
			{
				return default(ArraySegment<byte>);
			}

			public static string ToJsonString(object value)
			{
				return null;
			}

			public static string ToJsonString(Type type, object value)
			{
				return null;
			}

			public static string ToJsonString(object value, IJsonFormatterResolver resolver)
			{
				return null;
			}

			public static string ToJsonString(Type type, object value, IJsonFormatterResolver resolver)
			{
				return null;
			}

			public static object Deserialize(Type type, string json)
			{
				return null;
			}

			public static object Deserialize(Type type, string json, IJsonFormatterResolver resolver)
			{
				return null;
			}

			public static object Deserialize(Type type, byte[] bytes)
			{
				return null;
			}

			public static object Deserialize(Type type, byte[] bytes, IJsonFormatterResolver resolver)
			{
				return null;
			}

			public static object Deserialize(Type type, byte[] bytes, int offset)
			{
				return null;
			}

			public static object Deserialize(Type type, byte[] bytes, int offset, IJsonFormatterResolver resolver)
			{
				return null;
			}

			public static object Deserialize(Type type, Stream stream)
			{
				return null;
			}

			public static object Deserialize(Type type, Stream stream, IJsonFormatterResolver resolver)
			{
				return null;
			}

			public static object Deserialize(Type type, ref JsonReader reader)
			{
				return null;
			}

			public static object Deserialize(Type type, ref JsonReader reader, IJsonFormatterResolver resolver)
			{
				return null;
			}
		}

		private static IJsonFormatterResolver defaultResolver;

		private static readonly byte[][] indent;

		private static readonly byte[] newLine;

		public static IJsonFormatterResolver DefaultResolver => null;

		public static bool IsInitialized => false;

		public static void SetDefaultResolver(IJsonFormatterResolver resolver)
		{
		}

		public static byte[] Serialize<T>(T obj)
		{
			return null;
		}

		public static byte[] Serialize<T>(T value, IJsonFormatterResolver resolver)
		{
			return null;
		}

		public static void Serialize<T>(ref JsonWriter writer, T value)
		{
		}

		public static void Serialize<T>(ref JsonWriter writer, T value, IJsonFormatterResolver resolver)
		{
		}

		public static void Serialize<T>(Stream stream, T value)
		{
		}

		public static void Serialize<T>(Stream stream, T value, IJsonFormatterResolver resolver)
		{
		}

		public static ArraySegment<byte> SerializeUnsafe<T>(T obj)
		{
			return default(ArraySegment<byte>);
		}

		public static ArraySegment<byte> SerializeUnsafe<T>(T value, IJsonFormatterResolver resolver)
		{
			return default(ArraySegment<byte>);
		}

		public static string ToJsonString<T>(T value)
		{
			return null;
		}

		public static string ToJsonString<T>(T value, IJsonFormatterResolver resolver)
		{
			return null;
		}

		public static T Deserialize<T>(string json)
		{
			return default(T);
		}

		public static T Deserialize<T>(string json, IJsonFormatterResolver resolver)
		{
			return default(T);
		}

		public static T Deserialize<T>(byte[] bytes)
		{
			return default(T);
		}

		public static T Deserialize<T>(byte[] bytes, IJsonFormatterResolver resolver)
		{
			return default(T);
		}

		public static T Deserialize<T>(byte[] bytes, int offset)
		{
			return default(T);
		}

		public static T Deserialize<T>(byte[] bytes, int offset, IJsonFormatterResolver resolver)
		{
			return default(T);
		}

		public static T Deserialize<T>(ref JsonReader reader)
		{
			return default(T);
		}

		public static T Deserialize<T>(ref JsonReader reader, IJsonFormatterResolver resolver)
		{
			return default(T);
		}

		public static T Deserialize<T>(Stream stream)
		{
			return default(T);
		}

		public static T Deserialize<T>(Stream stream, IJsonFormatterResolver resolver)
		{
			return default(T);
		}

		public static string PrettyPrint(byte[] json)
		{
			return null;
		}

		public static string PrettyPrint(byte[] json, int offset)
		{
			return null;
		}

		public static string PrettyPrint(string json)
		{
			return null;
		}

		public static byte[] PrettyPrintByteArray(byte[] json)
		{
			return null;
		}

		public static byte[] PrettyPrintByteArray(byte[] json, int offset)
		{
			return null;
		}

		public static byte[] PrettyPrintByteArray(string json)
		{
			return null;
		}

		private static void WritePrittyPrint(ref JsonReader reader, ref JsonWriter writer, int depth)
		{
		}

		private static int FillFromStream(Stream input, ref byte[] buffer)
		{
			return 0;
		}
	}
}
