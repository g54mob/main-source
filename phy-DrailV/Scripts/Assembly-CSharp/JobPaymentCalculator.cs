using System.Collections.Generic;
using DV;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using DV.Utils;
using UnityEngine;

public static class JobPaymentCalculator
{
	private const float BONUS_TIME_LIMIT_MINUTES_PER_KM = 7.5f;

	private const int SHUNTING_TIME_BASE_MINUTES = 18;

	private const float BASE_PAYMENT = 2000f;

	private const float DISTANCE_MULTIPLIER = 5E-05f;

	private const int FALLOFF_START_CAR_NUMBER = 3;

	private const float FALLOFF_STEEPNESS = 0.01f;

	private const float BORINGNESS_SHUNTING = 13.3f;

	private const float BORINGNESS_HAUL = 2.5f;

	private const float BORINGNESS_EMPTY_HAUL = 6.5f;

	private const float CAR_VALUE_MULTIPLIER = 0.01f;

	private const float CAR_MASS_MULTIPLIER = 0.02f;

	private const float CARGO_VALUE_MULTIPLIER = 0.03f;

	private const float CARGO_MASS_MULTIPLIER = 0.015f;

	private const float CARGO_ENVIRONMENT_DAMAGE_VALUE_MULTIPLIER = 0.05f;

	public static float CalculateJobPayment(JobType jobType, float distanceInMeters, PaymentCalculationData paymentCalculationData)
	{
		if (paymentCalculationData == null)
		{
			Debug.LogError("Provided null for paymentCalculationData. Using 0 for payment!");
			return 0f;
		}
		int num = 0;
		float num2 = 0f;
		float num3 = 0f;
		Dictionary<TrainCarLivery, int> carsData = paymentCalculationData.carsData;
		foreach (TrainCarLivery key in carsData.Keys)
		{
			int num4 = carsData[key];
			TrainCarType_v2 parentType = key.parentType;
			num2 += parentType.mass * (float)num4;
			num3 += parentType.damage.bodyPrice * (float)num4;
			num += num4;
		}
		float num5 = 0f;
		int num6 = 0;
		float num7 = 0f;
		float num8 = 0f;
		float num9 = 0f;
		Dictionary<CargoType, int> cargoData = paymentCalculationData.cargoData;
		foreach (CargoType key2 in cargoData.Keys)
		{
			CargoType_v2 cargoType_v = key2.ToV2();
			if (!(cargoType_v == null))
			{
				int num10 = cargoData[key2];
				num7 += cargoType_v.massPerUnit * (float)num10;
				num8 += cargoType_v.fullDamagePrice * (float)num10;
				num9 += cargoType_v.environmentDamagePrice * (float)num10;
				num5 += cargoType_v.sensitivityPaymentModifier * (float)num10;
				num6 += num10;
			}
		}
		float num11 = distanceInMeters * 5E-05f;
		float num12 = num2 * 0.02f + num3 * 0.01f + num7 * 0.015f + num8 * 0.03f + num9 * 0.05f;
		float boringnessFactor = GetBoringnessFactor(jobType);
		float falloffFactor = GetFalloffFactor(num);
		int num13 = Mathf.Max(num - num6, 0);
		float num14 = (num5 + (float)num13) / (float)(num6 + num13);
		return Mathf.Round((2000f + num12 * num11 * boringnessFactor * falloffFactor * num14) * Globals.G.GameParams.JobPaymentModifier);
	}

	private static float GetFalloffFactor(int numberOfCars)
	{
		if (numberOfCars <= 3)
		{
			return 1f;
		}
		return 1f / (1f + 0.01f * (float)(numberOfCars - 3));
	}

	private static float GetBoringnessFactor(JobType jobType)
	{
		switch (jobType)
		{
		case JobType.ShuntingLoad:
		case JobType.ShuntingUnload:
			return 13.3f;
		case JobType.Transport:
			return 2.5f;
		case JobType.EmptyHaul:
			return 6.5f;
		default:
			Debug.LogError($"Unexpected job type {jobType}! Using 1 for boringness factor");
			return 1f;
		}
	}

	public static float CalculateHaulBonusTimeLimit(float distanceInMeters, bool ignoreTimeDecreaseFromLicenses = false)
	{
		float num = (ignoreTimeDecreaseFromLicenses ? 1f : (1f - SingletonBehaviour<LicenseManager>.Instance.BonusTimeDecreasePercentage));
		return (float)Mathf.RoundToInt(distanceInMeters * 0.001f * 7.5f * num * Globals.G.GameParams.JobBonusTimeLimitModifier) * 60f;
	}

	public static float CalculateShuntingBonusTimeLimit(int numberOfTracks, bool ignoreTimeDecreaseFromLicenses = false)
	{
		float num = (ignoreTimeDecreaseFromLicenses ? 1f : (1f - SingletonBehaviour<LicenseManager>.Instance.BonusTimeDecreasePercentage));
		return (float)Mathf.RoundToInt(18f * num * Globals.G.GameParams.JobBonusTimeLimitModifier) * 60f * (float)numberOfTracks;
	}

	public static float GetDistanceBetweenStations(StationController startStation, StationController destinationStation)
	{
		return Vector3.Distance(startStation.transform.position, destinationStation.transform.position);
	}
}
