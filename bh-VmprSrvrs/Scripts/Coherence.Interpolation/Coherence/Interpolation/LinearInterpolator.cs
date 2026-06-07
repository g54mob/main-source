using UnityEngine;

namespace Coherence.Interpolation
{
	public class LinearInterpolator : Interpolator
	{
		public override int NumberOfSamplesToStayBehind => 0;

		private static float FloatLerp(float a, float b, float t)
		{
			return 0f;
		}

		private static double DoubleLerp(double a, double b, float t)
		{
			return 0.0;
		}

		private static long IntegerLerp(long a, long b, float t)
		{
			return 0L;
		}

		public override byte InterpolateByte(byte value1, byte value2, float t)
		{
			return 0;
		}

		public override sbyte InterpolateSByte(sbyte value1, sbyte value2, float t)
		{
			return 0;
		}

		public override short InterpolateShort(short value1, short value2, float t)
		{
			return 0;
		}

		public override ushort InterpolateUShort(ushort value1, ushort value2, float t)
		{
			return 0;
		}

		public override int InterpolateInt(int value1, int value2, float t)
		{
			return 0;
		}

		public override uint InterpolateUInt(uint value1, uint value2, float t)
		{
			return 0u;
		}

		public override long InterpolateLong(long value1, long value2, float t)
		{
			return 0L;
		}

		public override ulong InterpolateULong(ulong value1, ulong value2, float t)
		{
			return 0uL;
		}

		public override float InterpolateFloat(float value1, float value2, float t)
		{
			return 0f;
		}

		public override double InterpolateDouble(double value1, double value2, float t)
		{
			return 0.0;
		}

		public override Vector2 InterpolateVector2(Vector2 value1, Vector2 value2, float t)
		{
			return default(Vector2);
		}

		public override Vector3 InterpolateVector3(Vector3 value1, Vector3 value2, float t)
		{
			return default(Vector3);
		}

		public override Quaternion InterpolateQuaternion(Quaternion value1, Quaternion value2, float t)
		{
			return default(Quaternion);
		}

		public override Color InterpolateColor(Color value1, Color value2, float t)
		{
			return default(Color);
		}
	}
}
