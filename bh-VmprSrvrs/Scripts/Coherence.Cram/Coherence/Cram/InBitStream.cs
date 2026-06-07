using System.Numerics;
using Coherence.Brook;

namespace Coherence.Cram
{
	public struct InBitStream
	{
		private readonly IInBitStream instream;

		public InBitStream(IInBitStream instream)
		{
			this.instream = null;
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

		public Vector4 ReadVector4(in FloatMeta meta)
		{
			return default(Vector4);
		}

		public Quaternion ReadQuaternion(int bitsPerComponent)
		{
			return default(Quaternion);
		}

		private float ReadFullFloat()
		{
			return 0f;
		}

		private float ReadTruncatedFloat(int bits)
		{
			return 0f;
		}

		private double ReadFixedDouble(int minRange, int maxRange, double precision)
		{
			return 0.0;
		}
	}
}
