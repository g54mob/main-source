using System.Collections.Generic;
using System.Runtime.InteropServices;
using ProtoBuf.Meta;
using ProtoBuf.Serializers;

namespace ProtoBuf.Internal
{
	[StructLayout(LayoutKind.Auto)]
	internal readonly struct KeyValuePairSerializer<TKey, TValue> : ISerializer<KeyValuePair<TKey, TValue>>
	{
		private readonly ISerializer<TKey> _keySerializer;

		private readonly ISerializer<TValue> _valueSerializer;

		private readonly SerializerFeatures _keyFeatures;

		private readonly SerializerFeatures _valueFeatures;

		public SerializerFeatures Features => SerializerFeatures.WireTypeString | SerializerFeatures.CategoryMessage;

		internal KeyValuePairSerializer(ISerializer<TKey> keySerializer, SerializerFeatures keyFeatures, ISerializer<TValue> valueSerializer, SerializerFeatures valueFeatures)
		{
			_keySerializer = keySerializer;
			_valueSerializer = valueSerializer;
			_keyFeatures = keyFeatures;
			_valueFeatures = valueFeatures;
		}

		public KeyValuePair<TKey, TValue> Read(ref ProtoReader.State state, KeyValuePair<TKey, TValue> pair)
		{
			TKey val = pair.Key;
			TValue value = pair.Value;
			int num;
			while ((num = state.ReadFieldHeader()) > 0)
			{
				switch (num)
				{
				case 1:
					val = state.ReadAny(_keyFeatures, val, _keySerializer);
					break;
				case 2:
					value = state.ReadAny(_valueFeatures, value, _valueSerializer);
					break;
				default:
					state.SkipField();
					break;
				}
			}
			if (TypeHelper<TKey>.IsReferenceType && TypeHelper<TKey>.ValueChecker.IsNull(val))
			{
				val = TypeModel.CreateInstance(state.Context, _keySerializer);
			}
			if (TypeHelper<TValue>.IsReferenceType && TypeHelper<TValue>.ValueChecker.IsNull(value))
			{
				value = TypeModel.CreateInstance(state.Context, _valueSerializer);
			}
			return new KeyValuePair<TKey, TValue>(val, value);
		}

		public void Write(ref ProtoWriter.State state, KeyValuePair<TKey, TValue> value)
		{
			if (TypeHelper<TKey>.ValueChecker.HasNonTrivialValue(value.Key))
			{
				state.WriteAny(1, _keyFeatures, value.Key, _keySerializer);
			}
			if (TypeHelper<TValue>.ValueChecker.HasNonTrivialValue(value.Value))
			{
				state.WriteAny(2, _valueFeatures, value.Value, _valueSerializer);
			}
		}
	}
}
