using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	public interface IDroneInformationList
	{
		DroneData GetSelectedDrone();

		void SelectDrone(DroneData drone);
	}
}
