using Brewery.CarryingSystem;

namespace Brewery.Face
{
	public class CarryingFaceProbe : FaceStateProbe
	{
		private CarryingController _carrying;

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
