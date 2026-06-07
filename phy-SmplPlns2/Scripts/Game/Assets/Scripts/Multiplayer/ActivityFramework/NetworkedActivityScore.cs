using System;
using FishNet.Serializing;

namespace Assets.Scripts.Multiplayer.ActivityFramework
{
	public class NetworkedActivityScore
	{
		public enum ScoreValueType : byte
		{
			Float = 1,
			Int = 2
		}

		private object _value;

		public string DisplayName { get; }

		public string Id { get; }

		public object Value
		{
			get
			{
				return _value;
			}
			set
			{
				if (value is int valueInt)
				{
					ValueInt = valueInt;
					return;
				}
				if (value is float valueFloat)
				{
					ValueFloat = valueFloat;
					return;
				}
				throw GetInvalidValueTypeException(setter: true, value.GetType());
			}
		}

		public float ValueFloat
		{
			get
			{
				if (ValueType == ScoreValueType.Float)
				{
					return (float)(Value ?? ((object)0f));
				}
				if (ValueType == ScoreValueType.Int)
				{
					return (int)(Value ?? ((object)0));
				}
				throw GetInvalidValueTypeException(setter: false, typeof(float));
			}
			set
			{
				if (ValueType == ScoreValueType.Float)
				{
					SetValue(value);
					return;
				}
				if (ValueType == ScoreValueType.Int)
				{
					SetValue((int)value);
					return;
				}
				throw GetInvalidValueTypeException(setter: true, typeof(float));
			}
		}

		public int ValueInt
		{
			get
			{
				if (ValueType == ScoreValueType.Int)
				{
					return (int)(Value ?? ((object)0));
				}
				if (ValueType == ScoreValueType.Float)
				{
					return (int)(float)(Value ?? ((object)0f));
				}
				throw GetInvalidValueTypeException(setter: false, typeof(int));
			}
			set
			{
				if (ValueType == ScoreValueType.Int)
				{
					SetValue(value);
					return;
				}
				if (ValueType == ScoreValueType.Float)
				{
					SetValue((float)value);
					return;
				}
				throw GetInvalidValueTypeException(setter: true, typeof(int));
			}
		}

		public ScoreValueType ValueType { get; private set; }

		public NetworkedActivityScore(string id, string displayName, ScoreValueType type)
		{
			Id = id;
			DisplayName = displayName;
			ValueType = type;
		}

		public static ArraySegment<byte> ReadValueAsByteArray(Reader reader)
		{
			int position = reader.Position;
			int num = reader.ReadInt32();
			int count = reader.Position - position + num;
			reader.Position = position;
			return reader.ReadArraySegment(count);
		}

		public static void ReadValueAsThrowaway(Reader reader)
		{
			reader.ReadInt32();
			reader.Position += reader.Position;
		}

		public void ReadValue(Reader reader)
		{
			if (ValueType == ScoreValueType.Int)
			{
				reader.ReadInt32();
				ValueInt = reader.ReadInt32Unpacked();
				return;
			}
			if (ValueType == ScoreValueType.Float)
			{
				reader.ReadInt32();
				ValueFloat = reader.ReadSingle();
				return;
			}
			throw new InvalidOperationException($"Unable to read score '{DisplayName}' from the network reader because it is an unsupported value type '{ValueType}'");
		}

		public void WriteValue(Writer writer)
		{
			if (ValueType == ScoreValueType.Int)
			{
				writer.WriteInt32(4);
				writer.WriteInt32Unpacked(ValueInt);
				return;
			}
			if (ValueType == ScoreValueType.Float)
			{
				writer.WriteInt32(4);
				writer.WriteSingle(ValueFloat);
				return;
			}
			throw new InvalidOperationException($"Unable to write score '{DisplayName}' to the network writer because it is an unsupported value type '{ValueType}'");
		}

		private Exception GetInvalidValueTypeException(bool setter, Type targetType)
		{
			return new InvalidOperationException(string.Format("Unable to {0} score '{1}' as a '{2}' value because it is a '{3}' type.", setter ? "set" : "get", DisplayName, targetType.Name, ValueType));
		}

		private void SetValue(int value)
		{
			_value = value;
		}

		private void SetValue(float value)
		{
			_value = value;
		}
	}
}
