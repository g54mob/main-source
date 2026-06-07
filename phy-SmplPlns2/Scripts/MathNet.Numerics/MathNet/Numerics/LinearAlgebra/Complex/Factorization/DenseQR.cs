using System;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra.Factorization;
using MathNet.Numerics.Providers.LinearAlgebra;

namespace MathNet.Numerics.LinearAlgebra.Complex.Factorization
{
	internal sealed class DenseQR : QR
	{
		private System.Numerics.Complex[] Tau { get; set; }

		public static DenseQR Create(DenseMatrix matrix, QRMethod method = QRMethod.Full)
		{
			if (matrix.RowCount < matrix.ColumnCount)
			{
				throw Matrix<System.Numerics.Complex>.DimensionsDontMatch<ArgumentException>(matrix);
			}
			System.Numerics.Complex[] tau = new System.Numerics.Complex[Math.Min(matrix.RowCount, matrix.ColumnCount)];
			Matrix<System.Numerics.Complex> matrix2;
			Matrix<System.Numerics.Complex> matrix3;
			if (method == QRMethod.Full)
			{
				matrix2 = matrix.Clone();
				matrix3 = new DenseMatrix(matrix.RowCount);
				LinearAlgebraControl.Provider.QRFactor(((DenseMatrix)matrix2).Values, matrix.RowCount, matrix.ColumnCount, ((DenseMatrix)matrix3).Values, tau);
			}
			else
			{
				matrix3 = matrix.Clone();
				matrix2 = new DenseMatrix(matrix.ColumnCount);
				LinearAlgebraControl.Provider.ThinQRFactor(((DenseMatrix)matrix3).Values, matrix.RowCount, matrix.ColumnCount, ((DenseMatrix)matrix2).Values, tau);
			}
			return new DenseQR(matrix3, matrix2, method, tau);
		}

		private DenseQR(Matrix<System.Numerics.Complex> q, Matrix<System.Numerics.Complex> rFull, QRMethod method, System.Numerics.Complex[] tau)
			: base(q, rFull, method)
		{
			Tau = tau;
		}

		public override void Solve(Matrix<System.Numerics.Complex> input, Matrix<System.Numerics.Complex> result)
		{
			if (input.ColumnCount != result.ColumnCount)
			{
				throw new ArgumentException("Matrix column dimensions must agree.");
			}
			if (base.Q.RowCount != input.RowCount)
			{
				throw new ArgumentException("Matrix row dimensions must agree.");
			}
			if (FullR.ColumnCount != result.RowCount)
			{
				throw new ArgumentException("Matrix column dimensions must agree.");
			}
			if (input is DenseMatrix denseMatrix && result is DenseMatrix denseMatrix2)
			{
				LinearAlgebraControl.Provider.QRSolveFactored(((DenseMatrix)base.Q).Values, ((DenseMatrix)FullR).Values, base.Q.RowCount, FullR.ColumnCount, Tau, denseMatrix.Values, input.ColumnCount, denseMatrix2.Values, Method);
				return;
			}
			throw new NotSupportedException("Can only do QR factorization for dense matrices at the moment.");
		}

		public override void Solve(Vector<System.Numerics.Complex> input, Vector<System.Numerics.Complex> result)
		{
			if (base.Q.RowCount != input.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (FullR.ColumnCount != result.Count)
			{
				throw Matrix<System.Numerics.Complex>.DimensionsDontMatch<ArgumentException>(FullR, result);
			}
			if (input is DenseVector denseVector && result is DenseVector denseVector2)
			{
				LinearAlgebraControl.Provider.QRSolveFactored(((DenseMatrix)base.Q).Values, ((DenseMatrix)FullR).Values, base.Q.RowCount, FullR.ColumnCount, Tau, denseVector.Values, 1, denseVector2.Values, Method);
				return;
			}
			throw new NotSupportedException("Can only do QR factorization for dense vectors at the moment.");
		}
	}
}
