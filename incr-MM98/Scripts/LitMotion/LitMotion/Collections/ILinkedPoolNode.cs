namespace LitMotion.Collections
{
	public interface ILinkedPoolNode<T> where T : class
	{
		ref T NextNode { get; }
	}
}
