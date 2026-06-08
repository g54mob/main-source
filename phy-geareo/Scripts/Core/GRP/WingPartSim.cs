namespace GRP
{
	public class WingPartSim : PartSim<WingPart>, ISimPhysicsUpdate
	{
		public BoxVisual visual;

		public WingSimHandle[] handles;

		protected override void OnCreated()
		{
		}

		protected override void Setup()
		{
		}

		public void SimPhysicsUpdate()
		{
		}
	}
}
