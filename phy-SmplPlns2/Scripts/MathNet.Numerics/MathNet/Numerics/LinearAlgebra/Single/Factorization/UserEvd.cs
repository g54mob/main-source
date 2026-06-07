using System;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra.Complex;

namespace MathNet.Numerics.LinearAlgebra.Single.Factorization
{
	internal sealed class UserEvd : Evd
	{
		public static UserEvd Create(Matrix<float> matrix, Symmetricity symmetricity)
		{
			if (matrix.RowCount != matrix.ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.");
			}
			int rowCount = matrix.RowCount;
			Matrix<float> matrix2 = Matrix<float>.Build.SameAs(matrix, rowCount, rowCount, fullyMutable: true);
			Matrix<float> matrix3 = Matrix<float>.Build.SameAs(matrix, rowCount, rowCount);
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
			float[] array = new float[rowCount];
			float[] array2 = new float[rowCount];
			if (flag)
			{
				matrix.CopyTo(matrix2);
				array = matrix2.Row(rowCount - 1).ToArray();
				SymmetricTridiagonalize(matrix2, array, array2, rowCount);
				SymmetricDiagonalize(matrix2, array, array2, rowCount);
			}
			else
			{
				float[,] matrixH = matrix.ToArray();
				NonsymmetricReduceToHessenberg(matrix2, matrixH, rowCount);
				NonsymmetricReduceHessenberToRealSchur(matrix2, matrixH, array, array2, rowCount);
			}
			for (int i = 0; i < rowCount; i++)
			{
				matrix3.At(i, i, array[i]);
				if (array2[i] > 0f)
				{
					matrix3.At(i, i + 1, array2[i]);
				}
				else if (array2[i] < 0f)
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

		private UserEvd(Matrix<float> eigenVectors, Vector<System.Numerics.Complex> eigenValues, Matrix<float> blockDiagonal, bool isSymmetric)
			: base(eigenVectors, eigenValues, blockDiagonal, isSymmetric)
		{
		}

		private static void SymmetricTridiagonalize(Matrix<float> eigenVectors, float[] d, float[] e, int order)
		{
			for (int num = order - 1; num > 0; num--)
			{
				float num2 = 0f;
				float num3 = 0f;
				for (int i = 0; i < num; i++)
				{
					num2 += Math.Abs(d[i]);
				}
				if (num2 == 0f)
				{
					e[num] = d[num - 1];
					for (int j = 0; j < num; j++)
					{
						d[j] = eigenVectors.At(num - 1, j);
						eigenVectors.At(num, j, 0f);
						eigenVectors.At(j, num, 0f);
					}
				}
				else
				{
					for (int k = 0; k < num; k++)
					{
						d[k] /= num2;
						num3 += d[k] * d[k];
					}
					float num4 = d[num - 1];
					float num5 = (float)Math.Sqrt(num3);
					if (num4 > 0f)
					{
						num5 = 0f - num5;
					}
					e[num] = num2 * num5;
					num3 -= num4 * num5;
					d[num - 1] = num4 - num5;
					for (int l = 0; l < num; l++)
					{
						e[l] = 0f;
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
					num4 = 0f;
					for (int num6 = 0; num6 < num; num6++)
					{
						e[num6] /= num3;
						num4 += e[num6] * d[num6];
					}
					float num7 = num4 / (num3 + num3);
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
						eigenVectors.At(num, num9, 0f);
					}
				}
				d[num] = num3;
			}
			for (int num11 = 0; num11 < order - 1; num11++)
			{
				eigenVectors.At(order - 1, num11, eigenVectors.At(num11, num11));
				eigenVectors.At(num11, num11, 1f);
				float num12 = d[num11 + 1];
				if (num12 != 0f)
				{
					for (int num13 = 0; num13 <= num11; num13++)
					{
						d[num13] = eigenVectors.At(num13, num11 + 1) / num12;
					}
					for (int num14 = 0; num14 <= num11; num14++)
					{
						float num15 = 0f;
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
					eigenVectors.At(num18, num11 + 1, 0f);
				}
			}
			for (int num19 = 0; num19 < order; num19++)
			{
				d[num19] = eigenVectors.At(order - 1, num19);
				eigenVectors.At(order - 1, num19, 0f);
			}
			eigenVectors.At(order - 1, order - 1, 1f);
			e[0] = 0f;
		}

		private static void SymmetricDiagonalize(Matrix<float> eigenVectors, float[] d, float[] e, int order)
		{
			for (int i = 1; i < order; i++)
			{
				e[i - 1] = e[i];
			}
			e[order - 1] = 0f;
			float num = 0f;
			float num2 = 0f;
			double doublePrecision = Precision.DoublePrecision;
			for (int j = 0; j < order; j++)
			{
				num2 = Math.Max(num2, Math.Abs(d[j]) + Math.Abs(e[j]));
				int k;
				for (k = j; k < order && !((double)Math.Abs(e[k]) <= doublePrecision * (double)num2); k++)
				{
				}
				if (k > j)
				{
					int num3 = 0;
					do
					{
						num3++;
						float num4 = d[j];
						float num5 = (d[j + 1] - num4) / (2f * e[j]);
						float num6 = SpecialFunctions.Hypotenuse(num5, 1f);
						if (num5 < 0f)
						{
							num6 = 0f - num6;
						}
						d[j] = e[j] / (num5 + num6);
						d[j + 1] = e[j] * (num5 + num6);
						float num7 = d[j + 1];
						float num8 = num4 - d[j];
						for (int l = j + 2; l < order; l++)
						{
							d[l] -= num8;
						}
						num += num8;
						num5 = d[k];
						float num9 = 1f;
						float num10 = num9;
						float num11 = num9;
						float num12 = e[j + 1];
						float num13 = 0f;
						float num14 = 0f;
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
						num5 = (0f - num13) * num14 * num11 * num12 * e[j] / num7;
						e[j] = num13 * num5;
						d[j] = num9 * num5;
						if (num3 >= 1000)
						{
							throw new NonConvergenceException();
						}
					}
					while ((double)Math.Abs(e[j]) > doublePrecision * (double)num2);
				}
				d[j] += num;
				e[j] = 0f;
			}
			for (int n = 0; n < order - 1; n++)
			{
				int num16 = n;
				float num17 = d[n];
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

		private static void NonsymmetricReduceToHessenberg(Matrix<float> eigenVectors, float[,] matrixH, int order)
		{
			float[] array = new float[order];
			for (int i = 1; i < order - 1; i++)
			{
				float num = 0f;
				for (int j = i; j < order; j++)
				{
					num += Math.Abs(matrixH[j, i - 1]);
				}
				if (num == 0f)
				{
					continue;
				}
				float num2 = 0f;
				for (int num3 = order - 1; num3 >= i; num3--)
				{
					array[num3] = matrixH[num3, i - 1] / num;
					num2 += array[num3] * array[num3];
				}
				float num4 = (float)Math.Sqrt(num2);
				if (array[i] > 0f)
				{
					num4 = 0f - num4;
				}
				num2 -= array[i] * num4;
				array[i] -= num4;
				for (int k = i; k < order; k++)
				{
					float num5 = 0f;
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
					float num7 = 0f;
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
					eigenVectors.At(num9, num10, (num9 == num10) ? 1f : 0f);
				}
			}
			for (int num11 = order - 2; num11 >= 1; num11--)
			{
				if (matrixH[num11, num11 - 1] != 0f)
				{
					for (int num12 = num11 + 1; num12 < order; num12++)
					{
						array[num12] = matrixH[num12, num11 - 1];
					}
					for (int num13 = num11; num13 < order; num13++)
					{
						float num14 = 0f;
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

		private static void NonsymmetricReduceHessenberToRealSchur(Matrix<float> eigenVectors, float[,] matrixH, float[] d, float[] e, int order)
		{
			int num = order - 1;
			float num2 = (float)Precision.SinglePrecision;
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 0f;
			float num6 = 0f;
			float num7 = 0f;
			float num8 = 0f;
			float num9 = 0f;
			for (int i = 0; i < order; i++)
			{
				for (int j = Math.Max(i - 1, 0); j < order; j++)
				{
					num9 += Math.Abs(matrixH[i, j]);
				}
			}
			int num10 = 0;
			while (num >= 0)
			{
				int num11;
				for (num11 = num; num11 > 0; num11--)
				{
					num7 = Math.Abs(matrixH[num11 - 1, num11 - 1]) + Math.Abs(matrixH[num11, num11]);
					if (num7 == 0f)
					{
						num7 = num9;
					}
					if (Math.Abs(matrixH[num11, num11 - 1]) < num2 * num7)
					{
						break;
					}
				}
				if (num11 == num)
				{
					matrixH[num, num] += num3;
					d[num] = matrixH[num, num];
					e[num] = 0f;
					num--;
					num10 = 0;
					continue;
				}
				float num13;
				float num12;
				if (num11 == num - 1)
				{
					num12 = matrixH[num, num - 1] * matrixH[num - 1, num];
					num4 = (matrixH[num - 1, num - 1] - matrixH[num, num]) / 2f;
					num5 = num4 * num4 + num12;
					num8 = (float)Math.Sqrt(Math.Abs(num5));
					matrixH[num, num] += num3;
					matrixH[num - 1, num - 1] += num3;
					num13 = matrixH[num, num];
					if (num5 >= 0f)
					{
						num8 = ((!(num4 >= 0f)) ? (num4 - num8) : (num4 + num8));
						d[num - 1] = num13 + num8;
						d[num] = d[num - 1];
						if (num8 != 0f)
						{
							d[num] = num13 - num12 / num8;
						}
						e[num - 1] = 0f;
						e[num] = 0f;
						num13 = matrixH[num, num - 1];
						num7 = Math.Abs(num13) + Math.Abs(num8);
						num4 = num13 / num7;
						num5 = num8 / num7;
						num6 = (float)Math.Sqrt(num4 * num4 + num5 * num5);
						num4 /= num6;
						num5 /= num6;
						for (int k = num - 1; k < order; k++)
						{
							num8 = matrixH[num - 1, k];
							matrixH[num - 1, k] = num5 * num8 + num4 * matrixH[num, k];
							matrixH[num, k] = num5 * matrixH[num, k] - num4 * num8;
						}
						for (int l = 0; l <= num; l++)
						{
							num8 = matrixH[l, num - 1];
							matrixH[l, num - 1] = num5 * num8 + num4 * matrixH[l, num];
							matrixH[l, num] = num5 * matrixH[l, num] - num4 * num8;
						}
						for (int m = 0; m < order; m++)
						{
							num8 = eigenVectors.At(m, num - 1);
							eigenVectors.At(m, num - 1, num5 * num8 + num4 * eigenVectors.At(m, num));
							eigenVectors.At(m, num, num5 * eigenVectors.At(m, num) - num4 * num8);
						}
					}
					else
					{
						d[num - 1] = num13 + num4;
						d[num] = num13 + num4;
						e[num - 1] = num8;
						e[num] = 0f - num8;
					}
					num -= 2;
					num10 = 0;
					continue;
				}
				num13 = matrixH[num, num];
				float num14 = 0f;
				num12 = 0f;
				if (num11 < num)
				{
					num14 = matrixH[num - 1, num - 1];
					num12 = matrixH[num, num - 1] * matrixH[num - 1, num];
				}
				if (num10 == 10)
				{
					num3 += num13;
					for (int n = 0; n <= num; n++)
					{
						matrixH[n, n] -= num13;
					}
					num7 = Math.Abs(matrixH[num, num - 1]) + Math.Abs(matrixH[num - 1, num - 2]);
					num13 = (num14 = 0.75f * num7);
					num12 = -0.4375f * num7 * num7;
				}
				if (num10 == 30)
				{
					num7 = (num14 - num13) / 2f;
					num7 = num7 * num7 + num12;
					if (num7 > 0f)
					{
						num7 = (float)Math.Sqrt(num7);
						if (num14 < num13)
						{
							num7 = 0f - num7;
						}
						num7 = num13 - num12 / ((num14 - num13) / 2f + num7);
						for (int num15 = 0; num15 <= num; num15++)
						{
							matrixH[num15, num15] -= num7;
						}
						num3 += num7;
						num13 = (num14 = (num12 = 0.964f));
					}
				}
				num10++;
				int num16;
				for (num16 = num - 2; num16 >= num11; num16--)
				{
					num8 = matrixH[num16, num16];
					num6 = num13 - num8;
					num7 = num14 - num8;
					num4 = (num6 * num7 - num12) / matrixH[num16 + 1, num16] + matrixH[num16, num16 + 1];
					num5 = matrixH[num16 + 1, num16 + 1] - num8 - num6 - num7;
					num6 = matrixH[num16 + 2, num16 + 1];
					num7 = Math.Abs(num4) + Math.Abs(num5) + Math.Abs(num6);
					num4 /= num7;
					num5 /= num7;
					num6 /= num7;
					if (num16 == num11 || Math.Abs(matrixH[num16, num16 - 1]) * (Math.Abs(num5) + Math.Abs(num6)) < num2 * (Math.Abs(num4) * (Math.Abs(matrixH[num16 - 1, num16 - 1]) + Math.Abs(num8) + Math.Abs(matrixH[num16 + 1, num16 + 1]))))
					{
						break;
					}
				}
				for (int num17 = num16 + 2; num17 <= num; num17++)
				{
					matrixH[num17, num17 - 2] = 0f;
					if (num17 > num16 + 2)
					{
						matrixH[num17, num17 - 3] = 0f;
					}
				}
				for (int num18 = num16; num18 <= num - 1; num18++)
				{
					bool flag = num18 != num - 1;
					if (num18 != num16)
					{
						num4 = matrixH[num18, num18 - 1];
						num5 = matrixH[num18 + 1, num18 - 1];
						num6 = (flag ? matrixH[num18 + 2, num18 - 1] : 0f);
						num13 = Math.Abs(num4) + Math.Abs(num5) + Math.Abs(num6);
						if (num13 != 0f)
						{
							num4 /= num13;
							num5 /= num13;
							num6 /= num13;
						}
					}
					if (num13 == 0f)
					{
						break;
					}
					num7 = (float)Math.Sqrt(num4 * num4 + num5 * num5 + num6 * num6);
					if (num4 < 0f)
					{
						num7 = 0f - num7;
					}
					if (num7 == 0f)
					{
						continue;
					}
					if (num18 != num16)
					{
						matrixH[num18, num18 - 1] = (0f - num7) * num13;
					}
					else if (num11 != num16)
					{
						matrixH[num18, num18 - 1] = 0f - matrixH[num18, num18 - 1];
					}
					num4 += num7;
					num13 = num4 / num7;
					num14 = num5 / num7;
					num8 = num6 / num7;
					num5 /= num4;
					num6 /= num4;
					for (int num19 = num18; num19 < order; num19++)
					{
						num4 = matrixH[num18, num19] + num5 * matrixH[num18 + 1, num19];
						if (flag)
						{
							num4 += num6 * matrixH[num18 + 2, num19];
							matrixH[num18 + 2, num19] -= num4 * num8;
						}
						matrixH[num18, num19] -= num4 * num13;
						matrixH[num18 + 1, num19] -= num4 * num14;
					}
					for (int num20 = 0; num20 <= Math.Min(num, num18 + 3); num20++)
					{
						num4 = num13 * matrixH[num20, num18] + num14 * matrixH[num20, num18 + 1];
						if (flag)
						{
							num4 += num8 * matrixH[num20, num18 + 2];
							matrixH[num20, num18 + 2] -= num4 * num6;
						}
						matrixH[num20, num18] -= num4;
						matrixH[num20, num18 + 1] -= num4 * num5;
					}
					for (int num21 = 0; num21 < order; num21++)
					{
						num4 = num13 * eigenVectors.At(num21, num18) + num14 * eigenVectors.At(num21, num18 + 1);
						if (flag)
						{
							num4 += num8 * eigenVectors.At(num21, num18 + 2);
							eigenVectors.At(num21, num18 + 2, eigenVectors.At(num21, num18 + 2) - num4 * num6);
						}
						eigenVectors.At(num21, num18, eigenVectors.At(num21, num18) - num4);
						eigenVectors.At(num21, num18 + 1, eigenVectors.At(num21, num18 + 1) - num4 * num5);
					}
				}
			}
			if (num9 == 0f)
			{
				return;
			}
			for (num = order - 1; num >= 0; num--)
			{
				num4 = d[num];
				num5 = e[num];
				if (num5 == 0f)
				{
					int num22 = num;
					matrixH[num, num] = 1f;
					for (int num23 = num - 1; num23 >= 0; num23--)
					{
						float num12 = matrixH[num23, num23] - num4;
						num6 = 0f;
						for (int num24 = num22; num24 <= num; num24++)
						{
							num6 += matrixH[num23, num24] * matrixH[num24, num];
						}
						if (e[num23] < 0f)
						{
							num8 = num12;
							num7 = num6;
						}
						else
						{
							num22 = num23;
							float num25;
							if (e[num23] == 0f)
							{
								if (num12 != 0f)
								{
									matrixH[num23, num] = (0f - num6) / num12;
								}
								else
								{
									matrixH[num23, num] = (0f - num6) / (num2 * num9);
								}
							}
							else
							{
								float num13 = matrixH[num23, num23 + 1];
								float num14 = matrixH[num23 + 1, num23];
								num5 = (d[num23] - num4) * (d[num23] - num4) + e[num23] * e[num23];
								num25 = (matrixH[num23, num] = (num13 * num7 - num8 * num6) / num5);
								if (Math.Abs(num13) > Math.Abs(num8))
								{
									matrixH[num23 + 1, num] = (0f - num6 - num12 * num25) / num13;
								}
								else
								{
									matrixH[num23 + 1, num] = (0f - num7 - num14 * num25) / num8;
								}
							}
							num25 = Math.Abs(matrixH[num23, num]);
							if (num2 * num25 * num25 > 1f)
							{
								for (int num26 = num23; num26 <= num; num26++)
								{
									matrixH[num26, num] /= num25;
								}
							}
						}
					}
				}
				else if (num5 < 0f)
				{
					int num27 = num - 1;
					if (Math.Abs(matrixH[num, num - 1]) > Math.Abs(matrixH[num - 1, num]))
					{
						matrixH[num - 1, num - 1] = num5 / matrixH[num, num - 1];
						matrixH[num - 1, num] = (0f - (matrixH[num, num] - num4)) / matrixH[num, num - 1];
					}
					else
					{
						MathNet.Numerics.Complex32 complex = Cdiv(0f, 0f - matrixH[num - 1, num], matrixH[num - 1, num - 1] - num4, num5);
						matrixH[num - 1, num - 1] = complex.Real;
						matrixH[num - 1, num] = complex.Imaginary;
					}
					matrixH[num, num - 1] = 0f;
					matrixH[num, num] = 1f;
					for (int num28 = num - 2; num28 >= 0; num28--)
					{
						float num29 = 0f;
						float num30 = 0f;
						for (int num31 = num27; num31 <= num; num31++)
						{
							num29 += matrixH[num28, num31] * matrixH[num31, num - 1];
							num30 += matrixH[num28, num31] * matrixH[num31, num];
						}
						float num12 = matrixH[num28, num28] - num4;
						if (e[num28] < 0f)
						{
							num8 = num12;
							num6 = num29;
							num7 = num30;
						}
						else
						{
							num27 = num28;
							if (e[num28] == 0f)
							{
								MathNet.Numerics.Complex32 complex2 = Cdiv(0f - num29, 0f - num30, num12, num5);
								matrixH[num28, num - 1] = complex2.Real;
								matrixH[num28, num] = complex2.Imaginary;
							}
							else
							{
								float num13 = matrixH[num28, num28 + 1];
								float num14 = matrixH[num28 + 1, num28];
								float num32 = (d[num28] - num4) * (d[num28] - num4) + e[num28] * e[num28] - num5 * num5;
								float num33 = (d[num28] - num4) * 2f * num5;
								if (num32 == 0f && num33 == 0f)
								{
									num32 = num2 * num9 * (Math.Abs(num12) + Math.Abs(num5) + Math.Abs(num13) + Math.Abs(num14) + Math.Abs(num8));
								}
								MathNet.Numerics.Complex32 complex3 = Cdiv(num13 * num6 - num8 * num29 + num5 * num30, num13 * num7 - num8 * num30 - num5 * num29, num32, num33);
								matrixH[num28, num - 1] = complex3.Real;
								matrixH[num28, num] = complex3.Imaginary;
								if (Math.Abs(num13) > Math.Abs(num8) + Math.Abs(num5))
								{
									matrixH[num28 + 1, num - 1] = (0f - num29 - num12 * matrixH[num28, num - 1] + num5 * matrixH[num28, num]) / num13;
									matrixH[num28 + 1, num] = (0f - num30 - num12 * matrixH[num28, num] - num5 * matrixH[num28, num - 1]) / num13;
								}
								else
								{
									complex3 = Cdiv(0f - num6 - num14 * matrixH[num28, num - 1], 0f - num7 - num14 * matrixH[num28, num], num8, num5);
									matrixH[num28 + 1, num - 1] = complex3.Real;
									matrixH[num28 + 1, num] = complex3.Imaginary;
								}
							}
							float num25 = Math.Max(Math.Abs(matrixH[num28, num - 1]), Math.Abs(matrixH[num28, num]));
							if (num2 * num25 * num25 > 1f)
							{
								for (int num34 = num28; num34 <= num; num34++)
								{
									matrixH[num34, num - 1] /= num25;
									matrixH[num34, num] /= num25;
								}
							}
						}
					}
				}
			}
			for (int num35 = order - 1; num35 >= 0; num35--)
			{
				for (int num36 = 0; num36 < order; num36++)
				{
					num8 = 0f;
					for (int num37 = 0; num37 <= num35; num37++)
					{
						num8 += eigenVectors.At(num36, num37) * matrixH[num37, num35];
					}
					eigenVectors.At(num36, num35, num8);
				}
			}
		}

		private static MathNet.Numerics.Complex32 Cdiv(float xreal, float ximag, float yreal, float yimag)
		{
			if (Math.Abs(yimag) < Math.Abs(yreal))
			{
				return new MathNet.Numerics.Complex32((xreal + ximag * (yimag / yreal)) / (yreal + yimag * (yimag / yreal)), (ximag - xreal * (yimag / yreal)) / (yreal + yimag * (yimag / yreal)));
			}
			return new MathNet.Numerics.Complex32((ximag + xreal * (yreal / yimag)) / (yimag + yreal * (yreal / yimag)), (0f - xreal + ximag * (yreal / yimag)) / (yimag + yreal * (yreal / yimag)));
		}

		public override void Solve(Matrix<float> input, Matrix<float> result)
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
				float[] array = new float[count];
				for (int i = 0; i < count; i++)
				{
					for (int j = 0; j < count; j++)
					{
						float num = 0f;
						if (j < count)
						{
							for (int k = 0; k < count; k++)
							{
								num += base.EigenVectors.At(k, j) * input.At(k, i);
							}
							num /= (float)base.EigenValues[j].Real;
						}
						array[j] = num;
					}
					for (int l = 0; l < count; l++)
					{
						float num2 = 0f;
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

		public override void Solve(Vector<float> input, Vector<float> result)
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
				float[] array = new float[count];
				for (int i = 0; i < count; i++)
				{
					float num = 0f;
					if (i < count)
					{
						for (int j = 0; j < count; j++)
						{
							num += base.EigenVectors.At(j, i) * input[j];
						}
						num /= (float)base.EigenValues[i].Real;
					}
					array[i] = num;
				}
				for (int k = 0; k < count; k++)
				{
					float num = 0f;
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
