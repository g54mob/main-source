using LocoSim.Definitions;

namespace LocoSim.Implementations
{
	public class ConfigurableMultiplier : SimComponent
	{
		public readonly bool invertA;

		public readonly bool invertB;

		public readonly PortReference aReader;

		public readonly PortReference bReader;

		public readonly Port mulReadOut;

		public ConfigurableMultiplier(ConfigurableMultiplierDefinition gmDef)
			: base(gmDef.ID)
		{
			invertA = gmDef.invertA;
			invertB = gmDef.invertB;
			aReader = AddPortReference(gmDef.aReader);
			bReader = AddPortReference(gmDef.bReader);
			mulReadOut = AddPort(gmDef.mulReadOut);
		}

		public override void Tick(float delta)
		{
			float num = aReader.Value;
			if (invertA)
			{
				num = 1f / num;
			}
			float num2 = bReader.Value;
			if (invertB)
			{
				num2 = 1f / num2;
			}
			mulReadOut.Value = num * num2;
		}
	}
}
