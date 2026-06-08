namespace GRP
{
	public class GatePartSim : PartSim<GatePart>, ISimTick
	{
		public HubReceiver receiver;

		public HubTransmitter transmitter;

		public GateVisual visual;

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
