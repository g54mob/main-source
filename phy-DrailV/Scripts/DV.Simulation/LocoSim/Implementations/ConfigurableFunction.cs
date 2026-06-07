using System.Linq;
using LocoSim.Definitions;

namespace LocoSim.Implementations
{
	public class ConfigurableFunction : SimComponent
	{
		private ConfigurableFunctionDefinition.FunctionType type;

		private readonly PortReference[] readers;

		public readonly Port outReadOut;

		public ConfigurableFunction(ConfigurableFunctionDefinition cfDef)
			: base(cfDef.ID)
		{
			type = cfDef.type;
			readers = cfDef.readers.Select((PortReferenceDefinition prDef) => AddPortReference(prDef)).ToArray();
			outReadOut = AddPort(cfDef.outReadOut);
		}

		public override void Tick(float delta)
		{
			switch (type)
			{
			case ConfigurableFunctionDefinition.FunctionType.MIN:
			{
				float num3 = float.PositiveInfinity;
				PortReference[] array = readers;
				foreach (PortReference portReference3 in array)
				{
					if (portReference3.Value < num3)
					{
						num3 = portReference3.Value;
					}
				}
				outReadOut.Value = num3;
				break;
			}
			case ConfigurableFunctionDefinition.FunctionType.MAX:
			{
				float num2 = float.NegativeInfinity;
				PortReference[] array = readers;
				foreach (PortReference portReference2 in array)
				{
					if (portReference2.Value > num2)
					{
						num2 = portReference2.Value;
					}
				}
				outReadOut.Value = num2;
				break;
			}
			case ConfigurableFunctionDefinition.FunctionType.SUM:
			{
				float num = 0f;
				PortReference[] array = readers;
				foreach (PortReference portReference in array)
				{
					num += portReference.Value;
				}
				outReadOut.Value = num;
				break;
			}
			}
		}
	}
}
