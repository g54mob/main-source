namespace CommunityToolkit.HighPerformance.Helpers
{
	public interface IInAction<T>
	{
		void Invoke(in T item);
	}
}
