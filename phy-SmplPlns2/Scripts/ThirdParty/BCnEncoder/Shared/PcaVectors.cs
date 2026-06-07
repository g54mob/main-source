using System;
using System.Numerics;

namespace BCnEncoder.Shared
{
	internal static class PcaVectors
	{
		private const int C565_5Mask = 248;

		private const int C565_6Mask = 252;

		private static void ConvertToVector4(ReadOnlySpan<ColorRgba32> colors, Span<Vector4> vectors)
		{
			for (int i = 0; i < colors.Length; i++)
			{
				vectors[i].X += (float)(int)colors[i].r / 255f;
				vectors[i].Y += (float)(int)colors[i].g / 255f;
				vectors[i].Z += (float)(int)colors[i].b / 255f;
				vectors[i].W += (float)(int)colors[i].a / 255f;
			}
		}

		private static void ConvertToVector4(ReadOnlySpan<ColorRgbFloat> colors, Span<Vector4> vectors)
		{
			for (int i = 0; i < colors.Length; i++)
			{
				vectors[i].X += colors[i].r;
				vectors[i].Y += colors[i].g;
				vectors[i].Z += colors[i].b;
				vectors[i].W = 0f;
			}
		}

		private static Vector4 CalculateMean(Span<Vector4> colors)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			for (int i = 0; i < colors.Length; i++)
			{
				num += colors[i].X;
				num2 += colors[i].Y;
				num3 += colors[i].Z;
				num4 += colors[i].W;
			}
			return new Vector4(num / (float)colors.Length, num2 / (float)colors.Length, num3 / (float)colors.Length, num4 / (float)colors.Length);
		}

		internal static Matrix4x4 CalculateCovariance(Span<Vector4> values, out Vector4 mean)
		{
			mean = CalculateMean(values);
			for (int i = 0; i < values.Length; i++)
			{
				values[i] -= mean;
			}
			Matrix4x4 value = default(Matrix4x4);
			for (int j = 0; j < values.Length; j++)
			{
				value.M11 += values[j].X * values[j].X;
				value.M12 += values[j].X * values[j].Y;
				value.M13 += values[j].X * values[j].Z;
				value.M14 += values[j].X * values[j].W;
				value.M22 += values[j].Y * values[j].Y;
				value.M23 += values[j].Y * values[j].Z;
				value.M24 += values[j].Y * values[j].W;
				value.M33 += values[j].Z * values[j].Z;
				value.M34 += values[j].Z * values[j].W;
				value.M44 += values[j].W * values[j].W;
			}
			value = Matrix4x4.Multiply(value, 1f / (float)(values.Length - 1));
			value.M21 = value.M12;
			value.M31 = value.M13;
			value.M32 = value.M23;
			value.M41 = value.M14;
			value.M42 = value.M24;
			value.M43 = value.M34;
			return value;
		}

		internal static Vector4 CalculatePrincipalAxis(Matrix4x4 covarianceMatrix)
		{
			Vector4 vector = Vector4.UnitY;
			for (int i = 0; i < 30; i++)
			{
				Vector4 vector2 = Vector4.Transform(vector, covarianceMatrix);
				if (vector2.LengthSquared() == 0f)
				{
					break;
				}
				vector2 = Vector4.Normalize(vector2);
				if ((double)Vector4.Dot(vector, vector2) > 0.999999)
				{
					vector = vector2;
					break;
				}
				vector = vector2;
			}
			return vector;
		}

		public static void Create(Span<ColorRgba32> colors, out Vector3 mean, out Vector3 principalAxis)
		{
			Span<Vector4> span = stackalloc Vector4[colors.Length];
			ConvertToVector4(colors, span);
			Vector4 mean2;
			Matrix4x4 covarianceMatrix = CalculateCovariance(span, out mean2);
			mean = new Vector3(mean2.X, mean2.Y, mean2.Z);
			Vector4 vector = CalculatePrincipalAxis(covarianceMatrix);
			principalAxis = new Vector3(vector.X, vector.Y, vector.Z);
			if (principalAxis.LengthSquared() == 0f)
			{
				principalAxis = Vector3.UnitY;
			}
			else
			{
				principalAxis = Vector3.Normalize(principalAxis);
			}
		}

		public static void Create(Span<ColorRgbFloat> colors, out Vector3 mean, out Vector3 principalAxis)
		{
			Span<Vector4> span = stackalloc Vector4[colors.Length];
			ConvertToVector4(colors, span);
			Vector4 mean2;
			Matrix4x4 covarianceMatrix = CalculateCovariance(span, out mean2);
			mean = new Vector3(mean2.X, mean2.Y, mean2.Z);
			Vector4 vector = CalculatePrincipalAxis(covarianceMatrix);
			principalAxis = new Vector3(vector.X, vector.Y, vector.Z);
			if (principalAxis.LengthSquared() == 0f)
			{
				principalAxis = Vector3.UnitY;
			}
			else
			{
				principalAxis = Vector3.Normalize(principalAxis);
			}
		}

		public static void CreateWithAlpha(Span<ColorRgba32> colors, out Vector4 mean, out Vector4 principalAxis)
		{
			Span<Vector4> span = stackalloc Vector4[colors.Length];
			ConvertToVector4(colors, span);
			Matrix4x4 covarianceMatrix = CalculateCovariance(span, out mean);
			principalAxis = CalculatePrincipalAxis(covarianceMatrix);
		}

		public static void GetExtremePoints(Span<ColorRgba32> colors, Vector3 mean, Vector3 principalAxis, out ColorRgb24 min, out ColorRgb24 max)
		{
			float num = 0f;
			float num2 = 0f;
			for (int i = 0; i < colors.Length; i++)
			{
				float num3 = Vector3.Dot(new Vector3((float)(int)colors[i].r / 255f, (float)(int)colors[i].g / 255f, (float)(int)colors[i].b / 255f) - mean, principalAxis);
				if (num3 < num)
				{
					num = num3;
				}
				if (num3 > num2)
				{
					num2 = num3;
				}
			}
			Vector3 vector = mean + principalAxis * num;
			Vector3 vector2 = mean + principalAxis * num2;
			int num4 = (int)(vector.X * 255f);
			int num5 = (int)(vector.Y * 255f);
			int num6 = (int)(vector.Z * 255f);
			int num7 = (int)(vector2.X * 255f);
			int num8 = (int)(vector2.Y * 255f);
			int num9 = (int)(vector2.Z * 255f);
			num4 = ((num4 >= 0) ? num4 : 0);
			num5 = ((num5 >= 0) ? num5 : 0);
			num6 = ((num6 >= 0) ? num6 : 0);
			num7 = ((num7 <= 255) ? num7 : 255);
			num8 = ((num8 <= 255) ? num8 : 255);
			num9 = ((num9 <= 255) ? num9 : 255);
			min = new ColorRgb24((byte)num4, (byte)num5, (byte)num6);
			max = new ColorRgb24((byte)num7, (byte)num8, (byte)num9);
		}

		public static void GetMinMaxColor565(Span<ColorRgba32> colors, Vector3 mean, Vector3 principalAxis, out ColorRgb565 min, out ColorRgb565 max)
		{
			float num = 0f;
			float num2 = 0f;
			for (int i = 0; i < colors.Length; i++)
			{
				float num3 = Vector3.Dot(new Vector3((float)(int)colors[i].r / 255f, (float)(int)colors[i].g / 255f, (float)(int)colors[i].b / 255f) - mean, principalAxis);
				if (num3 < num)
				{
					num = num3;
				}
				if (num3 > num2)
				{
					num2 = num3;
				}
			}
			num *= 0.9375f;
			num2 *= 0.9375f;
			Vector3 vector = mean + principalAxis * num;
			Vector3 vector2 = mean + principalAxis * num2;
			int num4 = (int)(vector.X * 255f);
			int num5 = (int)(vector.Y * 255f);
			int num6 = (int)(vector.Z * 255f);
			int num7 = (int)(vector2.X * 255f);
			int num8 = (int)(vector2.Y * 255f);
			int num9 = (int)(vector2.Z * 255f);
			num4 = ((num4 >= 0) ? num4 : 0);
			num5 = ((num5 >= 0) ? num5 : 0);
			num6 = ((num6 >= 0) ? num6 : 0);
			num7 = ((num7 <= 255) ? num7 : 255);
			num8 = ((num8 <= 255) ? num8 : 255);
			num9 = ((num9 <= 255) ? num9 : 255);
			num4 = (num4 & 0xF8) | (num4 >> 5);
			num5 = (num5 & 0xFC) | (num5 >> 6);
			num6 = (num6 & 0xF8) | (num6 >> 5);
			num7 = (num7 & 0xF8) | (num7 >> 5);
			num8 = (num8 & 0xFC) | (num8 >> 6);
			num9 = (num9 & 0xF8) | (num9 >> 5);
			min = new ColorRgb565((byte)num4, (byte)num5, (byte)num6);
			max = new ColorRgb565((byte)num7, (byte)num8, (byte)num9);
		}

		public static void GetExtremePointsWithAlpha(Span<ColorRgba32> colors, Vector4 mean, Vector4 principalAxis, out Vector4 min, out Vector4 max)
		{
			float num = 0f;
			float num2 = 0f;
			for (int i = 0; i < colors.Length; i++)
			{
				float num3 = Vector4.Dot(new Vector4((float)(int)colors[i].r / 255f, (float)(int)colors[i].g / 255f, (float)(int)colors[i].b / 255f, (float)(int)colors[i].a / 255f) - mean, principalAxis);
				if (num3 < num)
				{
					num = num3;
				}
				if (num3 > num2)
				{
					num2 = num3;
				}
			}
			min = mean + principalAxis * num;
			max = mean + principalAxis * num2;
		}

		public static void GetExtremePoints(Span<ColorRgbFloat> colors, Vector3 mean, Vector3 principalAxis, out Vector3 min, out Vector3 max)
		{
			float num = 0f;
			float num2 = 0f;
			for (int i = 0; i < colors.Length; i++)
			{
				float num3 = Vector3.Dot(new Vector3(colors[i].r, colors[i].g, colors[i].b) - mean, principalAxis);
				if (num3 < num)
				{
					num = num3;
				}
				if (num3 > num2)
				{
					num2 = num3;
				}
			}
			num *= 0.9375f;
			num2 *= 0.9375f;
			min = mean + principalAxis * num;
			max = mean + principalAxis * num2;
		}
	}
}
