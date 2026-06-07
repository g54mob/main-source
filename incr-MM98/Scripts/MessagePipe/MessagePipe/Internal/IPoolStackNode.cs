namespace MessagePipe.Internal
{
	internal interface IPoolStackNode<T> where T : class
	{
		ref T NextNode { get; }
	}
}
