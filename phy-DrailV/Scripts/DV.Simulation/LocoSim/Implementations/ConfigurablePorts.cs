using LocoSim.Definitions;

namespace LocoSim.Implementations
{
	public class ConfigurablePorts : SimComponent
	{
		public readonly Port[] ports;

		public ConfigurablePorts(ConfigurablePortsDefinition cpDef)
			: base(cpDef.ID)
		{
			ports = new Port[cpDef.ports.Length];
			for (int i = 0; i < ports.Length; i++)
			{
				ports[i] = AddPort(cpDef.ports[i], (i < cpDef.startingValues.Length) ? cpDef.startingValues[i] : 0f);
			}
		}

		public override void InitializationAfterConnecting()
		{
			Port[] array = ports;
			foreach (Port port in array)
			{
				if (port.type == PortType.OUT || port.type == PortType.FORWARD_OUT)
				{
					port.Value = port.Value;
				}
			}
		}

		public override void Tick(float delta)
		{
		}
	}
}
