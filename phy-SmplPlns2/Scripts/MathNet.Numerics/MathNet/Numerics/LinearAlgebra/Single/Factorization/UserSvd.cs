using System;

namespace MathNet.Numerics.LinearAlgebra.Single.Factorization
{
	internal sealed class UserSvd : Svd
	{
		public static UserSvd Create(Matrix<float> matrix, bool computeVectors)
		{
			int num = Math.Min(matrix.RowCount + 1, matrix.ColumnCount);
			Matrix<float> matrix2 = matrix.Clone();
			Vector<float> vector = Vector<float>.Build.SameAs(matrix2, num);
			Matrix<float> matrix3 = Matrix<float>.Build.SameAs(matrix2, matrix2.RowCount, matrix2.RowCount, fullyMutable: true);
			Matrix<float> matrix4 = Matrix<float>.Build.SameAs(matrix2, matrix2.ColumnCount, matrix2.ColumnCount, fullyMutable: true);
			float[] array = new float[matrix2.ColumnCount];
			float[] array2 = new float[matrix2.RowCount];
			int rowCount = matrix2.RowCount;
			int num2 = Math.Min(matrix2.RowCount - 1, matrix2.ColumnCount);
			int num3 = Math.Max(0, Math.Min(matrix2.ColumnCount - 2, matrix2.RowCount));
			int num4 = Math.Max(num2, num3);
			for (int i = 0; i < num4; i++)
			{
				int num5 = i + 1;
				if (i < num2)
				{
					float value = Dnrm2Column(matrix2, matrix2.RowCount, i, i);
					vector[i] = value;
					if ((double)vector[i] != 0.0)
					{
						if ((double)matrix2.At(i, i) != 0.0)
						{
							vector[i] = Dsign(vector[i], matrix2.At(i, i));
						}
						DscalColumn(matrix2, matrix2.RowCount, i, i, 1f / vector[i]);
						matrix2.At(i, i, 1f + matrix2.At(i, i));
					}
					vector[i] = 0f - vector[i];
				}
				for (int j = num5; j < matrix2.ColumnCount; j++)
				{
					if (i < num2 && (double)vector[i] != 0.0)
					{
						float num6 = (0f - Ddot(matrix2, matrix2.RowCount, i, j, i)) / matrix2.At(i, i);
						for (int k = i; k < matrix2.RowCount; k++)
						{
							matrix2.At(k, j, matrix2.At(k, j) + num6 * matrix2.At(k, i));
						}
					}
					array[j] = matrix2.At(i, j);
				}
				if (computeVectors && i < num2)
				{
					for (int l = i; l < matrix2.RowCount; l++)
					{
						matrix3.At(l, i, matrix2.At(l, i));
					}
				}
				if (i >= num3)
				{
					continue;
				}
				float num7 = Dnrm2Vector(array, num5);
				array[i] = num7;
				if ((double)array[i] != 0.0)
				{
					if ((double)array[num5] != 0.0)
					{
						array[i] = Dsign(array[i], array[num5]);
					}
					DscalVector(array, num5, 1f / array[i]);
					array[num5] = 1f + array[num5];
				}
				array[i] = 0f - array[i];
				if (num5 < matrix2.RowCount && (double)array[i] != 0.0)
				{
					for (int l = num5; l < matrix2.RowCount; l++)
					{
						array2[l] = 0f;
					}
					for (int j = num5; j < matrix2.ColumnCount; j++)
					{
						for (int m = num5; m < matrix2.RowCount; m++)
						{
							array2[m] += array[j] * matrix2.At(m, j);
						}
					}
					for (int j = num5; j < matrix2.ColumnCount; j++)
					{
						float num8 = (0f - array[j]) / array[num5];
						for (int n = num5; n < matrix2.RowCount; n++)
						{
							matrix2.At(n, j, matrix2.At(n, j) + num8 * array2[n]);
						}
					}
				}
				if (computeVectors)
				{
					for (int l = num5; l < matrix2.ColumnCount; l++)
					{
						matrix4.At(l, i, array[l]);
					}
				}
			}
			int num9 = Math.Min(matrix2.ColumnCount, matrix2.RowCount + 1);
			int num10 = num2 + 1;
			int num11 = num3 + 1;
			if (num2 < matrix2.ColumnCount)
			{
				vector[num10 - 1] = matrix2.At(num10 - 1, num10 - 1);
			}
			if (matrix2.RowCount < num9)
			{
				vector[num9 - 1] = 0f;
			}
			if (num11 < num9)
			{
				array[num11 - 1] = matrix2.At(num11 - 1, num9 - 1);
			}
			array[num9 - 1] = 0f;
			if (computeVectors)
			{
				for (int j = num10 - 1; j < rowCount; j++)
				{
					for (int l = 0; l < matrix2.RowCount; l++)
					{
						matrix3.At(l, j, 0f);
					}
					matrix3.At(j, j, 1f);
				}
				for (int i = num2 - 1; i >= 0; i--)
				{
					if ((double)vector[i] != 0.0)
					{
						for (int j = i + 1; j < rowCount; j++)
						{
							float num6 = (0f - Ddot(matrix3, matrix2.RowCount, i, j, i)) / matrix3.At(i, i);
							for (int num12 = i; num12 < matrix2.RowCount; num12++)
							{
								matrix3.At(num12, j, matrix3.At(num12, j) + num6 * matrix3.At(num12, i));
							}
						}
						DscalColumn(matrix3, matrix2.RowCount, i, i, -1f);
						matrix3.At(i, i, 1f + matrix3.At(i, i));
						for (int l = 0; l < i; l++)
						{
							matrix3.At(l, i, 0f);
						}
					}
					else
					{
						for (int l = 0; l < matrix2.RowCount; l++)
						{
							matrix3.At(l, i, 0f);
						}
						matrix3.At(i, i, 1f);
					}
				}
			}
			if (computeVectors)
			{
				for (int i = matrix2.ColumnCount - 1; i >= 0; i--)
				{
					int num5 = i + 1;
					if (i < num3 && (double)array[i] != 0.0)
					{
						for (int j = num5; j < matrix2.ColumnCount; j++)
						{
							float num6 = (0f - Ddot(matrix4, matrix2.ColumnCount, i, j, num5)) / matrix4.At(num5, i);
							for (int num13 = i; num13 < matrix2.ColumnCount; num13++)
							{
								matrix4.At(num13, j, matrix4.At(num13, j) + num6 * matrix4.At(num13, i));
							}
						}
					}
					for (int l = 0; l < matrix2.ColumnCount; l++)
					{
						matrix4.At(l, i, 0f);
					}
					matrix4.At(i, i, 1f);
				}
			}
			for (int l = 0; l < num9; l++)
			{
				if ((double)vector[l] != 0.0)
				{
					float num6 = vector[l];
					float num14 = vector[l] / num6;
					vector[l] = num6;
					if (l < num9 - 1)
					{
						array[l] /= num14;
					}
					if (computeVectors)
					{
						DscalColumn(matrix3, matrix2.RowCount, l, 0, num14);
					}
				}
				if (l == num9 - 1)
				{
					break;
				}
				if ((double)array[l] != 0.0)
				{
					float num6 = array[l];
					float num14 = num6 / array[l];
					array[l] = num6;
					vector[l + 1] *= num14;
					if (computeVectors)
					{
						DscalColumn(matrix4, matrix2.ColumnCount, l + 1, 0, num14);
					}
				}
			}
			int num15 = num9;
			int num16 = 0;
			while (num9 > 0)
			{
				if (num16 >= 1000)
				{
					throw new NonConvergenceException();
				}
				int i;
				for (i = num9 - 2; i >= 0; i--)
				{
					float num17 = Math.Abs(vector[i]) + Math.Abs(vector[i + 1]);
					if ((num17 + Math.Abs(array[i])).AlmostEqualRelative(num17, 7))
					{
						array[i] = 0f;
						break;
					}
				}
				int num18;
				if (i == num9 - 2)
				{
					num18 = 4;
				}
				else
				{
					int num19;
					for (num19 = num9 - 1; num19 > i; num19--)
					{
						float num17 = 0f;
						if (num19 != num9 - 1)
						{
							num17 += Math.Abs(array[num19]);
						}
						if (num19 != i + 1)
						{
							num17 += Math.Abs(array[num19 - 1]);
						}
						if ((num17 + Math.Abs(vector[num19])).AlmostEqualRelative(num17, 7))
						{
							vector[num19] = 0f;
							break;
						}
					}
					if (num19 == i)
					{
						num18 = 3;
					}
					else if (num19 == num9 - 1)
					{
						num18 = 1;
					}
					else
					{
						num18 = 2;
						i = num19;
					}
				}
				i++;
				float c;
				float s;
				switch (num18)
				{
				case 1:
				{
					float da = array[num9 - 2];
					array[num9 - 2] = 0f;
					for (int num29 = i; num29 < num9 - 1; num29++)
					{
						int num28 = num9 - 2 - num29 + i;
						float da2 = vector[num28];
						Drotg(ref da2, ref da, out c, out s);
						vector[num28] = da2;
						if (num28 != i)
						{
							da = (0f - s) * array[num28 - 1];
							array[num28 - 1] = c * array[num28 - 1];
						}
						if (computeVectors)
						{
							Drot(matrix4, matrix2.ColumnCount, num28, num9 - 1, c, s);
						}
					}
					break;
				}
				case 2:
				{
					float da = array[i - 1];
					array[i - 1] = 0f;
					for (int num28 = i; num28 < num9; num28++)
					{
						float da2 = vector[num28];
						Drotg(ref da2, ref da, out c, out s);
						vector[num28] = da2;
						da = (0f - s) * array[num28];
						array[num28] = c * array[num28];
						if (computeVectors)
						{
							Drot(matrix3, matrix2.RowCount, num28, i - 1, c, s);
						}
					}
					break;
				}
				case 3:
				{
					float val = 0f;
					val = Math.Max(val, Math.Abs(vector[num9 - 1]));
					val = Math.Max(val, Math.Abs(vector[num9 - 2]));
					val = Math.Max(val, Math.Abs(array[num9 - 2]));
					val = Math.Max(val, Math.Abs(vector[i]));
					val = Math.Max(val, Math.Abs(array[i]));
					float num20 = vector[num9 - 1] / val;
					float num21 = vector[num9 - 2] / val;
					float num22 = array[num9 - 2] / val;
					float num23 = vector[i] / val;
					float num24 = array[i] / val;
					float num25 = ((num21 + num20) * (num21 - num20) + num22 * num22) / 2f;
					float num26 = num20 * num22 * (num20 * num22);
					float num27 = 0f;
					if ((double)num25 != 0.0 || (double)num26 != 0.0)
					{
						num27 = (float)Math.Sqrt(num25 * num25 + num26);
						if ((double)num25 < 0.0)
						{
							num27 = 0f - num27;
						}
						num27 = num26 / (num25 + num27);
					}
					float da = (num23 + num20) * (num23 - num20) + num27;
					float db = num23 * num24;
					for (int num28 = i; num28 < num9 - 1; num28++)
					{
						Drotg(ref da, ref db, out c, out s);
						if (num28 != i)
						{
							array[num28 - 1] = da;
						}
						da = c * vector[num28] + s * array[num28];
						array[num28] = c * array[num28] - s * vector[num28];
						db = s * vector[num28 + 1];
						vector[num28 + 1] = c * vector[num28 + 1];
						if (computeVectors)
						{
							Drot(matrix4, matrix2.ColumnCount, num28, num28 + 1, c, s);
						}
						Drotg(ref da, ref db, out c, out s);
						vector[num28] = da;
						da = c * array[num28] + s * vector[num28 + 1];
						vector[num28 + 1] = (0f - s) * array[num28] + c * vector[num28 + 1];
						db = s * array[num28 + 1];
						array[num28 + 1] = c * array[num28 + 1];
						if (computeVectors && num28 < matrix2.RowCount)
						{
							Drot(matrix3, matrix2.RowCount, num28, num28 + 1, c, s);
						}
					}
					array[num9 - 2] = da;
					num16++;
					break;
				}
				case 4:
					if ((double)vector[i] < 0.0)
					{
						vector[i] = 0f - vector[i];
						if (computeVectors)
						{
							DscalColumn(matrix4, matrix2.ColumnCount, i, 0, -1f);
						}
					}
					for (; i != num15 - 1 && !(vector[i] >= vector[i + 1]); i++)
					{
						float num6 = vector[i];
						vector[i] = vector[i + 1];
						vector[i + 1] = num6;
						if (computeVectors && i < matrix2.ColumnCount)
						{
							Dswap(matrix4, matrix2.ColumnCount, i, i + 1);
						}
						if (computeVectors && i < matrix2.RowCount)
						{
							Dswap(matrix3, matrix2.RowCount, i, i + 1);
						}
					}
					num16 = 0;
					num9--;
					break;
				}
			}
			if (computeVectors)
			{
				matrix4 = matrix4.Transpose();
			}
			if (matrix2.RowCount < matrix2.ColumnCount)
			{
				num--;
				Vector<float> vector2 = Vector<float>.Build.SameAs(matrix2, num);
				for (int l = 0; l < num; l++)
				{
					vector2[l] = vector[l];
				}
				vector = vector2;
			}
			return new UserSvd(vector, matrix3, matrix4, computeVectors);
		}

		private UserSvd(Vector<float> s, Matrix<float> u, Matrix<float> vt, bool vectorsComputed)
			: base(s, u, vt, vectorsComputed)
		{
		}

		private static float Dsign(float z1, float z2)
		{
			return Math.Abs(z1) * (z2 / Math.Abs(z2));
		}

		private static void Dswap(Matrix<float> a, int rowCount, int columnA, int columnB)
		{
			for (int i = 0; i < rowCount; i++)
			{
				float value = a.At(i, columnA);
				a.At(i, columnA, a.At(i, columnB));
				a.At(i, columnB, value);
			}
		}

		private static void DscalColumn(Matrix<float> a, int rowCount, int column, int rowStart, float z)
		{
			for (int i = rowStart; i < rowCount; i++)
			{
				a.At(i, column, a.At(i, column) * z);
			}
		}

		private static void DscalVector(float[] a, int start, float z)
		{
			for (int i = start; i < a.Length; i++)
			{
				a[i] *= z;
			}
		}

		private static void Drotg(ref float da, ref float db, out float c, out float s)
		{
			float num = db;
			float num2 = Math.Abs(da);
			float num3 = Math.Abs(db);
			if (num2 > num3)
			{
				num = da;
			}
			float num4 = num2 + num3;
			float num5;
			float num6;
			if ((double)num4 == 0.0)
			{
				c = 1f;
				s = 0f;
				num5 = 0f;
				num6 = 0f;
			}
			else
			{
				float num7 = da / num4;
				float num8 = db / num4;
				num5 = num4 * (float)Math.Sqrt(num7 * num7 + num8 * num8);
				if ((double)num < 0.0)
				{
					num5 = 0f - num5;
				}
				c = da / num5;
				s = db / num5;
				num6 = 1f;
				if (num2 > num3)
				{
					num6 = s;
				}
				if (num3 >= num2 && (double)c != 0.0)
				{
					num6 = 1f / c;
				}
			}
			da = num5;
			db = num6;
		}

		private static float Dnrm2Column(Matrix<float> a, int rowCount, int column, int rowStart)
		{
			float num = 0f;
			for (int i = rowStart; i < rowCount; i++)
			{
				num += a.At(i, column) * a.At(i, column);
			}
			return (float)Math.Sqrt(num);
		}

		private static float Dnrm2Vector(float[] a, int rowStart)
		{
			float num = 0f;
			for (int i = rowStart; i < a.Length; i++)
			{
				num += a[i] * a[i];
			}
			return (float)Math.Sqrt(num);
		}

		private static float Ddot(Matrix<float> a, int rowCount, int columnA, int columnB, int rowStart)
		{
			float num = 0f;
			for (int i = rowStart; i < rowCount; i++)
			{
				num += a.At(i, columnB) * a.At(i, columnA);
			}
			return num;
		}

		private static void Drot(Matrix<float> a, int rowCount, int columnA, int columnB, float c, float s)
		{
			for (int i = 0; i < rowCount; i++)
			{
				float value = c * a.At(i, columnA) + s * a.At(i, columnB);
				float value2 = c * a.At(i, columnB) - s * a.At(i, columnA);
				a.At(i, columnB, value2);
				a.At(i, columnA, value);
			}
		}

		public override void Solve(Matrix<float> input, Matrix<float> result)
		{
			if (!VectorsComputed)
			{
				throw new InvalidOperationException("The singular vectors were not computed.");
			}
			if (input.ColumnCount != result.ColumnCount)
			{
				throw new ArgumentException("Matrix column dimensions must agree.");
			}
			if (base.U.RowCount != input.RowCount)
			{
				throw new ArgumentException("Matrix row dimensions must agree.");
			}
			if (base.VT.ColumnCount != result.RowCount)
			{
				throw new ArgumentException("Matrix column dimensions must agree.");
			}
			int num = Math.Min(base.U.RowCount, base.VT.ColumnCount);
			int columnCount = input.ColumnCount;
			float[] array = new float[base.VT.ColumnCount];
			for (int i = 0; i < columnCount; i++)
			{
				for (int j = 0; j < base.VT.ColumnCount; j++)
				{
					float num2 = 0f;
					if (j < num)
					{
						for (int k = 0; k < base.U.RowCount; k++)
						{
							num2 += base.U.At(k, j) * input.At(k, i);
						}
						num2 /= base.S[j];
					}
					array[j] = num2;
				}
				for (int l = 0; l < base.VT.ColumnCount; l++)
				{
					float num3 = 0f;
					for (int m = 0; m < base.VT.ColumnCount; m++)
					{
						num3 += base.VT.At(m, l) * array[m];
					}
					result.At(l, i, num3);
				}
			}
		}

		public override void Solve(Vector<float> input, Vector<float> result)
		{
			if (!VectorsComputed)
			{
				throw new InvalidOperationException("The singular vectors were not computed.");
			}
			if (base.U.RowCount != input.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (base.VT.ColumnCount != result.Count)
			{
				throw Matrix<float>.DimensionsDontMatch<ArgumentException>(base.VT, result);
			}
			int num = Math.Min(base.U.RowCount, base.VT.ColumnCount);
			float[] array = new float[base.VT.ColumnCount];
			for (int i = 0; i < base.VT.ColumnCount; i++)
			{
				float num2 = 0f;
				if (i < num)
				{
					for (int j = 0; j < base.U.RowCount; j++)
					{
						num2 += base.U.At(j, i) * input[j];
					}
					num2 /= base.S[i];
				}
				array[i] = num2;
			}
			for (int k = 0; k < base.VT.ColumnCount; k++)
			{
				float num2 = 0f;
				for (int l = 0; l < base.VT.ColumnCount; l++)
				{
					num2 += base.VT.At(l, k) * array[l];
				}
				result[k] = num2;
			}
		}
	}
}
