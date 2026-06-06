using Brewery.Vehicle;

namespace Brewery.Face
{
	public class VehicleDrivingFaceProbe : FaceStateProbe
	{
		private VehicleDriverIK _driverIK;

		private MopedRiderIK _mopedRider;

		public override string ProbeId => null;

		private void Awake()
		{
		}

		public override float Evaluate01()
		{
			return 0f;
		}
	}
}
