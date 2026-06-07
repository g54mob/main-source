namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land
{
	public class VehicleList
	{
		private VehicleListData _data;

		private float _totalCarTypeRange;

		public VehicleList(VehicleListData data)
		{
			_data = data;
			VehicleListData.VehicleInfo[] vehicles = _data.vehicles;
			foreach (VehicleListData.VehicleInfo vehicleInfo in vehicles)
			{
				_totalCarTypeRange += vehicleInfo.frequency;
			}
		}

		public int GetRandomVehicleIndex(float randomZeroToOne)
		{
			if (_totalCarTypeRange == 0f)
			{
				return -1;
			}
			float num = randomZeroToOne * _totalCarTypeRange;
			int result = 0;
			for (int i = 0; i < _data.vehicles.Length; i++)
			{
				num -= _data.vehicles[i].frequency;
				if (num <= 0f)
				{
					result = i;
					break;
				}
			}
			return result;
		}
	}
}
