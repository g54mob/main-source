using NSMedieval.WorldMap;

namespace NSMedieval.Goap
{
	public interface IFormCaravanGoapAgent
	{
		CaravanInstance PreparingForCaravan { get; }

		void StartCaravanFormation(CaravanInstance caravan);

		void ClearCaravanFormingData();
	}
}
