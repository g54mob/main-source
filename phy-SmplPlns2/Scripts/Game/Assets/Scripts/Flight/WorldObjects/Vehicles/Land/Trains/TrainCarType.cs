using Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Trains.Attributes;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Trains
{
	public enum TrainCarType : byte
	{
		Unknown = 0,
		[PrefabPath("FreightCar1")]
		FreightCar1 = 1,
		[PrefabPath("FreightCar2")]
		FreightCar2 = 2
	}
}
