using System;
using System.Diagnostics;

namespace MathNet.Numerics.LinearAlgebra
{
	internal class VectorDebuggingView<T> where T : struct, IEquatable<T>, IFormattable
	{
		private readonly Vector<T> _vector;

		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public T[] Items => _vector.ToArray();

		public VectorDebuggingView(Vector<T> vector)
		{
			_vector = vector;
		}
	}
}
