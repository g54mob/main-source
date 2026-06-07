using System;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra.Complex;

namespace MathNet.Numerics.LinearAlgebra.Complex32.Factorization
{
	internal sealed class UserEvd : Evd
	{
		public static UserEvd Create(Matrix<MathNet.Numerics.Complex32> matrix, Symmetricity symmetricity)
		{
			if (matrix.RowCount != matrix.ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.");
			}
			int rowCount = matrix.RowCount;
			DenseMatrix eigenVectors = DenseMatrix.CreateIdentity(rowCount);
			Matrix<MathNet.Numerics.Complex32> matrix2 = Matrix<MathNet.Numerics.Complex32>.Build.SameAs(matrix, rowCount, rowCount);
			MathNet.Numerics.LinearAlgebra.Complex.DenseVector denseVector = new MathNet.Numerics.LinearAlgebra.Complex.DenseVector(rowCount);
			bool flag = symmetricity switch
			{
				Symmetricity.Hermitian => true, 
				Symmetricity.Asymmetric => false, 
				_ => matrix.IsHermitian(), 
			};
			if (flag)
			{
				MathNet.Numerics.Complex32[,] matrixA = matrix.ToArray();
				MathNet.Numerics.Complex32[] tau = new MathNet.Numerics.Complex32[rowCount];
				float[] array = new float[rowCount];
				float[] array2 = new float[rowCount];
				SymmetricTridiagonalize(matrixA, array, array2, tau, rowCount);
				SymmetricDiagonalize(eigenVectors, array, array2, rowCount);
				SymmetricUntridiagonalize(eigenVectors, matrixA, tau, rowCount);
				for (int i = 0; i < rowCount; i++)
				{
					denseVector[i] = new System.Numerics.Complex(array[i], array2[i]);
				}
			}
			else
			{
				MathNet.Numerics.Complex32[,] matrixH = matrix.ToArray();
				NonsymmetricReduceToHessenberg(eigenVectors, matrixH, rowCount);
				NonsymmetricReduceHessenberToRealSchur(eigenVectors, denseVector, matrixH, rowCount);
			}
			for (int j = 0; j < denseVector.Count; j++)
			{
				matrix2.At(j, j, (MathNet.Numerics.Complex32)denseVector[j]);
			}
			return new UserEvd(eigenVectors, denseVector, matrix2, flag);
		}

		private UserEvd(Matrix<MathNet.Numerics.Complex32> eigenVectors, Vector<System.Numerics.Complex> eigenValues, Matrix<MathNet.Numerics.Complex32> blockDiagonal, bool isSymmetric)
			: base(eigenVectors, eigenValues, blockDiagonal, isSymmetric)
		{
		}

		private static void SymmetricTridiagonalize(MathNet.Numerics.Complex32[,] matrixA, float[] d, float[] e, MathNet.Numerics.Complex32[] tau, int order)
		{
			tau[order - 1] = MathNet.Numerics.Complex32.One;
			for (int i = 0; i < order; i++)
			{
				d[i] = matrixA[i, i].Real;
			}
			float num4;
			for (int num = order - 1; num > 0; num--)
			{
				float num2 = 0f;
				float num3 = 0f;
				for (int j = 0; j < num; j++)
				{
					num2 = num2 + Math.Abs(matrixA[num, j].Real) + Math.Abs(matrixA[num, j].Imaginary);
				}
				if (num2 == 0f)
				{
					tau[num - 1] = MathNet.Numerics.Complex32.One;
					e[num] = 0f;
				}
				else
				{
					for (int k = 0; k < num; k++)
					{
						matrixA[num, k] /= num2;
						num3 += matrixA[num, k].MagnitudeSquared;
					}
					MathNet.Numerics.Complex32 complex = (float)Math.Sqrt(num3);
					e[num] = num2 * complex.Real;
					MathNet.Numerics.Complex32 complex2 = matrixA[num, num - 1];
					MathNet.Numerics.Complex32 complex3;
					if (complex2.Magnitude != 0f)
					{
						complex3 = -(matrixA[num, num - 1].Conjugate() * tau[num].Conjugate()) / complex2.Magnitude;
						num3 += complex2.Magnitude * complex.Real;
						complex = 1f + complex / complex2.Magnitude;
						matrixA[num, num - 1] *= complex;
					}
					else
					{
						complex3 = -tau[num].Conjugate();
						matrixA[num, num - 1] = complex;
					}
					if (complex2.Magnitude == 0f || num != 1)
					{
						complex2 = MathNet.Numerics.Complex32.Zero;
						for (int l = 0; l < num; l++)
						{
							MathNet.Numerics.Complex32 zero = MathNet.Numerics.Complex32.Zero;
							for (int m = 0; m <= l; m++)
							{
								zero += matrixA[l, m] * matrixA[num, m].Conjugate();
							}
							for (int n = l + 1; n <= num - 1; n++)
							{
								zero += matrixA[n, l].Conjugate() * matrixA[num, n].Conjugate();
							}
							tau[l] = zero / num3;
							complex2 += zero / num3 * matrixA[num, l];
						}
						num4 = complex2.Real / (num3 + num3);
						for (int num5 = 0; num5 < num; num5++)
						{
							complex2 = matrixA[num, num5].Conjugate();
							complex = tau[num5] - num4 * complex2;
							tau[num5] = complex.Conjugate();
							for (int num6 = 0; num6 <= num5; num6++)
							{
								matrixA[num5, num6] -= complex2 * tau[num6] + complex * matrixA[num, num6];
							}
						}
					}
					for (int num7 = 0; num7 < num; num7++)
					{
						matrixA[num, num7] *= num2;
					}
					tau[num - 1] = complex3.Conjugate();
				}
				num4 = d[num];
				d[num] = matrixA[num, num].Real;
				matrixA[num, num] = new MathNet.Numerics.Complex32(num4, num2 * (float)Math.Sqrt(num3));
			}
			num4 = d[0];
			d[0] = matrixA[0, 0].Real;
			matrixA[0, 0] = num4;
			e[0] = 0f;
		}

		private static void SymmetricDiagonalize(Matrix<MathNet.Numerics.Complex32> eigenVectors, float[] d, float[] e, int order)
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
								num8 = eigenVectors.At(m, num15 + 1).Real;
								eigenVectors.At(m, num15 + 1, num13 * eigenVectors.At(m, num15).Real + num9 * num8);
								eigenVectors.At(m, num15, num9 * eigenVectors.At(m, num15).Real - num13 * num8);
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
						num17 = eigenVectors.At(num19, n).Real;
						eigenVectors.At(num19, n, eigenVectors.At(num19, num16));
						eigenVectors.At(num19, num16, num17);
					}
				}
			}
		}

		private static void SymmetricUntridiagonalize(Matrix<MathNet.Numerics.Complex32> eigenVectors, MathNet.Numerics.Complex32[,] matrixA, MathNet.Numerics.Complex32[] tau, int order)
		{
			for (int i = 0; i < order; i++)
			{
				for (int j = 0; j < order; j++)
				{
					eigenVectors.At(i, j, eigenVectors.At(i, j).Real * tau[i].Conjugate());
				}
			}
			for (int k = 1; k < order; k++)
			{
				float imaginary = matrixA[k, k].Imaginary;
				if (imaginary == 0f)
				{
					continue;
				}
				for (int l = 0; l < order; l++)
				{
					MathNet.Numerics.Complex32 zero = MathNet.Numerics.Complex32.Zero;
					for (int m = 0; m < k; m++)
					{
						zero += eigenVectors.At(m, l) * matrixA[k, m];
					}
					zero = zero / imaginary / imaginary;
					for (int n = 0; n < k; n++)
					{
						eigenVectors.At(n, l, eigenVectors.At(n, l) - zero * matrixA[k, n].Conjugate());
					}
				}
			}
		}

		private static void NonsymmetricReduceToHessenberg(Matrix<MathNet.Numerics.Complex32> eigenVectors, MathNet.Numerics.Complex32[,] matrixH, int order)
		{
			MathNet.Numerics.Complex32[] array = new MathNet.Numerics.Complex32[order];
			for (int i = 1; i < order - 1; i++)
			{
				float num = 0f;
				for (int j = i; j < order; j++)
				{
					num += Math.Abs(matrixH[j, i - 1].Real) + Math.Abs(matrixH[j, i - 1].Imaginary);
				}
				if (num == 0f)
				{
					continue;
				}
				float num2 = 0f;
				for (int num3 = order - 1; num3 >= i; num3--)
				{
					array[num3] = matrixH[num3, i - 1] / num;
					num2 += array[num3].MagnitudeSquared;
				}
				float num4 = (float)Math.Sqrt(num2);
				if (array[i].Magnitude != 0f)
				{
					num2 += array[i].Magnitude * num4;
					num4 /= array[i].Magnitude;
					array[i] = (1f + num4) * array[i];
				}
				else
				{
					array[i] = num4;
					matrixH[i, i - 1] = num;
				}
				for (int k = i; k < order; k++)
				{
					MathNet.Numerics.Complex32 zero = MathNet.Numerics.Complex32.Zero;
					for (int num5 = order - 1; num5 >= i; num5--)
					{
						zero += array[num5].Conjugate() * matrixH[num5, k];
					}
					zero /= num2;
					for (int l = i; l < order; l++)
					{
						matrixH[l, k] -= zero * array[l];
					}
				}
				for (int m = 0; m < order; m++)
				{
					MathNet.Numerics.Complex32 zero2 = MathNet.Numerics.Complex32.Zero;
					for (int num6 = order - 1; num6 >= i; num6--)
					{
						zero2 += array[num6] * matrixH[m, num6];
					}
					zero2 /= num2;
					for (int n = i; n < order; n++)
					{
						matrixH[m, n] -= zero2 * array[n].Conjugate();
					}
				}
				array[i] = num * array[i];
				matrixH[i, i - 1] *= 0f - num4;
			}
			for (int num7 = 0; num7 < order; num7++)
			{
				for (int num8 = 0; num8 < order; num8++)
				{
					eigenVectors.At(num7, num8, (num7 == num8) ? MathNet.Numerics.Complex32.One : MathNet.Numerics.Complex32.Zero);
				}
			}
			for (int num9 = order - 2; num9 >= 1; num9--)
			{
				if (matrixH[num9, num9 - 1] != MathNet.Numerics.Complex32.Zero && array[num9] != MathNet.Numerics.Complex32.Zero)
				{
					float num10 = matrixH[num9, num9 - 1].Real * array[num9].Real + matrixH[num9, num9 - 1].Imaginary * array[num9].Imaginary;
					for (int num11 = num9 + 1; num11 < order; num11++)
					{
						array[num11] = matrixH[num11, num9 - 1];
					}
					for (int num12 = num9; num12 < order; num12++)
					{
						MathNet.Numerics.Complex32 zero3 = MathNet.Numerics.Complex32.Zero;
						for (int num13 = num9; num13 < order; num13++)
						{
							zero3 += array[num13].Conjugate() * eigenVectors.At(num13, num12);
						}
						zero3 /= num10;
						for (int num14 = num9; num14 < order; num14++)
						{
							eigenVectors.At(num14, num12, eigenVectors.At(num14, num12) + zero3 * array[num14]);
						}
					}
				}
			}
			for (int num15 = 1; num15 < order; num15++)
			{
				if (matrixH[num15, num15 - 1].Imaginary != 0f)
				{
					MathNet.Numerics.Complex32 complex = matrixH[num15, num15 - 1] / matrixH[num15, num15 - 1].Magnitude;
					matrixH[num15, num15 - 1] = matrixH[num15, num15 - 1].Magnitude;
					for (int num16 = num15; num16 < order; num16++)
					{
						matrixH[num15, num16] *= complex.Conjugate();
					}
					for (int num17 = 0; num17 <= Math.Min(num15 + 1, order - 1); num17++)
					{
						matrixH[num17, num15] *= complex;
					}
					for (int num18 = 0; num18 < order; num18++)
					{
						eigenVectors.At(num18, num15, eigenVectors.At(num18, num15) * complex);
					}
				}
			}
		}

		private static void NonsymmetricReduceHessenberToRealSchur(Matrix<MathNet.Numerics.Complex32> eigenVectors, Vector<System.Numerics.Complex> eigenValues, MathNet.Numerics.Complex32[,] matrixH, int order)
		{
			int num = order - 1;
			float num2 = (float)Precision.SinglePrecision;
			MathNet.Numerics.Complex32 zero = MathNet.Numerics.Complex32.Zero;
			int num3 = 0;
			float num6;
			while (num >= 0)
			{
				int num4;
				for (num4 = num; num4 > 0; num4--)
				{
					float num5 = Math.Abs(matrixH[num4 - 1, num4 - 1].Real) + Math.Abs(matrixH[num4 - 1, num4 - 1].Imaginary) + Math.Abs(matrixH[num4, num4].Real) + Math.Abs(matrixH[num4, num4].Imaginary);
					if (Math.Abs(matrixH[num4, num4 - 1].Real) < num2 * num5)
					{
						break;
					}
				}
				if (num4 == num)
				{
					matrixH[num, num] += zero;
					eigenValues[num] = matrixH[num, num].ToComplex();
					num--;
					num3 = 0;
					continue;
				}
				MathNet.Numerics.Complex32 complex;
				if (num3 != 10 && num3 != 20)
				{
					complex = matrixH[num, num];
					MathNet.Numerics.Complex32 complex2 = matrixH[num - 1, num] * matrixH[num, num - 1].Real;
					if (complex2.Real != 0f || complex2.Imaginary != 0f)
					{
						MathNet.Numerics.Complex32 complex3 = (matrixH[num - 1, num - 1] - complex) / 2f;
						MathNet.Numerics.Complex32 complex4 = (complex3 * complex3 + complex2).SquareRoot();
						if (complex3.Real * complex4.Real + complex3.Imaginary * complex4.Imaginary < 0f)
						{
							complex4 *= -1f;
						}
						complex2 /= complex3 + complex4;
						complex -= complex2;
					}
				}
				else
				{
					complex = Math.Abs(matrixH[num, num - 1].Real) + Math.Abs(matrixH[num - 1, num - 2].Real);
				}
				for (int i = 0; i <= num; i++)
				{
					matrixH[i, i] -= complex;
				}
				zero += complex;
				num3++;
				for (int j = num4 + 1; j <= num; j++)
				{
					complex = matrixH[j, j - 1].Real;
					num6 = SpecialFunctions.Hypotenuse(matrixH[j - 1, j - 1].Magnitude, complex.Real);
					MathNet.Numerics.Complex32 complex2 = matrixH[j - 1, j - 1] / num6;
					eigenValues[j - 1] = complex2.ToComplex();
					matrixH[j - 1, j - 1] = num6;
					matrixH[j, j - 1] = new MathNet.Numerics.Complex32(0f, complex.Real / num6);
					for (int k = j; k < order; k++)
					{
						MathNet.Numerics.Complex32 complex3 = matrixH[j - 1, k];
						MathNet.Numerics.Complex32 complex4 = matrixH[j, k];
						matrixH[j - 1, k] = complex2.Conjugate() * complex3 + matrixH[j, j - 1].Imaginary * complex4;
						matrixH[j, k] = complex2 * complex4 - matrixH[j, j - 1].Imaginary * complex3;
					}
				}
				complex = matrixH[num, num];
				if (complex.Imaginary != 0f)
				{
					complex /= matrixH[num, num].Magnitude;
					matrixH[num, num] = matrixH[num, num].Magnitude;
					for (int l = num + 1; l < order; l++)
					{
						matrixH[num, l] *= complex.Conjugate();
					}
				}
				for (int m = num4 + 1; m <= num; m++)
				{
					MathNet.Numerics.Complex32 complex2 = (MathNet.Numerics.Complex32)eigenValues[m - 1];
					for (int n = 0; n <= m; n++)
					{
						MathNet.Numerics.Complex32 complex4 = matrixH[n, m];
						MathNet.Numerics.Complex32 complex3;
						if (n != m)
						{
							complex3 = matrixH[n, m - 1];
							matrixH[n, m - 1] = complex2 * complex3 + matrixH[m, m - 1].Imaginary * complex4;
						}
						else
						{
							complex3 = matrixH[n, m - 1].Real;
							matrixH[n, m - 1] = new MathNet.Numerics.Complex32(complex2.Real * complex3.Real - complex2.Imaginary * complex3.Imaginary + matrixH[m, m - 1].Imaginary * complex4.Real, matrixH[n, m - 1].Imaginary);
						}
						matrixH[n, m] = complex2.Conjugate() * complex4 - matrixH[m, m - 1].Imaginary * complex3;
					}
					for (int num7 = 0; num7 < order; num7++)
					{
						MathNet.Numerics.Complex32 complex3 = eigenVectors.At(num7, m - 1);
						MathNet.Numerics.Complex32 complex4 = eigenVectors.At(num7, m);
						eigenVectors.At(num7, m - 1, complex2 * complex3 + matrixH[m, m - 1].Imaginary * complex4);
						eigenVectors.At(num7, m, complex2.Conjugate() * complex4 - matrixH[m, m - 1].Imaginary * complex3);
					}
				}
				if (complex.Imaginary != 0f)
				{
					for (int num8 = 0; num8 <= num; num8++)
					{
						matrixH[num8, num] *= complex;
					}
					for (int num9 = 0; num9 < order; num9++)
					{
						eigenVectors.At(num9, num, eigenVectors.At(num9, num) * complex);
					}
				}
			}
			num6 = 0f;
			for (int num10 = 0; num10 < order; num10++)
			{
				for (int num11 = num10; num11 < order; num11++)
				{
					num6 = Math.Max(num6, Math.Abs(matrixH[num10, num11].Real) + Math.Abs(matrixH[num10, num11].Imaginary));
				}
			}
			if (order == 1 || num6 == 0f)
			{
				return;
			}
			for (num = order - 1; num > 0; num--)
			{
				MathNet.Numerics.Complex32 complex2 = (MathNet.Numerics.Complex32)eigenValues[num];
				matrixH[num, num] = 1f;
				for (int num12 = num - 1; num12 >= 0; num12--)
				{
					MathNet.Numerics.Complex32 complex4 = 0f;
					for (int num13 = num12 + 1; num13 <= num; num13++)
					{
						complex4 += matrixH[num12, num13] * matrixH[num13, num];
					}
					MathNet.Numerics.Complex32 complex3 = complex2 - (MathNet.Numerics.Complex32)eigenValues[num12];
					if (complex3.Real == 0f && complex3.Imaginary == 0f)
					{
						complex3 = num2 * num6;
					}
					matrixH[num12, num] = complex4 / complex3;
					float num14 = Math.Abs(matrixH[num12, num].Real) + Math.Abs(matrixH[num12, num].Imaginary);
					if (num2 * num14 * num14 > 1f)
					{
						for (int num15 = num12; num15 <= num; num15++)
						{
							matrixH[num15, num] /= num14;
						}
					}
				}
			}
			for (int num16 = order - 1; num16 > 0; num16--)
			{
				for (int num17 = 0; num17 < order; num17++)
				{
					MathNet.Numerics.Complex32 complex4 = MathNet.Numerics.Complex32.Zero;
					for (int num18 = 0; num18 <= num16; num18++)
					{
						complex4 += eigenVectors.At(num17, num18) * matrixH[num18, num16];
					}
					eigenVectors.At(num17, num16, complex4);
				}
			}
		}

		public override void Solve(Matrix<MathNet.Numerics.Complex32> input, Matrix<MathNet.Numerics.Complex32> result)
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
				MathNet.Numerics.Complex32[] array = new MathNet.Numerics.Complex32[count];
				for (int i = 0; i < count; i++)
				{
					for (int j = 0; j < count; j++)
					{
						MathNet.Numerics.Complex32 complex = 0f;
						if (j < count)
						{
							for (int k = 0; k < count; k++)
							{
								complex += base.EigenVectors.At(k, j).Conjugate() * input.At(k, i);
							}
							complex /= (float)base.EigenValues[j].Real;
						}
						array[j] = complex;
					}
					for (int l = 0; l < count; l++)
					{
						MathNet.Numerics.Complex32 value = 0f;
						for (int m = 0; m < count; m++)
						{
							value += base.EigenVectors.At(l, m) * array[m];
						}
						result.At(l, i, value);
					}
				}
				return;
			}
			throw new ArgumentException("Matrix must be symmetric.");
		}

		public override void Solve(Vector<MathNet.Numerics.Complex32> input, Vector<MathNet.Numerics.Complex32> result)
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
				MathNet.Numerics.Complex32[] array = new MathNet.Numerics.Complex32[count];
				for (int i = 0; i < count; i++)
				{
					MathNet.Numerics.Complex32 complex = 0;
					if (i < count)
					{
						for (int j = 0; j < count; j++)
						{
							complex += base.EigenVectors.At(j, i).Conjugate() * input[j];
						}
						complex /= (float)base.EigenValues[i].Real;
					}
					array[i] = complex;
				}
				for (int k = 0; k < count; k++)
				{
					MathNet.Numerics.Complex32 complex = 0;
					for (int l = 0; l < count; l++)
					{
						complex += base.EigenVectors.At(k, l) * array[l];
					}
					result[k] = complex;
				}
				return;
			}
			throw new ArgumentException("Matrix must be symmetric.");
		}
	}
}
