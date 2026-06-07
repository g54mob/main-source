using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.BladedEngineScripts
{
	public class RotorPerfScalarsScript : PartModifierScript
	{
		private class RotorPerformance
		{
			public const float BaseCollectiveDragScalar = 1f;

			public const float BaseCollectiveLiftScalar = 1f;

			public const float CollectiveTorqueScalar = 5f;

			public const float CyclicBaseStrengthScalar = 0.2f;

			public const float CyclicMotorDragCylicTorqueRatio = 2f;

			public const float EngineInitialPowerScalar = 5f;

			public const float GroundEffectScalar = 1f;

			public const float GyroscopicLagScalar = 1f;

			public const float GyroscopicStabilizationBaseScalar = 13f;

			public const float MaxCyclicDegrees = 20f;

			public const float RelativeWindPassiveLiftScalar = 1f;

			public const float RelativeWindPassiveTorqueScalar = 31f;

			public const float RelativeWindPeakSpeed = 15f;

			public const float RotorTensorScalar = 8f;

			public const float RpmPercentToAddParasiticDrag = 0.05f;

			public const float TranslationalLiftScalar = 1f;
		}

		public float BaseCollectiveDragScalar => Data.CollectiveDrag * 1f;

		public float BaseCollectiveLiftScalar => Data.CollectiveLift * 1f;

		public float CollectiveTorqueScalar => Data.CollectiveTorque * 5f;

		public float CyclicBaseStrengthScalar => Data.CyclicStrength * 0.2f;

		public float CyclicMotorDragCylicTorqueRatio => Data.CyclicMotorDragTorque * 2f;

		public float CyclicPitchInputExpo => Data.CyclicPitchInputExpo;

		public float CyclicRollInputExpo => Data.CyclicRollInputExpo;

		public float CyclicRpmFalloffExpo => Data.CyclicRpmFalloffExpo;

		public RotorPerfScalarsData Data { get; private set; }

		public float EngineInitialPowerScalar => 5f;

		public float GroundEffectScalar => Data.GroundEffect * 1f;

		public float GyroscopicLagScalar => Data.GyroscopicLag * 1f;

		public float GyroscopicStabilizationBaseScalar => Data.GyroscopicStabilization * 13f;

		public float MaxCyclicDegrees => 20f;

		public float RelativeWindPassiveLiftScalar => Data.RelativeWindPassiveLift * 1f;

		public float RelativeWindPassiveTorqueScalar => Data.RelativeWindPassiveTorque * 31f;

		public float RelativeWindPeakSpeed => Data.RelativeWindPeakSpeed * 15f;

		public float RotorTensorScalar => Data.RotorTensor * 8f;

		public float RpmPercentToAddParasiticDrag => 0.05f;

		public float TranslationalLiftScalar => Data.TranslationalLift * 1f;

		public Vector3 CalculateTensor(float rotorArea)
		{
			return new Vector3(1f, 1f, rotorArea * 0.01f * RotorTensorScalar);
		}

		public void OnModifierInitialized(RotorPerfScalarsData heliMainRotorPerformance)
		{
			Data = heliMainRotorPerformance;
		}
	}
}
