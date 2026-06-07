using LocoSim.Definitions;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class ActiveCooler : SimComponent
	{
		public readonly float coolingRate;

		public readonly float easeTime;

		public readonly FuseReference powerFuseRef;

		public readonly PortReference controlReader;

		public readonly PortReference temperature;

		public readonly PortReference targetTemperature;

		public readonly Port heatOut;

		public readonly Port coolingEffectReadOut;

		private float coolerEffect;

		private float coolerEffectVelocity;

		public ActiveCooler(ActiveCoolerDefinition acDef)
			: base(acDef.ID)
		{
			coolingRate = acDef.coolingRate;
			easeTime = acDef.easeTime;
			powerFuseRef = AddFuseReference(acDef.powerFuseId);
			controlReader = AddPortReference(acDef.controlReader);
			temperature = AddPortReference(acDef.temperature);
			targetTemperature = AddPortReference(acDef.targetTemperature, 25f);
			heatOut = AddPort(acDef.heatOut);
			coolingEffectReadOut = AddPort(acDef.coolingEffectReadOut);
		}

		public override void Tick(float delta)
		{
			float num = targetTemperature.Value - temperature.Value;
			float num2 = powerFuseRef.ProcessInput(controlReader.Value);
			coolerEffect = Mathf.SmoothDamp(coolerEffect, num2, ref coolerEffectVelocity, easeTime, float.PositiveInfinity, delta);
			if ((double)coolerEffect < 0.001 && num2 == 0f)
			{
				coolerEffect = 0f;
			}
			coolingEffectReadOut.Value = coolerEffect;
			heatOut.Value = num * coolerEffect * coolingRate;
		}
	}
}
