using System;
using System.Collections.Generic;

namespace ExitGames.Client.Photon
{
	public abstract class IProtocol
	{
		public enum DeserializationFlags
		{
			None = 0,
			AllowPooledByteArray = 1,
			WrapIncomingStructs = 2
		}

		public readonly ByteArraySlicePool ByteArraySlicePool;

		public abstract string ProtocolType { get; }

		public abstract byte[] VersionBytes { get; }

		public abstract void Serialize(StreamBuffer dout, object serObject, bool setType);

		public abstract void SerializeShort(StreamBuffer dout, short serObject, bool setType);

		public abstract void SerializeString(StreamBuffer dout, string serObject, bool setType);

		public abstract void SerializeEventData(StreamBuffer stream, EventData serObject, bool setType);

		[Obsolete("Use ParameterDictionary instead.")]
		public abstract void SerializeOperationRequest(StreamBuffer stream, byte operationCode, Dictionary<byte, object> parameters, bool setType);

		public abstract void SerializeOperationRequest(StreamBuffer stream, byte operationCode, ParameterDictionary parameters, bool setType);

		public abstract void SerializeOperationResponse(StreamBuffer stream, OperationResponse serObject, bool setType);

		public abstract object Deserialize(StreamBuffer din, byte type, DeserializationFlags flags = DeserializationFlags.None);

		public abstract short DeserializeShort(StreamBuffer din);

		public abstract byte DeserializeByte(StreamBuffer din);

		public abstract EventData DeserializeEventData(StreamBuffer din, EventData target = null, DeserializationFlags flags = DeserializationFlags.None);

		public abstract OperationRequest DeserializeOperationRequest(StreamBuffer din, DeserializationFlags flags = DeserializationFlags.None);

		public abstract OperationResponse DeserializeOperationResponse(StreamBuffer stream, DeserializationFlags flags = DeserializationFlags.None);

		public abstract DisconnectMessage DeserializeDisconnectMessage(StreamBuffer stream);

		public byte[] Serialize(object obj)
		{
			return null;
		}

		public object Deserialize(StreamBuffer stream)
		{
			return null;
		}

		public object Deserialize(byte[] serializedData)
		{
			return null;
		}

		public object DeserializeMessage(StreamBuffer stream)
		{
			return null;
		}

		internal void SerializeMessage(StreamBuffer ms, object msg)
		{
		}
	}
}
