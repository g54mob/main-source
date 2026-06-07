using System;
using System.Collections.Generic;
using System.Linq;
using DV.Scenarios.Common;
using DV.ThingTypes;
using UnityEngine;

namespace DV.UI.PresetEditors
{
	public static class TrainEditor_Helpers
	{
		public static TrainCarType_v2 GetPreviousOrNextCarType(List<TrainCarType_v2> allTypes, TrainCarType_v2 currentType, bool next)
		{
			bool currentKindGroup = currentType.IsLocoOrTenderOrSlug();
			List<TrainCarType_v2> list = allTypes.Where((TrainCarType_v2 t) => t.IsLocoOrTenderOrSlug() == currentKindGroup).ToList();
			if (list.Count == 0)
			{
				Debug.LogWarning($"Found no candidates, this is suspicious, returning given {currentType}", currentType);
				return currentType;
			}
			return GetPreviousOrNext(list, currentType, next);
		}

		public static CargoType_v2 GetPreviousOrNextCargoForCarType(DVObjectModel om, ICar car, bool next)
		{
			if (car == null)
			{
				return null;
			}
			if (!om.CarTypeToLoadableCargo.TryGetValue(car.GetLivery().parentType, out var value) || value.Count == 0)
			{
				Debug.LogWarning("Couldn't find cargos for car type '" + car.CargoType + "'");
				return null;
			}
			List<CargoType_v2> list = value.Concat(new CargoType_v2[1]).ToList();
			CargoType_v2 cargo = car.GetCargo();
			return GetPreviousOrNext(list, cargo, next);
		}

		public static bool CarAcceptsAnyCargo(ICar car, DVObjectModel om)
		{
			if (car == null || !om.CarTypeToLoadableCargo.TryGetValue(car.GetLivery().parentType, out var value) || value.Count == 0)
			{
				return false;
			}
			return true;
		}

		public static bool CarAcceptsCargoType(ICar car, string cargoType, DVObjectModel om)
		{
			if (car == null || !om.CarTypeToLoadableCargo.TryGetValue(car.GetLivery().parentType, out var value) || value.Count == 0)
			{
				return false;
			}
			return value.Any((CargoType_v2 c) => c.id == cargoType);
		}

		public static TrainCarLivery GetPreviousOrNextCarLivery(TrainCarLivery currentLivery, bool next)
		{
			List<TrainCarLivery> list = currentLivery.parentType.liveries.ToList();
			if (list.Count <= 1)
			{
				return currentLivery;
			}
			return GetPreviousOrNext(list, currentLivery, next);
		}

		public static T GetPreviousOrNext<T>(List<T> list, T current, bool next)
		{
			if (list == null || list.Count < 2)
			{
				return current;
			}
			int num = list.IndexOf(current);
			if (num == -1)
			{
				Debug.LogWarning(string.Format("Given 'current' '{0}' is not a member of given List<{1}>, returning {2}", current, typeof(T).Name, next ? "first" : "last"));
				if (!next)
				{
					return list.LastOrDefault();
				}
				return list.FirstOrDefault();
			}
			int num2 = num + (next ? 1 : (-1));
			if (num2 < 0 && !next)
			{
				num2 = list.Count - 1;
			}
			else if (num2 >= list.Count && next)
			{
				num2 = 0;
			}
			return list[num2];
		}

		public static bool IsLiveryUnlocked(TrainCarLivery livery, HashSet<GeneralLicenseType_v2> unlockedLicenses, HashSet<GarageType_v2> unlockedGarages)
		{
			if (livery == null || (livery.requiredLicense == null && livery.RequiredGarage() == null))
			{
				return true;
			}
			bool flag = false;
			if (livery.requiredLicense != null)
			{
				switch (livery.requiredLicense.FreeRoamAvailability)
				{
				case FreeRoamAvailability.ONLY_IF_UNLOCKED_IN_CAREER:
					flag = unlockedLicenses.Contains(livery.requiredLicense);
					break;
				case FreeRoamAvailability.ALWAYS:
					flag = true;
					break;
				case FreeRoamAvailability.NEVER:
					flag = false;
					break;
				default:
					throw new ArgumentOutOfRangeException(string.Format("Unhandled {0} value {1}", "FreeRoamAvailability", livery.requiredLicense.FreeRoamAvailability));
				}
				if (!flag)
				{
					return false;
				}
			}
			GarageType_v2 garageType_v = livery.RequiredGarage();
			if (garageType_v != null)
			{
				switch (garageType_v.FreeRoamAvailability)
				{
				case FreeRoamAvailability.ONLY_IF_UNLOCKED_IN_CAREER:
					return unlockedGarages.Contains(garageType_v);
				case FreeRoamAvailability.ALWAYS:
					return true;
				case FreeRoamAvailability.NEVER:
					return false;
				default:
					throw new ArgumentOutOfRangeException(string.Format("Unhandled {0} value {1}", "FreeRoamAvailability", livery.requiredLicense.FreeRoamAvailability));
				}
			}
			return true;
		}
	}
}
