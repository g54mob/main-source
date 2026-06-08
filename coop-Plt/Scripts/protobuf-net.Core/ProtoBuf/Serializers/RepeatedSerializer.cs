using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using ProtoBuf.Internal;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	public static class RepeatedSerializer
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RepeatedSerializer<TCollection, T> CreateConcurrentBag<TCollection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>() where TCollection : ConcurrentBag<T>
		{
			return SerializerCache<ConcurrentBagSerializer<TCollection, T>>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RepeatedSerializer<TCollection, T> CreateConcurrentStack<TCollection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>() where TCollection : ConcurrentStack<T>
		{
			return SerializerCache<ConcurrentStackSerializer<TCollection, T>>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RepeatedSerializer<TCollection, T> CreateConcurrentQueue<TCollection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>() where TCollection : ConcurrentQueue<T>
		{
			return SerializerCache<ConcurrentQueueSerializer<TCollection, T>>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RepeatedSerializer<TCollection, T> CreateIProducerConsumerCollection<TCollection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>() where TCollection : class, IProducerConsumerCollection<T>
		{
			return SerializerCache<ProducerConsumerSerializer<TCollection, T>>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[Obsolete("Since this isn't supported, you probably shouldn't be doing it...", false)]
		public static RepeatedSerializer<TCollection, T> CreateNestedDataNotSupported<TCollection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>()
		{
			ThrowHelper.ThrowNestedDataNotSupported(typeof(TCollection));
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[Obsolete("Since this isn't supported, you probably shouldn't be doing it...", false)]
		public static RepeatedSerializer<TCollection, T> CreateNotSupported<TCollection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>()
		{
			ThrowHelper.ThrowNotSupportedException($"Repeated data of type {typeof(TCollection)} is not supported");
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RepeatedSerializer<List<T>, T> CreateList<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>()
		{
			return SerializerCache<ListSerializer<T>>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RepeatedSerializer<TList, T> CreateList<TList, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>() where TList : List<T>
		{
			return SerializerCache<ListSerializer<TList, T>>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RepeatedSerializer<TCollection, T> CreateEnumerable<TCollection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>() where TCollection : class, IEnumerable<T>
		{
			return SerializerCache<EnumerableSerializer<TCollection, TCollection, T>>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RepeatedSerializer<TCollection, T> CreateEnumerable<TCollection, TCreate, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>() where TCollection : class, IEnumerable<T> where TCreate : TCollection
		{
			return SerializerCache<EnumerableSerializer<TCollection, TCreate, T>>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RepeatedSerializer<T[], T> CreateVector<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>()
		{
			return SerializerCache<VectorSerializer<T>>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RepeatedSerializer<TCollection, T> CreateQueue<TCollection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>() where TCollection : Queue<T>
		{
			return SerializerCache<QueueSerializer<TCollection, T>>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RepeatedSerializer<TCollection, T> CreateStack<TCollection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>() where TCollection : Stack<T>
		{
			return SerializerCache<StackSerializer<TCollection, T>>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void ReverseInPlace<T>(this ref ArraySegment<T> values)
		{
			Array.Reverse((Array)values.Array, values.Offset, values.Count);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static ref T Singleton<T>(this ref ArraySegment<T> values)
		{
			return ref values.Array[values.Offset];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RepeatedSerializer<ImmutableArray<T>, T> CreateImmutableArray<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>()
		{
			return SerializerCache<ImmutableArraySerializer<T>>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RepeatedSerializer<ImmutableList<T>, T> CreateImmutableList<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>()
		{
			return SerializerCache<ImmutableListSerializer<T>>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RepeatedSerializer<IImmutableList<T>, T> CreateImmutableIList<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>()
		{
			return SerializerCache<ImmutableIListSerializer<T>>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RepeatedSerializer<ImmutableQueue<T>, T> CreateImmutableQueue<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>()
		{
			return SerializerCache<ImmutableQueueSerializer<T>>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RepeatedSerializer<IImmutableQueue<T>, T> CreateImmutableIQueue<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>()
		{
			return SerializerCache<ImmutableIQueueSerializer<T>>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RepeatedSerializer<ImmutableStack<T>, T> CreateImmutableStack<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>()
		{
			return SerializerCache<ImmutableStackSerializer<T>>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RepeatedSerializer<IImmutableStack<T>, T> CreateImmutableIStack<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>()
		{
			return SerializerCache<ImmutableIStackSerializer<T>>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RepeatedSerializer<ImmutableHashSet<T>, T> CreateImmutableHashSet<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>()
		{
			return SerializerCache<ImmutableHashSetSerializer<T>>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RepeatedSerializer<ImmutableSortedSet<T>, T> CreateImmutableSortedSet<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>()
		{
			return SerializerCache<ImmutableSortedSetSerializer<T>>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RepeatedSerializer<IImmutableSet<T>, T> CreateImmutableISet<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>()
		{
			return SerializerCache<ImmutableISetSerializer<T>>.InstanceField;
		}
	}
	public abstract class RepeatedSerializer<TCollection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] TItem> : IRepeatedSerializer<TCollection>, ISerializer<TCollection>, IFactory<TCollection>
	{
		SerializerFeatures ISerializer<TCollection>.Features => SerializerFeatures.CategoryRepeated;

		TCollection IFactory<TCollection>.Create(ISerializationContext context)
		{
			return Initialize(default(TCollection), context);
		}

		TCollection ISerializer<TCollection>.Read(ref ProtoReader.State state, TCollection value)
		{
			ThrowHelper.ThrowInvalidOperationException("Should have used ReadRepeated");
			return default(TCollection);
		}

		void ISerializer<TCollection>.Write(ref ProtoWriter.State state, TCollection value)
		{
			ThrowHelper.ThrowInvalidOperationException("Should have used WriteRepeated");
		}

		void IRepeatedSerializer<TCollection>.WriteRepeated(ref ProtoWriter.State state, int fieldNumber, SerializerFeatures features, TCollection values)
		{
			WriteRepeated(ref state, fieldNumber, features, values);
		}

		public void WriteRepeated(ref ProtoWriter.State state, int fieldNumber, SerializerFeatures features, TCollection values, ISerializer<TItem> serializer = null)
		{
			if (serializer == null)
			{
				serializer = TypeModel.GetSerializer<TItem>(state.Model);
			}
			SerializerFeatures features2 = serializer.Features;
			if (features2.IsRepeated())
			{
				TypeModel.ThrowNestedListsNotSupported(typeof(TItem));
			}
			features.InheritFrom(features2);
			int num = TryGetCount(values);
			SerializerFeatures category = features2.GetCategory();
			WireType wireType = features.GetWireType();
			if (TypeHelper<TItem>.CanBePacked && !features.IsPackedDisabled() && (num == 0 || num > 1) && serializer is IMeasuringSerializer<TItem> serializer2)
			{
				if (category != SerializerFeatures.CategoryScalar)
				{
					features2.ThrowInvalidCategory();
				}
				if (num == 0)
				{
					WriteZeroLengthPackedHeader(ref state, fieldNumber);
				}
				else
				{
					WritePacked(ref state, fieldNumber, wireType, values, num, serializer2);
				}
			}
			else if (num != 0)
			{
				Write(ref state, fieldNumber, category, wireType, values, serializer);
			}
		}

		private void WriteZeroLengthPackedHeader(ref ProtoWriter.State state, int fieldNumber)
		{
			if (state.Model.OmitsOption(TypeModel.TypeModelOptions.SkipZeroLengthPackedArrays))
			{
				state.WriteFieldHeader(fieldNumber, WireType.String);
				ProtoWriter writer = state.GetWriter();
				writer.AdvanceAndReset(writer.ImplWriteVarint64(ref state, 0uL));
			}
		}

		internal abstract void Write(ref ProtoWriter.State state, int fieldNumber, SerializerFeatures category, WireType wireType, TCollection values, ISerializer<TItem> serializer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Write<TEnumerator>(ref ProtoWriter.State state, int fieldNumber, SerializerFeatures category, WireType wireType, ref TEnumerator values, ISerializer<TItem> serializer) where TEnumerator : IEnumerator<TItem>
		{
			ProtoWriter writer = state.GetWriter();
			while (values.MoveNext())
			{
				TItem current = values.Current;
				if (TypeHelper<TItem>.CanBeNull && TypeHelper<TItem>.ValueChecker.IsNull(current))
				{
					ThrowHelper.ThrowNullRepeatedContents<TItem>();
				}
				state.WriteFieldHeader(fieldNumber, wireType);
				switch (category)
				{
				case SerializerFeatures.CategoryMessage:
				case SerializerFeatures.CategoryMessageWrappedAtRoot:
					writer.WriteMessage(ref state, current, serializer, PrefixStyle.Base128, recursionCheck: true);
					break;
				case SerializerFeatures.CategoryScalar:
					serializer.Write(ref state, current);
					break;
				default:
					category.ThrowInvalidCategory();
					break;
				}
			}
		}

		internal abstract long Measure(TCollection values, IMeasuringSerializer<TItem> serializer, ISerializationContext context, WireType wireType);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal long Measure<TEnumerator>(ref TEnumerator values, IMeasuringSerializer<TItem> serializer, ISerializationContext context, WireType wireType) where TEnumerator : IEnumerator<TItem>
		{
			long num = 0L;
			while (values.MoveNext())
			{
				num += serializer.Measure(context, wireType, values.Current);
			}
			return num;
		}

		internal abstract void WritePacked(ref ProtoWriter.State state, TCollection values, IMeasuringSerializer<TItem> serializer, WireType wireType);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void WritePacked<TEnumerator>(ref ProtoWriter.State state, ref TEnumerator values, IMeasuringSerializer<TItem> serializer, WireType wireType) where TEnumerator : IEnumerator<TItem>
		{
			while (values.MoveNext())
			{
				TItem current = values.Current;
				state.WireType = wireType;
				serializer.Write(ref state, current);
			}
		}

		private void WritePacked(ref ProtoWriter.State state, int fieldNumber, WireType wireType, TCollection values, int count, IMeasuringSerializer<TItem> serializer)
		{
			long num;
			switch (wireType)
			{
			case WireType.Fixed32:
				num = count * 4;
				break;
			case WireType.Fixed64:
				num = count * 8;
				break;
			case WireType.Variant:
			case WireType.SignedVariant:
				num = Measure(values, serializer, state.Context, wireType);
				break;
			default:
				ThrowHelper.ThrowInvalidPackedOperationException(wireType, typeof(TItem));
				num = 0L;
				break;
			}
			state.WriteFieldHeader(fieldNumber, WireType.String);
			ProtoWriter writer = state.GetWriter();
			writer.AdvanceAndReset(writer.ImplWriteVarint64(ref state, (ulong)num));
			long position = state.GetPosition();
			WritePacked(ref state, values, serializer, wireType);
			long num2 = state.GetPosition() - position;
			if (num2 != num)
			{
				ThrowHelper.ThrowInvalidOperationException($"packed encoding length miscalculation for {typeof(TItem).NormalizeName()}, {wireType}; expected {num}, got {num2}");
			}
		}

		protected abstract int TryGetCount(TCollection values);

		protected int TryGetCountDefault(TCollection values)
		{
			try
			{
				return (values is IReadOnlyCollection<TItem> readOnlyCollection) ? readOnlyCollection.Count : ((values is ICollection<TItem> collection) ? collection.Count : ((values is ICollection collection2) ? collection2.Count : ((values != null) ? (-1) : 0)));
			}
			catch
			{
				return -1;
			}
		}

		TCollection IRepeatedSerializer<TCollection>.ReadRepeated(ref ProtoReader.State state, SerializerFeatures features, TCollection values)
		{
			return ReadRepeated(ref state, features, values);
		}

		public TCollection ReadRepeated(ref ProtoReader.State state, SerializerFeatures features, TCollection values, ISerializer<TItem> serializer = null)
		{
			if (serializer == null)
			{
				serializer = TypeModel.GetSerializer<TItem>(state.Model);
			}
			SerializerFeatures features2 = serializer.Features;
			if (features2.IsRepeated())
			{
				TypeModel.ThrowNestedListsNotSupported(typeof(TItem));
			}
			features.InheritFrom(features2);
			ISerializationContext context = state.Context;
			values = Initialize(values, context);
			using ReadBuffer<TItem> readBuffer = state.FillBuffer(features, in serializer, TypeHelper<TItem>.Default);
			if ((features & SerializerFeatures.OptionClearCollection) != SerializerFeatures.CategoryRepeated)
			{
				values = Clear(values, context);
			}
			if (readBuffer.IsEmpty)
			{
				return values;
			}
			ArraySegment<TItem> newValues = readBuffer.Segment;
			return AddRange(values, ref newValues, context);
		}

		protected virtual TCollection Initialize(TCollection values, ISerializationContext context)
		{
			return values;
		}

		protected abstract TCollection Clear(TCollection values, ISerializationContext context);

		protected abstract TCollection AddRange(TCollection values, ref ArraySegment<TItem> newValues, ISerializationContext context);
	}
}
