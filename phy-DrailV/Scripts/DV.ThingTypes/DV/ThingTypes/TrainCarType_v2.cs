using System;
using System.Collections.Generic;
using System.Linq;
using DV.ThingTypes.Attributes;
using UnityEngine;

namespace DV.ThingTypes
{
	[CreateAssetMenu(menuName = "DV/Object Model/Train Car - type", fileName = "TrainCarType_")]
	public class TrainCarType_v2 : Thing_v2
	{
		[Serializable]
		public class BrakesSetup
		{
			public enum TrainBrake
			{
				None = 0,
				SelfLap = 1,
				ManualLap = 2
			}

			public enum BrakeCylinderPressureCalculation
			{
				Regular = 0,
				CopyFront = 1,
				CopyRear = 2,
				CopyMax = 3
			}

			public bool hasCompressor;

			public bool hasMainResConnections;

			public TrainBrake trainBrake;

			public bool hasIndependentBrake;

			public bool hasHandbrake = true;

			public bool ignoreOverheating;

			public BrakeCylinderPressureCalculation brakeCylinderPressureCalculation;

			[Header("Leave brake curve data blank for linear behaviour")]
			public BrakesCurve trainBrakeCurveData;

			public BrakesCurve indBrakeCurveData;

			[ConstMultiplier(15000f, "MaxBrakingForcePerBogie")]
			public float brakingForcePerBogieMultiplier = 1f;

			public float MaxBrakingForcePerBogie => 15000f * brakingForcePerBogieMultiplier;
		}

		[Serializable]
		public class DamageSetup
		{
			[Header("HP - leave at 0 if unused")]
			public float wheelsHP;

			public float mechanicalPowertrainHP;

			public float electricalPowertrainHP;

			[Header("Price (cars not using wheels price currently")]
			public float bodyPrice = -1f;

			public float wheelsPrice = -1f;

			public float electricalPowertrainPrice = -1f;

			public float mechanicalPowertrainPrice = -1f;
		}

		public enum UnusedCarDeletePreventionMode
		{
			None = 0,
			TimeBasedCarVisit = 10,
			TimeBasedCarVisitPropagatedToFrontCar = 11,
			TimeBasedCarVisitPropagatedToRearCar = 12,
			TimeBasedCarVisitPropagatedToFrontAndRearCar = 13,
			OnlyManualDeletePossible = 20
		}

		private const float MAX_BRAKING_FORCE_PER_BOGIE = 15000f;

		private const float ROLLING_RESISTANCE_COEFFICIENT = 0.002f;

		private const float WHEELSLIDE_FRICTION_COEFFICIENT = 0.13f;

		private const float WHEELSLIP_FRICTION_COEFFICIENT = 0.2f;

		public string carInstanceIdGenBase = "-";

		public string localizationKey;

		public TrainCarKind kind;

		public List<TrainCarLivery> liveries;

		[Header("Info")]
		public float mass;

		public float bogieSuspensionMultiplier = 1f;

		[ConstMultiplier(0.002f, "RollingResistanceCoef")]
		public float rollingResistanceMultiplier = 1f;

		[ConstMultiplier(0.13f, "WheelSlideFrictionCoef")]
		public float wheelSlideFrictionMultiplier = 1f;

		[ConstMultiplier(0.2f, "WheelslipFrictionCoef")]
		public float wheelslipFrictionMultiplier = 1f;

		public BrakesSetup brakes;

		public DamageSetup damage;

		[Header("Wheels")]
		public float wheelRadius;

		public bool useDefaultWheelRotation = true;

		[Header("HUD - optional")]
		public GameObject hudPrefab;

		[Header("Audio - optional")]
		public GameObject audioPrefab;

		public int audioPoolSize;

		[Header("Unused car delete prevention")]
		public UnusedCarDeletePreventionMode unusedCarDeletePreventionMode;

		public JobLicenseType_v2[] requiredJobLicenses;

		public float RollingResistanceCoef => 0.002f * rollingResistanceMultiplier;

		public float WheelSlideFrictionCoef => 0.13f * wheelSlideFrictionMultiplier;

		public float WheelslipFrictionCoef => 0.2f * wheelslipFrictionMultiplier;

		protected override void PopulateErrors(ErrorPopulator AddError)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				AddError("id is empty");
			}
			if (string.IsNullOrWhiteSpace(localizationKey))
			{
				AddError("localizationKey is empty");
			}
			if (kind == null)
			{
				AddError("kind is null");
			}
			if (liveries == null || liveries.Count == 0)
			{
				AddError("liveries list is null or empty");
			}
			else
			{
				Thing_v2.ValidateList(liveries, "liveries", AddError);
				liveries.Where((TrainCarLivery el) => el != null).SelectMany((TrainCarLivery el) => el.Validate()).ToList()
					.ForEach(delegate((string errorMessage, UnityEngine.Object context) tup)
					{
						AddError(tup.errorMessage, tup.context);
					});
			}
			if (mass <= 0f)
			{
				AddError("mass is not set properly");
			}
			if (bogieSuspensionMultiplier <= 0f)
			{
				AddError("bogieSuspensionMultiplier is less or equal to 0");
			}
			if (rollingResistanceMultiplier <= 0f)
			{
				AddError("RollingResistanceCoef multiplier is less or equal to 0");
			}
			if (wheelSlideFrictionMultiplier <= 0f)
			{
				AddError("WheelSlideFrictionCoef multiplier is less or equal to 0");
			}
			if (wheelslipFrictionMultiplier <= 0f)
			{
				AddError("WheelslipFrictionCoef multiplier is less or equal to 0");
			}
			if (brakes.trainBrake == BrakesSetup.TrainBrake.None && brakes.trainBrakeCurveData != null)
			{
				AddError("Train brake is not present, but trainBrakeCurveData is set");
			}
			if (brakes.trainBrake != BrakesSetup.TrainBrake.None && brakes.brakeCylinderPressureCalculation != BrakesSetup.BrakeCylinderPressureCalculation.Regular)
			{
				AddError("Train brake is present, but brakeCylinderPressureCalculation is not regular!");
			}
			if (!brakes.hasIndependentBrake && brakes.indBrakeCurveData != null)
			{
				AddError("Independent brake is not present, but indBrakeCurveData is set");
			}
			if (brakes.hasIndependentBrake && !brakes.hasCompressor)
			{
				AddError("Independent brake is present, but compressor isn't");
			}
			if (brakes.brakingForcePerBogieMultiplier <= 0f)
			{
				AddError("MaxBrakingForcePerBogie multiplier is less or equal to 0");
			}
			if (damage.bodyPrice < 0f)
			{
				AddError("bodyPrice is not set");
			}
			if (damage.wheelsPrice < 0f)
			{
				AddError("wheelsPrice is not set");
			}
			if (damage.electricalPowertrainPrice < 0f)
			{
				AddError("electricalPowertrainPrice is not set");
			}
			if (damage.mechanicalPowertrainPrice < 0f)
			{
				AddError("mechanicalPowertrainPrice is not set");
			}
			if (wheelRadius <= 0f)
			{
				AddError("wheelRadius is not set properly");
			}
			if (requiredJobLicenses == null)
			{
				AddError("requiredJobLicenses are null");
			}
			if (string.IsNullOrWhiteSpace(carInstanceIdGenBase))
			{
				AddError("carInstanceIdGenBase is null or empty");
			}
		}
	}
}
