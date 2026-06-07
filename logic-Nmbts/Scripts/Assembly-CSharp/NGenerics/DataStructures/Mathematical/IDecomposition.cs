namespace NGenerics.DataStructures.Mathematical
{
	public interface IDecomposition
	{
		Matrix LeftFactorMatrix { get; }

		Matrix RightFactorMatrix { get; }

		Matrix Solve(Matrix right);

		void Decompose(Matrix matrix);
	}
}
