namespace Castle.Components.DictionaryAdapter
{
	public interface IVirtualTarget<TNode, TMember>
	{
		void OnRealizing(TNode node, TMember member);
	}
}
