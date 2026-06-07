using LocoSim.Definitions;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class MechanicalCompressor : SimComponent
	{
		public readonly float loadTorque;

		public readonly float maxProductionRate;

		public readonly float smoothTime;

		public readonly Port activationSignalExtIn;

		public readonly Port compressorHealthStateExtIn;

		public readonly PortReference engineRpmNormalizedReader;

		public readonly Port torqueOut;

		public readonly Port productionRateReadOut;

		public readonly Port productionRateNormalizedReadOut;

		public readonly Port mainResVolumeReadOut;

		public readonly Port activationPressureThresholdReadOut;

		private float engagement;

		private float engagementVelocity;

		public MechanicalCompressor(MechanicalCompressorDefinition mcDef)
			: base(mcDef.ID)
		{
			loadTorque = mcDef.loadTorque;
			maxProductionRate = mcDef.maxProductionRate;
			smoothTime = mcDef.smoothTime;
			activationSignalExtIn = AddPort(mcDef.activationSignalExtIn);
			compressorHealthStateExtIn = AddPort(mcDef.compressorHealthStateExtIn, 1f);
			engineRpmNormalizedReader = AddPortReference(mcDef.engineRpmNormalizedReader);
			torqueOut = AddPort(mcDef.torqueOut);
			productionRateReadOut = AddPort(mcDef.productionRateReadOut);
			productionRateNormalizedReadOut = AddPort(mcDef.productionRateNormalizedReadOut);
			mainResVolumeReadOut = AddPort(mcDef.mainResVolumeReadOut, mcDef.mainReservoirVolume);
			activationPressureThresholdReadOut = AddPort(mcDef.activationPressureThresholdReadOut, mcDef.activationPressureThreshold);
		}

		public override void Tick(float delta)
		{
			bool flag = gameParams.CompressorFailureAllowed && Mathf.Clamp01(compressorHealthStateExtIn.Value) < 0.2f;
			bool num = activationSignalExtIn.Value > 0f && !flag;
			float value = engineRpmNormalizedReader.Value;
			float num2 = (num ? 1f : 0f);
			if (num2 == 0f && engagement < 0.001f)
			{
				engagement = 0f;
				engagementVelocity = 0f;
			}
			else
			{
				engagement = ((smoothTime == 0f) ? num2 : Mathf.SmoothDamp(engagement, num2, ref engagementVelocity, smoothTime, float.PositiveInfinity, delta));
			}
			productionRateNormalizedReadOut.Value = engagement * value;
			productionRateReadOut.Value = engagement * value * maxProductionRate;
			torqueOut.Value = (0f - loadTorque) * engagement;
		}
	}
}
