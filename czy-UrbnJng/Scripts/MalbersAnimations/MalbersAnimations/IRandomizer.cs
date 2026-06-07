namespace MalbersAnimations
{
	public interface IRandomizer
	{
		void SetRandom(int value, int priority);

		void ResetRandomPriority(int priority);
	}
}
