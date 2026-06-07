using LocoSim.Definitions;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class ElectricCompressor : SimComponent
	{
		public readonly float maxPower;

		public readonly float maxBarLiterProductionRate;

		public readonly float smoothTime;

		public readonly FuseReference powerFuseRef;

		public readonly Port activationSignalExtIn;

		public readonly Port compressorHealthStateExtIn;

		public readonly PortReference voltageNormalizedReader;

		public readonly Port powerConsumptionReadOut;

		public readonly Port productionRateReadOut;

		public readonly Port productionRateNormalizedReadOut;

		public readonly Port mainResVolumeReadOut;

		public readonly Port activationPressureThresholdReadOut;

		private float productionRateSmoothed;

		private float productionRateSmoothedVelocity;

		public ElectricCompressor(ElectricCompressorDefinition cDef)
			: base(cDef.ID)
		{
			maxPower = cDef.maxPower;
			maxBarLiterProductionRate = cDef.maxBarLiterProductionRate;
			smoothTime = cDef.smoothTime;
			powerFuseRef = AddFuseReference(cDef.powerFuseId);
			activationSignalExtIn = AddPort(cDef.activationSignalExtIn);
			compressorHealthStateExtIn = AddPort(cDef.compressorHealthStateExtIn, 1f);
			voltageNormalizedReader = AddPortReference(cDef.voltageNormalizedReader);
			powerConsumptionReadOut = AddPort(cDef.powerConsumptionReadOut);
			productionRateReadOut = AddPort(cDef.productionRateReadOut);
			productionRateNormalizedReadOut = AddPort(cDef.productionRateNormalizedReadOut);
			mainResVolumeReadOut = AddPort(cDef.mainResVolumeReadOut, cDef.mainReservoirVolume);
			activationPressureThresholdReadOut = AddPort(cDef.activationPressureThresholdReadOut, cDef.activationPressureThreshold);
		}

		public override void Tick(float delta)
		{
			float num = Mathf.Clamp01(activationSignalExtIn.Value);
			bool num2 = gameParams.CompressorFailureAllowed && Mathf.Clamp01(compressorHealthStateExtIn.Value) < 0.2f;
			float num3 = powerFuseRef.ProcessInput(voltageNormalizedReader.Value);
			float num4 = ((!num2 && num3 > 0f) ? (num3 * num) : 0f);
			if (num4 == 0f && productionRateSmoothed < 0.001f)
			{
				productionRateSmoothed = 0f;
				productionRateSmoothedVelocity = 0f;
			}
			else
			{
				float num5 = num4 * maxBarLiterProductionRate;
				productionRateSmoothed = ((smoothTime > 0f) ? Mathf.SmoothDamp(productionRateSmoothed, num5, ref productionRateSmoothedVelocity, smoothTime, float.PositiveInfinity, delta) : num5);
			}
			productionRateReadOut.Value = productionRateSmoothed;
			productionRateNormalizedReadOut.Value = productionRateSmoothed / maxBarLiterProductionRate;
			powerConsumptionReadOut.Value = maxPower * productionRateNormalizedReadOut.Value;
		}
	}
}
