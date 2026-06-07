using LocoSim.Definitions;

namespace LocoSim.Implementations
{
	public class PortForwardIn : SimComponent
	{
		public readonly bool skipPropagationWhenDisconnected;

		public readonly Port forwardIn;

		public readonly Port simOut;

		private bool skipNextSetAfterConnect;

		public PortForwardIn(string id, PortDefinition forwardInDef, PortDefinition simOutDef, bool skipOneTickWhenConnected, bool skipPropagationWhenDisconnected)
			: base(id)
		{
			forwardIn = AddPort(forwardInDef);
			simOut = AddPort(simOutDef);
			this.skipPropagationWhenDisconnected = skipPropagationWhenDisconnected;
			if (skipOneTickWhenConnected)
			{
				forwardIn.PortConnectionChanged += OnPortConnectionChange;
			}
		}

		private void OnPortConnectionChange(bool connected)
		{
			if (connected)
			{
				skipNextSetAfterConnect = true;
			}
		}

		public override void Tick(float delta)
		{
			if (forwardIn.IsConnectedPort)
			{
				if (skipNextSetAfterConnect)
				{
					skipNextSetAfterConnect = false;
				}
				else
				{
					simOut.Value = forwardIn.Value;
				}
			}
			else if (!skipPropagationWhenDisconnected)
			{
				simOut.Value = forwardIn.Value;
			}
		}
	}
}
