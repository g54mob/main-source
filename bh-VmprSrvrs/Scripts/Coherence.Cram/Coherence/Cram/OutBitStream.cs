using System.Numerics;
using Coherence.Brook;

namespace Coherence.Cram
{
	public struct OutBitStream
	{
		private readonly IOutBitStream outstream;

		public OutBitStream(IOutBitStream outstream)
		{
			this.outstream = null;
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

		public void WriteVector4(in Vector4 v, in FloatMeta meta)
		{
		}

		public void WriteQuaternion(in Quaternion q, int bitsPerComponent)
		{
		}

		private void WriteFullFloat(float value)
		{
		}

		private void WriteTruncatedFloat(float value, int bits)
		{
		}

		private void WriteFixedDouble(double value, int minRange, int maxRange, double precision)
		{
		}
	}
}
