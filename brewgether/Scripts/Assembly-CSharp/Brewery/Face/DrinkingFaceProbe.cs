using Brewery.DrinkingSystem;

namespace Brewery.Face
{
	public class DrinkingFaceProbe : FaceStateProbe
	{
		private DrinkingController _drinking;

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
