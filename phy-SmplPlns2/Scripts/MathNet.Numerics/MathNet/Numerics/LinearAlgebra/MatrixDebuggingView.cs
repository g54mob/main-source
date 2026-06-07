using System;
using System.Diagnostics;

namespace MathNet.Numerics.LinearAlgebra
{
	internal class MatrixDebuggingView<T> where T : struct, IEquatable<T>, IFormattable
	{
		private readonly Matrix<T> _matrix;

		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public T[,] Items => _matrix.ToArray();

		public MatrixDebuggingView(Matrix<T> matrix)
		{
			_matrix = matrix;
		}
	}
}
