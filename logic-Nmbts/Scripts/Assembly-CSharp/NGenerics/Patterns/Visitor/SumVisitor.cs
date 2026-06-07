namespace NGenerics.Patterns.Visitor
{
	public sealed class SumVisitor : IVisitor<int>
	{
		public bool HasCompleted
		{
			get
			{
				return false;
			}
		}

		public int Sum { get; private set; }

		public void Visit(int obj)
		{
			Sum += obj;
		}
	}
}
