namespace Mirror.Cloud
{
	public abstract class BaseApi
	{
		protected readonly ICoroutineRunner runner;

		protected readonly IRequestCreator requestCreator;

		protected BaseApi(ICoroutineRunner runner, IRequestCreator requestCreator)
		{
		}
	}
}
