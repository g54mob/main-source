namespace FluffyUnderware.Curvy.ThirdParty.LibTessDotNet
{
	internal class Dict<TValue> where TValue : class
	{
		public class Node
		{
			internal TValue _key;

			internal Node _prev;

			internal Node _next;

			public TValue Key => null;

			public Node Prev => null;

			public Node Next => null;
		}

		public delegate bool LessOrEqual(TValue lhs, TValue rhs);

		private LessOrEqual _leq;

		private Node _head;

		public Dict(LessOrEqual leq)
		{
		}

		public Node Insert(TValue key)
		{
			return null;
		}

		public Node InsertBefore(Node node, TValue key)
		{
			return null;
		}

		public Node Find(TValue key)
		{
			return null;
		}

		public Node Min()
		{
			return null;
		}

		public void Remove(Node node)
		{
		}
	}
}
