using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using ProtoBuf.Internal;
using ProtoBuf.Meta;

namespace ProtoBuf
{
	public static class Serializer
	{
		public static class NonGeneric
		{
			public static object DeepClone(object instance)
			{
				if (instance != null)
				{
					return RuntimeTypeModel.Default.DeepClone(instance);
				}
				return null;
			}

			public static void Serialize(Stream dest, object instance)
			{
				if (instance != null)
				{
					ProtoWriter.State state = ProtoWriter.State.Create(dest, RuntimeTypeModel.Default);
					try
					{
						state.Model.SerializeRootFallback(ref state, instance);
					}
					finally
					{
						state.Dispose();
					}
				}
			}

			public static object Deserialize([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type, Stream source)
			{
				return RuntimeTypeModel.Default.Deserialize(type, source, null, null, -1L);
			}

			public static object Deserialize([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type, Stream source, object instance = null, object userState = null, long length = -1L)
			{
				return RuntimeTypeModel.Default.Deserialize(type, source, instance, userState, length);
			}

			public static object Deserialize([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type, ReadOnlyMemory<byte> source, object instance = null, object userState = null)
			{
				return RuntimeTypeModel.Default.Deserialize(type, source, instance, userState);
			}

			public static object Deserialize([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type, ReadOnlySequence<byte> source, object instance = null, object userState = null)
			{
				return RuntimeTypeModel.Default.Deserialize(type, source, instance, userState);
			}

			public static object Deserialize([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type, ReadOnlySpan<byte> source, object instance = null, object userState = null)
			{
				return RuntimeTypeModel.Default.Deserialize(type, source, instance, userState);
			}

			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public static object Merge(Stream source, object instance)
			{
				if (instance == null)
				{
					throw new ArgumentNullException("instance");
				}
				using ProtoReader.State state = ProtoReader.State.Create(source, RuntimeTypeModel.Default, null, -1L);
				return state.DeserializeRootFallback(instance, instance.GetType());
			}

			public static void SerializeWithLengthPrefix(Stream destination, object instance, PrefixStyle style, int fieldNumber)
			{
				if (instance == null)
				{
					throw new ArgumentNullException("instance");
				}
				RuntimeTypeModel.Default.SerializeWithLengthPrefix(destination, instance, instance.GetType(), style, fieldNumber);
			}

			public static bool TryDeserializeWithLengthPrefix(Stream source, PrefixStyle style, ProtoBuf.TypeResolver resolver, out object value)
			{
				value = RuntimeTypeModel.Default.DeserializeWithLengthPrefix(source, null, null, style, 0, resolver);
				return value != null;
			}

			public static bool CanSerialize(Type type)
			{
				return RuntimeTypeModel.Default.IsDefined(type);
			}

			public static void PrepareSerializer([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type)
			{
				RuntimeTypeModel.Default[type].CompileInPlace();
			}
		}

		public static class GlobalOptions
		{
			private static ProtoSyntax _defaultSyntax = ProtoSyntax.Proto3;

			[Obsolete("Please use RuntimeTypeModel.Default.InferTagFromNameDefault instead (or on a per-model basis)", false)]
			public static bool InferTagFromName
			{
				get
				{
					return RuntimeTypeModel.Default.InferTagFromNameDefault;
				}
				set
				{
					RuntimeTypeModel.Default.InferTagFromNameDefault = value;
				}
			}

			public static ProtoSyntax DefaultSyntax
			{
				get
				{
					return _defaultSyntax;
				}
				set
				{
					if ((uint)value <= 1u)
					{
						_defaultSyntax = value;
					}
					else
					{
						ThrowHelper.ThrowArgumentOutOfRangeException("DefaultSyntax");
					}
				}
			}

			internal static ProtoSyntax Normalize(ProtoSyntax syntax)
			{
				return syntax switch
				{
					ProtoSyntax.Proto2 => syntax, 
					ProtoSyntax.Proto3 => syntax, 
					_ => DefaultSyntax, 
				};
			}
		}

		[Obsolete("Please use ProtoBuf.TypeResolver", true)]
		public delegate Type TypeResolver(int fieldNumber);

		private const string ProtoBinaryField = "proto";

		public const int ListItemTag = 1;

		public static string GetProto<T>()
		{
			return RuntimeTypeModel.Default.GetSchema(typeof(T), ProtoSyntax.Default);
		}

		public static string GetProto<T>(ProtoSyntax syntax)
		{
			return RuntimeTypeModel.Default.GetSchema(typeof(T), syntax);
		}

		public static string GetProto(SchemaGenerationOptions options)
		{
			return RuntimeTypeModel.Default.GetSchema(options);
		}

		public static T DeepClone<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(T instance, SerializationContext context)
		{
			return RuntimeTypeModel.Default.DeepClone(instance, context);
		}

		public static T DeepClone<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(T instance, object userState = null)
		{
			return RuntimeTypeModel.Default.DeepClone(instance, userState);
		}

		public static MeasureState<T> Measure<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(T value, object userState = null, long abortAfter = -1L)
		{
			return RuntimeTypeModel.Default.Measure(value, userState, abortAfter);
		}

		public static T Merge<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(Stream source, T instance)
		{
			using ProtoReader.State state = ProtoReader.State.Create(source, RuntimeTypeModel.Default, null, -1L);
			return state.DeserializeRootImpl(instance);
		}

		public static TTo ChangeType<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] TFrom, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] TTo>(TFrom instance)
		{
			using MemoryStream memoryStream = new MemoryStream();
			Serialize(memoryStream, instance);
			memoryStream.Position = 0L;
			return Deserialize<TTo>(memoryStream);
		}

		public static void Merge<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(XmlReader reader, T instance) where T : IXmlSerializable
		{
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			byte[] buffer = new byte[4096];
			using MemoryStream memoryStream = new MemoryStream();
			int depth = reader.Depth;
			while (reader.Read() && reader.Depth > depth)
			{
				if (reader.NodeType == XmlNodeType.Text)
				{
					int count;
					while ((count = reader.ReadContentAsBase64(buffer, 0, 4096)) > 0)
					{
						memoryStream.Write(buffer, 0, count);
					}
					if (reader.Depth <= depth)
					{
						break;
					}
				}
			}
			memoryStream.Position = 0L;
			Merge(memoryStream, instance);
		}

		public static void Merge<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(SerializationInfo info, T instance) where T : class, ISerializable
		{
			Merge(info, new StreamingContext(StreamingContextStates.Persistence), instance);
		}

		public static void Merge<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(SerializationInfo info, StreamingContext context, T instance) where T : class, ISerializable
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			if (instance.GetType() != typeof(T))
			{
				throw new ArgumentException("Incorrect type", "instance");
			}
			byte[] buffer = (byte[])info.GetValue("proto", typeof(byte[]));
			using MemoryStream source = new MemoryStream(buffer);
			T val = RuntimeTypeModel.Default.Deserialize(source, instance, context.Context);
			if (val != instance)
			{
				throw new ProtoException("Deserialization changed the instance; cannot succeed.");
			}
		}

		public static void PrepareSerializer<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>()
		{
			RuntimeTypeModel.Default[typeof(T)].CompileInPlace();
		}

		public static IFormatter CreateFormatter<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>()
		{
			return RuntimeTypeModel.Default.CreateFormatter(typeof(T));
		}

		public static IEnumerable<T> DeserializeItems<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(Stream source, PrefixStyle style, int fieldNumber)
		{
			return RuntimeTypeModel.Default.DeserializeItems<T>(source, style, fieldNumber);
		}

		public static T DeserializeWithLengthPrefix<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(Stream source, PrefixStyle style)
		{
			return DeserializeWithLengthPrefix<T>(source, style, 0);
		}

		public static T DeserializeWithLengthPrefix<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(Stream source, PrefixStyle style, int fieldNumber)
		{
			return (T)RuntimeTypeModel.Default.DeserializeWithLengthPrefix(source, null, typeof(T), style, fieldNumber);
		}

		public static T MergeWithLengthPrefix<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(Stream source, T instance, PrefixStyle style)
		{
			return (T)RuntimeTypeModel.Default.DeserializeWithLengthPrefix(source, instance, typeof(T), style, 0);
		}

		public static bool TryReadLengthPrefix(Stream source, PrefixStyle style, out int length)
		{
			length = ProtoReader.ReadLengthPrefix(source, expectHeader: false, style, out var _, out var bytesRead);
			return bytesRead > 0;
		}

		public static bool TryReadLengthPrefix(byte[] buffer, int index, int count, PrefixStyle style, out int length)
		{
			using Stream source = new MemoryStream(buffer, index, count);
			return TryReadLengthPrefix(source, style, out length);
		}

		[Obsolete]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void FlushPool()
		{
		}

		public static T Deserialize<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(Stream source)
		{
			using ProtoReader.State state = ProtoReader.State.Create(source, RuntimeTypeModel.Default, null, -1L);
			return state.DeserializeRootImpl<T>();
		}

		public static T Deserialize<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(Stream source, T value, SerializationContext context, long length = -1L)
		{
			using ProtoReader.State state = ProtoReader.State.Create(source, RuntimeTypeModel.Default, context, length);
			return state.DeserializeRootImpl(value);
		}

		public static T Deserialize<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(Stream source, T value = default(T), object userState = null, long length = -1L)
		{
			using ProtoReader.State state = ProtoReader.State.Create(source, RuntimeTypeModel.Default, userState, length);
			return state.DeserializeRootImpl(value);
		}

		public static object Deserialize([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type, Stream source)
		{
			using ProtoReader.State state = ProtoReader.State.Create(source, RuntimeTypeModel.Default, null, -1L);
			return state.DeserializeRootFallback(null, type);
		}

		public static T Deserialize<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(ReadOnlyMemory<byte> source, T value = default(T), object userState = null)
		{
			return RuntimeTypeModel.Default.Deserialize(source, value, userState);
		}

		public static T Deserialize<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(ReadOnlySequence<byte> source, T value = default(T), object userState = null)
		{
			return RuntimeTypeModel.Default.Deserialize(source, value, userState);
		}

		public static T Deserialize<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(ReadOnlySpan<byte> source, T value = default(T), object userState = null)
		{
			return RuntimeTypeModel.Default.Deserialize(source, value, userState);
		}

		public static void Serialize<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(Stream destination, T instance)
		{
			Serialize(destination, instance, null);
		}

		public static void Serialize<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(Stream destination, T instance, object userState)
		{
			ProtoWriter.State state = ProtoWriter.State.Create(destination, RuntimeTypeModel.Default, userState);
			try
			{
				TypeModel.SerializeImpl(ref state, instance);
			}
			finally
			{
				state.Dispose();
			}
		}

		public static void Serialize<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(IBufferWriter<byte> destination, T instance, object userState = null)
		{
			ProtoWriter.State state = ProtoWriter.State.Create(destination, RuntimeTypeModel.Default, userState);
			try
			{
				TypeModel.SerializeImpl(ref state, instance);
			}
			finally
			{
				state.Dispose();
			}
		}

		public static void Serialize<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(SerializationInfo info, T instance) where T : class, ISerializable
		{
			Serialize(info, new StreamingContext(StreamingContextStates.Persistence), instance);
		}

		public static void Serialize<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(SerializationInfo info, StreamingContext context, T instance) where T : class, ISerializable
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			if (instance.GetType() != typeof(T))
			{
				throw new ArgumentException("Incorrect type", "instance");
			}
			using MemoryStream memoryStream = new MemoryStream();
			RuntimeTypeModel.Default.Serialize(memoryStream, instance, context.Context);
			info.AddValue("proto", memoryStream.ToArray());
		}

		public static void Serialize<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(XmlWriter writer, T instance) where T : IXmlSerializable
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			using MemoryStream memoryStream = new MemoryStream();
			Serialize(memoryStream, instance);
			Helpers.GetBuffer(memoryStream, out var segment);
			writer.WriteBase64(segment.Array, segment.Offset, segment.Count);
		}

		public static void SerializeWithLengthPrefix<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(Stream destination, T instance, PrefixStyle style)
		{
			SerializeWithLengthPrefix(destination, instance, style, 0);
		}

		public static void SerializeWithLengthPrefix<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(Stream destination, T instance, PrefixStyle style, int fieldNumber)
		{
			RuntimeTypeModel.Default.SerializeWithLengthPrefix(destination, instance, typeof(T), style, fieldNumber);
		}
	}
}
