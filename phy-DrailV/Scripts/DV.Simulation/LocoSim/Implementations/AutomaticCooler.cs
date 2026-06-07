using LocoSim.Definitions;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class AutomaticCooler : SimComponent
	{
		public float coolingRate;

		public readonly float activationTemperature;

		public readonly float deactivationTemperature;

		public readonly float easeTime;

		public readonly FuseReference powerFuseRef;

		public readonly PortReference isPoweredReader;

		public readonly PortReference temperature;

		public readonly PortReference targetTemperature;

		public readonly Port heatOut;

		public readonly Port coolerEffectReadOut;

		private bool isCoolerActive;

		private float coolerEffect;

		private float coolerEffectVelocity;

		public AutomaticCooler(AutomaticCoolerDefinition acDef)
			: base(acDef.ID)
		{
			coolingRate = acDef.coolingRate;
			activationTemperature = acDef.activationTemperature;
			deactivationTemperature = acDef.deactivationTemperature;
			easeTime = acDef.easeTime;
			powerFuseRef = AddFuseReference(acDef.powerFuseId);
			isPoweredReader = AddPortReference(acDef.isPoweredReader);
			temperature = AddPortReference(acDef.temperature);
			targetTemperature = AddPortReference(acDef.targetTemperature, 25f);
			heatOut = AddPort(acDef.heatOut);
			coolerEffectReadOut = AddPort(acDef.coolingEffectReadOut);
		}

		public override void Tick(float delta)
		{
			float value = temperature.Value;
			bool num = powerFuseRef.State && isPoweredReader.Value == 1f;
			float num2 = 0f;
			if (num)
			{
				if (!isCoolerActive)
				{
					if (value > activationTemperature)
					{
						isCoolerActive = true;
					}
				}
				else if (value < deactivationTemperature)
				{
					isCoolerActive = false;
				}
				if (isCoolerActive)
				{
					num2 = 1f;
				}
			}
			if (coolerEffect != num2)
			{
				coolerEffect = Mathf.SmoothDamp(coolerEffect, num2, ref coolerEffectVelocity, easeTime, float.PositiveInfinity, delta);
				if (coolerEffect < 0.01f && coolerEffect > 0f && num2 == 0f)
				{
					coolerEffect = 0f;
					coolerEffectVelocity = 0f;
				}
				else if (coolerEffect > 0.99f && coolerEffect < 1f && num2 == 1f)
				{
					coolerEffect = 1f;
					coolerEffectVelocity = 0f;
				}
			}
			coolerEffectReadOut.Value = coolerEffect;
			float num3 = targetTemperature.Value - value;
			heatOut.Value = num3 * coolerEffect * coolingRate;
		}
	}
}
