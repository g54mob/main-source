namespace NGenerics.Patterns.Visitor
{
	public sealed class PreOrderVisitor<T> : OrderedVisitor<T>
	{
		public PreOrderVisitor(IVisitor<T> visitor)
			: base(visitor)
		{
		}

		public override void VisitInOrder(T obj)
		{
		}

		public override void VisitPostOrder(T obj)
		{
		}
	}
}
