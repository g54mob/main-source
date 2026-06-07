namespace Utils
{
	public interface IPoolableComponent
	{
		void OnReturnToPool();

		void OnRetrieveFromPool();
	}
}
