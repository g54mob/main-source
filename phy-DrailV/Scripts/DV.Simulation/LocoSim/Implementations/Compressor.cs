using LocoSim.Definitions;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class Compressor : SimComponent
	{
		public readonly float maxPower;

		public readonly float maxBarLiterProductionRate;

		public readonly float smoothTime;

		public readonly FuseReference powerFuseRef;

		public readonly Port activationSignalExtIn;

		public readonly Port compressorHealthStateExtIn;

		public readonly Port powerIn;

		public readonly Port powerOut;

		public readonly Port productionRateReadOut;

		public readonly Port productionRateNormalizedReadOut;

		public readonly Port mainResVolumeReadOut;

		public readonly Port activationPressureThresholdReadOut;

		private float productionRateSmoothed;

		private float productionRateSmoothedVelocity;

		public Compressor(CompressorDefinition cDef)
			: base(cDef.ID)
		{
			maxPower = cDef.maxPower;
			maxBarLiterProductionRate = cDef.maxBarLiterProductionRate;
			smoothTime = cDef.smoothTime;
			powerFuseRef = AddFuseReference(cDef.powerFuseId);
			activationSignalExtIn = AddPort(cDef.activationSignalExtIn);
			compressorHealthStateExtIn = AddPort(cDef.compressorHealthStateExtIn, 1f);
			powerIn = AddPort(cDef.powerIn);
			powerOut = AddPort(cDef.powerOut);
			productionRateReadOut = AddPort(cDef.productionRateReadOut);
			productionRateNormalizedReadOut = AddPort(cDef.productionRateNormalizedReadOut);
			mainResVolumeReadOut = AddPort(cDef.mainResVolumeReadOut, cDef.mainReservoirVolume);
			activationPressureThresholdReadOut = AddPort(cDef.activationPressureThresholdReadOut, cDef.activationPressureThreshold);
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
				num2 = Mathf.Min(value, num * maxPower);
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
