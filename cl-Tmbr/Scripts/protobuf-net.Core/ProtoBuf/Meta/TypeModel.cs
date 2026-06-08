using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;
using ProtoBuf.Internal;
using ProtoBuf.Serializers;

namespace ProtoBuf.Meta
{
	public abstract class TypeModel : IProtoInput<Stream>, IProtoInput<ArraySegment<byte>>, IProtoInput<byte[]>, IProtoInput<ReadOnlyMemory<byte>>, IProtoInput<ReadOnlySequence<byte>>, IProtoOutput<Stream>, IProtoOutput<IBufferWriter<byte>>, IMeasuredProtoOutput<Stream>, IMeasuredProtoOutput<IBufferWriter<byte>>
	{
		[Flags]
		public enum TypeModelOptions
		{
			None = 0,
			InternStrings = 1,
			IncludeDateTimeKind = 2,
			SkipZeroLengthPackedArrays = 4,
			AllowPackedEncodingAtRoot = 8
		}

		private sealed class DeserializeItemsIterator<T> : DeserializeItemsIterator, IEnumerator<T>, IEnumerator, IDisposable, IEnumerable<T>, IEnumerable
		{
			public new T Current => (T)base.Current;

			IEnumerator<T> IEnumerable<T>.GetEnumerator()
			{
				return this;
			}

			void IDisposable.Dispose()
			{
			}

			public DeserializeItemsIterator(TypeModel model, Stream source, PrefixStyle style, int expectedField, SerializationContext context)
				: base(model, source, typeof(T), style, expectedField, null, context)
			{
			}
		}

		private class DeserializeItemsIterator : IEnumerator, IEnumerable
		{
			private bool haveObject;

			private object current;

			private readonly Stream source;

			private readonly Type type;

			private readonly PrefixStyle style;

			private readonly int expectedField;

			private readonly TypeResolver resolver;

			private readonly TypeModel model;

			private readonly SerializationContext context;

			public object Current => current;

			IEnumerator IEnumerable.GetEnumerator()
			{
				return this;
			}

			public bool MoveNext()
			{
				if (haveObject)
				{
					current = model.DeserializeWithLengthPrefix(source, null, type, style, expectedField, resolver, out var _, out haveObject, context);
				}
				return haveObject;
			}

			void IEnumerator.Reset()
			{
				ThrowHelper.ThrowNotSupportedException();
			}

			public DeserializeItemsIterator(TypeModel model, Stream source, Type type, PrefixStyle style, int expectedField, TypeResolver resolver, SerializationContext context)
			{
				haveObject = true;
				this.source = source;
				this.type = type;
				this.style = style;
				this.expectedField = expectedField;
				this.resolver = resolver;
				this.model = model;
				this.context = context;
			}
		}

		internal sealed class NullModel : TypeModel
		{
			private static readonly NullModel s_Singleton = new NullModel();

			public static TypeModel Singleton
			{
				[MethodImpl(MethodImplOptions.NoInlining)]
				get
				{
					return s_Singleton;
				}
			}

			private NullModel()
			{
			}

			protected override ISerializer<T> GetSerializer<T>()
			{
				return null;
			}
		}

		protected internal enum CallbackType
		{
			BeforeSerialize = 0,
			AfterSerialize = 1,
			BeforeDeserialize = 2,
			AfterDeserialize = 3
		}

		internal sealed class Formatter : IFormatter
		{
			private readonly TypeModel model;

			private readonly Type type;

			public SerializationBinder Binder { get; set; }

			public StreamingContext Context { get; set; }

			public ISurrogateSelector SurrogateSelector { get; set; }

			internal Formatter(TypeModel model, Type type)
			{
				if (model == null)
				{
					ThrowHelper.ThrowArgumentNullException("model");
				}
				if ((object)type == null)
				{
					ThrowHelper.ThrowArgumentNullException("model");
				}
				this.model = model;
				this.type = type;
			}

			public object Deserialize(Stream serializationStream)
			{
				using ProtoReader.State state = ProtoReader.State.Create(serializationStream, model, Context, -1L);
				return state.DeserializeRootFallback(null, type);
			}

			public void Serialize(Stream serializationStream, object graph)
			{
				ProtoWriter.State state = ProtoWriter.State.Create(serializationStream, model, Context);
				try
				{
					model.SerializeRootFallback(ref state, graph);
				}
				finally
				{
					state.Dispose();
				}
			}
		}

		private int _bufferSize = 1024;

		private int _maxDepth = 512;

		internal const int DefaultMaxDepth = 512;

		internal const TypeModelOptions DefaultOptions = TypeModelOptions.None;

		internal const SerializerFeatures FromAux = (SerializerFeatures)1073741824;

		private static TypeModel s_defaultModel;

		public const int ListItemTag = 1;

		public int BufferSize
		{
			get
			{
				return _bufferSize;
			}
			set
			{
				_bufferSize = ((value <= 0) ? 1024 : value);
			}
		}

		public int MaxDepth
		{
			get
			{
				return _maxDepth;
			}
			set
			{
				_maxDepth = ((value <= 0) ? 512 : value);
			}
		}

		public virtual TypeModelOptions Options => TypeModelOptions.None;

		internal static TypeModel DefaultModel => s_defaultModel ?? SetDefaultModel(null);

		public event TypeFormatEventHandler DynamicTypeFormatting;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected static ISerializer<T> GetSerializer<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicMethods)] TProvider, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>() where TProvider : class
		{
			return SerializerCache<TProvider, T>.InstanceField;
		}

		[Obsolete("This API is no longer required and may be removed in a future release")]
		protected internal Type MapType(Type type)
		{
			return type;
		}

		[Obsolete("This API is no longer required and may be removed in a future release")]
		protected internal Type MapType(Type type, bool demand)
		{
			return type;
		}

		internal static WireType GetWireType(TypeModel model, DataFormat format, Type type)
		{
			if (type.IsEnum)
			{
				return WireType.Variant;
			}
			if (model != null && model.CanSerializeContractType(type))
			{
				if (format != DataFormat.Group)
				{
					return WireType.String;
				}
				return WireType.StartGroup;
			}
			switch (Helpers.GetTypeCode(type))
			{
			case ProtoTypeCode.Int64:
			case ProtoTypeCode.UInt64:
				if (format != DataFormat.FixedSize)
				{
					return WireType.Variant;
				}
				return WireType.Fixed64;
			case ProtoTypeCode.Boolean:
			case ProtoTypeCode.Char:
			case ProtoTypeCode.SByte:
			case ProtoTypeCode.Byte:
			case ProtoTypeCode.Int16:
			case ProtoTypeCode.UInt16:
			case ProtoTypeCode.Int32:
			case ProtoTypeCode.UInt32:
				if (format != DataFormat.FixedSize)
				{
					return WireType.Variant;
				}
				return WireType.Fixed32;
			case ProtoTypeCode.Double:
				return WireType.Fixed64;
			case ProtoTypeCode.Single:
				return WireType.Fixed32;
			case ProtoTypeCode.Decimal:
			case ProtoTypeCode.DateTime:
			case ProtoTypeCode.String:
			case ProtoTypeCode.TimeSpan:
			case ProtoTypeCode.ByteArray:
			case ProtoTypeCode.Guid:
			case ProtoTypeCode.Uri:
			case ProtoTypeCode.ByteArraySegment:
			case ProtoTypeCode.ByteMemory:
			case ProtoTypeCode.ByteReadOnlyMemory:
				return WireType.String;
			default:
				return WireType.None;
			}
		}

		internal virtual bool IsKnownType<T>(CompatibilityLevel ambient)
		{
			if (TypeHelper<T>.IsReferenceType | !TypeHelper<T>.CanBeNull)
			{
				return GetSerializerCore<T>(ambient) != null;
			}
			return false;
		}

		internal bool TrySerializeAuxiliaryType(ref ProtoWriter.State state, Type type, DataFormat format, int tag, object value, bool isInsideList, object parentList, bool isRoot)
		{
			PrepareDeserialize(value, ref type);
			WireType wireType = GetWireType(this, format, type);
			if (DynamicStub.CanSerialize(type, this, out var features))
			{
				ObjectScope objectScope = NormalizeAuxScope(features, isInsideList, type, isRoot);
				try
				{
					if (!DynamicStub.TrySerializeAny(tag, wireType.AsFeatures() | (SerializerFeatures)1073741824, type, this, ref state, value))
					{
						ThrowUnexpectedType(type, this);
					}
				}
				catch (Exception ex)
				{
					ThrowHelper.ThrowProtoException(ex.Message + $"; scope: {objectScope}, features: {features}; type: {type.NormalizeName()}", ex);
				}
				return true;
			}
			if (value is IEnumerable enumerable)
			{
				if (isInsideList)
				{
					ThrowNestedListsNotSupported(parentList?.GetType());
				}
				foreach (object item in enumerable)
				{
					if (item == null)
					{
						ThrowHelper.ThrowNullReferenceException();
					}
					if (!TrySerializeAuxiliaryType(ref state, null, format, tag, item, isInsideList: true, enumerable, isRoot))
					{
						ThrowUnexpectedType(item.GetType(), this);
					}
				}
				return true;
			}
			return false;
		}

		private static ObjectScope NormalizeAuxScope(SerializerFeatures features, bool isInsideList, Type type, bool isRoot)
		{
			switch (features.GetCategory())
			{
			case SerializerFeatures.CategoryRepeated:
				if (isInsideList)
				{
					ThrowNestedListsNotSupported(type);
				}
				ThrowHelper.ThrowNotSupportedException("A repeated type was not expected as an aux type: " + type.NormalizeName());
				return ObjectScope.NakedMessage;
			case SerializerFeatures.CategoryMessage:
				return ObjectScope.WrappedMessage;
			case SerializerFeatures.CategoryMessageWrappedAtRoot:
				if (!(isInsideList || isRoot))
				{
					return ObjectScope.LikeRoot;
				}
				return ObjectScope.WrappedMessage;
			case SerializerFeatures.CategoryScalar:
				return ObjectScope.Scalar;
			default:
				features.ThrowInvalidCategory();
				return ObjectScope.Invalid;
			}
		}

		public void Serialize(Stream dest, object value)
		{
			ProtoWriter.State state = ProtoWriter.State.Create(dest, this);
			try
			{
				SerializeRootFallback(ref state, value);
			}
			finally
			{
				state.Dispose();
			}
		}

		public void Serialize(Stream dest, object value, SerializationContext context)
		{
			ProtoWriter.State state = ProtoWriter.State.Create(dest, this, context);
			try
			{
				SerializeRootFallback(ref state, value);
			}
			finally
			{
				state.Dispose();
			}
		}

		public void Serialize(IBufferWriter<byte> dest, object value, object userState = null)
		{
			ProtoWriter.State state = ProtoWriter.State.Create(dest, this, userState);
			try
			{
				SerializeRootFallback(ref state, value);
			}
			finally
			{
				state.Dispose();
			}
		}

		internal void SerializeRootFallback(ref ProtoWriter.State state, object value)
		{
			Type type = value.GetType();
			try
			{
				if (!DynamicStub.TrySerializeRoot(type, this, ref state, value))
				{
					if (!TrySerializeAuxiliaryType(ref state, type, DataFormat.Default, 1, value, isInsideList: false, null, isRoot: true))
					{
						ThrowUnexpectedType(type, this);
					}
					state.Close();
				}
			}
			catch
			{
				state.Abandon();
				throw;
			}
		}

		public long Serialize<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(Stream dest, T value, object userState = null)
		{
			ProtoWriter.State state = ProtoWriter.State.Create(dest, this, userState);
			try
			{
				return SerializeImpl(ref state, value);
			}
			finally
			{
				state.Dispose();
			}
		}

		public long Serialize<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(IBufferWriter<byte> dest, T value, object userState = null)
		{
			ProtoWriter.State state = ProtoWriter.State.Create(dest, this, userState);
			try
			{
				return SerializeImpl(ref state, value);
			}
			finally
			{
				state.Dispose();
			}
		}

		public MeasureState<T> Measure<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(T value, object userState = null, long abortAfter = -1L)
		{
			return new MeasureState<T>(this, in value, userState, abortAfter);
		}

		[Obsolete("If possible, please use the State API; a transitionary implementation is provided, but this API may be removed in a future version", false)]
		public void Serialize(ProtoWriter dest, object value)
		{
			ProtoWriter.State state = dest.DefaultState();
			SerializeRootFallback(ref state, value);
		}

		internal static long SerializeImpl<T>(ref ProtoWriter.State state, T value)
		{
			if (TypeHelper<T>.CanBeNull && TypeHelper<T>.ValueChecker.IsNull(value))
			{
				return 0L;
			}
			ISerializer<T> serializer = TryGetSerializer<T>(state.Model);
			if (serializer == null)
			{
				long position = state.GetPosition();
				state.Model.SerializeRootFallback(ref state, value);
				return state.GetPosition() - position;
			}
			return state.SerializeRoot(value, serializer);
		}

		public object DeserializeWithLengthPrefix(Stream source, object value, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type, PrefixStyle style, int fieldNumber)
		{
			long bytesRead;
			return DeserializeWithLengthPrefix(source, value, type, style, fieldNumber, (TypeResolver)null, out bytesRead);
		}

		public object DeserializeWithLengthPrefix(Stream source, object value, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type, PrefixStyle style, int expectedField, TypeResolver resolver)
		{
			long bytesRead;
			return DeserializeWithLengthPrefix(source, value, type, style, expectedField, resolver, out bytesRead);
		}

		public object DeserializeWithLengthPrefix(Stream source, object value, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type, PrefixStyle style, int expectedField, TypeResolver resolver, out int bytesRead)
		{
			long bytesRead2;
			bool haveObject;
			object result = DeserializeWithLengthPrefix(source, value, type, style, expectedField, resolver, out bytesRead2, out haveObject, null);
			bytesRead = checked((int)bytesRead2);
			return result;
		}

		public object DeserializeWithLengthPrefix(Stream source, object value, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type, PrefixStyle style, int expectedField, TypeResolver resolver, out long bytesRead)
		{
			bool haveObject;
			return DeserializeWithLengthPrefix(source, value, type, style, expectedField, resolver, out bytesRead, out haveObject, null);
		}

		private object DeserializeWithLengthPrefix(Stream source, object value, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type, PrefixStyle style, int expectedField, TypeResolver resolver, out long bytesRead, out bool haveObject, SerializationContext context)
		{
			haveObject = false;
			bytesRead = 0L;
			if ((object)type == null && (style != PrefixStyle.Base128 || resolver == null))
			{
				ThrowHelper.ThrowInvalidOperationException("A type must be provided unless base-128 prefixing is being used in combination with a resolver");
			}
			long num;
			bool flag2;
			do
			{
				bool flag = expectedField > 0 || resolver != null;
				num = ProtoReader.ReadLongLengthPrefix(source, flag, style, out var fieldNumber, out var bytesRead2);
				if (bytesRead2 == 0)
				{
					return value;
				}
				bytesRead += bytesRead2;
				if (num < 0)
				{
					return value;
				}
				if (style == PrefixStyle.Base128)
				{
					if (flag && expectedField == 0 && (object)type == null && resolver != null)
					{
						type = resolver(fieldNumber);
						flag2 = (object)type == null;
					}
					else
					{
						flag2 = expectedField != fieldNumber;
					}
				}
				else
				{
					flag2 = false;
				}
				if (flag2)
				{
					if (num == long.MaxValue)
					{
						ThrowHelper.ThrowInvalidOperationException();
					}
					ProtoReader.Seek(source, num, null);
					bytesRead += num;
				}
			}
			while (flag2);
			ProtoReader.State state = ProtoReader.State.Create(source, this, context, num);
			try
			{
				if (IsDefined(type) && !type.IsEnum)
				{
					value = Deserialize(ObjectScope.LikeRoot, ref state, type, value);
				}
				else if (!TryDeserializeAuxiliaryType(ref state, DataFormat.Default, 1, type, ref value, skipOtherFields: true, asListItem: false, autoCreate: true, insideList: false, null, isRoot: true) && num != 0L)
				{
					ThrowUnexpectedType(type, this);
				}
				bytesRead += state.GetPosition();
			}
			finally
			{
				state.Dispose();
			}
			haveObject = true;
			return value;
		}

		public IEnumerable DeserializeItems(Stream source, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type, PrefixStyle style, int expectedField, TypeResolver resolver)
		{
			return DeserializeItems(source, type, style, expectedField, resolver, null);
		}

		public IEnumerable DeserializeItems(Stream source, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type, PrefixStyle style, int expectedField, TypeResolver resolver, SerializationContext context)
		{
			return new DeserializeItemsIterator(this, source, type, style, expectedField, resolver, context);
		}

		public IEnumerable<T> DeserializeItems<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(Stream source, PrefixStyle style, int expectedField)
		{
			return DeserializeItems<T>(source, style, expectedField, null);
		}

		public IEnumerable<T> DeserializeItems<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(Stream source, PrefixStyle style, int expectedField, SerializationContext context)
		{
			return new DeserializeItemsIterator<T>(this, source, style, expectedField, context);
		}

		public void SerializeWithLengthPrefix(Stream dest, object value, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type, PrefixStyle style, int fieldNumber)
		{
			SerializeWithLengthPrefix(dest, value, type, style, fieldNumber, null);
		}

		public void SerializeWithLengthPrefix(Stream dest, object value, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type, PrefixStyle style, int fieldNumber, SerializationContext context)
		{
			if ((object)type == null)
			{
				if (value == null)
				{
					ThrowHelper.ThrowArgumentNullException("value");
				}
				type = value.GetType();
			}
			ProtoWriter.State state = ProtoWriter.State.Create(dest, this, context);
			try
			{
				switch (style)
				{
				case PrefixStyle.None:
					if (!DynamicStub.TrySerializeRoot(type, this, ref state, value))
					{
						ThrowUnexpectedType(type, this);
					}
					break;
				case PrefixStyle.Base128:
				case PrefixStyle.Fixed32:
				case PrefixStyle.Fixed32BigEndian:
					state.WriteObject(value, type, style, fieldNumber);
					break;
				default:
					ThrowHelper.ThrowArgumentOutOfRangeException("style");
					break;
				}
				state.Flush();
				state.Close();
			}
			catch
			{
				state.Abandon();
				throw;
			}
			finally
			{
				state.Dispose();
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public object Deserialize(Stream source, object value, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type)
		{
			using ProtoReader.State state = ProtoReader.State.Create(source, this, null, -1L);
			return state.DeserializeRootFallback(value, type);
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public object Deserialize(Stream source, object value, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type, SerializationContext context)
		{
			using ProtoReader.State state = ProtoReader.State.Create(source, this, context, -1L);
			return state.DeserializeRootFallback(value, type);
		}

		public T Deserialize<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(Stream source, T value = default(T), object userState = null)
		{
			using ProtoReader.State state = ProtoReader.State.Create(source, this, userState, -1L);
			return state.DeserializeRootImpl(value);
		}

		public T Deserialize<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(ReadOnlyMemory<byte> source, T value = default(T), object userState = null)
		{
			using ProtoReader.State state = ProtoReader.State.Create(source, this, userState);
			return state.DeserializeRootImpl(value);
		}

		public unsafe T Deserialize<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(ReadOnlySpan<byte> source, T value = default(T), object userState = null)
		{
			fixed (byte* pointer = source)
			{
				FixedMemoryManager fixedMemoryManager = null;
				ProtoReader.State state = default(ProtoReader.State);
				try
				{
					fixedMemoryManager = Pool<FixedMemoryManager>.TryGet() ?? new FixedMemoryManager();
					state = ProtoReader.State.Create(fixedMemoryManager.Init(pointer, source.Length), this, userState);
					return state.DeserializeRootImpl(value);
				}
				finally
				{
					state.Dispose();
					Pool<FixedMemoryManager>.Put(fixedMemoryManager);
				}
			}
		}

		public T Deserialize<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(ReadOnlySequence<byte> source, T value = default(T), object userState = null)
		{
			using ProtoReader.State state = ProtoReader.State.Create(source, this, userState);
			return state.DeserializeRootImpl(value);
		}

		public object Deserialize([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type, Stream source, object value = null, object userState = null, long length = -1L)
		{
			using ProtoReader.State state = ProtoReader.State.Create(source, this, userState, length);
			return state.DeserializeRootFallback(value, type);
		}

		public object Deserialize([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type, ReadOnlyMemory<byte> source, object value = null, object userState = null)
		{
			using ProtoReader.State state = ProtoReader.State.Create(source, this, userState);
			return state.DeserializeRootFallback(value, type);
		}

		public unsafe object Deserialize([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type, ReadOnlySpan<byte> source, object value = null, object userState = null)
		{
			fixed (byte* pointer = source)
			{
				FixedMemoryManager fixedMemoryManager = null;
				ProtoReader.State state = default(ProtoReader.State);
				try
				{
					fixedMemoryManager = Pool<FixedMemoryManager>.TryGet() ?? new FixedMemoryManager();
					state = ProtoReader.State.Create(fixedMemoryManager.Init(pointer, source.Length), this, userState);
					return state.DeserializeRootFallback(value, type);
				}
				finally
				{
					state.Dispose();
					Pool<FixedMemoryManager>.Put(fixedMemoryManager);
				}
			}
		}

		public object Deserialize([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type, ReadOnlySequence<byte> source, object value = null, object userState = null)
		{
			using ProtoReader.State state = ProtoReader.State.Create(source, this, userState);
			return state.DeserializeRootFallback(value, type);
		}

		internal static bool PrepareDeserialize(object value, ref Type type)
		{
			if ((object)type == null || type == typeof(object))
			{
				if (value == null)
				{
					ThrowHelper.ThrowArgumentNullException("type");
				}
				type = value.GetType();
			}
			bool result = true;
			Type underlyingType = Nullable.GetUnderlyingType(type);
			if ((object)underlyingType == null)
			{
				type = DynamicStub.GetEffectiveType(type);
			}
			else
			{
				type = underlyingType;
				result = false;
			}
			return result;
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public object Deserialize(Stream source, object value, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type, int length)
		{
			return Deserialize(source, value, type, length, null);
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public object Deserialize(Stream source, object value, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type, long length)
		{
			return Deserialize(source, value, type, length, null);
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public object Deserialize(Stream source, object value, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type, int length, SerializationContext context)
		{
			return Deserialize(source, value, type, (length == int.MaxValue) ? long.MaxValue : length, context);
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public object Deserialize(Stream source, object value, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type, long length, SerializationContext context)
		{
			ProtoReader.State state = ProtoReader.State.Create(source, this, context, length);
			try
			{
				bool autoCreate = PrepareDeserialize(value, ref type);
				if (!DynamicStub.TryDeserializeRoot(type, this, ref state, ref value, autoCreate))
				{
					value = state.DeserializeRootFallback(value, type);
				}
				return value;
			}
			finally
			{
				state.Dispose();
			}
		}

		public object Deserialize(ReadOnlyMemory<byte> source, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type, object value = null, object userState = null)
		{
			ProtoReader.State state = ProtoReader.State.Create(source, this, userState);
			try
			{
				bool autoCreate = PrepareDeserialize(value, ref type);
				if (!DynamicStub.TryDeserializeRoot(type, this, ref state, ref value, autoCreate))
				{
					value = state.DeserializeRootFallback(value, type);
				}
				return value;
			}
			finally
			{
				state.Dispose();
			}
		}

		public object Deserialize(ReadOnlySequence<byte> source, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type, object value = null, object userState = null)
		{
			ProtoReader.State state = ProtoReader.State.Create(source, this, userState);
			try
			{
				bool autoCreate = PrepareDeserialize(value, ref type);
				if (!DynamicStub.TryDeserializeRoot(type, this, ref state, ref value, autoCreate))
				{
					value = state.DeserializeRootFallback(value, type);
				}
				return value;
			}
			finally
			{
				state.Dispose();
			}
		}

		[Obsolete("If possible, please use the State API; a transitionary implementation is provided, but this API may be removed in a future version", false)]
		public object Deserialize(ProtoReader source, object value, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type)
		{
			return source.DefaultState().DeserializeRootFallbackWithModel(value, type, this);
		}

		internal object DeserializeRootAny(ref ProtoReader.State state, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type, object value, bool autoCreate)
		{
			if (!DynamicStub.TryDeserializeRoot(type, this, ref state, ref value, autoCreate))
			{
				TryDeserializeAuxiliaryType(ref state, DataFormat.Default, 1, type, ref value, skipOtherFields: true, asListItem: false, autoCreate, insideList: false, null, isRoot: true);
			}
			return value;
		}

		private bool TryDeserializeList(ref ProtoReader.State state, DataFormat format, int tag, Type listType, Type itemType, ref object value, bool isRoot)
		{
			bool result = false;
			object value2 = null;
			IList list = value as IList;
			IList list2 = ((list == null) ? ((IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(itemType), nonPublic: true)) : null);
			while (TryDeserializeAuxiliaryType(ref state, format, tag, itemType, ref value2, skipOtherFields: true, asListItem: true, autoCreate: true, insideList: true, value ?? listType, isRoot))
			{
				result = true;
				if (value == null && list2 == null)
				{
					value = CreateListInstance(listType, itemType);
					list = value as IList;
				}
				if (list != null)
				{
					list.Add(value2);
				}
				else
				{
					list2.Add(value2);
				}
				value2 = null;
			}
			if (list2 != null)
			{
				if (value != null)
				{
					if (list2.Count != 0)
					{
						Array array = (Array)value;
						Array array2 = Array.CreateInstance(itemType, array.Length + list2.Count);
						Array.Copy(array, array2, array.Length);
						list2.CopyTo(array2, array.Length);
						value = array2;
					}
				}
				else
				{
					Array array2 = Array.CreateInstance(itemType, list2.Count);
					list2.CopyTo(array2, 0);
					value = array2;
				}
			}
			return result;
		}

		private static object CreateListInstance(Type listType, Type itemType)
		{
			Type type = listType;
			if (listType.IsArray)
			{
				return Array.CreateInstance(itemType, 0);
			}
			if (!listType.IsClass || listType.IsAbstract || (object)Helpers.GetConstructor(listType, Type.EmptyTypes, nonPublic: true) == null)
			{
				bool flag = false;
				string fullName;
				if (listType.IsInterface && (fullName = listType.FullName) != null && fullName.Contains("Dictionary"))
				{
					if (listType.IsGenericType && listType.GetGenericTypeDefinition() == typeof(IDictionary<, >))
					{
						Type[] genericArguments = listType.GetGenericArguments();
						type = typeof(Dictionary<, >).MakeGenericType(genericArguments);
						flag = true;
					}
					if (!flag && listType == typeof(IDictionary))
					{
						type = typeof(Hashtable);
						flag = true;
					}
				}
				if (!flag)
				{
					type = typeof(List<>).MakeGenericType(itemType);
					flag = true;
				}
				if (!flag)
				{
					type = typeof(ArrayList);
					flag = true;
				}
			}
			return Activator.CreateInstance(type, nonPublic: true);
		}

		internal bool TryDeserializeAuxiliaryType(ref ProtoReader.SolidState state, DataFormat format, int tag, Type type, ref object value, bool skipOtherFields, bool asListItem, bool autoCreate, bool insideList, object parentListOrType, bool isRoot)
		{
			ProtoReader.State state2 = state.Liquify();
			bool result = TryDeserializeAuxiliaryType(ref state2, format, tag, type, ref value, skipOtherFields, asListItem, autoCreate, insideList, parentListOrType, isRoot);
			state = state2.Solidify();
			return result;
		}

		internal bool TryDeserializeAuxiliaryType(ref ProtoReader.State state, DataFormat format, int tag, Type type, ref object value, bool skipOtherFields, bool asListItem, bool autoCreate, bool insideList, object parentListOrType, bool isRoot)
		{
			if ((object)type == null)
			{
				ThrowHelper.ThrowArgumentNullException("type");
			}
			WireType wireType = GetWireType(this, format, type);
			bool flag = false;
			if (wireType == WireType.None)
			{
				if (!TypeHelper.ResolveUniqueEnumerableT(type, out var t))
				{
					t = null;
				}
				if ((object)t == null && type.IsArray && type.GetArrayRank() == 1 && type != typeof(byte[]))
				{
					t = type.GetElementType();
				}
				if ((object)t != null)
				{
					if (insideList)
					{
						ThrowNestedListsNotSupported((parentListOrType as Type) ?? parentListOrType?.GetType());
					}
					flag = TryDeserializeList(ref state, format, tag, type, t, ref value, isRoot);
					if (!flag && autoCreate)
					{
						value = CreateListInstance(type, t);
					}
					return flag;
				}
				ThrowUnexpectedType(type, this);
			}
			if (!DynamicStub.CanSerialize(type, this, out var features))
			{
				ThrowHelper.ThrowInvalidOperationException("Unable to deserialize aux type: " + type.NormalizeName());
			}
			while (!(flag && asListItem))
			{
				int num = state.ReadFieldHeader();
				if (num <= 0)
				{
					break;
				}
				if (num != tag)
				{
					if (skipOtherFields)
					{
						state.SkipField();
						continue;
					}
					state.ThrowInvalidOperationException($"Expected field {tag}, but found {num}");
				}
				flag = true;
				state.Hint(wireType);
				ObjectScope scope = NormalizeAuxScope(features, insideList, type, isRoot);
				value = Deserialize(scope, ref state, type, value);
			}
			if (!flag && !asListItem && autoCreate && type != typeof(string))
			{
				value = Activator.CreateInstance(type, nonPublic: true);
			}
			return flag;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static TypeModel SetDefaultModel(TypeModel newValue)
		{
			if (newValue == null || newValue is NullModel)
			{
				Interlocked.CompareExchange(ref s_defaultModel, NullModel.Singleton, null);
			}
			else
			{
				Interlocked.Exchange(ref s_defaultModel, newValue);
			}
			return Volatile.Read(ref s_defaultModel);
		}

		internal static void ResetDefaultModel()
		{
			Volatile.Write(ref s_defaultModel, null);
		}

		[Obsolete("Use RuntimeTypeModel.Create", true)]
		public static TypeModel Create()
		{
			ThrowHelper.ThrowNotSupportedException();
			return null;
		}

		[Obsolete("Use RuntimeTypeModel.CreateForAssembly", true)]
		public static TypeModel CreateForAssembly<T>()
		{
			ThrowHelper.ThrowNotSupportedException();
			return null;
		}

		[Obsolete("Use RuntimeTypeModel.CreateForAssembly", true)]
		public static TypeModel CreateForAssembly(Type type)
		{
			ThrowHelper.ThrowNotSupportedException();
			return null;
		}

		[Obsolete("Use RuntimeTypeModel.CreateForAssembly", true)]
		public static TypeModel CreateForAssembly(Assembly assembly)
		{
			ThrowHelper.ThrowNotSupportedException();
			return null;
		}

		public bool IsDefined(Type type)
		{
			return IsDefined(type, CompatibilityLevel.NotSpecified);
		}

		internal bool IsDefined(Type type, CompatibilityLevel ambient)
		{
			if ((object)type != null)
			{
				return DynamicStub.IsKnownType(type, this, ambient);
			}
			return false;
		}

		protected virtual ISerializer<T> GetSerializer<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>()
		{
			return this as ISerializer<T>;
		}

		internal virtual ISerializer<T> GetSerializerCore<T>(CompatibilityLevel ambient)
		{
			return GetSerializer<T>();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static ISerializer<T> NoSerializer<T>(TypeModel model)
		{
			string text = null;
			if (model is NullModel)
			{
				text = "; you may need to ensure that RuntimeTypeModel.Initialize has been invoked";
			}
			ThrowHelper.ThrowInvalidOperationException("No serializer for type " + typeof(T).NormalizeName() + " is available for model " + (model?.ToString() ?? "(none)") + text);
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static ISubTypeSerializer<T> NoSubTypeSerializer<T>(TypeModel model) where T : class
		{
			ThrowHelper.ThrowInvalidOperationException("No sub-type serializer for type " + typeof(T).NormalizeName() + " is available for model " + (model?.ToString() ?? "(none)"));
			return null;
		}

		internal static T CreateInstance<T>(ISerializationContext context, ISerializer<T> serializer = null)
		{
			if (TypeHelper<T>.IsReferenceType)
			{
				if (serializer == null)
				{
					serializer = TryGetSerializer<T>(context?.Model);
				}
				T val = default(T);
				if (serializer is IFactory<T> factory)
				{
					val = factory.Create(context);
				}
				T val2 = val;
				if (val2 == null)
				{
					val = ActivatorCreate<T>();
				}
				return val;
			}
			return default(T);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static T ActivatorCreate<T>()
		{
			try
			{
				return (T)Activator.CreateInstance(typeof(T), nonPublic: true);
			}
			catch (MissingMethodException inner)
			{
				ThrowCannotCreateInstance(typeof(T), inner);
				return default(T);
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static ISerializer<T> GetSerializer<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(TypeModel model, CompatibilityLevel ambient = CompatibilityLevel.NotSpecified)
		{
			return SerializerCache<PrimaryTypeProvider, T>.InstanceField ?? model?.GetSerializerCore<T>(ambient) ?? NoSerializer<T>(model);
		}

		public static ISerializer<T> GetInbuiltSerializer<T>(CompatibilityLevel compatibilityLevel = CompatibilityLevel.NotSpecified, DataFormat dataFormat = DataFormat.Default)
		{
			if (compatibilityLevel >= CompatibilityLevel.Level300)
			{
				ISerializer<T> instanceField;
				if (dataFormat == DataFormat.FixedSize)
				{
					instanceField = SerializerCache<Level300FixedSerializer, T>.InstanceField;
					if (instanceField != null)
					{
						return instanceField;
					}
				}
				instanceField = SerializerCache<Level300DefaultSerializer, T>.InstanceField;
				if (instanceField != null)
				{
					return instanceField;
				}
			}
			else if (compatibilityLevel >= CompatibilityLevel.Level240 || dataFormat == DataFormat.WellKnown)
			{
				ISerializer<T> instanceField = SerializerCache<Level240DefaultSerializer, T>.InstanceField;
				if (instanceField != null)
				{
					return instanceField;
				}
			}
			return SerializerCache<PrimaryTypeProvider, T>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IRepeatedSerializer<T> GetRepeatedSerializer<T>(TypeModel model)
		{
			if (model?.GetSerializer<T>() is IRepeatedSerializer<T> result)
			{
				return result;
			}
			NoSerializer<T>(model);
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static ISerializer<T> TryGetSerializer<T>(TypeModel model)
		{
			ISerializer<T> serializer = SerializerCache<PrimaryTypeProvider, T>.InstanceField;
			if (serializer == null)
			{
				if (model == null)
				{
					return null;
				}
				serializer = model.GetSerializer<T>();
			}
			return serializer;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static ISubTypeSerializer<T> GetSubTypeSerializer<T>(TypeModel model) where T : class
		{
			return (model?.GetSerializer<T>() as ISubTypeSerializer<T>) ?? NoSubTypeSerializer<T>(model);
		}

		internal object Deserialize(ObjectScope scope, ref ProtoReader.State state, Type type, object value)
		{
			if (!DynamicStub.TryDeserialize(scope, type, this, ref state, ref value))
			{
				ThrowHelper.ThrowNotSupportedException(string.Format("{0} is not supported for {1} by {2}", "Deserialize", type.NormalizeName(), this));
			}
			return value;
		}

		public T DeepClone<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(T value, object userState = null)
		{
			if (!RuntimeHelpers.IsReferenceOrContainsReferences<T>())
			{
				return value;
			}
			if (TypeHelper<T>.CanBeNull && TypeHelper<T>.ValueChecker.IsNull(value))
			{
				return value;
			}
			ISerializer<T> serializer = TryGetSerializer<T>(this);
			if (serializer == null)
			{
				return (T)DeepCloneFallback(typeof(T), value);
			}
			if ((serializer.Features & SerializerFeatures.CategoryScalar) != SerializerFeatures.CategoryRepeated)
			{
				return value;
			}
			using MemoryStream memoryStream = new MemoryStream();
			Serialize(memoryStream, value, userState);
			memoryStream.Position = 0L;
			return Deserialize(memoryStream, default(T), userState);
		}

		public object DeepClone(object value)
		{
			if (value == null)
			{
				return null;
			}
			Type type = value.GetType();
			if (!DynamicStub.TryDeepClone(type, this, ref value))
			{
				return DeepCloneFallback(type, value);
			}
			return value;
		}

		private object DeepCloneFallback(Type type, object value)
		{
			using MemoryStream memoryStream = new MemoryStream();
			ProtoWriter.State state = ProtoWriter.State.Create(memoryStream, this);
			PrepareDeserialize(value, ref type);
			try
			{
				if (!TrySerializeAuxiliaryType(ref state, type, DataFormat.Default, 1, value, isInsideList: false, null, isRoot: true))
				{
					ThrowUnexpectedType(type, this);
				}
				state.Close();
			}
			catch
			{
				state.Abandon();
				throw;
			}
			finally
			{
				state.Dispose();
			}
			memoryStream.Position = 0L;
			ProtoReader.State state2 = ProtoReader.State.Create(memoryStream, this, null, -1L);
			try
			{
				value = null;
				TryDeserializeAuxiliaryType(ref state2, DataFormat.Default, 1, type, ref value, skipOtherFields: true, asListItem: false, autoCreate: true, insideList: false, null, isRoot: true);
			}
			finally
			{
				state2.Dispose();
			}
			return value;
		}

		protected internal static void ThrowUnexpectedSubtype(Type expected, Type actual)
		{
			if (!DynamicStub.IsTypeEquivalent(expected, actual))
			{
				ThrowHelper.ThrowInvalidOperationException("Unexpected sub-type: " + actual.FullName);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ThrowUnexpectedSubtype<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(T value) where T : class
		{
			if (IsSubType(value))
			{
				ThrowUnexpectedSubtype(typeof(T), value.GetType());
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ThrowUnexpectedSubtype<T, TConstruct>(T value) where T : class where TConstruct : class, T
		{
			if (IsSubType(value) && value.GetType() != typeof(TConstruct))
			{
				ThrowUnexpectedSubtype(typeof(T), value.GetType());
			}
		}

		public static bool IsSubType<T>(T value) where T : class
		{
			if (value != null)
			{
				return typeof(T) != value.GetType();
			}
			return false;
		}

		protected internal static void ThrowUnexpectedType(Type type, TypeModel model)
		{
			string text = (((object)type == null) ? "(unknown)" : type.FullName);
			if ((object)type != null)
			{
				Type baseType = type.BaseType;
				if ((object)baseType != null && baseType.IsGenericType && baseType.GetGenericTypeDefinition().Name == "GeneratedMessage`2")
				{
					ThrowHelper.ThrowInvalidOperationException("Are you mixing protobuf-net and protobuf-csharp-port? See https://stackoverflow.com/q/11564914/23354; type: " + text);
				}
			}
			try
			{
				ThrowHelper.ThrowInvalidOperationException("Type is not expected, and no contract can be inferred: " + text);
			}
			catch (Exception ex) when (model != null)
			{
				ex.Data["TypeModel"] = model.ToString();
				throw;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void ThrowNestedListsNotSupported(Type type)
		{
			ThrowHelper.ThrowNestedDataNotSupported(type);
		}

		public static void ThrowCannotCreateInstance(Type type, Exception inner = null)
		{
			ThrowHelper.ThrowProtoException("No parameterless constructor found for " + (type?.FullName ?? "(null)"), inner);
		}

		internal static string SerializeType(TypeModel model, Type type)
		{
			if (model != null)
			{
				TypeFormatEventHandler typeFormatEventHandler = model.DynamicTypeFormatting;
				if (typeFormatEventHandler != null)
				{
					TypeFormatEventArgs e = new TypeFormatEventArgs(type);
					typeFormatEventHandler(model, e);
					if (!string.IsNullOrEmpty(e.FormattedName))
					{
						return e.FormattedName;
					}
				}
			}
			return type.AssemblyQualifiedName;
		}

		internal static Type DeserializeType(TypeModel model, string value)
		{
			if (model != null)
			{
				TypeFormatEventHandler typeFormatEventHandler = model.DynamicTypeFormatting;
				if (typeFormatEventHandler != null)
				{
					TypeFormatEventArgs e = new TypeFormatEventArgs(value);
					typeFormatEventHandler(model, e);
					if ((object)e.Type != null)
					{
						return e.Type;
					}
				}
			}
			return Type.GetType(value);
		}

		public bool CanSerializeContractType(Type type)
		{
			SerializerFeatures category;
			return CanSerialize(type, allowBasic: false, allowContract: true, allowLists: true, out category);
		}

		public bool CanSerialize(Type type)
		{
			SerializerFeatures category;
			return CanSerialize(type, allowBasic: true, allowContract: true, allowLists: true, out category);
		}

		public bool CanSerializeBasicType(Type type)
		{
			SerializerFeatures category;
			return CanSerialize(type, allowBasic: true, allowContract: false, allowLists: true, out category);
		}

		internal bool CanSerialize(Type type, bool allowBasic, bool allowContract, bool allowLists, out SerializerFeatures category)
		{
			if ((object)type == null)
			{
				ThrowHelper.ThrowArgumentNullException("type");
			}
			do
			{
				if (!DynamicStub.CanSerialize(type, this, out var features))
				{
					continue;
				}
				category = features.GetCategory();
				switch (category)
				{
				case SerializerFeatures.CategoryRepeated:
					if (allowLists)
					{
						return DoCheckLists(type, this, allowBasic, allowContract);
					}
					return false;
				case SerializerFeatures.CategoryMessage:
					return allowContract;
				case SerializerFeatures.CategoryScalar:
				case SerializerFeatures.CategoryMessageWrappedAtRoot:
					return allowBasic;
				}
			}
			while (CheckIfNullableT(ref type));
			category = SerializerFeatures.CategoryRepeated;
			return false;
			static bool CheckIfNullableT(ref Type reference)
			{
				Type underlyingType = Nullable.GetUnderlyingType(reference);
				if ((object)underlyingType != null)
				{
					reference = underlyingType;
					return true;
				}
				return false;
			}
			static bool DoCheckLists(Type type2, TypeModel model, bool allowBasic2, bool allowContract2)
			{
				SerializerFeatures category2;
				if (TypeHelper.ResolveUniqueEnumerableT(type2, out var t))
				{
					return model.CanSerialize(t, allowBasic2, allowContract2, allowLists: false, out category2);
				}
				return false;
			}
		}

		public string GetSchema([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type)
		{
			return GetSchema(type, ProtoSyntax.Default);
		}

		public string GetSchema([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type, ProtoSyntax syntax)
		{
			SchemaGenerationOptions schemaGenerationOptions;
			if ((object)type == null && syntax == ProtoSyntax.Default)
			{
				schemaGenerationOptions = SchemaGenerationOptions.Default;
			}
			else
			{
				schemaGenerationOptions = new SchemaGenerationOptions
				{
					Syntax = syntax
				};
				if ((object)type != null)
				{
					schemaGenerationOptions.Types.Add(type);
				}
			}
			return GetSchema(schemaGenerationOptions);
		}

		public virtual string GetSchema(SchemaGenerationOptions options)
		{
			ThrowHelper.ThrowNotSupportedException();
			return null;
		}

		public IFormatter CreateFormatter([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type)
		{
			return new Formatter(this, type);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Type ResolveKnownType(string name, Assembly assembly)
		{
			if (string.IsNullOrEmpty(name))
			{
				return null;
			}
			try
			{
				Type type = Type.GetType(name);
				if ((object)type != null)
				{
					return type;
				}
			}
			catch
			{
			}
			try
			{
				int num = name.IndexOf(',');
				string name2 = ((num > 0) ? name.Substring(0, num) : name).Trim();
				if ((object)assembly == null)
				{
					assembly = Assembly.GetCallingAssembly();
				}
				Type type2 = assembly?.GetType(name2);
				if ((object)type2 != null)
				{
					return type2;
				}
			}
			catch
			{
			}
			return null;
		}

		T IProtoInput<Stream>.Deserialize<T>(Stream source, T value, object userState)
		{
			return Deserialize(source, value, userState);
		}

		T IProtoInput<ArraySegment<byte>>.Deserialize<T>(ArraySegment<byte> source, T value, object userState)
		{
			return Deserialize(new ReadOnlyMemory<byte>(source.Array, source.Offset, source.Count), value, userState);
		}

		T IProtoInput<byte[]>.Deserialize<T>(byte[] source, T value, object userState)
		{
			return Deserialize(new ReadOnlyMemory<byte>(source), value, userState);
		}

		void IProtoOutput<Stream>.Serialize<T>(Stream destination, T value, object userState)
		{
			Serialize(destination, value, userState);
		}

		void IProtoOutput<IBufferWriter<byte>>.Serialize<T>(IBufferWriter<byte> destination, T value, object userState)
		{
			Serialize(destination, value, userState);
		}

		void IMeasuredProtoOutput<Stream>.Serialize<T>(MeasureState<T> measured, Stream destination)
		{
			measured.Serialize(destination);
		}

		void IMeasuredProtoOutput<IBufferWriter<byte>>.Serialize<T>(MeasureState<T> measured, IBufferWriter<byte> destination)
		{
			measured.Serialize(destination);
		}

		MeasureState<T> IMeasuredProtoOutput<Stream>.Measure<T>(T value, object userState)
		{
			return Measure(value, userState, -1L);
		}

		MeasureState<T> IMeasuredProtoOutput<IBufferWriter<byte>>.Measure<T>(T value, object userState)
		{
			return Measure(value, userState, -1L);
		}
	}
}
