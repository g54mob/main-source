using LocoSim.Definitions;

namespace LocoSim.Implementations
{
	public class ConfigurablePort : SimComponent
	{
		private readonly float value;

		private readonly Port port;

		public ConfigurablePort(ConfigurablePortDefinition cpDef)
			: base(cpDef.ID)
		{
			value = cpDef.value;
			port = AddPort(cpDef.port, value);
		}

		public override void InitializationAfterConnecting()
		{
			if (port.type == PortType.OUT || port.type == PortType.FORWARD_OUT)
			{
				port.Value = port.Value;
			}
		}

		public override void Tick(float delta)
		{
		}
	}
}
