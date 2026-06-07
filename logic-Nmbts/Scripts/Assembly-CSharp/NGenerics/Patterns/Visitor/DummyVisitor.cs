namespace NGenerics.Patterns.Visitor
{
	public class DummyVisitor<T> : IVisitor<T>
	{
		public bool HasCompleted
		{
			get
			{
				return false;
			}
		}

		public void Visit(T obj)
		{
		}
	}
}
