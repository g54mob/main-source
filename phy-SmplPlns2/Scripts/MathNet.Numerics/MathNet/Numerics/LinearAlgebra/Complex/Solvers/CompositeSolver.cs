using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra.Solvers;

namespace MathNet.Numerics.LinearAlgebra.Complex.Solvers
{
	public sealed class CompositeSolver : IIterativeSolver<System.Numerics.Complex>
	{
		private readonly List<Tuple<IIterativeSolver<System.Numerics.Complex>, IPreconditioner<System.Numerics.Complex>>> _solvers;

		public CompositeSolver(IEnumerable<IIterativeSolverSetup<System.Numerics.Complex>> solvers)
		{
			_solvers = solvers.Select((IIterativeSolverSetup<System.Numerics.Complex> setup) => new Tuple<IIterativeSolver<System.Numerics.Complex>, IPreconditioner<System.Numerics.Complex>>(setup.CreateSolver(), setup.CreatePreconditioner() ?? new UnitPreconditioner<System.Numerics.Complex>())).ToList();
		}

		public void Solve(Matrix<System.Numerics.Complex> matrix, Vector<System.Numerics.Complex> input, Vector<System.Numerics.Complex> result, Iterator<System.Numerics.Complex> iterator, IPreconditioner<System.Numerics.Complex> preconditioner)
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
				iterator = new Iterator<System.Numerics.Complex>();
			}
			if (preconditioner == null)
			{
				preconditioner = new UnitPreconditioner<System.Numerics.Complex>();
			}
			Vector<System.Numerics.Complex> vector = input.Clone();
			Vector<System.Numerics.Complex> vector2 = result.Clone();
			foreach (Tuple<IIterativeSolver<System.Numerics.Complex>, IPreconditioner<System.Numerics.Complex>> solver in _solvers)
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
