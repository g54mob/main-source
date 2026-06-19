using System;
using System.IO;
using MessagePack.Decoders;

namespace MessagePack
{
	public static class MessagePackBinary
	{
		private static class StreamDecodeMemoryPool
		{
			[ThreadStatic]
			private static byte[] buffer;

			public static byte[] GetBuffer()
			{
				if (buffer == null)
				{
					buffer = new byte[65536];
				}
				return buffer;
			}
		}

		private const int MaxSize = 256;

		private const int ArrayMaxSize = 2147483591;

		private static readonly IMapHeaderDecoder[] mapHeaderDecoders;

		private static readonly IArrayHeaderDecoder[] arrayHeaderDecoders;

		private static readonly IBooleanDecoder[] booleanDecoders;

		private static readonly IByteDecoder[] byteDecoders;

		private static readonly IBytesDecoder[] bytesDecoders;

		private static readonly IBytesSegmentDecoder[] bytesSegmentDecoders;

		private static readonly ISByteDecoder[] sbyteDecoders;

		private static readonly ISingleDecoder[] singleDecoders;

		private static readonly IDoubleDecoder[] doubleDecoders;

		private static readonly IInt16Decoder[] int16Decoders;

		private static readonly IInt32Decoder[] int32Decoders;

		private static readonly IInt64Decoder[] int64Decoders;

		private static readonly IUInt16Decoder[] uint16Decoders;

		private static readonly IUInt32Decoder[] uint32Decoders;

		private static readonly IUInt64Decoder[] uint64Decoders;

		private static readonly IStringDecoder[] stringDecoders;

		private static readonly IStringSegmentDecoder[] stringSegmentDecoders;

		private static readonly IExtDecoder[] extDecoders;

		private static readonly IExtHeaderDecoder[] extHeaderDecoders;

		private static readonly IDateTimeDecoder[] dateTimeDecoders;

		private static readonly IReadNextDecoder[] readNextDecoders;

		static MessagePackBinary()
		{
			mapHeaderDecoders = new IMapHeaderDecoder[256];
			arrayHeaderDecoders = new IArrayHeaderDecoder[256];
			booleanDecoders = new IBooleanDecoder[256];
			byteDecoders = new IByteDecoder[256];
			bytesDecoders = new IBytesDecoder[256];
			bytesSegmentDecoders = new IBytesSegmentDecoder[256];
			sbyteDecoders = new ISByteDecoder[256];
			singleDecoders = new ISingleDecoder[256];
			doubleDecoders = new IDoubleDecoder[256];
			int16Decoders = new IInt16Decoder[256];
			int32Decoders = new IInt32Decoder[256];
			int64Decoders = new IInt64Decoder[256];
			uint16Decoders = new IUInt16Decoder[256];
			uint32Decoders = new IUInt32Decoder[256];
			uint64Decoders = new IUInt64Decoder[256];
			stringDecoders = new IStringDecoder[256];
			stringSegmentDecoders = new IStringSegmentDecoder[256];
			extDecoders = new IExtDecoder[256];
			extHeaderDecoders = new IExtHeaderDecoder[256];
			dateTimeDecoders = new IDateTimeDecoder[256];
			readNextDecoders = new IReadNextDecoder[256];
			for (int i = 0; i < 256; i++)
			{
				mapHeaderDecoders[i] = InvalidMapHeader.Instance;
				arrayHeaderDecoders[i] = InvalidArrayHeader.Instance;
				booleanDecoders[i] = InvalidBoolean.Instance;
				byteDecoders[i] = InvalidByte.Instance;
				bytesDecoders[i] = InvalidBytes.Instance;
				bytesSegmentDecoders[i] = InvalidBytesSegment.Instance;
				sbyteDecoders[i] = InvalidSByte.Instance;
				singleDecoders[i] = InvalidSingle.Instance;
				doubleDecoders[i] = InvalidDouble.Instance;
				int16Decoders[i] = InvalidInt16.Instance;
				int32Decoders[i] = InvalidInt32.Instance;
				int64Decoders[i] = InvalidInt64.Instance;
				uint16Decoders[i] = InvalidUInt16.Instance;
				uint32Decoders[i] = InvalidUInt32.Instance;
				uint64Decoders[i] = InvalidUInt64.Instance;
				stringDecoders[i] = InvalidString.Instance;
				stringSegmentDecoders[i] = InvalidStringSegment.Instance;
				extDecoders[i] = InvalidExt.Instance;
				extHeaderDecoders[i] = InvalidExtHeader.Instance;
				dateTimeDecoders[i] = InvalidDateTime.Instance;
			}
			for (int j = 224; j <= 255; j++)
			{
				sbyteDecoders[j] = FixSByte.Instance;
				int16Decoders[j] = FixNegativeInt16.Instance;
				int32Decoders[j] = FixNegativeInt32.Instance;
				int64Decoders[j] = FixNegativeInt64.Instance;
				singleDecoders[j] = FixNegativeFloat.Instance;
				doubleDecoders[j] = FixNegativeDouble.Instance;
				readNextDecoders[j] = ReadNext1.Instance;
			}
			for (int k = 0; k <= 127; k++)
			{
				byteDecoders[k] = FixByte.Instance;
				sbyteDecoders[k] = FixSByte.Instance;
				int16Decoders[k] = FixInt16.Instance;
				int32Decoders[k] = FixInt32.Instance;
				int64Decoders[k] = FixInt64.Instance;
				uint16Decoders[k] = FixUInt16.Instance;
				uint32Decoders[k] = FixUInt32.Instance;
				uint64Decoders[k] = FixUInt64.Instance;
				singleDecoders[k] = FixFloat.Instance;
				doubleDecoders[k] = FixDouble.Instance;
				readNextDecoders[k] = ReadNext1.Instance;
			}
			byteDecoders[204] = UInt8Byte.Instance;
			sbyteDecoders[208] = Int8SByte.Instance;
			int16Decoders[204] = UInt8Int16.Instance;
			int16Decoders[205] = UInt16Int16.Instance;
			int16Decoders[208] = Int8Int16.Instance;
			int16Decoders[209] = Int16Int16.Instance;
			int32Decoders[204] = UInt8Int32.Instance;
			int32Decoders[205] = UInt16Int32.Instance;
			int32Decoders[206] = UInt32Int32.Instance;
			int32Decoders[208] = Int8Int32.Instance;
			int32Decoders[209] = Int16Int32.Instance;
			int32Decoders[210] = Int32Int32.Instance;
			int64Decoders[204] = UInt8Int64.Instance;
			int64Decoders[205] = UInt16Int64.Instance;
			int64Decoders[206] = UInt32Int64.Instance;
			int64Decoders[207] = UInt64Int64.Instance;
			int64Decoders[208] = Int8Int64.Instance;
			int64Decoders[209] = Int16Int64.Instance;
			int64Decoders[210] = Int32Int64.Instance;
			int64Decoders[211] = Int64Int64.Instance;
			uint16Decoders[204] = UInt8UInt16.Instance;
			uint16Decoders[205] = UInt16UInt16.Instance;
			uint32Decoders[204] = UInt8UInt32.Instance;
			uint32Decoders[205] = UInt16UInt32.Instance;
			uint32Decoders[206] = UInt32UInt32.Instance;
			uint64Decoders[204] = UInt8UInt64.Instance;
			uint64Decoders[205] = UInt16UInt64.Instance;
			uint64Decoders[206] = UInt32UInt64.Instance;
			uint64Decoders[207] = UInt64UInt64.Instance;
			singleDecoders[202] = Float32Single.Instance;
			singleDecoders[208] = Int8Single.Instance;
			singleDecoders[209] = Int16Single.Instance;
			singleDecoders[210] = Int32Single.Instance;
			singleDecoders[211] = Int64Single.Instance;
			singleDecoders[204] = UInt8Single.Instance;
			singleDecoders[205] = UInt16Single.Instance;
			singleDecoders[206] = UInt32Single.Instance;
			singleDecoders[207] = UInt64Single.Instance;
			doubleDecoders[202] = Float32Double.Instance;
			doubleDecoders[203] = Float64Double.Instance;
			doubleDecoders[208] = Int8Double.Instance;
			doubleDecoders[209] = Int16Double.Instance;
			doubleDecoders[210] = Int32Double.Instance;
			doubleDecoders[211] = Int64Double.Instance;
			doubleDecoders[204] = UInt8Double.Instance;
			doubleDecoders[205] = UInt16Double.Instance;
			doubleDecoders[206] = UInt32Double.Instance;
			doubleDecoders[207] = UInt64Double.Instance;
			readNextDecoders[208] = ReadNext2.Instance;
			readNextDecoders[209] = ReadNext3.Instance;
			readNextDecoders[210] = ReadNext5.Instance;
			readNextDecoders[211] = ReadNext9.Instance;
			readNextDecoders[204] = ReadNext2.Instance;
			readNextDecoders[205] = ReadNext3.Instance;
			readNextDecoders[206] = ReadNext5.Instance;
			readNextDecoders[207] = ReadNext9.Instance;
			readNextDecoders[202] = ReadNext5.Instance;
			readNextDecoders[203] = ReadNext9.Instance;
			for (int l = 128; l <= 143; l++)
			{
				mapHeaderDecoders[l] = FixMapHeader.Instance;
				readNextDecoders[l] = ReadNext1.Instance;
			}
			mapHeaderDecoders[222] = Map16Header.Instance;
			mapHeaderDecoders[223] = Map32Header.Instance;
			readNextDecoders[222] = ReadNextMap.Instance;
			readNextDecoders[223] = ReadNextMap.Instance;
			for (int m = 144; m <= 159; m++)
			{
				arrayHeaderDecoders[m] = FixArrayHeader.Instance;
				readNextDecoders[m] = ReadNext1.Instance;
			}
			arrayHeaderDecoders[220] = Array16Header.Instance;
			arrayHeaderDecoders[221] = Array32Header.Instance;
			readNextDecoders[220] = ReadNextArray.Instance;
			readNextDecoders[221] = ReadNextArray.Instance;
			for (int n = 160; n <= 191; n++)
			{
				stringDecoders[n] = FixString.Instance;
				stringSegmentDecoders[n] = FixStringSegment.Instance;
				readNextDecoders[n] = ReadNextFixStr.Instance;
			}
			stringDecoders[217] = Str8String.Instance;
			stringDecoders[218] = Str16String.Instance;
			stringDecoders[219] = Str32String.Instance;
			stringSegmentDecoders[217] = Str8StringSegment.Instance;
			stringSegmentDecoders[218] = Str16StringSegment.Instance;
			stringSegmentDecoders[219] = Str32StringSegment.Instance;
			readNextDecoders[217] = ReadNextStr8.Instance;
			readNextDecoders[218] = ReadNextStr16.Instance;
			readNextDecoders[219] = ReadNextStr32.Instance;
			stringDecoders[192] = NilString.Instance;
			stringSegmentDecoders[192] = NilStringSegment.Instance;
			bytesDecoders[192] = NilBytes.Instance;
			bytesSegmentDecoders[192] = NilBytesSegment.Instance;
			readNextDecoders[192] = ReadNext1.Instance;
			booleanDecoders[194] = False.Instance;
			booleanDecoders[195] = True.Instance;
			readNextDecoders[194] = ReadNext1.Instance;
			readNextDecoders[195] = ReadNext1.Instance;
			bytesDecoders[196] = Bin8Bytes.Instance;
			bytesDecoders[197] = Bin16Bytes.Instance;
			bytesDecoders[198] = Bin32Bytes.Instance;
			bytesSegmentDecoders[196] = Bin8BytesSegment.Instance;
			bytesSegmentDecoders[197] = Bin16BytesSegment.Instance;
			bytesSegmentDecoders[198] = Bin32BytesSegment.Instance;
			readNextDecoders[196] = ReadNextBin8.Instance;
			readNextDecoders[197] = ReadNextBin16.Instance;
			readNextDecoders[198] = ReadNextBin32.Instance;
			extDecoders[212] = FixExt1.Instance;
			extDecoders[213] = FixExt2.Instance;
			extDecoders[214] = FixExt4.Instance;
			extDecoders[215] = FixExt8.Instance;
			extDecoders[216] = FixExt16.Instance;
			extDecoders[199] = Ext8.Instance;
			extDecoders[200] = Ext16.Instance;
			extDecoders[201] = Ext32.Instance;
			extHeaderDecoders[212] = FixExt1Header.Instance;
			extHeaderDecoders[213] = FixExt2Header.Instance;
			extHeaderDecoders[214] = FixExt4Header.Instance;
			extHeaderDecoders[215] = FixExt8Header.Instance;
			extHeaderDecoders[216] = FixExt16Header.Instance;
			extHeaderDecoders[199] = Ext8Header.Instance;
			extHeaderDecoders[200] = Ext16Header.Instance;
			extHeaderDecoders[201] = Ext32Header.Instance;
			readNextDecoders[212] = ReadNext3.Instance;
			readNextDecoders[213] = ReadNext4.Instance;
			readNextDecoders[214] = ReadNext6.Instance;
			readNextDecoders[215] = ReadNext10.Instance;
			readNextDecoders[216] = ReadNext18.Instance;
			readNextDecoders[199] = ReadNextExt8.Instance;
			readNextDecoders[200] = ReadNextExt16.Instance;
			readNextDecoders[201] = ReadNextExt32.Instance;
			dateTimeDecoders[214] = FixExt4DateTime.Instance;
			dateTimeDecoders[215] = FixExt8DateTime.Instance;
			dateTimeDecoders[199] = Ext8DateTime.Instance;
		}

		public static void EnsureCapacity(ref byte[] bytes, int offset, int appendLength)
		{
			int num = offset + appendLength;
			if (bytes == null)
			{
				bytes = new byte[num];
				return;
			}
			int num2 = bytes.Length;
			if (num <= num2)
			{
				return;
			}
			int num3 = num;
			if (num3 < 256)
			{
				num3 = 256;
				FastResize(ref bytes, num3);
				return;
			}
			if (num2 == 2147483591)
			{
				throw new InvalidOperationException("byte[] size reached maximum size of array(0x7FFFFFC7), can not write to single byte[]. Details: https://msdn.microsoft.com/en-us/library/system.array");
			}
			int num4 = num2 * 2;
			if (num4 < 0)
			{
				num3 = 2147483591;
			}
			else if (num3 < num4)
			{
				num3 = num4;
			}
			FastResize(ref bytes, num3);
		}

		public static void FastResize(ref byte[] array, int newSize)
		{
			if (newSize < 0)
			{
				throw new ArgumentOutOfRangeException("newSize");
			}
			byte[] array2 = array;
			if (array2 == null)
			{
				array = new byte[newSize];
			}
			else if (array2.Length != newSize)
			{
				byte[] array3 = new byte[newSize];
				Buffer.BlockCopy(array2, 0, array3, 0, (array2.Length > newSize) ? newSize : array2.Length);
				array = array3;
			}
		}

		public static byte[] FastCloneWithResize(byte[] array, int newSize)
		{
			if (newSize < 0)
			{
				throw new ArgumentOutOfRangeException("newSize");
			}
			byte[] array2 = array;
			if (array2 == null)
			{
				array = new byte[newSize];
				return array;
			}
			byte[] array3 = new byte[newSize];
			Buffer.BlockCopy(array2, 0, array3, 0, (array2.Length > newSize) ? newSize : array2.Length);
			return array3;
		}

		public static MessagePackType GetMessagePackType(byte[] bytes, int offset)
		{
			return MessagePackCode.ToMessagePackType(bytes[offset]);
		}

		public static int ReadNext(byte[] bytes, int offset)
		{
			return readNextDecoders[bytes[offset]].Read(bytes, offset);
		}

		public static int ReadNextBlock(byte[] bytes, int offset)
		{
			switch (GetMessagePackType(bytes, offset))
			{
			default:
				return ReadNext(bytes, offset);
			case MessagePackType.Array:
			{
				int num3 = offset;
				int readSize2;
				int num4 = ReadArrayHeader(bytes, offset, out readSize2);
				offset += readSize2;
				for (int j = 0; j < num4; j++)
				{
					offset += ReadNextBlock(bytes, offset);
				}
				return offset - num3;
			}
			case MessagePackType.Map:
			{
				int num = offset;
				int readSize;
				int num2 = ReadMapHeader(bytes, offset, out readSize);
				offset += readSize;
				for (int i = 0; i < num2; i++)
				{
					offset += ReadNextBlock(bytes, offset);
					offset += ReadNextBlock(bytes, offset);
				}
				return offset - num;
			}
			}
		}

		public static int WriteNil(ref byte[] bytes, int offset)
		{
			EnsureCapacity(ref bytes, offset, 1);
			bytes[offset] = 192;
			return 1;
		}

		public static Nil ReadNil(byte[] bytes, int offset, out int readSize)
		{
			if (bytes[offset] == 192)
			{
				readSize = 1;
				return Nil.Default;
			}
			throw new InvalidOperationException($"code is invalid. code:{bytes[offset]} format:{MessagePackCode.ToFormatName(bytes[offset])}");
		}

		public static bool IsNil(byte[] bytes, int offset)
		{
			return bytes[offset] == 192;
		}

		public static int WriteRaw(ref byte[] bytes, int offset, byte[] rawMessagePackBlock)
		{
			EnsureCapacity(ref bytes, offset, rawMessagePackBlock.Length);
			Buffer.BlockCopy(rawMessagePackBlock, 0, bytes, offset, rawMessagePackBlock.Length);
			return rawMessagePackBlock.Length;
		}

		public static int WriteFixedMapHeaderUnsafe(ref byte[] bytes, int offset, int count)
		{
			EnsureCapacity(ref bytes, offset, 1);
			bytes[offset] = (byte)(0x80 | count);
			return 1;
		}

		public static int WriteMapHeader(ref byte[] bytes, int offset, int count)
		{
			return WriteMapHeader(ref bytes, offset, checked((uint)count));
		}

		public static int WriteMapHeader(ref byte[] bytes, int offset, uint count)
		{
			if (count <= 15)
			{
				EnsureCapacity(ref bytes, offset, 1);
				bytes[offset] = (byte)(0x80 | count);
				return 1;
			}
			if (count <= 65535)
			{
				EnsureCapacity(ref bytes, offset, 3);
				bytes[offset] = 222;
				bytes[offset + 1] = (byte)(count >> 8);
				bytes[offset + 2] = (byte)count;
				return 3;
			}
			EnsureCapacity(ref bytes, offset, 5);
			bytes[offset] = 223;
			bytes[offset + 1] = (byte)(count >> 24);
			bytes[offset + 2] = (byte)(count >> 16);
			bytes[offset + 3] = (byte)(count >> 8);
			bytes[offset + 4] = (byte)count;
			return 5;
		}

		public static int WriteMapHeaderForceMap32Block(ref byte[] bytes, int offset, uint count)
		{
			EnsureCapacity(ref bytes, offset, 5);
			bytes[offset] = 223;
			bytes[offset + 1] = (byte)(count >> 24);
			bytes[offset + 2] = (byte)(count >> 16);
			bytes[offset + 3] = (byte)(count >> 8);
			bytes[offset + 4] = (byte)count;
			return 5;
		}

		public static int ReadMapHeader(byte[] bytes, int offset, out int readSize)
		{
			return checked((int)mapHeaderDecoders[bytes[offset]].Read(bytes, offset, out readSize));
		}

		public static uint ReadMapHeaderRaw(byte[] bytes, int offset, out int readSize)
		{
			return mapHeaderDecoders[bytes[offset]].Read(bytes, offset, out readSize);
		}

		public static int GetArrayHeaderLength(int count)
		{
			if (count <= 15)
			{
				return 1;
			}
			if (count <= 65535)
			{
				return 3;
			}
			return 5;
		}

		public static int WriteFixedArrayHeaderUnsafe(ref byte[] bytes, int offset, int count)
		{
			EnsureCapacity(ref bytes, offset, 1);
			bytes[offset] = (byte)(0x90 | count);
			return 1;
		}

		public static int WriteArrayHeader(ref byte[] bytes, int offset, int count)
		{
			return WriteArrayHeader(ref bytes, offset, checked((uint)count));
		}

		public static int WriteArrayHeader(ref byte[] bytes, int offset, uint count)
		{
			if (count <= 15)
			{
				EnsureCapacity(ref bytes, offset, 1);
				bytes[offset] = (byte)(0x90 | count);
				return 1;
			}
			if (count <= 65535)
			{
				EnsureCapacity(ref bytes, offset, 3);
				bytes[offset] = 220;
				bytes[offset + 1] = (byte)(count >> 8);
				bytes[offset + 2] = (byte)count;
				return 3;
			}
			EnsureCapacity(ref bytes, offset, 5);
			bytes[offset] = 221;
			bytes[offset + 1] = (byte)(count >> 24);
			bytes[offset + 2] = (byte)(count >> 16);
			bytes[offset + 3] = (byte)(count >> 8);
			bytes[offset + 4] = (byte)count;
			return 5;
		}

		public static int WriteArrayHeaderForceArray32Block(ref byte[] bytes, int offset, uint count)
		{
			EnsureCapacity(ref bytes, offset, 5);
			bytes[offset] = 221;
			bytes[offset + 1] = (byte)(count >> 24);
			bytes[offset + 2] = (byte)(count >> 16);
			bytes[offset + 3] = (byte)(count >> 8);
			bytes[offset + 4] = (byte)count;
			return 5;
		}

		public static int ReadArrayHeader(byte[] bytes, int offset, out int readSize)
		{
			return checked((int)arrayHeaderDecoders[bytes[offset]].Read(bytes, offset, out readSize));
		}

		public static uint ReadArrayHeaderRaw(byte[] bytes, int offset, out int readSize)
		{
			return arrayHeaderDecoders[bytes[offset]].Read(bytes, offset, out readSize);
		}

		public static int WriteBoolean(ref byte[] bytes, int offset, bool value)
		{
			EnsureCapacity(ref bytes, offset, 1);
			bytes[offset] = (byte)(value ? 195 : 194);
			return 1;
		}

		public static bool ReadBoolean(byte[] bytes, int offset, out int readSize)
		{
			readSize = 1;
			return booleanDecoders[bytes[offset]].Read();
		}

		public static int WriteByte(ref byte[] bytes, int offset, byte value)
		{
			if (value <= 127)
			{
				EnsureCapacity(ref bytes, offset, 1);
				bytes[offset] = value;
				return 1;
			}
			EnsureCapacity(ref bytes, offset, 2);
			bytes[offset] = 204;
			bytes[offset + 1] = value;
			return 2;
		}

		public static int WriteByteForceByteBlock(ref byte[] bytes, int offset, byte value)
		{
			EnsureCapacity(ref bytes, offset, 2);
			bytes[offset] = 204;
			bytes[offset + 1] = value;
			return 2;
		}

		public static byte ReadByte(byte[] bytes, int offset, out int readSize)
		{
			return byteDecoders[bytes[offset]].Read(bytes, offset, out readSize);
		}

		public static int WriteBytes(ref byte[] bytes, int offset, byte[] value)
		{
			if (value == null)
			{
				return WriteNil(ref bytes, offset);
			}
			return WriteBytes(ref bytes, offset, value, 0, value.Length);
		}

		public static int WriteBytes(ref byte[] dest, int dstOffset, byte[] src, int srcOffset, int count)
		{
			if (src == null)
			{
				return WriteNil(ref dest, dstOffset);
			}
			if (count <= 255)
			{
				int num = count + 2;
				EnsureCapacity(ref dest, dstOffset, num);
				dest[dstOffset] = 196;
				dest[dstOffset + 1] = (byte)count;
				Buffer.BlockCopy(src, srcOffset, dest, dstOffset + 2, count);
				return num;
			}
			if (count <= 65535)
			{
				int num2 = count + 3;
				EnsureCapacity(ref dest, dstOffset, num2);
				dest[dstOffset] = 197;
				dest[dstOffset + 1] = (byte)(count >> 8);
				dest[dstOffset + 2] = (byte)count;
				Buffer.BlockCopy(src, srcOffset, dest, dstOffset + 3, count);
				return num2;
			}
			int num3 = count + 5;
			EnsureCapacity(ref dest, dstOffset, num3);
			dest[dstOffset] = 198;
			dest[dstOffset + 1] = (byte)(count >> 24);
			dest[dstOffset + 2] = (byte)(count >> 16);
			dest[dstOffset + 3] = (byte)(count >> 8);
			dest[dstOffset + 4] = (byte)count;
			Buffer.BlockCopy(src, srcOffset, dest, dstOffset + 5, count);
			return num3;
		}

		public static byte[] ReadBytes(byte[] bytes, int offset, out int readSize)
		{
			return bytesDecoders[bytes[offset]].Read(bytes, offset, out readSize);
		}

		public static ArraySegment<byte> ReadBytesSegment(byte[] bytes, int offset, out int readSize)
		{
			return bytesSegmentDecoders[bytes[offset]].Read(bytes, offset, out readSize);
		}

		public static int WriteSByte(ref byte[] bytes, int offset, sbyte value)
		{
			if (value < -32)
			{
				EnsureCapacity(ref bytes, offset, 2);
				bytes[offset] = 208;
				bytes[offset + 1] = (byte)value;
				return 2;
			}
			EnsureCapacity(ref bytes, offset, 1);
			bytes[offset] = (byte)value;
			return 1;
		}

		public static int WriteSByteForceSByteBlock(ref byte[] bytes, int offset, sbyte value)
		{
			EnsureCapacity(ref bytes, offset, 2);
			bytes[offset] = 208;
			bytes[offset + 1] = (byte)value;
			return 2;
		}

		public static sbyte ReadSByte(byte[] bytes, int offset, out int readSize)
		{
			return sbyteDecoders[bytes[offset]].Read(bytes, offset, out readSize);
		}

		public static int WriteSingle(ref byte[] bytes, int offset, float value)
		{
			EnsureCapacity(ref bytes, offset, 5);
			bytes[offset] = 202;
			Float32Bits float32Bits = new Float32Bits(value);
			if (BitConverter.IsLittleEndian)
			{
				bytes[offset + 1] = float32Bits.Byte3;
				bytes[offset + 2] = float32Bits.Byte2;
				bytes[offset + 3] = float32Bits.Byte1;
				bytes[offset + 4] = float32Bits.Byte0;
			}
			else
			{
				bytes[offset + 1] = float32Bits.Byte0;
				bytes[offset + 2] = float32Bits.Byte1;
				bytes[offset + 3] = float32Bits.Byte2;
				bytes[offset + 4] = float32Bits.Byte3;
			}
			return 5;
		}

		public static float ReadSingle(byte[] bytes, int offset, out int readSize)
		{
			return singleDecoders[bytes[offset]].Read(bytes, offset, out readSize);
		}

		public static int WriteDouble(ref byte[] bytes, int offset, double value)
		{
			EnsureCapacity(ref bytes, offset, 9);
			bytes[offset] = 203;
			Float64Bits float64Bits = new Float64Bits(value);
			if (BitConverter.IsLittleEndian)
			{
				bytes[offset + 1] = float64Bits.Byte7;
				bytes[offset + 2] = float64Bits.Byte6;
				bytes[offset + 3] = float64Bits.Byte5;
				bytes[offset + 4] = float64Bits.Byte4;
				bytes[offset + 5] = float64Bits.Byte3;
				bytes[offset + 6] = float64Bits.Byte2;
				bytes[offset + 7] = float64Bits.Byte1;
				bytes[offset + 8] = float64Bits.Byte0;
			}
			else
			{
				bytes[offset + 1] = float64Bits.Byte0;
				bytes[offset + 2] = float64Bits.Byte1;
				bytes[offset + 3] = float64Bits.Byte2;
				bytes[offset + 4] = float64Bits.Byte3;
				bytes[offset + 5] = float64Bits.Byte4;
				bytes[offset + 6] = float64Bits.Byte5;
				bytes[offset + 7] = float64Bits.Byte6;
				bytes[offset + 8] = float64Bits.Byte7;
			}
			return 9;
		}

		public static double ReadDouble(byte[] bytes, int offset, out int readSize)
		{
			return doubleDecoders[bytes[offset]].Read(bytes, offset, out readSize);
		}

		public static int WriteInt16(ref byte[] bytes, int offset, short value)
		{
			if (value >= 0)
			{
				if (value <= 127)
				{
					EnsureCapacity(ref bytes, offset, 1);
					bytes[offset] = (byte)value;
					return 1;
				}
				if (value <= 255)
				{
					EnsureCapacity(ref bytes, offset, 2);
					bytes[offset] = 204;
					bytes[offset + 1] = (byte)value;
					return 2;
				}
				EnsureCapacity(ref bytes, offset, 3);
				bytes[offset] = 205;
				bytes[offset + 1] = (byte)(value >> 8);
				bytes[offset + 2] = (byte)value;
				return 3;
			}
			if (-32 <= value)
			{
				EnsureCapacity(ref bytes, offset, 1);
				bytes[offset] = (byte)value;
				return 1;
			}
			if (-128 <= value)
			{
				EnsureCapacity(ref bytes, offset, 2);
				bytes[offset] = 208;
				bytes[offset + 1] = (byte)value;
				return 2;
			}
			EnsureCapacity(ref bytes, offset, 3);
			bytes[offset] = 209;
			bytes[offset + 1] = (byte)(value >> 8);
			bytes[offset + 2] = (byte)value;
			return 3;
		}

		public static int WriteInt16ForceInt16Block(ref byte[] bytes, int offset, short value)
		{
			EnsureCapacity(ref bytes, offset, 3);
			bytes[offset] = 209;
			bytes[offset + 1] = (byte)(value >> 8);
			bytes[offset + 2] = (byte)value;
			return 3;
		}

		public static short ReadInt16(byte[] bytes, int offset, out int readSize)
		{
			return int16Decoders[bytes[offset]].Read(bytes, offset, out readSize);
		}

		public static int WritePositiveFixedIntUnsafe(ref byte[] bytes, int offset, int value)
		{
			EnsureCapacity(ref bytes, offset, 1);
			bytes[offset] = (byte)value;
			return 1;
		}

		public static int WriteInt32(ref byte[] bytes, int offset, int value)
		{
			if (value >= 0)
			{
				if (value <= 127)
				{
					EnsureCapacity(ref bytes, offset, 1);
					bytes[offset] = (byte)value;
					return 1;
				}
				if (value <= 255)
				{
					EnsureCapacity(ref bytes, offset, 2);
					bytes[offset] = 204;
					bytes[offset + 1] = (byte)value;
					return 2;
				}
				if (value <= 65535)
				{
					EnsureCapacity(ref bytes, offset, 3);
					bytes[offset] = 205;
					bytes[offset + 1] = (byte)(value >> 8);
					bytes[offset + 2] = (byte)value;
					return 3;
				}
				EnsureCapacity(ref bytes, offset, 5);
				bytes[offset] = 206;
				bytes[offset + 1] = (byte)(value >> 24);
				bytes[offset + 2] = (byte)(value >> 16);
				bytes[offset + 3] = (byte)(value >> 8);
				bytes[offset + 4] = (byte)value;
				return 5;
			}
			if (-32 <= value)
			{
				EnsureCapacity(ref bytes, offset, 1);
				bytes[offset] = (byte)value;
				return 1;
			}
			if (-128 <= value)
			{
				EnsureCapacity(ref bytes, offset, 2);
				bytes[offset] = 208;
				bytes[offset + 1] = (byte)value;
				return 2;
			}
			if (-32768 <= value)
			{
				EnsureCapacity(ref bytes, offset, 3);
				bytes[offset] = 209;
				bytes[offset + 1] = (byte)(value >> 8);
				bytes[offset + 2] = (byte)value;
				return 3;
			}
			EnsureCapacity(ref bytes, offset, 5);
			bytes[offset] = 210;
			bytes[offset + 1] = (byte)(value >> 24);
			bytes[offset + 2] = (byte)(value >> 16);
			bytes[offset + 3] = (byte)(value >> 8);
			bytes[offset + 4] = (byte)value;
			return 5;
		}

		public static int WriteInt32ForceInt32Block(ref byte[] bytes, int offset, int value)
		{
			EnsureCapacity(ref bytes, offset, 5);
			bytes[offset] = 210;
			bytes[offset + 1] = (byte)(value >> 24);
			bytes[offset + 2] = (byte)(value >> 16);
			bytes[offset + 3] = (byte)(value >> 8);
			bytes[offset + 4] = (byte)value;
			return 5;
		}

		public static int ReadInt32(byte[] bytes, int offset, out int readSize)
		{
			return int32Decoders[bytes[offset]].Read(bytes, offset, out readSize);
		}

		public static int WriteInt64(ref byte[] bytes, int offset, long value)
		{
			if (value >= 0)
			{
				if (value <= 127)
				{
					EnsureCapacity(ref bytes, offset, 1);
					bytes[offset] = (byte)value;
					return 1;
				}
				if (value <= 255)
				{
					EnsureCapacity(ref bytes, offset, 2);
					bytes[offset] = 204;
					bytes[offset + 1] = (byte)value;
					return 2;
				}
				if (value <= 65535)
				{
					EnsureCapacity(ref bytes, offset, 3);
					bytes[offset] = 205;
					bytes[offset + 1] = (byte)(value >> 8);
					bytes[offset + 2] = (byte)value;
					return 3;
				}
				if (value <= uint.MaxValue)
				{
					EnsureCapacity(ref bytes, offset, 5);
					bytes[offset] = 206;
					bytes[offset + 1] = (byte)(value >> 24);
					bytes[offset + 2] = (byte)(value >> 16);
					bytes[offset + 3] = (byte)(value >> 8);
					bytes[offset + 4] = (byte)value;
					return 5;
				}
				EnsureCapacity(ref bytes, offset, 9);
				bytes[offset] = 207;
				bytes[offset + 1] = (byte)(value >> 56);
				bytes[offset + 2] = (byte)(value >> 48);
				bytes[offset + 3] = (byte)(value >> 40);
				bytes[offset + 4] = (byte)(value >> 32);
				bytes[offset + 5] = (byte)(value >> 24);
				bytes[offset + 6] = (byte)(value >> 16);
				bytes[offset + 7] = (byte)(value >> 8);
				bytes[offset + 8] = (byte)value;
				return 9;
			}
			if (-32 <= value)
			{
				EnsureCapacity(ref bytes, offset, 1);
				bytes[offset] = (byte)value;
				return 1;
			}
			if (-128 <= value)
			{
				EnsureCapacity(ref bytes, offset, 2);
				bytes[offset] = 208;
				bytes[offset + 1] = (byte)value;
				return 2;
			}
			if (-32768 <= value)
			{
				EnsureCapacity(ref bytes, offset, 3);
				bytes[offset] = 209;
				bytes[offset + 1] = (byte)(value >> 8);
				bytes[offset + 2] = (byte)value;
				return 3;
			}
			if (int.MinValue <= value)
			{
				EnsureCapacity(ref bytes, offset, 5);
				bytes[offset] = 210;
				bytes[offset + 1] = (byte)(value >> 24);
				bytes[offset + 2] = (byte)(value >> 16);
				bytes[offset + 3] = (byte)(value >> 8);
				bytes[offset + 4] = (byte)value;
				return 5;
			}
			EnsureCapacity(ref bytes, offset, 9);
			bytes[offset] = 211;
			bytes[offset + 1] = (byte)(value >> 56);
			bytes[offset + 2] = (byte)(value >> 48);
			bytes[offset + 3] = (byte)(value >> 40);
			bytes[offset + 4] = (byte)(value >> 32);
			bytes[offset + 5] = (byte)(value >> 24);
			bytes[offset + 6] = (byte)(value >> 16);
			bytes[offset + 7] = (byte)(value >> 8);
			bytes[offset + 8] = (byte)value;
			return 9;
		}

		public static int WriteInt64ForceInt64Block(ref byte[] bytes, int offset, long value)
		{
			EnsureCapacity(ref bytes, offset, 9);
			bytes[offset] = 211;
			bytes[offset + 1] = (byte)(value >> 56);
			bytes[offset + 2] = (byte)(value >> 48);
			bytes[offset + 3] = (byte)(value >> 40);
			bytes[offset + 4] = (byte)(value >> 32);
			bytes[offset + 5] = (byte)(value >> 24);
			bytes[offset + 6] = (byte)(value >> 16);
			bytes[offset + 7] = (byte)(value >> 8);
			bytes[offset + 8] = (byte)value;
			return 9;
		}

		public static long ReadInt64(byte[] bytes, int offset, out int readSize)
		{
			return int64Decoders[bytes[offset]].Read(bytes, offset, out readSize);
		}

		public static int WriteUInt16(ref byte[] bytes, int offset, ushort value)
		{
			if (value <= 127)
			{
				EnsureCapacity(ref bytes, offset, 1);
				bytes[offset] = (byte)value;
				return 1;
			}
			if (value <= 255)
			{
				EnsureCapacity(ref bytes, offset, 2);
				bytes[offset] = 204;
				bytes[offset + 1] = (byte)value;
				return 2;
			}
			EnsureCapacity(ref bytes, offset, 3);
			bytes[offset] = 205;
			bytes[offset + 1] = (byte)(value >> 8);
			bytes[offset + 2] = (byte)value;
			return 3;
		}

		public static int WriteUInt16ForceUInt16Block(ref byte[] bytes, int offset, ushort value)
		{
			EnsureCapacity(ref bytes, offset, 3);
			bytes[offset] = 205;
			bytes[offset + 1] = (byte)(value >> 8);
			bytes[offset + 2] = (byte)value;
			return 3;
		}

		public static ushort ReadUInt16(byte[] bytes, int offset, out int readSize)
		{
			return uint16Decoders[bytes[offset]].Read(bytes, offset, out readSize);
		}

		public static int WriteUInt32(ref byte[] bytes, int offset, uint value)
		{
			if (value <= 127)
			{
				EnsureCapacity(ref bytes, offset, 1);
				bytes[offset] = (byte)value;
				return 1;
			}
			if (value <= 255)
			{
				EnsureCapacity(ref bytes, offset, 2);
				bytes[offset] = 204;
				bytes[offset + 1] = (byte)value;
				return 2;
			}
			if (value <= 65535)
			{
				EnsureCapacity(ref bytes, offset, 3);
				bytes[offset] = 205;
				bytes[offset + 1] = (byte)(value >> 8);
				bytes[offset + 2] = (byte)value;
				return 3;
			}
			EnsureCapacity(ref bytes, offset, 5);
			bytes[offset] = 206;
			bytes[offset + 1] = (byte)(value >> 24);
			bytes[offset + 2] = (byte)(value >> 16);
			bytes[offset + 3] = (byte)(value >> 8);
			bytes[offset + 4] = (byte)value;
			return 5;
		}

		public static int WriteUInt32ForceUInt32Block(ref byte[] bytes, int offset, uint value)
		{
			EnsureCapacity(ref bytes, offset, 5);
			bytes[offset] = 206;
			bytes[offset + 1] = (byte)(value >> 24);
			bytes[offset + 2] = (byte)(value >> 16);
			bytes[offset + 3] = (byte)(value >> 8);
			bytes[offset + 4] = (byte)value;
			return 5;
		}

		public static uint ReadUInt32(byte[] bytes, int offset, out int readSize)
		{
			return uint32Decoders[bytes[offset]].Read(bytes, offset, out readSize);
		}

		public static int WriteUInt64(ref byte[] bytes, int offset, ulong value)
		{
			if (value <= 127)
			{
				EnsureCapacity(ref bytes, offset, 1);
				bytes[offset] = (byte)value;
				return 1;
			}
			if (value <= 255)
			{
				EnsureCapacity(ref bytes, offset, 2);
				bytes[offset] = 204;
				bytes[offset + 1] = (byte)value;
				return 2;
			}
			if (value <= 65535)
			{
				EnsureCapacity(ref bytes, offset, 3);
				bytes[offset] = 205;
				bytes[offset + 1] = (byte)(value >> 8);
				bytes[offset + 2] = (byte)value;
				return 3;
			}
			if (value <= uint.MaxValue)
			{
				EnsureCapacity(ref bytes, offset, 5);
				bytes[offset] = 206;
				bytes[offset + 1] = (byte)(value >> 24);
				bytes[offset + 2] = (byte)(value >> 16);
				bytes[offset + 3] = (byte)(value >> 8);
				bytes[offset + 4] = (byte)value;
				return 5;
			}
			EnsureCapacity(ref bytes, offset, 9);
			bytes[offset] = 207;
			bytes[offset + 1] = (byte)(value >> 56);
			bytes[offset + 2] = (byte)(value >> 48);
			bytes[offset + 3] = (byte)(value >> 40);
			bytes[offset + 4] = (byte)(value >> 32);
			bytes[offset + 5] = (byte)(value >> 24);
			bytes[offset + 6] = (byte)(value >> 16);
			bytes[offset + 7] = (byte)(value >> 8);
			bytes[offset + 8] = (byte)value;
			return 9;
		}

		public static int WriteUInt64ForceUInt64Block(ref byte[] bytes, int offset, ulong value)
		{
			EnsureCapacity(ref bytes, offset, 9);
			bytes[offset] = 207;
			bytes[offset + 1] = (byte)(value >> 56);
			bytes[offset + 2] = (byte)(value >> 48);
			bytes[offset + 3] = (byte)(value >> 40);
			bytes[offset + 4] = (byte)(value >> 32);
			bytes[offset + 5] = (byte)(value >> 24);
			bytes[offset + 6] = (byte)(value >> 16);
			bytes[offset + 7] = (byte)(value >> 8);
			bytes[offset + 8] = (byte)value;
			return 9;
		}

		public static ulong ReadUInt64(byte[] bytes, int offset, out int readSize)
		{
			return uint64Decoders[bytes[offset]].Read(bytes, offset, out readSize);
		}

		public static int WriteChar(ref byte[] bytes, int offset, char value)
		{
			return WriteUInt16(ref bytes, offset, value);
		}

		public static char ReadChar(byte[] bytes, int offset, out int readSize)
		{
			return (char)ReadUInt16(bytes, offset, out readSize);
		}

		public static int WriteFixedStringUnsafe(ref byte[] bytes, int offset, string value, int byteCount)
		{
			EnsureCapacity(ref bytes, offset, byteCount + 1);
			bytes[offset] = (byte)(0xA0 | byteCount);
			StringEncoding.UTF8.GetBytes(value, 0, value.Length, bytes, offset + 1);
			return byteCount + 1;
		}

		public static int WriteStringUnsafe(ref byte[] bytes, int offset, string value, int byteCount)
		{
			if (byteCount <= 31)
			{
				EnsureCapacity(ref bytes, offset, byteCount + 1);
				bytes[offset] = (byte)(0xA0 | byteCount);
				StringEncoding.UTF8.GetBytes(value, 0, value.Length, bytes, offset + 1);
				return byteCount + 1;
			}
			if (byteCount <= 255)
			{
				EnsureCapacity(ref bytes, offset, byteCount + 2);
				bytes[offset] = 217;
				bytes[offset + 1] = (byte)byteCount;
				StringEncoding.UTF8.GetBytes(value, 0, value.Length, bytes, offset + 2);
				return byteCount + 2;
			}
			if (byteCount <= 65535)
			{
				EnsureCapacity(ref bytes, offset, byteCount + 3);
				bytes[offset] = 218;
				bytes[offset + 1] = (byte)(byteCount >> 8);
				bytes[offset + 2] = (byte)byteCount;
				StringEncoding.UTF8.GetBytes(value, 0, value.Length, bytes, offset + 3);
				return byteCount + 3;
			}
			EnsureCapacity(ref bytes, offset, byteCount + 5);
			bytes[offset] = 219;
			bytes[offset + 1] = (byte)(byteCount >> 24);
			bytes[offset + 2] = (byte)(byteCount >> 16);
			bytes[offset + 3] = (byte)(byteCount >> 8);
			bytes[offset + 4] = (byte)byteCount;
			StringEncoding.UTF8.GetBytes(value, 0, value.Length, bytes, offset + 5);
			return byteCount + 5;
		}

		public static int WriteStringBytes(ref byte[] bytes, int offset, byte[] utf8stringBytes)
		{
			int num = utf8stringBytes.Length;
			if (num <= 31)
			{
				EnsureCapacity(ref bytes, offset, num + 1);
				bytes[offset] = (byte)(0xA0 | num);
				Buffer.BlockCopy(utf8stringBytes, 0, bytes, offset + 1, num);
				return num + 1;
			}
			if (num <= 255)
			{
				EnsureCapacity(ref bytes, offset, num + 2);
				bytes[offset] = 217;
				bytes[offset + 1] = (byte)num;
				Buffer.BlockCopy(utf8stringBytes, 0, bytes, offset + 2, num);
				return num + 2;
			}
			if (num <= 65535)
			{
				EnsureCapacity(ref bytes, offset, num + 3);
				bytes[offset] = 218;
				bytes[offset + 1] = (byte)(num >> 8);
				bytes[offset + 2] = (byte)num;
				Buffer.BlockCopy(utf8stringBytes, 0, bytes, offset + 3, num);
				return num + 3;
			}
			EnsureCapacity(ref bytes, offset, num + 5);
			bytes[offset] = 219;
			bytes[offset + 1] = (byte)(num >> 24);
			bytes[offset + 2] = (byte)(num >> 16);
			bytes[offset + 3] = (byte)(num >> 8);
			bytes[offset + 4] = (byte)num;
			Buffer.BlockCopy(utf8stringBytes, 0, bytes, offset + 5, num);
			return num + 5;
		}

		public static byte[] GetEncodedStringBytes(string value)
		{
			int byteCount = StringEncoding.UTF8.GetByteCount(value);
			if (byteCount <= 31)
			{
				byte[] array = new byte[byteCount + 1];
				array[0] = (byte)(0xA0 | byteCount);
				StringEncoding.UTF8.GetBytes(value, 0, value.Length, array, 1);
				return array;
			}
			if (byteCount <= 255)
			{
				byte[] array2 = new byte[byteCount + 2];
				array2[0] = 217;
				array2[1] = (byte)byteCount;
				StringEncoding.UTF8.GetBytes(value, 0, value.Length, array2, 2);
				return array2;
			}
			if (byteCount <= 65535)
			{
				byte[] array3 = new byte[byteCount + 3];
				array3[0] = 218;
				array3[1] = (byte)(byteCount >> 8);
				array3[2] = (byte)byteCount;
				StringEncoding.UTF8.GetBytes(value, 0, value.Length, array3, 3);
				return array3;
			}
			byte[] array4 = new byte[byteCount + 5];
			array4[0] = 219;
			array4[1] = (byte)(byteCount >> 24);
			array4[2] = (byte)(byteCount >> 16);
			array4[3] = (byte)(byteCount >> 8);
			array4[4] = (byte)byteCount;
			StringEncoding.UTF8.GetBytes(value, 0, value.Length, array4, 5);
			return array4;
		}

		public static int WriteString(ref byte[] bytes, int offset, string value)
		{
			if (value == null)
			{
				return WriteNil(ref bytes, offset);
			}
			EnsureCapacity(ref bytes, offset, StringEncoding.UTF8.GetMaxByteCount(value.Length) + 5);
			int num = ((value.Length <= 31) ? 1 : ((value.Length <= 255) ? 2 : ((value.Length > 65535) ? 5 : 3)));
			int num2 = offset + num;
			int bytes2 = StringEncoding.UTF8.GetBytes(value, 0, value.Length, bytes, num2);
			if (bytes2 <= 31)
			{
				if (num != 1)
				{
					Buffer.BlockCopy(bytes, num2, bytes, offset + 1, bytes2);
				}
				bytes[offset] = (byte)(0xA0 | bytes2);
				return bytes2 + 1;
			}
			if (bytes2 <= 255)
			{
				if (num != 2)
				{
					Buffer.BlockCopy(bytes, num2, bytes, offset + 2, bytes2);
				}
				bytes[offset] = 217;
				bytes[offset + 1] = (byte)bytes2;
				return bytes2 + 2;
			}
			if (bytes2 <= 65535)
			{
				if (num != 3)
				{
					Buffer.BlockCopy(bytes, num2, bytes, offset + 3, bytes2);
				}
				bytes[offset] = 218;
				bytes[offset + 1] = (byte)(bytes2 >> 8);
				bytes[offset + 2] = (byte)bytes2;
				return bytes2 + 3;
			}
			if (num != 5)
			{
				Buffer.BlockCopy(bytes, num2, bytes, offset + 5, bytes2);
			}
			bytes[offset] = 219;
			bytes[offset + 1] = (byte)(bytes2 >> 24);
			bytes[offset + 2] = (byte)(bytes2 >> 16);
			bytes[offset + 3] = (byte)(bytes2 >> 8);
			bytes[offset + 4] = (byte)bytes2;
			return bytes2 + 5;
		}

		public static int WriteStringForceStr32Block(ref byte[] bytes, int offset, string value)
		{
			if (value == null)
			{
				return WriteNil(ref bytes, offset);
			}
			EnsureCapacity(ref bytes, offset, StringEncoding.UTF8.GetMaxByteCount(value.Length) + 5);
			int bytes2 = StringEncoding.UTF8.GetBytes(value, 0, value.Length, bytes, offset + 5);
			bytes[offset] = 219;
			bytes[offset + 1] = (byte)(bytes2 >> 24);
			bytes[offset + 2] = (byte)(bytes2 >> 16);
			bytes[offset + 3] = (byte)(bytes2 >> 8);
			bytes[offset + 4] = (byte)bytes2;
			return bytes2 + 5;
		}

		public static string ReadString(byte[] bytes, int offset, out int readSize)
		{
			return stringDecoders[bytes[offset]].Read(bytes, offset, out readSize);
		}

		public static ArraySegment<byte> ReadStringSegment(byte[] bytes, int offset, out int readSize)
		{
			return stringSegmentDecoders[bytes[offset]].Read(bytes, offset, out readSize);
		}

		public static int WriteExtensionFormatHeader(ref byte[] bytes, int offset, sbyte typeCode, int dataLength)
		{
			switch (dataLength)
			{
			case 1:
				EnsureCapacity(ref bytes, offset, 3);
				bytes[offset] = 212;
				bytes[offset + 1] = (byte)typeCode;
				return 2;
			case 2:
				EnsureCapacity(ref bytes, offset, 4);
				bytes[offset] = 213;
				bytes[offset + 1] = (byte)typeCode;
				return 2;
			case 4:
				EnsureCapacity(ref bytes, offset, 6);
				bytes[offset] = 214;
				bytes[offset + 1] = (byte)typeCode;
				return 2;
			case 8:
				EnsureCapacity(ref bytes, offset, 10);
				bytes[offset] = 215;
				bytes[offset + 1] = (byte)typeCode;
				return 2;
			case 16:
				EnsureCapacity(ref bytes, offset, 18);
				bytes[offset] = 216;
				bytes[offset + 1] = (byte)typeCode;
				return 2;
			default:
				if (dataLength <= 255)
				{
					EnsureCapacity(ref bytes, offset, dataLength + 3);
					bytes[offset] = 199;
					bytes[offset + 1] = (byte)dataLength;
					bytes[offset + 2] = (byte)typeCode;
					return 3;
				}
				if (dataLength <= 65535)
				{
					EnsureCapacity(ref bytes, offset, dataLength + 4);
					bytes[offset] = 200;
					bytes[offset + 1] = (byte)(dataLength >> 8);
					bytes[offset + 2] = (byte)dataLength;
					bytes[offset + 3] = (byte)typeCode;
					return 4;
				}
				EnsureCapacity(ref bytes, offset, dataLength + 6);
				bytes[offset] = 201;
				bytes[offset + 1] = (byte)(dataLength >> 24);
				bytes[offset + 2] = (byte)(dataLength >> 16);
				bytes[offset + 3] = (byte)(dataLength >> 8);
				bytes[offset + 4] = (byte)dataLength;
				bytes[offset + 5] = (byte)typeCode;
				return 6;
			}
		}

		public static int WriteExtensionFormatHeaderForceExt32Block(ref byte[] bytes, int offset, sbyte typeCode, int dataLength)
		{
			EnsureCapacity(ref bytes, offset, dataLength + 6);
			bytes[offset] = 201;
			bytes[offset + 1] = (byte)(dataLength >> 24);
			bytes[offset + 2] = (byte)(dataLength >> 16);
			bytes[offset + 3] = (byte)(dataLength >> 8);
			bytes[offset + 4] = (byte)dataLength;
			bytes[offset + 5] = (byte)typeCode;
			return 6;
		}

		public static int WriteExtensionFormat(ref byte[] bytes, int offset, sbyte typeCode, byte[] data)
		{
			int num = data.Length;
			switch (num)
			{
			case 1:
				EnsureCapacity(ref bytes, offset, 3);
				bytes[offset] = 212;
				bytes[offset + 1] = (byte)typeCode;
				bytes[offset + 2] = data[0];
				return 3;
			case 2:
				EnsureCapacity(ref bytes, offset, 4);
				bytes[offset] = 213;
				bytes[offset + 1] = (byte)typeCode;
				bytes[offset + 2] = data[0];
				bytes[offset + 3] = data[1];
				return 4;
			case 4:
				EnsureCapacity(ref bytes, offset, 6);
				bytes[offset] = 214;
				bytes[offset + 1] = (byte)typeCode;
				bytes[offset + 2] = data[0];
				bytes[offset + 3] = data[1];
				bytes[offset + 4] = data[2];
				bytes[offset + 5] = data[3];
				return 6;
			case 8:
				EnsureCapacity(ref bytes, offset, 10);
				bytes[offset] = 215;
				bytes[offset + 1] = (byte)typeCode;
				bytes[offset + 2] = data[0];
				bytes[offset + 3] = data[1];
				bytes[offset + 4] = data[2];
				bytes[offset + 5] = data[3];
				bytes[offset + 6] = data[4];
				bytes[offset + 7] = data[5];
				bytes[offset + 8] = data[6];
				bytes[offset + 9] = data[7];
				return 10;
			case 16:
				EnsureCapacity(ref bytes, offset, 18);
				bytes[offset] = 216;
				bytes[offset + 1] = (byte)typeCode;
				bytes[offset + 2] = data[0];
				bytes[offset + 3] = data[1];
				bytes[offset + 4] = data[2];
				bytes[offset + 5] = data[3];
				bytes[offset + 6] = data[4];
				bytes[offset + 7] = data[5];
				bytes[offset + 8] = data[6];
				bytes[offset + 9] = data[7];
				bytes[offset + 10] = data[8];
				bytes[offset + 11] = data[9];
				bytes[offset + 12] = data[10];
				bytes[offset + 13] = data[11];
				bytes[offset + 14] = data[12];
				bytes[offset + 15] = data[13];
				bytes[offset + 16] = data[14];
				bytes[offset + 17] = data[15];
				return 18;
			default:
				if (data.Length <= 255)
				{
					EnsureCapacity(ref bytes, offset, num + 3);
					bytes[offset] = 199;
					bytes[offset + 1] = (byte)num;
					bytes[offset + 2] = (byte)typeCode;
					Buffer.BlockCopy(data, 0, bytes, offset + 3, num);
					return num + 3;
				}
				if (data.Length <= 65535)
				{
					EnsureCapacity(ref bytes, offset, num + 4);
					bytes[offset] = 200;
					bytes[offset + 1] = (byte)(num >> 8);
					bytes[offset + 2] = (byte)num;
					bytes[offset + 3] = (byte)typeCode;
					Buffer.BlockCopy(data, 0, bytes, offset + 4, num);
					return num + 4;
				}
				EnsureCapacity(ref bytes, offset, num + 6);
				bytes[offset] = 201;
				bytes[offset + 1] = (byte)(num >> 24);
				bytes[offset + 2] = (byte)(num >> 16);
				bytes[offset + 3] = (byte)(num >> 8);
				bytes[offset + 4] = (byte)num;
				bytes[offset + 5] = (byte)typeCode;
				Buffer.BlockCopy(data, 0, bytes, offset + 6, num);
				return num + 6;
			}
		}

		public static ExtensionResult ReadExtensionFormat(byte[] bytes, int offset, out int readSize)
		{
			return extDecoders[bytes[offset]].Read(bytes, offset, out readSize);
		}

		public static ExtensionHeader ReadExtensionFormatHeader(byte[] bytes, int offset, out int readSize)
		{
			return extHeaderDecoders[bytes[offset]].Read(bytes, offset, out readSize);
		}

		public static int GetExtensionFormatHeaderLength(int dataLength)
		{
			switch (dataLength)
			{
			case 1:
			case 2:
			case 4:
			case 8:
			case 16:
				return 2;
			default:
				if (dataLength <= 255)
				{
					return 3;
				}
				if (dataLength <= 65535)
				{
					return 4;
				}
				return 6;
			}
		}

		public static int WriteDateTime(ref byte[] bytes, int offset, DateTime dateTime)
		{
			dateTime = ((dateTime.Kind == DateTimeKind.Utc) ? dateTime : dateTime.ToUniversalTime());
			long num = dateTime.Ticks / 10000000 - 62135596800L;
			long num2 = dateTime.Ticks % 10000000 * 100;
			if (num >> 34 == 0L)
			{
				ulong num3 = (ulong)((num2 << 34) | num);
				if ((num3 & 0xFFFFFFFF00000000uL) == 0L)
				{
					uint num4 = (uint)num3;
					EnsureCapacity(ref bytes, offset, 6);
					bytes[offset] = 214;
					bytes[offset + 1] = byte.MaxValue;
					bytes[offset + 2] = (byte)(num4 >> 24);
					bytes[offset + 3] = (byte)(num4 >> 16);
					bytes[offset + 4] = (byte)(num4 >> 8);
					bytes[offset + 5] = (byte)num4;
					return 6;
				}
				EnsureCapacity(ref bytes, offset, 10);
				bytes[offset] = 215;
				bytes[offset + 1] = byte.MaxValue;
				bytes[offset + 2] = (byte)(num3 >> 56);
				bytes[offset + 3] = (byte)(num3 >> 48);
				bytes[offset + 4] = (byte)(num3 >> 40);
				bytes[offset + 5] = (byte)(num3 >> 32);
				bytes[offset + 6] = (byte)(num3 >> 24);
				bytes[offset + 7] = (byte)(num3 >> 16);
				bytes[offset + 8] = (byte)(num3 >> 8);
				bytes[offset + 9] = (byte)num3;
				return 10;
			}
			EnsureCapacity(ref bytes, offset, 15);
			bytes[offset] = 199;
			bytes[offset + 1] = 12;
			bytes[offset + 2] = byte.MaxValue;
			bytes[offset + 3] = (byte)(num2 >> 24);
			bytes[offset + 4] = (byte)(num2 >> 16);
			bytes[offset + 5] = (byte)(num2 >> 8);
			bytes[offset + 6] = (byte)num2;
			bytes[offset + 7] = (byte)(num >> 56);
			bytes[offset + 8] = (byte)(num >> 48);
			bytes[offset + 9] = (byte)(num >> 40);
			bytes[offset + 10] = (byte)(num >> 32);
			bytes[offset + 11] = (byte)(num >> 24);
			bytes[offset + 12] = (byte)(num >> 16);
			bytes[offset + 13] = (byte)(num >> 8);
			bytes[offset + 14] = (byte)num;
			return 15;
		}

		public static DateTime ReadDateTime(byte[] bytes, int offset, out int readSize)
		{
			return dateTimeDecoders[bytes[offset]].Read(bytes, offset, out readSize);
		}

		private static byte[] ReadMessageBlockFromStreamUnsafe(Stream stream)
		{
			int readSize;
			return ReadMessageBlockFromStreamUnsafe(stream, readOnlySingleMessage: false, out readSize);
		}

		public static byte[] ReadMessageBlockFromStreamUnsafe(Stream stream, bool readOnlySingleMessage, out int readSize)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			readSize = ReadMessageBlockFromStreamCore(stream, ref bytes, 0, readOnlySingleMessage);
			return bytes;
		}

		private static int ReadMessageBlockFromStreamCore(Stream stream, ref byte[] bytes, int offset, bool readOnlySingleMessage)
		{
			int num = stream.ReadByte();
			if (num < 0 || 255 < num)
			{
				throw new InvalidOperationException("Invalid MessagePack code was detected, code:" + num);
			}
			byte b = (byte)num;
			EnsureCapacity(ref bytes, offset, 1);
			bytes[offset] = b;
			switch (MessagePackCode.ToMessagePackType(b))
			{
			case MessagePackType.Integer:
			{
				int num8 = 0;
				if (224 <= b && b <= byte.MaxValue)
				{
					return 1;
				}
				if (0 <= b && b <= 127)
				{
					return 1;
				}
				num8 = b switch
				{
					208 => 1, 
					209 => 2, 
					210 => 4, 
					211 => 8, 
					204 => 1, 
					205 => 2, 
					206 => 4, 
					207 => 8, 
					_ => throw new InvalidOperationException("Invalid Code"), 
				};
				EnsureCapacity(ref bytes, offset, num8 + 1);
				ReadFully(stream, bytes, offset + 1, num8);
				return num8 + 1;
			}
			case MessagePackType.Unknown:
			case MessagePackType.Nil:
			case MessagePackType.Boolean:
				return 1;
			case MessagePackType.Float:
				if (b == 202)
				{
					EnsureCapacity(ref bytes, offset, 5);
					ReadFully(stream, bytes, offset + 1, 4);
					return 5;
				}
				EnsureCapacity(ref bytes, offset, 9);
				ReadFully(stream, bytes, offset + 1, 8);
				return 9;
			case MessagePackType.String:
				if (160 <= b && b <= 191)
				{
					int num12 = bytes[offset] & 0x1F;
					EnsureCapacity(ref bytes, offset, 1 + num12);
					ReadFully(stream, bytes, offset + 1, num12);
					return num12 + 1;
				}
				switch (b)
				{
				case 217:
				{
					EnsureCapacity(ref bytes, offset, 2);
					ReadFully(stream, bytes, offset + 1, 1);
					byte b3 = bytes[offset + 1];
					EnsureCapacity(ref bytes, offset, 2 + b3);
					ReadFully(stream, bytes, offset + 2, b3);
					return b3 + 2;
				}
				case 218:
				{
					EnsureCapacity(ref bytes, offset, 3);
					ReadFully(stream, bytes, offset + 1, 2);
					int num14 = (bytes[offset + 1] << 8) + bytes[offset + 2];
					EnsureCapacity(ref bytes, offset, 3 + num14);
					ReadFully(stream, bytes, offset + 3, num14);
					return num14 + 3;
				}
				case 219:
				{
					EnsureCapacity(ref bytes, offset, 5);
					ReadFully(stream, bytes, offset + 1, 4);
					int num13 = (bytes[offset + 1] << 24) | (bytes[offset + 2] << 16) | (bytes[offset + 3] << 8) | bytes[offset + 4];
					EnsureCapacity(ref bytes, offset, 5 + num13);
					ReadFully(stream, bytes, offset + 5, num13);
					return num13 + 5;
				}
				default:
					throw new InvalidOperationException("Invalid Code");
				}
			case MessagePackType.Binary:
				switch (b)
				{
				case 196:
				{
					EnsureCapacity(ref bytes, offset, 2);
					ReadFully(stream, bytes, offset + 1, 1);
					byte b2 = bytes[offset + 1];
					EnsureCapacity(ref bytes, offset, 2 + b2);
					ReadFully(stream, bytes, offset + 2, b2);
					return b2 + 2;
				}
				case 197:
				{
					EnsureCapacity(ref bytes, offset, 3);
					ReadFully(stream, bytes, offset + 1, 2);
					int num4 = (bytes[offset + 1] << 8) + bytes[offset + 2];
					EnsureCapacity(ref bytes, offset, 3 + num4);
					ReadFully(stream, bytes, offset + 3, num4);
					return num4 + 3;
				}
				case 198:
				{
					EnsureCapacity(ref bytes, offset, 5);
					ReadFully(stream, bytes, offset + 1, 4);
					int num3 = (bytes[offset + 1] << 24) | (bytes[offset + 2] << 16) | (bytes[offset + 3] << 8) | bytes[offset + 4];
					EnsureCapacity(ref bytes, offset, 5 + num3);
					ReadFully(stream, bytes, offset + 5, num3);
					return num3 + 5;
				}
				default:
					throw new InvalidOperationException("Invalid Code");
				}
			case MessagePackType.Array:
			{
				int num9 = 0;
				if (144 <= b && b <= 159)
				{
					num9 = 0;
				}
				else
				{
					switch (b)
					{
					case 220:
						num9 = 2;
						break;
					case 221:
						num9 = 4;
						break;
					}
				}
				if (num9 != 0)
				{
					EnsureCapacity(ref bytes, offset, num9 + 1);
					ReadFully(stream, bytes, offset + 1, num9);
				}
				int num10 = offset;
				offset += num9 + 1;
				int readSize3;
				uint num11 = ReadArrayHeaderRaw(bytes, num10, out readSize3);
				if (!readOnlySingleMessage)
				{
					for (int j = 0; j < num11; j++)
					{
						offset += ReadMessageBlockFromStreamCore(stream, ref bytes, offset, readOnlySingleMessage);
					}
				}
				return offset - num10;
			}
			case MessagePackType.Map:
			{
				int num5 = 0;
				if (128 <= b && b <= 143)
				{
					num5 = 0;
				}
				else
				{
					switch (b)
					{
					case 222:
						num5 = 2;
						break;
					case 223:
						num5 = 4;
						break;
					}
				}
				if (num5 != 0)
				{
					EnsureCapacity(ref bytes, offset, num5 + 1);
					ReadFully(stream, bytes, offset + 1, num5);
				}
				int num6 = offset;
				offset += num5 + 1;
				int readSize2;
				uint num7 = ReadMapHeaderRaw(bytes, num6, out readSize2);
				if (!readOnlySingleMessage)
				{
					for (int i = 0; i < num7; i++)
					{
						offset += ReadMessageBlockFromStreamCore(stream, ref bytes, offset, readOnlySingleMessage);
						offset += ReadMessageBlockFromStreamCore(stream, ref bytes, offset, readOnlySingleMessage);
					}
				}
				return offset - num6;
			}
			case MessagePackType.Extension:
			{
				int num2 = 0;
				num2 = b switch
				{
					212 => 1, 
					213 => 1, 
					214 => 1, 
					215 => 1, 
					216 => 1, 
					199 => 2, 
					200 => 3, 
					201 => 5, 
					_ => throw new InvalidOperationException("Invalid Code"), 
				};
				EnsureCapacity(ref bytes, offset, num2 + 1);
				ReadFully(stream, bytes, offset + 1, num2);
				if (!readOnlySingleMessage)
				{
					int readSize;
					ExtensionHeader extensionHeader = ReadExtensionFormatHeader(bytes, offset, out readSize);
					EnsureCapacity(ref bytes, offset, 1 + num2 + (int)extensionHeader.Length);
					ReadFully(stream, bytes, offset + 1 + num2, (int)extensionHeader.Length);
					return 1 + num2 + (int)extensionHeader.Length;
				}
				return num2 + 1;
			}
			default:
				throw new InvalidOperationException("Invalid Code");
			}
		}

		private static void ReadFully(Stream stream, byte[] bytes, int offset, int readSize)
		{
			int num = readSize;
			while (num != 0)
			{
				int num2 = stream.Read(bytes, offset, num);
				if (num2 == -1)
				{
					break;
				}
				offset += num2;
				num -= num2;
			}
		}

		public static int ReadNext(Stream stream)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			return ReadMessageBlockFromStreamCore(stream, ref bytes, 0, readOnlySingleMessage: true);
		}

		public static int ReadNextBlock(Stream stream)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int offset = 0;
			return ReadMessageBlockFromStreamCore(stream, ref bytes, offset, readOnlySingleMessage: false);
		}

		public static int WriteNil(Stream stream)
		{
			stream.WriteByte(192);
			return 1;
		}

		public static Nil ReadNil(Stream stream)
		{
			byte[] bytes = ReadMessageBlockFromStreamUnsafe(stream);
			int offset = 0;
			int readSize;
			return ReadNil(bytes, offset, out readSize);
		}

		public static bool IsNil(Stream stream)
		{
			byte[] array = ReadMessageBlockFromStreamUnsafe(stream);
			int num = 0;
			return array[num] == 192;
		}

		public static int WriteFixedMapHeaderUnsafe(Stream stream, int count)
		{
			stream.WriteByte((byte)(0x80 | count));
			return 1;
		}

		public static int WriteMapHeader(Stream stream, int count)
		{
			return WriteMapHeader(stream, checked((uint)count));
		}

		public static int WriteMapHeader(Stream stream, uint count)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteMapHeader(ref bytes, 0, count);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static int WriteMapHeaderForceMap32Block(Stream stream, uint count)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteMapHeaderForceMap32Block(ref bytes, 0, count);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static int ReadMapHeader(Stream stream)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			ReadMessageBlockFromStreamCore(stream, ref bytes, 0, readOnlySingleMessage: true);
			int readSize;
			return ReadMapHeader(bytes, 0, out readSize);
		}

		public static uint ReadMapHeaderRaw(Stream stream)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			ReadMessageBlockFromStreamCore(stream, ref bytes, 0, readOnlySingleMessage: true);
			int readSize;
			return ReadMapHeaderRaw(bytes, 0, out readSize);
		}

		public static int WriteFixedArrayHeaderUnsafe(Stream stream, int count)
		{
			stream.WriteByte((byte)(0x90 | count));
			return 1;
		}

		public static int WriteArrayHeader(Stream stream, int count)
		{
			return WriteArrayHeader(stream, checked((uint)count));
		}

		public static int WriteArrayHeader(Stream stream, uint count)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteArrayHeader(ref bytes, 0, count);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static int WriteArrayHeaderForceArray32Block(Stream stream, uint count)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteArrayHeaderForceArray32Block(ref bytes, 0, count);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static int ReadArrayHeader(Stream stream)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			ReadMessageBlockFromStreamCore(stream, ref bytes, 0, readOnlySingleMessage: true);
			int readSize;
			return ReadArrayHeader(bytes, 0, out readSize);
		}

		public static uint ReadArrayHeaderRaw(Stream stream)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			ReadMessageBlockFromStreamCore(stream, ref bytes, 0, readOnlySingleMessage: true);
			int readSize;
			return ReadArrayHeaderRaw(bytes, 0, out readSize);
		}

		public static int WriteBoolean(Stream stream, bool value)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteBoolean(ref bytes, 0, value);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static bool ReadBoolean(Stream stream)
		{
			byte[] bytes = ReadMessageBlockFromStreamUnsafe(stream);
			int offset = 0;
			int readSize;
			return ReadBoolean(bytes, offset, out readSize);
		}

		public static int WriteByte(Stream stream, byte value)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteByte(ref bytes, 0, value);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static int WriteByteForceByteBlock(Stream stream, byte value)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteByteForceByteBlock(ref bytes, 0, value);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static byte ReadByte(Stream stream)
		{
			byte[] bytes = ReadMessageBlockFromStreamUnsafe(stream);
			int offset = 0;
			int readSize;
			return ReadByte(bytes, offset, out readSize);
		}

		public static int WriteBytes(Stream stream, byte[] value)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteBytes(ref bytes, 0, value);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static int WriteBytes(Stream stream, byte[] src, int srcOffset, int count)
		{
			byte[] dest = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteBytes(ref dest, 0, src, srcOffset, count);
			stream.Write(dest, 0, num);
			return num;
		}

		public static byte[] ReadBytes(Stream stream)
		{
			byte[] bytes = ReadMessageBlockFromStreamUnsafe(stream);
			int offset = 0;
			int readSize;
			return ReadBytes(bytes, offset, out readSize);
		}

		public static int WriteSByte(Stream stream, sbyte value)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteSByte(ref bytes, 0, value);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static int WriteSByteForceSByteBlock(Stream stream, sbyte value)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteSByteForceSByteBlock(ref bytes, 0, value);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static sbyte ReadSByte(Stream stream)
		{
			byte[] bytes = ReadMessageBlockFromStreamUnsafe(stream);
			int offset = 0;
			int readSize;
			return ReadSByte(bytes, offset, out readSize);
		}

		public static int WriteSingle(Stream stream, float value)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteSingle(ref bytes, 0, value);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static float ReadSingle(Stream stream)
		{
			byte[] bytes = ReadMessageBlockFromStreamUnsafe(stream);
			int offset = 0;
			int readSize;
			return ReadSingle(bytes, offset, out readSize);
		}

		public static int WriteDouble(Stream stream, double value)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteDouble(ref bytes, 0, value);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static double ReadDouble(Stream stream)
		{
			byte[] bytes = ReadMessageBlockFromStreamUnsafe(stream);
			int offset = 0;
			int readSize;
			return ReadDouble(bytes, offset, out readSize);
		}

		public static int WriteInt16(Stream stream, short value)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteInt16(ref bytes, 0, value);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static int WriteInt16ForceInt16Block(Stream stream, short value)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteInt16ForceInt16Block(ref bytes, 0, value);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static short ReadInt16(Stream stream)
		{
			byte[] bytes = ReadMessageBlockFromStreamUnsafe(stream);
			int offset = 0;
			int readSize;
			return ReadInt16(bytes, offset, out readSize);
		}

		public static int WritePositiveFixedIntUnsafe(Stream stream, int value)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WritePositiveFixedIntUnsafe(ref bytes, 0, value);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static int WriteInt32(Stream stream, int value)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteInt32(ref bytes, 0, value);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static int WriteInt32ForceInt32Block(Stream stream, int value)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteInt32ForceInt32Block(ref bytes, 0, value);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static int ReadInt32(Stream stream)
		{
			byte[] bytes = ReadMessageBlockFromStreamUnsafe(stream);
			int offset = 0;
			int readSize;
			return ReadInt32(bytes, offset, out readSize);
		}

		public static int WriteInt64(Stream stream, long value)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteInt64(ref bytes, 0, value);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static int WriteInt64ForceInt64Block(Stream stream, long value)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteInt64ForceInt64Block(ref bytes, 0, value);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static long ReadInt64(Stream stream)
		{
			byte[] bytes = ReadMessageBlockFromStreamUnsafe(stream);
			int offset = 0;
			int readSize;
			return ReadInt64(bytes, offset, out readSize);
		}

		public static int WriteUInt16(Stream stream, ushort value)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteUInt16(ref bytes, 0, value);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static int WriteUInt16ForceUInt16Block(Stream stream, ushort value)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteUInt16ForceUInt16Block(ref bytes, 0, value);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static ushort ReadUInt16(Stream stream)
		{
			byte[] bytes = ReadMessageBlockFromStreamUnsafe(stream);
			int offset = 0;
			int readSize;
			return ReadUInt16(bytes, offset, out readSize);
		}

		public static int WriteUInt32(Stream stream, uint value)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteUInt32(ref bytes, 0, value);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static int WriteUInt32ForceUInt32Block(Stream stream, uint value)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteUInt32ForceUInt32Block(ref bytes, 0, value);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static uint ReadUInt32(Stream stream)
		{
			byte[] bytes = ReadMessageBlockFromStreamUnsafe(stream);
			int offset = 0;
			int readSize;
			return ReadUInt32(bytes, offset, out readSize);
		}

		public static int WriteUInt64(Stream stream, ulong value)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteUInt64(ref bytes, 0, value);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static int WriteUInt64ForceUInt64Block(Stream stream, ulong value)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteUInt64ForceUInt64Block(ref bytes, 0, value);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static ulong ReadUInt64(Stream stream)
		{
			byte[] bytes = ReadMessageBlockFromStreamUnsafe(stream);
			int offset = 0;
			int readSize;
			return ReadUInt64(bytes, offset, out readSize);
		}

		public static int WriteChar(Stream stream, char value)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteChar(ref bytes, 0, value);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static char ReadChar(Stream stream)
		{
			byte[] bytes = ReadMessageBlockFromStreamUnsafe(stream);
			int offset = 0;
			int readSize;
			return ReadChar(bytes, offset, out readSize);
		}

		public static int WriteFixedStringUnsafe(Stream stream, string value, int byteCount)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteFixedStringUnsafe(ref bytes, 0, value, byteCount);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static int WriteStringUnsafe(Stream stream, string value, int byteCount)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteStringUnsafe(ref bytes, 0, value, byteCount);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static int WriteStringBytes(Stream stream, byte[] utf8stringBytes)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteStringBytes(ref bytes, 0, utf8stringBytes);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static int WriteString(Stream stream, string value)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteString(ref bytes, 0, value);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static int WriteStringForceStr32Block(Stream stream, string value)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteStringForceStr32Block(ref bytes, 0, value);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static string ReadString(Stream stream)
		{
			byte[] bytes = ReadMessageBlockFromStreamUnsafe(stream);
			int offset = 0;
			int readSize;
			return ReadString(bytes, offset, out readSize);
		}

		public static int WriteExtensionFormatHeader(Stream stream, sbyte typeCode, int dataLength)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteExtensionFormatHeader(ref bytes, 0, typeCode, dataLength);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static int WriteExtensionFormatHeaderForceExt32Block(Stream stream, sbyte typeCode, int dataLength)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteExtensionFormatHeaderForceExt32Block(ref bytes, 0, typeCode, dataLength);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static int WriteExtensionFormat(Stream stream, sbyte typeCode, byte[] data)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteExtensionFormat(ref bytes, 0, typeCode, data);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static ExtensionResult ReadExtensionFormat(Stream stream)
		{
			byte[] bytes = ReadMessageBlockFromStreamUnsafe(stream);
			int offset = 0;
			int readSize;
			return ReadExtensionFormat(bytes, offset, out readSize);
		}

		public static ExtensionHeader ReadExtensionFormatHeader(Stream stream)
		{
			int readSize;
			byte[] bytes = ReadMessageBlockFromStreamUnsafe(stream, readOnlySingleMessage: true, out readSize);
			int offset = 0;
			return ReadExtensionFormatHeader(bytes, offset, out readSize);
		}

		public static int WriteDateTime(Stream stream, DateTime dateTime)
		{
			byte[] bytes = StreamDecodeMemoryPool.GetBuffer();
			int num = WriteDateTime(ref bytes, 0, dateTime);
			stream.Write(bytes, 0, num);
			return num;
		}

		public static DateTime ReadDateTime(Stream stream)
		{
			byte[] bytes = ReadMessageBlockFromStreamUnsafe(stream);
			int offset = 0;
			int readSize;
			return ReadDateTime(bytes, offset, out readSize);
		}
	}
}
