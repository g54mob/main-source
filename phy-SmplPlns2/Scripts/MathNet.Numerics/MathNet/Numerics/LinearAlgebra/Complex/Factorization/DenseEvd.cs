using System;
using System.Numerics;
using MathNet.Numerics.Providers.LinearAlgebra;

namespace MathNet.Numerics.LinearAlgebra.Complex.Factorization
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
			DenseMatrix denseMatrix = DenseMatrix.CreateIdentity(rowCount);
			DenseMatrix denseMatrix2 = new DenseMatrix(rowCount);
			DenseVector denseVector = new DenseVector(rowCount);
			bool isSymmetric = symmetricity switch
			{
				Symmetricity.Hermitian => true, 
				Symmetricity.Asymmetric => false, 
				_ => matrix.IsHermitian(), 
			};
			LinearAlgebraControl.Provider.EigenDecomp(isSymmetric, rowCount, matrix.Values, denseMatrix.Values, denseVector.Values, denseMatrix2.Values);
			return new DenseEvd(denseMatrix, denseVector, denseMatrix2, isSymmetric);
		}

		private DenseEvd(Matrix<System.Numerics.Complex> eigenVectors, Vector<System.Numerics.Complex> eigenValues, Matrix<System.Numerics.Complex> blockDiagonal, bool isSymmetric)
			: base(eigenVectors, eigenValues, blockDiagonal, isSymmetric)
		{
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
								complex += ((DenseMatrix)base.EigenVectors).Values[j * count + k].Conjugate() * input.At(k, i);
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
							value += ((DenseMatrix)base.EigenVectors).Values[m * count + l] * array[m];
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
							complex += ((DenseMatrix)base.EigenVectors).Values[i * count + j].Conjugate() * input[j];
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
						complex += ((DenseMatrix)base.EigenVectors).Values[l * count + k] * array[l];
					}
					result[k] = complex;
				}
				return;
			}
			throw new ArgumentException("Matrix must be symmetric.");
		}
	}
}
