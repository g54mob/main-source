namespace NGenerics.Patterns.Visitor
{
	public interface IVisitor<T>
	{
		bool HasCompleted { get; }

		void Visit(T obj);
	}
}
