using LocoSim.Definitions;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class DirectionalMovementCooler : SimComponent
	{
		private float coolingRate;

		private readonly float minCoolingSpeed;

		private readonly float maxCoolingSpeed;

		private readonly bool coolingInForwardDirection;

		private readonly PortReference speedReader;

		private readonly PortReference temperature;

		private readonly PortReference targetTemperature;

		private readonly Port heatOut;

		public DirectionalMovementCooler(DirectionalMovementCoolerDefinition dmcDef)
			: base(dmcDef.ID)
		{
			coolingRate = dmcDef.coolingRate;
			minCoolingSpeed = dmcDef.minCoolingSpeed;
			maxCoolingSpeed = dmcDef.maxCoolingSpeed;
			coolingInForwardDirection = dmcDef.coolingInForwardDirection;
			speedReader = AddPortReference(dmcDef.speedReader);
			temperature = AddPortReference(dmcDef.temperature);
			targetTemperature = AddPortReference(dmcDef.targetTemperature, 25f);
			heatOut = AddPort(dmcDef.heatOut);
		}

		public override void Tick(float delta)
		{
			float value = speedReader.Value;
			float num = ((value >= 0f == coolingInForwardDirection) ? Mathf.InverseLerp(minCoolingSpeed, maxCoolingSpeed, Mathf.Abs(value)) : 0f);
			float num2 = targetTemperature.Value - temperature.Value;
			heatOut.Value = num2 * num * coolingRate;
		}
	}
}
