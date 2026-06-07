using System;

namespace R3.Collections
{
	public struct SwapListCore<T>
	{
		private const int InitialArraySize = 4;

		private T[]? arrayA;

		private int lengthA;

		private T[]? arrayB;

		private int lengthB;

		private bool useA;

		public bool HasValue
		{
			get
			{
				if (lengthA <= 0)
				{
					return lengthB > 0;
				}
				return true;
			}
		}

		public void Add(T value)
		{
			if (useA)
			{
				if (arrayA == null)
				{
					arrayA = new T[4];
				}
				else if (lengthA == arrayA.Length)
				{
					T[] destinationArray = new T[arrayA.Length * 2];
					Array.Copy(arrayA, destinationArray, arrayA.Length);
					arrayA = destinationArray;
				}
				arrayA[lengthA++] = value;
			}
			else
			{
				if (arrayB == null)
				{
					arrayB = new T[4];
				}
				else if (lengthB == arrayB.Length)
				{
					T[] destinationArray2 = new T[arrayB.Length * 2];
					Array.Copy(arrayB, destinationArray2, arrayB.Length);
					arrayB = destinationArray2;
				}
				arrayB[lengthB++] = value;
			}
		}

		public ReadOnlySpan<T> Swap(out bool token)
		{
			if (useA)
			{
				useA = false;
				if (arrayA == null)
				{
					token = true;
					return ReadOnlySpan<T>.Empty;
				}
				token = true;
				return arrayA.AsSpan(0, lengthA);
			}
			useA = true;
			if (arrayB == null)
			{
				token = false;
				return ReadOnlySpan<T>.Empty;
			}
			token = false;
			return arrayB.AsSpan(0, lengthB);
		}

		public void Clear(bool token)
		{
			if (token)
			{
				if (arrayA != null)
				{
					Array.Clear(arrayA, 0, lengthA);
					lengthA = 0;
				}
			}
			else if (arrayB != null)
			{
				Array.Clear(arrayB, 0, lengthB);
				lengthB = 0;
			}
			if (lengthB == 0)
			{
				useA = true;
			}
		}

		public void Dispose()
		{
			if (arrayA != null)
			{
				Array.Clear(arrayA, 0, lengthA);
				arrayA = null;
				lengthA = 0;
			}
			if (arrayB != null)
			{
				Array.Clear(arrayB, 0, lengthB);
				arrayB = null;
				lengthB = 0;
			}
		}
	}
}
