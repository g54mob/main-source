using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra.Solvers;

namespace MathNet.Numerics.LinearAlgebra.Double.Solvers
{
	public sealed class CompositeSolver : IIterativeSolver<double>
	{
		private readonly List<Tuple<IIterativeSolver<double>, IPreconditioner<double>>> _solvers;

		public CompositeSolver(IEnumerable<IIterativeSolverSetup<double>> solvers)
		{
			_solvers = solvers.Select((IIterativeSolverSetup<double> setup) => new Tuple<IIterativeSolver<double>, IPreconditioner<double>>(setup.CreateSolver(), setup.CreatePreconditioner() ?? new UnitPreconditioner<double>())).ToList();
		}

		public void Solve(Matrix<double> matrix, Vector<double> input, Vector<double> result, Iterator<double> iterator, IPreconditioner<double> preconditioner)
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
				iterator = new Iterator<double>();
			}
			if (preconditioner == null)
			{
				preconditioner = new UnitPreconditioner<double>();
			}
			Vector<double> vector = input.Clone();
			Vector<double> vector2 = result.Clone();
			foreach (Tuple<IIterativeSolver<double>, IPreconditioner<double>> solver in _solvers)
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
