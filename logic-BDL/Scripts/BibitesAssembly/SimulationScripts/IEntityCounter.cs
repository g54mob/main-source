namespace SimulationScripts
{
	public interface IEntityCounter
	{
		void ChangeCount(float amountDifference);

		void AddToGlobalCount();
	}
}
