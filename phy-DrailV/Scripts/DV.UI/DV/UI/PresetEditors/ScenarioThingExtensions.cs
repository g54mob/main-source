using System.Linq;
using DV.Localization;
using DV.Scenarios.Common;
using DV.ThingTypes;
using UnityEngine;

namespace DV.UI.PresetEditors
{
	public static class ScenarioThingExtensions
	{
		private static DVObjectModel dvOM;

		public static void Init(DVObjectModel dvObjectModel)
		{
			dvOM = dvObjectModel;
		}

		public static TrainCarLivery GetLivery(this ICar car)
		{
			if (car == null || string.IsNullOrWhiteSpace(car.Name) || dvOM == null || dvOM.Liveries.Count == 0 || dvOM.Liveries.Any((TrainCarLivery l) => l == null || string.IsNullOrWhiteSpace(l.id)))
			{
				Debug.LogError("Bad state in ScenarioThingExtensions");
				return null;
			}
			return dvOM.Liveries.FirstOrDefault((TrainCarLivery l) => l.id.ToLower() == car.Name.ToLower());
		}

		public static GarageType_v2 RequiredGarage(this TrainCarLivery carLivery)
		{
			if (carLivery == null || dvOM == null)
			{
				Debug.LogError("Bad state in ScenarioThingExtensions");
				return null;
			}
			dvOM.CarLiveryToGarageRequirement.TryGetValue(carLivery, out var value);
			return value;
		}

		public static CargoType_v2 GetCargo(this ICar car)
		{
			if (car.GetLivery() == null)
			{
				return null;
			}
			return dvOM.cargos.FirstOrDefault((CargoType_v2 c) => c.id == car.CargoType);
		}

		public static bool IsValid(this ICar car)
		{
			if (car != null)
			{
				return car.GetLivery() != null;
			}
			return false;
		}

		public static bool IsLocoOrTenderOrSlug(this ICar car)
		{
			if (car.IsValid())
			{
				return car.GetLivery().parentType.IsLocoOrTenderOrSlug();
			}
			return false;
		}

		public static bool IsLocoOrTenderOrSlug(this TrainCarType_v2 carType)
		{
			if (carType == null)
			{
				return false;
			}
			string text = carType.kind.id.ToLower();
			if (!text.Contains("loco") && !text.Contains("tender"))
			{
				return text.Contains("slug");
			}
			return true;
		}

		public static bool IsRegularCarOrCaboose(this TrainCarType_v2 carType)
		{
			if (carType == null)
			{
				return false;
			}
			string text = carType.kind.id.ToLower();
			if (!text.Contains("car"))
			{
				return text.Contains("caboose");
			}
			return true;
		}

		public static string LocalizedInfo(this ICar car)
		{
			if (car.IsValid())
			{
				TrainCarLivery livery = car.GetLivery();
				string text = LocalizationAPI.L(livery.localizationKey);
				string text2 = LocalizationAPI.L(livery.parentType.kind.localizationKey);
				string text3 = ((car.GetCargo() != null) ? (" – " + LocalizationAPI.L(car.GetCargo().localizationKeyShort)) : "");
				return text2 + " – " + text + text3;
			}
			return "(?) " + car?.Name;
		}
	}
}
