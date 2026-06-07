using Unity.Netcode;

namespace Brewery.Face
{
	public class SleepFaceProbe : FaceStateProbe
	{
		private NetworkObject _netObj;

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
