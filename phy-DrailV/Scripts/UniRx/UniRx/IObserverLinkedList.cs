namespace UniRx
{
	internal interface IObserverLinkedList<T>
	{
		void UnsubscribeNode(ObserverNode<T> node);
	}
}
