using MyStuff.Intoxication;

namespace Brewery.Face
{
	public class IntoxicationFaceProbe : FaceStateProbe
	{
		private IntoxicationVisionController _intox;

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
