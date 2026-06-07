using System;
using System.Numerics;

namespace MathNet.Numerics.Providers.SparseSolver
{
	public sealed class ManagedSparseSolverProvider : ISparseSolverProvider, ISparseSolverProvider<double>, ISparseSolverProvider<float>, ISparseSolverProvider<Complex>, ISparseSolverProvider<Complex32>
	{
		public static ManagedSparseSolverProvider Instance { get; } = new ManagedSparseSolverProvider();

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

		public DssStatus Solve(DssMatrixStructure matrixStructure, DssMatrixType matrixType, DssSystemType systemType, int rowCount, int columnCount, int nonZerosCount, int[] rowPointers, int[] columnIndices, float[] values, int nRhs, float[] rhs, float[] solution)
		{
			throw new NotImplementedException();
		}

		public DssStatus Solve(DssMatrixStructure matrixStructure, DssMatrixType matrixType, DssSystemType systemType, int rowCount, int columnCount, int nonZerosCount, int[] rowPointers, int[] columnIndices, double[] values, int nRhs, double[] rhs, double[] solution)
		{
			throw new NotImplementedException();
		}

		public DssStatus Solve(DssMatrixStructure matrixStructure, DssMatrixType matrixType, DssSystemType systemType, int rowCount, int columnCount, int nonZerosCount, int[] rowPointers, int[] columnIndices, Complex32[] values, int nRhs, Complex32[] rhs, Complex32[] solution)
		{
			throw new NotImplementedException();
		}

		public DssStatus Solve(DssMatrixStructure matrixStructure, DssMatrixType matrixType, DssSystemType systemType, int rowCount, int columnCount, int nonZerosCount, int[] rowPointers, int[] columnIndices, Complex[] values, int nRhs, Complex[] rhs, Complex[] solution)
		{
			throw new NotImplementedException();
		}
	}
}
