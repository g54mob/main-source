using System;
using System.Collections;
using System.Collections.Generic;
using NGenerics.DataStructures.General;

namespace NGenerics.DataStructures.Mathematical
{
	public interface IVector<T> : IEnumerable<T>, IEnumerable, IEquatable<IVector<T>>, ICloneable
	{
		T this[int index] { get; set; }

		int DimensionCount { get; }

		T AbsoluteMaximum();

		int AbsoluteMaximumIndex();

		T AbsoluteMinimum();

		int AbsoluteMinimumIndex();

		void Add(IVector<T> vector);

		void Add(T number);

		void Clear();

		IVector<T> CrossProduct(IVector<T> vector);

		void Decrement();

		T DotProduct(IVector<T> vector);

		T Sum();

		T Product();

		void Increment();

		T Magnitude();

		void Divide(T number);

		void Divide(IVector<T> vector);

		void Negate();

		void Normalize();

		T Maximum();

		int MaximumIndex();

		T Minimum();

		int MinimumIndex();

		IMatrix<T> Multiply(IVector<T> vector);

		void Multiply(T number);

		void Subtract(IVector<T> vector);

		void Subtract(T number);

		void SetValues(params T[] values);

		void Swap(IVector<T> other);

		T[] ToArray();

		IMatrix<T> ToMatrix();
	}
}
