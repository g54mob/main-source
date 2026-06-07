namespace FractureField.Drones
{
	public class DroneSaveData : IConvertableSaveData
	{
		public DroneType SavedDroneType { get; set; }

		public float[] PosSaveData { get; set; }

		protected DroneSaveData Save(Drone data)
		{
			return null;
		}
	}
}
