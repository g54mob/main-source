using LocoSim.Definitions;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class SteamCompressor : SimComponent
	{
		public readonly float MIN_STEAM_PRESSURE = 1.5f;

		public readonly float maxProductionRate;

		public readonly float maxSteamConsumption;

		public readonly float pressureForMaxProduction;

		public readonly float smoothTime;

		public readonly Port activationSignalExtIn;

		public readonly Port mainResPressureNormalizedExtIn;

		public readonly PortReference compressorControl;

		public readonly Port compressorHealthStateExtIn;

		public readonly PortReference steamPressure;

		public readonly Port steamConsumptionReadOut;

		public readonly Port productionRateReadOut;

		public readonly Port productionRateNormalizedReadOut;

		public readonly Port mainResVolumeReadOut;

		public readonly Port activationPressureThresholdReadOut;

		private float productionRateSmoothed;

		private float productionRateSmoothedVelocity;

		public SteamCompressor(SteamCompressorDefinition scDef)
			: base(scDef.ID)
		{
			maxProductionRate = scDef.maxProductionRate;
			maxSteamConsumption = scDef.maxSteamConsumption;
			pressureForMaxProduction = scDef.pressureForMaxProduction;
			smoothTime = scDef.smoothTime;
			activationSignalExtIn = AddPort(scDef.activationSignalExtIn);
			mainResPressureNormalizedExtIn = AddPort(scDef.mainResPressureNormalizedExtIn);
			compressorControl = AddPortReference(scDef.compressorControl);
			compressorHealthStateExtIn = AddPort(scDef.compressorHealthStateExtIn, 1f);
			steamPressure = AddPortReference(scDef.steamPressure);
			steamConsumptionReadOut = AddPort(scDef.steamConsumptionReadOut);
			productionRateReadOut = AddPort(scDef.productionRateReadOut);
			productionRateNormalizedReadOut = AddPort(scDef.productionRateNormalizedReadOut);
			mainResVolumeReadOut = AddPort(scDef.mainResVolumeReadOut, scDef.mainReservoirVolume);
			activationPressureThresholdReadOut = AddPort(scDef.activationPressureThresholdReadOut, scDef.activationPressureThreshold);
		}

		public override void Tick(float delta)
		{
			bool flag = gameParams.CompressorFailureAllowed && Mathf.Clamp01(compressorHealthStateExtIn.Value) < 0.2f;
			float num = 0f;
			if (Mathf.Clamp01(activationSignalExtIn.Value) * compressorControl.Value > 0f && !flag)
			{
				num = NumberUtil.MapClamp(steamPressure.Value, 1f, pressureForMaxProduction, 0f, maxProductionRate);
				float num2 = NumberUtil.MapClamp(mainResPressureNormalizedExtIn.Value, 0.75f, 1f, 1f, 0.2f);
				num *= num2;
			}
			if (num == 0f && productionRateSmoothed < 0.001f)
			{
				productionRateSmoothed = 0f;
				productionRateSmoothedVelocity = 0f;
			}
			else
			{
				productionRateSmoothed = Mathf.SmoothDamp(productionRateSmoothed, num, ref productionRateSmoothedVelocity, smoothTime, float.PositiveInfinity, delta);
			}
			productionRateReadOut.Value = productionRateSmoothed;
			productionRateNormalizedReadOut.Value = productionRateSmoothed / maxProductionRate;
			steamConsumptionReadOut.Value = productionRateNormalizedReadOut.Value * maxSteamConsumption;
		}
	}
}
