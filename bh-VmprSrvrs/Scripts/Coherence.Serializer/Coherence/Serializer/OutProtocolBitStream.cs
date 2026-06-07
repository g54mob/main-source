using System;
using System.Numerics;
using Coherence.Brook;
using Coherence.Common;
using Coherence.Cram;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Serializer
{
	public class OutProtocolBitStream : IOutProtocolBitStream
	{
		public const int BYTES_LIST_LENGTH_BITS = 9;

		public const int BYTES_LIST_MAX_LENGTH = 511;

		public const int SHORT_STRING_LENGTH_BITS = 6;

		public const int SHORT_STRING_MAX_SIZE = 63;

		public const int ENUM_LENGTH_BITS = 6;

		public const int ENUM_MAX_VALUE = 63;

		private Coherence.Cram.OutBitStream cramStream;

		private Logger logger;

		[ThreadStatic]
		private static OutProtocolBitStream shared;

		public IOutBitStream BitStream { get; private set; }

		internal static OutProtocolBitStream Shared => null;

		public OutProtocolBitStream(IOutBitStream bitStream, Logger incoming)
		{
		}

		internal OutProtocolBitStream Reset(IOutBitStream bitStream, Logger incoming)
		{
			return null;
		}

		public void WriteIntegerRange(int v, int bitCount, int offset)
		{
		}

		public void WriteUIntegerRange(uint v, int bitCount, uint offset)
		{
		}

		public void WriteDouble(double value)
		{
		}

		public void WriteFloat(float value, in FloatMeta meta)
		{
		}

		public void WriteVector2(in Vector2 v, in FloatMeta meta)
		{
		}

		public void WriteVector3(in Vector3 v, in FloatMeta meta)
		{
		}

		public void WriteVector3d(in Vector3d v)
		{
		}

		public void WriteVector4(in Vector4 v, in FloatMeta meta)
		{
		}

		public void WriteColor(in Vector4 v, in FloatMeta meta)
		{
		}

		public void WriteQuaternion(in Quaternion q, int bitsPerComponent)
		{
		}

		public void WriteShortString(string s)
		{
		}

		public void WriteBytesList(byte[] data)
		{
		}

		public void WriteBits(uint value, int count)
		{
		}

		public void WriteByte(byte value)
		{
		}

		public void WriteSByte(sbyte value)
		{
		}

		public void WriteShort(short value)
		{
		}

		public void WriteUShort(ushort value)
		{
		}

		public void WriteChar(char value)
		{
		}

		public void WriteLong(long value)
		{
		}

		public void WriteULong(ulong value)
		{
		}

		public bool WriteMask(bool b)
		{
			return false;
		}

		public void WriteMaskBits(uint mask, uint numBits)
		{
		}

		public void WriteBool(bool b)
		{
		}

		public void WriteEnum(int b)
		{
		}

		public void WriteEntity(Entity entityID)
		{
		}

		void IOutProtocolBitStream.WriteFloat(float value, in FloatMeta meta)
		{
		}

		void IOutProtocolBitStream.WriteVector2(in Vector2 v, in FloatMeta meta)
		{
		}

		void IOutProtocolBitStream.WriteVector3(in Vector3 v, in FloatMeta meta)
		{
		}

		void IOutProtocolBitStream.WriteVector3d(in Vector3d v)
		{
		}

		void IOutProtocolBitStream.WriteVector4(in Vector4 v, in FloatMeta meta)
		{
		}

		void IOutProtocolBitStream.WriteColor(in Vector4 fromUnityColor, in FloatMeta forFixedPoint)
		{
		}

		void IOutProtocolBitStream.WriteQuaternion(in Quaternion q, int bitsPerComponent)
		{
		}
	}
}
