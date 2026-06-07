namespace NGenerics.Patterns.Visitor
{
	public sealed class CountingVisitor<T> : IVisitor<T>
	{
		public bool HasCompleted
		{
			get
			{
				return false;
			}
		}

		public int Count { get; private set; }

		public void Visit(T obj)
		{
			Count++;
		}

		public void ResetCount()
		{
			Count = 0;
		}
	}
}
