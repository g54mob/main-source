using LocoSim.Definitions;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class VoltageRegulator : SimComponent
	{
		public readonly PortReference throttleReader;

		public readonly PortReference supplyVoltage;

		public readonly Port voltageReadOut;

		public readonly PortReference singleMotorEffectiveResistanceReader;

		public readonly Port externalCurrentLimitExtIn;

		public readonly Port externalCurrentLimitActiveReadOut;

		public VoltageRegulator(VoltageRegulatorDefinition vrDef)
			: base(vrDef.ID)
		{
			throttleReader = AddPortReference(vrDef.throttleReader);
			supplyVoltage = AddPortReference(vrDef.supplyVoltage);
			voltageReadOut = AddPort(vrDef.voltageReadOut);
			singleMotorEffectiveResistanceReader = AddPortReference(vrDef.singleMotorEffectiveResistanceReader);
			externalCurrentLimitExtIn = AddPort(vrDef.externalCurrentLimitExtIn, float.PositiveInfinity);
			externalCurrentLimitActiveReadOut = AddPort(vrDef.externalCurrentLimitActiveReadOut);
		}

		public override void Tick(float delta)
		{
			float num = throttleReader.Value * supplyVoltage.Value;
			float num2 = (float.IsInfinity(externalCurrentLimitExtIn.Value) ? float.PositiveInfinity : (externalCurrentLimitExtIn.Value * singleMotorEffectiveResistanceReader.Value));
			externalCurrentLimitActiveReadOut.Value = ((num2 < num) ? 1f : 0f);
			float value = Mathf.Min(num, num2);
			voltageReadOut.Value = value;
		}
	}
}
