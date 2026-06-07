using System;
using System.Numerics;

namespace MathNet.Numerics.LinearAlgebra.Complex.Factorization
{
	internal sealed class UserSvd : Svd
	{
		public static UserSvd Create(Matrix<System.Numerics.Complex> matrix, bool computeVectors)
		{
			int num = Math.Min(matrix.RowCount + 1, matrix.ColumnCount);
			Matrix<System.Numerics.Complex> matrix2 = matrix.Clone();
			Vector<System.Numerics.Complex> vector = Vector<System.Numerics.Complex>.Build.SameAs(matrix2, num);
			Matrix<System.Numerics.Complex> matrix3 = Matrix<System.Numerics.Complex>.Build.SameAs(matrix2, matrix2.RowCount, matrix2.RowCount, fullyMutable: true);
			Matrix<System.Numerics.Complex> matrix4 = Matrix<System.Numerics.Complex>.Build.SameAs(matrix2, matrix2.ColumnCount, matrix2.ColumnCount, fullyMutable: true);
			System.Numerics.Complex[] array = new System.Numerics.Complex[matrix2.ColumnCount];
			System.Numerics.Complex[] array2 = new System.Numerics.Complex[matrix2.RowCount];
			int rowCount = matrix2.RowCount;
			int num2 = Math.Min(matrix2.RowCount - 1, matrix2.ColumnCount);
			int num3 = Math.Max(0, Math.Min(matrix2.ColumnCount - 2, matrix2.RowCount));
			int num4 = Math.Max(num2, num3);
			for (int i = 0; i < num4; i++)
			{
				int num5 = i + 1;
				if (i < num2)
				{
					vector[i] = Cnrm2Column(matrix2, matrix2.RowCount, i, i);
					if (vector[i].Magnitude != 0.0)
					{
						if (matrix2.At(i, i).Magnitude != 0.0)
						{
							vector[i] = Csign(vector[i], matrix2.At(i, i));
						}
						CscalColumn(matrix2, matrix2.RowCount, i, i, 1.0 / vector[i]);
						matrix2.At(i, i, System.Numerics.Complex.One + matrix2.At(i, i));
					}
					vector[i] = -vector[i];
				}
				for (int j = num5; j < matrix2.ColumnCount; j++)
				{
					if (i < num2 && vector[i].Magnitude != 0.0)
					{
						System.Numerics.Complex complex = -Cdotc(matrix2, matrix2.RowCount, i, j, i) / matrix2.At(i, i);
						if (complex != System.Numerics.Complex.Zero)
						{
							for (int k = i; k < matrix2.RowCount; k++)
							{
								matrix2.At(k, j, matrix2.At(k, j) + complex * matrix2.At(k, i));
							}
						}
					}
					array[j] = matrix2.At(i, j).Conjugate();
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
				double num6 = Cnrm2Vector(array, num5);
				array[i] = num6;
				if (array[i].Magnitude != 0.0)
				{
					if (array[num5].Magnitude != 0.0)
					{
						array[i] = Csign(array[i], array[num5]);
					}
					CscalVector(array, num5, 1.0 / array[i]);
					array[num5] = System.Numerics.Complex.One + array[num5];
				}
				array[i] = -array[i].Conjugate();
				if (num5 < matrix2.RowCount && array[i].Magnitude != 0.0)
				{
					for (int l = num5; l < matrix2.RowCount; l++)
					{
						array2[l] = System.Numerics.Complex.Zero;
					}
					for (int j = num5; j < matrix2.ColumnCount; j++)
					{
						if (array[j] != System.Numerics.Complex.Zero)
						{
							for (int m = num5; m < matrix2.RowCount; m++)
							{
								array2[m] += array[j] * matrix2.At(m, j);
							}
						}
					}
					for (int j = num5; j < matrix2.ColumnCount; j++)
					{
						System.Numerics.Complex complex2 = (-array[j] / array[num5]).Conjugate();
						if (complex2 != System.Numerics.Complex.Zero)
						{
							for (int n = num5; n < matrix2.RowCount; n++)
							{
								matrix2.At(n, j, matrix2.At(n, j) + complex2 * array2[n]);
							}
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
			int num7 = Math.Min(matrix2.ColumnCount, matrix2.RowCount + 1);
			int num8 = num2 + 1;
			int num9 = num3 + 1;
			if (num2 < matrix2.ColumnCount)
			{
				vector[num8 - 1] = matrix2.At(num8 - 1, num8 - 1);
			}
			if (matrix2.RowCount < num7)
			{
				vector[num7 - 1] = System.Numerics.Complex.Zero;
			}
			if (num9 < num7)
			{
				array[num9 - 1] = matrix2.At(num9 - 1, num7 - 1);
			}
			array[num7 - 1] = System.Numerics.Complex.Zero;
			if (computeVectors)
			{
				for (int j = num8 - 1; j < rowCount; j++)
				{
					for (int l = 0; l < matrix2.RowCount; l++)
					{
						matrix3.At(l, j, System.Numerics.Complex.Zero);
					}
					matrix3.At(j, j, System.Numerics.Complex.One);
				}
				for (int i = num2 - 1; i >= 0; i--)
				{
					if (vector[i].Magnitude != 0.0)
					{
						for (int j = i + 1; j < rowCount; j++)
						{
							System.Numerics.Complex complex = -Cdotc(matrix3, matrix2.RowCount, i, j, i) / matrix3.At(i, i);
							if (complex != System.Numerics.Complex.Zero)
							{
								for (int num10 = i; num10 < matrix2.RowCount; num10++)
								{
									matrix3.At(num10, j, matrix3.At(num10, j) + complex * matrix3.At(num10, i));
								}
							}
						}
						CscalColumn(matrix3, matrix2.RowCount, i, i, -1.0);
						matrix3.At(i, i, System.Numerics.Complex.One + matrix3.At(i, i));
						for (int l = 0; l < i; l++)
						{
							matrix3.At(l, i, System.Numerics.Complex.Zero);
						}
					}
					else
					{
						for (int l = 0; l < matrix2.RowCount; l++)
						{
							matrix3.At(l, i, System.Numerics.Complex.Zero);
						}
						matrix3.At(i, i, System.Numerics.Complex.One);
					}
				}
			}
			if (computeVectors)
			{
				for (int i = matrix2.ColumnCount - 1; i >= 0; i--)
				{
					int num5 = i + 1;
					if (i < num3 && array[i].Magnitude != 0.0)
					{
						for (int j = num5; j < matrix2.ColumnCount; j++)
						{
							System.Numerics.Complex complex = -Cdotc(matrix4, matrix2.ColumnCount, i, j, num5) / matrix4.At(num5, i);
							if (complex != System.Numerics.Complex.Zero)
							{
								for (int num11 = i; num11 < matrix2.ColumnCount; num11++)
								{
									matrix4.At(num11, j, matrix4.At(num11, j) + complex * matrix4.At(num11, i));
								}
							}
						}
					}
					for (int l = 0; l < matrix2.ColumnCount; l++)
					{
						matrix4.At(l, i, System.Numerics.Complex.Zero);
					}
					matrix4.At(i, i, System.Numerics.Complex.One);
				}
			}
			for (int l = 0; l < num7; l++)
			{
				if (vector[l].Magnitude != 0.0)
				{
					System.Numerics.Complex complex = vector[l].Magnitude;
					System.Numerics.Complex complex3 = vector[l] / complex;
					vector[l] = complex;
					if (l < num7 - 1)
					{
						array[l] /= complex3;
					}
					if (computeVectors)
					{
						CscalColumn(matrix3, matrix2.RowCount, l, 0, complex3);
					}
				}
				if (l == num7 - 1)
				{
					break;
				}
				if (array[l].Magnitude != 0.0)
				{
					System.Numerics.Complex complex = array[l].Magnitude;
					System.Numerics.Complex complex3 = complex / array[l];
					array[l] = complex;
					vector[l + 1] *= complex3;
					if (computeVectors)
					{
						CscalColumn(matrix4, matrix2.ColumnCount, l + 1, 0, complex3);
					}
				}
			}
			int num12 = num7;
			int num13 = 0;
			while (num7 > 0)
			{
				if (num13 >= 1000)
				{
					throw new NonConvergenceException();
				}
				int i;
				for (i = num7 - 2; i >= 0; i--)
				{
					double num14 = vector[i].Magnitude + vector[i + 1].Magnitude;
					if ((num14 + array[i].Magnitude).AlmostEqualRelative(num14, 15))
					{
						array[i] = System.Numerics.Complex.Zero;
						break;
					}
				}
				int num15;
				if (i == num7 - 2)
				{
					num15 = 4;
				}
				else
				{
					int num16;
					for (num16 = num7 - 1; num16 > i; num16--)
					{
						double num14 = 0.0;
						if (num16 != num7 - 1)
						{
							num14 += array[num16].Magnitude;
						}
						if (num16 != i + 1)
						{
							num14 += array[num16 - 1].Magnitude;
						}
						if ((num14 + vector[num16].Magnitude).AlmostEqualRelative(num14, 15))
						{
							vector[num16] = System.Numerics.Complex.Zero;
							break;
						}
					}
					if (num16 == i)
					{
						num15 = 3;
					}
					else if (num16 == num7 - 1)
					{
						num15 = 1;
					}
					else
					{
						num15 = 2;
						i = num16;
					}
				}
				i++;
				double c;
				double s;
				switch (num15)
				{
				case 1:
				{
					double da = array[num7 - 2].Real;
					array[num7 - 2] = System.Numerics.Complex.Zero;
					for (int num26 = i; num26 < num7 - 1; num26++)
					{
						int num25 = num7 - 2 - num26 + i;
						double da2 = vector[num25].Real;
						Srotg(ref da2, ref da, out c, out s);
						vector[num25] = da2;
						if (num25 != i)
						{
							da = (0.0 - s) * array[num25 - 1].Real;
							array[num25 - 1] = c * array[num25 - 1];
						}
						if (computeVectors)
						{
							Csrot(matrix4, matrix2.ColumnCount, num25, num7 - 1, c, s);
						}
					}
					break;
				}
				case 2:
				{
					double da = array[i - 1].Real;
					array[i - 1] = System.Numerics.Complex.Zero;
					for (int num25 = i; num25 < num7; num25++)
					{
						double da2 = vector[num25].Real;
						Srotg(ref da2, ref da, out c, out s);
						vector[num25] = da2;
						da = (0.0 - s) * array[num25].Real;
						array[num25] = c * array[num25];
						if (computeVectors)
						{
							Csrot(matrix3, matrix2.RowCount, num25, i - 1, c, s);
						}
					}
					break;
				}
				case 3:
				{
					double val = 0.0;
					val = Math.Max(val, vector[num7 - 1].Magnitude);
					val = Math.Max(val, vector[num7 - 2].Magnitude);
					val = Math.Max(val, array[num7 - 2].Magnitude);
					val = Math.Max(val, vector[i].Magnitude);
					val = Math.Max(val, array[i].Magnitude);
					double num17 = vector[num7 - 1].Real / val;
					double num18 = vector[num7 - 2].Real / val;
					double num19 = array[num7 - 2].Real / val;
					double num20 = vector[i].Real / val;
					double num21 = array[i].Real / val;
					double num22 = ((num18 + num17) * (num18 - num17) + num19 * num19) / 2.0;
					double num23 = num17 * num19 * (num17 * num19);
					double num24 = 0.0;
					if (num22 != 0.0 || num23 != 0.0)
					{
						num24 = Math.Sqrt(num22 * num22 + num23);
						if (num22 < 0.0)
						{
							num24 = 0.0 - num24;
						}
						num24 = num23 / (num22 + num24);
					}
					double da = (num20 + num17) * (num20 - num17) + num24;
					double db = num20 * num21;
					for (int num25 = i; num25 < num7 - 1; num25++)
					{
						Srotg(ref da, ref db, out c, out s);
						if (num25 != i)
						{
							array[num25 - 1] = da;
						}
						da = c * vector[num25].Real + s * array[num25].Real;
						array[num25] = c * array[num25] - s * vector[num25];
						db = s * vector[num25 + 1].Real;
						vector[num25 + 1] = c * vector[num25 + 1];
						if (computeVectors)
						{
							Csrot(matrix4, matrix2.ColumnCount, num25, num25 + 1, c, s);
						}
						Srotg(ref da, ref db, out c, out s);
						vector[num25] = da;
						da = c * array[num25].Real + s * vector[num25 + 1].Real;
						vector[num25 + 1] = (0.0 - s) * array[num25] + c * vector[num25 + 1];
						db = s * array[num25 + 1].Real;
						array[num25 + 1] = c * array[num25 + 1];
						if (computeVectors && num25 < matrix2.RowCount)
						{
							Csrot(matrix3, matrix2.RowCount, num25, num25 + 1, c, s);
						}
					}
					array[num7 - 2] = da;
					num13++;
					break;
				}
				case 4:
					if (vector[i].Real < 0.0)
					{
						vector[i] = -vector[i];
						if (computeVectors)
						{
							CscalColumn(matrix4, matrix2.ColumnCount, i, 0, -1.0);
						}
					}
					for (; i != num12 - 1 && !(vector[i].Real >= vector[i + 1].Real); i++)
					{
						System.Numerics.Complex complex = vector[i];
						vector[i] = vector[i + 1];
						vector[i + 1] = complex;
						if (computeVectors && i < matrix2.ColumnCount)
						{
							Swap(matrix4, matrix2.ColumnCount, i, i + 1);
						}
						if (computeVectors && i < matrix2.RowCount)
						{
							Swap(matrix3, matrix2.RowCount, i, i + 1);
						}
					}
					num13 = 0;
					num7--;
					break;
				}
			}
			if (computeVectors)
			{
				matrix4 = matrix4.ConjugateTranspose();
			}
			if (matrix2.RowCount < matrix2.ColumnCount)
			{
				num--;
				Vector<System.Numerics.Complex> vector2 = Vector<System.Numerics.Complex>.Build.SameAs(matrix2, num);
				for (int l = 0; l < num; l++)
				{
					vector2[l] = vector[l];
				}
				vector = vector2;
			}
			return new UserSvd(vector, matrix3, matrix4, computeVectors);
		}

		private UserSvd(Vector<System.Numerics.Complex> s, Matrix<System.Numerics.Complex> u, Matrix<System.Numerics.Complex> vt, bool vectorsComputed)
			: base(s, u, vt, vectorsComputed)
		{
		}

		private static System.Numerics.Complex Csign(System.Numerics.Complex z1, System.Numerics.Complex z2)
		{
			return z1.Magnitude * (z2 / z2.Magnitude);
		}

		private static void Swap(Matrix<System.Numerics.Complex> a, int rowCount, int columnA, int columnB)
		{
			for (int i = 0; i < rowCount; i++)
			{
				System.Numerics.Complex value = a.At(i, columnA);
				a.At(i, columnA, a.At(i, columnB));
				a.At(i, columnB, value);
			}
		}

		private static void CscalColumn(Matrix<System.Numerics.Complex> a, int rowCount, int column, int rowStart, System.Numerics.Complex z)
		{
			for (int i = rowStart; i < rowCount; i++)
			{
				a.At(i, column, a.At(i, column) * z);
			}
		}

		private static void CscalVector(System.Numerics.Complex[] a, int start, System.Numerics.Complex z)
		{
			for (int i = start; i < a.Length; i++)
			{
				a[i] *= z;
			}
		}

		private static void Srotg(ref double da, ref double db, out double c, out double s)
		{
			double num = db;
			double num2 = Math.Abs(da);
			double num3 = Math.Abs(db);
			if (num2 > num3)
			{
				num = da;
			}
			double num4 = num2 + num3;
			double num5;
			double num6;
			if (num4 == 0.0)
			{
				c = 1.0;
				s = 0.0;
				num5 = 0.0;
				num6 = 0.0;
			}
			else
			{
				double num7 = da / num4;
				double num8 = db / num4;
				num5 = num4 * Math.Sqrt(num7 * num7 + num8 * num8);
				if (num < 0.0)
				{
					num5 = 0.0 - num5;
				}
				c = da / num5;
				s = db / num5;
				num6 = 1.0;
				if (num2 > num3)
				{
					num6 = s;
				}
				if (num3 >= num2 && c != 0.0)
				{
					num6 = 1.0 / c;
				}
			}
			da = num5;
			db = num6;
		}

		private static double Cnrm2Column(Matrix<System.Numerics.Complex> a, int rowCount, int column, int rowStart)
		{
			double num = 0.0;
			for (int i = rowStart; i < rowCount; i++)
			{
				num += a.At(i, column).Magnitude * a.At(i, column).Magnitude;
			}
			return Math.Sqrt(num);
		}

		private static double Cnrm2Vector(System.Numerics.Complex[] a, int rowStart)
		{
			double num = 0.0;
			for (int i = rowStart; i < a.Length; i++)
			{
				num += a[i].Magnitude * a[i].Magnitude;
			}
			return Math.Sqrt(num);
		}

		private static System.Numerics.Complex Cdotc(Matrix<System.Numerics.Complex> a, int rowCount, int columnA, int columnB, int rowStart)
		{
			System.Numerics.Complex zero = System.Numerics.Complex.Zero;
			for (int i = rowStart; i < rowCount; i++)
			{
				zero += a.At(i, columnA).Conjugate() * a.At(i, columnB);
			}
			return zero;
		}

		private static void Csrot(Matrix<System.Numerics.Complex> a, int rowCount, int columnA, int columnB, double c, double s)
		{
			for (int i = 0; i < rowCount; i++)
			{
				System.Numerics.Complex value = c * a.At(i, columnA) + s * a.At(i, columnB);
				System.Numerics.Complex value2 = c * a.At(i, columnB) - s * a.At(i, columnA);
				a.At(i, columnB, value2);
				a.At(i, columnA, value);
			}
		}

		public override void Solve(Matrix<System.Numerics.Complex> input, Matrix<System.Numerics.Complex> result)
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
			System.Numerics.Complex[] array = new System.Numerics.Complex[base.VT.ColumnCount];
			for (int i = 0; i < columnCount; i++)
			{
				for (int j = 0; j < base.VT.ColumnCount; j++)
				{
					System.Numerics.Complex zero = System.Numerics.Complex.Zero;
					if (j < num)
					{
						for (int k = 0; k < base.U.RowCount; k++)
						{
							zero += base.U.At(k, j).Conjugate() * input.At(k, i);
						}
						zero /= base.S[j];
					}
					array[j] = zero;
				}
				for (int l = 0; l < base.VT.ColumnCount; l++)
				{
					System.Numerics.Complex zero2 = System.Numerics.Complex.Zero;
					for (int m = 0; m < base.VT.ColumnCount; m++)
					{
						zero2 += base.VT.At(m, l).Conjugate() * array[m];
					}
					result.At(l, i, zero2);
				}
			}
		}

		public override void Solve(Vector<System.Numerics.Complex> input, Vector<System.Numerics.Complex> result)
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
				throw Matrix<System.Numerics.Complex>.DimensionsDontMatch<ArgumentException>(base.VT, result);
			}
			int num = Math.Min(base.U.RowCount, base.VT.ColumnCount);
			System.Numerics.Complex[] array = new System.Numerics.Complex[base.VT.ColumnCount];
			for (int i = 0; i < base.VT.ColumnCount; i++)
			{
				System.Numerics.Complex zero = System.Numerics.Complex.Zero;
				if (i < num)
				{
					for (int j = 0; j < base.U.RowCount; j++)
					{
						zero += base.U.At(j, i).Conjugate() * input[j];
					}
					zero /= base.S[i];
				}
				array[i] = zero;
			}
			for (int k = 0; k < base.VT.ColumnCount; k++)
			{
				System.Numerics.Complex zero2 = System.Numerics.Complex.Zero;
				for (int l = 0; l < base.VT.ColumnCount; l++)
				{
					zero2 += base.VT.At(l, k).Conjugate() * array[l];
				}
				result[k] = zero2;
			}
		}
	}
}
