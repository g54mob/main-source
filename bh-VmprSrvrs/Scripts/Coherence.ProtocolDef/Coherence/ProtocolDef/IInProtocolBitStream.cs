using System.Numerics;
using Coherence.Brook;
using Coherence.Common;
using Coherence.Entities;

namespace Coherence.ProtocolDef
{
	public interface IInProtocolBitStream
	{
		uint ReadBits(int count);

		byte ReadByte();

		sbyte ReadSByte();

		short ReadShort();

		ushort ReadUShort();

		char ReadChar();

		int ReadIntegerRange(int bitCount, int offset);

		uint ReadUIntegerRange(int bitCount, uint offset);

		long ReadLong();

		ulong ReadULong();

		double ReadDouble();

		float ReadFloat(in FloatMeta meta);

		Vector2 ReadVector2(in FloatMeta meta);

		Vector3 ReadVector3(in FloatMeta meta);

		Vector3d ReadVector3d();

		Vector4 ReadVector4(in FloatMeta meta);

		Vector4 ReadColor(in FloatMeta meta);

		Quaternion ReadQuaternion(int bitsPerComponent);

		string ReadShortString();

		bool ReadBool();

		int ReadEnum();

		bool ReadMask();

		uint ReadMaskBits(uint numBits);

		Entity ReadEntity();

		byte[] ReadBytesList();
	}
}
