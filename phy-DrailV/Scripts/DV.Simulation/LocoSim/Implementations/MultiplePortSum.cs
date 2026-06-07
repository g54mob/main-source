using System.Linq;
using LocoSim.Definitions;

namespace LocoSim.Implementations
{
	public class MultiplePortSum : SimComponent
	{
		public readonly PortReference[] inputs;

		public readonly Port output;

		public MultiplePortSum(MultiplePortSumDefinition sDef)
			: base(sDef.ID)
		{
			inputs = sDef.inputs.Select((PortReferenceDefinition portRef) => AddPortReference(portRef)).ToArray();
			output = AddPort(sDef.output);
		}

		public override void Tick(float delta)
		{
			float num = 0f;
			PortReference[] array = inputs;
			foreach (PortReference portReference in array)
			{
				num += portReference.Value;
			}
			output.Value = num;
		}
	}
}
