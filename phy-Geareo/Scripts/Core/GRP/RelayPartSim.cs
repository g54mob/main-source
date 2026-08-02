namespace GRP
{
	public class RelayPartSim : PartSim<RelayPart>, ISimTick
	{
		public HubReceiver receiver;

		public HubTransmitter transmitter;

		public RelayVisual visual;

		protected override void OnSpawned()
		{
		}

		protected override void Setup()
		{
		}

		public void SimTick()
		{
		}
	}
}
