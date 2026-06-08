namespace Castle.Components.DictionaryAdapter
{
	public interface IVirtualSite<T>
	{
		void OnRealizing(T node);
	}
}
