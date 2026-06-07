using System;
using System.Collections;
using System.Collections.Generic;

namespace ExitGames.Client.Photon
{
	public class Protocol16 : IProtocol
	{
		public enum GpType : byte
		{
			Unknown = 0,
			Array = 121,
			Boolean = 111,
			Byte = 98,
			ByteArray = 120,
			ObjectArray = 122,
			Short = 107,
			Float = 102,
			Dictionary = 68,
			Double = 100,
			Hashtable = 104,
			Integer = 105,
			IntegerArray = 110,
			Long = 108,
			String = 115,
			StringArray = 97,
			Custom = 99,
			Null = 42,
			EventData = 101,
			OperationRequest = 113,
			OperationResponse = 112
		}

		private readonly byte[] versionBytes;

		private readonly byte[] memShort;

		private readonly long[] memLongBlock;

		private readonly byte[] memLongBlockBytes;

		private static readonly float[] memFloatBlock;

		private static readonly byte[] memFloatBlockBytes;

		private readonly double[] memDoubleBlock;

		private readonly byte[] memDoubleBlockBytes;

		private readonly byte[] memInteger;

		private readonly byte[] memLong;

		private readonly byte[] memFloat;

		private readonly byte[] memDouble;

		public override string ProtocolType => null;

		public override byte[] VersionBytes => null;

		private bool SerializeCustom(StreamBuffer dout, object serObject)
		{
			return false;
		}

		private object DeserializeCustom(StreamBuffer din, byte customTypeCode, DeserializationFlags flags = DeserializationFlags.None)
		{
			return null;
		}

		private Type GetTypeOfCode(byte typeCode)
		{
			return null;
		}

		private GpType GetCodeOfType(Type type)
		{
			return default(GpType);
		}

		private Array CreateArrayByType(byte arrayType, short length)
		{
			return null;
		}

		public void SerializeOperationRequest(StreamBuffer stream, OperationRequest operation, bool setType)
		{
		}

		[Obsolete("Use ParameterDictionary instead.")]
		public override void SerializeOperationRequest(StreamBuffer stream, byte operationCode, Dictionary<byte, object> parameters, bool setType)
		{
		}

		public override void SerializeOperationRequest(StreamBuffer stream, byte operationCode, ParameterDictionary parameters, bool setType)
		{
		}

		public override OperationRequest DeserializeOperationRequest(StreamBuffer din, DeserializationFlags flags)
		{
			return null;
		}

		public override void SerializeOperationResponse(StreamBuffer stream, OperationResponse serObject, bool setType)
		{
		}

		public override DisconnectMessage DeserializeDisconnectMessage(StreamBuffer stream)
		{
			return null;
		}

		public override OperationResponse DeserializeOperationResponse(StreamBuffer stream, DeserializationFlags flags = DeserializationFlags.None)
		{
			return null;
		}

		public override void SerializeEventData(StreamBuffer stream, EventData serObject, bool setType)
		{
		}

		public override EventData DeserializeEventData(StreamBuffer din, EventData target = null, DeserializationFlags flags = DeserializationFlags.None)
		{
			return null;
		}

		[Obsolete("Use ParameterDictionary instead of Dictionary<byte, object>.")]
		private void SerializeParameterTable(StreamBuffer stream, Dictionary<byte, object> parameters)
		{
		}

		private void SerializeParameterTable(StreamBuffer stream, ParameterDictionary parameters)
		{
		}

		private Dictionary<byte, object> DeserializeParameterTable(StreamBuffer stream, Dictionary<byte, object> target = null)
		{
			return null;
		}

		private ParameterDictionary DeserializeParameterDictionary(StreamBuffer stream, ParameterDictionary target = null, DeserializationFlags flags = DeserializationFlags.None)
		{
			return null;
		}

		public override void Serialize(StreamBuffer dout, object serObject, bool setType)
		{
		}

		private void SerializeByte(StreamBuffer dout, byte serObject, bool setType)
		{
		}

		private void SerializeBoolean(StreamBuffer dout, bool serObject, bool setType)
		{
		}

		public override void SerializeShort(StreamBuffer dout, short serObject, bool setType)
		{
		}

		public void SerializeLengthAsShort(StreamBuffer dout, int serObject, string type)
		{
		}

		private void SerializeInteger(StreamBuffer dout, int serObject, bool setType)
		{
		}

		private void SerializeLong(StreamBuffer dout, long serObject, bool setType)
		{
		}

		private void SerializeFloat(StreamBuffer dout, float serObject, bool setType)
		{
		}

		private void SerializeDouble(StreamBuffer dout, double serObject, bool setType)
		{
		}

		public override void SerializeString(StreamBuffer stream, string value, bool setType)
		{
		}

		private void SerializeArray(StreamBuffer dout, Array serObject, bool setType)
		{
		}

		private void SerializeByteArray(StreamBuffer dout, byte[] serObject, bool setType)
		{
		}

		private void SerializeByteArraySegment(StreamBuffer dout, byte[] serObject, int offset, int count, bool setType)
		{
		}

		private void SerializeIntArrayOptimized(StreamBuffer inWriter, int[] serObject, bool setType)
		{
		}

		private void SerializeStringArray(StreamBuffer dout, string[] serObject, bool setType)
		{
		}

		private void SerializeObjectArray(StreamBuffer dout, IList objects, bool setType)
		{
		}

		private void SerializeHashTable(StreamBuffer dout, Hashtable serObject, bool setType)
		{
		}

		private void SerializeDictionary(StreamBuffer dout, IDictionary serObject, bool setType)
		{
		}

		private void SerializeDictionaryHeader(StreamBuffer writer, Type dictType)
		{
		}

		private void SerializeDictionaryHeader(StreamBuffer writer, object dict, out bool setKeyType, out bool setValueType)
		{
			setKeyType = default(bool);
			setValueType = default(bool);
		}

		private void SerializeDictionaryElements(StreamBuffer writer, object dict, bool setKeyType, bool setValueType)
		{
		}

		public override object Deserialize(StreamBuffer din, byte type, DeserializationFlags flags = DeserializationFlags.None)
		{
			return null;
		}

		public override byte DeserializeByte(StreamBuffer din)
		{
			return 0;
		}

		private bool DeserializeBoolean(StreamBuffer din)
		{
			return false;
		}

		public override short DeserializeShort(StreamBuffer din)
		{
			return 0;
		}

		private int DeserializeInteger(StreamBuffer din)
		{
			return 0;
		}

		private long DeserializeLong(StreamBuffer din)
		{
			return 0L;
		}

		private float DeserializeFloat(StreamBuffer din)
		{
			return 0f;
		}

		private double DeserializeDouble(StreamBuffer din)
		{
			return 0.0;
		}

		private string DeserializeString(StreamBuffer din)
		{
			return null;
		}

		private Array DeserializeArray(StreamBuffer din)
		{
			return null;
		}

		private byte[] DeserializeByteArray(StreamBuffer din, int size = -1)
		{
			return null;
		}

		private int[] DeserializeIntArray(StreamBuffer din, int size = -1)
		{
			return null;
		}

		private string[] DeserializeStringArray(StreamBuffer din)
		{
			return null;
		}

		private object[] DeserializeObjectArray(StreamBuffer din)
		{
			return null;
		}

		private Hashtable DeserializeHashTable(StreamBuffer din)
		{
			return null;
		}

		private IDictionary DeserializeDictionary(StreamBuffer din)
		{
			return null;
		}

		private bool DeserializeDictionaryArray(StreamBuffer din, short size, out Array arrayResult)
		{
			arrayResult = null;
			return false;
		}

		private Type DeserializeDictionaryType(StreamBuffer reader, out byte keyTypeCode, out byte valTypeCode)
		{
			keyTypeCode = default(byte);
			valTypeCode = default(byte);
			return null;
		}
	}
}
