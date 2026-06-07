using System;
using Assets.Scripts.Craft.Parts.Fuselage;
using Assets.Scripts.Craft.Wings.Utilities;
using Unity.Collections;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.MeshGen
{
	public static class SimpleInset
	{
		public static void Inflate(NativeList<float2> inPoints, NativeList<float2> outPoints, NativeList<float2> outNormals, float radius, int vertsPerTurn = 20)
		{
			float2 float5 = inPoints[inPoints.Length - 1];
			for (int i = 0; i < inPoints.Length; i++)
			{
				float2 float6 = inPoints[i];
				float2 obj = inPoints[(i + 1) % inPoints.Length];
				float2 float7 = math.normalize(float6 - float5);
				float2 float8 = math.normalize(obj - float6);
				if (!math.any(math.isnan(math.float4(float7, float8))))
				{
					float arg = ((complex)float8 * ((complex)float7).conj).arg;
					arg = 0f - MathUtils.Repeat(0f - arg, MathF.PI * 2f);
					float num = ((complex)float7).arg + MathF.PI / 2f;
					int num2 = math.max(2, (int)math.round((float)vertsPerTurn * math.abs(arg) / (MathF.PI * 2f)));
					float num3 = arg / (float)(num2 - 1);
					for (int j = 0; j < num2; j++)
					{
						float2 value = (float2)complex.FromArgMag(num + (float)j * num3, 1f);
						outPoints.Add(float6 + value * radius);
						outNormals.Add(in value);
					}
					float5 = float6;
				}
			}
			if (outPoints.Length == 0 && inPoints.Length != 0)
			{
				float2 float9 = inPoints[0];
				float num4 = MathF.PI * -2f / (float)(vertsPerTurn - 1);
				for (int k = 0; k < vertsPerTurn; k++)
				{
					float2 value2 = (float2)complex.FromArgMag((float)k * num4, 1f);
					outPoints.Add(float9 + value2 * radius);
					outNormals.Add(in value2);
				}
			}
		}

		public static float EstimateMaxInset(NativeList<float2> points)
		{
			Span<float> span = stackalloc float[points.Length];
			float2 float5 = points[points.Length - 1];
			for (int i = 0; i < points.Length; i++)
			{
				float2 float6 = points[i];
				float2 obj = points[(i + 1) % points.Length];
				float2 inVec = float6 - float5;
				float2 outVec = obj - float6;
				span[i] = ComputePointShrinkage(inVec, outVec);
				float5 = float6;
			}
			float num = float.PositiveInfinity;
			for (int j = 0; j < points.Length; j++)
			{
				int index = j;
				int index2 = (j + 1) % points.Length;
				float num2 = math.distance(points[index], points[index2]);
				float num3 = span[index] + span[index2];
				num = math.min(num, num2 / num3);
			}
			return num;
		}

		public static float Inset(NativeList<float2> inPoints, float insetBy, float? minSize = null, bool mergePoints = true)
		{
			if (insetBy == 0f)
			{
				return 0f;
			}
			int numPoints = inPoints.Length;
			Span<float2> span = stackalloc float2[numPoints];
			Span<float> span2 = stackalloc float[numPoints];
			Span<float2> span3 = stackalloc float2[numPoints];
			Span<int> span4 = stackalloc int[numPoints];
			Span<int> mergedTo = stackalloc int[numPoints];
			for (int i = 0; i < numPoints; i++)
			{
				span[i] = inPoints[i];
				mergedTo[i] = i;
			}
			float num = insetBy;
			while (num > 0f)
			{
				for (int j = 0; j < numPoints; j++)
				{
					float2 float5 = span[j];
					float2 float6 = span[Prev(j)];
					float2 obj = span[Next(j)];
					float2 float7 = float5 - float6;
					float2 float8 = obj - float5;
					while (j == 0 && math.lengthsq(float7) < 1.1920929E-07f)
					{
						Merge(numPoints - 1, span, mergedTo);
						if (numPoints < 3)
						{
							break;
						}
						float6 = numPoints - 1;
						float7 = float5 - float6;
					}
					if (numPoints < 3)
					{
						break;
					}
					while (j < numPoints - 1 && math.lengthsq(float8) < 1.1920929E-07f)
					{
						Merge(j, span, mergedTo);
						if (numPoints < 3)
						{
							break;
						}
						float8 = span[Next(j)] - float5;
					}
					if (numPoints < 3)
					{
						break;
					}
					span2[j] = ComputePointShrinkage(float7, float8);
					span3[j] = ComputePointVelocity(span2[j], float7);
				}
				if (numPoints < 3)
				{
					break;
				}
				float num2 = num;
				float num3 = 0f;
				int num4 = 0;
				for (int k = 0; k < numPoints; k++)
				{
					int index = Next(k);
					float2 float9 = span[k];
					float2 float10 = span[index];
					float num5 = span2[k] + span2[index];
					float num6 = num2 * num5;
					float num7 = math.length(float10 - float9) / num5;
					num3 = math.max(num3, num7);
					if (num6 > 0f && num2 + 1.1920929E-07f > num7)
					{
						float num8 = num7;
						if (num8 < num2 - 1E-05f)
						{
							num4 = 0;
						}
						num2 = math.min(num2, num8);
						span4[num4++] = k;
					}
				}
				bool flag = false;
				if (minSize.HasValue)
				{
					num3 -= minSize.Value;
					if (num2 > num3 - 1.1920929E-07f)
					{
						num4 = 0;
						flag = true;
						num2 = num3;
					}
				}
				for (int l = 0; l < numPoints; l++)
				{
					float2 float11 = span[l];
					float11 += span3[l] * num2;
					span[l] = float11;
				}
				num -= num2;
				for (int m = 0; m < num4; m++)
				{
					Merge(span4[m] - m, span, mergedTo);
					if (numPoints < 3)
					{
						break;
					}
				}
				if (numPoints < 3 || flag)
				{
					break;
				}
			}
			if (mergePoints)
			{
				inPoints.Length = numPoints;
				Span<float2> span5 = span;
				span5.Slice(0, numPoints).CopyTo(inPoints.AsArray().AsSpan());
			}
			else
			{
				for (int n = 0; n < inPoints.Length; n++)
				{
					inPoints[n] = span[mergedTo[n]];
				}
			}
			return insetBy - num;
			void Merge(int num10, Span<float2> points, Span<int> span6)
			{
				int num9 = Next(num10);
				numPoints--;
				for (int num11 = num10 + 1; num11 < numPoints; num11++)
				{
					points[num11] = points[num11 + 1];
				}
				if (!mergePoints)
				{
					for (int num12 = 0; num12 < span6.Length; num12++)
					{
						int num13 = span6[num12];
						if (num13 == num9)
						{
							span6[num12] = num10;
						}
						else if (num13 > num9)
						{
							span6[num12] = num13 - 1;
						}
					}
				}
			}
			int Next(int num9)
			{
				return (num9 + 1) % numPoints;
			}
			int Prev(int num9)
			{
				return (num9 + numPoints - 1) % numPoints;
			}
		}

		public static void Inset(NativeList<Point> inPoints, float insetBy, float? minSize = null, bool mergePoints = true)
		{
			if (insetBy == 0f)
			{
				return;
			}
			int numPoints = inPoints.Length;
			Span<Point> span = stackalloc Point[numPoints];
			Span<float> span2 = stackalloc float[numPoints];
			Span<float2> span3 = stackalloc float2[numPoints];
			Span<int> span4 = stackalloc int[numPoints];
			Span<int> mergedTo = stackalloc int[numPoints];
			Span<float2> angleVectors = stackalloc float2[numPoints];
			for (int i = 0; i < numPoints; i++)
			{
				span[i] = inPoints[i];
				mergedTo[i] = i;
				angleVectors[i] = FracToVec(span[i].Fraction);
			}
			float num = insetBy;
			while (num > 0f)
			{
				for (int j = 0; j < numPoints; j++)
				{
					float2 position = span[j].Position;
					float2 position2 = span[Prev(j)].Position;
					float2 position3 = span[Next(j)].Position;
					float2 float5 = position - position2;
					float2 float6 = position3 - position;
					while (j == 0 && math.lengthsq(float5) < 1.1920929E-07f)
					{
						Merge(numPoints - 1, angleVectors, span, mergedTo);
						if (numPoints < 3)
						{
							break;
						}
						position2 = numPoints - 1;
						float5 = position - position2;
					}
					if (numPoints < 3)
					{
						break;
					}
					while (j < numPoints - 1 && math.lengthsq(float6) < 1.1920929E-07f)
					{
						Merge(j, angleVectors, span, mergedTo);
						if (numPoints < 3)
						{
							break;
						}
						float6 = span[Next(j)].Position - position;
					}
					if (numPoints < 3)
					{
						break;
					}
					span2[j] = ComputePointShrinkage(float5, float6);
					span3[j] = ComputePointVelocity(span2[j], float5);
				}
				if (numPoints < 3)
				{
					break;
				}
				float num2 = num;
				float num3 = 0f;
				int num4 = 0;
				for (int k = 0; k < numPoints; k++)
				{
					int index = Next(k);
					float2 position4 = span[k].Position;
					float2 position5 = span[index].Position;
					float num5 = span2[k] + span2[index];
					float num6 = num2 * num5;
					float num7 = math.length(position5 - position4) / num5;
					num3 = math.max(num3, num7);
					if (num6 > 0f && num2 + 1.1920929E-07f > num7)
					{
						float num8 = num7;
						if (num8 < num2 - 1E-05f)
						{
							num4 = 0;
						}
						num2 = math.min(num2, num8);
						span4[num4++] = k;
					}
				}
				bool flag = false;
				if (minSize.HasValue)
				{
					num3 -= minSize.Value;
					if (num2 > num3 - 1.1920929E-07f)
					{
						num4 = 0;
						flag = true;
						num2 = num3;
					}
				}
				for (int l = 0; l < numPoints; l++)
				{
					Point point = span[l];
					point.Position += span3[l] * num2;
					span[l] = point;
				}
				num -= num2;
				for (int m = 0; m < num4; m++)
				{
					Merge(span4[m] - m, angleVectors, span, mergedTo);
					if (numPoints < 3)
					{
						break;
					}
				}
				if (numPoints < 3 || flag)
				{
					break;
				}
			}
			for (int n = 0; n < numPoints; n++)
			{
				Point point2 = span[n];
				point2.Fraction = VecToFrac(angleVectors[n]);
				span[n] = point2;
			}
			if (mergePoints)
			{
				inPoints.Length = numPoints;
				Span<Point> span5 = span;
				span5.Slice(0, numPoints).CopyTo(inPoints.AsArray().AsSpan());
				return;
			}
			for (int num9 = 0; num9 < inPoints.Length; num9++)
			{
				Point value = inPoints[num9];
				value.Position = span[mergedTo[num9]].Position;
				inPoints[num9] = value;
			}
			static float2 FracToVec(float frac)
			{
				float2 result = default(float2);
				math.sincos(frac * (MathF.PI * 2f), out result.x, out result.y);
				return result;
			}
			void Merge(int num11, Span<float2> span6, Span<Point> points, Span<int> span7)
			{
				int num10 = Next(num11);
				Point point3 = points[num11];
				Point point4 = points[num10];
				points[num11] = new Point
				{
					Position = point3.Position,
					Sharp = true,
					Tangent = point3.Tangent,
					TangentB = (point4.Sharp ? point4.TangentB : point4.Tangent)
				};
				span6[num11] = span6[num10] + span6[num11];
				numPoints--;
				for (int num12 = num11 + 1; num12 < numPoints; num12++)
				{
					points[num12] = points[num12 + 1];
					span6[num12] = span6[num12 + 1];
				}
				if (!mergePoints)
				{
					for (int num13 = 0; num13 < span7.Length; num13++)
					{
						int num14 = span7[num13];
						if (num14 == num10)
						{
							span7[num13] = num11;
						}
						else if (num14 > num10)
						{
							span7[num13] = num14 - 1;
						}
					}
				}
			}
			int Next(int num10)
			{
				return (num10 + 1) % numPoints;
			}
			int Prev(int num10)
			{
				return (num10 + numPoints - 1) % numPoints;
			}
			static float VecToFrac(float2 vec)
			{
				if (math.lengthsq(vec) < 1.1920929E-07f)
				{
					return 0f;
				}
				return MathUtils.Repeat(math.atan2(vec.x, vec.y) * (1f / (2f * MathF.PI)), 1f);
			}
		}

		public static float ComputePointShrinkage(float2 inVec, float2 outVec)
		{
			float2 v = math.normalize(inVec);
			float2 float5 = math.normalize(outVec);
			float2 float6 = Rotate(v);
			float2 float7 = Rotate(float5);
			float num = math.dot(float6 - float7, float6);
			float num2 = math.dot(float6, float5);
			if (!(math.abs(num2) <= 1.1920929E-07f))
			{
				return num / num2;
			}
			return 0f;
		}

		public static float2 ComputePointVelocity(float pointShrinkage, float2 inVec)
		{
			float2 float5 = math.normalize(inVec);
			return Rotate(float5) - float5 * pointShrinkage;
		}

		public static float2 Rotate(float2 v)
		{
			return math.float2(v.y, 0f - v.x);
		}
	}
}
