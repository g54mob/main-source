namespace Simulator.GameWorld
{
	public interface IStainCleaner
	{
		Stain Stain { get; }

		float CleaningRate { get; }

		bool CanStartCleanDirt(Stain dirt);

		void StartCleanDirt(Stain dirt);

		void StopCleanDirt(Stain dirt);

		void TryStartCleanDirt(Stain dirt)
		{
			if (CanStartCleanDirt(dirt))
			{
				StartCleanDirt(dirt);
			}
		}
	}
}
