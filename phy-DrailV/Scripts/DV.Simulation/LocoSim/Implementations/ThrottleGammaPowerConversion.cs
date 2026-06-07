using LocoSim.Definitions;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class ThrottleGammaPowerConversion : SimComponent
	{
		public readonly int numberOfNotches;

		public readonly float gamma;

		public readonly PortReference throttleReader;

		public readonly PortReference idleRpmNormalizedReader;

		public readonly PortReference maxPowerRpmNormalizedReader;

		public readonly PortReference maxPowerReader;

		public readonly Port goalPowerReadOut;

		public readonly Port goalRpmNormalizedReadOut;

		public readonly Port notchReadOut;

		private float normalizedRpmPerNotch;

		private int currentThrottleNotch;

		public ThrottleGammaPowerConversion(ThrottleGammaPowerConversionDefinition tgpcDef)
			: base(tgpcDef.ID)
		{
			numberOfNotches = tgpcDef.numberOfNotches;
			gamma = tgpcDef.gamma;
			throttleReader = AddPortReference(tgpcDef.throttleReader);
			idleRpmNormalizedReader = AddPortReference(tgpcDef.idleRpmNormalizedReader);
			maxPowerRpmNormalizedReader = AddPortReference(tgpcDef.maxPowerRpmNormalizedReader);
			maxPowerReader = AddPortReference(tgpcDef.maxPowerReader);
			goalPowerReadOut = AddPort(tgpcDef.goalPowerReadOut);
			goalRpmNormalizedReadOut = AddPort(tgpcDef.goalRpmNormalizedReadOut);
			notchReadOut = AddPort(tgpcDef.notchReadOut);
		}

		public override void InitializationAfterConnecting()
		{
			normalizedRpmPerNotch = (maxPowerRpmNormalizedReader.Value - idleRpmNormalizedReader.Value) / (float)(numberOfNotches - 2);
		}

		public override void Tick(float delta)
		{
			int num = Mathf.RoundToInt(throttleReader.Value * (float)(numberOfNotches - 1));
			notchReadOut.Value = num;
			goalRpmNormalizedReadOut.Value = ((num <= 1) ? idleRpmNormalizedReader.Value : (idleRpmNormalizedReader.Value + normalizedRpmPerNotch * (float)(num - 1)));
			float value = maxPowerReader.Value * Mathf.Pow((float)num / (float)(numberOfNotches - 1), gamma);
			goalPowerReadOut.Value = value;
		}
	}
}
