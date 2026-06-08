using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using ProtoBuf.Internal;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	public static class MapSerializer
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static MapSerializer<TCollection, TKey, TValue> CreateConcurrentDictionary<TCollection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] TKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] TValue>() where TCollection : ConcurrentDictionary<TKey, TValue>
		{
			return SerializerCache<ConcurrentDictionarySerializer<TCollection, TKey, TValue>>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static MapSerializer<Dictionary<TKey, TValue>, TKey, TValue> CreateDictionary<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] TKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] TValue>()
		{
			return SerializerCache<DictionarySerializer<TKey, TValue>>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static MapSerializer<TCollection, TKey, TValue> CreateDictionary<TCollection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] TKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] TValue>() where TCollection : IDictionary<TKey, TValue>
		{
			return SerializerCache<DictionarySerializer<TCollection, TKey, TValue>>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static MapSerializer<ImmutableDictionary<TKey, TValue>, TKey, TValue> CreateImmutableDictionary<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] TKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] TValue>()
		{
			return SerializerCache<ImmutableDictionarySerializer<TKey, TValue>>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static MapSerializer<ImmutableSortedDictionary<TKey, TValue>, TKey, TValue> CreateImmutableSortedDictionary<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] TKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] TValue>()
		{
			return SerializerCache<ImmutableSortedDictionarySerializer<TKey, TValue>>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static MapSerializer<IImmutableDictionary<TKey, TValue>, TKey, TValue> CreateIImmutableDictionary<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] TKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] TValue>()
		{
			return SerializerCache<ImmutableIDictionarySerializer<TKey, TValue>>.InstanceField;
		}
	}
	public abstract class MapSerializer<TCollection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] TKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] TValue> : IRepeatedSerializer<TCollection>, ISerializer<TCollection>, IFactory<TCollection>
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
			WriteMap(ref state, fieldNumber, features, values, SerializerFeatures.CategoryRepeated, SerializerFeatures.CategoryRepeated);
		}

		TCollection IRepeatedSerializer<TCollection>.ReadRepeated(ref ProtoReader.State state, SerializerFeatures features, TCollection values)
		{
			return ReadMap(ref state, features, values, SerializerFeatures.CategoryRepeated, SerializerFeatures.CategoryRepeated);
		}

		private static KeyValuePairSerializer<TKey, TValue> GetSerializer(TypeModel model, SerializerFeatures keyFeatures, SerializerFeatures valueFeatures, ISerializer<TKey> keySerializer, ISerializer<TValue> valueSerializer)
		{
			if (keySerializer == null)
			{
				keySerializer = TypeModel.GetSerializer<TKey>(model);
			}
			if (valueSerializer == null)
			{
				valueSerializer = TypeModel.GetSerializer<TValue>(model);
			}
			keyFeatures.InheritFrom(keySerializer.Features);
			valueFeatures.InheritFrom(valueSerializer.Features);
			return new KeyValuePairSerializer<TKey, TValue>(keySerializer, keyFeatures, valueSerializer, valueFeatures);
		}

		public void WriteMap(ref ProtoWriter.State state, int fieldNumber, SerializerFeatures features, TCollection values, SerializerFeatures keyFeatures, SerializerFeatures valueFeatures, ISerializer<TKey> keySerializer = null, ISerializer<TValue> valueSerializer = null)
		{
			KeyValuePairSerializer<TKey, TValue> pairSerializer = GetSerializer(state.Model, keyFeatures, valueFeatures, keySerializer, valueSerializer);
			features.InheritFrom(pairSerializer.Features);
			WireType wireType = features.GetWireType();
			Write(ref state, fieldNumber, wireType, values, in pairSerializer);
		}

		internal abstract void Write(ref ProtoWriter.State state, int fieldNumber, WireType wireType, TCollection values, in KeyValuePairSerializer<TKey, TValue> pairSerializer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Write<TEnumerator>(ref ProtoWriter.State state, int fieldNumber, WireType wireType, ref TEnumerator enumerator, in KeyValuePairSerializer<TKey, TValue> pairSerializer) where TEnumerator : IEnumerator<KeyValuePair<TKey, TValue>>
		{
			if (enumerator.MoveNext())
			{
				ISerializer<KeyValuePair<TKey, TValue>> serializer = pairSerializer;
				do
				{
					state.WriteFieldHeader(fieldNumber, wireType);
					state.GetWriter().WriteMessage(ref state, enumerator.Current, serializer, PrefixStyle.Base128, recursionCheck: false);
				}
				while (enumerator.MoveNext());
			}
		}

		protected virtual TCollection Initialize(TCollection values, ISerializationContext context)
		{
			return values;
		}

		protected abstract TCollection Clear(TCollection values, ISerializationContext context);

		protected abstract TCollection AddRange(TCollection values, ref ArraySegment<KeyValuePair<TKey, TValue>> newValues, ISerializationContext context);

		protected abstract TCollection SetValues(TCollection values, ref ArraySegment<KeyValuePair<TKey, TValue>> newValues, ISerializationContext context);

		public TCollection ReadMap(ref ProtoReader.State state, SerializerFeatures features, TCollection values, SerializerFeatures keyFeatures, SerializerFeatures valueFeatures, ISerializer<TKey> keySerializer = null, ISerializer<TValue> valueSerializer = null)
		{
			ISerializationContext context = state.Context;
			KeyValuePairSerializer<TKey, TValue> serializer = GetSerializer(state.Model, keyFeatures, valueFeatures, keySerializer, valueSerializer);
			features.InheritFrom(serializer.Features);
			values = Initialize(values, context);
			using ReadBuffer<KeyValuePair<TKey, TValue>> readBuffer = state.FillBuffer(features, in serializer, new KeyValuePair<TKey, TValue>(TypeHelper<TKey>.Default, TypeHelper<TValue>.Default));
			if ((features & SerializerFeatures.OptionClearCollection) != SerializerFeatures.CategoryRepeated)
			{
				values = Clear(values, context);
			}
			if (!readBuffer.IsEmpty)
			{
				ArraySegment<KeyValuePair<TKey, TValue>> newValues = readBuffer.Segment;
				values = (((features & SerializerFeatures.OptionFailOnDuplicateKey) == 0) ? SetValues(values, ref newValues, context) : AddRange(values, ref newValues, context));
			}
			return values;
		}
	}
}
