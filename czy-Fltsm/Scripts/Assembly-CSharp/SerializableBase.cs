using System;
using System.Collections.Generic;
using System.IO;
using PajamaLlama.Debugs;

public abstract class SerializableBase
{
	private BinaryWriter _writer;

	private Dictionary<string, byte[]> _deserializedValueTypes;

	private Dictionary<string, string> _deserializedStrings;

	private Dictionary<string, SerializableBase> _deserializedSerializables;

	public abstract SerializationMarkers Marker { get; }

	public void Serialize(BinaryWriter writer)
	{
		_writer = writer;
		_writer.Write((byte)Marker);
		InternalSerialize();
		_writer.Write(byte.MaxValue);
		_writer = null;
	}

	public void Deserialize(BinaryReader reader, bool isRoot)
	{
		if (isRoot && reader.ReadByte() != 16)
		{
			Debugger.Error("The root object for the serialization should always extend SerializableBase!");
			return;
		}
		SerializationMarkers serializationMarkers;
		while ((serializationMarkers = (SerializationMarkers)reader.ReadByte()) == SerializationMarkers.Key)
		{
			string key = reader.ReadString();
			SerializationMarkers serializationMarkers2 = (SerializationMarkers)reader.ReadByte();
			switch (serializationMarkers2)
			{
			case SerializationMarkers.Key:
			case SerializationMarkers.SerializableEnd:
				Debugger.Error("Unexpected marker '" + serializationMarkers2.ToString() + "' encountered during deserialization!");
				serializationMarkers = serializationMarkers2;
				continue;
			case SerializationMarkers.Byte:
			case SerializationMarkers.Boolean:
				DeserializeValueType(reader, key, 1);
				continue;
			case SerializationMarkers.Integer:
			case SerializationMarkers.Float:
				DeserializeValueType(reader, key, 4);
				continue;
			case SerializationMarkers.String:
				if (_deserializedStrings == null)
				{
					_deserializedStrings = new Dictionary<string, string>();
				}
				_deserializedStrings.Add(key, reader.ReadString());
				continue;
			}
			if (_deserializedSerializables == null)
			{
				_deserializedSerializables = new Dictionary<string, SerializableBase>();
			}
			SerializableBase serializableBase = SerializableFactory.ReturnInstance(serializationMarkers2);
			serializableBase.Deserialize(reader, isRoot: false);
			_deserializedSerializables.Add(key, serializableBase);
		}
		if (serializationMarkers != SerializationMarkers.SerializableEnd)
		{
			Debugger.Error(GetType()?.ToString() + " has finished serialization with marker '" + serializationMarkers.ToString() + "' instead of the 'SerializableEnd' marker!");
		}
		InternalDeserialize();
	}

	protected abstract void InternalSerialize();

	protected abstract void InternalDeserialize();

	protected void WriteByte(string key, byte value)
	{
		WriteKey(key);
		_writer.Write((byte)8);
		_writer.Write(value);
	}

	protected void WriteBool(string key, bool value)
	{
		WriteKey(key);
		_writer.Write((byte)9);
		_writer.Write(value);
	}

	protected void WriteInt(string key, int value)
	{
		WriteKey(key);
		_writer.Write((byte)10);
		_writer.Write(value);
	}

	protected void WriteFloat(string key, float value)
	{
		WriteKey(key);
		_writer.Write((byte)11);
		_writer.Write(value);
	}

	protected void WriteString(string key, string value)
	{
		WriteKey(key);
		_writer.Write((byte)12);
		_writer.Write(value);
	}

	protected void WriteSerializable(string key, SerializableBase serializable)
	{
		WriteKey(key);
		serializable.Serialize(_writer);
	}

	private void WriteKey(string key)
	{
		_writer.Write((byte)1);
		_writer.Write(key);
	}

	protected byte ReadByte(string key, byte defaultValue = 0)
	{
		if (TryReturnDeserializedBytes(key, out var bytes))
		{
			return bytes[0];
		}
		return defaultValue;
	}

	protected bool ReadBool(string key, bool defaultValue = false)
	{
		if (TryReturnDeserializedBytes(key, out var bytes))
		{
			return BitConverter.ToBoolean(bytes, 0);
		}
		return defaultValue;
	}

	protected int ReadInt(string key, int defaultValue = 0)
	{
		if (TryReturnDeserializedBytes(key, out var bytes))
		{
			return BitConverter.ToInt32(bytes, 0);
		}
		return defaultValue;
	}

	protected float ReadFloat(string key, float defaultValue = 0f)
	{
		if (TryReturnDeserializedBytes(key, out var bytes))
		{
			return BitConverter.ToSingle(bytes, 0);
		}
		return defaultValue;
	}

	protected string ReadString(string key, string defaultValue = null)
	{
		if (_deserializedStrings == null)
		{
			Debugger.Error("No strings were deserialized!");
			return null;
		}
		if (_deserializedStrings.TryGetValue(key, out var value))
		{
			return value;
		}
		Debugger.Error("No string was found for key: " + key + "!");
		return defaultValue;
	}

	protected T ReadSerializable<T>(string key) where T : SerializableBase
	{
		if (_deserializedSerializables == null)
		{
			Debugger.Error("No serializables were deserialized!");
			return null;
		}
		if (_deserializedSerializables.TryGetValue(key, out var value))
		{
			T obj = value as T;
			if (obj == null)
			{
				Debugger.Error("Serializable type mismatch between " + typeof(T)?.ToString() + " and " + value.GetType());
			}
			return obj;
		}
		Debugger.Error("No serializable was found for key: " + key + "!");
		return null;
	}

	private void DeserializeValueType(BinaryReader reader, string key, int bytes)
	{
		if (_deserializedValueTypes == null)
		{
			_deserializedValueTypes = new Dictionary<string, byte[]>();
		}
		_deserializedValueTypes.Add(key, reader.ReadBytes(bytes));
	}

	private bool TryReturnDeserializedBytes(string key, out byte[] bytes)
	{
		if (_deserializedValueTypes == null)
		{
			Debugger.Error("No value types were deserialized!");
			bytes = null;
			return false;
		}
		if (_deserializedValueTypes.TryGetValue(key, out bytes))
		{
			return true;
		}
		Debugger.Error("No value type was found for key: " + key + "!");
		bytes = null;
		return false;
	}
}
