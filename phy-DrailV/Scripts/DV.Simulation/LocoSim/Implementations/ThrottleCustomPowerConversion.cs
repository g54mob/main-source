using LocoSim.Definitions;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class ThrottleCustomPowerConversion : SimComponent
	{
		public readonly float[] notchPowerPercentages;

		public readonly PortReference throttleReader;

		public readonly PortReference maxPowerReader;

		public readonly Port goalPowerReadOut;

		public readonly Port notchReadOut;

		public readonly Port prevNotchReadOut;

		private int currentThrottleNotch;

		public ThrottleCustomPowerConversion(ThrottleCustomPowerConversionDefinition tcpcDef)
			: base(tcpcDef.ID)
		{
			notchPowerPercentages = tcpcDef.notchPowerPercentages;
			throttleReader = AddPortReference(tcpcDef.throttleReader);
			maxPowerReader = AddPortReference(tcpcDef.maxPowerReader);
			goalPowerReadOut = AddPort(tcpcDef.goalPowerReadOut);
			notchReadOut = AddPort(tcpcDef.notchReadOut);
			prevNotchReadOut = AddPort(tcpcDef.prevNotchReadOut);
		}

		public override void Tick(float delta)
		{
			int num = Mathf.RoundToInt(throttleReader.Value * (float)(notchPowerPercentages.Length - 1));
			if (currentThrottleNotch != num)
			{
				prevNotchReadOut.Value = currentThrottleNotch;
				notchReadOut.Value = num;
				currentThrottleNotch = num;
				float value = maxPowerReader.Value * notchPowerPercentages[currentThrottleNotch];
				goalPowerReadOut.Value = value;
			}
			else if (prevNotchReadOut.Value != (float)currentThrottleNotch)
			{
				prevNotchReadOut.Value = currentThrottleNotch;
			}
		}
	}
}
