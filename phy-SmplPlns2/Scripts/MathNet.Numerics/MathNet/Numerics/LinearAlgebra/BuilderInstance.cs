using System;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra.Complex;
using MathNet.Numerics.LinearAlgebra.Complex32;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Single;

namespace MathNet.Numerics.LinearAlgebra
{
	internal static class BuilderInstance<T> where T : struct, IEquatable<T>, IFormattable
	{
		private static Lazy<Tuple<MatrixBuilder<T>, VectorBuilder<T>>> _singleton = new Lazy<Tuple<MatrixBuilder<T>, VectorBuilder<T>>>(Create);

		public static MatrixBuilder<T> Matrix => _singleton.Value.Item1;

		public static VectorBuilder<T> Vector => _singleton.Value.Item2;

		private static Tuple<MatrixBuilder<T>, VectorBuilder<T>> Create()
		{
			if (typeof(T) == typeof(System.Numerics.Complex))
			{
				return new Tuple<MatrixBuilder<T>, VectorBuilder<T>>((MatrixBuilder<T>)(object)new MathNet.Numerics.LinearAlgebra.Complex.MatrixBuilder(), (VectorBuilder<T>)(object)new MathNet.Numerics.LinearAlgebra.Complex.VectorBuilder());
			}
			if (typeof(T) == typeof(MathNet.Numerics.Complex32))
			{
				return new Tuple<MatrixBuilder<T>, VectorBuilder<T>>((MatrixBuilder<T>)(object)new MathNet.Numerics.LinearAlgebra.Complex32.MatrixBuilder(), (VectorBuilder<T>)(object)new MathNet.Numerics.LinearAlgebra.Complex32.VectorBuilder());
			}
			if (typeof(T) == typeof(double))
			{
				return new Tuple<MatrixBuilder<T>, VectorBuilder<T>>((MatrixBuilder<T>)(object)new MathNet.Numerics.LinearAlgebra.Double.MatrixBuilder(), (VectorBuilder<T>)(object)new MathNet.Numerics.LinearAlgebra.Double.VectorBuilder());
			}
			if (typeof(T) == typeof(float))
			{
				return new Tuple<MatrixBuilder<T>, VectorBuilder<T>>((MatrixBuilder<T>)(object)new MathNet.Numerics.LinearAlgebra.Single.MatrixBuilder(), (VectorBuilder<T>)(object)new MathNet.Numerics.LinearAlgebra.Single.VectorBuilder());
			}
			throw new NotSupportedException(FormattableString.Invariant($"Matrices and vectors of type '{typeof(T).Name}' are not supported. Only Double, Single, Complex or Complex32 are supported at this point."));
		}

		public static void Register(MatrixBuilder<T> matrixBuilder, VectorBuilder<T> vectorBuilder)
		{
			_singleton = new Lazy<Tuple<MatrixBuilder<T>, VectorBuilder<T>>>(() => new Tuple<MatrixBuilder<T>, VectorBuilder<T>>(matrixBuilder, vectorBuilder));
		}
	}
}
