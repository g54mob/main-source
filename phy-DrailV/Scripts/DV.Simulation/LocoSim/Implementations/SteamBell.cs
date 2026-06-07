using LocoSim.Definitions;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class SteamBell : SimComponent
	{
		public readonly float steamConsumption;

		public readonly float minOperatingPressure;

		public readonly float smoothDownTime;

		public readonly PortReference bellControl;

		public readonly PortReference steamPressure;

		public readonly Port steamConsumptionReadOut;

		public readonly Port bellNormalizedReadOut;

		private float bellSmoothVelocity;

		public SteamBell(SteamBellDefinition sbDef)
			: base(sbDef.ID)
		{
			steamConsumption = sbDef.steamConsumption;
			minOperatingPressure = sbDef.minOperatingPressure;
			smoothDownTime = sbDef.smoothDownTime;
			steamPressure = AddPortReference(sbDef.steamPressure);
			bellControl = AddPortReference(sbDef.bellControl);
			bellNormalizedReadOut = AddPort(sbDef.bellNormalizedReadOut);
			steamConsumptionReadOut = AddPort(sbDef.steamConsumptionReadOut);
		}

		public override void Tick(float delta)
		{
			float value = bellNormalizedReadOut.Value;
			if (steamPressure.Value > minOperatingPressure && bellControl.Value > 0f)
			{
				value = 1f;
				bellSmoothVelocity = 0f;
			}
			else if (value > 0f && value < 0.001f)
			{
				value = 0f;
				bellSmoothVelocity = 0f;
			}
			else
			{
				value = Mathf.SmoothDamp(value, 0f, ref bellSmoothVelocity, smoothDownTime, float.PositiveInfinity, delta);
			}
			bellNormalizedReadOut.Value = value;
			steamConsumptionReadOut.Value = value * steamConsumption;
		}
	}
}
