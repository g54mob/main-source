using System.Numerics;
using MathNet.Numerics.LinearAlgebra.Factorization;

namespace MathNet.Numerics.Providers.LinearAlgebra
{
	public interface ILinearAlgebraProvider : ILinearAlgebraProvider<double>, ILinearAlgebraProvider<float>, ILinearAlgebraProvider<Complex>, ILinearAlgebraProvider<Complex32>
	{
		bool IsAvailable();

		void InitializeVerify();

		void FreeResources();
	}
	public interface ILinearAlgebraProvider<T> where T : struct
	{
		void AddVectorToScaledVector(T[] y, T alpha, T[] x, T[] result);

		void ScaleArray(T alpha, T[] x, T[] result);

		void ConjugateArray(T[] x, T[] result);

		T DotProduct(T[] x, T[] y);

		void AddArrays(T[] x, T[] y, T[] result);

		void SubtractArrays(T[] x, T[] y, T[] result);

		void PointWiseMultiplyArrays(T[] x, T[] y, T[] result);

		void PointWiseDivideArrays(T[] x, T[] y, T[] result);

		void PointWisePowerArrays(T[] x, T[] y, T[] result);

		double MatrixNorm(Norm norm, int rows, int columns, T[] matrix);

		void MatrixMultiply(T[] x, int rowsX, int columnsX, T[] y, int rowsY, int columnsY, T[] result);

		void MatrixMultiplyWithUpdate(Transpose transposeA, Transpose transposeB, T alpha, T[] a, int rowsA, int columnsA, T[] b, int rowsB, int columnsB, T beta, T[] c);

		void LUFactor(T[] data, int order, int[] ipiv);

		void LUInverse(T[] a, int order);

		void LUInverseFactored(T[] a, int order, int[] ipiv);

		void LUSolve(int columnsOfB, T[] a, int order, T[] b);

		void LUSolveFactored(int columnsOfB, T[] a, int order, int[] ipiv, T[] b);

		void CholeskyFactor(T[] a, int order);

		void CholeskySolve(T[] a, int orderA, T[] b, int columnsB);

		void CholeskySolveFactored(T[] a, int orderA, T[] b, int columnsB);

		void QRFactor(T[] a, int rowsA, int columnsA, T[] q, T[] tau);

		void ThinQRFactor(T[] a, int rowsA, int columnsA, T[] r, T[] tau);

		void QRSolve(T[] a, int rows, int columns, T[] b, int columnsB, T[] x, QRMethod method = QRMethod.Full);

		void QRSolveFactored(T[] q, T[] r, int rowsA, int columnsA, T[] tau, T[] b, int columnsB, T[] x, QRMethod method = QRMethod.Full);

		void SingularValueDecomposition(bool computeVectors, T[] a, int rowsA, int columnsA, T[] s, T[] u, T[] vt);

		void SvdSolve(T[] a, int rowsA, int columnsA, T[] b, int columnsB, T[] x);

		void SvdSolveFactored(int rowsA, int columnsA, T[] s, T[] u, T[] vt, T[] b, int columnsB, T[] x);

		void EigenDecomp(bool isSymmetric, int order, T[] matrix, T[] matrixEv, Complex[] vectorEv, T[] matrixD);
	}
}
