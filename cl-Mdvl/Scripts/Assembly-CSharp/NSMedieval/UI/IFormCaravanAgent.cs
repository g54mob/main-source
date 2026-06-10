using NSMedieval.WorldMap;

namespace NSMedieval.UI
{
	public interface IFormCaravanAgent
	{
		bool IsFormingCaravan();

		CaravanInstance GetFormingCaravanInstance();

		void IncognitoDispose();

		bool IsInIncognitoMode();

		void ClearCaravanFormingData();

		void StartCaravanFormation(CaravanInstance caravan);
	}
}
