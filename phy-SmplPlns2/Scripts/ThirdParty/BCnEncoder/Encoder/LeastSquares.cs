using System;
using System.Numerics;
using BCnEncoder.Shared;

namespace BCnEncoder.Encoder
{
	internal static class LeastSquares
	{
		private static int ComputeIndex4(float texelPos, float endPoint0Pos, float endPoint1Pos)
		{
			return (int)Math.Clamp((texelPos - endPoint0Pos) / (endPoint1Pos - endPoint0Pos) * 15f, 0f, 15f);
		}

		private static int ComputeIndex3(float texelPos, float endPoint0Pos, float endPoint1Pos)
		{
			return (int)Math.Clamp((texelPos - endPoint0Pos) / (endPoint1Pos - endPoint0Pos) * 6.98182f + 0.00909f + 0.5f, 0f, 7f);
		}

		private static uint F32ToF16(float f32)
		{
			return Half.GetBits(new Half(f32));
		}

		private static Vector3 F32ToF16(Vector3 f32)
		{
			return new Vector3(F32ToF16(f32.X), F32ToF16(f32.Y), F32ToF16(f32.Z));
		}

		private static float F16ToF32(uint f16)
		{
			return Half.ToHalf((ushort)f16);
		}

		private static Vector3 F16ToF32(Vector3 f16)
		{
			return new Vector3(F16ToF32((uint)f16.X), F16ToF32((uint)f16.Y), F16ToF32((uint)f16.Z));
		}

		public static void OptimizeEndpoints1Sub(RawBlock4X4RgbFloat block, ref ColorRgbFloat ep0, ref ColorRgbFloat ep1)
		{
			Vector3 vector = ep0.ToVector3();
			Vector3 vector2 = ep1.ToVector3();
			Span<ColorRgbFloat> asSpan = block.AsSpan;
			Vector3 vector3 = vector2 - vector;
			vector3 /= vector3.X + vector3.Y + vector3.Z;
			float endPoint0Pos = F32ToF16(Vector3.Dot(vector, vector3));
			float endPoint1Pos = F32ToF16(Vector3.Dot(vector2, vector3));
			Vector3 vector4 = default(Vector3);
			Vector3 vector5 = default(Vector3);
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			for (int i = 0; i < 16; i++)
			{
				float num4 = Math.Clamp((float)ComputeIndex4(F32ToF16(Vector3.Dot(asSpan[i].ToVector3(), vector3)), endPoint0Pos, endPoint1Pos) / 15f, 0f, 1f);
				float num5 = 1f - num4;
				Vector3 vector6 = F32ToF16(asSpan[i].ToVector3());
				vector4 += num5 * vector6;
				vector5 += num4 * vector6;
				num += num5 * num4;
				num2 += num5 * num5;
				num3 += num4 * num4;
			}
			float num6 = num2 * num3 - num * num;
			if (MathF.Abs(num6) > 1E-05f)
			{
				float num7 = 1f / num6;
				Vector3 value = num7 * (vector4 * num3 - vector5 * num);
				Vector3 value2 = num7 * (vector5 * num2 - vector4 * num);
				value = Vector3.Clamp(value, Vector3.Zero, new Vector3((int)Half.MaxValue.Value));
				value2 = Vector3.Clamp(value2, Vector3.Zero, new Vector3((int)Half.MaxValue.Value));
				ep0 = new ColorRgbFloat(F16ToF32(value));
				ep1 = new ColorRgbFloat(F16ToF32(value2));
			}
		}

		public static void OptimizeEndpoints2Sub(RawBlock4X4RgbFloat block, ref ColorRgbFloat ep0, ref ColorRgbFloat ep1, int partitionSetId, int subsetIndex)
		{
			Vector3 vector = ep0.ToVector3();
			Vector3 vector2 = ep1.ToVector3();
			Span<ColorRgbFloat> asSpan = block.AsSpan;
			Vector3 vector3 = vector2 - vector;
			vector3 /= vector3.X + vector3.Y + vector3.Z;
			float endPoint0Pos = F32ToF16(Vector3.Dot(vector, vector3));
			float endPoint1Pos = F32ToF16(Vector3.Dot(vector2, vector3));
			Vector3 vector4 = default(Vector3);
			Vector3 vector5 = default(Vector3);
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			for (int i = 0; i < 16; i++)
			{
				if (Bc6Block.Subsets2PartitionTable[partitionSetId][i] == subsetIndex)
				{
					float num4 = Math.Clamp((float)ComputeIndex3(F32ToF16(Vector3.Dot(asSpan[i].ToVector3(), vector3)), endPoint0Pos, endPoint1Pos) / 7f, 0f, 1f);
					float num5 = 1f - num4;
					Vector3 vector6 = F32ToF16(asSpan[i].ToVector3());
					vector4 += num5 * vector6;
					vector5 += num4 * vector6;
					num += num5 * num4;
					num2 += num5 * num5;
					num3 += num4 * num4;
				}
			}
			float num6 = num2 * num3 - num * num;
			if (MathF.Abs(num6) > 1E-05f)
			{
				float num7 = 1f / num6;
				Vector3 value = num7 * (vector4 * num3 - vector5 * num);
				Vector3 value2 = num7 * (vector5 * num2 - vector4 * num);
				value = Vector3.Clamp(value, Vector3.Zero, new Vector3((int)Half.MaxValue.Value));
				value2 = Vector3.Clamp(value2, Vector3.Zero, new Vector3((int)Half.MaxValue.Value));
				ep0 = new ColorRgbFloat(F16ToF32(value));
				ep1 = new ColorRgbFloat(F16ToF32(value2));
			}
		}
	}
}
