using System.Numerics;

namespace MathNet.Numerics.Providers.SparseSolver
{
	public interface ISparseSolverProvider : ISparseSolverProvider<double>, ISparseSolverProvider<float>, ISparseSolverProvider<Complex>, ISparseSolverProvider<Complex32>
	{
		bool IsAvailable();

		void InitializeVerify();

		void FreeResources();
	}
	public interface ISparseSolverProvider<T> where T : struct
	{
		DssStatus Solve(DssMatrixStructure matrixStructure, DssMatrixType matrixType, DssSystemType systemType, int rows, int cols, int nnz, int[] rowIdx, int[] colPtr, T[] values, int nRhs, T[] rhs, T[] solution);
	}
}
