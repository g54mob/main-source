using LocoSim.Definitions;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class Battery : SimComponent
	{
		private readonly float internalResistance;

		private readonly float baseConsumptionMultiplier;

		private readonly FuseReference powerFuseRef;

		private readonly PortReference chargeNormalized;

		private readonly PortReference chargeConsumption;

		private readonly Port voltageReadOut;

		private readonly Port voltageNormalizedReadOut;

		private readonly PortReference powerReader;

		private readonly float minVoltage;

		private readonly float maxVoltage;

		public Battery(BatteryDefinition bDef)
			: base(bDef.ID)
		{
			internalResistance = bDef.internalResistance;
			baseConsumptionMultiplier = bDef.baseConsumptionMultiplier;
			powerFuseRef = AddFuseReference(bDef.powerFuseId);
			chargeNormalized = AddPortReference(bDef.chargeNormalized);
			chargeConsumption = AddPortReference(bDef.chargeConsumption);
			voltageReadOut = AddPort(bDef.voltageReadOut);
			voltageNormalizedReadOut = AddPort(bDef.voltageNormalizedReadOut);
			powerReader = AddPortReference(bDef.powerReader);
			BatteryDefinition.BatteryChemistry chemistry = bDef.chemistry;
			if (chemistry == BatteryDefinition.BatteryChemistry.LeadAcid)
			{
				minVoltage = (float)bDef.numSeriesCells * 1.94f;
				maxVoltage = (float)bDef.numSeriesCells * 2.15f;
			}
			else
			{
				Debug.LogError("Unknown battery chemistry");
			}
		}

		public override void Tick(float delta)
		{
			float num = Mathf.Lerp(minVoltage, maxVoltage, chargeNormalized.Value);
			float num2 = num * num - 4f * powerReader.Value * internalResistance;
			if (chargeNormalized.Value <= 0f || num2 <= 0f)
			{
				powerFuseRef.ChangeState(newState: false);
				voltageReadOut.Value = 0f;
				voltageNormalizedReadOut.Value = 0f;
				chargeConsumption.Value = 0f;
			}
			else
			{
				float value = powerFuseRef.ProcessInput(0.5f * (num + Mathf.Sqrt(num2)));
				voltageReadOut.Value = value;
				voltageNormalizedReadOut.Value = Mathf.InverseLerp(minVoltage, maxVoltage, value);
				float num3 = gameParams.ResourceConsumptionModifier * baseConsumptionMultiplier * powerReader.Value;
				chargeConsumption.Value = num3 * delta / 1000000f;
			}
		}
	}
}
