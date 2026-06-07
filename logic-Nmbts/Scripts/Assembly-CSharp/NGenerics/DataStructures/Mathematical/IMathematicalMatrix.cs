using NGenerics.DataStructures.General;

namespace NGenerics.DataStructures.Mathematical
{
	public interface IMathematicalMatrix : IMatrix<double>
	{
		bool IsSymmetric { get; }

		bool IsSingular { get; }

		IMathematicalMatrix Inverse();

		double Determinant();

		IMathematicalMatrix Negate();

		IMathematicalMatrix Subtract(IMathematicalMatrix matrix);

		IMathematicalMatrix Add(IMathematicalMatrix matrix);

		IMathematicalMatrix Multiply(IMathematicalMatrix matrix);

		IMathematicalMatrix Multiply(double number);

		void MultiplyRow(int row, double number);

		void MultiplyColumn(int column, double number);

		IMathematicalMatrix Transpose();

		IMathematicalMatrix Minor(int row, int column);

		IMathematicalMatrix Adjoint();

		IMathematicalMatrix Concatenate(IMathematicalMatrix rightMatrix);
	}
}
