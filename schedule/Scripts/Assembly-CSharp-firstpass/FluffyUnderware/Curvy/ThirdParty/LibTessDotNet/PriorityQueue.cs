namespace FluffyUnderware.Curvy.ThirdParty.LibTessDotNet
{
	internal class PriorityQueue<TValue> where TValue : class
	{
		private class StackItem
		{
			internal int p;

			internal int r;
		}

		private PriorityHeap<TValue>.LessOrEqual _leq;

		private PriorityHeap<TValue> _heap;

		private TValue[] _keys;

		private int[] _order;

		private int _size;

		private int _max;

		private bool _initialized;

		public bool Empty => false;

		public PriorityQueue(int initialSize, PriorityHeap<TValue>.LessOrEqual leq)
		{
		}

		private static void Swap(ref int a, ref int b)
		{
		}

		public void Init()
		{
		}

		public PQHandle Insert(TValue value)
		{
			return default(PQHandle);
		}

		public TValue ExtractMin()
		{
			return null;
		}

		public TValue Minimum()
		{
			return null;
		}

		public void Remove(PQHandle handle)
		{
		}
	}
}
