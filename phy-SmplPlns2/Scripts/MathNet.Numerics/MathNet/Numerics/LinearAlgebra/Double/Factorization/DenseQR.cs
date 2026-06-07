using System;
using MathNet.Numerics.LinearAlgebra.Factorization;
using MathNet.Numerics.Providers.LinearAlgebra;

namespace MathNet.Numerics.LinearAlgebra.Double.Factorization
{
	internal sealed class DenseQR : QR
	{
		private double[] Tau { get; set; }

		public static DenseQR Create(DenseMatrix matrix, QRMethod method = QRMethod.Full)
		{
			if (matrix.RowCount < matrix.ColumnCount)
			{
				throw Matrix<double>.DimensionsDontMatch<ArgumentException>(matrix);
			}
			double[] tau = new double[Math.Min(matrix.RowCount, matrix.ColumnCount)];
			Matrix<double> matrix2;
			Matrix<double> matrix3;
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

		private DenseQR(Matrix<double> q, Matrix<double> rFull, QRMethod method, double[] tau)
			: base(q, rFull, method)
		{
			Tau = tau;
		}

		public override void Solve(Matrix<double> input, Matrix<double> result)
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

		public override void Solve(Vector<double> input, Vector<double> result)
		{
			if (base.Q.RowCount != input.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (FullR.ColumnCount != result.Count)
			{
				throw Matrix<double>.DimensionsDontMatch<ArgumentException>(FullR, result);
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
