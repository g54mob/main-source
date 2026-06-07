using System;
using System.Collections.Generic;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra.Storage;
using MathNet.Numerics.Random;

namespace MathNet.Numerics.LinearAlgebra
{
	public abstract class VectorBuilder<T> where T : struct, IEquatable<T>, IFormattable
	{
		public abstract T Zero { get; }

		public abstract T One { get; }

		public Vector<T> OfStorage(VectorStorage<T> storage)
		{
			if (storage == null)
			{
				throw new ArgumentNullException("storage");
			}
			if (storage is DenseVectorStorage<T> storage2)
			{
				return Dense(storage2);
			}
			if (storage is SparseVectorStorage<T> storage3)
			{
				return Sparse(storage3);
			}
			throw new NotSupportedException(FormattableString.Invariant($"Vector storage type '{storage.GetType().Name}' is not supported. Only DenseVectorStorage and SparseVectorStorage are supported as this point."));
		}

		public Vector<T> SameAs<TU>(Vector<TU> example, int length) where TU : struct, IEquatable<TU>, IFormattable
		{
			if (!example.Storage.IsDense)
			{
				return Sparse(length);
			}
			return Dense(length);
		}

		public Vector<T> SameAs<TU>(Vector<TU> example) where TU : struct, IEquatable<TU>, IFormattable
		{
			if (!example.Storage.IsDense)
			{
				return Sparse(example.Count);
			}
			return Dense(example.Count);
		}

		public Vector<T> SameAs<TU>(Matrix<TU> example, int length) where TU : struct, IEquatable<TU>, IFormattable
		{
			if (!example.Storage.IsDense)
			{
				return Sparse(length);
			}
			return Dense(length);
		}

		public Vector<T> SameAs(Vector<T> example, Vector<T> otherExample, int length)
		{
			if (!example.Storage.IsDense && !otherExample.Storage.IsDense)
			{
				return Sparse(length);
			}
			return Dense(length);
		}

		public Vector<T> SameAs(Vector<T> example, Vector<T> otherExample)
		{
			if (!example.Storage.IsDense && !otherExample.Storage.IsDense)
			{
				return Sparse(example.Count);
			}
			return Dense(example.Count);
		}

		public Vector<T> SameAs(Matrix<T> matrix, Vector<T> vector, int length)
		{
			if (!matrix.Storage.IsDense && !vector.Storage.IsDense)
			{
				return Sparse(length);
			}
			return Dense(length);
		}

		public abstract Vector<T> Random(int length, IContinuousDistribution distribution);

		public Vector<T> Random(int length)
		{
			return Random(length, new Normal(SystemRandomSource.Default));
		}

		public Vector<T> Random(int length, int seed)
		{
			return Random(length, new Normal(new SystemRandomSource(seed, threadSafe: true)));
		}

		public abstract Vector<T> Dense(DenseVectorStorage<T> storage);

		public Vector<T> Dense(int size)
		{
			return Dense(new DenseVectorStorage<T>(size));
		}

		public Vector<T> Dense(T[] array)
		{
			return Dense(new DenseVectorStorage<T>(array.Length, array));
		}

		public Vector<T> Dense(int length, T value)
		{
			if (Zero.Equals(value))
			{
				return Dense(length);
			}
			return Dense(DenseVectorStorage<T>.OfValue(length, value));
		}

		public Vector<T> Dense(int length, Func<int, T> init)
		{
			return Dense(DenseVectorStorage<T>.OfInit(length, init));
		}

		public Vector<T> DenseOfVector(Vector<T> vector)
		{
			return Dense(DenseVectorStorage<T>.OfVector(vector.Storage));
		}

		public Vector<T> DenseOfArray(T[] array)
		{
			return Dense(DenseVectorStorage<T>.OfVector(new DenseVectorStorage<T>(array.Length, array)));
		}

		public Vector<T> DenseOfEnumerable(IEnumerable<T> enumerable)
		{
			return Dense(DenseVectorStorage<T>.OfEnumerable(enumerable));
		}

		public Vector<T> DenseOfIndexed(int length, IEnumerable<Tuple<int, T>> enumerable)
		{
			return Dense(DenseVectorStorage<T>.OfIndexedEnumerable(length, enumerable));
		}

		public Vector<T> DenseOfIndexed(int length, IEnumerable<(int, T)> enumerable)
		{
			return Dense(DenseVectorStorage<T>.OfIndexedEnumerable(length, enumerable));
		}

		public abstract Vector<T> Sparse(SparseVectorStorage<T> storage);

		public Vector<T> Sparse(int size)
		{
			return Sparse(new SparseVectorStorage<T>(size));
		}

		public Vector<T> Sparse(int length, T value)
		{
			if (Zero.Equals(value))
			{
				return Sparse(length);
			}
			return Sparse(SparseVectorStorage<T>.OfValue(length, value));
		}

		public Vector<T> Sparse(int length, Func<int, T> init)
		{
			return Sparse(SparseVectorStorage<T>.OfInit(length, init));
		}

		public Vector<T> SparseOfVector(Vector<T> vector)
		{
			return Sparse(SparseVectorStorage<T>.OfVector(vector.Storage));
		}

		public Vector<T> SparseOfArray(T[] array)
		{
			return Sparse(SparseVectorStorage<T>.OfEnumerable(array));
		}

		public Vector<T> SparseOfEnumerable(IEnumerable<T> enumerable)
		{
			return Sparse(SparseVectorStorage<T>.OfEnumerable(enumerable));
		}

		public Vector<T> SparseOfIndexed(int length, IEnumerable<Tuple<int, T>> enumerable)
		{
			return Sparse(SparseVectorStorage<T>.OfIndexedEnumerable(length, enumerable));
		}

		public Vector<T> SparseOfIndexed(int length, IEnumerable<(int, T)> enumerable)
		{
			return Sparse(SparseVectorStorage<T>.OfIndexedEnumerable(length, enumerable));
		}
	}
}
