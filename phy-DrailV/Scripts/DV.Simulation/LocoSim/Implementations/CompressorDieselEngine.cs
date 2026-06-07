using LocoSim.Definitions;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class CompressorDieselEngine : SimComponent
	{
		private const float IDLE_POWER_PERCENTAGE = 0.5f;

		private const float MAX_POWER_OVER_IDLE_PERCENTAGE = 0.5f;

		public readonly float maxPower;

		public readonly float maxBarLiterProductionRate;

		public readonly float smoothTime;

		public readonly FuseReference powerFuseRef;

		public readonly Port activationSignalExtIn;

		public readonly Port compressorHealthStateExtIn;

		public readonly PortReference engineRpmNormalizedReader;

		public readonly PortReference engineIdleRpmNormalizedReader;

		public readonly Port powerIn;

		public readonly Port powerOut;

		public readonly Port productionRateReadOut;

		public readonly Port productionRateNormalizedReadOut;

		public readonly Port mainResVolumeReadOut;

		public readonly Port activationPressureThresholdReadOut;

		private float productionRateSmoothed;

		private float productionRateSmoothedVelocity;

		private float rpmOverIdleMaxNormalized;

		public CompressorDieselEngine(CompressorDieselEngineDefinition cdeDef)
			: base(cdeDef.ID)
		{
			maxPower = cdeDef.maxPower;
			maxBarLiterProductionRate = cdeDef.idleBarLiterProduction + cdeDef.idleBarLiterProduction / 0.5f * 0.5f;
			smoothTime = cdeDef.smoothTime;
			powerFuseRef = AddFuseReference(cdeDef.powerFuseId);
			activationSignalExtIn = AddPort(cdeDef.activationSignalExtIn);
			compressorHealthStateExtIn = AddPort(cdeDef.compressorHealthStateExtIn, 1f);
			engineRpmNormalizedReader = AddPortReference(cdeDef.engineRpmNormalizedReader);
			engineIdleRpmNormalizedReader = AddPortReference(cdeDef.engineIdleRpmNormalizedReader);
			powerIn = AddPort(cdeDef.powerIn);
			powerOut = AddPort(cdeDef.powerOut);
			productionRateReadOut = AddPort(cdeDef.productionRateReadOut);
			productionRateNormalizedReadOut = AddPort(cdeDef.productionRateNormalizedReadOut);
			mainResVolumeReadOut = AddPort(cdeDef.mainResVolumeReadOut, cdeDef.mainReservoirVolume);
			activationPressureThresholdReadOut = AddPort(cdeDef.activationPressureThresholdReadOut, cdeDef.activationPressureThreshold);
		}

		public override void InitializationAfterConnecting()
		{
			rpmOverIdleMaxNormalized = 1f - engineIdleRpmNormalizedReader.Value;
		}

		public override void Tick(float delta)
		{
			float num = Mathf.Clamp01(activationSignalExtIn.Value);
			bool flag = gameParams.CompressorFailureAllowed && Mathf.Clamp01(compressorHealthStateExtIn.Value) < 0.2f;
			float value = powerIn.Value;
			bool flag2 = value > 0f && powerFuseRef.State && !flag;
			float num2 = 0f;
			float num3 = 0f;
			if (num > 0f && flag2)
			{
				float num4 = num * 0.5f * maxPower;
				float num5 = Mathf.Clamp01(engineRpmNormalizedReader.Value - engineIdleRpmNormalizedReader.Value) / rpmOverIdleMaxNormalized * 0.5f * maxPower;
				num2 = Mathf.Min(value, num4 + num5);
				num3 = num2 / maxPower * maxBarLiterProductionRate;
			}
			if (num3 == 0f && productionRateSmoothed < 0.001f)
			{
				productionRateSmoothed = 0f;
				productionRateSmoothedVelocity = 0f;
			}
			else
			{
				productionRateSmoothed = ((smoothTime > 0f) ? Mathf.SmoothDamp(productionRateSmoothed, num3, ref productionRateSmoothedVelocity, smoothTime, float.PositiveInfinity, delta) : num3);
			}
			productionRateReadOut.Value = productionRateSmoothed;
			productionRateNormalizedReadOut.Value = productionRateSmoothed / maxBarLiterProductionRate;
			powerOut.Value = value - num2;
		}
	}
}
