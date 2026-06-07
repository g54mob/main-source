using LocoSim.Definitions;

namespace LocoSim.Implementations
{
	public class ConfigurableAdd : SimComponent
	{
		public readonly bool negativeA;

		public readonly bool negativeB;

		public readonly PortReference aReader;

		public readonly PortReference bReader;

		public readonly Port addReadOut;

		public ConfigurableAdd(ConfigurableAddDefinition caDef)
			: base(caDef.ID)
		{
			negativeA = caDef.negativeA;
			negativeB = caDef.negativeB;
			aReader = AddPortReference(caDef.aReader);
			bReader = AddPortReference(caDef.bReader);
			addReadOut = AddPort(caDef.addReadOut);
		}

		public override void Tick(float delta)
		{
			float num = aReader.Value;
			if (negativeA)
			{
				num = 0f - num;
			}
			float num2 = bReader.Value;
			if (negativeB)
			{
				num2 = 0f - num2;
			}
			addReadOut.Value = num + num2;
		}
	}
}
