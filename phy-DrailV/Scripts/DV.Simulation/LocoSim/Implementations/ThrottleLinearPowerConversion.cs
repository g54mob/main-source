using LocoSim.Definitions;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class ThrottleLinearPowerConversion : SimComponent
	{
		public readonly int numberOfNotches;

		public readonly PortReference throttleReader;

		public readonly PortReference maxPowerReader;

		public readonly Port goalPowerReadOut;

		public readonly Port notchReadOut;

		public readonly Port prevNotchReadOut;

		private int currentThrottleNotch;

		public ThrottleLinearPowerConversion(ThrottleLinearPowerConversionDefinition tlpcDef)
			: base(tlpcDef.ID)
		{
			numberOfNotches = tlpcDef.numberOfNotches;
			throttleReader = AddPortReference(tlpcDef.throttleReader);
			maxPowerReader = AddPortReference(tlpcDef.maxPowerReader);
			goalPowerReadOut = AddPort(tlpcDef.goalPowerReadOut);
			notchReadOut = AddPort(tlpcDef.notchReadOut);
			prevNotchReadOut = AddPort(tlpcDef.prevNotchReadOut);
		}

		public override void Tick(float delta)
		{
			int num = Mathf.RoundToInt(throttleReader.Value * (float)(numberOfNotches - 1));
			if (currentThrottleNotch != num)
			{
				prevNotchReadOut.Value = currentThrottleNotch;
				notchReadOut.Value = num;
				currentThrottleNotch = num;
				float value = maxPowerReader.Value / (float)(numberOfNotches - 1) * (float)currentThrottleNotch;
				goalPowerReadOut.Value = value;
			}
			else if (prevNotchReadOut.Value != (float)currentThrottleNotch)
			{
				prevNotchReadOut.Value = currentThrottleNotch;
			}
		}
	}
}
