using UnityEngine;

namespace DV.ThingTypes
{
	public static class CarTypes
	{
		private static bool KindContains(TrainCarLivery livery, string substring)
		{
			if (livery == null || livery.parentType == null || livery.parentType.kind == null || livery.parentType.kind.id == null)
			{
				Debug.LogError($"Got bad livery '{livery}'");
				return false;
			}
			return livery.parentType.kind.id.ToLower().Contains(substring.ToLower());
		}

		public static bool IsLocomotive(TrainCarLivery carLivery)
		{
			return KindContains(carLivery, "loco");
		}

		public static bool IsSlug(TrainCarLivery carLivery)
		{
			return KindContains(carLivery, "slug");
		}

		public static bool IsMUSteamLocomotive(TrainCarType carType)
		{
			return carType == TrainCarType.LocoSteamHeavy;
		}

		public static bool IsSteamLocomotive(TrainCarLivery carLivery)
		{
			if (carLivery.v1 != TrainCarType.LocoSteamHeavy)
			{
				return carLivery.v1 == TrainCarType.LocoS060;
			}
			return true;
		}

		public static bool IsTender(TrainCarLivery carLivery)
		{
			return KindContains(carLivery, "tender");
		}

		public static bool IsCaboose(TrainCarLivery carLivery)
		{
			return KindContains(carLivery, "caboose");
		}

		public static bool IsRegularCar(TrainCarLivery carLivery)
		{
			return KindContains(carLivery, "car");
		}

		public static bool IsAnyLocomotiveOrTender(TrainCarLivery carLivery)
		{
			if (!IsLocomotive(carLivery))
			{
				return IsTender(carLivery);
			}
			return true;
		}

		public static bool IsAnyLocoSlugTender(TrainCarLivery carLivery)
		{
			if (!IsLocomotive(carLivery) && !IsSlug(carLivery))
			{
				return IsTender(carLivery);
			}
			return true;
		}
	}
}
