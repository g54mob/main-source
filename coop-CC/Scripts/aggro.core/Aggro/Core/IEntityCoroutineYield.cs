namespace Aggro.Core
{
	public interface IEntityCoroutineYield : IEntityTyped
	{
		bool keepWaiting { get; }

		void ReleaseSelf();
	}
}
