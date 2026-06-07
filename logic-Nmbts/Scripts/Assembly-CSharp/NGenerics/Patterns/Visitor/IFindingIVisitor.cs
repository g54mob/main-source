namespace NGenerics.Patterns.Visitor
{
	internal interface IFindingIVisitor<T> : IVisitor<T>
	{
		bool Found { get; }

		T SearchValue { get; }
	}
}
