using Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Trains.Attributes;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Trains
{
	public enum TrainLocomotiveType : byte
	{
		Unknown = 0,
		[PrefabPath("Locomotive1")]
		Locomotive1 = 1,
		[PrefabPath("Locomotive2")]
		Locomotive2 = 2
	}
}
