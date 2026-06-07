using System.Numerics;
using Coherence.Brook;
using Coherence.Common;
using Coherence.Cram;
using Coherence.Entities;
using Coherence.ProtocolDef;

namespace Coherence.Serializer
{
	public struct InProtocolBitStream : IInProtocolBitStream
	{
		private readonly Coherence.Cram.InBitStream cramStream;

		private readonly IInBitStream bitStream;

		public InProtocolBitStream(IInBitStream bitStream)
		{
			cramStream = default(Coherence.Cram.InBitStream);
			this.bitStream = null;
		}

		public int ReadIntegerRange(int bitCount, int offset)
		{
			return 0;
		}

		public uint ReadUIntegerRange(int bitCount, uint offset)
		{
			return 0u;
		}

		public Quaternion ReadQuaternion(int bitsPerComponent)
		{
			return default(Quaternion);
		}

		public double ReadDouble()
		{
			return 0.0;
		}

		public float ReadFloat(in FloatMeta meta)
		{
			return 0f;
		}

		public Vector2 ReadVector2(in FloatMeta meta)
		{
			return default(Vector2);
		}

		public Vector3 ReadVector3(in FloatMeta meta)
		{
			return default(Vector3);
		}

		public Vector3d ReadVector3d()
		{
			return default(Vector3d);
		}

		public Vector4 ReadVector4(in FloatMeta meta)
		{
			return default(Vector4);
		}

		public Vector4 ReadColor(in FloatMeta meta)
		{
			return default(Vector4);
		}

		public string ReadShortString()
		{
			return null;
		}

		public byte[] ReadBytesList()
		{
			return null;
		}

		public uint ReadBits(int count)
		{
			return 0u;
		}

		public byte ReadByte()
		{
			return 0;
		}

		public sbyte ReadSByte()
		{
			return 0;
		}

		public short ReadShort()
		{
			return 0;
		}

		public ushort ReadUShort()
		{
			return 0;
		}

		public char ReadChar()
		{
			return '\0';
		}

		public long ReadLong()
		{
			return 0L;
		}

		public ulong ReadULong()
		{
			return 0uL;
		}

		public bool ReadMask()
		{
			return false;
		}

		public uint ReadMaskBits(uint numBits)
		{
			return 0u;
		}

		public bool ReadBool()
		{
			return false;
		}

		public int ReadEnum()
		{
			return 0;
		}

		public Entity ReadEntity()
		{
			return default(Entity);
		}

		float IInProtocolBitStream.ReadFloat(in FloatMeta meta)
		{
			return 0f;
		}

		Vector2 IInProtocolBitStream.ReadVector2(in FloatMeta meta)
		{
			return default(Vector2);
		}

		Vector3 IInProtocolBitStream.ReadVector3(in FloatMeta meta)
		{
			return default(Vector3);
		}

		Vector4 IInProtocolBitStream.ReadVector4(in FloatMeta meta)
		{
			return default(Vector4);
		}

		Vector4 IInProtocolBitStream.ReadColor(in FloatMeta meta)
		{
			return default(Vector4);
		}
	}
}
