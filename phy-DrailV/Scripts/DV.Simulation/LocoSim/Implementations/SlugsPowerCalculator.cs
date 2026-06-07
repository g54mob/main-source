using LocoSim.Definitions;

namespace LocoSim.Implementations
{
	public class SlugsPowerCalculator : SimComponent
	{
		public PortReference internalEffectiveResistanceReader;

		public Port externalEffectiveResistanceExtIn;

		public PortReference internalAmpsResistanceReader;

		public Port externalAmpsExtIn;

		public Port effectiveResistanceReadOut;

		public Port totalAmpsReadOut;

		public SlugsPowerCalculator(SlugsPowerCalculatorDefinition spcDef)
			: base(spcDef.ID)
		{
			internalEffectiveResistanceReader = AddPortReference(spcDef.internalEffectiveResistanceReader);
			externalEffectiveResistanceExtIn = AddPort(spcDef.externalEffectiveResistanceExtIn);
			internalAmpsResistanceReader = AddPortReference(spcDef.internalAmpsResistanceReader);
			externalAmpsExtIn = AddPort(spcDef.externalAmpsExtIn);
			effectiveResistanceReadOut = AddPort(spcDef.effectiveResistanceReadOut);
			totalAmpsReadOut = AddPort(spcDef.totalAmpsReadOut);
		}

		public override void Tick(float _)
		{
			effectiveResistanceReadOut.Value = 1f / (1f / internalEffectiveResistanceReader.Value + 1f / externalEffectiveResistanceExtIn.Value);
			totalAmpsReadOut.Value = internalAmpsResistanceReader.Value + externalAmpsExtIn.Value;
		}
	}
}
