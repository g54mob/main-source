using System;
using System.Collections.Generic;
using UnityEngine;

namespace DV.ThingTypes.TransitionHelpers
{
	public static class TransitionHelpers
	{
		private static DVObjectModel Current => DVObjectModel.current;

		private static Tv2 Helper<Tv1, Tv2>(Tv1 enumVal, Dictionary<Tv1, Tv2> dict) where Tv1 : Enum where Tv2 : Thing_v2_from_v1_enum<Tv1>
		{
			if (!dict.TryGetValue(enumVal, out var value))
			{
				Debug.LogError($"Couldn't find mapping for '{enumVal}'");
				return null;
			}
			return value;
		}

		public static TrainCarLivery ToV2(this TrainCarType enumVal)
		{
			return Helper(enumVal, Current.TrainCarType_to_v2);
		}

		public static CargoType_v2 ToV2(this CargoType enumVal)
		{
			return Helper(enumVal, Current.CargoType_to_v2);
		}

		public static ResourceType_v2 ToV2(this ResourceType enumVal)
		{
			return Helper(enumVal, Current.ResourceType_to_v2);
		}

		public static GeneralLicenseType_v2 ToV2(this GeneralLicenseType enumVal)
		{
			return Helper(enumVal, Current.GeneralLicenseType_to_v2);
		}

		public static JobLicenseType_v2 ToV2(this JobLicenses enumVal)
		{
			return Helper(enumVal, Current.JobLicenses_to_v2);
		}

		public static GarageType_v2 ToV2(this Garage enumVal)
		{
			return Helper(enumVal, Current.Garage_to_v2);
		}
	}
}
