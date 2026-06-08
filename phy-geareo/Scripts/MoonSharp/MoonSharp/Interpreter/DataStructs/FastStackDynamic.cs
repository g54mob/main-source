using System.Collections.Generic;

namespace MoonSharp.Interpreter.DataStructs
{
	internal class FastStackDynamic<T> : List<T>
	{
		public FastStackDynamic(int startingCapacity)
		{
		}

		public void Set(int idxofs, T item)
		{
		}

		public T Push(T item)
		{
			return default(T);
		}

		public void Expand(int size)
		{
		}

		public void Zero(int index)
		{
		}

		public T Peek(int idxofs = 0)
		{
			return default(T);
		}

		public void CropAtCount(int p)
		{
		}

		public void RemoveLast(int cnt = 1)
		{
		}

		public T Pop()
		{
			return default(T);
		}
	}
}
