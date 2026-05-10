using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon.StructWrapping;

namespace ExitGames.Client.Photon
{
	public class Protocol18 : IProtocol
	{
		public enum GpType : byte
		{
			Unknown = 0,
			Boolean = 2,
			Byte = 3,
			Short = 4,
			Float = 5,
			Double = 6,
			String = 7,
			Null = 8,
			CompressedInt = 9,
			CompressedLong = 10,
			Int1 = 11,
			Int1_ = 12,
			Int2 = 13,
			Int2_ = 14,
			L1 = 15,
			L1_ = 16,
			L2 = 17,
			L2_ = 18,
			Custom = 19,
			CustomTypeSlim = 128,
			Dictionary = 20,
			Hashtable = 21,
			ObjectArray = 23,
			OperationRequest = 24,
			OperationResponse = 25,
			EventData = 26,
			BooleanFalse = 27,
			BooleanTrue = 28,
			ShortZero = 29,
			IntZero = 30,
			LongZero = 31,
			FloatZero = 32,
			DoubleZero = 33,
			ByteZero = 34,
			Array = 64,
			BooleanArray = 66,
			ByteArray = 67,
			ShortArray = 68,
			DoubleArray = 70,
			FloatArray = 69,
			StringArray = 71,
			HashtableArray = 85,
			DictionaryArray = 84,
			CustomTypeArray = 83,
			CompressedIntArray = 73,
			CompressedLongArray = 74
		}

		private readonly byte[] versionBytes;

		private static readonly byte[] boolMasks;

		private readonly double[] memDoubleBlock;

		private readonly float[] memFloatBlock;

		private readonly byte[] memCustomTypeBodyLengthSerialized;

		private readonly byte[] memCompressedUInt32;

		private byte[] memCompressedUInt64;

		public override string ProtocolType => null;

		public override byte[] VersionBytes => null;

		public override void Serialize(StreamBuffer dout, object serObject, bool setType)
		{
		}

		public override void SerializeShort(StreamBuffer dout, short serObject, bool setType)
		{
		}

		public override void SerializeString(StreamBuffer dout, string serObject, bool setType)
		{
		}

		public override object Deserialize(StreamBuffer din, byte type, DeserializationFlags flags = DeserializationFlags.None)
		{
			return null;
		}

		public override short DeserializeShort(StreamBuffer din)
		{
			return 0;
		}

		public override byte DeserializeByte(StreamBuffer din)
		{
			return 0;
		}

		private static Type GetAllowedDictionaryKeyTypes(GpType gpType)
		{
			return null;
		}

		private static Type GetClrArrayType(GpType gpType)
		{
			return null;
		}

		private GpType GetCodeOfType(Type type)
		{
			return default(GpType);
		}

		private GpType GetCodeOfTypeCode(TypeCode type)
		{
			return default(GpType);
		}

		private object Read(StreamBuffer stream, DeserializationFlags flags, ParameterDictionary parameters)
		{
			return null;
		}

		private object Read(StreamBuffer stream, byte gpType, DeserializationFlags flags = DeserializationFlags.None, ParameterDictionary parameters = null)
		{
			return null;
		}

		internal bool ReadBoolean(StreamBuffer stream)
		{
			return false;
		}

		internal byte ReadByte(StreamBuffer stream)
		{
			return 0;
		}

		internal short ReadInt16(StreamBuffer stream)
		{
			return 0;
		}

		internal ushort ReadUShort(StreamBuffer stream)
		{
			return 0;
		}

		internal int ReadInt32(StreamBuffer stream)
		{
			return 0;
		}

		internal long ReadInt64(StreamBuffer stream)
		{
			return 0L;
		}

		internal float ReadSingle(StreamBuffer stream)
		{
			return 0f;
		}

		internal double ReadDouble(StreamBuffer stream)
		{
			return 0.0;
		}

		internal ByteArraySlice ReadNonAllocByteArray(StreamBuffer stream)
		{
			return null;
		}

		internal byte[] ReadByteArray(StreamBuffer stream)
		{
			return null;
		}

		public object ReadCustomType(StreamBuffer stream, byte gpType = 0)
		{
			return null;
		}

		public override EventData DeserializeEventData(StreamBuffer din, EventData target = null, DeserializationFlags flags = DeserializationFlags.None)
		{
			return null;
		}

		[Obsolete("Use ParameterDictionary instead.")]
		private Dictionary<byte, object> ReadParameterTable(StreamBuffer stream, Dictionary<byte, object> target = null, DeserializationFlags flags = DeserializationFlags.None)
		{
			return null;
		}

		private ParameterDictionary ReadParameterDictionary(StreamBuffer stream, ParameterDictionary target = null, DeserializationFlags flags = DeserializationFlags.None)
		{
			return null;
		}

		public Hashtable ReadHashtable(StreamBuffer stream, DeserializationFlags flags, ParameterDictionary parameters)
		{
			return null;
		}

		public int[] ReadIntArray(StreamBuffer stream)
		{
			return null;
		}

		public override OperationRequest DeserializeOperationRequest(StreamBuffer din, DeserializationFlags flags = DeserializationFlags.None)
		{
			return null;
		}

		public override OperationResponse DeserializeOperationResponse(StreamBuffer stream, DeserializationFlags flags = DeserializationFlags.None)
		{
			return null;
		}

		public override DisconnectMessage DeserializeDisconnectMessage(StreamBuffer stream)
		{
			return null;
		}

		internal string ReadString(StreamBuffer stream)
		{
			return null;
		}

		private object ReadCustomTypeArray(StreamBuffer stream)
		{
			return null;
		}

		private Type ReadDictionaryType(StreamBuffer stream, out GpType keyReadType, out GpType valueReadType)
		{
			keyReadType = default(GpType);
			valueReadType = default(GpType);
			return null;
		}

		private Type ReadDictionaryType(StreamBuffer stream)
		{
			return null;
		}

		private Type GetDictArrayType(StreamBuffer stream)
		{
			return null;
		}

		private IDictionary ReadDictionary(StreamBuffer stream, DeserializationFlags flags, ParameterDictionary parameters)
		{
			return null;
		}

		private bool ReadDictionaryElements(StreamBuffer stream, GpType keyReadType, GpType valueReadType, IDictionary dictionary, DeserializationFlags flags, ParameterDictionary parameters)
		{
			return false;
		}

		private object[] ReadObjectArray(StreamBuffer stream, DeserializationFlags flags, ParameterDictionary parameters)
		{
			return null;
		}

		private StructWrapper[] ReadWrapperArray(StreamBuffer stream, DeserializationFlags flags, ParameterDictionary parameters)
		{
			return null;
		}

		private bool[] ReadBooleanArray(StreamBuffer stream)
		{
			return null;
		}

		internal short[] ReadInt16Array(StreamBuffer stream)
		{
			return null;
		}

		private float[] ReadSingleArray(StreamBuffer stream)
		{
			return null;
		}

		private double[] ReadDoubleArray(StreamBuffer stream)
		{
			return null;
		}

		internal string[] ReadStringArray(StreamBuffer stream)
		{
			return null;
		}

		private Hashtable[] ReadHashtableArray(StreamBuffer stream, DeserializationFlags flags, ParameterDictionary parameters)
		{
			return null;
		}

		private IDictionary[] ReadDictionaryArray(StreamBuffer stream, DeserializationFlags flags, ParameterDictionary parameters)
		{
			return null;
		}

		private Array ReadArrayInArray(StreamBuffer stream, DeserializationFlags flags, ParameterDictionary parameters)
		{
			return null;
		}

		internal int ReadInt1(StreamBuffer stream, bool signNegative)
		{
			return 0;
		}

		internal int ReadInt2(StreamBuffer stream, bool signNegative)
		{
			return 0;
		}

		internal int ReadCompressedInt32(StreamBuffer stream)
		{
			return 0;
		}

		private uint ReadCompressedUInt32(StreamBuffer stream)
		{
			return 0u;
		}

		internal long ReadCompressedInt64(StreamBuffer stream)
		{
			return 0L;
		}

		private ulong ReadCompressedUInt64(StreamBuffer stream)
		{
			return 0uL;
		}

		internal int[] ReadCompressedInt32Array(StreamBuffer stream)
		{
			return null;
		}

		internal long[] ReadCompressedInt64Array(StreamBuffer stream)
		{
			return null;
		}

		private int DecodeZigZag32(uint value)
		{
			return 0;
		}

		private long DecodeZigZag64(ulong value)
		{
			return 0L;
		}

		internal void Write(StreamBuffer stream, object value, bool writeType)
		{
		}

		private void Write(StreamBuffer stream, object value, GpType gpType, bool writeType)
		{
		}

		public override void SerializeEventData(StreamBuffer stream, EventData serObject, bool setType)
		{
		}

		private void WriteParameterTable(StreamBuffer stream, Dictionary<byte, object> parameters)
		{
		}

		private void WriteParameterTable(StreamBuffer stream, ParameterDictionary parameters)
		{
		}

		private void SerializeOperationRequest(StreamBuffer stream, OperationRequest operation, bool setType)
		{
		}

		[Obsolete("Use ParameterDictionary instead.")]
		public override void SerializeOperationRequest(StreamBuffer stream, byte operationCode, Dictionary<byte, object> parameters, bool setType)
		{
		}

		public override void SerializeOperationRequest(StreamBuffer stream, byte operationCode, ParameterDictionary parameters, bool setType)
		{
		}

		public override void SerializeOperationResponse(StreamBuffer stream, OperationResponse serObject, bool setType)
		{
		}

		internal void WriteByte(StreamBuffer stream, byte value, bool writeType)
		{
		}

		internal void WriteBoolean(StreamBuffer stream, bool value, bool writeType)
		{
		}

		internal void WriteUShort(StreamBuffer stream, ushort value)
		{
		}

		internal void WriteInt16(StreamBuffer stream, short value, bool writeType)
		{
		}

		internal void WriteDouble(StreamBuffer stream, double value, bool writeType)
		{
		}

		internal void WriteSingle(StreamBuffer stream, float value, bool writeType)
		{
		}

		internal void WriteString(StreamBuffer stream, string value, bool writeType)
		{
		}

		private void WriteHashtable(StreamBuffer stream, object value, bool writeType)
		{
		}

		internal void WriteByteArray(StreamBuffer stream, byte[] value, bool writeType)
		{
		}

		private void WriteArraySegmentByte(StreamBuffer stream, ArraySegment<byte> seg, bool writeType)
		{
		}

		private void WriteByteArraySlice(StreamBuffer stream, ByteArraySlice buffer, bool writeType)
		{
		}

		internal void WriteInt32ArrayCompressed(StreamBuffer stream, int[] value, bool writeType)
		{
		}

		private void WriteInt64ArrayCompressed(StreamBuffer stream, long[] values, bool setType)
		{
		}

		internal void WriteBoolArray(StreamBuffer stream, bool[] value, bool writeType)
		{
		}

		internal void WriteInt16Array(StreamBuffer stream, short[] value, bool writeType)
		{
		}

		internal void WriteSingleArray(StreamBuffer stream, float[] values, bool setType)
		{
		}

		internal void WriteDoubleArray(StreamBuffer stream, double[] values, bool setType)
		{
		}

		internal void WriteStringArray(StreamBuffer stream, object value0, bool writeType)
		{
		}

		private void WriteObjectArray(StreamBuffer stream, object array, bool writeType)
		{
		}

		private void WriteObjectArray(StreamBuffer stream, IList array, bool writeType)
		{
		}

		private void WriteArrayInArray(StreamBuffer stream, object value, bool writeType)
		{
		}

		private void WriteCustomTypeBody(CustomType customType, StreamBuffer stream, object value)
		{
		}

		private void WriteCustomType(StreamBuffer stream, object value, bool writeType)
		{
		}

		private void WriteCustomTypeArray(StreamBuffer stream, object value, bool writeType)
		{
		}

		private bool WriteArrayHeader(StreamBuffer stream, Type type)
		{
			return false;
		}

		private void WriteDictionaryElements(StreamBuffer stream, IDictionary dictionary, GpType keyWriteType, GpType valueWriteType)
		{
		}

		private void WriteDictionary(StreamBuffer stream, object dict, bool setType)
		{
		}

		private void WriteDictionaryHeader(StreamBuffer stream, Type type, out GpType keyWriteType, out GpType valueWriteType)
		{
			keyWriteType = default(GpType);
			valueWriteType = default(GpType);
		}

		private bool WriteArrayType(StreamBuffer stream, Type type, out GpType writeType)
		{
			writeType = default(GpType);
			return false;
		}

		private void WriteHashtableArray(StreamBuffer stream, object value, bool writeType)
		{
		}

		private void WriteDictionaryArray(StreamBuffer stream, IDictionary[] dictArray, bool writeType)
		{
		}

		private void WriteIntLength(StreamBuffer stream, int value)
		{
		}

		private void WriteVarInt32(StreamBuffer stream, int value, bool writeType)
		{
		}

		private void WriteCompressedInt32(StreamBuffer stream, int value, bool writeType)
		{
		}

		private void WriteCompressedInt64(StreamBuffer stream, long value, bool writeType)
		{
		}

		private void WriteCompressedUInt32(StreamBuffer stream, uint value)
		{
		}

		private int WriteCompressedUInt32(byte[] buffer, uint value)
		{
			return 0;
		}

		private void WriteCompressedUInt64(StreamBuffer stream, ulong value)
		{
		}

		private uint EncodeZigZag32(int value)
		{
			return 0u;
		}

		private ulong EncodeZigZag64(long value)
		{
			return 0uL;
		}
	}
}
