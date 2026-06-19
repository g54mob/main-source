using Player;

namespace Vehicles
{
	public interface IVehicleDriver
	{
		bool IsDriving { get; set; }

		PlayerBehaviour Player { get; }

		void GetOnVehicle(DrivableVehicle vehicle);

		void GetOfTheVehicle(DrivableVehicle vehicle);
	}
}
