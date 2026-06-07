using System;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra.Complex;
using MathNet.Numerics.Providers.LinearAlgebra;

namespace MathNet.Numerics.LinearAlgebra.Double.Factorization
{
	internal sealed class DenseEvd : Evd
	{
		public static DenseEvd Create(DenseMatrix matrix, Symmetricity symmetricity)
		{
			if (matrix.RowCount != matrix.ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.");
			}
			int rowCount = matrix.RowCount;
			DenseMatrix denseMatrix = new DenseMatrix(rowCount);
			DenseMatrix denseMatrix2 = new DenseMatrix(rowCount);
			MathNet.Numerics.LinearAlgebra.Complex.DenseVector denseVector = new MathNet.Numerics.LinearAlgebra.Complex.DenseVector(rowCount);
			bool isSymmetric;
			switch (symmetricity)
			{
			case Symmetricity.Symmetric:
			case Symmetricity.Hermitian:
				isSymmetric = true;
				break;
			case Symmetricity.Asymmetric:
				isSymmetric = false;
				break;
			default:
				isSymmetric = matrix.IsSymmetric();
				break;
			}
			LinearAlgebraControl.Provider.EigenDecomp(isSymmetric, rowCount, matrix.Values, denseMatrix.Values, denseVector.Values, denseMatrix2.Values);
			return new DenseEvd(denseMatrix, denseVector, denseMatrix2, isSymmetric);
		}

		private DenseEvd(Matrix<double> eigenVectors, Vector<System.Numerics.Complex> eigenValues, Matrix<double> blockDiagonal, bool isSymmetric)
			: base(eigenVectors, eigenValues, blockDiagonal, isSymmetric)
		{
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
								num += ((DenseMatrix)base.EigenVectors).Values[j * count + k] * input.At(k, i);
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
							num2 += ((DenseMatrix)base.EigenVectors).Values[m * count + l] * array[m];
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
							num += ((DenseMatrix)base.EigenVectors).Values[i * count + j] * input[j];
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
						num += ((DenseMatrix)base.EigenVectors).Values[l * count + k] * array[l];
					}
					result[k] = num;
				}
				return;
			}
			throw new ArgumentException("Matrix must be symmetric.");
		}
	}
}
