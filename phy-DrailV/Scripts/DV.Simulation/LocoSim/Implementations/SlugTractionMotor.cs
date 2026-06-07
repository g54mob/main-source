using LocoSim.Definitions;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class SlugTractionMotor : SimComponent
	{
		private const float RPM_SMOOTH_TIME = 0.2f;

		public readonly float maxRpm;

		public readonly PortReference wheelRpmReader;

		public readonly PortReference gearRatioReader;

		public readonly Port torqueInverterExtIn;

		public readonly Port torqueExtIn;

		public readonly Port ampsExtIn;

		public readonly Port dynamicBrakeEffectExtIn;

		public readonly Port torqueOut;

		public readonly Port tmRpmNormalizedReadOut;

		public readonly Port numOfTractionMotorsReadOut;

		private float tmRpm;

		private float tmRpmSmoothVelocity;

		public SlugTractionMotor(SlugTractionMotorDefinition stmd)
			: base(stmd.ID)
		{
			maxRpm = stmd.maxRpm;
			wheelRpmReader = AddPortReference(stmd.wheelRpmReader);
			gearRatioReader = AddPortReference(stmd.gearRatioReader);
			torqueInverterExtIn = AddPort(stmd.torqueInverterExtIn);
			torqueExtIn = AddPort(stmd.torqueExtIn);
			ampsExtIn = AddPort(stmd.ampsExtIn);
			dynamicBrakeEffectExtIn = AddPort(stmd.dynamicBrakeEffectExtIn);
			torqueOut = AddPort(stmd.torqueOut);
			tmRpmNormalizedReadOut = AddPort(stmd.tmRpmNormalizedReadOut);
			numOfTractionMotorsReadOut = AddPort(stmd.numOfTractionMotorsReadOut, stmd.numberOfTractionMotors);
		}

		public override void Tick(float delta)
		{
			float target = Mathf.Abs(wheelRpmReader.Value) * gearRatioReader.Value;
			tmRpm = Mathf.SmoothDamp(tmRpm, target, ref tmRpmSmoothVelocity, 0.2f, float.PositiveInfinity, delta);
			tmRpmNormalizedReadOut.Value = tmRpm / maxRpm;
			float num = torqueExtIn.Value;
			if (torqueInverterExtIn.Value == 1f)
			{
				num = 0f - num;
			}
			float num2 = 1f - Mathf.InverseLerp(maxRpm, maxRpm * 1.05f, tmRpm);
			torqueOut.Value = num * numOfTractionMotorsReadOut.Value * num2;
		}
	}
}
