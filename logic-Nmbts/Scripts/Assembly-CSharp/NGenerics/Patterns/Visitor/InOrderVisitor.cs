namespace NGenerics.Patterns.Visitor
{
	public sealed class InOrderVisitor<T> : OrderedVisitor<T>
	{
		public InOrderVisitor(IVisitor<T> visitor)
			: base(visitor)
		{
		}

		public override void VisitPostOrder(T obj)
		{
		}

		public override void VisitPreOrder(T obj)
		{
		}
	}
}
