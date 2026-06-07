using System;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra.Complex;

namespace MathNet.Numerics.LinearAlgebra.Double.Factorization
{
	internal sealed class UserEvd : Evd
	{
		public static UserEvd Create(Matrix<double> matrix, Symmetricity symmetricity)
		{
			if (matrix.RowCount != matrix.ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.");
			}
			int rowCount = matrix.RowCount;
			Matrix<double> matrix2 = Matrix<double>.Build.SameAs(matrix, rowCount, rowCount, fullyMutable: true);
			Matrix<double> matrix3 = Matrix<double>.Build.SameAs(matrix, rowCount, rowCount);
			MathNet.Numerics.LinearAlgebra.Complex.DenseVector denseVector = new MathNet.Numerics.LinearAlgebra.Complex.DenseVector(rowCount);
			bool flag;
			switch (symmetricity)
			{
			case Symmetricity.Symmetric:
			case Symmetricity.Hermitian:
				flag = true;
				break;
			case Symmetricity.Asymmetric:
				flag = false;
				break;
			default:
				flag = matrix.IsSymmetric();
				break;
			}
			double[] array = new double[rowCount];
			double[] array2 = new double[rowCount];
			if (flag)
			{
				matrix.CopyTo(matrix2);
				array = matrix2.Row(rowCount - 1).ToArray();
				SymmetricTridiagonalize(matrix2, array, array2, rowCount);
				SymmetricDiagonalize(matrix2, array, array2, rowCount);
			}
			else
			{
				double[,] matrixH = matrix.ToArray();
				NonsymmetricReduceToHessenberg(matrix2, matrixH, rowCount);
				NonsymmetricReduceHessenberToRealSchur(matrix2, matrixH, array, array2, rowCount);
			}
			for (int i = 0; i < rowCount; i++)
			{
				matrix3.At(i, i, array[i]);
				if (array2[i] > 0.0)
				{
					matrix3.At(i, i + 1, array2[i]);
				}
				else if (array2[i] < 0.0)
				{
					matrix3.At(i, i - 1, array2[i]);
				}
			}
			for (int j = 0; j < rowCount; j++)
			{
				denseVector[j] = new System.Numerics.Complex(array[j], array2[j]);
			}
			return new UserEvd(matrix2, denseVector, matrix3, flag);
		}

		private UserEvd(Matrix<double> eigenVectors, Vector<System.Numerics.Complex> eigenValues, Matrix<double> blockDiagonal, bool isSymmetric)
			: base(eigenVectors, eigenValues, blockDiagonal, isSymmetric)
		{
		}

		private static void SymmetricTridiagonalize(Matrix<double> eigenVectors, double[] d, double[] e, int order)
		{
			for (int num = order - 1; num > 0; num--)
			{
				double num2 = 0.0;
				double num3 = 0.0;
				for (int i = 0; i < num; i++)
				{
					num2 += Math.Abs(d[i]);
				}
				if (num2 == 0.0)
				{
					e[num] = d[num - 1];
					for (int j = 0; j < num; j++)
					{
						d[j] = eigenVectors.At(num - 1, j);
						eigenVectors.At(num, j, 0.0);
						eigenVectors.At(j, num, 0.0);
					}
				}
				else
				{
					for (int k = 0; k < num; k++)
					{
						d[k] /= num2;
						num3 += d[k] * d[k];
					}
					double num4 = d[num - 1];
					double num5 = Math.Sqrt(num3);
					if (num4 > 0.0)
					{
						num5 = 0.0 - num5;
					}
					e[num] = num2 * num5;
					num3 -= num4 * num5;
					d[num - 1] = num4 - num5;
					for (int l = 0; l < num; l++)
					{
						e[l] = 0.0;
					}
					for (int m = 0; m < num; m++)
					{
						num4 = d[m];
						eigenVectors.At(m, num, num4);
						num5 = e[m] + eigenVectors.At(m, m) * num4;
						for (int n = m + 1; n <= num - 1; n++)
						{
							num5 += eigenVectors.At(n, m) * d[n];
							e[n] += eigenVectors.At(n, m) * num4;
						}
						e[m] = num5;
					}
					num4 = 0.0;
					for (int num6 = 0; num6 < num; num6++)
					{
						e[num6] /= num3;
						num4 += e[num6] * d[num6];
					}
					double num7 = num4 / (num3 + num3);
					for (int num8 = 0; num8 < num; num8++)
					{
						e[num8] -= num7 * d[num8];
					}
					for (int num9 = 0; num9 < num; num9++)
					{
						num4 = d[num9];
						num5 = e[num9];
						for (int num10 = num9; num10 <= num - 1; num10++)
						{
							eigenVectors.At(num10, num9, eigenVectors.At(num10, num9) - num4 * e[num10] - num5 * d[num10]);
						}
						d[num9] = eigenVectors.At(num - 1, num9);
						eigenVectors.At(num, num9, 0.0);
					}
				}
				d[num] = num3;
			}
			for (int num11 = 0; num11 < order - 1; num11++)
			{
				eigenVectors.At(order - 1, num11, eigenVectors.At(num11, num11));
				eigenVectors.At(num11, num11, 1.0);
				double num12 = d[num11 + 1];
				if (num12 != 0.0)
				{
					for (int num13 = 0; num13 <= num11; num13++)
					{
						d[num13] = eigenVectors.At(num13, num11 + 1) / num12;
					}
					for (int num14 = 0; num14 <= num11; num14++)
					{
						double num15 = 0.0;
						for (int num16 = 0; num16 <= num11; num16++)
						{
							num15 += eigenVectors.At(num16, num11 + 1) * eigenVectors.At(num16, num14);
						}
						for (int num17 = 0; num17 <= num11; num17++)
						{
							eigenVectors.At(num17, num14, eigenVectors.At(num17, num14) - num15 * d[num17]);
						}
					}
				}
				for (int num18 = 0; num18 <= num11; num18++)
				{
					eigenVectors.At(num18, num11 + 1, 0.0);
				}
			}
			for (int num19 = 0; num19 < order; num19++)
			{
				d[num19] = eigenVectors.At(order - 1, num19);
				eigenVectors.At(order - 1, num19, 0.0);
			}
			eigenVectors.At(order - 1, order - 1, 1.0);
			e[0] = 0.0;
		}

		private static void SymmetricDiagonalize(Matrix<double> eigenVectors, double[] d, double[] e, int order)
		{
			for (int i = 1; i < order; i++)
			{
				e[i - 1] = e[i];
			}
			e[order - 1] = 0.0;
			double num = 0.0;
			double num2 = 0.0;
			double doublePrecision = Precision.DoublePrecision;
			for (int j = 0; j < order; j++)
			{
				num2 = Math.Max(num2, Math.Abs(d[j]) + Math.Abs(e[j]));
				int k;
				for (k = j; k < order && !(Math.Abs(e[k]) <= doublePrecision * num2); k++)
				{
				}
				if (k > j)
				{
					int num3 = 0;
					do
					{
						num3++;
						double num4 = d[j];
						double num5 = (d[j + 1] - num4) / (2.0 * e[j]);
						double num6 = SpecialFunctions.Hypotenuse(num5, 1.0);
						if (num5 < 0.0)
						{
							num6 = 0.0 - num6;
						}
						d[j] = e[j] / (num5 + num6);
						d[j + 1] = e[j] * (num5 + num6);
						double num7 = d[j + 1];
						double num8 = num4 - d[j];
						for (int l = j + 2; l < order; l++)
						{
							d[l] -= num8;
						}
						num += num8;
						num5 = d[k];
						double num9 = 1.0;
						double num10 = num9;
						double num11 = num9;
						double num12 = e[j + 1];
						double num13 = 0.0;
						double num14 = 0.0;
						for (int num15 = k - 1; num15 >= j; num15--)
						{
							num11 = num10;
							num10 = num9;
							num14 = num13;
							num4 = num9 * e[num15];
							num8 = num9 * num5;
							num6 = SpecialFunctions.Hypotenuse(num5, e[num15]);
							e[num15 + 1] = num13 * num6;
							num13 = e[num15] / num6;
							num9 = num5 / num6;
							num5 = num9 * d[num15] - num13 * num4;
							d[num15 + 1] = num8 + num13 * (num9 * num4 + num13 * d[num15]);
							for (int m = 0; m < order; m++)
							{
								num8 = eigenVectors.At(m, num15 + 1);
								eigenVectors.At(m, num15 + 1, num13 * eigenVectors.At(m, num15) + num9 * num8);
								eigenVectors.At(m, num15, num9 * eigenVectors.At(m, num15) - num13 * num8);
							}
						}
						num5 = (0.0 - num13) * num14 * num11 * num12 * e[j] / num7;
						e[j] = num13 * num5;
						d[j] = num9 * num5;
						if (num3 >= 1000)
						{
							throw new NonConvergenceException();
						}
					}
					while (Math.Abs(e[j]) > doublePrecision * num2);
				}
				d[j] += num;
				e[j] = 0.0;
			}
			for (int n = 0; n < order - 1; n++)
			{
				int num16 = n;
				double num17 = d[n];
				for (int num18 = n + 1; num18 < order; num18++)
				{
					if (d[num18] < num17)
					{
						num16 = num18;
						num17 = d[num18];
					}
				}
				if (num16 != n)
				{
					d[num16] = d[n];
					d[n] = num17;
					for (int num19 = 0; num19 < order; num19++)
					{
						num17 = eigenVectors.At(num19, n);
						eigenVectors.At(num19, n, eigenVectors.At(num19, num16));
						eigenVectors.At(num19, num16, num17);
					}
				}
			}
		}

		private static void NonsymmetricReduceToHessenberg(Matrix<double> eigenVectors, double[,] matrixH, int order)
		{
			double[] array = new double[order];
			for (int i = 1; i < order - 1; i++)
			{
				double num = 0.0;
				for (int j = i; j < order; j++)
				{
					num += Math.Abs(matrixH[j, i - 1]);
				}
				if (num == 0.0)
				{
					continue;
				}
				double num2 = 0.0;
				for (int num3 = order - 1; num3 >= i; num3--)
				{
					array[num3] = matrixH[num3, i - 1] / num;
					num2 += array[num3] * array[num3];
				}
				double num4 = Math.Sqrt(num2);
				if (array[i] > 0.0)
				{
					num4 = 0.0 - num4;
				}
				num2 -= array[i] * num4;
				array[i] -= num4;
				for (int k = i; k < order; k++)
				{
					double num5 = 0.0;
					for (int num6 = order - 1; num6 >= i; num6--)
					{
						num5 += array[num6] * matrixH[num6, k];
					}
					num5 /= num2;
					for (int l = i; l < order; l++)
					{
						matrixH[l, k] -= num5 * array[l];
					}
				}
				for (int m = 0; m < order; m++)
				{
					double num7 = 0.0;
					for (int num8 = order - 1; num8 >= i; num8--)
					{
						num7 += array[num8] * matrixH[m, num8];
					}
					num7 /= num2;
					for (int n = i; n < order; n++)
					{
						matrixH[m, n] -= num7 * array[n];
					}
				}
				array[i] = num * array[i];
				matrixH[i, i - 1] = num * num4;
			}
			for (int num9 = 0; num9 < order; num9++)
			{
				for (int num10 = 0; num10 < order; num10++)
				{
					eigenVectors.At(num9, num10, (num9 == num10) ? 1.0 : 0.0);
				}
			}
			for (int num11 = order - 2; num11 >= 1; num11--)
			{
				if (matrixH[num11, num11 - 1] != 0.0)
				{
					for (int num12 = num11 + 1; num12 < order; num12++)
					{
						array[num12] = matrixH[num12, num11 - 1];
					}
					for (int num13 = num11; num13 < order; num13++)
					{
						double num14 = 0.0;
						for (int num15 = num11; num15 < order; num15++)
						{
							num14 += array[num15] * eigenVectors.At(num15, num13);
						}
						num14 = num14 / array[num11] / matrixH[num11, num11 - 1];
						for (int num16 = num11; num16 < order; num16++)
						{
							eigenVectors.At(num16, num13, eigenVectors.At(num16, num13) + num14 * array[num16]);
						}
					}
				}
			}
		}

		private static void NonsymmetricReduceHessenberToRealSchur(Matrix<double> eigenVectors, double[,] matrixH, double[] d, double[] e, int order)
		{
			int num = order - 1;
			double doublePrecision = Precision.DoublePrecision;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			double num8 = 0.0;
			for (int i = 0; i < order; i++)
			{
				for (int j = Math.Max(i - 1, 0); j < order; j++)
				{
					num8 += Math.Abs(matrixH[i, j]);
				}
			}
			int num9 = 0;
			while (num >= 0)
			{
				int num10;
				for (num10 = num; num10 > 0; num10--)
				{
					num6 = Math.Abs(matrixH[num10 - 1, num10 - 1]) + Math.Abs(matrixH[num10, num10]);
					if (num6 == 0.0)
					{
						num6 = num8;
					}
					if (Math.Abs(matrixH[num10, num10 - 1]) < doublePrecision * num6)
					{
						break;
					}
				}
				if (num10 == num)
				{
					matrixH[num, num] += num2;
					d[num] = matrixH[num, num];
					e[num] = 0.0;
					num--;
					num9 = 0;
					continue;
				}
				double num12;
				double num11;
				if (num10 == num - 1)
				{
					num11 = matrixH[num, num - 1] * matrixH[num - 1, num];
					num3 = (matrixH[num - 1, num - 1] - matrixH[num, num]) / 2.0;
					num4 = num3 * num3 + num11;
					num7 = Math.Sqrt(Math.Abs(num4));
					matrixH[num, num] += num2;
					matrixH[num - 1, num - 1] += num2;
					num12 = matrixH[num, num];
					if (num4 >= 0.0)
					{
						num7 = ((!(num3 >= 0.0)) ? (num3 - num7) : (num3 + num7));
						d[num - 1] = num12 + num7;
						d[num] = d[num - 1];
						if (num7 != 0.0)
						{
							d[num] = num12 - num11 / num7;
						}
						e[num - 1] = 0.0;
						e[num] = 0.0;
						num12 = matrixH[num, num - 1];
						num6 = Math.Abs(num12) + Math.Abs(num7);
						num3 = num12 / num6;
						num4 = num7 / num6;
						num5 = Math.Sqrt(num3 * num3 + num4 * num4);
						num3 /= num5;
						num4 /= num5;
						for (int k = num - 1; k < order; k++)
						{
							num7 = matrixH[num - 1, k];
							matrixH[num - 1, k] = num4 * num7 + num3 * matrixH[num, k];
							matrixH[num, k] = num4 * matrixH[num, k] - num3 * num7;
						}
						for (int l = 0; l <= num; l++)
						{
							num7 = matrixH[l, num - 1];
							matrixH[l, num - 1] = num4 * num7 + num3 * matrixH[l, num];
							matrixH[l, num] = num4 * matrixH[l, num] - num3 * num7;
						}
						for (int m = 0; m < order; m++)
						{
							num7 = eigenVectors.At(m, num - 1);
							eigenVectors.At(m, num - 1, num4 * num7 + num3 * eigenVectors.At(m, num));
							eigenVectors.At(m, num, num4 * eigenVectors.At(m, num) - num3 * num7);
						}
					}
					else
					{
						d[num - 1] = num12 + num3;
						d[num] = num12 + num3;
						e[num - 1] = num7;
						e[num] = 0.0 - num7;
					}
					num -= 2;
					num9 = 0;
					continue;
				}
				num12 = matrixH[num, num];
				double num13 = 0.0;
				num11 = 0.0;
				if (num10 < num)
				{
					num13 = matrixH[num - 1, num - 1];
					num11 = matrixH[num, num - 1] * matrixH[num - 1, num];
				}
				if (num9 == 10)
				{
					num2 += num12;
					for (int n = 0; n <= num; n++)
					{
						matrixH[n, n] -= num12;
					}
					num6 = Math.Abs(matrixH[num, num - 1]) + Math.Abs(matrixH[num - 1, num - 2]);
					num12 = (num13 = 0.75 * num6);
					num11 = -0.4375 * num6 * num6;
				}
				if (num9 == 30)
				{
					num6 = (num13 - num12) / 2.0;
					num6 = num6 * num6 + num11;
					if (num6 > 0.0)
					{
						num6 = Math.Sqrt(num6);
						if (num13 < num12)
						{
							num6 = 0.0 - num6;
						}
						num6 = num12 - num11 / ((num13 - num12) / 2.0 + num6);
						for (int num14 = 0; num14 <= num; num14++)
						{
							matrixH[num14, num14] -= num6;
						}
						num2 += num6;
						num12 = (num13 = (num11 = 0.964));
					}
				}
				num9++;
				int num15;
				for (num15 = num - 2; num15 >= num10; num15--)
				{
					num7 = matrixH[num15, num15];
					num5 = num12 - num7;
					num6 = num13 - num7;
					num3 = (num5 * num6 - num11) / matrixH[num15 + 1, num15] + matrixH[num15, num15 + 1];
					num4 = matrixH[num15 + 1, num15 + 1] - num7 - num5 - num6;
					num5 = matrixH[num15 + 2, num15 + 1];
					num6 = Math.Abs(num3) + Math.Abs(num4) + Math.Abs(num5);
					num3 /= num6;
					num4 /= num6;
					num5 /= num6;
					if (num15 == num10 || Math.Abs(matrixH[num15, num15 - 1]) * (Math.Abs(num4) + Math.Abs(num5)) < doublePrecision * (Math.Abs(num3) * (Math.Abs(matrixH[num15 - 1, num15 - 1]) + Math.Abs(num7) + Math.Abs(matrixH[num15 + 1, num15 + 1]))))
					{
						break;
					}
				}
				for (int num16 = num15 + 2; num16 <= num; num16++)
				{
					matrixH[num16, num16 - 2] = 0.0;
					if (num16 > num15 + 2)
					{
						matrixH[num16, num16 - 3] = 0.0;
					}
				}
				for (int num17 = num15; num17 <= num - 1; num17++)
				{
					bool flag = num17 != num - 1;
					if (num17 != num15)
					{
						num3 = matrixH[num17, num17 - 1];
						num4 = matrixH[num17 + 1, num17 - 1];
						num5 = (flag ? matrixH[num17 + 2, num17 - 1] : 0.0);
						num12 = Math.Abs(num3) + Math.Abs(num4) + Math.Abs(num5);
						if (num12 != 0.0)
						{
							num3 /= num12;
							num4 /= num12;
							num5 /= num12;
						}
					}
					if (num12 == 0.0)
					{
						break;
					}
					num6 = Math.Sqrt(num3 * num3 + num4 * num4 + num5 * num5);
					if (num3 < 0.0)
					{
						num6 = 0.0 - num6;
					}
					if (num6 == 0.0)
					{
						continue;
					}
					if (num17 != num15)
					{
						matrixH[num17, num17 - 1] = (0.0 - num6) * num12;
					}
					else if (num10 != num15)
					{
						matrixH[num17, num17 - 1] = 0.0 - matrixH[num17, num17 - 1];
					}
					num3 += num6;
					num12 = num3 / num6;
					num13 = num4 / num6;
					num7 = num5 / num6;
					num4 /= num3;
					num5 /= num3;
					for (int num18 = num17; num18 < order; num18++)
					{
						num3 = matrixH[num17, num18] + num4 * matrixH[num17 + 1, num18];
						if (flag)
						{
							num3 += num5 * matrixH[num17 + 2, num18];
							matrixH[num17 + 2, num18] -= num3 * num7;
						}
						matrixH[num17, num18] -= num3 * num12;
						matrixH[num17 + 1, num18] -= num3 * num13;
					}
					for (int num19 = 0; num19 <= Math.Min(num, num17 + 3); num19++)
					{
						num3 = num12 * matrixH[num19, num17] + num13 * matrixH[num19, num17 + 1];
						if (flag)
						{
							num3 += num7 * matrixH[num19, num17 + 2];
							matrixH[num19, num17 + 2] -= num3 * num5;
						}
						matrixH[num19, num17] -= num3;
						matrixH[num19, num17 + 1] -= num3 * num4;
					}
					for (int num20 = 0; num20 < order; num20++)
					{
						num3 = num12 * eigenVectors.At(num20, num17) + num13 * eigenVectors.At(num20, num17 + 1);
						if (flag)
						{
							num3 += num7 * eigenVectors.At(num20, num17 + 2);
							eigenVectors.At(num20, num17 + 2, eigenVectors.At(num20, num17 + 2) - num3 * num5);
						}
						eigenVectors.At(num20, num17, eigenVectors.At(num20, num17) - num3);
						eigenVectors.At(num20, num17 + 1, eigenVectors.At(num20, num17 + 1) - num3 * num4);
					}
				}
			}
			if (num8 == 0.0)
			{
				return;
			}
			for (num = order - 1; num >= 0; num--)
			{
				num3 = d[num];
				num4 = e[num];
				if (num4 == 0.0)
				{
					int num21 = num;
					matrixH[num, num] = 1.0;
					for (int num22 = num - 1; num22 >= 0; num22--)
					{
						double num11 = matrixH[num22, num22] - num3;
						num5 = 0.0;
						for (int num23 = num21; num23 <= num; num23++)
						{
							num5 += matrixH[num22, num23] * matrixH[num23, num];
						}
						if (e[num22] < 0.0)
						{
							num7 = num11;
							num6 = num5;
						}
						else
						{
							num21 = num22;
							double num24;
							if (e[num22] == 0.0)
							{
								if (num11 != 0.0)
								{
									matrixH[num22, num] = (0.0 - num5) / num11;
								}
								else
								{
									matrixH[num22, num] = (0.0 - num5) / (doublePrecision * num8);
								}
							}
							else
							{
								double num12 = matrixH[num22, num22 + 1];
								double num13 = matrixH[num22 + 1, num22];
								num4 = (d[num22] - num3) * (d[num22] - num3) + e[num22] * e[num22];
								num24 = (matrixH[num22, num] = (num12 * num6 - num7 * num5) / num4);
								if (Math.Abs(num12) > Math.Abs(num7))
								{
									matrixH[num22 + 1, num] = (0.0 - num5 - num11 * num24) / num12;
								}
								else
								{
									matrixH[num22 + 1, num] = (0.0 - num6 - num13 * num24) / num7;
								}
							}
							num24 = Math.Abs(matrixH[num22, num]);
							if (doublePrecision * num24 * num24 > 1.0)
							{
								for (int num25 = num22; num25 <= num; num25++)
								{
									matrixH[num25, num] /= num24;
								}
							}
						}
					}
				}
				else if (num4 < 0.0)
				{
					int num26 = num - 1;
					if (Math.Abs(matrixH[num, num - 1]) > Math.Abs(matrixH[num - 1, num]))
					{
						matrixH[num - 1, num - 1] = num4 / matrixH[num, num - 1];
						matrixH[num - 1, num] = (0.0 - (matrixH[num, num] - num3)) / matrixH[num, num - 1];
					}
					else
					{
						System.Numerics.Complex complex = Cdiv(0.0, 0.0 - matrixH[num - 1, num], matrixH[num - 1, num - 1] - num3, num4);
						matrixH[num - 1, num - 1] = complex.Real;
						matrixH[num - 1, num] = complex.Imaginary;
					}
					matrixH[num, num - 1] = 0.0;
					matrixH[num, num] = 1.0;
					for (int num27 = num - 2; num27 >= 0; num27--)
					{
						double num28 = 0.0;
						double num29 = 0.0;
						for (int num30 = num26; num30 <= num; num30++)
						{
							num28 += matrixH[num27, num30] * matrixH[num30, num - 1];
							num29 += matrixH[num27, num30] * matrixH[num30, num];
						}
						double num11 = matrixH[num27, num27] - num3;
						if (e[num27] < 0.0)
						{
							num7 = num11;
							num5 = num28;
							num6 = num29;
						}
						else
						{
							num26 = num27;
							if (e[num27] == 0.0)
							{
								System.Numerics.Complex complex2 = Cdiv(0.0 - num28, 0.0 - num29, num11, num4);
								matrixH[num27, num - 1] = complex2.Real;
								matrixH[num27, num] = complex2.Imaginary;
							}
							else
							{
								double num12 = matrixH[num27, num27 + 1];
								double num13 = matrixH[num27 + 1, num27];
								double num31 = (d[num27] - num3) * (d[num27] - num3) + e[num27] * e[num27] - num4 * num4;
								double num32 = (d[num27] - num3) * 2.0 * num4;
								if (num31 == 0.0 && num32 == 0.0)
								{
									num31 = doublePrecision * num8 * (Math.Abs(num11) + Math.Abs(num4) + Math.Abs(num12) + Math.Abs(num13) + Math.Abs(num7));
								}
								System.Numerics.Complex complex3 = Cdiv(num12 * num5 - num7 * num28 + num4 * num29, num12 * num6 - num7 * num29 - num4 * num28, num31, num32);
								matrixH[num27, num - 1] = complex3.Real;
								matrixH[num27, num] = complex3.Imaginary;
								if (Math.Abs(num12) > Math.Abs(num7) + Math.Abs(num4))
								{
									matrixH[num27 + 1, num - 1] = (0.0 - num28 - num11 * matrixH[num27, num - 1] + num4 * matrixH[num27, num]) / num12;
									matrixH[num27 + 1, num] = (0.0 - num29 - num11 * matrixH[num27, num] - num4 * matrixH[num27, num - 1]) / num12;
								}
								else
								{
									complex3 = Cdiv(0.0 - num5 - num13 * matrixH[num27, num - 1], 0.0 - num6 - num13 * matrixH[num27, num], num7, num4);
									matrixH[num27 + 1, num - 1] = complex3.Real;
									matrixH[num27 + 1, num] = complex3.Imaginary;
								}
							}
							double num24 = Math.Max(Math.Abs(matrixH[num27, num - 1]), Math.Abs(matrixH[num27, num]));
							if (doublePrecision * num24 * num24 > 1.0)
							{
								for (int num33 = num27; num33 <= num; num33++)
								{
									matrixH[num33, num - 1] /= num24;
									matrixH[num33, num] /= num24;
								}
							}
						}
					}
				}
			}
			for (int num34 = order - 1; num34 >= 0; num34--)
			{
				for (int num35 = 0; num35 < order; num35++)
				{
					num7 = 0.0;
					for (int num36 = 0; num36 <= num34; num36++)
					{
						num7 += eigenVectors.At(num35, num36) * matrixH[num36, num34];
					}
					eigenVectors.At(num35, num34, num7);
				}
			}
		}

		private static System.Numerics.Complex Cdiv(double xreal, double ximag, double yreal, double yimag)
		{
			if (Math.Abs(yimag) < Math.Abs(yreal))
			{
				return new System.Numerics.Complex((xreal + ximag * (yimag / yreal)) / (yreal + yimag * (yimag / yreal)), (ximag - xreal * (yimag / yreal)) / (yreal + yimag * (yimag / yreal)));
			}
			return new System.Numerics.Complex((ximag + xreal * (yreal / yimag)) / (yimag + yreal * (yreal / yimag)), (0.0 - xreal + ximag * (yreal / yimag)) / (yimag + yreal * (yreal / yimag)));
		}

		public override void Solve(Matrix<double> input, Matrix<double> result)
		{
			if (input.ColumnCount != result.ColumnCount)
			{
				throw new ArgumentException("Matrix column dimensions must agree.");
			}
			if (base.EigenValues.Count != input.RowCount)
			{
				throw new ArgumentException("Matrix row dimensions must agree.");
			}
			if (base.EigenValues.Count != result.RowCount)
			{
				throw new ArgumentException("Matrix column dimensions must agree.");
			}
			if (base.IsSymmetric)
			{
				int count = base.EigenValues.Count;
				double[] array = new double[count];
				for (int i = 0; i < count; i++)
				{
					for (int j = 0; j < count; j++)
					{
						double num = 0.0;
						if (j < count)
						{
							for (int k = 0; k < count; k++)
							{
								num += base.EigenVectors.At(k, j) * input.At(k, i);
							}
							num /= base.EigenValues[j].Real;
						}
						array[j] = num;
					}
					for (int l = 0; l < count; l++)
					{
						double num2 = 0.0;
						for (int m = 0; m < count; m++)
						{
							num2 += base.EigenVectors.At(l, m) * array[m];
						}
						result.At(l, i, num2);
					}
				}
				return;
			}
			throw new ArgumentException("Matrix must be symmetric.");
		}

		public override void Solve(Vector<double> input, Vector<double> result)
		{
			if (base.EigenValues.Count != input.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (base.EigenValues.Count != result.Count)
			{
				throw new ArgumentException("Matrix dimensions must agree.");
			}
			if (base.IsSymmetric)
			{
				int count = base.EigenValues.Count;
				double[] array = new double[count];
				for (int i = 0; i < count; i++)
				{
					double num = 0.0;
					if (i < count)
					{
						for (int j = 0; j < count; j++)
						{
							num += base.EigenVectors.At(j, i) * input[j];
						}
						num /= base.EigenValues[i].Real;
					}
					array[i] = num;
				}
				for (int k = 0; k < count; k++)
				{
					double num = 0.0;
					for (int l = 0; l < count; l++)
					{
						num += base.EigenVectors.At(k, l) * array[l];
					}
					result[k] = num;
				}
				return;
			}
			throw new ArgumentException("Matrix must be symmetric.");
		}
	}
}
