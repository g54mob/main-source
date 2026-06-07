using System;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra.Factorization;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.Providers.LinearAlgebra
{
	public sealed class ManagedLinearAlgebraProvider : ILinearAlgebraProvider, ILinearAlgebraProvider<double>, ILinearAlgebraProvider<float>, ILinearAlgebraProvider<Complex>, ILinearAlgebraProvider<Complex32>
	{
		public static ManagedLinearAlgebraProvider Instance { get; } = new ManagedLinearAlgebraProvider();

		public void AddVectorToScaledVector(Complex[] y, Complex alpha, Complex[] x, Complex[] result)
		{
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (y.Length != x.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (alpha.IsZero())
			{
				y.Copy(result);
			}
			else if (alpha.IsOne())
			{
				for (int i = 0; i < result.Length; i++)
				{
					result[i] = y[i] + x[i];
				}
			}
			else
			{
				for (int j = 0; j < result.Length; j++)
				{
					result[j] = y[j] + alpha * x[j];
				}
			}
		}

		public void ScaleArray(Complex alpha, Complex[] x, Complex[] result)
		{
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (alpha.IsZero())
			{
				Array.Clear(result, 0, result.Length);
				return;
			}
			if (alpha.IsOne())
			{
				x.Copy(result);
				return;
			}
			for (int i = 0; i < result.Length; i++)
			{
				result[i] = alpha * x[i];
			}
		}

		public void ConjugateArray(Complex[] x, Complex[] result)
		{
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			for (int i = 0; i < result.Length; i++)
			{
				result[i] = x[i].Conjugate();
			}
		}

		public Complex DotProduct(Complex[] x, Complex[] y)
		{
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (y.Length != x.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			Complex zero = Complex.Zero;
			for (int i = 0; i < y.Length; i++)
			{
				zero += y[i] * x[i];
			}
			return zero;
		}

		public void AddArrays(Complex[] x, Complex[] y, Complex[] result)
		{
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (y.Length != x.Length || y.Length != result.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			for (int i = 0; i < result.Length; i++)
			{
				result[i] = x[i] + y[i];
			}
		}

		public void SubtractArrays(Complex[] x, Complex[] y, Complex[] result)
		{
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (y.Length != x.Length || y.Length != result.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			for (int i = 0; i < result.Length; i++)
			{
				result[i] = x[i] - y[i];
			}
		}

		public void PointWiseMultiplyArrays(Complex[] x, Complex[] y, Complex[] result)
		{
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (y.Length != x.Length || y.Length != result.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			for (int i = 0; i < result.Length; i++)
			{
				result[i] = x[i] * y[i];
			}
		}

		public void PointWiseDivideArrays(Complex[] x, Complex[] y, Complex[] result)
		{
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (y.Length != x.Length || y.Length != result.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			CommonParallel.For(0, y.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					result[i] = x[i] / y[i];
				}
			});
		}

		public void PointWisePowerArrays(Complex[] x, Complex[] y, Complex[] result)
		{
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (y.Length != x.Length || y.Length != result.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			CommonParallel.For(0, y.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					result[i] = Complex.Pow(x[i], y[i]);
				}
			});
		}

		public double MatrixNorm(Norm norm, int rows, int columns, Complex[] matrix)
		{
			switch (norm)
			{
			case Norm.OneNorm:
			{
				double num3 = 0.0;
				for (int l = 0; l < columns; l++)
				{
					double num4 = 0.0;
					for (int m = 0; m < rows; m++)
					{
						num4 += matrix[l * rows + m].Magnitude;
					}
					num3 = Math.Max(num3, num4);
				}
				return num3;
			}
			case Norm.LargestAbsoluteValue:
			{
				double num2 = 0.0;
				for (int j = 0; j < columns; j++)
				{
					for (int k = 0; k < rows; k++)
					{
						num2 = Math.Max(matrix[j * rows + k].Magnitude, num2);
					}
				}
				return num2;
			}
			case Norm.InfinityNorm:
			{
				double[] array2 = new double[rows];
				for (int n = 0; n < columns; n++)
				{
					for (int num5 = 0; num5 < rows; num5++)
					{
						array2[num5] += matrix[n * rows + num5].Magnitude;
					}
				}
				double num6 = array2[0];
				for (int num7 = 0; num7 < array2.Length; num7++)
				{
					if (array2[num7] > num6)
					{
						num6 = array2[num7];
					}
				}
				return num6;
			}
			case Norm.FrobeniusNorm:
			{
				Complex[] array = new Complex[rows * rows];
				MatrixMultiplyWithUpdate(Transpose.DontTranspose, Transpose.ConjugateTranspose, 1.0, matrix, rows, columns, matrix, rows, columns, 0.0, array);
				double num = 0.0;
				for (int i = 0; i < rows; i++)
				{
					num += array[i * rows + i].Magnitude;
				}
				return Math.Sqrt(num);
			}
			default:
				throw new NotSupportedException();
			}
		}

		public void MatrixMultiply(Complex[] x, int rowsX, int columnsX, Complex[] y, int rowsY, int columnsY, Complex[] result)
		{
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (columnsX != rowsY)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"columnsA ({columnsX}) != rowsB ({rowsY})"));
			}
			if (rowsX * columnsX != x.Length)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"rowsA ({rowsX}) * columnsA ({columnsX}) != a.Length ({x.Length})"));
			}
			if (rowsY * columnsY != y.Length)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"rowsB ({rowsY}) * columnsB ({columnsY}) != b.Length ({y.Length})"));
			}
			if (rowsX * columnsY != result.Length)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"rowsA ({rowsX}) * columnsB ({columnsY}) != c.Length ({result.Length})"));
			}
			Array.Clear(result, 0, result.Length);
			Complex[][] columnDataB = new Complex[columnsY][];
			for (int i = 0; i < columnDataB.Length; i++)
			{
				Complex[] array = new Complex[rowsY];
				GetColumn(Transpose.DontTranspose, i, rowsY, columnsY, y, array);
				columnDataB[i] = array;
			}
			if (rowsX + columnsY + columnsX < Control.ParallelizeOrder || Control.MaxDegreeOfParallelism < 2)
			{
				Complex[] array2 = new Complex[columnsX];
				for (int j = 0; j < rowsX; j++)
				{
					GetRow(Transpose.DontTranspose, j, rowsX, columnsX, x, array2);
					for (int k = 0; k < columnsY; k++)
					{
						Complex[] array3 = columnDataB[k];
						Complex zero = Complex.Zero;
						for (int l = 0; l < array2.Length; l++)
						{
							zero += array2[l] * array3[l];
						}
						result[k * rowsX + j] += Complex.One * zero;
					}
				}
				return;
			}
			CommonParallel.For(0, rowsX, 1, delegate(int u, int v)
			{
				Complex[] array4 = new Complex[columnsX];
				for (int m = u; m < v; m++)
				{
					GetRow(Transpose.DontTranspose, m, rowsX, columnsX, x, array4);
					for (int n = 0; n < columnsY; n++)
					{
						Complex[] array5 = columnDataB[n];
						Complex zero2 = Complex.Zero;
						for (int num = 0; num < array4.Length; num++)
						{
							zero2 += array4[num] * array5[num];
						}
						result[n * rowsX + m] += Complex.One * zero2;
					}
				}
			});
		}

		public void MatrixMultiplyWithUpdate(Transpose transposeA, Transpose transposeB, Complex alpha, Complex[] a, int rowsA, int columnsA, Complex[] b, int rowsB, int columnsB, Complex beta, Complex[] c)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (c == null)
			{
				throw new ArgumentNullException("c");
			}
			if (transposeA != Transpose.DontTranspose)
			{
				int num = columnsA;
				int num2 = rowsA;
				columnsA = num2;
				rowsA = num;
			}
			if (transposeB != Transpose.DontTranspose)
			{
				int num3 = columnsB;
				int num2 = rowsB;
				columnsB = num2;
				rowsB = num3;
			}
			if (columnsA != rowsB)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"columnsA ({columnsA}) != rowsB ({rowsB})"));
			}
			if (rowsA * columnsA != a.Length)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"rowsA ({rowsA}) * columnsA ({columnsA}) != a.Length ({a.Length})"));
			}
			if (rowsB * columnsB != b.Length)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"rowsB ({rowsB}) * columnsB ({columnsB}) != b.Length ({b.Length})"));
			}
			if (rowsA * columnsB != c.Length)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"rowsA ({rowsA}) * columnsB ({columnsB}) != c.Length ({c.Length})"));
			}
			if (beta == Complex.Zero)
			{
				Array.Clear(c, 0, c.Length);
			}
			else if (beta != Complex.One)
			{
				ScaleArray(beta, c, c);
			}
			if (alpha == Complex.Zero)
			{
				return;
			}
			Complex[][] columnDataB = new Complex[columnsB][];
			for (int i = 0; i < columnDataB.Length; i++)
			{
				Complex[] array = new Complex[rowsB];
				GetColumn(transposeB, i, rowsB, columnsB, b, array);
				columnDataB[i] = array;
			}
			if (rowsA + columnsB + columnsA < Control.ParallelizeOrder || Control.MaxDegreeOfParallelism < 2)
			{
				Complex[] array2 = new Complex[columnsA];
				for (int j = 0; j < rowsA; j++)
				{
					GetRow(transposeA, j, rowsA, columnsA, a, array2);
					for (int k = 0; k < columnsB; k++)
					{
						Complex[] array3 = columnDataB[k];
						Complex zero = Complex.Zero;
						for (int l = 0; l < array2.Length; l++)
						{
							zero += array2[l] * array3[l];
						}
						c[k * rowsA + j] += alpha * zero;
					}
				}
				return;
			}
			CommonParallel.For(0, rowsA, 1, delegate(int u, int v)
			{
				Complex[] array4 = new Complex[columnsA];
				for (int m = u; m < v; m++)
				{
					GetRow(transposeA, m, rowsA, columnsA, a, array4);
					for (int n = 0; n < columnsB; n++)
					{
						Complex[] array5 = columnDataB[n];
						Complex zero2 = Complex.Zero;
						for (int num4 = 0; num4 < array4.Length; num4++)
						{
							zero2 += array4[num4] * array5[num4];
						}
						c[n * rowsA + m] += alpha * zero2;
					}
				}
			});
		}

		public void LUFactor(Complex[] data, int order, int[] ipiv)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (ipiv == null)
			{
				throw new ArgumentNullException("ipiv");
			}
			if (data.Length != order * order)
			{
				throw new ArgumentException("The array arguments must have the same length.", "data");
			}
			if (ipiv.Length != order)
			{
				throw new ArgumentException("The array arguments must have the same length.", "ipiv");
			}
			for (int i = 0; i < order; i++)
			{
				ipiv[i] = i;
			}
			Complex[] array = new Complex[order];
			for (int j = 0; j < order; j++)
			{
				int num = j * order;
				int num2 = num + j;
				for (int k = 0; k < order; k++)
				{
					array[k] = data[num + k];
				}
				for (int l = 0; l < order; l++)
				{
					int num3 = Math.Min(l, j);
					Complex zero = Complex.Zero;
					for (int m = 0; m < num3; m++)
					{
						zero += data[m * order + l] * array[m];
					}
					data[num + l] = (array[l] -= zero);
				}
				int num4 = j;
				for (int n = j + 1; n < order; n++)
				{
					if (array[n].Magnitude > array[num4].Magnitude)
					{
						num4 = n;
					}
				}
				if (num4 != j)
				{
					for (int num5 = 0; num5 < order; num5++)
					{
						int num6 = num5 * order;
						int num7 = num6 + num4;
						int num8 = num6 + j;
						ref Complex reference = ref data[num7];
						ref Complex reference2 = ref data[num8];
						Complex complex = data[num8];
						Complex complex2 = data[num7];
						reference = complex;
						reference2 = complex2;
					}
					ipiv[j] = num4;
				}
				if ((j < order) & (data[num2] != 0.0))
				{
					for (int num9 = j + 1; num9 < order; num9++)
					{
						data[num + num9] /= data[num2];
					}
				}
			}
		}

		public void LUInverse(Complex[] a, int order)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (a.Length != order * order)
			{
				throw new ArgumentException("The array arguments must have the same length.", "a");
			}
			int[] ipiv = new int[order];
			LUFactor(a, order, ipiv);
			LUInverseFactored(a, order, ipiv);
		}

		public void LUInverseFactored(Complex[] a, int order, int[] ipiv)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (ipiv == null)
			{
				throw new ArgumentNullException("ipiv");
			}
			if (a.Length != order * order)
			{
				throw new ArgumentException("The array arguments must have the same length.", "a");
			}
			if (ipiv.Length != order)
			{
				throw new ArgumentException("The array arguments must have the same length.", "ipiv");
			}
			Complex[] array = new Complex[a.Length];
			for (int i = 0; i < order; i++)
			{
				array[i + order * i] = Complex.One;
			}
			LUSolveFactored(order, a, order, ipiv, array);
			array.Copy(a);
		}

		public void LUSolve(int columnsOfB, Complex[] a, int order, Complex[] b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (a.Length != order * order)
			{
				throw new ArgumentException("The array arguments must have the same length.", "a");
			}
			if (b.Length != order * columnsOfB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			if (a == b)
			{
				throw new ArgumentException("Arguments must be different objects.");
			}
			int[] ipiv = new int[order];
			Complex[] array = new Complex[a.Length];
			a.Copy(array);
			LUFactor(array, order, ipiv);
			LUSolveFactored(columnsOfB, array, order, ipiv, b);
		}

		public void LUSolveFactored(int columnsOfB, Complex[] a, int order, int[] ipiv, Complex[] b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (ipiv == null)
			{
				throw new ArgumentNullException("ipiv");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (a.Length != order * order)
			{
				throw new ArgumentException("The array arguments must have the same length.", "a");
			}
			if (ipiv.Length != order)
			{
				throw new ArgumentException("The array arguments must have the same length.", "ipiv");
			}
			if (b.Length != order * columnsOfB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			if (a == b)
			{
				throw new ArgumentException("Arguments must be different objects.");
			}
			for (int i = 0; i < ipiv.Length; i++)
			{
				if (ipiv[i] != i)
				{
					int num = ipiv[i];
					for (int j = 0; j < columnsOfB; j++)
					{
						int num2 = j * order;
						int num3 = num2 + num;
						int num4 = num2 + i;
						ref Complex reference = ref b[num3];
						ref Complex reference2 = ref b[num4];
						Complex complex = b[num4];
						Complex complex2 = b[num3];
						reference = complex;
						reference2 = complex2;
					}
				}
			}
			for (int k = 0; k < order; k++)
			{
				int num5 = k * order;
				for (int l = k + 1; l < order; l++)
				{
					for (int m = 0; m < columnsOfB; m++)
					{
						int num6 = m * order;
						b[l + num6] -= b[k + num6] * a[l + num5];
					}
				}
			}
			for (int num7 = order - 1; num7 >= 0; num7--)
			{
				int num8 = num7 + num7 * order;
				for (int n = 0; n < columnsOfB; n++)
				{
					b[num7 + n * order] /= a[num8];
				}
				num8 = num7 * order;
				for (int num9 = 0; num9 < num7; num9++)
				{
					for (int num10 = 0; num10 < columnsOfB; num10++)
					{
						int num11 = num10 * order;
						b[num9 + num11] -= b[num7 + num11] * a[num9 + num8];
					}
				}
			}
		}

		public void CholeskyFactor(Complex[] a, int order)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			Complex[] array = new Complex[order];
			for (int i = 0; i < order; i++)
			{
				Complex complex = a[i * order + i];
				if (!(complex.Real > 0.0))
				{
					throw new ArgumentException("Matrix must be positive definite.");
				}
				complex = (array[i] = (a[i * order + i] = complex.SquareRoot()));
				for (int j = i + 1; j < order; j++)
				{
					a[i * order + j] /= complex;
					array[j] = a[i * order + j];
				}
				DoCholeskyStep(a, order, i + 1, order, array, Control.MaxDegreeOfParallelism);
				for (int k = i + 1; k < order; k++)
				{
					a[k * order + i] = 0.0;
				}
			}
		}

		private static void DoCholeskyStep(Complex[] data, int rowDim, int firstCol, int colLimit, Complex[] multipliers, int availableCores)
		{
			int num = colLimit - firstCol;
			if (availableCores > 1 && num > Control.ParallelizeElements)
			{
				int tmpSplit = firstCol + num / 3;
				int tmpCores = availableCores / 2;
				CommonParallel.Invoke(delegate
				{
					DoCholeskyStep(data, rowDim, firstCol, tmpSplit, multipliers, tmpCores);
				}, delegate
				{
					DoCholeskyStep(data, rowDim, tmpSplit, colLimit, multipliers, tmpCores);
				});
				return;
			}
			for (int num2 = firstCol; num2 < colLimit; num2++)
			{
				Complex complex = multipliers[num2];
				for (int num3 = num2; num3 < rowDim; num3++)
				{
					data[num2 * rowDim + num3] -= multipliers[num3] * complex.Conjugate();
				}
			}
		}

		public void CholeskySolve(Complex[] a, int orderA, Complex[] b, int columnsB)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (b.Length != orderA * columnsB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			if (a == b)
			{
				throw new ArgumentException("Arguments must be different objects.");
			}
			Complex[] array = new Complex[a.Length];
			a.Copy(array);
			CholeskyFactor(array, orderA);
			CholeskySolveFactored(array, orderA, b, columnsB);
		}

		public void CholeskySolveFactored(Complex[] a, int orderA, Complex[] b, int columnsB)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (b.Length != orderA * columnsB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			if (a == b)
			{
				throw new ArgumentException("Arguments must be different objects.");
			}
			CommonParallel.For(0, columnsB, delegate(int u, int v)
			{
				for (int i = u; i < v; i++)
				{
					DoCholeskySolve(a, orderA, b, i);
				}
			});
		}

		private static void DoCholeskySolve(Complex[] a, int orderA, Complex[] b, int index)
		{
			int num = index * orderA;
			for (int i = 0; i < orderA; i++)
			{
				Complex complex = b[num + i];
				for (int num2 = i - 1; num2 >= 0; num2--)
				{
					complex -= a[num2 * orderA + i] * b[num + num2];
				}
				b[num + i] = complex / a[i * orderA + i];
			}
			for (int num3 = orderA - 1; num3 >= 0; num3--)
			{
				Complex complex = b[num + num3];
				int num4 = num3 * orderA;
				for (int j = num3 + 1; j < orderA; j++)
				{
					complex -= a[num4 + j].Conjugate() * b[num + j];
				}
				b[num + num3] = complex / a[num4 + num3];
			}
		}

		public void QRFactor(Complex[] r, int rowsR, int columnsR, Complex[] q, Complex[] tau)
		{
			if (r == null)
			{
				throw new ArgumentNullException("r");
			}
			if (q == null)
			{
				throw new ArgumentNullException("q");
			}
			if (r.Length != rowsR * columnsR)
			{
				throw new ArgumentException("The given array has the wrong length. Should be rowsR * columnsR.", "r");
			}
			if (tau.Length < Math.Min(rowsR, columnsR))
			{
				throw new ArgumentException("The given array is too small. It must be at least min(m,n) long.", "tau");
			}
			if (q.Length != rowsR * rowsR)
			{
				throw new ArgumentException("The given array has the wrong length. Should be rowsR * rowsR.", "q");
			}
			Complex[] work = ((columnsR > rowsR) ? new Complex[rowsR * rowsR] : new Complex[rowsR * columnsR]);
			CommonParallel.For(0, rowsR, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					q[i * rowsR + i] = Complex.One;
				}
			});
			int num = Math.Min(rowsR, columnsR);
			for (int num2 = 0; num2 < num; num2++)
			{
				GenerateColumn(work, r, rowsR, num2, num2);
				ComputeQR(work, num2, r, num2, rowsR, num2 + 1, columnsR, Control.MaxDegreeOfParallelism);
			}
			for (int num3 = num - 1; num3 >= 0; num3--)
			{
				ComputeQR(work, num3, q, num3, rowsR, num3, rowsR, Control.MaxDegreeOfParallelism);
			}
		}

		public void ThinQRFactor(Complex[] a, int rowsA, int columnsA, Complex[] r, Complex[] tau)
		{
			if (r == null)
			{
				throw new ArgumentNullException("r");
			}
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (a.Length != rowsA * columnsA)
			{
				throw new ArgumentException("The given array has the wrong length. Should be rowsR * columnsR.", "a");
			}
			if (tau.Length < Math.Min(rowsA, columnsA))
			{
				throw new ArgumentException("The given array is too small. It must be at least min(m,n) long.", "tau");
			}
			if (r.Length != columnsA * columnsA)
			{
				throw new ArgumentException("The given array has the wrong length. Should be columnsA * columnsA.", "r");
			}
			Complex[] work = new Complex[rowsA * columnsA];
			int num = Math.Min(rowsA, columnsA);
			for (int i = 0; i < num; i++)
			{
				GenerateColumn(work, a, rowsA, i, i);
				ComputeQR(work, i, a, i, rowsA, i + 1, columnsA, Control.MaxDegreeOfParallelism);
			}
			for (int j = 0; j < columnsA; j++)
			{
				int num2 = j * columnsA;
				int num3 = j * rowsA;
				for (int k = 0; k < columnsA; k++)
				{
					r[num2 + k] = a[num3 + k];
				}
			}
			Array.Clear(a, 0, a.Length);
			for (int l = 0; l < columnsA; l++)
			{
				a[l * rowsA + l] = Complex.One;
			}
			for (int num4 = num - 1; num4 >= 0; num4--)
			{
				ComputeQR(work, num4, a, num4, rowsA, num4, columnsA, Control.MaxDegreeOfParallelism);
			}
		}

		private static void ComputeQR(Complex[] work, int workIndex, Complex[] a, int rowStart, int rowCount, int columnStart, int columnCount, int availableCores)
		{
			if (rowStart > rowCount || columnStart > columnCount)
			{
				return;
			}
			int num = columnCount - columnStart;
			if (availableCores > 1 && num > 200)
			{
				int tmpSplit = columnStart + num / 2;
				int tmpCores = availableCores / 2;
				CommonParallel.Invoke(delegate
				{
					ComputeQR(work, workIndex, a, rowStart, rowCount, columnStart, tmpSplit, tmpCores);
				}, delegate
				{
					ComputeQR(work, workIndex, a, rowStart, rowCount, tmpSplit, columnCount, tmpCores);
				});
				return;
			}
			for (int num2 = columnStart; num2 < columnCount; num2++)
			{
				Complex zero = Complex.Zero;
				for (int num3 = rowStart; num3 < rowCount; num3++)
				{
					zero += work[workIndex * rowCount + num3 - rowStart] * a[num2 * rowCount + num3];
				}
				for (int num4 = rowStart; num4 < rowCount; num4++)
				{
					a[num2 * rowCount + num4] -= work[workIndex * rowCount + num4 - rowStart].Conjugate() * zero;
				}
			}
		}

		private static void GenerateColumn(Complex[] work, Complex[] a, int rowCount, int row, int column)
		{
			int tmp = column * rowCount;
			int num = tmp + row;
			CommonParallel.For(row, rowCount, delegate(int u, int v)
			{
				for (int i = u; i < v; i++)
				{
					int num4 = tmp + i;
					work[num4 - row] = a[num4];
					a[num4] = Complex.Zero;
				}
			});
			Complex norm = Complex.Zero;
			for (int num2 = 0; num2 < rowCount - row; num2++)
			{
				int num3 = tmp + num2;
				norm += (Complex)(work[num3].Magnitude * work[num3].Magnitude);
			}
			norm = norm.SquareRoot();
			if (row == rowCount - 1 || norm.Magnitude == 0.0)
			{
				a[num] = -work[tmp];
				work[tmp] = new Complex(2.0, 0.0).SquareRoot();
				return;
			}
			if (work[tmp].Magnitude != 0.0)
			{
				norm = norm.Magnitude * (work[tmp] / work[tmp].Magnitude);
			}
			a[num] = -norm;
			CommonParallel.For(0, rowCount - row, 4096, delegate(int u, int v)
			{
				for (int i = u; i < v; i++)
				{
					work[tmp + i] /= norm;
				}
			});
			work[tmp] += (Complex)1.0;
			Complex s = (1.0 / work[tmp]).SquareRoot();
			CommonParallel.For(0, rowCount - row, 4096, delegate(int u, int v)
			{
				for (int i = u; i < v; i++)
				{
					work[tmp + i] = work[tmp + i].Conjugate() * s;
				}
			});
		}

		public void QRSolve(Complex[] a, int rows, int columns, Complex[] b, int columnsB, Complex[] x, QRMethod method = QRMethod.Full)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (a.Length != rows * columns)
			{
				throw new ArgumentException("The array arguments must have the same length.", "a");
			}
			if (b.Length != rows * columnsB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			if (rows < columns)
			{
				throw new ArgumentException("The number of rows must greater than or equal to the number of columns.");
			}
			if (x.Length != columns * columnsB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "x");
			}
			Complex[] tau = new Complex[rows * columns];
			Complex[] array = new Complex[a.Length];
			a.Copy(array);
			if (method == QRMethod.Full)
			{
				Complex[] q = new Complex[rows * rows];
				QRFactor(array, rows, columns, q, tau);
				QRSolveFactored(q, array, rows, columns, null, b, columnsB, x, method);
			}
			else
			{
				Complex[] r = new Complex[columns * columns];
				ThinQRFactor(array, rows, columns, r, tau);
				QRSolveFactored(array, r, rows, columns, null, b, columnsB, x, method);
			}
		}

		public void QRSolveFactored(Complex[] q, Complex[] r, int rowsA, int columnsA, Complex[] tau, Complex[] b, int columnsB, Complex[] x, QRMethod method = QRMethod.Full)
		{
			if (r == null)
			{
				throw new ArgumentNullException("r");
			}
			if (q == null)
			{
				throw new ArgumentNullException("q");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (rowsA < columnsA)
			{
				throw new ArgumentException("The number of rows must greater than or equal to the number of columns.");
			}
			int num;
			int num2;
			int num3;
			int num4;
			if (method == QRMethod.Full)
			{
				num = (num2 = (num3 = rowsA));
				num4 = columnsA;
			}
			else
			{
				num = rowsA;
				num2 = (num3 = (num4 = columnsA));
			}
			if (r.Length != num3 * num4)
			{
				throw new ArgumentException($"The given array has the wrong length. Should be {num3 * num4}.", "r");
			}
			if (q.Length != num * num2)
			{
				throw new ArgumentException($"The given array has the wrong length. Should be {num * num2}.", "q");
			}
			if (b.Length != rowsA * columnsB)
			{
				throw new ArgumentException($"The given array has the wrong length. Should be {rowsA * columnsB}.", "b");
			}
			if (x.Length != columnsA * columnsB)
			{
				throw new ArgumentException($"The given array has the wrong length. Should be {columnsA * columnsB}.", "x");
			}
			Complex[] sol = new Complex[b.Length];
			Array.Copy(b, 0, sol, 0, b.Length);
			Complex[] column = new Complex[rowsA];
			for (int i = 0; i < columnsB; i++)
			{
				int jm = i * rowsA;
				Array.Copy(sol, jm, column, 0, rowsA);
				CommonParallel.For(0, columnsA, delegate(int u, int v)
				{
					for (int j = u; j < v; j++)
					{
						int num12 = j * rowsA;
						Complex zero = Complex.Zero;
						for (int k = 0; k < rowsA; k++)
						{
							zero += q[num12 + k].Conjugate() * column[k];
						}
						sol[jm + j] = zero;
					}
				});
			}
			for (int num5 = columnsA - 1; num5 >= 0; num5--)
			{
				int num6 = num5 * num3;
				for (int num7 = 0; num7 < columnsB; num7++)
				{
					sol[num7 * rowsA + num5] /= r[num6 + num5];
				}
				for (int num8 = 0; num8 < num5; num8++)
				{
					for (int num9 = 0; num9 < columnsB; num9++)
					{
						int num10 = num9 * rowsA;
						sol[num10 + num8] -= sol[num10 + num5] * r[num6 + num8];
					}
				}
			}
			for (int num11 = 0; num11 < columnsB; num11++)
			{
				Array.Copy(sol, num11 * rowsA, x, num11 * columnsA, num4);
			}
		}

		public void SingularValueDecomposition(bool computeVectors, Complex[] a, int rowsA, int columnsA, Complex[] s, Complex[] u, Complex[] vt)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			if (u == null)
			{
				throw new ArgumentNullException("u");
			}
			if (vt == null)
			{
				throw new ArgumentNullException("vt");
			}
			if (u.Length != rowsA * rowsA)
			{
				throw new ArgumentException("The array arguments must have the same length.", "u");
			}
			if (vt.Length != columnsA * columnsA)
			{
				throw new ArgumentException("The array arguments must have the same length.", "vt");
			}
			if (s.Length != Math.Min(rowsA, columnsA))
			{
				throw new ArgumentException("The array arguments must have the same length.", "s");
			}
			Complex[] array = new Complex[rowsA];
			Complex[] array2 = new Complex[columnsA];
			Complex[] array3 = new Complex[vt.Length];
			Complex[] array4 = new Complex[Math.Min(rowsA + 1, columnsA)];
			int num = Math.Min(rowsA - 1, columnsA);
			int num2 = Math.Max(0, Math.Min(columnsA - 2, rowsA));
			int num3 = Math.Max(num, num2);
			for (int i = 0; i < num3; i++)
			{
				int num4 = i + 1;
				if (i < num)
				{
					double num5 = 0.0;
					for (int j = i; j < rowsA; j++)
					{
						num5 += a[i * rowsA + j].Magnitude * a[i * rowsA + j].Magnitude;
					}
					array4[i] = Math.Sqrt(num5);
					if (array4[i] != 0.0)
					{
						if (a[i * rowsA + i] != 0.0)
						{
							array4[i] = array4[i].Magnitude * (a[i * rowsA + i] / a[i * rowsA + i].Magnitude);
						}
						for (int j = i; j < rowsA; j++)
						{
							a[i * rowsA + j] *= 1.0 / array4[i];
						}
						a[i * rowsA + i] = 1.0 + a[i * rowsA + i];
					}
					array4[i] = -array4[i];
				}
				for (int k = num4; k < columnsA; k++)
				{
					if (i < num && array4[i] != 0.0)
					{
						Complex complex = 0.0;
						for (int j = i; j < rowsA; j++)
						{
							complex += a[i * rowsA + j].Conjugate() * a[k * rowsA + j];
						}
						complex = -complex / a[i * rowsA + i];
						for (int l = i; l < rowsA; l++)
						{
							a[k * rowsA + l] += complex * a[i * rowsA + l];
						}
					}
					array2[k] = a[k * rowsA + i].Conjugate();
				}
				if (computeVectors && i < num)
				{
					for (int j = i; j < rowsA; j++)
					{
						u[i * rowsA + j] = a[i * rowsA + j];
					}
				}
				if (i >= num2)
				{
					continue;
				}
				double num6 = 0.0;
				for (int j = num4; j < array2.Length; j++)
				{
					num6 += array2[j].Magnitude * array2[j].Magnitude;
				}
				array2[i] = Math.Sqrt(num6);
				if (array2[i] != 0.0)
				{
					if (array2[num4] != 0.0)
					{
						array2[i] = array2[i].Magnitude * (array2[num4] / array2[num4].Magnitude);
					}
					for (int j = num4; j < array2.Length; j++)
					{
						array2[j] *= 1.0 / array2[i];
					}
					array2[num4] = 1.0 + array2[num4];
				}
				array2[i] = -array2[i].Conjugate();
				if (num4 < rowsA && array2[i] != 0.0)
				{
					for (int j = num4; j < rowsA; j++)
					{
						array[j] = 0.0;
					}
					for (int k = num4; k < columnsA; k++)
					{
						for (int m = num4; m < rowsA; m++)
						{
							array[m] += array2[k] * a[k * rowsA + m];
						}
					}
					for (int k = num4; k < columnsA; k++)
					{
						Complex complex2 = (-array2[k] / array2[num4]).Conjugate();
						for (int n = num4; n < rowsA; n++)
						{
							a[k * rowsA + n] += complex2 * array[n];
						}
					}
				}
				if (computeVectors)
				{
					for (int j = num4; j < columnsA; j++)
					{
						array3[i * columnsA + j] = array2[j];
					}
				}
			}
			int num7 = Math.Min(columnsA, rowsA + 1);
			int num8 = num + 1;
			int num9 = num2 + 1;
			if (num < columnsA)
			{
				array4[num8 - 1] = a[(num8 - 1) * rowsA + (num8 - 1)];
			}
			if (rowsA < num7)
			{
				array4[num7 - 1] = 0.0;
			}
			if (num9 < num7)
			{
				array2[num9 - 1] = a[(num7 - 1) * rowsA + (num9 - 1)];
			}
			array2[num7 - 1] = 0.0;
			if (computeVectors)
			{
				for (int k = num8 - 1; k < rowsA; k++)
				{
					for (int j = 0; j < rowsA; j++)
					{
						u[k * rowsA + j] = 0.0;
					}
					u[k * rowsA + k] = 1.0;
				}
				for (int i = num - 1; i >= 0; i--)
				{
					if (array4[i] != 0.0)
					{
						for (int k = i + 1; k < rowsA; k++)
						{
							Complex complex = 0.0;
							for (int j = i; j < rowsA; j++)
							{
								complex += u[i * rowsA + j].Conjugate() * u[k * rowsA + j];
							}
							complex = -complex / u[i * rowsA + i];
							for (int num10 = i; num10 < rowsA; num10++)
							{
								u[k * rowsA + num10] += complex * u[i * rowsA + num10];
							}
						}
						for (int j = i; j < rowsA; j++)
						{
							u[i * rowsA + j] *= (Complex)(-1.0);
						}
						u[i * rowsA + i] = 1.0 + u[i * rowsA + i];
						for (int j = 0; j < i; j++)
						{
							u[i * rowsA + j] = 0.0;
						}
					}
					else
					{
						for (int j = 0; j < rowsA; j++)
						{
							u[i * rowsA + j] = 0.0;
						}
						u[i * rowsA + i] = 1.0;
					}
				}
			}
			if (computeVectors)
			{
				for (int i = columnsA - 1; i >= 0; i--)
				{
					int num4 = i + 1;
					if (i < num2 && array2[i] != 0.0)
					{
						for (int k = num4; k < columnsA; k++)
						{
							Complex complex = 0.0;
							for (int j = num4; j < columnsA; j++)
							{
								complex += array3[i * columnsA + j].Conjugate() * array3[k * columnsA + j];
							}
							complex = -complex / array3[i * columnsA + num4];
							for (int num11 = i; num11 < columnsA; num11++)
							{
								array3[k * columnsA + num11] += complex * array3[i * columnsA + num11];
							}
						}
					}
					for (int j = 0; j < columnsA; j++)
					{
						array3[i * columnsA + j] = 0.0;
					}
					array3[i * columnsA + i] = 1.0;
				}
			}
			for (int j = 0; j < num7; j++)
			{
				Complex complex;
				Complex complex3;
				if (array4[j] != 0.0)
				{
					complex = array4[j].Magnitude;
					complex3 = array4[j] / complex;
					array4[j] = complex;
					if (j < num7 - 1)
					{
						array2[j] /= complex3;
					}
					if (computeVectors)
					{
						for (int k = 0; k < rowsA; k++)
						{
							u[j * rowsA + k] *= complex3;
						}
					}
				}
				if (j == num7 - 1)
				{
					break;
				}
				if (array2[j] == 0.0)
				{
					continue;
				}
				complex = array2[j].Magnitude;
				complex3 = complex / array2[j];
				array2[j] = complex;
				array4[j + 1] *= complex3;
				if (computeVectors)
				{
					for (int k = 0; k < columnsA; k++)
					{
						array3[(j + 1) * columnsA + k] *= complex3;
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
					double num14 = array4[i].Magnitude + array4[i + 1].Magnitude;
					if ((num14 + array2[i].Magnitude).AlmostEqualRelative(num14, 15))
					{
						array2[i] = 0.0;
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
							num14 += array2[num16].Magnitude;
						}
						if (num16 != i + 1)
						{
							num14 += array2[num16 - 1].Magnitude;
						}
						if ((num14 + array4[num16].Magnitude).AlmostEqualRelative(num14, 15))
						{
							array4[num16] = 0.0;
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
				double s2;
				switch (num15)
				{
				case 1:
				{
					double db = array2[num7 - 2].Real;
					array2[num7 - 2] = 0.0;
					for (int num26 = i; num26 < num7 - 1; num26++)
					{
						int num17 = num7 - 2 - num26 + i;
						double da = array4[num17].Real;
						Drotg(ref da, ref db, out c, out s2);
						array4[num17] = da;
						if (num17 != i)
						{
							db = (0.0 - s2) * array2[num17 - 1].Real;
							array2[num17 - 1] = c * array2[num17 - 1];
						}
						if (computeVectors)
						{
							for (int j = 0; j < columnsA; j++)
							{
								Complex complex9 = c * array3[num17 * columnsA + j] + s2 * array3[(num7 - 1) * columnsA + j];
								array3[(num7 - 1) * columnsA + j] = c * array3[(num7 - 1) * columnsA + j] - s2 * array3[num17 * columnsA + j];
								array3[num17 * columnsA + j] = complex9;
							}
						}
					}
					break;
				}
				case 2:
				{
					double db = array2[i - 1].Real;
					array2[i - 1] = 0.0;
					for (int num17 = i; num17 < num7; num17++)
					{
						double da = array4[num17].Real;
						Drotg(ref da, ref db, out c, out s2);
						array4[num17] = da;
						db = (0.0 - s2) * array2[num17].Real;
						array2[num17] = c * array2[num17];
						if (computeVectors)
						{
							for (int j = 0; j < rowsA; j++)
							{
								Complex complex6 = c * u[num17 * rowsA + j] + s2 * u[(i - 1) * rowsA + j];
								u[(i - 1) * rowsA + j] = c * u[(i - 1) * rowsA + j] - s2 * u[num17 * rowsA + j];
								u[num17 * rowsA + j] = complex6;
							}
						}
					}
					break;
				}
				case 3:
				{
					double val = 0.0;
					val = Math.Max(val, array4[num7 - 1].Magnitude);
					val = Math.Max(val, array4[num7 - 2].Magnitude);
					val = Math.Max(val, array2[num7 - 2].Magnitude);
					val = Math.Max(val, array4[i].Magnitude);
					val = Math.Max(val, array2[i].Magnitude);
					double num18 = array4[num7 - 1].Real / val;
					double num19 = array4[num7 - 2].Real / val;
					double num20 = array2[num7 - 2].Real / val;
					double num21 = array4[i].Real / val;
					double num22 = array2[i].Real / val;
					double num23 = ((num19 + num18) * (num19 - num18) + num20 * num20) / 2.0;
					double num24 = num18 * num20 * (num18 * num20);
					double num25 = 0.0;
					if (num23 != 0.0 || num24 != 0.0)
					{
						num25 = Math.Sqrt(num23 * num23 + num24);
						if (num23 < 0.0)
						{
							num25 = 0.0 - num25;
						}
						num25 = num24 / (num23 + num25);
					}
					double db = (num21 + num18) * (num21 - num18) + num25;
					double db2 = num21 * num22;
					for (int num17 = i; num17 < num7 - 1; num17++)
					{
						Drotg(ref db, ref db2, out c, out s2);
						if (num17 != i)
						{
							array2[num17 - 1] = db;
						}
						db = c * array4[num17].Real + s2 * array2[num17].Real;
						array2[num17] = c * array2[num17] - s2 * array4[num17];
						db2 = s2 * array4[num17 + 1].Real;
						array4[num17 + 1] = c * array4[num17 + 1];
						if (computeVectors)
						{
							for (int j = 0; j < columnsA; j++)
							{
								Complex complex7 = c * array3[num17 * columnsA + j] + s2 * array3[(num17 + 1) * columnsA + j];
								array3[(num17 + 1) * columnsA + j] = c * array3[(num17 + 1) * columnsA + j] - s2 * array3[num17 * columnsA + j];
								array3[num17 * columnsA + j] = complex7;
							}
						}
						Drotg(ref db, ref db2, out c, out s2);
						array4[num17] = db;
						db = c * array2[num17].Real + s2 * array4[num17 + 1].Real;
						array4[num17 + 1] = -(s2 * array2[num17]) + c * array4[num17 + 1];
						db2 = s2 * array2[num17 + 1].Real;
						array2[num17 + 1] = c * array2[num17 + 1];
						if (computeVectors && num17 < rowsA)
						{
							for (int j = 0; j < rowsA; j++)
							{
								Complex complex8 = c * u[num17 * rowsA + j] + s2 * u[(num17 + 1) * rowsA + j];
								u[(num17 + 1) * rowsA + j] = c * u[(num17 + 1) * rowsA + j] - s2 * u[num17 * rowsA + j];
								u[num17 * rowsA + j] = complex8;
							}
						}
					}
					array2[num7 - 2] = db;
					num13++;
					break;
				}
				case 4:
					if (array4[i].Real < 0.0)
					{
						array4[i] = -array4[i];
						if (computeVectors)
						{
							for (int j = 0; j < columnsA; j++)
							{
								array3[i * columnsA + j] *= (Complex)(-1.0);
							}
						}
					}
					for (; i != num12 - 1 && !(array4[i].Real >= array4[i + 1].Real); i++)
					{
						Complex complex = array4[i];
						array4[i] = array4[i + 1];
						array4[i + 1] = complex;
						if (computeVectors && i < columnsA)
						{
							for (int j = 0; j < columnsA; j++)
							{
								ref Complex reference = ref array3[i * columnsA + j];
								ref Complex reference2 = ref array3[(i + 1) * columnsA + j];
								Complex complex4 = array3[(i + 1) * columnsA + j];
								Complex complex5 = array3[i * columnsA + j];
								reference = complex4;
								reference2 = complex5;
							}
						}
						if (computeVectors && i < rowsA)
						{
							for (int j = 0; j < rowsA; j++)
							{
								ref Complex reference = ref u[i * rowsA + j];
								ref Complex reference3 = ref u[(i + 1) * rowsA + j];
								Complex complex5 = u[(i + 1) * rowsA + j];
								Complex complex4 = u[i * rowsA + j];
								reference = complex5;
								reference3 = complex4;
							}
						}
					}
					num13 = 0;
					num7--;
					break;
				}
			}
			if (computeVectors)
			{
				for (int j = 0; j < columnsA; j++)
				{
					for (int k = 0; k < columnsA; k++)
					{
						vt[k * columnsA + j] = array3[j * columnsA + k].Conjugate();
					}
				}
			}
			Array.Copy(array4, 0, s, 0, Math.Min(rowsA, columnsA));
		}

		public void SvdSolve(Complex[] a, int rowsA, int columnsA, Complex[] b, int columnsB, Complex[] x)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (b.Length != rowsA * columnsB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			if (x.Length != columnsA * columnsB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			Complex[] s = new Complex[Math.Min(rowsA, columnsA)];
			Complex[] u = new Complex[rowsA * rowsA];
			Complex[] vt = new Complex[columnsA * columnsA];
			Complex[] array = new Complex[a.Length];
			a.Copy(array);
			SingularValueDecomposition(computeVectors: true, array, rowsA, columnsA, s, u, vt);
			SvdSolveFactored(rowsA, columnsA, s, u, vt, b, columnsB, x);
		}

		public void SvdSolveFactored(int rowsA, int columnsA, Complex[] s, Complex[] u, Complex[] vt, Complex[] b, int columnsB, Complex[] x)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			if (u == null)
			{
				throw new ArgumentNullException("u");
			}
			if (vt == null)
			{
				throw new ArgumentNullException("vt");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (u.Length != rowsA * rowsA)
			{
				throw new ArgumentException("The array arguments must have the same length.", "u");
			}
			if (vt.Length != columnsA * columnsA)
			{
				throw new ArgumentException("The array arguments must have the same length.", "vt");
			}
			if (s.Length != Math.Min(rowsA, columnsA))
			{
				throw new ArgumentException("The array arguments must have the same length.", "s");
			}
			if (b.Length != rowsA * columnsB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			if (x.Length != columnsA * columnsB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			int num = Math.Min(rowsA, columnsA);
			Complex[] array = new Complex[columnsA];
			for (int i = 0; i < columnsB; i++)
			{
				for (int j = 0; j < columnsA; j++)
				{
					Complex zero = Complex.Zero;
					if (j < num)
					{
						for (int k = 0; k < rowsA; k++)
						{
							zero += u[j * rowsA + k].Conjugate() * b[i * rowsA + k];
						}
						zero /= s[j];
					}
					array[j] = zero;
				}
				for (int l = 0; l < columnsA; l++)
				{
					Complex zero2 = Complex.Zero;
					for (int m = 0; m < columnsA; m++)
					{
						zero2 += vt[l * columnsA + m].Conjugate() * array[m];
					}
					x[i * columnsA + l] = zero2;
				}
			}
		}

		public void EigenDecomp(bool isSymmetric, int order, Complex[] matrix, Complex[] matrixEv, Complex[] vectorEv, Complex[] matrixD)
		{
			if (matrix == null)
			{
				throw new ArgumentNullException("matrix");
			}
			if (matrix.Length != order * order)
			{
				throw new ArgumentException($"The given array has the wrong length. Should be {order * order}.", "matrix");
			}
			if (matrixEv == null)
			{
				throw new ArgumentNullException("matrixEv");
			}
			if (matrixEv.Length != order * order)
			{
				throw new ArgumentException($"The given array has the wrong length. Should be {order * order}.", "matrixEv");
			}
			if (vectorEv == null)
			{
				throw new ArgumentNullException("vectorEv");
			}
			if (vectorEv.Length != order)
			{
				throw new ArgumentException($"The given array has the wrong length. Should be {order}.", "vectorEv");
			}
			if (matrixD == null)
			{
				throw new ArgumentNullException("matrixD");
			}
			if (matrixD.Length != order * order)
			{
				throw new ArgumentException($"The given array has the wrong length. Should be {order * order}.", "matrixD");
			}
			Complex[] array = new Complex[matrix.Length];
			Array.Copy(matrix, 0, array, 0, matrix.Length);
			if (isSymmetric)
			{
				Complex[] tau = new Complex[order];
				double[] array2 = new double[order];
				double[] array3 = new double[order];
				SymmetricTridiagonalize(array, array2, array3, tau, order);
				SymmetricDiagonalize(matrixEv, array2, array3, order);
				SymmetricUntridiagonalize(matrixEv, array, tau, order);
				for (int i = 0; i < order; i++)
				{
					vectorEv[i] = new Complex(array2[i], array3[i]);
				}
			}
			else
			{
				NonsymmetricReduceToHessenberg(matrixEv, array, order);
				NonsymmetricReduceHessenberToRealSchur(vectorEv, matrixEv, array, order);
			}
			for (int j = 0; j < order; j++)
			{
				matrixD[j * order + j] = vectorEv[j];
			}
		}

		internal static void SymmetricTridiagonalize(Complex[] matrixA, double[] d, double[] e, Complex[] tau, int order)
		{
			tau[order - 1] = Complex.One;
			for (int i = 0; i < order; i++)
			{
				d[i] = matrixA[i * order + i].Real;
			}
			double num6;
			for (int num = order - 1; num > 0; num--)
			{
				double num2 = 0.0;
				double num3 = 0.0;
				for (int j = 0; j < num; j++)
				{
					num2 = num2 + Math.Abs(matrixA[j * order + num].Real) + Math.Abs(matrixA[j * order + num].Imaginary);
				}
				if (num2 == 0.0)
				{
					tau[num - 1] = Complex.One;
					e[num] = 0.0;
				}
				else
				{
					for (int k = 0; k < num; k++)
					{
						matrixA[k * order + num] /= (Complex)num2;
						num3 += matrixA[k * order + num].MagnitudeSquared();
					}
					Complex complex = Math.Sqrt(num3);
					e[num] = num2 * complex.Real;
					int num4 = (num - 1) * order + num;
					Complex complex2 = matrixA[num4];
					Complex complex3;
					if (complex2.Magnitude != 0.0)
					{
						complex3 = -(matrixA[num4].Conjugate() * tau[num].Conjugate()) / complex2.Magnitude;
						num3 += complex2.Magnitude * complex.Real;
						complex = 1.0 + complex / complex2.Magnitude;
						matrixA[num4] *= complex;
					}
					else
					{
						complex3 = -tau[num].Conjugate();
						matrixA[num4] = complex;
					}
					if (complex2.Magnitude == 0.0 || num != 1)
					{
						complex2 = Complex.Zero;
						for (int l = 0; l < num; l++)
						{
							Complex zero = Complex.Zero;
							int num5 = l * order;
							for (int m = 0; m <= l; m++)
							{
								zero += matrixA[m * order + l] * matrixA[m * order + num].Conjugate();
							}
							for (int n = l + 1; n <= num - 1; n++)
							{
								zero += matrixA[num5 + n].Conjugate() * matrixA[n * order + num].Conjugate();
							}
							tau[l] = zero / num3;
							complex2 += zero / num3 * matrixA[num5 + num];
						}
						num6 = complex2.Real / (num3 + num3);
						for (int num7 = 0; num7 < num; num7++)
						{
							complex2 = matrixA[num7 * order + num].Conjugate();
							complex = tau[num7] - num6 * complex2;
							tau[num7] = complex.Conjugate();
							for (int num8 = 0; num8 <= num7; num8++)
							{
								matrixA[num8 * order + num7] -= complex2 * tau[num8] + complex * matrixA[num8 * order + num];
							}
						}
					}
					for (int num9 = 0; num9 < num; num9++)
					{
						matrixA[num9 * order + num] *= (Complex)num2;
					}
					tau[num - 1] = complex3.Conjugate();
				}
				num6 = d[num];
				d[num] = matrixA[num * order + num].Real;
				matrixA[num * order + num] = new Complex(num6, num2 * Math.Sqrt(num3));
			}
			num6 = d[0];
			d[0] = matrixA[0].Real;
			matrixA[0] = num6;
			e[0] = 0.0;
		}

		internal static void SymmetricDiagonalize(Complex[] dataEv, double[] d, double[] e, int order)
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
								num8 = dataEv[(num15 + 1) * order + m].Real;
								dataEv[(num15 + 1) * order + m] = num13 * dataEv[num15 * order + m].Real + num9 * num8;
								dataEv[num15 * order + m] = num9 * dataEv[num15 * order + m].Real - num13 * num8;
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
						num17 = dataEv[n * order + num19].Real;
						dataEv[n * order + num19] = dataEv[num16 * order + num19];
						dataEv[num16 * order + num19] = num17;
					}
				}
			}
		}

		internal static void SymmetricUntridiagonalize(Complex[] dataEv, Complex[] matrixA, Complex[] tau, int order)
		{
			for (int i = 0; i < order; i++)
			{
				for (int j = 0; j < order; j++)
				{
					dataEv[j * order + i] = dataEv[j * order + i].Real * tau[i].Conjugate();
				}
			}
			for (int k = 1; k < order; k++)
			{
				double imaginary = matrixA[k * order + k].Imaginary;
				if (imaginary == 0.0)
				{
					continue;
				}
				for (int l = 0; l < order; l++)
				{
					Complex zero = Complex.Zero;
					for (int m = 0; m < k; m++)
					{
						zero += dataEv[l * order + m] * matrixA[m * order + k];
					}
					zero = zero / imaginary / imaginary;
					for (int n = 0; n < k; n++)
					{
						dataEv[l * order + n] -= zero * matrixA[n * order + k].Conjugate();
					}
				}
			}
		}

		internal static void NonsymmetricReduceToHessenberg(Complex[] dataEv, Complex[] matrixH, int order)
		{
			Complex[] array = new Complex[order];
			for (int i = 1; i < order - 1; i++)
			{
				double num = 0.0;
				int num2 = (i - 1) * order;
				for (int j = i; j < order; j++)
				{
					num += Math.Abs(matrixH[num2 + j].Real) + Math.Abs(matrixH[num2 + j].Imaginary);
				}
				if (num == 0.0)
				{
					continue;
				}
				double num3 = 0.0;
				for (int num4 = order - 1; num4 >= i; num4--)
				{
					array[num4] = matrixH[num2 + num4] / num;
					num3 += array[num4].MagnitudeSquared();
				}
				double num5 = Math.Sqrt(num3);
				if (array[i].Magnitude != 0.0)
				{
					num3 += array[i].Magnitude * num5;
					num5 /= array[i].Magnitude;
					array[i] = (1.0 + num5) * array[i];
				}
				else
				{
					array[i] = num5;
					matrixH[num2 + i] = num;
				}
				for (int k = i; k < order; k++)
				{
					Complex zero = Complex.Zero;
					int num6 = k * order;
					for (int num7 = order - 1; num7 >= i; num7--)
					{
						zero += array[num7].Conjugate() * matrixH[num6 + num7];
					}
					zero /= (Complex)num3;
					for (int l = i; l < order; l++)
					{
						matrixH[num6 + l] -= zero * array[l];
					}
				}
				for (int m = 0; m < order; m++)
				{
					Complex zero2 = Complex.Zero;
					for (int num8 = order - 1; num8 >= i; num8--)
					{
						zero2 += array[num8] * matrixH[num8 * order + m];
					}
					zero2 /= (Complex)num3;
					for (int n = i; n < order; n++)
					{
						matrixH[n * order + m] -= zero2 * array[n].Conjugate();
					}
				}
				array[i] = num * array[i];
				matrixH[num2 + i] *= (Complex)(0.0 - num5);
			}
			for (int num9 = 0; num9 < order; num9++)
			{
				for (int num10 = 0; num10 < order; num10++)
				{
					dataEv[num10 * order + num9] = ((num9 == num10) ? Complex.One : Complex.Zero);
				}
			}
			for (int num11 = order - 2; num11 >= 1; num11--)
			{
				int num12 = (num11 - 1) * order;
				int num13 = num12 + num11;
				if (matrixH[num13] != Complex.Zero && array[num11] != Complex.Zero)
				{
					double num14 = matrixH[num13].Real * array[num11].Real + matrixH[num13].Imaginary * array[num11].Imaginary;
					for (int num15 = num11 + 1; num15 < order; num15++)
					{
						array[num15] = matrixH[num12 + num15];
					}
					for (int num16 = num11; num16 < order; num16++)
					{
						Complex zero3 = Complex.Zero;
						for (int num17 = num11; num17 < order; num17++)
						{
							zero3 += array[num17].Conjugate() * dataEv[num16 * order + num17];
						}
						zero3 /= (Complex)num14;
						for (int num18 = num11; num18 < order; num18++)
						{
							dataEv[num16 * order + num18] += zero3 * array[num18];
						}
					}
				}
			}
			for (int num19 = 1; num19 < order; num19++)
			{
				int num20 = (num19 - 1) * order + num19;
				int num21 = num19 * order;
				if (matrixH[num20].Imaginary != 0.0)
				{
					Complex complex = matrixH[num20] / matrixH[num20].Magnitude;
					matrixH[num20] = matrixH[num20].Magnitude;
					for (int num22 = num19; num22 < order; num22++)
					{
						matrixH[num22 * order + num19] *= complex.Conjugate();
					}
					for (int num23 = 0; num23 <= Math.Min(num19 + 1, order - 1); num23++)
					{
						matrixH[num21 + num23] *= complex;
					}
					for (int num24 = 0; num24 < order; num24++)
					{
						dataEv[num19 * order + num24] *= complex;
					}
				}
			}
		}

		internal static void NonsymmetricReduceHessenberToRealSchur(Complex[] vectorV, Complex[] dataEv, Complex[] matrixH, int order)
		{
			int num = order - 1;
			double doublePrecision = Precision.DoublePrecision;
			Complex zero = Complex.Zero;
			int num2 = 0;
			double num15;
			while (num >= 0)
			{
				int num3;
				for (num3 = num; num3 > 0; num3--)
				{
					int num4 = num3 - 1;
					int num5 = num4 * order;
					int num6 = num3 * order;
					double num7 = Math.Abs(matrixH[num5 + num4].Real) + Math.Abs(matrixH[num5 + num4].Imaginary) + Math.Abs(matrixH[num6 + num3].Real) + Math.Abs(matrixH[num6 + num3].Imaginary);
					if (Math.Abs(matrixH[num5 + num3].Real) < doublePrecision * num7)
					{
						break;
					}
				}
				int num8 = num - 1;
				int num9 = num8 * order;
				int num10 = num * order;
				int num11 = num10 + num;
				if (num3 == num)
				{
					matrixH[num11] += zero;
					vectorV[num] = matrixH[num11];
					num--;
					num2 = 0;
					continue;
				}
				Complex complex;
				if (num2 != 10 && num2 != 20)
				{
					complex = matrixH[num11];
					Complex complex2 = matrixH[num10 + num8] * matrixH[num9 + num].Real;
					if (complex2.Real != 0.0 || complex2.Imaginary != 0.0)
					{
						Complex complex3 = (matrixH[num9 + num8] - complex) / 2.0;
						Complex complex4 = (complex3 * complex3 + complex2).SquareRoot();
						if (complex3.Real * complex4.Real + complex3.Imaginary * complex4.Imaginary < 0.0)
						{
							complex4 *= (Complex)(-1.0);
						}
						complex2 /= complex3 + complex4;
						complex -= complex2;
					}
				}
				else
				{
					complex = Math.Abs(matrixH[num9 + num].Real) + Math.Abs(matrixH[(num - 2) * order + num8].Real);
				}
				for (int i = 0; i <= num; i++)
				{
					matrixH[i * order + i] -= complex;
				}
				zero += complex;
				num2++;
				for (int j = num3 + 1; j <= num; j++)
				{
					int num12 = j - 1;
					int num13 = num12 * order;
					int num14 = num13 + num12;
					complex = matrixH[num13 + j].Real;
					num15 = SpecialFunctions.Hypotenuse(matrixH[num14].Magnitude, complex.Real);
					Complex complex2 = (vectorV[j - 1] = matrixH[num14] / num15);
					matrixH[num14] = num15;
					matrixH[num13 + j] = new Complex(0.0, complex.Real / num15);
					for (int k = j; k < order; k++)
					{
						int num16 = k * order;
						Complex complex3 = matrixH[num16 + num12];
						Complex complex4 = matrixH[num16 + j];
						matrixH[num16 + num12] = complex2.Conjugate() * complex3 + matrixH[num13 + j].Imaginary * complex4;
						matrixH[num16 + j] = complex2 * complex4 - matrixH[num13 + j].Imaginary * complex3;
					}
				}
				complex = matrixH[num11];
				if (complex.Imaginary != 0.0)
				{
					complex /= (Complex)matrixH[num11].Magnitude;
					matrixH[num11] = matrixH[num11].Magnitude;
					for (int l = num + 1; l < order; l++)
					{
						matrixH[l * order + num] *= complex.Conjugate();
					}
				}
				for (int m = num3 + 1; m <= num; m++)
				{
					Complex complex2 = vectorV[m - 1];
					int num17 = m * order;
					int num18 = (m - 1) * order;
					int num19 = num18 + m;
					for (int n = 0; n <= m; n++)
					{
						int num20 = num18 + n;
						Complex complex4 = matrixH[num17 + n];
						Complex complex3;
						if (n != m)
						{
							complex3 = matrixH[num20];
							matrixH[num20] = complex2 * complex3 + matrixH[num18 + m].Imaginary * complex4;
						}
						else
						{
							complex3 = matrixH[num20].Real;
							matrixH[num20] = new Complex(complex2.Real * complex3.Real - complex2.Imaginary * complex3.Imaginary + matrixH[num18 + m].Imaginary * complex4.Real, matrixH[num20].Imaginary);
						}
						matrixH[num17 + n] = complex2.Conjugate() * complex4 - matrixH[num18 + m].Imaginary * complex3;
					}
					for (int num21 = 0; num21 < order; num21++)
					{
						Complex complex3 = dataEv[(m - 1) * order + num21];
						Complex complex4 = dataEv[m * order + num21];
						dataEv[num18 + num21] = complex2 * complex3 + matrixH[num19].Imaginary * complex4;
						dataEv[num17 + num21] = complex2.Conjugate() * complex4 - matrixH[num19].Imaginary * complex3;
					}
				}
				if (complex.Imaginary != 0.0)
				{
					for (int num22 = 0; num22 <= num; num22++)
					{
						matrixH[num10 + num22] *= complex;
					}
					for (int num23 = 0; num23 < order; num23++)
					{
						dataEv[num10 + num23] *= complex;
					}
				}
			}
			num15 = 0.0;
			for (int num24 = 0; num24 < order; num24++)
			{
				for (int num25 = num24; num25 < order; num25++)
				{
					num15 = Math.Max(num15, Math.Abs(matrixH[num25 * order + num24].Real) + Math.Abs(matrixH[num25 * order + num24].Imaginary));
				}
			}
			if (order == 1 || num15 == 0.0)
			{
				return;
			}
			for (num = order - 1; num > 0; num--)
			{
				int num26 = num * order;
				int num27 = num26 + num;
				Complex complex2 = vectorV[num];
				matrixH[num27] = 1.0;
				for (int num28 = num - 1; num28 >= 0; num28--)
				{
					Complex complex4 = 0.0;
					for (int num29 = num28 + 1; num29 <= num; num29++)
					{
						complex4 += matrixH[num29 * order + num28] * matrixH[num26 + num29];
					}
					Complex complex3 = complex2 - vectorV[num28];
					if (complex3.Real == 0.0 && complex3.Imaginary == 0.0)
					{
						complex3 = doublePrecision * num15;
					}
					matrixH[num26 + num28] = complex4 / complex3;
					double num30 = Math.Abs(matrixH[num26 + num28].Real) + Math.Abs(matrixH[num26 + num28].Imaginary);
					if (doublePrecision * num30 * num30 > 1.0)
					{
						for (int num31 = num28; num31 <= num; num31++)
						{
							matrixH[num26 + num31] /= (Complex)num30;
						}
					}
				}
			}
			for (int num32 = order - 1; num32 > 0; num32--)
			{
				int num33 = num32 * order;
				for (int num34 = 0; num34 < order; num34++)
				{
					Complex complex4 = Complex.Zero;
					for (int num35 = 0; num35 <= num32; num35++)
					{
						complex4 += dataEv[num35 * order + num34] * matrixH[num33 + num35];
					}
					dataEv[num33 + num34] = complex4;
				}
			}
		}

		private static void GetRow(Transpose transpose, int rowindx, int numRows, int numCols, Complex[] matrix, Complex[] row)
		{
			switch (transpose)
			{
			case Transpose.DontTranspose:
			{
				for (int j = 0; j < numCols; j++)
				{
					row[j] = matrix[j * numRows + rowindx];
				}
				break;
			}
			case Transpose.ConjugateTranspose:
			{
				int num = rowindx * numCols;
				for (int i = 0; i < row.Length; i++)
				{
					row[i] = matrix[i + num].Conjugate();
				}
				break;
			}
			default:
				Array.Copy(matrix, rowindx * numCols, row, 0, numCols);
				break;
			}
		}

		private static void GetColumn(Transpose transpose, int colindx, int numRows, int numCols, Complex[] matrix, Complex[] column)
		{
			switch (transpose)
			{
			case Transpose.DontTranspose:
				Array.Copy(matrix, colindx * numRows, column, 0, numRows);
				break;
			case Transpose.ConjugateTranspose:
			{
				for (int j = 0; j < numRows; j++)
				{
					column[j] = matrix[j * numCols + colindx].Conjugate();
				}
				break;
			}
			default:
			{
				for (int i = 0; i < numRows; i++)
				{
					column[i] = matrix[i * numCols + colindx];
				}
				break;
			}
			}
		}

		public void AddVectorToScaledVector(Complex32[] y, Complex32 alpha, Complex32[] x, Complex32[] result)
		{
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (y.Length != x.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (alpha.IsZero())
			{
				y.Copy(result);
			}
			else if (alpha.IsOne())
			{
				for (int i = 0; i < result.Length; i++)
				{
					result[i] = y[i] + x[i];
				}
			}
			else
			{
				for (int j = 0; j < result.Length; j++)
				{
					result[j] = y[j] + alpha * x[j];
				}
			}
		}

		public void ScaleArray(Complex32 alpha, Complex32[] x, Complex32[] result)
		{
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (alpha.IsZero())
			{
				Array.Clear(result, 0, result.Length);
				return;
			}
			if (alpha.IsOne())
			{
				x.Copy(result);
				return;
			}
			for (int i = 0; i < result.Length; i++)
			{
				result[i] = alpha * x[i];
			}
		}

		public void ConjugateArray(Complex32[] x, Complex32[] result)
		{
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			for (int i = 0; i < result.Length; i++)
			{
				result[i] = x[i].Conjugate();
			}
		}

		public Complex32 DotProduct(Complex32[] x, Complex32[] y)
		{
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (y.Length != x.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			Complex32 result = new Complex32(0f, 0f);
			for (int i = 0; i < y.Length; i++)
			{
				result += y[i] * x[i];
			}
			return result;
		}

		public void AddArrays(Complex32[] x, Complex32[] y, Complex32[] result)
		{
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (y.Length != x.Length || y.Length != result.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			for (int i = 0; i < result.Length; i++)
			{
				result[i] = x[i] + y[i];
			}
		}

		public void SubtractArrays(Complex32[] x, Complex32[] y, Complex32[] result)
		{
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (y.Length != x.Length || y.Length != result.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			for (int i = 0; i < result.Length; i++)
			{
				result[i] = x[i] - y[i];
			}
		}

		public void PointWiseMultiplyArrays(Complex32[] x, Complex32[] y, Complex32[] result)
		{
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (y.Length != x.Length || y.Length != result.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			for (int i = 0; i < result.Length; i++)
			{
				result[i] = x[i] * y[i];
			}
		}

		public void PointWiseDivideArrays(Complex32[] x, Complex32[] y, Complex32[] result)
		{
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (y.Length != x.Length || y.Length != result.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			CommonParallel.For(0, y.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					result[i] = x[i] / y[i];
				}
			});
		}

		public void PointWisePowerArrays(Complex32[] x, Complex32[] y, Complex32[] result)
		{
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (y.Length != x.Length || y.Length != result.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			CommonParallel.For(0, y.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					result[i] = Complex32.Pow(x[i], y[i]);
				}
			});
		}

		public double MatrixNorm(Norm norm, int rows, int columns, Complex32[] matrix)
		{
			switch (norm)
			{
			case Norm.OneNorm:
			{
				double num3 = 0.0;
				for (int l = 0; l < columns; l++)
				{
					double num4 = 0.0;
					for (int m = 0; m < rows; m++)
					{
						num4 += (double)matrix[l * rows + m].Magnitude;
					}
					num3 = Math.Max(num3, num4);
				}
				return num3;
			}
			case Norm.LargestAbsoluteValue:
			{
				double num2 = 0.0;
				for (int j = 0; j < columns; j++)
				{
					for (int k = 0; k < rows; k++)
					{
						num2 = Math.Max(matrix[j * rows + k].Magnitude, num2);
					}
				}
				return num2;
			}
			case Norm.InfinityNorm:
			{
				double[] array2 = new double[rows];
				for (int n = 0; n < columns; n++)
				{
					for (int num5 = 0; num5 < rows; num5++)
					{
						array2[num5] += matrix[n * rows + num5].Magnitude;
					}
				}
				double num6 = array2[0];
				for (int num7 = 0; num7 < array2.Length; num7++)
				{
					if (array2[num7] > num6)
					{
						num6 = array2[num7];
					}
				}
				return num6;
			}
			case Norm.FrobeniusNorm:
			{
				Complex32[] array = new Complex32[rows * rows];
				MatrixMultiplyWithUpdate(Transpose.DontTranspose, Transpose.ConjugateTranspose, 1f, matrix, rows, columns, matrix, rows, columns, 0f, array);
				double num = 0.0;
				for (int i = 0; i < rows; i++)
				{
					num += (double)array[i * rows + i].Magnitude;
				}
				return Math.Sqrt(num);
			}
			default:
				throw new NotSupportedException();
			}
		}

		public void MatrixMultiply(Complex32[] x, int rowsX, int columnsX, Complex32[] y, int rowsY, int columnsY, Complex32[] result)
		{
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (columnsX != rowsY)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"columnsA ({columnsX}) != rowsB ({rowsY})"));
			}
			if (rowsX * columnsX != x.Length)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"rowsA ({rowsX}) * columnsA ({columnsX}) != a.Length ({x.Length})"));
			}
			if (rowsY * columnsY != y.Length)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"rowsB ({rowsY}) * columnsB ({columnsY}) != b.Length ({y.Length})"));
			}
			if (rowsX * columnsY != result.Length)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"rowsA ({rowsX}) * columnsB ({columnsY}) != c.Length ({result.Length})"));
			}
			Array.Clear(result, 0, result.Length);
			Complex32[][] columnDataB = new Complex32[columnsY][];
			for (int i = 0; i < columnDataB.Length; i++)
			{
				Complex32[] array = new Complex32[rowsY];
				GetColumn(Transpose.DontTranspose, i, rowsY, columnsY, y, array);
				columnDataB[i] = array;
			}
			if (rowsX + columnsY + columnsX < Control.ParallelizeOrder || Control.MaxDegreeOfParallelism < 2)
			{
				Complex32[] array2 = new Complex32[columnsX];
				for (int j = 0; j < rowsX; j++)
				{
					GetRow(Transpose.DontTranspose, j, rowsX, columnsX, x, array2);
					for (int k = 0; k < columnsY; k++)
					{
						Complex32[] array3 = columnDataB[k];
						Complex32 zero = Complex32.Zero;
						for (int l = 0; l < array2.Length; l++)
						{
							zero += array2[l] * array3[l];
						}
						result[k * rowsX + j] += Complex32.One * zero;
					}
				}
				return;
			}
			CommonParallel.For(0, rowsX, 1, delegate(int u, int v)
			{
				Complex32[] array4 = new Complex32[columnsX];
				for (int m = u; m < v; m++)
				{
					GetRow(Transpose.DontTranspose, m, rowsX, columnsX, x, array4);
					for (int n = 0; n < columnsY; n++)
					{
						Complex32[] array5 = columnDataB[n];
						Complex32 zero2 = Complex32.Zero;
						for (int num = 0; num < array4.Length; num++)
						{
							zero2 += array4[num] * array5[num];
						}
						result[n * rowsX + m] += Complex32.One * zero2;
					}
				}
			});
		}

		public void MatrixMultiplyWithUpdate(Transpose transposeA, Transpose transposeB, Complex32 alpha, Complex32[] a, int rowsA, int columnsA, Complex32[] b, int rowsB, int columnsB, Complex32 beta, Complex32[] c)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (c == null)
			{
				throw new ArgumentNullException("c");
			}
			if (transposeA != Transpose.DontTranspose)
			{
				int num = columnsA;
				int num2 = rowsA;
				columnsA = num2;
				rowsA = num;
			}
			if (transposeB != Transpose.DontTranspose)
			{
				int num3 = columnsB;
				int num2 = rowsB;
				columnsB = num2;
				rowsB = num3;
			}
			if (columnsA != rowsB)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"columnsA ({columnsA}) != rowsB ({rowsB})"));
			}
			if (rowsA * columnsA != a.Length)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"rowsA ({rowsA}) * columnsA ({columnsA}) != a.Length ({a.Length})"));
			}
			if (rowsB * columnsB != b.Length)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"rowsB ({rowsB}) * columnsB ({columnsB}) != b.Length ({b.Length})"));
			}
			if (rowsA * columnsB != c.Length)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"rowsA ({rowsA}) * columnsB ({columnsB}) != c.Length ({c.Length})"));
			}
			if (beta == Complex32.Zero)
			{
				Array.Clear(c, 0, c.Length);
			}
			else if (beta != Complex32.One)
			{
				ScaleArray(beta, c, c);
			}
			if (alpha == Complex32.Zero)
			{
				return;
			}
			Complex32[][] columnDataB = new Complex32[columnsB][];
			for (int i = 0; i < columnDataB.Length; i++)
			{
				Complex32[] array = new Complex32[rowsB];
				GetColumn(transposeB, i, rowsB, columnsB, b, array);
				columnDataB[i] = array;
			}
			if (rowsA + columnsB + columnsA < Control.ParallelizeOrder || Control.MaxDegreeOfParallelism < 2)
			{
				Complex32[] array2 = new Complex32[columnsA];
				for (int j = 0; j < rowsA; j++)
				{
					GetRow(transposeA, j, rowsA, columnsA, a, array2);
					for (int k = 0; k < columnsB; k++)
					{
						Complex32[] array3 = columnDataB[k];
						Complex32 zero = Complex32.Zero;
						for (int l = 0; l < array2.Length; l++)
						{
							zero += array2[l] * array3[l];
						}
						c[k * rowsA + j] += alpha * zero;
					}
				}
				return;
			}
			CommonParallel.For(0, rowsA, 1, delegate(int u, int v)
			{
				Complex32[] array4 = new Complex32[columnsA];
				for (int m = u; m < v; m++)
				{
					GetRow(transposeA, m, rowsA, columnsA, a, array4);
					for (int n = 0; n < columnsB; n++)
					{
						Complex32[] array5 = columnDataB[n];
						Complex32 zero2 = Complex32.Zero;
						for (int num4 = 0; num4 < array4.Length; num4++)
						{
							zero2 += array4[num4] * array5[num4];
						}
						c[n * rowsA + m] += alpha * zero2;
					}
				}
			});
		}

		public void LUFactor(Complex32[] data, int order, int[] ipiv)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (ipiv == null)
			{
				throw new ArgumentNullException("ipiv");
			}
			if (data.Length != order * order)
			{
				throw new ArgumentException("The array arguments must have the same length.", "data");
			}
			if (ipiv.Length != order)
			{
				throw new ArgumentException("The array arguments must have the same length.", "ipiv");
			}
			for (int i = 0; i < order; i++)
			{
				ipiv[i] = i;
			}
			Complex32[] array = new Complex32[order];
			for (int j = 0; j < order; j++)
			{
				int num = j * order;
				int num2 = num + j;
				for (int k = 0; k < order; k++)
				{
					array[k] = data[num + k];
				}
				for (int l = 0; l < order; l++)
				{
					int num3 = Math.Min(l, j);
					Complex32 zero = Complex32.Zero;
					for (int m = 0; m < num3; m++)
					{
						zero += data[m * order + l] * array[m];
					}
					data[num + l] = (array[l] -= zero);
				}
				int num4 = j;
				for (int n = j + 1; n < order; n++)
				{
					if (array[n].Magnitude > array[num4].Magnitude)
					{
						num4 = n;
					}
				}
				if (num4 != j)
				{
					for (int num5 = 0; num5 < order; num5++)
					{
						int num6 = num5 * order;
						int num7 = num6 + num4;
						int num8 = num6 + j;
						ref Complex32 reference = ref data[num7];
						ref Complex32 reference2 = ref data[num8];
						Complex32 complex = data[num8];
						Complex32 complex2 = data[num7];
						reference = complex;
						reference2 = complex2;
					}
					ipiv[j] = num4;
				}
				if ((j < order) & (data[num2] != 0f))
				{
					for (int num9 = j + 1; num9 < order; num9++)
					{
						data[num + num9] /= data[num2];
					}
				}
			}
		}

		public void LUInverse(Complex32[] a, int order)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (a.Length != order * order)
			{
				throw new ArgumentException("The array arguments must have the same length.", "a");
			}
			int[] ipiv = new int[order];
			LUFactor(a, order, ipiv);
			LUInverseFactored(a, order, ipiv);
		}

		public void LUInverseFactored(Complex32[] a, int order, int[] ipiv)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (ipiv == null)
			{
				throw new ArgumentNullException("ipiv");
			}
			if (a.Length != order * order)
			{
				throw new ArgumentException("The array arguments must have the same length.", "a");
			}
			if (ipiv.Length != order)
			{
				throw new ArgumentException("The array arguments must have the same length.", "ipiv");
			}
			Complex32[] array = new Complex32[a.Length];
			for (int i = 0; i < order; i++)
			{
				array[i + order * i] = Complex32.One;
			}
			LUSolveFactored(order, a, order, ipiv, array);
			array.Copy(a);
		}

		public void LUSolve(int columnsOfB, Complex32[] a, int order, Complex32[] b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (a.Length != order * order)
			{
				throw new ArgumentException("The array arguments must have the same length.", "a");
			}
			if (b.Length != order * columnsOfB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			if (a == b)
			{
				throw new ArgumentException("Arguments must be different objects.");
			}
			int[] ipiv = new int[order];
			Complex32[] array = new Complex32[a.Length];
			a.Copy(array);
			LUFactor(array, order, ipiv);
			LUSolveFactored(columnsOfB, array, order, ipiv, b);
		}

		public void LUSolveFactored(int columnsOfB, Complex32[] a, int order, int[] ipiv, Complex32[] b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (ipiv == null)
			{
				throw new ArgumentNullException("ipiv");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (a.Length != order * order)
			{
				throw new ArgumentException("The array arguments must have the same length.", "a");
			}
			if (ipiv.Length != order)
			{
				throw new ArgumentException("The array arguments must have the same length.", "ipiv");
			}
			if (b.Length != order * columnsOfB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			if (a == b)
			{
				throw new ArgumentException("Arguments must be different objects.");
			}
			for (int i = 0; i < ipiv.Length; i++)
			{
				if (ipiv[i] != i)
				{
					int num = ipiv[i];
					for (int j = 0; j < columnsOfB; j++)
					{
						int num2 = j * order;
						int num3 = num2 + num;
						int num4 = num2 + i;
						ref Complex32 reference = ref b[num3];
						ref Complex32 reference2 = ref b[num4];
						Complex32 complex = b[num4];
						Complex32 complex2 = b[num3];
						reference = complex;
						reference2 = complex2;
					}
				}
			}
			for (int k = 0; k < order; k++)
			{
				int num5 = k * order;
				for (int l = k + 1; l < order; l++)
				{
					for (int m = 0; m < columnsOfB; m++)
					{
						int num6 = m * order;
						b[l + num6] -= b[k + num6] * a[l + num5];
					}
				}
			}
			for (int num7 = order - 1; num7 >= 0; num7--)
			{
				int num8 = num7 + num7 * order;
				for (int n = 0; n < columnsOfB; n++)
				{
					b[num7 + n * order] /= a[num8];
				}
				num8 = num7 * order;
				for (int num9 = 0; num9 < num7; num9++)
				{
					for (int num10 = 0; num10 < columnsOfB; num10++)
					{
						int num11 = num10 * order;
						b[num9 + num11] -= b[num7 + num11] * a[num9 + num8];
					}
				}
			}
		}

		public void CholeskyFactor(Complex32[] a, int order)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			Complex32[] array = new Complex32[order];
			for (int i = 0; i < order; i++)
			{
				Complex32 complex = a[i * order + i];
				if (!((double)complex.Real > 0.0))
				{
					throw new ArgumentException("Matrix must be positive definite.");
				}
				complex = (array[i] = (a[i * order + i] = complex.SquareRoot()));
				for (int j = i + 1; j < order; j++)
				{
					a[i * order + j] /= complex;
					array[j] = a[i * order + j];
				}
				DoCholeskyStep(a, order, i + 1, order, array, Control.MaxDegreeOfParallelism);
				for (int k = i + 1; k < order; k++)
				{
					a[k * order + i] = 0f;
				}
			}
		}

		private static void DoCholeskyStep(Complex32[] data, int rowDim, int firstCol, int colLimit, Complex32[] multipliers, int availableCores)
		{
			int num = colLimit - firstCol;
			if (availableCores > 1 && num > Control.ParallelizeElements)
			{
				int tmpSplit = firstCol + num / 3;
				int tmpCores = availableCores / 2;
				CommonParallel.Invoke(delegate
				{
					DoCholeskyStep(data, rowDim, firstCol, tmpSplit, multipliers, tmpCores);
				}, delegate
				{
					DoCholeskyStep(data, rowDim, tmpSplit, colLimit, multipliers, tmpCores);
				});
				return;
			}
			for (int num2 = firstCol; num2 < colLimit; num2++)
			{
				Complex32 complex = multipliers[num2];
				for (int num3 = num2; num3 < rowDim; num3++)
				{
					data[num2 * rowDim + num3] -= multipliers[num3] * complex.Conjugate();
				}
			}
		}

		public void CholeskySolve(Complex32[] a, int orderA, Complex32[] b, int columnsB)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (b.Length != orderA * columnsB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			if (a == b)
			{
				throw new ArgumentException("Arguments must be different objects.");
			}
			Complex32[] array = new Complex32[a.Length];
			a.Copy(array);
			CholeskyFactor(array, orderA);
			CholeskySolveFactored(array, orderA, b, columnsB);
		}

		public void CholeskySolveFactored(Complex32[] a, int orderA, Complex32[] b, int columnsB)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (b.Length != orderA * columnsB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			if (a == b)
			{
				throw new ArgumentException("Arguments must be different objects.");
			}
			CommonParallel.For(0, columnsB, delegate(int u, int v)
			{
				for (int i = u; i < v; i++)
				{
					DoCholeskySolve(a, orderA, b, i);
				}
			});
		}

		private static void DoCholeskySolve(Complex32[] a, int orderA, Complex32[] b, int index)
		{
			int num = index * orderA;
			for (int i = 0; i < orderA; i++)
			{
				Complex32 complex = b[num + i];
				for (int num2 = i - 1; num2 >= 0; num2--)
				{
					complex -= a[num2 * orderA + i] * b[num + num2];
				}
				b[num + i] = complex / a[i * orderA + i];
			}
			for (int num3 = orderA - 1; num3 >= 0; num3--)
			{
				Complex32 complex = b[num + num3];
				int num4 = num3 * orderA;
				for (int j = num3 + 1; j < orderA; j++)
				{
					complex -= a[num4 + j].Conjugate() * b[num + j];
				}
				b[num + num3] = complex / a[num4 + num3];
			}
		}

		public void QRFactor(Complex32[] r, int rowsR, int columnsR, Complex32[] q, Complex32[] tau)
		{
			if (r == null)
			{
				throw new ArgumentNullException("r");
			}
			if (q == null)
			{
				throw new ArgumentNullException("q");
			}
			if (r.Length != rowsR * columnsR)
			{
				throw new ArgumentException("The given array has the wrong length. Should be rowsR * columnsR.", "r");
			}
			if (tau.Length < Math.Min(rowsR, columnsR))
			{
				throw new ArgumentException("The given array is too small. It must be at least min(m,n) long.", "tau");
			}
			if (q.Length != rowsR * rowsR)
			{
				throw new ArgumentException("The given array has the wrong length. Should be rowsR * rowsR.", "q");
			}
			Complex32[] work = ((columnsR > rowsR) ? new Complex32[rowsR * rowsR] : new Complex32[rowsR * columnsR]);
			CommonParallel.For(0, rowsR, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					q[i * rowsR + i] = Complex32.One;
				}
			});
			int num = Math.Min(rowsR, columnsR);
			for (int num2 = 0; num2 < num; num2++)
			{
				GenerateColumn(work, r, rowsR, num2, num2);
				ComputeQR(work, num2, r, num2, rowsR, num2 + 1, columnsR, Control.MaxDegreeOfParallelism);
			}
			for (int num3 = num - 1; num3 >= 0; num3--)
			{
				ComputeQR(work, num3, q, num3, rowsR, num3, rowsR, Control.MaxDegreeOfParallelism);
			}
		}

		public void ThinQRFactor(Complex32[] a, int rowsA, int columnsA, Complex32[] r, Complex32[] tau)
		{
			if (r == null)
			{
				throw new ArgumentNullException("r");
			}
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (a.Length != rowsA * columnsA)
			{
				throw new ArgumentException("The given array has the wrong length. Should be rowsR * columnsR.", "a");
			}
			if (tau.Length < Math.Min(rowsA, columnsA))
			{
				throw new ArgumentException("The given array is too small. It must be at least min(m,n) long.", "tau");
			}
			if (r.Length != columnsA * columnsA)
			{
				throw new ArgumentException("The given array has the wrong length. Should be columnsA * columnsA.", "r");
			}
			Complex32[] work = new Complex32[rowsA * columnsA];
			int num = Math.Min(rowsA, columnsA);
			for (int i = 0; i < num; i++)
			{
				GenerateColumn(work, a, rowsA, i, i);
				ComputeQR(work, i, a, i, rowsA, i + 1, columnsA, Control.MaxDegreeOfParallelism);
			}
			for (int j = 0; j < columnsA; j++)
			{
				int num2 = j * columnsA;
				int num3 = j * rowsA;
				for (int k = 0; k < columnsA; k++)
				{
					r[num2 + k] = a[num3 + k];
				}
			}
			Array.Clear(a, 0, a.Length);
			for (int l = 0; l < columnsA; l++)
			{
				a[l * rowsA + l] = Complex32.One;
			}
			for (int num4 = num - 1; num4 >= 0; num4--)
			{
				ComputeQR(work, num4, a, num4, rowsA, num4, columnsA, Control.MaxDegreeOfParallelism);
			}
		}

		private static void ComputeQR(Complex32[] work, int workIndex, Complex32[] a, int rowStart, int rowCount, int columnStart, int columnCount, int availableCores)
		{
			if (rowStart > rowCount || columnStart > columnCount)
			{
				return;
			}
			int num = columnCount - columnStart;
			if (availableCores > 1 && num > 200)
			{
				int tmpSplit = columnStart + num / 2;
				int tmpCores = availableCores / 2;
				CommonParallel.Invoke(delegate
				{
					ComputeQR(work, workIndex, a, rowStart, rowCount, columnStart, tmpSplit, tmpCores);
				}, delegate
				{
					ComputeQR(work, workIndex, a, rowStart, rowCount, tmpSplit, columnCount, tmpCores);
				});
				return;
			}
			for (int num2 = columnStart; num2 < columnCount; num2++)
			{
				Complex32 zero = Complex32.Zero;
				for (int num3 = rowStart; num3 < rowCount; num3++)
				{
					zero += work[workIndex * rowCount + num3 - rowStart] * a[num2 * rowCount + num3];
				}
				for (int num4 = rowStart; num4 < rowCount; num4++)
				{
					a[num2 * rowCount + num4] -= work[workIndex * rowCount + num4 - rowStart].Conjugate() * zero;
				}
			}
		}

		private static void GenerateColumn(Complex32[] work, Complex32[] a, int rowCount, int row, int column)
		{
			int tmp = column * rowCount;
			int num = tmp + row;
			CommonParallel.For(row, rowCount, delegate(int u, int v)
			{
				for (int i = u; i < v; i++)
				{
					int num4 = tmp + i;
					work[num4 - row] = a[num4];
					a[num4] = Complex32.Zero;
				}
			});
			Complex32 norm = Complex32.Zero;
			for (int num2 = 0; num2 < rowCount - row; num2++)
			{
				int num3 = tmp + num2;
				norm += work[num3].Magnitude * work[num3].Magnitude;
			}
			norm = norm.SquareRoot();
			if (row == rowCount - 1 || norm.Magnitude == 0f)
			{
				a[num] = -work[tmp];
				work[tmp] = new Complex32(2f, 0f).SquareRoot();
				return;
			}
			if (work[tmp].Magnitude != 0f)
			{
				norm = norm.Magnitude * (work[tmp] / work[tmp].Magnitude);
			}
			a[num] = -norm;
			CommonParallel.For(0, rowCount - row, 4096, delegate(int u, int v)
			{
				for (int i = u; i < v; i++)
				{
					work[tmp + i] /= norm;
				}
			});
			work[tmp] += 1f;
			Complex32 s = (1f / work[tmp]).SquareRoot();
			CommonParallel.For(0, rowCount - row, 4096, delegate(int u, int v)
			{
				for (int i = u; i < v; i++)
				{
					work[tmp + i] = work[tmp + i].Conjugate() * s;
				}
			});
		}

		public void QRSolve(Complex32[] a, int rows, int columns, Complex32[] b, int columnsB, Complex32[] x, QRMethod method = QRMethod.Full)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (a.Length != rows * columns)
			{
				throw new ArgumentException("The array arguments must have the same length.", "a");
			}
			if (b.Length != rows * columnsB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			if (x.Length != columns * columnsB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "x");
			}
			if (rows < columns)
			{
				throw new ArgumentException("The number of rows must greater than or equal to the number of columns.");
			}
			Complex32[] tau = new Complex32[rows * columns];
			Complex32[] array = new Complex32[a.Length];
			a.Copy(array);
			if (method == QRMethod.Full)
			{
				Complex32[] q = new Complex32[rows * rows];
				QRFactor(array, rows, columns, q, tau);
				QRSolveFactored(q, array, rows, columns, null, b, columnsB, x, method);
			}
			else
			{
				Complex32[] r = new Complex32[columns * columns];
				ThinQRFactor(array, rows, columns, r, tau);
				QRSolveFactored(array, r, rows, columns, null, b, columnsB, x, method);
			}
		}

		public void QRSolveFactored(Complex32[] q, Complex32[] r, int rowsA, int columnsA, Complex32[] tau, Complex32[] b, int columnsB, Complex32[] x, QRMethod method = QRMethod.Full)
		{
			if (r == null)
			{
				throw new ArgumentNullException("r");
			}
			if (q == null)
			{
				throw new ArgumentNullException("q");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (rowsA < columnsA)
			{
				throw new ArgumentException("The number of rows must greater than or equal to the number of columns.");
			}
			int num;
			int num2;
			int num3;
			int num4;
			if (method == QRMethod.Full)
			{
				num = (num2 = (num3 = rowsA));
				num4 = columnsA;
			}
			else
			{
				num = rowsA;
				num2 = (num3 = (num4 = columnsA));
			}
			if (r.Length != num3 * num4)
			{
				throw new ArgumentException($"The given array has the wrong length. Should be {num3 * num4}.", "r");
			}
			if (q.Length != num * num2)
			{
				throw new ArgumentException($"The given array has the wrong length. Should be {num * num2}.", "q");
			}
			if (b.Length != rowsA * columnsB)
			{
				throw new ArgumentException($"The given array has the wrong length. Should be {rowsA * columnsB}.", "b");
			}
			if (x.Length != columnsA * columnsB)
			{
				throw new ArgumentException($"The given array has the wrong length. Should be {columnsA * columnsB}.", "x");
			}
			Complex32[] sol = new Complex32[b.Length];
			Array.Copy(b, 0, sol, 0, b.Length);
			Complex32[] column = new Complex32[rowsA];
			for (int i = 0; i < columnsB; i++)
			{
				int jm = i * rowsA;
				Array.Copy(sol, jm, column, 0, rowsA);
				CommonParallel.For(0, columnsA, delegate(int u, int v)
				{
					for (int j = u; j < v; j++)
					{
						int num12 = j * rowsA;
						Complex32 zero = Complex32.Zero;
						for (int k = 0; k < rowsA; k++)
						{
							zero += q[num12 + k].Conjugate() * column[k];
						}
						sol[jm + j] = zero;
					}
				});
			}
			for (int num5 = columnsA - 1; num5 >= 0; num5--)
			{
				int num6 = num5 * num3;
				for (int num7 = 0; num7 < columnsB; num7++)
				{
					sol[num7 * rowsA + num5] /= r[num6 + num5];
				}
				for (int num8 = 0; num8 < num5; num8++)
				{
					for (int num9 = 0; num9 < columnsB; num9++)
					{
						int num10 = num9 * rowsA;
						sol[num10 + num8] -= sol[num10 + num5] * r[num6 + num8];
					}
				}
			}
			for (int num11 = 0; num11 < columnsB; num11++)
			{
				Array.Copy(sol, num11 * rowsA, x, num11 * columnsA, num4);
			}
		}

		public void SingularValueDecomposition(bool computeVectors, Complex32[] a, int rowsA, int columnsA, Complex32[] s, Complex32[] u, Complex32[] vt)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			if (u == null)
			{
				throw new ArgumentNullException("u");
			}
			if (vt == null)
			{
				throw new ArgumentNullException("vt");
			}
			if (u.Length != rowsA * rowsA)
			{
				throw new ArgumentException("The array arguments must have the same length.", "u");
			}
			if (vt.Length != columnsA * columnsA)
			{
				throw new ArgumentException("The array arguments must have the same length.", "vt");
			}
			if (s.Length != Math.Min(rowsA, columnsA))
			{
				throw new ArgumentException("The array arguments must have the same length.", "s");
			}
			Complex32[] array = new Complex32[rowsA];
			Complex32[] array2 = new Complex32[columnsA];
			Complex32[] array3 = new Complex32[vt.Length];
			Complex32[] array4 = new Complex32[Math.Min(rowsA + 1, columnsA)];
			int num = Math.Min(rowsA - 1, columnsA);
			int num2 = Math.Max(0, Math.Min(columnsA - 2, rowsA));
			int num3 = Math.Max(num, num2);
			for (int i = 0; i < num3; i++)
			{
				int num4 = i + 1;
				if (i < num)
				{
					float num5 = 0f;
					for (int j = i; j < rowsA; j++)
					{
						num5 += a[i * rowsA + j].Magnitude * a[i * rowsA + j].Magnitude;
					}
					array4[i] = (float)Math.Sqrt(num5);
					if (array4[i] != 0f)
					{
						if (a[i * rowsA + i] != 0f)
						{
							array4[i] = array4[i].Magnitude * (a[i * rowsA + i] / a[i * rowsA + i].Magnitude);
						}
						for (int j = i; j < rowsA; j++)
						{
							a[i * rowsA + j] *= 1f / array4[i];
						}
						a[i * rowsA + i] = 1f + a[i * rowsA + i];
					}
					array4[i] = -array4[i];
				}
				for (int k = num4; k < columnsA; k++)
				{
					if (i < num && array4[i] != 0f)
					{
						Complex32 complex = 0f;
						for (int j = i; j < rowsA; j++)
						{
							complex += a[i * rowsA + j].Conjugate() * a[k * rowsA + j];
						}
						complex = -complex / a[i * rowsA + i];
						for (int l = i; l < rowsA; l++)
						{
							a[k * rowsA + l] += complex * a[i * rowsA + l];
						}
					}
					array2[k] = a[k * rowsA + i].Conjugate();
				}
				if (computeVectors && i < num)
				{
					for (int j = i; j < rowsA; j++)
					{
						u[i * rowsA + j] = a[i * rowsA + j];
					}
				}
				if (i >= num2)
				{
					continue;
				}
				float num6 = 0f;
				for (int j = num4; j < array2.Length; j++)
				{
					num6 += array2[j].Magnitude * array2[j].Magnitude;
				}
				array2[i] = (float)Math.Sqrt(num6);
				if (array2[i] != 0f)
				{
					if (array2[num4] != 0f)
					{
						array2[i] = array2[i].Magnitude * (array2[num4] / array2[num4].Magnitude);
					}
					for (int j = num4; j < array2.Length; j++)
					{
						array2[j] *= 1f / array2[i];
					}
					array2[num4] = 1f + array2[num4];
				}
				array2[i] = -array2[i].Conjugate();
				if (num4 < rowsA && array2[i] != 0f)
				{
					for (int j = num4; j < rowsA; j++)
					{
						array[j] = 0f;
					}
					for (int k = num4; k < columnsA; k++)
					{
						for (int m = num4; m < rowsA; m++)
						{
							array[m] += array2[k] * a[k * rowsA + m];
						}
					}
					for (int k = num4; k < columnsA; k++)
					{
						Complex32 complex2 = (-array2[k] / array2[num4]).Conjugate();
						for (int n = num4; n < rowsA; n++)
						{
							a[k * rowsA + n] += complex2 * array[n];
						}
					}
				}
				if (computeVectors)
				{
					for (int j = num4; j < columnsA; j++)
					{
						array3[i * columnsA + j] = array2[j];
					}
				}
			}
			int num7 = Math.Min(columnsA, rowsA + 1);
			int num8 = num + 1;
			int num9 = num2 + 1;
			if (num < columnsA)
			{
				array4[num8 - 1] = a[(num8 - 1) * rowsA + (num8 - 1)];
			}
			if (rowsA < num7)
			{
				array4[num7 - 1] = 0f;
			}
			if (num9 < num7)
			{
				array2[num9 - 1] = a[(num7 - 1) * rowsA + (num9 - 1)];
			}
			array2[num7 - 1] = 0f;
			if (computeVectors)
			{
				for (int k = num8 - 1; k < rowsA; k++)
				{
					for (int j = 0; j < rowsA; j++)
					{
						u[k * rowsA + j] = 0f;
					}
					u[k * rowsA + k] = 1f;
				}
				for (int i = num - 1; i >= 0; i--)
				{
					if (array4[i] != 0f)
					{
						for (int k = i + 1; k < rowsA; k++)
						{
							Complex32 complex = 0f;
							for (int j = i; j < rowsA; j++)
							{
								complex += u[i * rowsA + j].Conjugate() * u[k * rowsA + j];
							}
							complex = -complex / u[i * rowsA + i];
							for (int num10 = i; num10 < rowsA; num10++)
							{
								u[k * rowsA + num10] += complex * u[i * rowsA + num10];
							}
						}
						for (int j = i; j < rowsA; j++)
						{
							u[i * rowsA + j] *= -1f;
						}
						u[i * rowsA + i] = 1f + u[i * rowsA + i];
						for (int j = 0; j < i; j++)
						{
							u[i * rowsA + j] = 0f;
						}
					}
					else
					{
						for (int j = 0; j < rowsA; j++)
						{
							u[i * rowsA + j] = 0f;
						}
						u[i * rowsA + i] = 1f;
					}
				}
			}
			if (computeVectors)
			{
				for (int i = columnsA - 1; i >= 0; i--)
				{
					int num4 = i + 1;
					if (i < num2 && array2[i] != 0f)
					{
						for (int k = num4; k < columnsA; k++)
						{
							Complex32 complex = 0f;
							for (int j = num4; j < columnsA; j++)
							{
								complex += array3[i * columnsA + j].Conjugate() * array3[k * columnsA + j];
							}
							complex = -complex / array3[i * columnsA + num4];
							for (int num11 = i; num11 < columnsA; num11++)
							{
								array3[k * columnsA + num11] += complex * array3[i * columnsA + num11];
							}
						}
					}
					for (int j = 0; j < columnsA; j++)
					{
						array3[i * columnsA + j] = 0f;
					}
					array3[i * columnsA + i] = 1f;
				}
			}
			for (int j = 0; j < num7; j++)
			{
				Complex32 complex;
				Complex32 complex3;
				if (array4[j] != 0f)
				{
					complex = array4[j].Magnitude;
					complex3 = array4[j] / complex;
					array4[j] = complex;
					if (j < num7 - 1)
					{
						array2[j] /= complex3;
					}
					if (computeVectors)
					{
						for (int k = 0; k < rowsA; k++)
						{
							u[j * rowsA + k] *= complex3;
						}
					}
				}
				if (j == num7 - 1)
				{
					break;
				}
				if (array2[j] == 0f)
				{
					continue;
				}
				complex = array2[j].Magnitude;
				complex3 = complex / array2[j];
				array2[j] = complex;
				array4[j + 1] *= complex3;
				if (computeVectors)
				{
					for (int k = 0; k < columnsA; k++)
					{
						array3[(j + 1) * columnsA + k] *= complex3;
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
					float num14 = array4[i].Magnitude + array4[i + 1].Magnitude;
					if ((num14 + array2[i].Magnitude).AlmostEqualRelative(num14, 7))
					{
						array2[i] = 0f;
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
						float num14 = 0f;
						if (num16 != num7 - 1)
						{
							num14 += array2[num16].Magnitude;
						}
						if (num16 != i + 1)
						{
							num14 += array2[num16 - 1].Magnitude;
						}
						if ((num14 + array4[num16].Magnitude).AlmostEqualRelative(num14, 7))
						{
							array4[num16] = 0f;
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
				float c;
				float s2;
				switch (num15)
				{
				case 1:
				{
					float db = array2[num7 - 2].Real;
					array2[num7 - 2] = 0f;
					for (int num26 = i; num26 < num7 - 1; num26++)
					{
						int num17 = num7 - 2 - num26 + i;
						float da = array4[num17].Real;
						Drotg(ref da, ref db, out c, out s2);
						array4[num17] = da;
						if (num17 != i)
						{
							db = (0f - s2) * array2[num17 - 1].Real;
							array2[num17 - 1] = c * array2[num17 - 1];
						}
						if (computeVectors)
						{
							for (int j = 0; j < columnsA; j++)
							{
								Complex32 complex9 = c * array3[num17 * columnsA + j] + s2 * array3[(num7 - 1) * columnsA + j];
								array3[(num7 - 1) * columnsA + j] = c * array3[(num7 - 1) * columnsA + j] - s2 * array3[num17 * columnsA + j];
								array3[num17 * columnsA + j] = complex9;
							}
						}
					}
					break;
				}
				case 2:
				{
					float db = array2[i - 1].Real;
					array2[i - 1] = 0f;
					for (int num17 = i; num17 < num7; num17++)
					{
						float da = array4[num17].Real;
						Drotg(ref da, ref db, out c, out s2);
						array4[num17] = da;
						db = (0f - s2) * array2[num17].Real;
						array2[num17] = c * array2[num17];
						if (computeVectors)
						{
							for (int j = 0; j < rowsA; j++)
							{
								Complex32 complex6 = c * u[num17 * rowsA + j] + s2 * u[(i - 1) * rowsA + j];
								u[(i - 1) * rowsA + j] = c * u[(i - 1) * rowsA + j] - s2 * u[num17 * rowsA + j];
								u[num17 * rowsA + j] = complex6;
							}
						}
					}
					break;
				}
				case 3:
				{
					float val = 0f;
					val = Math.Max(val, array4[num7 - 1].Magnitude);
					val = Math.Max(val, array4[num7 - 2].Magnitude);
					val = Math.Max(val, array2[num7 - 2].Magnitude);
					val = Math.Max(val, array4[i].Magnitude);
					val = Math.Max(val, array2[i].Magnitude);
					float num18 = array4[num7 - 1].Real / val;
					float num19 = array4[num7 - 2].Real / val;
					float num20 = array2[num7 - 2].Real / val;
					float num21 = array4[i].Real / val;
					float num22 = array2[i].Real / val;
					float num23 = ((num19 + num18) * (num19 - num18) + num20 * num20) / 2f;
					float num24 = num18 * num20 * (num18 * num20);
					float num25 = 0f;
					if (num23 != 0f || num24 != 0f)
					{
						num25 = (float)Math.Sqrt(num23 * num23 + num24);
						if (num23 < 0f)
						{
							num25 = 0f - num25;
						}
						num25 = num24 / (num23 + num25);
					}
					float db = (num21 + num18) * (num21 - num18) + num25;
					float db2 = num21 * num22;
					for (int num17 = i; num17 < num7 - 1; num17++)
					{
						Drotg(ref db, ref db2, out c, out s2);
						if (num17 != i)
						{
							array2[num17 - 1] = db;
						}
						db = c * array4[num17].Real + s2 * array2[num17].Real;
						array2[num17] = c * array2[num17] - s2 * array4[num17];
						db2 = s2 * array4[num17 + 1].Real;
						array4[num17 + 1] = c * array4[num17 + 1];
						if (computeVectors)
						{
							for (int j = 0; j < columnsA; j++)
							{
								Complex32 complex7 = c * array3[num17 * columnsA + j] + s2 * array3[(num17 + 1) * columnsA + j];
								array3[(num17 + 1) * columnsA + j] = c * array3[(num17 + 1) * columnsA + j] - s2 * array3[num17 * columnsA + j];
								array3[num17 * columnsA + j] = complex7;
							}
						}
						Drotg(ref db, ref db2, out c, out s2);
						array4[num17] = db;
						db = c * array2[num17].Real + s2 * array4[num17 + 1].Real;
						array4[num17 + 1] = -(s2 * array2[num17]) + c * array4[num17 + 1];
						db2 = s2 * array2[num17 + 1].Real;
						array2[num17 + 1] = c * array2[num17 + 1];
						if (computeVectors && num17 < rowsA)
						{
							for (int j = 0; j < rowsA; j++)
							{
								Complex32 complex8 = c * u[num17 * rowsA + j] + s2 * u[(num17 + 1) * rowsA + j];
								u[(num17 + 1) * rowsA + j] = c * u[(num17 + 1) * rowsA + j] - s2 * u[num17 * rowsA + j];
								u[num17 * rowsA + j] = complex8;
							}
						}
					}
					array2[num7 - 2] = db;
					num13++;
					break;
				}
				case 4:
					if (array4[i].Real < 0f)
					{
						array4[i] = -array4[i];
						if (computeVectors)
						{
							for (int j = 0; j < columnsA; j++)
							{
								array3[i * columnsA + j] *= -1f;
							}
						}
					}
					for (; i != num12 - 1 && !(array4[i].Real >= array4[i + 1].Real); i++)
					{
						Complex32 complex = array4[i];
						array4[i] = array4[i + 1];
						array4[i + 1] = complex;
						if (computeVectors && i < columnsA)
						{
							for (int j = 0; j < columnsA; j++)
							{
								ref Complex32 reference = ref array3[i * columnsA + j];
								ref Complex32 reference2 = ref array3[(i + 1) * columnsA + j];
								Complex32 complex4 = array3[(i + 1) * columnsA + j];
								Complex32 complex5 = array3[i * columnsA + j];
								reference = complex4;
								reference2 = complex5;
							}
						}
						if (computeVectors && i < rowsA)
						{
							for (int j = 0; j < rowsA; j++)
							{
								ref Complex32 reference = ref u[i * rowsA + j];
								ref Complex32 reference3 = ref u[(i + 1) * rowsA + j];
								Complex32 complex5 = u[(i + 1) * rowsA + j];
								Complex32 complex4 = u[i * rowsA + j];
								reference = complex5;
								reference3 = complex4;
							}
						}
					}
					num13 = 0;
					num7--;
					break;
				}
			}
			if (computeVectors)
			{
				for (int j = 0; j < columnsA; j++)
				{
					for (int k = 0; k < columnsA; k++)
					{
						vt[k * columnsA + j] = array3[j * columnsA + k].Conjugate();
					}
				}
			}
			Array.Copy(array4, 0, s, 0, Math.Min(rowsA, columnsA));
		}

		public void SvdSolve(Complex32[] a, int rowsA, int columnsA, Complex32[] b, int columnsB, Complex32[] x)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (b.Length != rowsA * columnsB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			if (x.Length != columnsA * columnsB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			Complex32[] s = new Complex32[Math.Min(rowsA, columnsA)];
			Complex32[] u = new Complex32[rowsA * rowsA];
			Complex32[] vt = new Complex32[columnsA * columnsA];
			Complex32[] array = new Complex32[a.Length];
			a.Copy(array);
			SingularValueDecomposition(computeVectors: true, array, rowsA, columnsA, s, u, vt);
			SvdSolveFactored(rowsA, columnsA, s, u, vt, b, columnsB, x);
		}

		public void SvdSolveFactored(int rowsA, int columnsA, Complex32[] s, Complex32[] u, Complex32[] vt, Complex32[] b, int columnsB, Complex32[] x)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			if (u == null)
			{
				throw new ArgumentNullException("u");
			}
			if (vt == null)
			{
				throw new ArgumentNullException("vt");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (u.Length != rowsA * rowsA)
			{
				throw new ArgumentException("The array arguments must have the same length.", "u");
			}
			if (vt.Length != columnsA * columnsA)
			{
				throw new ArgumentException("The array arguments must have the same length.", "vt");
			}
			if (s.Length != Math.Min(rowsA, columnsA))
			{
				throw new ArgumentException("The array arguments must have the same length.", "s");
			}
			if (b.Length != rowsA * columnsB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			if (x.Length != columnsA * columnsB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			int num = Math.Min(rowsA, columnsA);
			Complex32[] array = new Complex32[columnsA];
			for (int i = 0; i < columnsB; i++)
			{
				for (int j = 0; j < columnsA; j++)
				{
					Complex32 zero = Complex32.Zero;
					if (j < num)
					{
						for (int k = 0; k < rowsA; k++)
						{
							zero += u[j * rowsA + k].Conjugate() * b[i * rowsA + k];
						}
						zero /= s[j];
					}
					array[j] = zero;
				}
				for (int l = 0; l < columnsA; l++)
				{
					Complex32 zero2 = Complex32.Zero;
					for (int m = 0; m < columnsA; m++)
					{
						zero2 += vt[l * columnsA + m].Conjugate() * array[m];
					}
					x[i * columnsA + l] = zero2;
				}
			}
		}

		public void EigenDecomp(bool isSymmetric, int order, Complex32[] matrix, Complex32[] matrixEv, Complex[] vectorEv, Complex32[] matrixD)
		{
			if (matrix == null)
			{
				throw new ArgumentNullException("matrix");
			}
			if (matrix.Length != order * order)
			{
				throw new ArgumentException($"The given array has the wrong length. Should be {order * order}.", "matrix");
			}
			if (matrixEv == null)
			{
				throw new ArgumentNullException("matrixEv");
			}
			if (matrixEv.Length != order * order)
			{
				throw new ArgumentException($"The given array has the wrong length. Should be {order * order}.", "matrixEv");
			}
			if (vectorEv == null)
			{
				throw new ArgumentNullException("vectorEv");
			}
			if (vectorEv.Length != order)
			{
				throw new ArgumentException($"The given array has the wrong length. Should be {order}.", "vectorEv");
			}
			if (matrixD == null)
			{
				throw new ArgumentNullException("matrixD");
			}
			if (matrixD.Length != order * order)
			{
				throw new ArgumentException($"The given array has the wrong length. Should be {order * order}.", "matrixD");
			}
			Complex32[] array = new Complex32[matrix.Length];
			Array.Copy(matrix, 0, array, 0, matrix.Length);
			if (isSymmetric)
			{
				Complex32[] tau = new Complex32[order];
				float[] array2 = new float[order];
				float[] array3 = new float[order];
				SymmetricTridiagonalize(array, array2, array3, tau, order);
				SymmetricDiagonalize(matrixEv, array2, array3, order);
				SymmetricUntridiagonalize(matrixEv, array, tau, order);
				for (int i = 0; i < order; i++)
				{
					vectorEv[i] = new Complex(array2[i], array3[i]);
					matrixD[i * order + i] = new Complex32(array2[i], array3[i]);
				}
			}
			else
			{
				Complex32[] array4 = new Complex32[order];
				NonsymmetricReduceToHessenberg(matrixEv, array, order);
				NonsymmetricReduceHessenberToRealSchur(array4, matrixEv, array, order);
				for (int j = 0; j < order; j++)
				{
					vectorEv[j] = new Complex(array4[j].Real, array4[j].Imaginary);
					matrixD[j * order + j] = array4[j];
				}
			}
		}

		internal static void SymmetricTridiagonalize(Complex32[] matrixA, float[] d, float[] e, Complex32[] tau, int order)
		{
			tau[order - 1] = Complex32.One;
			for (int i = 0; i < order; i++)
			{
				d[i] = matrixA[i * order + i].Real;
			}
			float num6;
			for (int num = order - 1; num > 0; num--)
			{
				float num2 = 0f;
				float num3 = 0f;
				for (int j = 0; j < num; j++)
				{
					num2 = num2 + Math.Abs(matrixA[j * order + num].Real) + Math.Abs(matrixA[j * order + num].Imaginary);
				}
				if (num2 == 0f)
				{
					tau[num - 1] = Complex32.One;
					e[num] = 0f;
				}
				else
				{
					for (int k = 0; k < num; k++)
					{
						matrixA[k * order + num] /= num2;
						num3 += matrixA[k * order + num].MagnitudeSquared;
					}
					Complex32 complex = (float)Math.Sqrt(num3);
					e[num] = num2 * complex.Real;
					int num4 = (num - 1) * order + num;
					Complex32 complex2 = matrixA[num4];
					Complex32 complex3;
					if (complex2.Magnitude != 0f)
					{
						complex3 = -(matrixA[num4].Conjugate() * tau[num].Conjugate()) / complex2.Magnitude;
						num3 += complex2.Magnitude * complex.Real;
						complex = 1f + complex / complex2.Magnitude;
						matrixA[num4] *= complex;
					}
					else
					{
						complex3 = -tau[num].Conjugate();
						matrixA[num4] = complex;
					}
					if (complex2.Magnitude == 0f || num != 1)
					{
						complex2 = Complex32.Zero;
						for (int l = 0; l < num; l++)
						{
							Complex32 zero = Complex32.Zero;
							int num5 = l * order;
							for (int m = 0; m <= l; m++)
							{
								zero += matrixA[m * order + l] * matrixA[m * order + num].Conjugate();
							}
							for (int n = l + 1; n <= num - 1; n++)
							{
								zero += matrixA[num5 + n].Conjugate() * matrixA[n * order + num].Conjugate();
							}
							tau[l] = zero / num3;
							complex2 += zero / num3 * matrixA[num5 + num];
						}
						num6 = complex2.Real / (num3 + num3);
						for (int num7 = 0; num7 < num; num7++)
						{
							complex2 = matrixA[num7 * order + num].Conjugate();
							complex = tau[num7] - num6 * complex2;
							tau[num7] = complex.Conjugate();
							for (int num8 = 0; num8 <= num7; num8++)
							{
								matrixA[num8 * order + num7] -= complex2 * tau[num8] + complex * matrixA[num8 * order + num];
							}
						}
					}
					for (int num9 = 0; num9 < num; num9++)
					{
						matrixA[num9 * order + num] *= num2;
					}
					tau[num - 1] = complex3.Conjugate();
				}
				num6 = d[num];
				d[num] = matrixA[num * order + num].Real;
				matrixA[num * order + num] = new Complex32(num6, num2 * (float)Math.Sqrt(num3));
			}
			num6 = d[0];
			d[0] = matrixA[0].Real;
			matrixA[0] = num6;
			e[0] = 0f;
		}

		internal static void SymmetricDiagonalize(Complex32[] dataEv, float[] d, float[] e, int order)
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
								num8 = dataEv[(num15 + 1) * order + m].Real;
								dataEv[(num15 + 1) * order + m] = num13 * dataEv[num15 * order + m].Real + num9 * num8;
								dataEv[num15 * order + m] = num9 * dataEv[num15 * order + m].Real - num13 * num8;
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
						num17 = dataEv[n * order + num19].Real;
						dataEv[n * order + num19] = dataEv[num16 * order + num19];
						dataEv[num16 * order + num19] = num17;
					}
				}
			}
		}

		internal static void SymmetricUntridiagonalize(Complex32[] dataEv, Complex32[] matrixA, Complex32[] tau, int order)
		{
			for (int i = 0; i < order; i++)
			{
				for (int j = 0; j < order; j++)
				{
					dataEv[j * order + i] = dataEv[j * order + i].Real * tau[i].Conjugate();
				}
			}
			for (int k = 1; k < order; k++)
			{
				float imaginary = matrixA[k * order + k].Imaginary;
				if (imaginary == 0f)
				{
					continue;
				}
				for (int l = 0; l < order; l++)
				{
					Complex32 zero = Complex32.Zero;
					for (int m = 0; m < k; m++)
					{
						zero += dataEv[l * order + m] * matrixA[m * order + k];
					}
					zero = zero / imaginary / imaginary;
					for (int n = 0; n < k; n++)
					{
						dataEv[l * order + n] -= zero * matrixA[n * order + k].Conjugate();
					}
				}
			}
		}

		internal static void NonsymmetricReduceToHessenberg(Complex32[] dataEv, Complex32[] matrixH, int order)
		{
			Complex32[] array = new Complex32[order];
			for (int i = 1; i < order - 1; i++)
			{
				float num = 0f;
				int num2 = (i - 1) * order;
				for (int j = i; j < order; j++)
				{
					num += Math.Abs(matrixH[num2 + j].Real) + Math.Abs(matrixH[num2 + j].Imaginary);
				}
				if (num == 0f)
				{
					continue;
				}
				float num3 = 0f;
				for (int num4 = order - 1; num4 >= i; num4--)
				{
					array[num4] = matrixH[num2 + num4] / num;
					num3 += array[num4].MagnitudeSquared;
				}
				float num5 = (float)Math.Sqrt(num3);
				if (array[i].Magnitude != 0f)
				{
					num3 += array[i].Magnitude * num5;
					num5 /= array[i].Magnitude;
					array[i] = (1f + num5) * array[i];
				}
				else
				{
					array[i] = num5;
					matrixH[num2 + i] = num;
				}
				for (int k = i; k < order; k++)
				{
					Complex32 zero = Complex32.Zero;
					int num6 = k * order;
					for (int num7 = order - 1; num7 >= i; num7--)
					{
						zero += array[num7].Conjugate() * matrixH[num6 + num7];
					}
					zero /= num3;
					for (int l = i; l < order; l++)
					{
						matrixH[num6 + l] -= zero * array[l];
					}
				}
				for (int m = 0; m < order; m++)
				{
					Complex32 zero2 = Complex32.Zero;
					for (int num8 = order - 1; num8 >= i; num8--)
					{
						zero2 += array[num8] * matrixH[num8 * order + m];
					}
					zero2 /= num3;
					for (int n = i; n < order; n++)
					{
						matrixH[n * order + m] -= zero2 * array[n].Conjugate();
					}
				}
				array[i] = num * array[i];
				matrixH[num2 + i] *= 0f - num5;
			}
			for (int num9 = 0; num9 < order; num9++)
			{
				for (int num10 = 0; num10 < order; num10++)
				{
					dataEv[num10 * order + num9] = ((num9 == num10) ? Complex32.One : Complex32.Zero);
				}
			}
			for (int num11 = order - 2; num11 >= 1; num11--)
			{
				int num12 = (num11 - 1) * order;
				int num13 = num12 + num11;
				if (matrixH[num13] != Complex32.Zero && array[num11] != Complex32.Zero)
				{
					float num14 = matrixH[num13].Real * array[num11].Real + matrixH[num13].Imaginary * array[num11].Imaginary;
					for (int num15 = num11 + 1; num15 < order; num15++)
					{
						array[num15] = matrixH[num12 + num15];
					}
					for (int num16 = num11; num16 < order; num16++)
					{
						Complex32 zero3 = Complex32.Zero;
						for (int num17 = num11; num17 < order; num17++)
						{
							zero3 += array[num17].Conjugate() * dataEv[num16 * order + num17];
						}
						zero3 /= num14;
						for (int num18 = num11; num18 < order; num18++)
						{
							dataEv[num16 * order + num18] += zero3 * array[num18];
						}
					}
				}
			}
			for (int num19 = 1; num19 < order; num19++)
			{
				int num20 = (num19 - 1) * order + num19;
				int num21 = num19 * order;
				if (matrixH[num20].Imaginary != 0f)
				{
					Complex32 complex = matrixH[num20] / matrixH[num20].Magnitude;
					matrixH[num20] = matrixH[num20].Magnitude;
					for (int num22 = num19; num22 < order; num22++)
					{
						matrixH[num22 * order + num19] *= complex.Conjugate();
					}
					for (int num23 = 0; num23 <= Math.Min(num19 + 1, order - 1); num23++)
					{
						matrixH[num21 + num23] *= complex;
					}
					for (int num24 = 0; num24 < order; num24++)
					{
						dataEv[num19 * order + num24] *= complex;
					}
				}
			}
		}

		internal static void NonsymmetricReduceHessenberToRealSchur(Complex32[] vectorV, Complex32[] dataEv, Complex32[] matrixH, int order)
		{
			int num = order - 1;
			float num2 = (float)Precision.SinglePrecision;
			Complex32 zero = Complex32.Zero;
			int num3 = 0;
			float num16;
			while (num >= 0)
			{
				int num4;
				for (num4 = num; num4 > 0; num4--)
				{
					int num5 = num4 - 1;
					int num6 = num5 * order;
					int num7 = num4 * order;
					float num8 = Math.Abs(matrixH[num6 + num5].Real) + Math.Abs(matrixH[num6 + num5].Imaginary) + Math.Abs(matrixH[num7 + num4].Real) + Math.Abs(matrixH[num7 + num4].Imaginary);
					if (Math.Abs(matrixH[num6 + num4].Real) < num2 * num8)
					{
						break;
					}
				}
				int num9 = num - 1;
				int num10 = num9 * order;
				int num11 = num * order;
				int num12 = num11 + num;
				if (num4 == num)
				{
					matrixH[num12] += zero;
					vectorV[num] = matrixH[num12];
					num--;
					num3 = 0;
					continue;
				}
				Complex32 complex;
				if (num3 != 10 && num3 != 20)
				{
					complex = matrixH[num12];
					Complex32 complex2 = matrixH[num11 + num9] * matrixH[num10 + num].Real;
					if (complex2.Real != 0f || complex2.Imaginary != 0f)
					{
						Complex32 complex3 = (matrixH[num10 + num9] - complex) / 2f;
						Complex32 complex4 = (complex3 * complex3 + complex2).SquareRoot();
						if ((double)(complex3.Real * complex4.Real + complex3.Imaginary * complex4.Imaginary) < 0.0)
						{
							complex4 *= -1f;
						}
						complex2 /= complex3 + complex4;
						complex -= complex2;
					}
				}
				else
				{
					complex = Math.Abs(matrixH[num10 + num].Real) + Math.Abs(matrixH[(num - 2) * order + num9].Real);
				}
				for (int i = 0; i <= num; i++)
				{
					matrixH[i * order + i] -= complex;
				}
				zero += complex;
				num3++;
				for (int j = num4 + 1; j <= num; j++)
				{
					int num13 = j - 1;
					int num14 = num13 * order;
					int num15 = num14 + num13;
					complex = matrixH[num14 + j].Real;
					num16 = SpecialFunctions.Hypotenuse(matrixH[num15].Magnitude, complex.Real);
					Complex32 complex2 = (vectorV[j - 1] = matrixH[num15] / num16);
					matrixH[num15] = num16;
					matrixH[num14 + j] = new Complex32(0f, complex.Real / num16);
					for (int k = j; k < order; k++)
					{
						int num17 = k * order;
						Complex32 complex3 = matrixH[num17 + num13];
						Complex32 complex4 = matrixH[num17 + j];
						matrixH[num17 + num13] = complex2.Conjugate() * complex3 + matrixH[num14 + j].Imaginary * complex4;
						matrixH[num17 + j] = complex2 * complex4 - matrixH[num14 + j].Imaginary * complex3;
					}
				}
				complex = matrixH[num12];
				if (complex.Imaginary != 0f)
				{
					complex /= matrixH[num12].Magnitude;
					matrixH[num12] = matrixH[num12].Magnitude;
					for (int l = num + 1; l < order; l++)
					{
						matrixH[l * order + num] *= complex.Conjugate();
					}
				}
				for (int m = num4 + 1; m <= num; m++)
				{
					Complex32 complex2 = vectorV[m - 1];
					int num18 = m * order;
					int num19 = (m - 1) * order;
					int num20 = num19 + m;
					for (int n = 0; n <= m; n++)
					{
						int num21 = num19 + n;
						Complex32 complex4 = matrixH[num18 + n];
						Complex32 complex3;
						if (n != m)
						{
							complex3 = matrixH[num21];
							matrixH[num21] = complex2 * complex3 + matrixH[num19 + m].Imaginary * complex4;
						}
						else
						{
							complex3 = matrixH[num21].Real;
							matrixH[num21] = new Complex32(complex2.Real * complex3.Real - complex2.Imaginary * complex3.Imaginary + matrixH[num19 + m].Imaginary * complex4.Real, matrixH[num21].Imaginary);
						}
						matrixH[num18 + n] = complex2.Conjugate() * complex4 - matrixH[num19 + m].Imaginary * complex3;
					}
					for (int num22 = 0; num22 < order; num22++)
					{
						Complex32 complex3 = dataEv[(m - 1) * order + num22];
						Complex32 complex4 = dataEv[m * order + num22];
						dataEv[num19 + num22] = complex2 * complex3 + matrixH[num20].Imaginary * complex4;
						dataEv[num18 + num22] = complex2.Conjugate() * complex4 - matrixH[num20].Imaginary * complex3;
					}
				}
				if (complex.Imaginary != 0f)
				{
					for (int num23 = 0; num23 <= num; num23++)
					{
						matrixH[num11 + num23] *= complex;
					}
					for (int num24 = 0; num24 < order; num24++)
					{
						dataEv[num11 + num24] *= complex;
					}
				}
			}
			num16 = 0f;
			for (int num25 = 0; num25 < order; num25++)
			{
				for (int num26 = num25; num26 < order; num26++)
				{
					num16 = Math.Max(num16, Math.Abs(matrixH[num26 * order + num25].Real) + Math.Abs(matrixH[num26 * order + num25].Imaginary));
				}
			}
			if (order == 1 || (double)num16 == 0.0)
			{
				return;
			}
			for (num = order - 1; num > 0; num--)
			{
				int num27 = num * order;
				int num28 = num27 + num;
				Complex32 complex2 = vectorV[num];
				matrixH[num28] = 1f;
				for (int num29 = num - 1; num29 >= 0; num29--)
				{
					Complex32 complex4 = 0f;
					for (int num30 = num29 + 1; num30 <= num; num30++)
					{
						complex4 += matrixH[num30 * order + num29] * matrixH[num27 + num30];
					}
					Complex32 complex3 = complex2 - vectorV[num29];
					if (complex3.Real == 0f && complex3.Imaginary == 0f)
					{
						complex3 = num2 * num16;
					}
					matrixH[num27 + num29] = complex4 / complex3;
					float num31 = Math.Abs(matrixH[num27 + num29].Real) + Math.Abs(matrixH[num27 + num29].Imaginary);
					if (num2 * num31 * num31 > 1f)
					{
						for (int num32 = num29; num32 <= num; num32++)
						{
							matrixH[num27 + num32] /= num31;
						}
					}
				}
			}
			for (int num33 = order - 1; num33 > 0; num33--)
			{
				int num34 = num33 * order;
				for (int num35 = 0; num35 < order; num35++)
				{
					Complex32 complex4 = Complex32.Zero;
					for (int num36 = 0; num36 <= num33; num36++)
					{
						complex4 += dataEv[num36 * order + num35] * matrixH[num34 + num36];
					}
					dataEv[num34 + num35] = complex4;
				}
			}
		}

		private static void GetRow(Transpose transpose, int rowindx, int numRows, int numCols, Complex32[] matrix, Complex32[] row)
		{
			switch (transpose)
			{
			case Transpose.DontTranspose:
			{
				for (int j = 0; j < numCols; j++)
				{
					row[j] = matrix[j * numRows + rowindx];
				}
				break;
			}
			case Transpose.ConjugateTranspose:
			{
				int num = rowindx * numCols;
				for (int i = 0; i < row.Length; i++)
				{
					row[i] = matrix[i + num].Conjugate();
				}
				break;
			}
			default:
				Array.Copy(matrix, rowindx * numCols, row, 0, numCols);
				break;
			}
		}

		private static void GetColumn(Transpose transpose, int colindx, int numRows, int numCols, Complex32[] matrix, Complex32[] column)
		{
			switch (transpose)
			{
			case Transpose.DontTranspose:
				Array.Copy(matrix, colindx * numRows, column, 0, numRows);
				break;
			case Transpose.ConjugateTranspose:
			{
				for (int j = 0; j < numRows; j++)
				{
					column[j] = matrix[j * numCols + colindx].Conjugate();
				}
				break;
			}
			default:
			{
				for (int i = 0; i < numRows; i++)
				{
					column[i] = matrix[i * numCols + colindx];
				}
				break;
			}
			}
		}

		public bool IsAvailable()
		{
			return true;
		}

		public void InitializeVerify()
		{
		}

		public void FreeResources()
		{
		}

		public override string ToString()
		{
			return "Managed";
		}

		private static void GetRow<T>(Transpose transpose, int rowindx, int numRows, int numCols, T[] matrix, T[] row)
		{
			if (transpose == Transpose.DontTranspose)
			{
				for (int i = 0; i < numCols; i++)
				{
					row[i] = matrix[i * numRows + rowindx];
				}
			}
			else
			{
				Array.Copy(matrix, rowindx * numCols, row, 0, numCols);
			}
		}

		private static void GetColumn<T>(Transpose transpose, int colindx, int numRows, int numCols, T[] matrix, T[] column)
		{
			if (transpose == Transpose.DontTranspose)
			{
				Array.Copy(matrix, colindx * numRows, column, 0, numRows);
				return;
			}
			for (int i = 0; i < numRows; i++)
			{
				column[i] = matrix[i * numCols + colindx];
			}
		}

		public void AddVectorToScaledVector(double[] y, double alpha, double[] x, double[] result)
		{
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (y.Length != x.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (alpha == 0.0)
			{
				y.Copy(result);
			}
			else if (alpha == 1.0)
			{
				for (int i = 0; i < result.Length; i++)
				{
					result[i] = y[i] + x[i];
				}
			}
			else
			{
				for (int j = 0; j < result.Length; j++)
				{
					result[j] = y[j] + alpha * x[j];
				}
			}
		}

		public void ScaleArray(double alpha, double[] x, double[] result)
		{
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (alpha == 0.0)
			{
				Array.Clear(result, 0, result.Length);
				return;
			}
			if (alpha == 1.0)
			{
				x.Copy(result);
				return;
			}
			for (int i = 0; i < result.Length; i++)
			{
				result[i] = alpha * x[i];
			}
		}

		public void ConjugateArray(double[] x, double[] result)
		{
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (x != result)
			{
				x.CopyTo(result, 0);
			}
		}

		public double DotProduct(double[] x, double[] y)
		{
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (y.Length != x.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			double num = 0.0;
			for (int i = 0; i < y.Length; i++)
			{
				num += y[i] * x[i];
			}
			return num;
		}

		public void AddArrays(double[] x, double[] y, double[] result)
		{
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (y.Length != x.Length || y.Length != result.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			for (int i = 0; i < result.Length; i++)
			{
				result[i] = x[i] + y[i];
			}
		}

		public void SubtractArrays(double[] x, double[] y, double[] result)
		{
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (y.Length != x.Length || y.Length != result.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			for (int i = 0; i < result.Length; i++)
			{
				result[i] = x[i] - y[i];
			}
		}

		public void PointWiseMultiplyArrays(double[] x, double[] y, double[] result)
		{
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (y.Length != x.Length || y.Length != result.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			for (int i = 0; i < result.Length; i++)
			{
				result[i] = x[i] * y[i];
			}
		}

		public void PointWiseDivideArrays(double[] x, double[] y, double[] result)
		{
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (y.Length != x.Length || y.Length != result.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			CommonParallel.For(0, y.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					result[i] = x[i] / y[i];
				}
			});
		}

		public void PointWisePowerArrays(double[] x, double[] y, double[] result)
		{
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (y.Length != x.Length || y.Length != result.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			CommonParallel.For(0, y.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					result[i] = Math.Pow(x[i], y[i]);
				}
			});
		}

		public double MatrixNorm(Norm norm, int rows, int columns, double[] matrix)
		{
			switch (norm)
			{
			case Norm.OneNorm:
			{
				double num3 = 0.0;
				for (int l = 0; l < columns; l++)
				{
					double num4 = 0.0;
					for (int m = 0; m < rows; m++)
					{
						num4 += Math.Abs(matrix[l * rows + m]);
					}
					num3 = Math.Max(num3, num4);
				}
				return num3;
			}
			case Norm.LargestAbsoluteValue:
			{
				double num2 = 0.0;
				for (int j = 0; j < columns; j++)
				{
					for (int k = 0; k < rows; k++)
					{
						num2 = Math.Max(Math.Abs(matrix[j * rows + k]), num2);
					}
				}
				return num2;
			}
			case Norm.InfinityNorm:
			{
				double[] array2 = new double[rows];
				for (int n = 0; n < columns; n++)
				{
					for (int num5 = 0; num5 < rows; num5++)
					{
						array2[num5] += Math.Abs(matrix[n * rows + num5]);
					}
				}
				double num6 = array2[0];
				for (int num7 = 0; num7 < array2.Length; num7++)
				{
					if (array2[num7] > num6)
					{
						num6 = array2[num7];
					}
				}
				return num6;
			}
			case Norm.FrobeniusNorm:
			{
				double[] array = new double[rows * rows];
				MatrixMultiplyWithUpdate(Transpose.DontTranspose, Transpose.Transpose, 1.0, matrix, rows, columns, matrix, rows, columns, 0.0, array);
				double num = 0.0;
				for (int i = 0; i < rows; i++)
				{
					num += Math.Abs(array[i * rows + i]);
				}
				return Math.Sqrt(num);
			}
			default:
				throw new NotSupportedException();
			}
		}

		public void MatrixMultiply(double[] x, int rowsX, int columnsX, double[] y, int rowsY, int columnsY, double[] result)
		{
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (columnsX != rowsY)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"columnsA ({columnsX}) != rowsB ({rowsY})"));
			}
			if (rowsX * columnsX != x.Length)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"rowsA ({rowsX}) * columnsA ({columnsX}) != a.Length ({x.Length})"));
			}
			if (rowsY * columnsY != y.Length)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"rowsB ({rowsY}) * columnsB ({columnsY}) != b.Length ({y.Length})"));
			}
			if (rowsX * columnsY != result.Length)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"rowsA ({rowsX}) * columnsB ({columnsY}) != c.Length ({result.Length})"));
			}
			Array.Clear(result, 0, result.Length);
			double[][] columnDataB = new double[columnsY][];
			for (int i = 0; i < columnDataB.Length; i++)
			{
				double[] array = new double[rowsY];
				GetColumn(Transpose.DontTranspose, i, rowsY, columnsY, y, array);
				columnDataB[i] = array;
			}
			if (rowsX + columnsY + columnsX < Control.ParallelizeOrder || Control.MaxDegreeOfParallelism < 2)
			{
				double[] array2 = new double[columnsX];
				for (int j = 0; j < rowsX; j++)
				{
					GetRow(Transpose.DontTranspose, j, rowsX, columnsX, x, array2);
					for (int k = 0; k < columnsY; k++)
					{
						double[] array3 = columnDataB[k];
						double num = 0.0;
						for (int l = 0; l < array2.Length; l++)
						{
							num += array2[l] * array3[l];
						}
						result[k * rowsX + j] += 1.0 * num;
					}
				}
				return;
			}
			CommonParallel.For(0, rowsX, 1, delegate(int u, int v)
			{
				double[] array4 = new double[columnsX];
				for (int m = u; m < v; m++)
				{
					GetRow(Transpose.DontTranspose, m, rowsX, columnsX, x, array4);
					for (int n = 0; n < columnsY; n++)
					{
						double[] array5 = columnDataB[n];
						double num2 = 0.0;
						for (int num3 = 0; num3 < array4.Length; num3++)
						{
							num2 += array4[num3] * array5[num3];
						}
						result[n * rowsX + m] += 1.0 * num2;
					}
				}
			});
		}

		public void MatrixMultiplyWithUpdate(Transpose transposeA, Transpose transposeB, double alpha, double[] a, int rowsA, int columnsA, double[] b, int rowsB, int columnsB, double beta, double[] c)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (c == null)
			{
				throw new ArgumentNullException("c");
			}
			if (transposeA != Transpose.DontTranspose)
			{
				int num = columnsA;
				int num2 = rowsA;
				columnsA = num2;
				rowsA = num;
			}
			if (transposeB != Transpose.DontTranspose)
			{
				int num3 = columnsB;
				int num2 = rowsB;
				columnsB = num2;
				rowsB = num3;
			}
			if (columnsA != rowsB)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"columnsA ({columnsA}) != rowsB ({rowsB})"));
			}
			if (rowsA * columnsA != a.Length)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"rowsA ({rowsA}) * columnsA ({columnsA}) != a.Length ({a.Length})"));
			}
			if (rowsB * columnsB != b.Length)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"rowsB ({rowsB}) * columnsB ({columnsB}) != b.Length ({b.Length})"));
			}
			if (rowsA * columnsB != c.Length)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"rowsA ({rowsA}) * columnsB ({columnsB}) != c.Length ({c.Length})"));
			}
			if (beta == 0.0)
			{
				Array.Clear(c, 0, c.Length);
			}
			else if (beta != 1.0)
			{
				ScaleArray(beta, c, c);
			}
			if (alpha == 0.0)
			{
				return;
			}
			double[][] columnDataB = new double[columnsB][];
			for (int i = 0; i < columnDataB.Length; i++)
			{
				double[] array = new double[rowsB];
				GetColumn(transposeB, i, rowsB, columnsB, b, array);
				columnDataB[i] = array;
			}
			if (rowsA + columnsB + columnsA < Control.ParallelizeOrder || Control.MaxDegreeOfParallelism < 2)
			{
				double[] array2 = new double[columnsA];
				for (int j = 0; j < rowsA; j++)
				{
					GetRow(transposeA, j, rowsA, columnsA, a, array2);
					for (int k = 0; k < columnsB; k++)
					{
						double[] array3 = columnDataB[k];
						double num4 = 0.0;
						for (int l = 0; l < array2.Length; l++)
						{
							num4 += array2[l] * array3[l];
						}
						c[k * rowsA + j] += alpha * num4;
					}
				}
				return;
			}
			CommonParallel.For(0, rowsA, 1, delegate(int u, int v)
			{
				double[] array4 = new double[columnsA];
				for (int m = u; m < v; m++)
				{
					GetRow(transposeA, m, rowsA, columnsA, a, array4);
					for (int n = 0; n < columnsB; n++)
					{
						double[] array5 = columnDataB[n];
						double num5 = 0.0;
						for (int num6 = 0; num6 < array4.Length; num6++)
						{
							num5 += array4[num6] * array5[num6];
						}
						c[n * rowsA + m] += alpha * num5;
					}
				}
			});
		}

		public void LUFactor(double[] data, int order, int[] ipiv)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (ipiv == null)
			{
				throw new ArgumentNullException("ipiv");
			}
			if (data.Length != order * order)
			{
				throw new ArgumentException("The array arguments must have the same length.", "data");
			}
			if (ipiv.Length != order)
			{
				throw new ArgumentException("The array arguments must have the same length.", "ipiv");
			}
			for (int i = 0; i < order; i++)
			{
				ipiv[i] = i;
			}
			double[] array = new double[order];
			for (int j = 0; j < order; j++)
			{
				int num = j * order;
				int num2 = num + j;
				for (int k = 0; k < order; k++)
				{
					array[k] = data[num + k];
				}
				for (int l = 0; l < order; l++)
				{
					int num3 = Math.Min(l, j);
					double num4 = 0.0;
					for (int m = 0; m < num3; m++)
					{
						num4 += data[m * order + l] * array[m];
					}
					data[num + l] = (array[l] -= num4);
				}
				int num5 = j;
				for (int n = j + 1; n < order; n++)
				{
					if (Math.Abs(array[n]) > Math.Abs(array[num5]))
					{
						num5 = n;
					}
				}
				if (num5 != j)
				{
					for (int num6 = 0; num6 < order; num6++)
					{
						int num7 = num6 * order;
						int num8 = num7 + num5;
						int num9 = num7 + j;
						ref double reference = ref data[num8];
						ref double reference2 = ref data[num9];
						double num10 = data[num9];
						double num11 = data[num8];
						reference = num10;
						reference2 = num11;
					}
					ipiv[j] = num5;
				}
				if ((j < order) & (data[num2] != 0.0))
				{
					for (int num12 = j + 1; num12 < order; num12++)
					{
						data[num + num12] /= data[num2];
					}
				}
			}
		}

		public void LUInverse(double[] a, int order)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (a.Length != order * order)
			{
				throw new ArgumentException("The array arguments must have the same length.", "a");
			}
			int[] ipiv = new int[order];
			LUFactor(a, order, ipiv);
			LUInverseFactored(a, order, ipiv);
		}

		public void LUInverseFactored(double[] a, int order, int[] ipiv)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (ipiv == null)
			{
				throw new ArgumentNullException("ipiv");
			}
			if (a.Length != order * order)
			{
				throw new ArgumentException("The array arguments must have the same length.", "a");
			}
			if (ipiv.Length != order)
			{
				throw new ArgumentException("The array arguments must have the same length.", "ipiv");
			}
			double[] array = new double[a.Length];
			for (int i = 0; i < order; i++)
			{
				array[i + order * i] = 1.0;
			}
			LUSolveFactored(order, a, order, ipiv, array);
			array.Copy(a);
		}

		public void LUSolve(int columnsOfB, double[] a, int order, double[] b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (a.Length != order * order)
			{
				throw new ArgumentException("The array arguments must have the same length.", "a");
			}
			if (b.Length != order * columnsOfB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			if (a == b)
			{
				throw new ArgumentException("Arguments must be different objects.");
			}
			int[] ipiv = new int[order];
			double[] array = new double[a.Length];
			a.Copy(array);
			LUFactor(array, order, ipiv);
			LUSolveFactored(columnsOfB, array, order, ipiv, b);
		}

		public void LUSolveFactored(int columnsOfB, double[] a, int order, int[] ipiv, double[] b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (ipiv == null)
			{
				throw new ArgumentNullException("ipiv");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (a.Length != order * order)
			{
				throw new ArgumentException("The array arguments must have the same length.", "a");
			}
			if (ipiv.Length != order)
			{
				throw new ArgumentException("The array arguments must have the same length.", "ipiv");
			}
			if (b.Length != order * columnsOfB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			if (a == b)
			{
				throw new ArgumentException("Arguments must be different objects.");
			}
			for (int i = 0; i < ipiv.Length; i++)
			{
				if (ipiv[i] != i)
				{
					int num = ipiv[i];
					for (int j = 0; j < columnsOfB; j++)
					{
						int num2 = j * order;
						int num3 = num2 + num;
						int num4 = num2 + i;
						ref double reference = ref b[num3];
						ref double reference2 = ref b[num4];
						double num5 = b[num4];
						double num6 = b[num3];
						reference = num5;
						reference2 = num6;
					}
				}
			}
			for (int k = 0; k < order; k++)
			{
				int num7 = k * order;
				for (int l = k + 1; l < order; l++)
				{
					for (int m = 0; m < columnsOfB; m++)
					{
						int num8 = m * order;
						b[l + num8] -= b[k + num8] * a[l + num7];
					}
				}
			}
			for (int num9 = order - 1; num9 >= 0; num9--)
			{
				int num10 = num9 + num9 * order;
				for (int n = 0; n < columnsOfB; n++)
				{
					b[num9 + n * order] /= a[num10];
				}
				num10 = num9 * order;
				for (int num11 = 0; num11 < num9; num11++)
				{
					for (int num12 = 0; num12 < columnsOfB; num12++)
					{
						int num13 = num12 * order;
						b[num11 + num13] -= b[num9 + num13] * a[num11 + num10];
					}
				}
			}
		}

		public void CholeskyFactor(double[] a, int order)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			double[] array = new double[order];
			for (int i = 0; i < order; i++)
			{
				double num = a[i * order + i];
				if (!(num > 0.0))
				{
					throw new ArgumentException("Matrix must be positive definite.");
				}
				num = (array[i] = (a[i * order + i] = Math.Sqrt(num)));
				for (int j = i + 1; j < order; j++)
				{
					a[i * order + j] /= num;
					array[j] = a[i * order + j];
				}
				DoCholeskyStep(a, order, i + 1, order, array, Control.MaxDegreeOfParallelism);
				for (int k = i + 1; k < order; k++)
				{
					a[k * order + i] = 0.0;
				}
			}
		}

		private static void DoCholeskyStep(double[] data, int rowDim, int firstCol, int colLimit, double[] multipliers, int availableCores)
		{
			int num = colLimit - firstCol;
			if (availableCores > 1 && num > Control.ParallelizeElements)
			{
				int tmpSplit = firstCol + num / 3;
				int tmpCores = availableCores / 2;
				CommonParallel.Invoke(delegate
				{
					DoCholeskyStep(data, rowDim, firstCol, tmpSplit, multipliers, tmpCores);
				}, delegate
				{
					DoCholeskyStep(data, rowDim, tmpSplit, colLimit, multipliers, tmpCores);
				});
				return;
			}
			for (int num2 = firstCol; num2 < colLimit; num2++)
			{
				double num3 = multipliers[num2];
				for (int num4 = num2; num4 < rowDim; num4++)
				{
					data[num2 * rowDim + num4] -= multipliers[num4] * num3;
				}
			}
		}

		public void CholeskySolve(double[] a, int orderA, double[] b, int columnsB)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (b.Length != orderA * columnsB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			if (a == b)
			{
				throw new ArgumentException("Arguments must be different objects.");
			}
			double[] array = new double[a.Length];
			a.Copy(array);
			CholeskyFactor(array, orderA);
			CholeskySolveFactored(array, orderA, b, columnsB);
		}

		public void CholeskySolveFactored(double[] a, int orderA, double[] b, int columnsB)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (b.Length != orderA * columnsB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			if (a == b)
			{
				throw new ArgumentException("Arguments must be different objects.");
			}
			CommonParallel.For(0, columnsB, delegate(int u, int v)
			{
				for (int i = u; i < v; i++)
				{
					DoCholeskySolve(a, orderA, b, i);
				}
			});
		}

		private static void DoCholeskySolve(double[] a, int orderA, double[] b, int index)
		{
			int num = index * orderA;
			for (int i = 0; i < orderA; i++)
			{
				double num2 = b[num + i];
				for (int num3 = i - 1; num3 >= 0; num3--)
				{
					num2 -= a[num3 * orderA + i] * b[num + num3];
				}
				b[num + i] = num2 / a[i * orderA + i];
			}
			for (int num4 = orderA - 1; num4 >= 0; num4--)
			{
				double num2 = b[num + num4];
				int num5 = num4 * orderA;
				for (int j = num4 + 1; j < orderA; j++)
				{
					num2 -= a[num5 + j] * b[num + j];
				}
				b[num + num4] = num2 / a[num5 + num4];
			}
		}

		public void QRFactor(double[] r, int rowsR, int columnsR, double[] q, double[] tau)
		{
			if (r == null)
			{
				throw new ArgumentNullException("r");
			}
			if (q == null)
			{
				throw new ArgumentNullException("q");
			}
			if (r.Length != rowsR * columnsR)
			{
				throw new ArgumentException("The given array has the wrong length. Should be rowsR * columnsR.", "r");
			}
			if (tau.Length < Math.Min(rowsR, columnsR))
			{
				throw new ArgumentException("The given array is too small. It must be at least min(m,n) long.", "tau");
			}
			if (q.Length != rowsR * rowsR)
			{
				throw new ArgumentException("The given array has the wrong length. Should be rowsR * rowsR.", "q");
			}
			CommonParallel.For(0, rowsR, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					q[i * rowsR + i] = 1.0;
				}
			});
			double[] work = ((columnsR > rowsR) ? new double[rowsR * rowsR] : new double[rowsR * columnsR]);
			int num = Math.Min(rowsR, columnsR);
			for (int num2 = 0; num2 < num; num2++)
			{
				GenerateColumn(work, r, rowsR, num2, num2);
				ComputeQR(work, num2, r, num2, rowsR, num2 + 1, columnsR, Control.MaxDegreeOfParallelism);
			}
			for (int num3 = num - 1; num3 >= 0; num3--)
			{
				ComputeQR(work, num3, q, num3, rowsR, num3, rowsR, Control.MaxDegreeOfParallelism);
			}
		}

		public void ThinQRFactor(double[] a, int rowsA, int columnsA, double[] r, double[] tau)
		{
			if (r == null)
			{
				throw new ArgumentNullException("r");
			}
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (a.Length != rowsA * columnsA)
			{
				throw new ArgumentException("The given array has the wrong length. Should be rowsR * columnsR.", "a");
			}
			if (tau.Length < Math.Min(rowsA, columnsA))
			{
				throw new ArgumentException("The given array is too small. It must be at least min(m,n) long.", "tau");
			}
			if (r.Length != columnsA * columnsA)
			{
				throw new ArgumentException("The given array has the wrong length. Should be columnsA * columnsA.", "r");
			}
			double[] work = new double[rowsA * columnsA];
			int num = Math.Min(rowsA, columnsA);
			for (int i = 0; i < num; i++)
			{
				GenerateColumn(work, a, rowsA, i, i);
				ComputeQR(work, i, a, i, rowsA, i + 1, columnsA, Control.MaxDegreeOfParallelism);
			}
			for (int j = 0; j < columnsA; j++)
			{
				int num2 = j * columnsA;
				int num3 = j * rowsA;
				for (int k = 0; k < columnsA; k++)
				{
					r[num2 + k] = a[num3 + k];
				}
			}
			Array.Clear(a, 0, a.Length);
			for (int l = 0; l < columnsA; l++)
			{
				a[l * rowsA + l] = 1.0;
			}
			for (int num4 = num - 1; num4 >= 0; num4--)
			{
				ComputeQR(work, num4, a, num4, rowsA, num4, columnsA, Control.MaxDegreeOfParallelism);
			}
		}

		private static void ComputeQR(double[] work, int workIndex, double[] a, int rowStart, int rowCount, int columnStart, int columnCount, int availableCores)
		{
			if (rowStart > rowCount || columnStart > columnCount)
			{
				return;
			}
			int num = columnCount - columnStart;
			if (availableCores > 1 && num > 200)
			{
				int tmpSplit = columnStart + num / 2;
				int tmpCores = availableCores / 2;
				CommonParallel.Invoke(delegate
				{
					ComputeQR(work, workIndex, a, rowStart, rowCount, columnStart, tmpSplit, tmpCores);
				}, delegate
				{
					ComputeQR(work, workIndex, a, rowStart, rowCount, tmpSplit, columnCount, tmpCores);
				});
				return;
			}
			for (int num2 = columnStart; num2 < columnCount; num2++)
			{
				double num3 = 0.0;
				for (int num4 = rowStart; num4 < rowCount; num4++)
				{
					num3 += work[workIndex * rowCount + num4 - rowStart] * a[num2 * rowCount + num4];
				}
				for (int num5 = rowStart; num5 < rowCount; num5++)
				{
					a[num2 * rowCount + num5] -= work[workIndex * rowCount + num5 - rowStart] * num3;
				}
			}
		}

		private static void GenerateColumn(double[] work, double[] a, int rowCount, int row, int column)
		{
			int tmp = column * rowCount;
			int num = tmp + row;
			CommonParallel.For(row, rowCount, delegate(int u, int v)
			{
				for (int i = u; i < v; i++)
				{
					int num5 = tmp + i;
					work[num5 - row] = a[num5];
					a[num5] = 0.0;
				}
			});
			double num2 = 0.0;
			for (int num3 = 0; num3 < rowCount - row; num3++)
			{
				int num4 = tmp + num3;
				num2 += work[num4] * work[num4];
			}
			num2 = Math.Sqrt(num2);
			if (row == rowCount - 1 || num2 == 0.0)
			{
				a[num] = 0.0 - work[tmp];
				work[tmp] = 1.4142135623730951;
				return;
			}
			double scale = 1.0 / num2;
			if (work[tmp] < 0.0)
			{
				scale *= -1.0;
			}
			a[num] = -1.0 / scale;
			CommonParallel.For(0, rowCount - row, 4096, delegate(int u, int v)
			{
				for (int i = u; i < v; i++)
				{
					work[tmp + i] *= scale;
				}
			});
			work[tmp] += 1.0;
			double s = Math.Sqrt(1.0 / work[tmp]);
			CommonParallel.For(0, rowCount - row, 4096, delegate(int u, int v)
			{
				for (int i = u; i < v; i++)
				{
					work[tmp + i] *= s;
				}
			});
		}

		public void QRSolve(double[] a, int rows, int columns, double[] b, int columnsB, double[] x, QRMethod method = QRMethod.Full)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (a.Length != rows * columns)
			{
				throw new ArgumentException("The array arguments must have the same length.", "a");
			}
			if (b.Length != rows * columnsB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			if (x.Length != columns * columnsB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "x");
			}
			if (rows < columns)
			{
				throw new ArgumentException("The number of rows must greater than or equal to the number of columns.");
			}
			double[] tau = new double[rows * columns];
			double[] array = new double[a.Length];
			a.Copy(array);
			if (method == QRMethod.Full)
			{
				double[] q = new double[rows * rows];
				QRFactor(array, rows, columns, q, tau);
				QRSolveFactored(q, array, rows, columns, null, b, columnsB, x, method);
			}
			else
			{
				double[] r = new double[columns * columns];
				ThinQRFactor(array, rows, columns, r, tau);
				QRSolveFactored(array, r, rows, columns, null, b, columnsB, x, method);
			}
		}

		public void QRSolveFactored(double[] q, double[] r, int rowsA, int columnsA, double[] tau, double[] b, int columnsB, double[] x, QRMethod method = QRMethod.Full)
		{
			if (r == null)
			{
				throw new ArgumentNullException("r");
			}
			if (q == null)
			{
				throw new ArgumentNullException("q");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (rowsA < columnsA)
			{
				throw new ArgumentException("The number of rows must greater than or equal to the number of columns.");
			}
			int num;
			int num2;
			int num3;
			int num4;
			if (method == QRMethod.Full)
			{
				num = (num2 = (num3 = rowsA));
				num4 = columnsA;
			}
			else
			{
				num = rowsA;
				num2 = (num3 = (num4 = columnsA));
			}
			if (r.Length != num3 * num4)
			{
				throw new ArgumentException($"The given array has the wrong length. Should be {num3 * num4}.", "r");
			}
			if (q.Length != num * num2)
			{
				throw new ArgumentException($"The given array has the wrong length. Should be {num * num2}.", "q");
			}
			if (b.Length != rowsA * columnsB)
			{
				throw new ArgumentException($"The given array has the wrong length. Should be {rowsA * columnsB}.", "b");
			}
			if (x.Length != columnsA * columnsB)
			{
				throw new ArgumentException($"The given array has the wrong length. Should be {columnsA * columnsB}.", "x");
			}
			double[] sol = new double[b.Length];
			Buffer.BlockCopy(b, 0, sol, 0, b.Length * 8);
			double[] column = new double[rowsA];
			for (int i = 0; i < columnsB; i++)
			{
				int jm = i * rowsA;
				Array.Copy(sol, jm, column, 0, rowsA);
				CommonParallel.For(0, columnsA, delegate(int u, int v)
				{
					for (int j = u; j < v; j++)
					{
						int num12 = j * rowsA;
						double num13 = 0.0;
						for (int k = 0; k < rowsA; k++)
						{
							num13 += q[num12 + k] * column[k];
						}
						sol[jm + j] = num13;
					}
				});
			}
			for (int num5 = columnsA - 1; num5 >= 0; num5--)
			{
				int num6 = num5 * num3;
				for (int num7 = 0; num7 < columnsB; num7++)
				{
					sol[num7 * rowsA + num5] /= r[num6 + num5];
				}
				for (int num8 = 0; num8 < num5; num8++)
				{
					for (int num9 = 0; num9 < columnsB; num9++)
					{
						int num10 = num9 * rowsA;
						sol[num10 + num8] -= sol[num10 + num5] * r[num6 + num8];
					}
				}
			}
			for (int num11 = 0; num11 < columnsB; num11++)
			{
				Array.Copy(sol, num11 * rowsA, x, num11 * columnsA, num4);
			}
		}

		public void SingularValueDecomposition(bool computeVectors, double[] a, int rowsA, int columnsA, double[] s, double[] u, double[] vt)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			if (u == null)
			{
				throw new ArgumentNullException("u");
			}
			if (vt == null)
			{
				throw new ArgumentNullException("vt");
			}
			if (u.Length != rowsA * rowsA)
			{
				throw new ArgumentException("The array arguments must have the same length.", "u");
			}
			if (vt.Length != columnsA * columnsA)
			{
				throw new ArgumentException("The array arguments must have the same length.", "vt");
			}
			if (s.Length != Math.Min(rowsA, columnsA))
			{
				throw new ArgumentException("The array arguments must have the same length.", "s");
			}
			double[] array = new double[rowsA];
			double[] array2 = new double[columnsA];
			double[] array3 = new double[vt.Length];
			double[] array4 = new double[Math.Min(rowsA + 1, columnsA)];
			int num = Math.Min(rowsA - 1, columnsA);
			int num2 = Math.Max(0, Math.Min(columnsA - 2, rowsA));
			int num3 = Math.Max(num, num2);
			for (int i = 0; i < num3; i++)
			{
				int num4 = i + 1;
				if (i < num)
				{
					double num5 = 0.0;
					for (int j = i; j < rowsA; j++)
					{
						num5 += a[i * rowsA + j] * a[i * rowsA + j];
					}
					array4[i] = Math.Sqrt(num5);
					if (array4[i] != 0.0)
					{
						if (a[i * rowsA + i] != 0.0)
						{
							array4[i] = Math.Abs(array4[i]) * (a[i * rowsA + i] / Math.Abs(a[i * rowsA + i]));
						}
						for (int k = i; k < rowsA; k++)
						{
							a[i * rowsA + k] *= 1.0 / array4[i];
						}
						a[i * rowsA + i] = 1.0 + a[i * rowsA + i];
					}
					array4[i] = 0.0 - array4[i];
				}
				for (int l = num4; l < columnsA; l++)
				{
					if (i < num && array4[i] != 0.0)
					{
						double num6 = 0.0;
						for (int k = i; k < rowsA; k++)
						{
							num6 += a[l * rowsA + k] * a[i * rowsA + k];
						}
						num6 = (0.0 - num6) / a[i * rowsA + i];
						for (int m = i; m < rowsA; m++)
						{
							a[l * rowsA + m] += num6 * a[i * rowsA + m];
						}
					}
					array2[l] = a[l * rowsA + i];
				}
				if (computeVectors && i < num)
				{
					for (int k = i; k < rowsA; k++)
					{
						u[i * rowsA + k] = a[i * rowsA + k];
					}
				}
				if (i >= num2)
				{
					continue;
				}
				double num7 = 0.0;
				for (int k = num4; k < array2.Length; k++)
				{
					num7 += array2[k] * array2[k];
				}
				array2[i] = Math.Sqrt(num7);
				if (array2[i] != 0.0)
				{
					if (array2[num4] != 0.0)
					{
						array2[i] = Math.Abs(array2[i]) * (array2[num4] / Math.Abs(array2[num4]));
					}
					for (int k = num4; k < array2.Length; k++)
					{
						array2[k] *= 1.0 / array2[i];
					}
					array2[num4] = 1.0 + array2[num4];
				}
				array2[i] = 0.0 - array2[i];
				if (num4 < rowsA && array2[i] != 0.0)
				{
					for (int k = num4; k < rowsA; k++)
					{
						array[k] = 0.0;
					}
					for (int l = num4; l < columnsA; l++)
					{
						for (int n = num4; n < rowsA; n++)
						{
							array[n] += array2[l] * a[l * rowsA + n];
						}
					}
					for (int l = num4; l < columnsA; l++)
					{
						double num8 = (0.0 - array2[l]) / array2[num4];
						for (int num9 = num4; num9 < rowsA; num9++)
						{
							a[l * rowsA + num9] += num8 * array[num9];
						}
					}
				}
				if (computeVectors)
				{
					for (int k = num4; k < columnsA; k++)
					{
						array3[i * columnsA + k] = array2[k];
					}
				}
			}
			int num10 = Math.Min(columnsA, rowsA + 1);
			int num11 = num + 1;
			int num12 = num2 + 1;
			if (num < columnsA)
			{
				array4[num11 - 1] = a[(num11 - 1) * rowsA + (num11 - 1)];
			}
			if (rowsA < num10)
			{
				array4[num10 - 1] = 0.0;
			}
			if (num12 < num10)
			{
				array2[num12 - 1] = a[(num10 - 1) * rowsA + (num12 - 1)];
			}
			array2[num10 - 1] = 0.0;
			if (computeVectors)
			{
				for (int l = num11 - 1; l < rowsA; l++)
				{
					for (int k = 0; k < rowsA; k++)
					{
						u[l * rowsA + k] = 0.0;
					}
					u[l * rowsA + l] = 1.0;
				}
				for (int i = num - 1; i >= 0; i--)
				{
					if (array4[i] != 0.0)
					{
						for (int l = i + 1; l < rowsA; l++)
						{
							double num6 = 0.0;
							for (int k = i; k < rowsA; k++)
							{
								num6 += u[l * rowsA + k] * u[i * rowsA + k];
							}
							num6 = (0.0 - num6) / u[i * rowsA + i];
							for (int num13 = i; num13 < rowsA; num13++)
							{
								u[l * rowsA + num13] += num6 * u[i * rowsA + num13];
							}
						}
						for (int k = i; k < rowsA; k++)
						{
							u[i * rowsA + k] *= -1.0;
						}
						u[i * rowsA + i] = 1.0 + u[i * rowsA + i];
						for (int k = 0; k < i; k++)
						{
							u[i * rowsA + k] = 0.0;
						}
					}
					else
					{
						for (int k = 0; k < rowsA; k++)
						{
							u[i * rowsA + k] = 0.0;
						}
						u[i * rowsA + i] = 1.0;
					}
				}
			}
			if (computeVectors)
			{
				for (int i = columnsA - 1; i >= 0; i--)
				{
					int num4 = i + 1;
					if (i < num2 && array2[i] != 0.0)
					{
						for (int l = num4; l < columnsA; l++)
						{
							double num6 = 0.0;
							for (int k = num4; k < columnsA; k++)
							{
								num6 += array3[l * columnsA + k] * array3[i * columnsA + k];
							}
							num6 = (0.0 - num6) / array3[i * columnsA + num4];
							for (int num14 = i; num14 < columnsA; num14++)
							{
								array3[l * columnsA + num14] += num6 * array3[i * columnsA + num14];
							}
						}
					}
					for (int k = 0; k < columnsA; k++)
					{
						array3[i * columnsA + k] = 0.0;
					}
					array3[i * columnsA + i] = 1.0;
				}
			}
			for (int k = 0; k < num10; k++)
			{
				double num6;
				double num15;
				if (array4[k] != 0.0)
				{
					num6 = array4[k];
					num15 = array4[k] / num6;
					array4[k] = num6;
					if (k < num10 - 1)
					{
						array2[k] /= num15;
					}
					if (computeVectors)
					{
						for (int l = 0; l < rowsA; l++)
						{
							u[k * rowsA + l] *= num15;
						}
					}
				}
				if (k == num10 - 1)
				{
					break;
				}
				if (array2[k] == 0.0)
				{
					continue;
				}
				num6 = array2[k];
				num15 = num6 / array2[k];
				array2[k] = num6;
				array4[k + 1] *= num15;
				if (computeVectors)
				{
					for (int l = 0; l < columnsA; l++)
					{
						array3[(k + 1) * columnsA + l] *= num15;
					}
				}
			}
			int num16 = num10;
			int num17 = 0;
			while (num10 > 0)
			{
				if (num17 >= 1000)
				{
					throw new NonConvergenceException();
				}
				int i;
				for (i = num10 - 2; i >= 0; i--)
				{
					double num18 = Math.Abs(array4[i]) + Math.Abs(array4[i + 1]);
					if ((num18 + Math.Abs(array2[i])).AlmostEqualRelative(num18, 15))
					{
						array2[i] = 0.0;
						break;
					}
				}
				int num19;
				if (i == num10 - 2)
				{
					num19 = 4;
				}
				else
				{
					int num20;
					for (num20 = num10 - 1; num20 > i; num20--)
					{
						double num18 = 0.0;
						if (num20 != num10 - 1)
						{
							num18 += Math.Abs(array2[num20]);
						}
						if (num20 != i + 1)
						{
							num18 += Math.Abs(array2[num20 - 1]);
						}
						if ((num18 + Math.Abs(array4[num20])).AlmostEqualRelative(num18, 15))
						{
							array4[num20] = 0.0;
							break;
						}
					}
					if (num20 == i)
					{
						num19 = 3;
					}
					else if (num20 == num10 - 1)
					{
						num19 = 1;
					}
					else
					{
						num19 = 2;
						i = num20;
					}
				}
				i++;
				double c;
				double s2;
				switch (num19)
				{
				case 1:
				{
					double db = array2[num10 - 2];
					array2[num10 - 2] = 0.0;
					for (int num35 = i; num35 < num10 - 1; num35++)
					{
						int num23 = num10 - 2 - num35 + i;
						double da = array4[num23];
						Drotg(ref da, ref db, out c, out s2);
						array4[num23] = da;
						if (num23 != i)
						{
							db = (0.0 - s2) * array2[num23 - 1];
							array2[num23 - 1] = c * array2[num23 - 1];
						}
						if (computeVectors)
						{
							for (int k = 0; k < columnsA; k++)
							{
								double num36 = c * array3[num23 * columnsA + k] + s2 * array3[(num10 - 1) * columnsA + k];
								array3[(num10 - 1) * columnsA + k] = c * array3[(num10 - 1) * columnsA + k] - s2 * array3[num23 * columnsA + k];
								array3[num23 * columnsA + k] = num36;
							}
						}
					}
					break;
				}
				case 2:
				{
					double db = array2[i - 1];
					array2[i - 1] = 0.0;
					for (int num23 = i; num23 < num10; num23++)
					{
						double da = array4[num23];
						Drotg(ref da, ref db, out c, out s2);
						array4[num23] = da;
						db = (0.0 - s2) * array2[num23];
						array2[num23] = c * array2[num23];
						if (computeVectors)
						{
							for (int k = 0; k < rowsA; k++)
							{
								double num24 = c * u[num23 * rowsA + k] + s2 * u[(i - 1) * rowsA + k];
								u[(i - 1) * rowsA + k] = c * u[(i - 1) * rowsA + k] - s2 * u[num23 * rowsA + k];
								u[num23 * rowsA + k] = num24;
							}
						}
					}
					break;
				}
				case 3:
				{
					double val = 0.0;
					val = Math.Max(val, Math.Abs(array4[num10 - 1]));
					val = Math.Max(val, Math.Abs(array4[num10 - 2]));
					val = Math.Max(val, Math.Abs(array2[num10 - 2]));
					val = Math.Max(val, Math.Abs(array4[i]));
					val = Math.Max(val, Math.Abs(array2[i]));
					double num25 = array4[num10 - 1] / val;
					double num26 = array4[num10 - 2] / val;
					double num27 = array2[num10 - 2] / val;
					double num28 = array4[i] / val;
					double num29 = array2[i] / val;
					double num30 = ((num26 + num25) * (num26 - num25) + num27 * num27) / 2.0;
					double num31 = num25 * num27 * (num25 * num27);
					double num32 = 0.0;
					if (num30 != 0.0 || num31 != 0.0)
					{
						num32 = Math.Sqrt(num30 * num30 + num31);
						if (num30 < 0.0)
						{
							num32 = 0.0 - num32;
						}
						num32 = num31 / (num30 + num32);
					}
					double db = (num28 + num25) * (num28 - num25) + num32;
					double db2 = num28 * num29;
					for (int num23 = i; num23 < num10 - 1; num23++)
					{
						Drotg(ref db, ref db2, out c, out s2);
						if (num23 != i)
						{
							array2[num23 - 1] = db;
						}
						db = c * array4[num23] + s2 * array2[num23];
						array2[num23] = c * array2[num23] - s2 * array4[num23];
						db2 = s2 * array4[num23 + 1];
						array4[num23 + 1] = c * array4[num23 + 1];
						if (computeVectors)
						{
							for (int k = 0; k < columnsA; k++)
							{
								double num33 = c * array3[num23 * columnsA + k] + s2 * array3[(num23 + 1) * columnsA + k];
								array3[(num23 + 1) * columnsA + k] = c * array3[(num23 + 1) * columnsA + k] - s2 * array3[num23 * columnsA + k];
								array3[num23 * columnsA + k] = num33;
							}
						}
						Drotg(ref db, ref db2, out c, out s2);
						array4[num23] = db;
						db = c * array2[num23] + s2 * array4[num23 + 1];
						array4[num23 + 1] = 0.0 - s2 * array2[num23] + c * array4[num23 + 1];
						db2 = s2 * array2[num23 + 1];
						array2[num23 + 1] = c * array2[num23 + 1];
						if (computeVectors && num23 < rowsA)
						{
							for (int k = 0; k < rowsA; k++)
							{
								double num34 = c * u[num23 * rowsA + k] + s2 * u[(num23 + 1) * rowsA + k];
								u[(num23 + 1) * rowsA + k] = c * u[(num23 + 1) * rowsA + k] - s2 * u[num23 * rowsA + k];
								u[num23 * rowsA + k] = num34;
							}
						}
					}
					array2[num10 - 2] = db;
					num17++;
					break;
				}
				case 4:
					if (array4[i] < 0.0)
					{
						array4[i] = 0.0 - array4[i];
						if (computeVectors)
						{
							for (int k = 0; k < columnsA; k++)
							{
								array3[i * columnsA + k] *= -1.0;
							}
						}
					}
					for (; i != num16 - 1 && !(array4[i] >= array4[i + 1]); i++)
					{
						double num6 = array4[i];
						array4[i] = array4[i + 1];
						array4[i + 1] = num6;
						if (computeVectors && i < columnsA)
						{
							for (int k = 0; k < columnsA; k++)
							{
								ref double reference = ref array3[i * columnsA + k];
								ref double reference2 = ref array3[(i + 1) * columnsA + k];
								double num21 = array3[(i + 1) * columnsA + k];
								double num22 = array3[i * columnsA + k];
								reference = num21;
								reference2 = num22;
							}
						}
						if (computeVectors && i < rowsA)
						{
							for (int k = 0; k < rowsA; k++)
							{
								ref double reference = ref u[i * rowsA + k];
								ref double reference3 = ref u[(i + 1) * rowsA + k];
								double num22 = u[(i + 1) * rowsA + k];
								double num21 = u[i * rowsA + k];
								reference = num22;
								reference3 = num21;
							}
						}
					}
					num17 = 0;
					num10--;
					break;
				}
			}
			if (computeVectors)
			{
				for (int k = 0; k < columnsA; k++)
				{
					for (int l = 0; l < columnsA; l++)
					{
						vt[l * columnsA + k] = array3[k * columnsA + l];
					}
				}
			}
			Buffer.BlockCopy(array4, 0, s, 0, Math.Min(rowsA, columnsA) * 8);
		}

		private static void Drotg(ref double da, ref double db, out double c, out double s)
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

		public void SvdSolve(double[] a, int rowsA, int columnsA, double[] b, int columnsB, double[] x)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (b.Length != rowsA * columnsB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			if (x.Length != columnsA * columnsB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			double[] s = new double[Math.Min(rowsA, columnsA)];
			double[] u = new double[rowsA * rowsA];
			double[] vt = new double[columnsA * columnsA];
			double[] array = new double[a.Length];
			Buffer.BlockCopy(a, 0, array, 0, a.Length * 8);
			SingularValueDecomposition(computeVectors: true, array, rowsA, columnsA, s, u, vt);
			SvdSolveFactored(rowsA, columnsA, s, u, vt, b, columnsB, x);
		}

		public void SvdSolveFactored(int rowsA, int columnsA, double[] s, double[] u, double[] vt, double[] b, int columnsB, double[] x)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			if (u == null)
			{
				throw new ArgumentNullException("u");
			}
			if (vt == null)
			{
				throw new ArgumentNullException("vt");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (u.Length != rowsA * rowsA)
			{
				throw new ArgumentException("The array arguments must have the same length.", "u");
			}
			if (vt.Length != columnsA * columnsA)
			{
				throw new ArgumentException("The array arguments must have the same length.", "vt");
			}
			if (s.Length != Math.Min(rowsA, columnsA))
			{
				throw new ArgumentException("The array arguments must have the same length.", "s");
			}
			if (b.Length != rowsA * columnsB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			if (x.Length != columnsA * columnsB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			int num = Math.Min(rowsA, columnsA);
			double[] array = new double[columnsA];
			for (int i = 0; i < columnsB; i++)
			{
				for (int j = 0; j < columnsA; j++)
				{
					double num2 = 0.0;
					if (j < num)
					{
						for (int k = 0; k < rowsA; k++)
						{
							num2 += u[j * rowsA + k] * b[i * rowsA + k];
						}
						num2 /= s[j];
					}
					array[j] = num2;
				}
				for (int l = 0; l < columnsA; l++)
				{
					double num3 = 0.0;
					for (int m = 0; m < columnsA; m++)
					{
						num3 += vt[l * columnsA + m] * array[m];
					}
					x[i * columnsA + l] = num3;
				}
			}
		}

		public void EigenDecomp(bool isSymmetric, int order, double[] matrix, double[] matrixEv, Complex[] vectorEv, double[] matrixD)
		{
			if (matrix == null)
			{
				throw new ArgumentNullException("matrix");
			}
			if (matrix.Length != order * order)
			{
				throw new ArgumentException($"The given array has the wrong length. Should be {order * order}.", "matrix");
			}
			if (matrixEv == null)
			{
				throw new ArgumentNullException("matrixEv");
			}
			if (matrixEv.Length != order * order)
			{
				throw new ArgumentException($"The given array has the wrong length. Should be {order * order}.", "matrixEv");
			}
			if (vectorEv == null)
			{
				throw new ArgumentNullException("vectorEv");
			}
			if (vectorEv.Length != order)
			{
				throw new ArgumentException($"The given array has the wrong length. Should be {order}.", "vectorEv");
			}
			if (matrixD == null)
			{
				throw new ArgumentNullException("matrixD");
			}
			if (matrixD.Length != order * order)
			{
				throw new ArgumentException($"The given array has the wrong length. Should be {order * order}.", "matrixD");
			}
			double[] array = new double[order];
			double[] array2 = new double[order];
			if (isSymmetric)
			{
				Buffer.BlockCopy(matrix, 0, matrixEv, 0, matrix.Length * 8);
				int num = order - 1;
				for (int i = 0; i < order; i++)
				{
					array[i] = matrixEv[i * order + num];
				}
				SymmetricTridiagonalize(matrixEv, array, array2, order);
				SymmetricDiagonalize(matrixEv, array, array2, order);
			}
			else
			{
				double[] array3 = new double[matrix.Length];
				Buffer.BlockCopy(matrix, 0, array3, 0, matrix.Length * 8);
				NonsymmetricReduceToHessenberg(matrixEv, array3, order);
				NonsymmetricReduceHessenberToRealSchur(matrixEv, array3, array, array2, order);
			}
			for (int j = 0; j < order; j++)
			{
				vectorEv[j] = new Complex(array[j], array2[j]);
				int num2 = j * order;
				matrixD[num2 + j] = array[j];
				if (array2[j] > 0.0)
				{
					matrixD[num2 + order + j] = array2[j];
					matrixD[(j + 1) * order + j] = array2[j];
				}
				else if (array2[j] < 0.0)
				{
					matrixD[num2 - order + j] = array2[j];
				}
			}
		}

		internal static void SymmetricTridiagonalize(double[] a, double[] d, double[] e, int order)
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
						d[j] = a[j * order + num - 1];
						a[j * order + num] = 0.0;
						a[num * order + j] = 0.0;
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
						num4 = (a[num * order + m] = d[m]);
						num5 = e[m] + a[m * order + m] * num4;
						for (int n = m + 1; n <= num - 1; n++)
						{
							num5 += a[m * order + n] * d[n];
							e[n] += a[m * order + n] * num4;
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
							a[num9 * order + num10] -= num4 * e[num10] + num5 * d[num10];
						}
						d[num9] = a[num9 * order + num - 1];
						a[num9 * order + num] = 0.0;
					}
				}
				d[num] = num3;
			}
			for (int num11 = 0; num11 < order - 1; num11++)
			{
				a[num11 * order + order - 1] = a[num11 * order + num11];
				a[num11 * order + num11] = 1.0;
				double num12 = d[num11 + 1];
				if (num12 != 0.0)
				{
					for (int num13 = 0; num13 <= num11; num13++)
					{
						d[num13] = a[(num11 + 1) * order + num13] / num12;
					}
					for (int num14 = 0; num14 <= num11; num14++)
					{
						double num15 = 0.0;
						for (int num16 = 0; num16 <= num11; num16++)
						{
							num15 += a[(num11 + 1) * order + num16] * a[num14 * order + num16];
						}
						for (int num17 = 0; num17 <= num11; num17++)
						{
							a[num14 * order + num17] -= num15 * d[num17];
						}
					}
				}
				for (int num18 = 0; num18 <= num11; num18++)
				{
					a[(num11 + 1) * order + num18] = 0.0;
				}
			}
			for (int num19 = 0; num19 < order; num19++)
			{
				d[num19] = a[num19 * order + order - 1];
				a[num19 * order + order - 1] = 0.0;
			}
			a[order * order - 1] = 1.0;
			e[0] = 0.0;
		}

		internal static void SymmetricDiagonalize(double[] a, double[] d, double[] e, int order)
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
								num8 = a[(num15 + 1) * order + m];
								a[(num15 + 1) * order + m] = num13 * a[num15 * order + m] + num9 * num8;
								a[num15 * order + m] = num9 * a[num15 * order + m] - num13 * num8;
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
						num17 = a[n * order + num19];
						a[n * order + num19] = a[num16 * order + num19];
						a[num16 * order + num19] = num17;
					}
				}
			}
		}

		internal static void NonsymmetricReduceToHessenberg(double[] a, double[] matrixH, int order)
		{
			double[] array = new double[order];
			int num = order - 1;
			for (int i = 1; i <= num - 1; i++)
			{
				int num2 = (i - 1) * order;
				double num3 = 0.0;
				for (int j = i; j <= num; j++)
				{
					num3 += Math.Abs(matrixH[num2 + j]);
				}
				if (num3 == 0.0)
				{
					continue;
				}
				double num4 = 0.0;
				for (int num5 = num; num5 >= i; num5--)
				{
					array[num5] = matrixH[num2 + num5] / num3;
					num4 += array[num5] * array[num5];
				}
				double num6 = Math.Sqrt(num4);
				if (array[i] > 0.0)
				{
					num6 = 0.0 - num6;
				}
				num4 -= array[i] * num6;
				array[i] -= num6;
				for (int k = i; k < order; k++)
				{
					int num7 = k * order;
					double num8 = 0.0;
					for (int num9 = order - 1; num9 >= i; num9--)
					{
						num8 += array[num9] * matrixH[num7 + num9];
					}
					num8 /= num4;
					for (int l = i; l <= num; l++)
					{
						matrixH[num7 + l] -= num8 * array[l];
					}
				}
				for (int m = 0; m <= num; m++)
				{
					double num10 = 0.0;
					for (int num11 = num; num11 >= i; num11--)
					{
						num10 += array[num11] * matrixH[num11 * order + m];
					}
					num10 /= num4;
					for (int n = i; n <= num; n++)
					{
						matrixH[n * order + m] -= num10 * array[n];
					}
				}
				array[i] = num3 * array[i];
				matrixH[num2 + i] = num3 * num6;
			}
			for (int num12 = 0; num12 < order; num12++)
			{
				for (int num13 = 0; num13 < order; num13++)
				{
					a[num13 * order + num12] = ((num12 == num13) ? 1.0 : 0.0);
				}
			}
			for (int num14 = num - 1; num14 >= 1; num14--)
			{
				int num15 = (num14 - 1) * order;
				int num16 = num15 + num14;
				if (matrixH[num16] != 0.0)
				{
					for (int num17 = num14 + 1; num17 <= num; num17++)
					{
						array[num17] = matrixH[num15 + num17];
					}
					for (int num18 = num14; num18 <= num; num18++)
					{
						double num19 = 0.0;
						int num20 = num18 * order;
						for (int num21 = num14; num21 <= num; num21++)
						{
							num19 += array[num21] * a[num20 + num21];
						}
						num19 = num19 / array[num14] / matrixH[num16];
						for (int num22 = num14; num22 <= num; num22++)
						{
							a[num20 + num22] += num19 * array[num22];
						}
					}
				}
			}
		}

		internal static void NonsymmetricReduceHessenberToRealSchur(double[] a, double[] matrixH, double[] d, double[] e, int order)
		{
			int num = order - 1;
			double num2 = Math.Pow(2.0, -52.0);
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			double num8 = 0.0;
			double num9 = 0.0;
			for (int i = 0; i < order; i++)
			{
				for (int j = Math.Max(i - 1, 0); j < order; j++)
				{
					num9 += Math.Abs(matrixH[j * order + i]);
				}
			}
			int num10 = 0;
			while (num >= 0)
			{
				int num11;
				for (num11 = num; num11 > 0; num11--)
				{
					int num12 = num11 - 1;
					int num13 = num12 * order;
					num7 = Math.Abs(matrixH[num13 + num12]) + Math.Abs(matrixH[num11 * order + num11]);
					if (num7 == 0.0)
					{
						num7 = num9;
					}
					if (Math.Abs(matrixH[num13 + num11]) < num2 * num7)
					{
						break;
					}
				}
				if (num11 == num)
				{
					int num14 = num * order + num;
					matrixH[num14] += num3;
					d[num] = matrixH[num14];
					e[num] = 0.0;
					num--;
					num10 = 0;
					continue;
				}
				double num20;
				double num19;
				if (num11 == num - 1)
				{
					int num15 = num * order;
					int num16 = num - 1;
					int num17 = num16 * order;
					int num18 = num15 + num;
					num19 = matrixH[num17 + num] * matrixH[num15 + num16];
					num4 = (matrixH[num17 + num16] - matrixH[num18]) / 2.0;
					num5 = num4 * num4 + num19;
					num8 = Math.Sqrt(Math.Abs(num5));
					matrixH[num18] += num3;
					matrixH[num17 + num16] += num3;
					num20 = matrixH[num18];
					if (num5 >= 0.0)
					{
						num8 = ((!(num4 >= 0.0)) ? (num4 - num8) : (num4 + num8));
						d[num16] = num20 + num8;
						d[num] = d[num16];
						if (num8 != 0.0)
						{
							d[num] = num20 - num19 / num8;
						}
						e[num - 1] = 0.0;
						e[num] = 0.0;
						num20 = matrixH[num17 + num];
						num7 = Math.Abs(num20) + Math.Abs(num8);
						num4 = num20 / num7;
						num5 = num8 / num7;
						num6 = Math.Sqrt(num4 * num4 + num5 * num5);
						num4 /= num6;
						num5 /= num6;
						for (int k = num - 1; k < order; k++)
						{
							int num21 = k * order;
							int num22 = num21 + num;
							num8 = matrixH[num21 + num16];
							matrixH[num21 + num16] = num5 * num8 + num4 * matrixH[num22];
							matrixH[num22] = num5 * matrixH[num22] - num4 * num8;
						}
						for (int l = 0; l <= num; l++)
						{
							int num23 = num15 + l;
							num8 = matrixH[num17 + l];
							matrixH[num17 + l] = num5 * num8 + num4 * matrixH[num23];
							matrixH[num23] = num5 * matrixH[num23] - num4 * num8;
						}
						for (int m = 0; m < order; m++)
						{
							int num24 = num15 + m;
							num8 = a[num17 + m];
							a[num17 + m] = num5 * num8 + num4 * a[num24];
							a[num24] = num5 * a[num24] - num4 * num8;
						}
					}
					else
					{
						d[num - 1] = num20 + num4;
						d[num] = num20 + num4;
						e[num - 1] = num8;
						e[num] = 0.0 - num8;
					}
					num -= 2;
					num10 = 0;
					continue;
				}
				int num25 = num * order;
				int num26 = num - 1;
				int num27 = num26 * order;
				int num28 = num25 + num;
				num20 = matrixH[num28];
				double num29 = 0.0;
				num19 = 0.0;
				if (num11 < num)
				{
					num29 = matrixH[num27 + num26];
					num19 = matrixH[num27 + num] * matrixH[num25 + num26];
				}
				if (num10 == 10)
				{
					num3 += num20;
					for (int n = 0; n <= num; n++)
					{
						matrixH[n * order + n] -= num20;
					}
					num7 = Math.Abs(matrixH[num27 + num]) + Math.Abs(matrixH[(num - 2) * order + num26]);
					num20 = (num29 = 0.75 * num7);
					num19 = -0.4375 * num7 * num7;
				}
				if (num10 == 30)
				{
					num7 = (num29 - num20) / 2.0;
					num7 = num7 * num7 + num19;
					if (num7 > 0.0)
					{
						num7 = Math.Sqrt(num7);
						if (num29 < num20)
						{
							num7 = 0.0 - num7;
						}
						num7 = num20 - num19 / ((num29 - num20) / 2.0 + num7);
						for (int num30 = 0; num30 <= num; num30++)
						{
							matrixH[num30 * order + num30] -= num7;
						}
						num3 += num7;
						num20 = (num29 = (num19 = 0.964));
					}
				}
				num10++;
				if (num10 >= 30 * order)
				{
					throw new NonConvergenceException();
				}
				int num31;
				for (num31 = num - 2; num31 >= num11; num31--)
				{
					int num32 = num31 + 1;
					int num33 = num31 - 1;
					int num34 = num31 * order;
					int num35 = num32 * order;
					int num36 = num33 * order;
					num8 = matrixH[num34 + num31];
					num6 = num20 - num8;
					num7 = num29 - num8;
					num4 = (num6 * num7 - num19) / matrixH[num34 + num32] + matrixH[num35 + num31];
					num5 = matrixH[num35 + num32] - num8 - num6 - num7;
					num6 = matrixH[num35 + (num31 + 2)];
					num7 = Math.Abs(num4) + Math.Abs(num5) + Math.Abs(num6);
					num4 /= num7;
					num5 /= num7;
					num6 /= num7;
					if (num31 == num11 || Math.Abs(matrixH[num36 + num31]) * (Math.Abs(num5) + Math.Abs(num6)) < num2 * (Math.Abs(num4) * (Math.Abs(matrixH[num36 + num33]) + Math.Abs(num8) + Math.Abs(matrixH[num35 + num32]))))
					{
						break;
					}
				}
				int num37 = num31 + 2;
				for (int num38 = num37; num38 <= num; num38++)
				{
					matrixH[(num38 - 2) * order + num38] = 0.0;
					if (num38 > num37)
					{
						matrixH[(num38 - 3) * order + num38] = 0.0;
					}
				}
				for (int num39 = num31; num39 <= num - 1; num39++)
				{
					bool flag = num39 != num - 1;
					int num40 = num39 * order;
					int num41 = num39 - 1;
					int num42 = num39 + 1;
					int num43 = num39 + 2;
					int num44 = num42 * order;
					int num45 = num43 * order;
					int num46 = num41 * order;
					if (num39 != num31)
					{
						num4 = matrixH[num46 + num39];
						num5 = matrixH[num46 + num42];
						num6 = (flag ? matrixH[num46 + num43] : 0.0);
						num20 = Math.Abs(num4) + Math.Abs(num5) + Math.Abs(num6);
						if (num20 == 0.0)
						{
							continue;
						}
						num4 /= num20;
						num5 /= num20;
						num6 /= num20;
					}
					num7 = Math.Sqrt(num4 * num4 + num5 * num5 + num6 * num6);
					if (num4 < 0.0)
					{
						num7 = 0.0 - num7;
					}
					if (num7 == 0.0)
					{
						continue;
					}
					if (num39 != num31)
					{
						matrixH[num46 + num39] = (0.0 - num7) * num20;
					}
					else if (num11 != num31)
					{
						matrixH[num46 + num39] = 0.0 - matrixH[num46 + num39];
					}
					num4 += num7;
					num20 = num4 / num7;
					num29 = num5 / num7;
					num8 = num6 / num7;
					num5 /= num4;
					num6 /= num4;
					for (int num47 = num39; num47 < order; num47++)
					{
						int num48 = num47 * order;
						int num49 = num48 + num39;
						int num50 = num48 + num42;
						int num51 = num48 + num43;
						num4 = matrixH[num49] + num5 * matrixH[num50];
						if (flag)
						{
							num4 += num6 * matrixH[num51];
							matrixH[num51] -= num4 * num8;
						}
						matrixH[num49] -= num4 * num20;
						matrixH[num50] -= num4 * num29;
					}
					for (int num52 = 0; num52 <= Math.Min(num, num39 + 3); num52++)
					{
						num4 = num20 * matrixH[num40 + num52] + num29 * matrixH[num44 + num52];
						if (flag)
						{
							num4 += num8 * matrixH[num45 + num52];
							matrixH[num45 + num52] -= num4 * num6;
						}
						matrixH[num40 + num52] -= num4;
						matrixH[num44 + num52] -= num4 * num5;
					}
					for (int num53 = 0; num53 < order; num53++)
					{
						num4 = num20 * a[num40 + num53] + num29 * a[num44 + num53];
						if (flag)
						{
							num4 += num8 * a[num45 + num53];
							a[num45 + num53] -= num4 * num6;
						}
						a[num40 + num53] -= num4;
						a[num44 + num53] -= num4 * num5;
					}
				}
			}
			if (num9 == 0.0)
			{
				return;
			}
			for (num = order - 1; num >= 0; num--)
			{
				int num54 = num * order;
				int num55 = num - 1;
				int num56 = num55 * order;
				num4 = d[num];
				num5 = e[num];
				if (num5 == 0.0)
				{
					int num57 = num;
					matrixH[num54 + num] = 1.0;
					for (int num58 = num - 1; num58 >= 0; num58--)
					{
						int num59 = num58 + 1;
						int num60 = num58 * order;
						int num61 = num59 * order;
						double num19 = matrixH[num60 + num58] - num4;
						num6 = 0.0;
						for (int num62 = num57; num62 <= num; num62++)
						{
							num6 += matrixH[num62 * order + num58] * matrixH[num54 + num62];
						}
						if (e[num58] < 0.0)
						{
							num8 = num19;
							num7 = num6;
						}
						else
						{
							num57 = num58;
							double num63;
							if (e[num58] == 0.0)
							{
								if (num19 != 0.0)
								{
									matrixH[num54 + num58] = (0.0 - num6) / num19;
								}
								else
								{
									matrixH[num54 + num58] = (0.0 - num6) / (num2 * num9);
								}
							}
							else
							{
								double num20 = matrixH[num61 + num58];
								double num29 = matrixH[num60 + num59];
								num5 = (d[num58] - num4) * (d[num58] - num4) + e[num58] * e[num58];
								num63 = (matrixH[num54 + num58] = (num20 * num7 - num8 * num6) / num5);
								if (Math.Abs(num20) > Math.Abs(num8))
								{
									matrixH[num54 + num59] = (0.0 - num6 - num19 * num63) / num20;
								}
								else
								{
									matrixH[num54 + num59] = (0.0 - num7 - num29 * num63) / num8;
								}
							}
							num63 = Math.Abs(matrixH[num54 + num58]);
							if (num2 * num63 * num63 > 1.0)
							{
								for (int num64 = num58; num64 <= num; num64++)
								{
									matrixH[num54 + num64] /= num63;
								}
							}
						}
					}
				}
				else if (num5 < 0.0)
				{
					int num65 = num - 1;
					if (Math.Abs(matrixH[num56 + num]) > Math.Abs(matrixH[num54 + num55]))
					{
						matrixH[num56 + num55] = num5 / matrixH[num56 + num];
						matrixH[num54 + num55] = (0.0 - (matrixH[num54 + num] - num4)) / matrixH[num56 + num];
					}
					else
					{
						Complex complex = Cdiv(0.0, 0.0 - matrixH[num54 + num55], matrixH[num56 + num55] - num4, num5);
						matrixH[num56 + num55] = complex.Real;
						matrixH[num54 + num55] = complex.Imaginary;
					}
					matrixH[num56 + num] = 0.0;
					matrixH[num54 + num] = 1.0;
					for (int num66 = num - 2; num66 >= 0; num66--)
					{
						int num67 = num66 + 1;
						int num68 = num66 * order;
						int num69 = num67 * order;
						double num70 = 0.0;
						double num71 = 0.0;
						for (int num72 = num65; num72 <= num; num72++)
						{
							int num73 = num72 * order + num66;
							num70 += matrixH[num73] * matrixH[num56 + num72];
							num71 += matrixH[num73] * matrixH[num54 + num72];
						}
						double num19 = matrixH[num68 + num66] - num4;
						if (e[num66] < 0.0)
						{
							num8 = num19;
							num6 = num70;
							num7 = num71;
						}
						else
						{
							num65 = num66;
							if (e[num66] == 0.0)
							{
								Complex complex2 = Cdiv(0.0 - num70, 0.0 - num71, num19, num5);
								matrixH[num56 + num66] = complex2.Real;
								matrixH[num54 + num66] = complex2.Imaginary;
							}
							else
							{
								double num20 = matrixH[num69 + num66];
								double num29 = matrixH[num68 + num67];
								double num74 = (d[num66] - num4) * (d[num66] - num4) + e[num66] * e[num66] - num5 * num5;
								double num75 = (d[num66] - num4) * 2.0 * num5;
								if (num74 == 0.0 && num75 == 0.0)
								{
									num74 = num2 * num9 * (Math.Abs(num19) + Math.Abs(num5) + Math.Abs(num20) + Math.Abs(num29) + Math.Abs(num8));
								}
								Complex complex3 = Cdiv(num20 * num6 - num8 * num70 + num5 * num71, num20 * num7 - num8 * num71 - num5 * num70, num74, num75);
								matrixH[num56 + num66] = complex3.Real;
								matrixH[num54 + num66] = complex3.Imaginary;
								if (Math.Abs(num20) > Math.Abs(num8) + Math.Abs(num5))
								{
									matrixH[num56 + num67] = (0.0 - num70 - num19 * matrixH[num56 + num66] + num5 * matrixH[num54 + num66]) / num20;
									matrixH[num54 + num67] = (0.0 - num71 - num19 * matrixH[num54 + num66] - num5 * matrixH[num56 + num66]) / num20;
								}
								else
								{
									complex3 = Cdiv(0.0 - num6 - num29 * matrixH[num56 + num66], 0.0 - num7 - num29 * matrixH[num54 + num66], num8, num5);
									matrixH[num56 + num67] = complex3.Real;
									matrixH[num54 + num67] = complex3.Imaginary;
								}
							}
							double num63 = Math.Max(Math.Abs(matrixH[num56 + num66]), Math.Abs(matrixH[num54 + num66]));
							if (num2 * num63 * num63 > 1.0)
							{
								for (int num76 = num66; num76 <= num; num76++)
								{
									matrixH[num56 + num76] /= num63;
									matrixH[num54 + num76] /= num63;
								}
							}
						}
					}
				}
			}
			for (int num77 = order - 1; num77 >= 0; num77--)
			{
				int num78 = num77 * order;
				for (int num79 = 0; num79 < order; num79++)
				{
					num8 = 0.0;
					for (int num80 = 0; num80 <= num77; num80++)
					{
						num8 += a[num80 * order + num79] * matrixH[num78 + num80];
					}
					a[num78 + num79] = num8;
				}
			}
		}

		private static Complex Cdiv(double xreal, double ximag, double yreal, double yimag)
		{
			if (Math.Abs(yimag) < Math.Abs(yreal))
			{
				return new Complex((xreal + ximag * (yimag / yreal)) / (yreal + yimag * (yimag / yreal)), (ximag - xreal * (yimag / yreal)) / (yreal + yimag * (yimag / yreal)));
			}
			return new Complex((ximag + xreal * (yreal / yimag)) / (yimag + yreal * (yreal / yimag)), (0.0 - xreal + ximag * (yreal / yimag)) / (yimag + yreal * (yreal / yimag)));
		}

		public void AddVectorToScaledVector(float[] y, float alpha, float[] x, float[] result)
		{
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (y.Length != x.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if ((double)alpha == 0.0)
			{
				y.Copy(result);
			}
			else if ((double)alpha == 1.0)
			{
				for (int i = 0; i < result.Length; i++)
				{
					result[i] = y[i] + x[i];
				}
			}
			else
			{
				for (int j = 0; j < result.Length; j++)
				{
					result[j] = y[j] + alpha * x[j];
				}
			}
		}

		public void ScaleArray(float alpha, float[] x, float[] result)
		{
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if ((double)alpha == 0.0)
			{
				Array.Clear(result, 0, result.Length);
				return;
			}
			if ((double)alpha == 1.0)
			{
				x.Copy(result);
				return;
			}
			for (int i = 0; i < result.Length; i++)
			{
				result[i] = alpha * x[i];
			}
		}

		public void ConjugateArray(float[] x, float[] result)
		{
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (x != result)
			{
				x.CopyTo(result, 0);
			}
		}

		public float DotProduct(float[] x, float[] y)
		{
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (y.Length != x.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			float num = 0f;
			for (int i = 0; i < y.Length; i++)
			{
				num += y[i] * x[i];
			}
			return num;
		}

		public void AddArrays(float[] x, float[] y, float[] result)
		{
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (y.Length != x.Length || y.Length != result.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			for (int i = 0; i < result.Length; i++)
			{
				result[i] = x[i] + y[i];
			}
		}

		public void SubtractArrays(float[] x, float[] y, float[] result)
		{
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (y.Length != x.Length || y.Length != result.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			for (int i = 0; i < result.Length; i++)
			{
				result[i] = x[i] - y[i];
			}
		}

		public void PointWiseMultiplyArrays(float[] x, float[] y, float[] result)
		{
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (y.Length != x.Length || y.Length != result.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			for (int i = 0; i < result.Length; i++)
			{
				result[i] = x[i] * y[i];
			}
		}

		public void PointWiseDivideArrays(float[] x, float[] y, float[] result)
		{
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (y.Length != x.Length || y.Length != result.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			CommonParallel.For(0, y.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					result[i] = x[i] / y[i];
				}
			});
		}

		public void PointWisePowerArrays(float[] x, float[] y, float[] result)
		{
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (y.Length != x.Length || y.Length != result.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			CommonParallel.For(0, y.Length, 4096, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					result[i] = (float)Math.Pow(x[i], y[i]);
				}
			});
		}

		public double MatrixNorm(Norm norm, int rows, int columns, float[] matrix)
		{
			switch (norm)
			{
			case Norm.OneNorm:
			{
				double num3 = 0.0;
				for (int l = 0; l < columns; l++)
				{
					double num4 = 0.0;
					for (int m = 0; m < rows; m++)
					{
						num4 += (double)Math.Abs(matrix[l * rows + m]);
					}
					num3 = Math.Max(num3, num4);
				}
				return num3;
			}
			case Norm.LargestAbsoluteValue:
			{
				double num2 = 0.0;
				for (int j = 0; j < columns; j++)
				{
					for (int k = 0; k < rows; k++)
					{
						num2 = Math.Max(Math.Abs(matrix[j * rows + k]), num2);
					}
				}
				return num2;
			}
			case Norm.InfinityNorm:
			{
				double[] array2 = new double[rows];
				for (int n = 0; n < columns; n++)
				{
					for (int num5 = 0; num5 < rows; num5++)
					{
						array2[num5] += Math.Abs(matrix[n * rows + num5]);
					}
				}
				double num6 = array2[0];
				for (int num7 = 0; num7 < array2.Length; num7++)
				{
					if (array2[num7] > num6)
					{
						num6 = array2[num7];
					}
				}
				return num6;
			}
			case Norm.FrobeniusNorm:
			{
				float[] array = new float[rows * rows];
				MatrixMultiplyWithUpdate(Transpose.DontTranspose, Transpose.Transpose, 1f, matrix, rows, columns, matrix, rows, columns, 0f, array);
				double num = 0.0;
				for (int i = 0; i < rows; i++)
				{
					num += (double)Math.Abs(array[i * rows + i]);
				}
				return Math.Sqrt(num);
			}
			default:
				throw new NotSupportedException();
			}
		}

		public void MatrixMultiply(float[] x, int rowsX, int columnsX, float[] y, int rowsY, int columnsY, float[] result)
		{
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (y == null)
			{
				throw new ArgumentNullException("y");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (columnsX != rowsY)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"columnsA ({columnsX}) != rowsB ({rowsY})"));
			}
			if (rowsX * columnsX != x.Length)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"rowsA ({rowsX}) * columnsA ({columnsX}) != a.Length ({x.Length})"));
			}
			if (rowsY * columnsY != y.Length)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"rowsB ({rowsY}) * columnsB ({columnsY}) != b.Length ({y.Length})"));
			}
			if (rowsX * columnsY != result.Length)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"rowsA ({rowsX}) * columnsB ({columnsY}) != c.Length ({result.Length})"));
			}
			Array.Clear(result, 0, result.Length);
			float[][] columnDataB = new float[columnsY][];
			for (int i = 0; i < columnDataB.Length; i++)
			{
				float[] array = new float[rowsY];
				GetColumn(Transpose.DontTranspose, i, rowsY, columnsY, y, array);
				columnDataB[i] = array;
			}
			if (rowsX + columnsY + columnsX < Control.ParallelizeOrder || Control.MaxDegreeOfParallelism < 2)
			{
				float[] array2 = new float[columnsX];
				for (int j = 0; j < rowsX; j++)
				{
					GetRow(Transpose.DontTranspose, j, rowsX, columnsX, x, array2);
					for (int k = 0; k < columnsY; k++)
					{
						float[] array3 = columnDataB[k];
						float num = 0f;
						for (int l = 0; l < array2.Length; l++)
						{
							num += array2[l] * array3[l];
						}
						result[k * rowsX + j] += 1f * num;
					}
				}
				return;
			}
			CommonParallel.For(0, rowsX, 1, delegate(int u, int v)
			{
				float[] array4 = new float[columnsX];
				for (int m = u; m < v; m++)
				{
					GetRow(Transpose.DontTranspose, m, rowsX, columnsX, x, array4);
					for (int n = 0; n < columnsY; n++)
					{
						float[] array5 = columnDataB[n];
						float num2 = 0f;
						for (int num3 = 0; num3 < array4.Length; num3++)
						{
							num2 += array4[num3] * array5[num3];
						}
						result[n * rowsX + m] += 1f * num2;
					}
				}
			});
		}

		public void MatrixMultiplyWithUpdate(Transpose transposeA, Transpose transposeB, float alpha, float[] a, int rowsA, int columnsA, float[] b, int rowsB, int columnsB, float beta, float[] c)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (c == null)
			{
				throw new ArgumentNullException("c");
			}
			if (transposeA != Transpose.DontTranspose)
			{
				int num = columnsA;
				int num2 = rowsA;
				columnsA = num2;
				rowsA = num;
			}
			if (transposeB != Transpose.DontTranspose)
			{
				int num3 = columnsB;
				int num2 = rowsB;
				columnsB = num2;
				rowsB = num3;
			}
			if (columnsA != rowsB)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"columnsA ({columnsA}) != rowsB ({rowsB})"));
			}
			if (rowsA * columnsA != a.Length)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"rowsA ({rowsA}) * columnsA ({columnsA}) != a.Length ({a.Length})"));
			}
			if (rowsB * columnsB != b.Length)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"rowsB ({rowsB}) * columnsB ({columnsB}) != b.Length ({b.Length})"));
			}
			if (rowsA * columnsB != c.Length)
			{
				throw new ArgumentOutOfRangeException(FormattableString.Invariant($"rowsA ({rowsA}) * columnsB ({columnsB}) != c.Length ({c.Length})"));
			}
			if ((double)beta == 0.0)
			{
				Array.Clear(c, 0, c.Length);
			}
			else if ((double)beta != 1.0)
			{
				ScaleArray(beta, c, c);
			}
			if ((double)alpha == 0.0)
			{
				return;
			}
			float[][] columnDataB = new float[columnsB][];
			for (int i = 0; i < columnDataB.Length; i++)
			{
				float[] array = new float[rowsB];
				GetColumn(transposeB, i, rowsB, columnsB, b, array);
				columnDataB[i] = array;
			}
			if (rowsA + columnsB + columnsA < Control.ParallelizeOrder || Control.MaxDegreeOfParallelism < 2)
			{
				float[] array2 = new float[columnsA];
				for (int j = 0; j < rowsA; j++)
				{
					GetRow(transposeA, j, rowsA, columnsA, a, array2);
					for (int k = 0; k < columnsB; k++)
					{
						float[] array3 = columnDataB[k];
						float num4 = 0f;
						for (int l = 0; l < array2.Length; l++)
						{
							num4 += array2[l] * array3[l];
						}
						c[k * rowsA + j] += alpha * num4;
					}
				}
				return;
			}
			CommonParallel.For(0, rowsA, 1, delegate(int u, int v)
			{
				float[] array4 = new float[columnsA];
				for (int m = u; m < v; m++)
				{
					GetRow(transposeA, m, rowsA, columnsA, a, array4);
					for (int n = 0; n < columnsB; n++)
					{
						float[] array5 = columnDataB[n];
						float num5 = 0f;
						for (int num6 = 0; num6 < array4.Length; num6++)
						{
							num5 += array4[num6] * array5[num6];
						}
						c[n * rowsA + m] += alpha * num5;
					}
				}
			});
		}

		public void LUFactor(float[] data, int order, int[] ipiv)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (ipiv == null)
			{
				throw new ArgumentNullException("ipiv");
			}
			if (data.Length != order * order)
			{
				throw new ArgumentException("The array arguments must have the same length.", "data");
			}
			if (ipiv.Length != order)
			{
				throw new ArgumentException("The array arguments must have the same length.", "ipiv");
			}
			for (int i = 0; i < order; i++)
			{
				ipiv[i] = i;
			}
			float[] array = new float[order];
			for (int j = 0; j < order; j++)
			{
				int num = j * order;
				int num2 = num + j;
				for (int k = 0; k < order; k++)
				{
					array[k] = data[num + k];
				}
				for (int l = 0; l < order; l++)
				{
					int num3 = Math.Min(l, j);
					float num4 = 0f;
					for (int m = 0; m < num3; m++)
					{
						num4 += data[m * order + l] * array[m];
					}
					data[num + l] = (array[l] -= num4);
				}
				int num5 = j;
				for (int n = j + 1; n < order; n++)
				{
					if (Math.Abs(array[n]) > Math.Abs(array[num5]))
					{
						num5 = n;
					}
				}
				if (num5 != j)
				{
					for (int num6 = 0; num6 < order; num6++)
					{
						int num7 = num6 * order;
						int num8 = num7 + num5;
						int num9 = num7 + j;
						ref float reference = ref data[num8];
						ref float reference2 = ref data[num9];
						float num10 = data[num9];
						float num11 = data[num8];
						reference = num10;
						reference2 = num11;
					}
					ipiv[j] = num5;
				}
				if ((j < order) & ((double)data[num2] != 0.0))
				{
					for (int num12 = j + 1; num12 < order; num12++)
					{
						data[num + num12] /= data[num2];
					}
				}
			}
		}

		public void LUInverse(float[] a, int order)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (a.Length != order * order)
			{
				throw new ArgumentException("The array arguments must have the same length.", "a");
			}
			int[] ipiv = new int[order];
			LUFactor(a, order, ipiv);
			LUInverseFactored(a, order, ipiv);
		}

		public void LUInverseFactored(float[] a, int order, int[] ipiv)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (ipiv == null)
			{
				throw new ArgumentNullException("ipiv");
			}
			if (a.Length != order * order)
			{
				throw new ArgumentException("The array arguments must have the same length.", "a");
			}
			if (ipiv.Length != order)
			{
				throw new ArgumentException("The array arguments must have the same length.", "ipiv");
			}
			float[] array = new float[a.Length];
			for (int i = 0; i < order; i++)
			{
				array[i + order * i] = 1f;
			}
			LUSolveFactored(order, a, order, ipiv, array);
			array.Copy(a);
		}

		public void LUSolve(int columnsOfB, float[] a, int order, float[] b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (a.Length != order * order)
			{
				throw new ArgumentException("The array arguments must have the same length.", "a");
			}
			if (b.Length != order * columnsOfB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			if (a == b)
			{
				throw new ArgumentException("Arguments must be different objects.");
			}
			int[] ipiv = new int[order];
			float[] array = new float[a.Length];
			a.Copy(array);
			LUFactor(array, order, ipiv);
			LUSolveFactored(columnsOfB, array, order, ipiv, b);
		}

		public void LUSolveFactored(int columnsOfB, float[] a, int order, int[] ipiv, float[] b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (ipiv == null)
			{
				throw new ArgumentNullException("ipiv");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (a.Length != order * order)
			{
				throw new ArgumentException("The array arguments must have the same length.", "a");
			}
			if (ipiv.Length != order)
			{
				throw new ArgumentException("The array arguments must have the same length.", "ipiv");
			}
			if (b.Length != order * columnsOfB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			if (a == b)
			{
				throw new ArgumentException("Arguments must be different objects.");
			}
			for (int i = 0; i < ipiv.Length; i++)
			{
				if (ipiv[i] != i)
				{
					int num = ipiv[i];
					for (int j = 0; j < columnsOfB; j++)
					{
						int num2 = j * order;
						int num3 = num2 + num;
						int num4 = num2 + i;
						ref float reference = ref b[num3];
						ref float reference2 = ref b[num4];
						float num5 = b[num4];
						float num6 = b[num3];
						reference = num5;
						reference2 = num6;
					}
				}
			}
			for (int k = 0; k < order; k++)
			{
				int num7 = k * order;
				for (int l = k + 1; l < order; l++)
				{
					for (int m = 0; m < columnsOfB; m++)
					{
						int num8 = m * order;
						b[l + num8] -= b[k + num8] * a[l + num7];
					}
				}
			}
			for (int num9 = order - 1; num9 >= 0; num9--)
			{
				int num10 = num9 + num9 * order;
				for (int n = 0; n < columnsOfB; n++)
				{
					b[num9 + n * order] /= a[num10];
				}
				num10 = num9 * order;
				for (int num11 = 0; num11 < num9; num11++)
				{
					for (int num12 = 0; num12 < columnsOfB; num12++)
					{
						int num13 = num12 * order;
						b[num11 + num13] -= b[num9 + num13] * a[num11 + num10];
					}
				}
			}
		}

		public void CholeskyFactor(float[] a, int order)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			float[] array = new float[order];
			for (int i = 0; i < order; i++)
			{
				float num = a[i * order + i];
				if (!((double)num > 0.0))
				{
					throw new ArgumentException("Matrix must be positive definite.");
				}
				num = (array[i] = (a[i * order + i] = (float)Math.Sqrt(num)));
				for (int j = i + 1; j < order; j++)
				{
					a[i * order + j] /= num;
					array[j] = a[i * order + j];
				}
				DoCholeskyStep(a, order, i + 1, order, array, Control.MaxDegreeOfParallelism);
				for (int k = i + 1; k < order; k++)
				{
					a[k * order + i] = 0f;
				}
			}
		}

		private static void DoCholeskyStep(float[] data, int rowDim, int firstCol, int colLimit, float[] multipliers, int availableCores)
		{
			int num = colLimit - firstCol;
			if (availableCores > 1 && num > Control.ParallelizeElements)
			{
				int tmpSplit = firstCol + num / 3;
				int tmpCores = availableCores / 2;
				CommonParallel.Invoke(delegate
				{
					DoCholeskyStep(data, rowDim, firstCol, tmpSplit, multipliers, tmpCores);
				}, delegate
				{
					DoCholeskyStep(data, rowDim, tmpSplit, colLimit, multipliers, tmpCores);
				});
				return;
			}
			for (int num2 = firstCol; num2 < colLimit; num2++)
			{
				float num3 = multipliers[num2];
				for (int num4 = num2; num4 < rowDim; num4++)
				{
					data[num2 * rowDim + num4] -= multipliers[num4] * num3;
				}
			}
		}

		public void CholeskySolve(float[] a, int orderA, float[] b, int columnsB)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (b.Length != orderA * columnsB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			if (a == b)
			{
				throw new ArgumentException("Arguments must be different objects.");
			}
			float[] array = new float[a.Length];
			a.Copy(array);
			CholeskyFactor(array, orderA);
			CholeskySolveFactored(array, orderA, b, columnsB);
		}

		public void CholeskySolveFactored(float[] a, int orderA, float[] b, int columnsB)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (b.Length != orderA * columnsB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			if (a == b)
			{
				throw new ArgumentException("Arguments must be different objects.");
			}
			CommonParallel.For(0, columnsB, delegate(int u, int v)
			{
				for (int i = u; i < v; i++)
				{
					DoCholeskySolve(a, orderA, b, i);
				}
			});
		}

		private static void DoCholeskySolve(float[] a, int orderA, float[] b, int index)
		{
			int num = index * orderA;
			for (int i = 0; i < orderA; i++)
			{
				float num2 = b[num + i];
				for (int num3 = i - 1; num3 >= 0; num3--)
				{
					num2 -= a[num3 * orderA + i] * b[num + num3];
				}
				b[num + i] = num2 / a[i * orderA + i];
			}
			for (int num4 = orderA - 1; num4 >= 0; num4--)
			{
				float num2 = b[num + num4];
				int num5 = num4 * orderA;
				for (int j = num4 + 1; j < orderA; j++)
				{
					num2 -= a[num5 + j] * b[num + j];
				}
				b[num + num4] = num2 / a[num5 + num4];
			}
		}

		public void QRFactor(float[] r, int rowsR, int columnsR, float[] q, float[] tau)
		{
			if (r == null)
			{
				throw new ArgumentNullException("r");
			}
			if (q == null)
			{
				throw new ArgumentNullException("q");
			}
			if (r.Length != rowsR * columnsR)
			{
				throw new ArgumentException("The given array has the wrong length. Should be rowsR * columnsR.", "r");
			}
			if (tau.Length < Math.Min(rowsR, columnsR))
			{
				throw new ArgumentException("The given array is too small. It must be at least min(m,n) long.", "tau");
			}
			if (q.Length != rowsR * rowsR)
			{
				throw new ArgumentException("The given array has the wrong length. Should be rowsR * rowsR.", "q");
			}
			float[] work = ((columnsR > rowsR) ? new float[rowsR * rowsR] : new float[rowsR * columnsR]);
			CommonParallel.For(0, rowsR, delegate(int a, int b)
			{
				for (int i = a; i < b; i++)
				{
					q[i * rowsR + i] = 1f;
				}
			});
			int num = Math.Min(rowsR, columnsR);
			for (int num2 = 0; num2 < num; num2++)
			{
				GenerateColumn(work, r, rowsR, num2, num2);
				ComputeQR(work, num2, r, num2, rowsR, num2 + 1, columnsR, Control.MaxDegreeOfParallelism);
			}
			for (int num3 = num - 1; num3 >= 0; num3--)
			{
				ComputeQR(work, num3, q, num3, rowsR, num3, rowsR, Control.MaxDegreeOfParallelism);
			}
		}

		public void ThinQRFactor(float[] a, int rowsA, int columnsA, float[] r, float[] tau)
		{
			if (r == null)
			{
				throw new ArgumentNullException("r");
			}
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (a.Length != rowsA * columnsA)
			{
				throw new ArgumentException("The given array has the wrong length. Should be rowsR * columnsR.", "a");
			}
			if (tau.Length < Math.Min(rowsA, columnsA))
			{
				throw new ArgumentException("The given array is too small. It must be at least min(m,n) long.", "tau");
			}
			if (r.Length != columnsA * columnsA)
			{
				throw new ArgumentException("The given array has the wrong length. Should be columnsA * columnsA.", "r");
			}
			float[] work = new float[rowsA * columnsA];
			int num = Math.Min(rowsA, columnsA);
			for (int i = 0; i < num; i++)
			{
				GenerateColumn(work, a, rowsA, i, i);
				ComputeQR(work, i, a, i, rowsA, i + 1, columnsA, Control.MaxDegreeOfParallelism);
			}
			for (int j = 0; j < columnsA; j++)
			{
				int num2 = j * columnsA;
				int num3 = j * rowsA;
				for (int k = 0; k < columnsA; k++)
				{
					r[num2 + k] = a[num3 + k];
				}
			}
			Array.Clear(a, 0, a.Length);
			for (int l = 0; l < columnsA; l++)
			{
				a[l * rowsA + l] = 1f;
			}
			for (int num4 = num - 1; num4 >= 0; num4--)
			{
				ComputeQR(work, num4, a, num4, rowsA, num4, columnsA, Control.MaxDegreeOfParallelism);
			}
		}

		private static void ComputeQR(float[] work, int workIndex, float[] a, int rowStart, int rowCount, int columnStart, int columnCount, int availableCores)
		{
			if (rowStart > rowCount || columnStart > columnCount)
			{
				return;
			}
			int num = columnCount - columnStart;
			if (availableCores > 1 && num > 200)
			{
				int tmpSplit = columnStart + num / 2;
				int tmpCores = availableCores / 2;
				CommonParallel.Invoke(delegate
				{
					ComputeQR(work, workIndex, a, rowStart, rowCount, columnStart, tmpSplit, tmpCores);
				}, delegate
				{
					ComputeQR(work, workIndex, a, rowStart, rowCount, tmpSplit, columnCount, tmpCores);
				});
				return;
			}
			for (int num2 = columnStart; num2 < columnCount; num2++)
			{
				float num3 = 0f;
				for (int num4 = rowStart; num4 < rowCount; num4++)
				{
					num3 += work[workIndex * rowCount + num4 - rowStart] * a[num2 * rowCount + num4];
				}
				for (int num5 = rowStart; num5 < rowCount; num5++)
				{
					a[num2 * rowCount + num5] -= work[workIndex * rowCount + num5 - rowStart] * num3;
				}
			}
		}

		private static void GenerateColumn(float[] work, float[] a, int rowCount, int row, int column)
		{
			int tmp = column * rowCount;
			int num = tmp + row;
			CommonParallel.For(row, rowCount, delegate(int u, int v)
			{
				for (int i = u; i < v; i++)
				{
					int num5 = tmp + i;
					work[num5 - row] = a[num5];
					a[num5] = 0f;
				}
			});
			double num2 = 0.0;
			for (int num3 = 0; num3 < rowCount - row; num3++)
			{
				int num4 = tmp + num3;
				num2 += (double)(work[num4] * work[num4]);
			}
			num2 = Math.Sqrt(num2);
			if (row == rowCount - 1 || num2 == 0.0)
			{
				a[num] = 0f - work[tmp];
				work[tmp] = 1.4142135f;
				return;
			}
			float scale = 1f / (float)num2;
			if ((double)work[tmp] < 0.0)
			{
				scale *= -1f;
			}
			a[num] = -1f / scale;
			CommonParallel.For(0, rowCount - row, 4096, delegate(int u, int v)
			{
				for (int i = u; i < v; i++)
				{
					work[tmp + i] *= scale;
				}
			});
			work[tmp] += 1f;
			float s = (float)Math.Sqrt(1.0 / (double)work[tmp]);
			CommonParallel.For(0, rowCount - row, 4096, delegate(int u, int v)
			{
				for (int i = u; i < v; i++)
				{
					work[tmp + i] *= s;
				}
			});
		}

		public void QRSolve(float[] a, int rows, int columns, float[] b, int columnsB, float[] x, QRMethod method = QRMethod.Full)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (a.Length != rows * columns)
			{
				throw new ArgumentException("The array arguments must have the same length.", "a");
			}
			if (b.Length != rows * columnsB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			if (x.Length != columns * columnsB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "x");
			}
			if (rows < columns)
			{
				throw new ArgumentException("The number of rows must greater than or equal to the number of columns.");
			}
			float[] tau = new float[rows * columns];
			float[] array = new float[a.Length];
			a.Copy(array);
			if (method == QRMethod.Full)
			{
				float[] q = new float[rows * rows];
				QRFactor(array, rows, columns, q, tau);
				QRSolveFactored(q, array, rows, columns, null, b, columnsB, x, method);
			}
			else
			{
				float[] r = new float[columns * columns];
				ThinQRFactor(array, rows, columns, r, tau);
				QRSolveFactored(array, r, rows, columns, null, b, columnsB, x, method);
			}
		}

		public void QRSolveFactored(float[] q, float[] r, int rowsA, int columnsA, float[] tau, float[] b, int columnsB, float[] x, QRMethod method = QRMethod.Full)
		{
			if (r == null)
			{
				throw new ArgumentNullException("r");
			}
			if (q == null)
			{
				throw new ArgumentNullException("q");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (rowsA < columnsA)
			{
				throw new ArgumentException("The number of rows must greater than or equal to the number of columns.");
			}
			int num;
			int num2;
			int num3;
			int num4;
			if (method == QRMethod.Full)
			{
				num = (num2 = (num3 = rowsA));
				num4 = columnsA;
			}
			else
			{
				num = rowsA;
				num2 = (num3 = (num4 = columnsA));
			}
			if (r.Length != num3 * num4)
			{
				throw new ArgumentException($"The given array has the wrong length. Should be {num3 * num4}.", "r");
			}
			if (q.Length != num * num2)
			{
				throw new ArgumentException($"The given array has the wrong length. Should be {num * num2}.", "q");
			}
			if (b.Length != rowsA * columnsB)
			{
				throw new ArgumentException($"The given array has the wrong length. Should be {rowsA * columnsB}.", "b");
			}
			if (x.Length != columnsA * columnsB)
			{
				throw new ArgumentException($"The given array has the wrong length. Should be {columnsA * columnsB}.", "x");
			}
			float[] sol = new float[b.Length];
			Buffer.BlockCopy(b, 0, sol, 0, b.Length * 4);
			float[] column = new float[rowsA];
			for (int i = 0; i < columnsB; i++)
			{
				int jm = i * rowsA;
				Array.Copy(sol, jm, column, 0, rowsA);
				CommonParallel.For(0, columnsA, delegate(int u, int v)
				{
					for (int j = u; j < v; j++)
					{
						int num12 = j * rowsA;
						float num13 = 0f;
						for (int k = 0; k < rowsA; k++)
						{
							num13 += q[num12 + k] * column[k];
						}
						sol[jm + j] = num13;
					}
				});
			}
			for (int num5 = columnsA - 1; num5 >= 0; num5--)
			{
				int num6 = num5 * num3;
				for (int num7 = 0; num7 < columnsB; num7++)
				{
					sol[num7 * rowsA + num5] /= r[num6 + num5];
				}
				for (int num8 = 0; num8 < num5; num8++)
				{
					for (int num9 = 0; num9 < columnsB; num9++)
					{
						int num10 = num9 * rowsA;
						sol[num10 + num8] -= sol[num10 + num5] * r[num6 + num8];
					}
				}
			}
			for (int num11 = 0; num11 < columnsB; num11++)
			{
				Array.Copy(sol, num11 * rowsA, x, num11 * columnsA, num4);
			}
		}

		public void SingularValueDecomposition(bool computeVectors, float[] a, int rowsA, int columnsA, float[] s, float[] u, float[] vt)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			if (u == null)
			{
				throw new ArgumentNullException("u");
			}
			if (vt == null)
			{
				throw new ArgumentNullException("vt");
			}
			if (u.Length != rowsA * rowsA)
			{
				throw new ArgumentException("The array arguments must have the same length.", "u");
			}
			if (vt.Length != columnsA * columnsA)
			{
				throw new ArgumentException("The array arguments must have the same length.", "vt");
			}
			if (s.Length != Math.Min(rowsA, columnsA))
			{
				throw new ArgumentException("The array arguments must have the same length.", "s");
			}
			float[] array = new float[rowsA];
			float[] array2 = new float[columnsA];
			float[] array3 = new float[vt.Length];
			float[] array4 = new float[Math.Min(rowsA + 1, columnsA)];
			int num = Math.Min(rowsA - 1, columnsA);
			int num2 = Math.Max(0, Math.Min(columnsA - 2, rowsA));
			int num3 = Math.Max(num, num2);
			for (int i = 0; i < num3; i++)
			{
				int num4 = i + 1;
				if (i < num)
				{
					int num5 = i;
					float num6 = 0f;
					for (int j = i; j < rowsA; j++)
					{
						num6 += a[num5 * rowsA + j] * a[num5 * rowsA + j];
					}
					array4[i] = (float)Math.Sqrt(num6);
					if ((double)array4[i] != 0.0)
					{
						if ((double)a[i * rowsA + i] != 0.0)
						{
							array4[i] = Math.Abs(array4[i]) * (a[i * rowsA + i] / Math.Abs(a[i * rowsA + i]));
						}
						for (int k = i; k < rowsA; k++)
						{
							a[i * rowsA + k] *= 1f / array4[i];
						}
						a[i * rowsA + i] = 1f + a[i * rowsA + i];
					}
					array4[i] = 0f - array4[i];
				}
				for (int l = num4; l < columnsA; l++)
				{
					if (i < num && (double)array4[i] != 0.0)
					{
						float num7 = 0f;
						for (int k = i; k < rowsA; k++)
						{
							num7 += a[l * rowsA + k] * a[i * rowsA + k];
						}
						num7 = (0f - num7) / a[i * rowsA + i];
						for (int m = i; m < rowsA; m++)
						{
							a[l * rowsA + m] += num7 * a[i * rowsA + m];
						}
					}
					array2[l] = a[l * rowsA + i];
				}
				if (computeVectors && i < num)
				{
					for (int k = i; k < rowsA; k++)
					{
						u[i * rowsA + k] = a[i * rowsA + k];
					}
				}
				if (i >= num2)
				{
					continue;
				}
				double num8 = 0.0;
				for (int k = num4; k < array2.Length; k++)
				{
					num8 += (double)(array2[k] * array2[k]);
				}
				array2[i] = (float)Math.Sqrt(num8);
				if ((double)array2[i] != 0.0)
				{
					if ((double)array2[num4] != 0.0)
					{
						array2[i] = Math.Abs(array2[i]) * (array2[num4] / Math.Abs(array2[num4]));
					}
					for (int k = num4; k < array2.Length; k++)
					{
						array2[k] *= 1f / array2[i];
					}
					array2[num4] = 1f + array2[num4];
				}
				array2[i] = 0f - array2[i];
				if (num4 < rowsA && (double)array2[i] != 0.0)
				{
					for (int k = num4; k < rowsA; k++)
					{
						array[k] = 0f;
					}
					for (int l = num4; l < columnsA; l++)
					{
						for (int n = num4; n < rowsA; n++)
						{
							array[n] += array2[l] * a[l * rowsA + n];
						}
					}
					for (int l = num4; l < columnsA; l++)
					{
						float num9 = (0f - array2[l]) / array2[num4];
						for (int num10 = num4; num10 < rowsA; num10++)
						{
							a[l * rowsA + num10] += num9 * array[num10];
						}
					}
				}
				if (computeVectors)
				{
					for (int k = num4; k < columnsA; k++)
					{
						array3[i * columnsA + k] = array2[k];
					}
				}
			}
			int num11 = Math.Min(columnsA, rowsA + 1);
			int num12 = num + 1;
			int num13 = num2 + 1;
			if (num < columnsA)
			{
				array4[num12 - 1] = a[(num12 - 1) * rowsA + (num12 - 1)];
			}
			if (rowsA < num11)
			{
				array4[num11 - 1] = 0f;
			}
			if (num13 < num11)
			{
				array2[num13 - 1] = a[(num11 - 1) * rowsA + (num13 - 1)];
			}
			array2[num11 - 1] = 0f;
			if (computeVectors)
			{
				for (int l = num12 - 1; l < rowsA; l++)
				{
					for (int k = 0; k < rowsA; k++)
					{
						u[l * rowsA + k] = 0f;
					}
					u[l * rowsA + l] = 1f;
				}
				for (int i = num - 1; i >= 0; i--)
				{
					if ((double)array4[i] != 0.0)
					{
						for (int l = i + 1; l < rowsA; l++)
						{
							float num7 = 0f;
							for (int k = i; k < rowsA; k++)
							{
								num7 += u[l * rowsA + k] * u[i * rowsA + k];
							}
							num7 = (0f - num7) / u[i * rowsA + i];
							for (int num14 = i; num14 < rowsA; num14++)
							{
								u[l * rowsA + num14] += num7 * u[i * rowsA + num14];
							}
						}
						for (int k = i; k < rowsA; k++)
						{
							u[i * rowsA + k] *= -1f;
						}
						u[i * rowsA + i] = 1f + u[i * rowsA + i];
						for (int k = 0; k < i; k++)
						{
							u[i * rowsA + k] = 0f;
						}
					}
					else
					{
						for (int k = 0; k < rowsA; k++)
						{
							u[i * rowsA + k] = 0f;
						}
						u[i * rowsA + i] = 1f;
					}
				}
			}
			if (computeVectors)
			{
				for (int i = columnsA - 1; i >= 0; i--)
				{
					int num4 = i + 1;
					if (i < num2 && (double)array2[i] != 0.0)
					{
						for (int l = num4; l < columnsA; l++)
						{
							float num7 = 0f;
							for (int k = num4; k < columnsA; k++)
							{
								num7 += array3[l * columnsA + k] * array3[i * columnsA + k];
							}
							num7 = (0f - num7) / array3[i * columnsA + num4];
							for (int num15 = i; num15 < columnsA; num15++)
							{
								array3[l * columnsA + num15] += num7 * array3[i * columnsA + num15];
							}
						}
					}
					for (int k = 0; k < columnsA; k++)
					{
						array3[i * columnsA + k] = 0f;
					}
					array3[i * columnsA + i] = 1f;
				}
			}
			for (int k = 0; k < num11; k++)
			{
				float num7;
				float num16;
				if ((double)array4[k] != 0.0)
				{
					num7 = array4[k];
					num16 = array4[k] / num7;
					array4[k] = num7;
					if (k < num11 - 1)
					{
						array2[k] /= num16;
					}
					if (computeVectors)
					{
						for (int l = 0; l < rowsA; l++)
						{
							u[k * rowsA + l] *= num16;
						}
					}
				}
				if (k == num11 - 1)
				{
					break;
				}
				if ((double)array2[k] == 0.0)
				{
					continue;
				}
				num7 = array2[k];
				num16 = num7 / array2[k];
				array2[k] = num7;
				array4[k + 1] *= num16;
				if (computeVectors)
				{
					for (int l = 0; l < columnsA; l++)
					{
						array3[(k + 1) * columnsA + l] *= num16;
					}
				}
			}
			int num17 = num11;
			int num18 = 0;
			while (num11 > 0)
			{
				if (num18 >= 1000)
				{
					throw new NonConvergenceException();
				}
				int i;
				for (i = num11 - 2; i >= 0; i--)
				{
					double num19 = Math.Abs(array4[i]) + Math.Abs(array4[i + 1]);
					if ((num19 + (double)Math.Abs(array2[i])).AlmostEqualRelative(num19, 7))
					{
						array2[i] = 0f;
						break;
					}
				}
				int num20;
				if (i == num11 - 2)
				{
					num20 = 4;
				}
				else
				{
					int num21;
					for (num21 = num11 - 1; num21 > i; num21--)
					{
						double num19 = 0.0;
						if (num21 != num11 - 1)
						{
							num19 += (double)Math.Abs(array2[num21]);
						}
						if (num21 != i + 1)
						{
							num19 += (double)Math.Abs(array2[num21 - 1]);
						}
						if ((num19 + (double)Math.Abs(array4[num21])).AlmostEqualRelative(num19, 7))
						{
							array4[num21] = 0f;
							break;
						}
					}
					if (num21 == i)
					{
						num20 = 3;
					}
					else if (num21 == num11 - 1)
					{
						num20 = 1;
					}
					else
					{
						num20 = 2;
						i = num21;
					}
				}
				i++;
				float c;
				float s2;
				switch (num20)
				{
				case 1:
				{
					float db = array2[num11 - 2];
					array2[num11 - 2] = 0f;
					for (int num36 = i; num36 < num11 - 1; num36++)
					{
						int num24 = num11 - 2 - num36 + i;
						float da = array4[num24];
						Drotg(ref da, ref db, out c, out s2);
						array4[num24] = da;
						if (num24 != i)
						{
							db = (0f - s2) * array2[num24 - 1];
							array2[num24 - 1] = c * array2[num24 - 1];
						}
						if (computeVectors)
						{
							for (int k = 0; k < columnsA; k++)
							{
								float num37 = c * array3[num24 * columnsA + k] + s2 * array3[(num11 - 1) * columnsA + k];
								array3[(num11 - 1) * columnsA + k] = c * array3[(num11 - 1) * columnsA + k] - s2 * array3[num24 * columnsA + k];
								array3[num24 * columnsA + k] = num37;
							}
						}
					}
					break;
				}
				case 2:
				{
					float db = array2[i - 1];
					array2[i - 1] = 0f;
					for (int num24 = i; num24 < num11; num24++)
					{
						float da = array4[num24];
						Drotg(ref da, ref db, out c, out s2);
						array4[num24] = da;
						db = (0f - s2) * array2[num24];
						array2[num24] = c * array2[num24];
						if (computeVectors)
						{
							for (int k = 0; k < rowsA; k++)
							{
								float num25 = c * u[num24 * rowsA + k] + s2 * u[(i - 1) * rowsA + k];
								u[(i - 1) * rowsA + k] = c * u[(i - 1) * rowsA + k] - s2 * u[num24 * rowsA + k];
								u[num24 * rowsA + k] = num25;
							}
						}
					}
					break;
				}
				case 3:
				{
					float val = 0f;
					val = Math.Max(val, Math.Abs(array4[num11 - 1]));
					val = Math.Max(val, Math.Abs(array4[num11 - 2]));
					val = Math.Max(val, Math.Abs(array2[num11 - 2]));
					val = Math.Max(val, Math.Abs(array4[i]));
					val = Math.Max(val, Math.Abs(array2[i]));
					float num26 = array4[num11 - 1] / val;
					float num27 = array4[num11 - 2] / val;
					float num28 = array2[num11 - 2] / val;
					float num29 = array4[i] / val;
					float num30 = array2[i] / val;
					float num31 = ((num27 + num26) * (num27 - num26) + num28 * num28) / 2f;
					float num32 = num26 * num28 * (num26 * num28);
					float num33 = 0f;
					if ((double)num31 != 0.0 || (double)num32 != 0.0)
					{
						num33 = (float)Math.Sqrt(num31 * num31 + num32);
						if ((double)num31 < 0.0)
						{
							num33 = 0f - num33;
						}
						num33 = num32 / (num31 + num33);
					}
					float db = (num29 + num26) * (num29 - num26) + num33;
					float db2 = num29 * num30;
					for (int num24 = i; num24 < num11 - 1; num24++)
					{
						Drotg(ref db, ref db2, out c, out s2);
						if (num24 != i)
						{
							array2[num24 - 1] = db;
						}
						db = c * array4[num24] + s2 * array2[num24];
						array2[num24] = c * array2[num24] - s2 * array4[num24];
						db2 = s2 * array4[num24 + 1];
						array4[num24 + 1] = c * array4[num24 + 1];
						if (computeVectors)
						{
							for (int k = 0; k < columnsA; k++)
							{
								float num34 = c * array3[num24 * columnsA + k] + s2 * array3[(num24 + 1) * columnsA + k];
								array3[(num24 + 1) * columnsA + k] = c * array3[(num24 + 1) * columnsA + k] - s2 * array3[num24 * columnsA + k];
								array3[num24 * columnsA + k] = num34;
							}
						}
						Drotg(ref db, ref db2, out c, out s2);
						array4[num24] = db;
						db = c * array2[num24] + s2 * array4[num24 + 1];
						array4[num24 + 1] = 0f - s2 * array2[num24] + c * array4[num24 + 1];
						db2 = s2 * array2[num24 + 1];
						array2[num24 + 1] = c * array2[num24 + 1];
						if (computeVectors && num24 < rowsA)
						{
							for (int k = 0; k < rowsA; k++)
							{
								float num35 = c * u[num24 * rowsA + k] + s2 * u[(num24 + 1) * rowsA + k];
								u[(num24 + 1) * rowsA + k] = c * u[(num24 + 1) * rowsA + k] - s2 * u[num24 * rowsA + k];
								u[num24 * rowsA + k] = num35;
							}
						}
					}
					array2[num11 - 2] = db;
					num18++;
					break;
				}
				case 4:
					if ((double)array4[i] < 0.0)
					{
						array4[i] = 0f - array4[i];
						if (computeVectors)
						{
							for (int k = 0; k < columnsA; k++)
							{
								array3[i * columnsA + k] *= -1f;
							}
						}
					}
					for (; i != num17 - 1 && !(array4[i] >= array4[i + 1]); i++)
					{
						float num7 = array4[i];
						array4[i] = array4[i + 1];
						array4[i + 1] = num7;
						if (computeVectors && i < columnsA)
						{
							for (int k = 0; k < columnsA; k++)
							{
								ref float reference = ref array3[i * columnsA + k];
								ref float reference2 = ref array3[(i + 1) * columnsA + k];
								float num22 = array3[(i + 1) * columnsA + k];
								float num23 = array3[i * columnsA + k];
								reference = num22;
								reference2 = num23;
							}
						}
						if (computeVectors && i < rowsA)
						{
							for (int k = 0; k < rowsA; k++)
							{
								ref float reference = ref u[i * rowsA + k];
								ref float reference3 = ref u[(i + 1) * rowsA + k];
								float num23 = u[(i + 1) * rowsA + k];
								float num22 = u[i * rowsA + k];
								reference = num23;
								reference3 = num22;
							}
						}
					}
					num18 = 0;
					num11--;
					break;
				}
			}
			if (computeVectors)
			{
				for (int k = 0; k < columnsA; k++)
				{
					for (int l = 0; l < columnsA; l++)
					{
						vt[l * columnsA + k] = array3[k * columnsA + l];
					}
				}
			}
			Buffer.BlockCopy(array4, 0, s, 0, Math.Min(rowsA, columnsA) * 4);
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

		public void SvdSolve(float[] a, int rowsA, int columnsA, float[] b, int columnsB, float[] x)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (b.Length != rowsA * columnsB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			if (x.Length != columnsA * columnsB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			float[] s = new float[Math.Min(rowsA, columnsA)];
			float[] u = new float[rowsA * rowsA];
			float[] vt = new float[columnsA * columnsA];
			float[] array = new float[a.Length];
			Buffer.BlockCopy(a, 0, array, 0, a.Length * 4);
			SingularValueDecomposition(computeVectors: true, array, rowsA, columnsA, s, u, vt);
			SvdSolveFactored(rowsA, columnsA, s, u, vt, b, columnsB, x);
		}

		public void SvdSolveFactored(int rowsA, int columnsA, float[] s, float[] u, float[] vt, float[] b, int columnsB, float[] x)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			if (u == null)
			{
				throw new ArgumentNullException("u");
			}
			if (vt == null)
			{
				throw new ArgumentNullException("vt");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			if (u.Length != rowsA * rowsA)
			{
				throw new ArgumentException("The array arguments must have the same length.", "u");
			}
			if (vt.Length != columnsA * columnsA)
			{
				throw new ArgumentException("The array arguments must have the same length.", "vt");
			}
			if (s.Length != Math.Min(rowsA, columnsA))
			{
				throw new ArgumentException("The array arguments must have the same length.", "s");
			}
			if (b.Length != rowsA * columnsB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			if (x.Length != columnsA * columnsB)
			{
				throw new ArgumentException("The array arguments must have the same length.", "b");
			}
			int num = Math.Min(rowsA, columnsA);
			float[] array = new float[columnsA];
			for (int i = 0; i < columnsB; i++)
			{
				for (int j = 0; j < columnsA; j++)
				{
					float num2 = 0f;
					if (j < num)
					{
						for (int k = 0; k < rowsA; k++)
						{
							num2 += u[j * rowsA + k] * b[i * rowsA + k];
						}
						num2 /= s[j];
					}
					array[j] = num2;
				}
				for (int l = 0; l < columnsA; l++)
				{
					float num3 = 0f;
					for (int m = 0; m < columnsA; m++)
					{
						num3 += vt[l * columnsA + m] * array[m];
					}
					x[i * columnsA + l] = num3;
				}
			}
		}

		public void EigenDecomp(bool isSymmetric, int order, float[] matrix, float[] matrixEv, Complex[] vectorEv, float[] matrixD)
		{
			if (matrix == null)
			{
				throw new ArgumentNullException("matrix");
			}
			if (matrix.Length != order * order)
			{
				throw new ArgumentException($"The given array has the wrong length. Should be {order * order}.", "matrix");
			}
			if (matrixEv == null)
			{
				throw new ArgumentNullException("matrixEv");
			}
			if (matrixEv.Length != order * order)
			{
				throw new ArgumentException($"The given array has the wrong length. Should be {order * order}.", "matrixEv");
			}
			if (vectorEv == null)
			{
				throw new ArgumentNullException("vectorEv");
			}
			if (vectorEv.Length != order)
			{
				throw new ArgumentException($"The given array has the wrong length. Should be {order}.", "vectorEv");
			}
			if (matrixD == null)
			{
				throw new ArgumentNullException("matrixD");
			}
			if (matrixD.Length != order * order)
			{
				throw new ArgumentException($"The given array has the wrong length. Should be {order * order}.", "matrixD");
			}
			float[] array = new float[order];
			float[] array2 = new float[order];
			if (isSymmetric)
			{
				Buffer.BlockCopy(matrix, 0, matrixEv, 0, matrix.Length * 4);
				int num = order - 1;
				for (int i = 0; i < order; i++)
				{
					array[i] = matrixEv[i * order + num];
				}
				SymmetricTridiagonalize(matrixEv, array, array2, order);
				SymmetricDiagonalize(matrixEv, array, array2, order);
			}
			else
			{
				float[] array3 = new float[matrix.Length];
				Buffer.BlockCopy(matrix, 0, array3, 0, matrix.Length * 4);
				NonsymmetricReduceToHessenberg(matrixEv, array3, order);
				NonsymmetricReduceHessenberToRealSchur(matrixEv, array3, array, array2, order);
			}
			for (int j = 0; j < order; j++)
			{
				vectorEv[j] = new Complex(array[j], array2[j]);
				int num2 = j * order;
				matrixD[num2 + j] = array[j];
				if (array2[j] > 0f)
				{
					matrixD[num2 + order + j] = array2[j];
				}
				else if (array2[j] < 0f)
				{
					matrixD[num2 - order + j] = array2[j];
				}
			}
		}

		internal static void SymmetricTridiagonalize(float[] a, float[] d, float[] e, int order)
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
						d[j] = a[j * order + num - 1];
						a[j * order + num] = 0f;
						a[num * order + j] = 0f;
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
						num4 = (a[num * order + m] = d[m]);
						num5 = e[m] + a[m * order + m] * num4;
						for (int n = m + 1; n <= num - 1; n++)
						{
							num5 += a[m * order + n] * d[n];
							e[n] += a[m * order + n] * num4;
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
							a[num9 * order + num10] -= num4 * e[num10] + num5 * d[num10];
						}
						d[num9] = a[num9 * order + num - 1];
						a[num9 * order + num] = 0f;
					}
				}
				d[num] = num3;
			}
			for (int num11 = 0; num11 < order - 1; num11++)
			{
				a[num11 * order + order - 1] = a[num11 * order + num11];
				a[num11 * order + num11] = 1f;
				float num12 = d[num11 + 1];
				if (num12 != 0f)
				{
					for (int num13 = 0; num13 <= num11; num13++)
					{
						d[num13] = a[(num11 + 1) * order + num13] / num12;
					}
					for (int num14 = 0; num14 <= num11; num14++)
					{
						float num15 = 0f;
						for (int num16 = 0; num16 <= num11; num16++)
						{
							num15 += a[(num11 + 1) * order + num16] * a[num14 * order + num16];
						}
						for (int num17 = 0; num17 <= num11; num17++)
						{
							a[num14 * order + num17] -= num15 * d[num17];
						}
					}
				}
				for (int num18 = 0; num18 <= num11; num18++)
				{
					a[(num11 + 1) * order + num18] = 0f;
				}
			}
			for (int num19 = 0; num19 < order; num19++)
			{
				d[num19] = a[num19 * order + order - 1];
				a[num19 * order + order - 1] = 0f;
			}
			a[order * order - 1] = 1f;
			e[0] = 0f;
		}

		internal static void SymmetricDiagonalize(float[] a, float[] d, float[] e, int order)
		{
			for (int i = 1; i < order; i++)
			{
				e[i - 1] = e[i];
			}
			e[order - 1] = 0f;
			float num = 0f;
			float num2 = 0f;
			double singlePrecision = Precision.SinglePrecision;
			for (int j = 0; j < order; j++)
			{
				num2 = Math.Max(num2, Math.Abs(d[j]) + Math.Abs(e[j]));
				int k;
				for (k = j; k < order && !((double)Math.Abs(e[k]) <= singlePrecision * (double)num2); k++)
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
								num8 = a[(num15 + 1) * order + m];
								a[(num15 + 1) * order + m] = num13 * a[num15 * order + m] + num9 * num8;
								a[num15 * order + m] = num9 * a[num15 * order + m] - num13 * num8;
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
					while ((double)Math.Abs(e[j]) > singlePrecision * (double)num2);
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
						num17 = a[n * order + num19];
						a[n * order + num19] = a[num16 * order + num19];
						a[num16 * order + num19] = num17;
					}
				}
			}
		}

		internal static void NonsymmetricReduceToHessenberg(float[] a, float[] matrixH, int order)
		{
			float[] array = new float[order];
			int num = order - 1;
			for (int i = 1; i <= num - 1; i++)
			{
				int num2 = (i - 1) * order;
				float num3 = 0f;
				for (int j = i; j <= num; j++)
				{
					num3 += Math.Abs(matrixH[num2 + j]);
				}
				if (num3 == 0f)
				{
					continue;
				}
				float num4 = 0f;
				for (int num5 = num; num5 >= i; num5--)
				{
					array[num5] = matrixH[num2 + num5] / num3;
					num4 += array[num5] * array[num5];
				}
				float num6 = (float)Math.Sqrt(num4);
				if (array[i] > 0f)
				{
					num6 = 0f - num6;
				}
				num4 -= array[i] * num6;
				array[i] -= num6;
				for (int k = i; k < order; k++)
				{
					int num7 = k * order;
					float num8 = 0f;
					for (int num9 = order - 1; num9 >= i; num9--)
					{
						num8 += array[num9] * matrixH[num7 + num9];
					}
					num8 /= num4;
					for (int l = i; l <= num; l++)
					{
						matrixH[num7 + l] -= num8 * array[l];
					}
				}
				for (int m = 0; m <= num; m++)
				{
					float num10 = 0f;
					for (int num11 = num; num11 >= i; num11--)
					{
						num10 += array[num11] * matrixH[num11 * order + m];
					}
					num10 /= num4;
					for (int n = i; n <= num; n++)
					{
						matrixH[n * order + m] -= num10 * array[n];
					}
				}
				array[i] = num3 * array[i];
				matrixH[num2 + i] = num3 * num6;
			}
			for (int num12 = 0; num12 < order; num12++)
			{
				for (int num13 = 0; num13 < order; num13++)
				{
					a[num13 * order + num12] = ((num12 == num13) ? 1f : 0f);
				}
			}
			for (int num14 = num - 1; num14 >= 1; num14--)
			{
				int num15 = (num14 - 1) * order;
				int num16 = num15 + num14;
				if ((double)matrixH[num16] != 0.0)
				{
					for (int num17 = num14 + 1; num17 <= num; num17++)
					{
						array[num17] = matrixH[num15 + num17];
					}
					for (int num18 = num14; num18 <= num; num18++)
					{
						float num19 = 0f;
						int num20 = num18 * order;
						for (int num21 = num14; num21 <= num; num21++)
						{
							num19 += array[num21] * a[num20 + num21];
						}
						num19 = num19 / array[num14] / matrixH[num16];
						for (int num22 = num14; num22 <= num; num22++)
						{
							a[num20 + num22] += num19 * array[num22];
						}
					}
				}
			}
		}

		internal static void NonsymmetricReduceHessenberToRealSchur(float[] a, float[] matrixH, float[] d, float[] e, int order)
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
					num9 += Math.Abs(matrixH[j * order + i]);
				}
			}
			int num10 = 0;
			while (num >= 0)
			{
				int num11;
				for (num11 = num; num11 > 0; num11--)
				{
					int num12 = num11 - 1;
					int num13 = num12 * order;
					num7 = Math.Abs(matrixH[num13 + num12]) + Math.Abs(matrixH[num11 * order + num11]);
					if ((double)num7 == 0.0)
					{
						num7 = num9;
					}
					if (Math.Abs(matrixH[num13 + num11]) < num2 * num7)
					{
						break;
					}
				}
				if (num11 == num)
				{
					int num14 = num * order + num;
					matrixH[num14] += num3;
					d[num] = matrixH[num14];
					e[num] = 0f;
					num--;
					num10 = 0;
					continue;
				}
				float num20;
				float num19;
				if (num11 == num - 1)
				{
					int num15 = num * order;
					int num16 = num - 1;
					int num17 = num16 * order;
					int num18 = num15 + num;
					num19 = matrixH[num17 + num] * matrixH[num15 + num16];
					num4 = (matrixH[num17 + num16] - matrixH[num18]) / 2f;
					num5 = num4 * num4 + num19;
					num8 = (float)Math.Sqrt(Math.Abs(num5));
					matrixH[num18] += num3;
					matrixH[num17 + num16] += num3;
					num20 = matrixH[num18];
					if (num5 >= 0f)
					{
						num8 = ((!(num4 >= 0f)) ? (num4 - num8) : (num4 + num8));
						d[num16] = num20 + num8;
						d[num] = d[num16];
						if ((double)num8 != 0.0)
						{
							d[num] = num20 - num19 / num8;
						}
						e[num - 1] = 0f;
						e[num] = 0f;
						num20 = matrixH[num17 + num];
						num7 = Math.Abs(num20) + Math.Abs(num8);
						num4 = num20 / num7;
						num5 = num8 / num7;
						num6 = (float)Math.Sqrt(num4 * num4 + num5 * num5);
						num4 /= num6;
						num5 /= num6;
						for (int k = num - 1; k < order; k++)
						{
							int num21 = k * order;
							int num22 = num21 + num;
							num8 = matrixH[num21 + num16];
							matrixH[num21 + num16] = num5 * num8 + num4 * matrixH[num22];
							matrixH[num22] = num5 * matrixH[num22] - num4 * num8;
						}
						for (int l = 0; l <= num; l++)
						{
							int num23 = num15 + l;
							num8 = matrixH[num17 + l];
							matrixH[num17 + l] = num5 * num8 + num4 * matrixH[num23];
							matrixH[num23] = num5 * matrixH[num23] - num4 * num8;
						}
						for (int m = 0; m < order; m++)
						{
							int num24 = num15 + m;
							num8 = a[num17 + m];
							a[num17 + m] = num5 * num8 + num4 * a[num24];
							a[num24] = num5 * a[num24] - num4 * num8;
						}
					}
					else
					{
						d[num - 1] = num20 + num4;
						d[num] = num20 + num4;
						e[num - 1] = num8;
						e[num] = 0f - num8;
					}
					num -= 2;
					num10 = 0;
					continue;
				}
				int num25 = num * order;
				int num26 = num - 1;
				int num27 = num26 * order;
				int num28 = num25 + num;
				num20 = matrixH[num28];
				float num29 = 0f;
				num19 = 0f;
				if (num11 < num)
				{
					num29 = matrixH[num27 + num26];
					num19 = matrixH[num27 + num] * matrixH[num25 + num26];
				}
				if (num10 == 10)
				{
					num3 += num20;
					for (int n = 0; n <= num; n++)
					{
						matrixH[n * order + n] -= num20;
					}
					num7 = Math.Abs(matrixH[num27 + num]) + Math.Abs(matrixH[(num - 2) * order + num26]);
					num20 = (num29 = 0.75f * num7);
					num19 = -0.4375f * num7 * num7;
				}
				if (num10 == 30)
				{
					num7 = (num29 - num20) / 2f;
					num7 = num7 * num7 + num19;
					if (num7 > 0f)
					{
						num7 = (float)Math.Sqrt(num7);
						if (num29 < num20)
						{
							num7 = 0f - num7;
						}
						num7 = num20 - num19 / ((num29 - num20) / 2f + num7);
						for (int num30 = 0; num30 <= num; num30++)
						{
							matrixH[num30 * order + num30] -= num7;
						}
						num3 += num7;
						num20 = (num29 = (num19 = 0.964f));
					}
				}
				num10++;
				if (num10 >= 30 * order)
				{
					throw new NonConvergenceException();
				}
				int num31;
				for (num31 = num - 2; num31 >= num11; num31--)
				{
					int num32 = num31 + 1;
					int num33 = num31 - 1;
					int num34 = num31 * order;
					int num35 = num32 * order;
					int num36 = num33 * order;
					num8 = matrixH[num34 + num31];
					num6 = num20 - num8;
					num7 = num29 - num8;
					num4 = (num6 * num7 - num19) / matrixH[num34 + num32] + matrixH[num35 + num31];
					num5 = matrixH[num35 + num32] - num8 - num6 - num7;
					num6 = matrixH[num35 + (num31 + 2)];
					num7 = Math.Abs(num4) + Math.Abs(num5) + Math.Abs(num6);
					num4 /= num7;
					num5 /= num7;
					num6 /= num7;
					if (num31 == num11 || Math.Abs(matrixH[num36 + num31]) * (Math.Abs(num5) + Math.Abs(num6)) < num2 * (Math.Abs(num4) * (Math.Abs(matrixH[num36 + num33]) + Math.Abs(num8) + Math.Abs(matrixH[num35 + num32]))))
					{
						break;
					}
				}
				int num37 = num31 + 2;
				for (int num38 = num37; num38 <= num; num38++)
				{
					matrixH[(num38 - 2) * order + num38] = 0f;
					if (num38 > num37)
					{
						matrixH[(num38 - 3) * order + num38] = 0f;
					}
				}
				for (int num39 = num31; num39 <= num - 1; num39++)
				{
					bool flag = num39 != num - 1;
					int num40 = num39 * order;
					int num41 = num39 - 1;
					int num42 = num39 + 1;
					int num43 = num39 + 2;
					int num44 = num42 * order;
					int num45 = num43 * order;
					int num46 = num41 * order;
					if (num39 != num31)
					{
						num4 = matrixH[num46 + num39];
						num5 = matrixH[num46 + num42];
						num6 = (flag ? matrixH[num46 + num43] : 0f);
						num20 = Math.Abs(num4) + Math.Abs(num5) + Math.Abs(num6);
						if (num20 == 0f)
						{
							continue;
						}
						num4 /= num20;
						num5 /= num20;
						num6 /= num20;
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
					if (num39 != num31)
					{
						matrixH[num46 + num39] = (0f - num7) * num20;
					}
					else if (num11 != num31)
					{
						matrixH[num46 + num39] = 0f - matrixH[num46 + num39];
					}
					num4 += num7;
					num20 = num4 / num7;
					num29 = num5 / num7;
					num8 = num6 / num7;
					num5 /= num4;
					num6 /= num4;
					for (int num47 = num39; num47 < order; num47++)
					{
						int num48 = num47 * order;
						int num49 = num48 + num39;
						int num50 = num48 + num42;
						int num51 = num48 + num43;
						num4 = matrixH[num49] + num5 * matrixH[num50];
						if (flag)
						{
							num4 += num6 * matrixH[num51];
							matrixH[num51] -= num4 * num8;
						}
						matrixH[num49] -= num4 * num20;
						matrixH[num50] -= num4 * num29;
					}
					for (int num52 = 0; num52 <= Math.Min(num, num39 + 3); num52++)
					{
						num4 = num20 * matrixH[num40 + num52] + num29 * matrixH[num44 + num52];
						if (flag)
						{
							num4 += num8 * matrixH[num45 + num52];
							matrixH[num45 + num52] -= num4 * num6;
						}
						matrixH[num40 + num52] -= num4;
						matrixH[num44 + num52] -= num4 * num5;
					}
					for (int num53 = 0; num53 < order; num53++)
					{
						num4 = num20 * a[num40 + num53] + num29 * a[num44 + num53];
						if (flag)
						{
							num4 += num8 * a[num45 + num53];
							a[num45 + num53] -= num4 * num6;
						}
						a[num40 + num53] -= num4;
						a[num44 + num53] -= num4 * num5;
					}
				}
			}
			if (num9 == 0f)
			{
				return;
			}
			for (num = order - 1; num >= 0; num--)
			{
				int num54 = num * order;
				int num55 = num - 1;
				int num56 = num55 * order;
				num4 = d[num];
				num5 = e[num];
				if (num5 == 0f)
				{
					int num57 = num;
					matrixH[num54 + num] = 1f;
					for (int num58 = num - 1; num58 >= 0; num58--)
					{
						int num59 = num58 + 1;
						int num60 = num58 * order;
						int num61 = num59 * order;
						float num19 = matrixH[num60 + num58] - num4;
						num6 = 0f;
						for (int num62 = num57; num62 <= num; num62++)
						{
							num6 += matrixH[num62 * order + num58] * matrixH[num54 + num62];
						}
						if ((double)e[num58] < 0.0)
						{
							num8 = num19;
							num7 = num6;
						}
						else
						{
							num57 = num58;
							float num63;
							if (e[num58] == 0f)
							{
								if (num19 != 0f)
								{
									matrixH[num54 + num58] = (0f - num6) / num19;
								}
								else
								{
									matrixH[num54 + num58] = (0f - num6) / (num2 * num9);
								}
							}
							else
							{
								float num20 = matrixH[num61 + num58];
								float num29 = matrixH[num60 + num59];
								num5 = (d[num58] - num4) * (d[num58] - num4) + e[num58] * e[num58];
								num63 = (matrixH[num54 + num58] = (num20 * num7 - num8 * num6) / num5);
								if (Math.Abs(num20) > Math.Abs(num8))
								{
									matrixH[num54 + num59] = (0f - num6 - num19 * num63) / num20;
								}
								else
								{
									matrixH[num54 + num59] = (0f - num7 - num29 * num63) / num8;
								}
							}
							num63 = Math.Abs(matrixH[num54 + num58]);
							if (num2 * num63 * num63 > 1f)
							{
								for (int num64 = num58; num64 <= num; num64++)
								{
									matrixH[num54 + num64] /= num63;
								}
							}
						}
					}
				}
				else if (num5 < 0f)
				{
					int num65 = num - 1;
					if (Math.Abs(matrixH[num56 + num]) > Math.Abs(matrixH[num54 + num55]))
					{
						matrixH[num56 + num55] = num5 / matrixH[num56 + num];
						matrixH[num54 + num55] = (0f - (matrixH[num54 + num] - num4)) / matrixH[num56 + num];
					}
					else
					{
						Complex32 complex = Cdiv(0f, 0f - matrixH[num54 + num55], matrixH[num56 + num55] - num4, num5);
						matrixH[num56 + num55] = complex.Real;
						matrixH[num54 + num55] = complex.Imaginary;
					}
					matrixH[num56 + num] = 0f;
					matrixH[num54 + num] = 1f;
					for (int num66 = num - 2; num66 >= 0; num66--)
					{
						int num67 = num66 + 1;
						int num68 = num66 * order;
						int num69 = num67 * order;
						float num70 = 0f;
						float num71 = 0f;
						for (int num72 = num65; num72 <= num; num72++)
						{
							int num73 = num72 * order + num66;
							num70 += matrixH[num73] * matrixH[num56 + num72];
							num71 += matrixH[num73] * matrixH[num54 + num72];
						}
						float num19 = matrixH[num68 + num66] - num4;
						if ((double)e[num66] < 0.0)
						{
							num8 = num19;
							num6 = num70;
							num7 = num71;
						}
						else
						{
							num65 = num66;
							if ((double)e[num66] == 0.0)
							{
								Complex32 complex2 = Cdiv(0f - num70, 0f - num71, num19, num5);
								matrixH[num56 + num66] = complex2.Real;
								matrixH[num54 + num66] = complex2.Imaginary;
							}
							else
							{
								float num20 = matrixH[num69 + num66];
								float num29 = matrixH[num68 + num67];
								float num74 = (d[num66] - num4) * (d[num66] - num4) + e[num66] * e[num66] - num5 * num5;
								float num75 = (d[num66] - num4) * 2f * num5;
								if (num74 == 0f && num75 == 0f)
								{
									num74 = num2 * num9 * (Math.Abs(num19) + Math.Abs(num5) + Math.Abs(num20) + Math.Abs(num29) + Math.Abs(num8));
								}
								Complex32 complex3 = Cdiv(num20 * num6 - num8 * num70 + num5 * num71, num20 * num7 - num8 * num71 - num5 * num70, num74, num75);
								matrixH[num56 + num66] = complex3.Real;
								matrixH[num54 + num66] = complex3.Imaginary;
								if (Math.Abs(num20) > Math.Abs(num8) + Math.Abs(num5))
								{
									matrixH[num56 + num67] = (0f - num70 - num19 * matrixH[num56 + num66] + num5 * matrixH[num54 + num66]) / num20;
									matrixH[num54 + num67] = (0f - num71 - num19 * matrixH[num54 + num66] - num5 * matrixH[num56 + num66]) / num20;
								}
								else
								{
									complex3 = Cdiv(0f - num6 - num29 * matrixH[num56 + num66], 0f - num7 - num29 * matrixH[num54 + num66], num8, num5);
									matrixH[num56 + num67] = complex3.Real;
									matrixH[num54 + num67] = complex3.Imaginary;
								}
							}
							float num63 = Math.Max(Math.Abs(matrixH[num56 + num66]), Math.Abs(matrixH[num54 + num66]));
							if (num2 * num63 * num63 > 1f)
							{
								for (int num76 = num66; num76 <= num; num76++)
								{
									matrixH[num56 + num76] /= num63;
									matrixH[num54 + num76] /= num63;
								}
							}
						}
					}
				}
			}
			for (int num77 = order - 1; num77 >= 0; num77--)
			{
				int num78 = num77 * order;
				for (int num79 = 0; num79 < order; num79++)
				{
					num8 = 0f;
					for (int num80 = 0; num80 <= num77; num80++)
					{
						num8 += a[num80 * order + num79] * matrixH[num78 + num80];
					}
					a[num78 + num79] = num8;
				}
			}
		}

		private static Complex32 Cdiv(float xreal, float ximag, float yreal, float yimag)
		{
			if (Math.Abs(yimag) < Math.Abs(yreal))
			{
				return new Complex32((xreal + ximag * (yimag / yreal)) / (yreal + yimag * (yimag / yreal)), (ximag - xreal * (yimag / yreal)) / (yreal + yimag * (yimag / yreal)));
			}
			return new Complex32((ximag + xreal * (yreal / yimag)) / (yimag + yreal * (yreal / yimag)), (0f - xreal + ximag * (yreal / yimag)) / (yimag + yreal * (yreal / yimag)));
		}
	}
}
