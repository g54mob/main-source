using System;
using System.Numerics;

namespace MathNet.Numerics.LinearAlgebra.Complex.Factorization
{
	internal sealed class UserEvd : Evd
	{
		public static UserEvd Create(Matrix<System.Numerics.Complex> matrix, Symmetricity symmetricity)
		{
			if (matrix.RowCount != matrix.ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.");
			}
			int rowCount = matrix.RowCount;
			DenseMatrix eigenVectors = DenseMatrix.CreateIdentity(rowCount);
			Matrix<System.Numerics.Complex> matrix2 = Matrix<System.Numerics.Complex>.Build.SameAs(matrix, rowCount, rowCount);
			DenseVector denseVector = new DenseVector(rowCount);
			bool flag = symmetricity switch
			{
				Symmetricity.Hermitian => true, 
				Symmetricity.Asymmetric => false, 
				_ => matrix.IsHermitian(), 
			};
			if (flag)
			{
				System.Numerics.Complex[,] matrixA = matrix.ToArray();
				System.Numerics.Complex[] tau = new System.Numerics.Complex[rowCount];
				double[] array = new double[rowCount];
				double[] array2 = new double[rowCount];
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
				System.Numerics.Complex[,] matrixH = matrix.ToArray();
				NonsymmetricReduceToHessenberg(eigenVectors, matrixH, rowCount);
				NonsymmetricReduceHessenberToRealSchur(eigenVectors, denseVector, matrixH, rowCount);
			}
			matrix2.SetDiagonal(denseVector);
			return new UserEvd(eigenVectors, denseVector, matrix2, flag);
		}

		private UserEvd(Matrix<System.Numerics.Complex> eigenVectors, Vector<System.Numerics.Complex> eigenValues, Matrix<System.Numerics.Complex> blockDiagonal, bool isSymmetric)
			: base(eigenVectors, eigenValues, blockDiagonal, isSymmetric)
		{
		}

		private static void SymmetricTridiagonalize(System.Numerics.Complex[,] matrixA, double[] d, double[] e, System.Numerics.Complex[] tau, int order)
		{
			tau[order - 1] = System.Numerics.Complex.One;
			for (int i = 0; i < order; i++)
			{
				d[i] = matrixA[i, i].Real;
			}
			double num4;
			for (int num = order - 1; num > 0; num--)
			{
				double num2 = 0.0;
				double num3 = 0.0;
				for (int j = 0; j < num; j++)
				{
					num2 = num2 + Math.Abs(matrixA[num, j].Real) + Math.Abs(matrixA[num, j].Imaginary);
				}
				if (num2 == 0.0)
				{
					tau[num - 1] = System.Numerics.Complex.One;
					e[num] = 0.0;
				}
				else
				{
					for (int k = 0; k < num; k++)
					{
						matrixA[num, k] /= (System.Numerics.Complex)num2;
						num3 += matrixA[num, k].MagnitudeSquared();
					}
					System.Numerics.Complex complex = Math.Sqrt(num3);
					e[num] = num2 * complex.Real;
					System.Numerics.Complex complex2 = matrixA[num, num - 1];
					System.Numerics.Complex complex3;
					if (complex2.Magnitude != 0.0)
					{
						complex3 = -(matrixA[num, num - 1].Conjugate() * tau[num].Conjugate()) / complex2.Magnitude;
						num3 += complex2.Magnitude * complex.Real;
						complex = 1.0 + complex / complex2.Magnitude;
						matrixA[num, num - 1] *= complex;
					}
					else
					{
						complex3 = -tau[num].Conjugate();
						matrixA[num, num - 1] = complex;
					}
					if (complex2.Magnitude == 0.0 || num != 1)
					{
						complex2 = System.Numerics.Complex.Zero;
						for (int l = 0; l < num; l++)
						{
							System.Numerics.Complex zero = System.Numerics.Complex.Zero;
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
						matrixA[num, num7] *= (System.Numerics.Complex)num2;
					}
					tau[num - 1] = complex3.Conjugate();
				}
				num4 = d[num];
				d[num] = matrixA[num, num].Real;
				matrixA[num, num] = new System.Numerics.Complex(num4, num2 * Math.Sqrt(num3));
			}
			num4 = d[0];
			d[0] = matrixA[0, 0].Real;
			matrixA[0, 0] = num4;
			e[0] = 0.0;
		}

		private static void SymmetricDiagonalize(Matrix<System.Numerics.Complex> eigenVectors, double[] d, double[] e, int order)
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
								num8 = eigenVectors.At(m, num15 + 1).Real;
								eigenVectors.At(m, num15 + 1, num13 * eigenVectors.At(m, num15).Real + num9 * num8);
								eigenVectors.At(m, num15, num9 * eigenVectors.At(m, num15).Real - num13 * num8);
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
						num17 = eigenVectors.At(num19, n).Real;
						eigenVectors.At(num19, n, eigenVectors.At(num19, num16));
						eigenVectors.At(num19, num16, num17);
					}
				}
			}
		}

		private static void SymmetricUntridiagonalize(Matrix<System.Numerics.Complex> eigenVectors, System.Numerics.Complex[,] matrixA, System.Numerics.Complex[] tau, int order)
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
				double imaginary = matrixA[k, k].Imaginary;
				if (imaginary == 0.0)
				{
					continue;
				}
				for (int l = 0; l < order; l++)
				{
					System.Numerics.Complex zero = System.Numerics.Complex.Zero;
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

		private static void NonsymmetricReduceToHessenberg(Matrix<System.Numerics.Complex> eigenVectors, System.Numerics.Complex[,] matrixH, int order)
		{
			System.Numerics.Complex[] array = new System.Numerics.Complex[order];
			for (int i = 1; i < order - 1; i++)
			{
				double num = 0.0;
				for (int j = i; j < order; j++)
				{
					num += Math.Abs(matrixH[j, i - 1].Real) + Math.Abs(matrixH[j, i - 1].Imaginary);
				}
				if (num == 0.0)
				{
					continue;
				}
				double num2 = 0.0;
				for (int num3 = order - 1; num3 >= i; num3--)
				{
					array[num3] = matrixH[num3, i - 1] / num;
					num2 += array[num3].MagnitudeSquared();
				}
				double num4 = Math.Sqrt(num2);
				if (array[i].Magnitude != 0.0)
				{
					num2 += array[i].Magnitude * num4;
					num4 /= array[i].Magnitude;
					array[i] = (1.0 + num4) * array[i];
				}
				else
				{
					array[i] = num4;
					matrixH[i, i - 1] = num;
				}
				for (int k = i; k < order; k++)
				{
					System.Numerics.Complex zero = System.Numerics.Complex.Zero;
					for (int num5 = order - 1; num5 >= i; num5--)
					{
						zero += array[num5].Conjugate() * matrixH[num5, k];
					}
					zero /= (System.Numerics.Complex)num2;
					for (int l = i; l < order; l++)
					{
						matrixH[l, k] -= zero * array[l];
					}
				}
				for (int m = 0; m < order; m++)
				{
					System.Numerics.Complex zero2 = System.Numerics.Complex.Zero;
					for (int num6 = order - 1; num6 >= i; num6--)
					{
						zero2 += array[num6] * matrixH[m, num6];
					}
					zero2 /= (System.Numerics.Complex)num2;
					for (int n = i; n < order; n++)
					{
						matrixH[m, n] -= zero2 * array[n].Conjugate();
					}
				}
				array[i] = num * array[i];
				matrixH[i, i - 1] *= (System.Numerics.Complex)(0.0 - num4);
			}
			for (int num7 = 0; num7 < order; num7++)
			{
				for (int num8 = 0; num8 < order; num8++)
				{
					eigenVectors.At(num7, num8, (num7 == num8) ? System.Numerics.Complex.One : System.Numerics.Complex.Zero);
				}
			}
			for (int num9 = order - 2; num9 >= 1; num9--)
			{
				if (matrixH[num9, num9 - 1] != System.Numerics.Complex.Zero && array[num9] != System.Numerics.Complex.Zero)
				{
					double num10 = matrixH[num9, num9 - 1].Real * array[num9].Real + matrixH[num9, num9 - 1].Imaginary * array[num9].Imaginary;
					for (int num11 = num9 + 1; num11 < order; num11++)
					{
						array[num11] = matrixH[num11, num9 - 1];
					}
					for (int num12 = num9; num12 < order; num12++)
					{
						System.Numerics.Complex zero3 = System.Numerics.Complex.Zero;
						for (int num13 = num9; num13 < order; num13++)
						{
							zero3 += array[num13].Conjugate() * eigenVectors.At(num13, num12);
						}
						zero3 /= (System.Numerics.Complex)num10;
						for (int num14 = num9; num14 < order; num14++)
						{
							eigenVectors.At(num14, num12, eigenVectors.At(num14, num12) + zero3 * array[num14]);
						}
					}
				}
			}
			for (int num15 = 1; num15 < order; num15++)
			{
				if (matrixH[num15, num15 - 1].Imaginary != 0.0)
				{
					System.Numerics.Complex complex = matrixH[num15, num15 - 1] / matrixH[num15, num15 - 1].Magnitude;
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

		private static void NonsymmetricReduceHessenberToRealSchur(Matrix<System.Numerics.Complex> eigenVectors, Vector<System.Numerics.Complex> eigenValues, System.Numerics.Complex[,] matrixH, int order)
		{
			int num = order - 1;
			double doublePrecision = Precision.DoublePrecision;
			System.Numerics.Complex zero = System.Numerics.Complex.Zero;
			int num2 = 0;
			double num5;
			while (num >= 0)
			{
				int num3;
				for (num3 = num; num3 > 0; num3--)
				{
					double num4 = Math.Abs(matrixH[num3 - 1, num3 - 1].Real) + Math.Abs(matrixH[num3 - 1, num3 - 1].Imaginary) + Math.Abs(matrixH[num3, num3].Real) + Math.Abs(matrixH[num3, num3].Imaginary);
					if (Math.Abs(matrixH[num3, num3 - 1].Real) < doublePrecision * num4)
					{
						break;
					}
				}
				if (num3 == num)
				{
					matrixH[num, num] += zero;
					eigenValues[num] = matrixH[num, num];
					num--;
					num2 = 0;
					continue;
				}
				System.Numerics.Complex complex;
				if (num2 != 10 && num2 != 20)
				{
					complex = matrixH[num, num];
					System.Numerics.Complex complex2 = matrixH[num - 1, num] * matrixH[num, num - 1].Real;
					if (complex2.Real != 0.0 || complex2.Imaginary != 0.0)
					{
						System.Numerics.Complex complex3 = (matrixH[num - 1, num - 1] - complex) / 2.0;
						System.Numerics.Complex complex4 = (complex3 * complex3 + complex2).SquareRoot();
						if (complex3.Real * complex4.Real + complex3.Imaginary * complex4.Imaginary < 0.0)
						{
							complex4 *= (System.Numerics.Complex)(-1.0);
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
				num2++;
				for (int j = num3 + 1; j <= num; j++)
				{
					complex = matrixH[j, j - 1].Real;
					num5 = SpecialFunctions.Hypotenuse(matrixH[j - 1, j - 1].Magnitude, complex.Real);
					System.Numerics.Complex complex2 = (eigenValues[j - 1] = matrixH[j - 1, j - 1] / num5);
					matrixH[j - 1, j - 1] = num5;
					matrixH[j, j - 1] = new System.Numerics.Complex(0.0, complex.Real / num5);
					for (int k = j; k < order; k++)
					{
						System.Numerics.Complex complex3 = matrixH[j - 1, k];
						System.Numerics.Complex complex4 = matrixH[j, k];
						matrixH[j - 1, k] = complex2.Conjugate() * complex3 + matrixH[j, j - 1].Imaginary * complex4;
						matrixH[j, k] = complex2 * complex4 - matrixH[j, j - 1].Imaginary * complex3;
					}
				}
				complex = matrixH[num, num];
				if (complex.Imaginary != 0.0)
				{
					complex /= (System.Numerics.Complex)matrixH[num, num].Magnitude;
					matrixH[num, num] = matrixH[num, num].Magnitude;
					for (int l = num + 1; l < order; l++)
					{
						matrixH[num, l] *= complex.Conjugate();
					}
				}
				for (int m = num3 + 1; m <= num; m++)
				{
					System.Numerics.Complex complex2 = eigenValues[m - 1];
					for (int n = 0; n <= m; n++)
					{
						System.Numerics.Complex complex4 = matrixH[n, m];
						System.Numerics.Complex complex3;
						if (n != m)
						{
							complex3 = matrixH[n, m - 1];
							matrixH[n, m - 1] = complex2 * complex3 + matrixH[m, m - 1].Imaginary * complex4;
						}
						else
						{
							complex3 = matrixH[n, m - 1].Real;
							matrixH[n, m - 1] = new System.Numerics.Complex(complex2.Real * complex3.Real - complex2.Imaginary * complex3.Imaginary + matrixH[m, m - 1].Imaginary * complex4.Real, matrixH[n, m - 1].Imaginary);
						}
						matrixH[n, m] = complex2.Conjugate() * complex4 - matrixH[m, m - 1].Imaginary * complex3;
					}
					for (int num6 = 0; num6 < order; num6++)
					{
						System.Numerics.Complex complex3 = eigenVectors.At(num6, m - 1);
						System.Numerics.Complex complex4 = eigenVectors.At(num6, m);
						eigenVectors.At(num6, m - 1, complex2 * complex3 + matrixH[m, m - 1].Imaginary * complex4);
						eigenVectors.At(num6, m, complex2.Conjugate() * complex4 - matrixH[m, m - 1].Imaginary * complex3);
					}
				}
				if (complex.Imaginary != 0.0)
				{
					for (int num7 = 0; num7 <= num; num7++)
					{
						matrixH[num7, num] *= complex;
					}
					for (int num8 = 0; num8 < order; num8++)
					{
						eigenVectors.At(num8, num, eigenVectors.At(num8, num) * complex);
					}
				}
			}
			num5 = 0.0;
			for (int num9 = 0; num9 < order; num9++)
			{
				for (int num10 = num9; num10 < order; num10++)
				{
					num5 = Math.Max(num5, Math.Abs(matrixH[num9, num10].Real) + Math.Abs(matrixH[num9, num10].Imaginary));
				}
			}
			if (order == 1 || num5 == 0.0)
			{
				return;
			}
			for (num = order - 1; num > 0; num--)
			{
				System.Numerics.Complex complex2 = eigenValues[num];
				matrixH[num, num] = 1.0;
				for (int num11 = num - 1; num11 >= 0; num11--)
				{
					System.Numerics.Complex complex4 = 0.0;
					for (int num12 = num11 + 1; num12 <= num; num12++)
					{
						complex4 += matrixH[num11, num12] * matrixH[num12, num];
					}
					System.Numerics.Complex complex3 = complex2 - eigenValues[num11];
					if (complex3.Real == 0.0 && complex3.Imaginary == 0.0)
					{
						complex3 = doublePrecision * num5;
					}
					matrixH[num11, num] = complex4 / complex3;
					double num13 = Math.Abs(matrixH[num11, num].Real) + Math.Abs(matrixH[num11, num].Imaginary);
					if (doublePrecision * num13 * num13 > 1.0)
					{
						for (int num14 = num11; num14 <= num; num14++)
						{
							matrixH[num14, num] /= (System.Numerics.Complex)num13;
						}
					}
				}
			}
			for (int num15 = order - 1; num15 > 0; num15--)
			{
				for (int num16 = 0; num16 < order; num16++)
				{
					System.Numerics.Complex complex4 = System.Numerics.Complex.Zero;
					for (int num17 = 0; num17 <= num15; num17++)
					{
						complex4 += eigenVectors.At(num16, num17) * matrixH[num17, num15];
					}
					eigenVectors.At(num16, num15, complex4);
				}
			}
		}

		public override void Solve(Matrix<System.Numerics.Complex> input, Matrix<System.Numerics.Complex> result)
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
				System.Numerics.Complex[] array = new System.Numerics.Complex[count];
				for (int i = 0; i < count; i++)
				{
					for (int j = 0; j < count; j++)
					{
						System.Numerics.Complex complex = 0.0;
						if (j < count)
						{
							for (int k = 0; k < count; k++)
							{
								complex += base.EigenVectors.At(k, j).Conjugate() * input.At(k, i);
							}
							complex /= (System.Numerics.Complex)base.EigenValues[j].Real;
						}
						array[j] = complex;
					}
					for (int l = 0; l < count; l++)
					{
						System.Numerics.Complex value = 0.0;
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

		public override void Solve(Vector<System.Numerics.Complex> input, Vector<System.Numerics.Complex> result)
		{
			if (base.EigenValues.Count != input.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (base.EigenValues.Count != result.Count)
			{
				throw Matrix<System.Numerics.Complex>.DimensionsDontMatch<ArgumentException>(base.EigenValues, result);
			}
			if (base.IsSymmetric)
			{
				int count = base.EigenValues.Count;
				System.Numerics.Complex[] array = new System.Numerics.Complex[count];
				for (int i = 0; i < count; i++)
				{
					System.Numerics.Complex complex = 0;
					if (i < count)
					{
						for (int j = 0; j < count; j++)
						{
							complex += base.EigenVectors.At(j, i).Conjugate() * input[j];
						}
						complex /= (System.Numerics.Complex)base.EigenValues[i].Real;
					}
					array[i] = complex;
				}
				for (int k = 0; k < count; k++)
				{
					System.Numerics.Complex complex = 0;
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
