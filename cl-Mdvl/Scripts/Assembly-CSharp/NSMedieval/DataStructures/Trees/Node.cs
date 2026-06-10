namespace NSMedieval.DataStructures.Trees
{
	public sealed class Node<T>
	{
		private T data;

		private Node<T> next;

		private Node<T> child;

		private Node<T> parent;

		public T Data => data;

		public Node<T> Parent => parent;

		public Node<T> Next => next;

		public Node<T> Child => child;

		public Node(T data, Node<T> parent)
		{
			this.data = data;
			this.parent = parent;
			if (parent != null)
			{
				next = parent.Child;
			}
		}

		public void SetChild(Node<T> child)
		{
			this.child = child;
		}
	}
}
