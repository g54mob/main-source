using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra.Solvers;

namespace MathNet.Numerics.LinearAlgebra.Single.Solvers
{
	public sealed class CompositeSolver : IIterativeSolver<float>
	{
		private readonly List<Tuple<IIterativeSolver<float>, IPreconditioner<float>>> _solvers;

		public CompositeSolver(IEnumerable<IIterativeSolverSetup<float>> solvers)
		{
			_solvers = solvers.Select((IIterativeSolverSetup<float> setup) => new Tuple<IIterativeSolver<float>, IPreconditioner<float>>(setup.CreateSolver(), setup.CreatePreconditioner() ?? new UnitPreconditioner<float>())).ToList();
		}

		public void Solve(Matrix<float> matrix, Vector<float> input, Vector<float> result, Iterator<float> iterator, IPreconditioner<float> preconditioner)
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
				iterator = new Iterator<float>();
			}
			if (preconditioner == null)
			{
				preconditioner = new UnitPreconditioner<float>();
			}
			Vector<float> vector = input.Clone();
			Vector<float> vector2 = result.Clone();
			foreach (Tuple<IIterativeSolver<float>, IPreconditioner<float>> solver in _solvers)
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
