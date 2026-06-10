using NSMedieval.Serialization;

namespace NSMedieval.WorldMap.Caravan
{
	public interface ICaravanEvent : IFVSerializable
	{
		void OnLoaded();

		void Tick();

		void OnLeftMap();
	}
}
