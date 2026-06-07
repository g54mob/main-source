using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra.Solvers;

namespace MathNet.Numerics.LinearAlgebra.Complex32.Solvers
{
	public sealed class CompositeSolver : IIterativeSolver<MathNet.Numerics.Complex32>
	{
		private readonly List<Tuple<IIterativeSolver<MathNet.Numerics.Complex32>, IPreconditioner<MathNet.Numerics.Complex32>>> _solvers;

		public CompositeSolver(IEnumerable<IIterativeSolverSetup<MathNet.Numerics.Complex32>> solvers)
		{
			_solvers = solvers.Select((IIterativeSolverSetup<MathNet.Numerics.Complex32> setup) => new Tuple<IIterativeSolver<MathNet.Numerics.Complex32>, IPreconditioner<MathNet.Numerics.Complex32>>(setup.CreateSolver(), setup.CreatePreconditioner() ?? new UnitPreconditioner<MathNet.Numerics.Complex32>())).ToList();
		}

		public void Solve(Matrix<MathNet.Numerics.Complex32> matrix, Vector<MathNet.Numerics.Complex32> input, Vector<MathNet.Numerics.Complex32> result, Iterator<MathNet.Numerics.Complex32> iterator, IPreconditioner<MathNet.Numerics.Complex32> preconditioner)
		{
			if (matrix.RowCount != matrix.ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.", "matrix");
			}
			if (result.Count != input.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (iterator == null)
			{
				iterator = new Iterator<MathNet.Numerics.Complex32>();
			}
			if (preconditioner == null)
			{
				preconditioner = new UnitPreconditioner<MathNet.Numerics.Complex32>();
			}
			Vector<MathNet.Numerics.Complex32> vector = input.Clone();
			Vector<MathNet.Numerics.Complex32> vector2 = result.Clone();
			foreach (Tuple<IIterativeSolver<MathNet.Numerics.Complex32>, IPreconditioner<MathNet.Numerics.Complex32>> solver in _solvers)
			{
				IterationStatus status;
				try
				{
					iterator.Reset();
					solver.Item1.Solve(matrix, vector, vector2, iterator, solver.Item2 ?? preconditioner);
					status = iterator.Status;
				}
				catch (Exception)
				{
					input.CopyTo(vector);
					continue;
				}
				switch (status)
				{
				case IterationStatus.Converged:
					vector2.CopyTo(result);
					return;
				case IterationStatus.StoppedWithoutConvergence:
					vector2.CopyTo(result);
					break;
				default:
					input.CopyTo(vector);
					break;
				}
			}
		}
	}
}
