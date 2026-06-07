namespace CommunityToolkit.HighPerformance.Helpers
{
	public interface IRefAction<T>
	{
		void Invoke(ref T item);
	}
}
