using Brewery.Pee;

namespace Brewery.Face
{
	public class PeeFaceProbe : FaceStateProbe
	{
		private PeeController _pee;

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
