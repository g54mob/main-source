namespace NGenerics.Patterns.Visitor
{
	public sealed class PostOrderVisitor<T> : OrderedVisitor<T>
	{
		public PostOrderVisitor(IVisitor<T> visitor)
			: base(visitor)
		{
		}

		public override void VisitInOrder(T obj)
		{
		}

		public override void VisitPreOrder(T obj)
		{
		}
	}
}
