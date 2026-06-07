using System.Collections.Generic;
using System.Text;
using DV.Localization;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using UnityEngine;

namespace DV.Booklets
{
	public class C
	{
		public const string CURRENCY_SIGN = "$";

		public const string PLUS_CURRENCY_SIGN = "+$";

		public const string MINUS_CURRENCY_SIGN = "-$";

		public const int NUM_OF_NO_DAMAGE_BOOKLET_PAGES = 2;

		public static readonly Color HAUL_JOB_TYPE_COLOR = new Color(0.4117f, 0.847f, 0.4117f);

		public static readonly Color SHUNTING_LOAD_JOB_TYPE_COLOR = new Color(0.847f, 0.4117f, 0.4117f);

		public static readonly Color SHUNTING_UNLOAD_JOB_TYPE_COLOR = new Color(0.847f, 0.4117f, 0.4117f);

		public static readonly Color EMPTY_HAUL_JOB_TYPE_COLOR = new Color(0.847f, 0.76f, 0.4117f);

		public static readonly Color JOB_REPORT_IN_PROGRESS_COLOR = new Color(0.847f, 0.76f, 0.4117f);

		public static readonly Color JOB_REPORT_COMPLETE_COLOR = new Color(0.4117f, 0.847f, 0.4117f);

		public static readonly Color TRACK_COLOR = new Color(0.808f, 0.808f, 0.808f);

		public const float JOB_VALUE_FORMAT_CONST = 1000000f;

		private const string PICK_UP_DROP_OFF_EASY_COLOR_HEX = "#3B7826";

		private const string PICK_UP_DROP_OFF_MEDIUM_COLOR_HEX = "#B3843A";

		private const string PICK_UP_DROP_OFF_HARD_COLOR_HEX = "#B63936";

		public static readonly ResourceType[] ENVIRONMENT_DAMAGE_TYPES_LOCO = new ResourceType[2]
		{
			ResourceType.EnvironmentDamageFuel,
			ResourceType.EnvironmentDamageCoal
		};

		public static readonly ResourceType[] ENVIRONMENT_DAMAGE_TYPES_CARGO = new ResourceType[1] { ResourceType.EnvironmentDamageCargo };

		public static string LOCO_SUMMARY_ASSESSMENT_LEVEL_1 => LocalizationAPI.L("job/loco_summary_assessment_level_1");

		public static string LOCO_SUMMARY_ASSESSMENT_LEVEL_2 => LocalizationAPI.L("job/loco_summary_assessment_level_2");

		public static string LOCO_SUMMARY_ASSESSMENT_LEVEL_3 => LocalizationAPI.L("job/loco_summary_assessment_level_3");

		public static string LOCO_SUMMARY_ASSESSMENT_LEVEL_4 => LocalizationAPI.L("job/loco_summary_assessment_level_4");

		public static string LOCO_SUMMARY_ASSESSMENT_LEVEL_5 => LocalizationAPI.L("job/loco_summary_assessment_level_5");

		public static string JOB_CARS_SUMMARY_ASSESSMENT_NO_DAMAGE => LocalizationAPI.L("job/job_cars_summary_assessment_no_damage");

		public static string JOB_CARS_SUMMARY_ASSESSMENT_LEVEL_1 => LocalizationAPI.L("job/job_cars_summary_assessment_level_1");

		public static string JOB_CARS_SUMMARY_ASSESSMENT_LEVEL_2 => LocalizationAPI.L("job/job_cars_summary_assessment_level_2");

		public static string JOB_CARS_SUMMARY_ASSESSMENT_LEVEL_3 => LocalizationAPI.L("job/job_cars_summary_assessment_level_3");

		public static string JOB_CARS_SUMMARY_ASSESSMENT_LEVEL_4 => LocalizationAPI.L("job/job_cars_summary_assessment_level_4");

		public static string JOB_CARS_SUMMARY_ASSESSMENT_LEVEL_5 => LocalizationAPI.L("job/job_cars_summary_assessment_level_5");

		public static string HAUL_JOB_TYPE_NAME => LocalizationAPI.L("job/haul_job_type_name");

		public static string SHUNTING_JOB_TYPE_NAME => LocalizationAPI.L("job/shunting_job_type_name");

		public static string EMPTY_HAUL_JOB_TYPE_NAME => LocalizationAPI.L("job/empty_haul_job_type_name");

		public static string NO_BONUS_TIME_LIMIT_STR => LocalizationAPI.L("job/no_bonus");

		public static string GetColoredTMPText(string text, string colorHexValue)
		{
			return $"<color={colorHexValue}>{text}</color>";
		}

		public static string GetJobDescription(Job_data job, List<CargoType> differentCargoTypes = null)
		{
			string result = "";
			switch (job.type)
			{
			case JobType.ShuntingLoad:
			{
				string firstParamValue3 = CargoTypesToString(differentCargoTypes);
				result = LocalizationAPI.L("job/desc_shunting_load", firstParamValue3);
				break;
			}
			case JobType.Transport:
			{
				string firstParamValue2 = CargoTypesToString(differentCargoTypes);
				result = LocalizationAPI.L("job/desc_transport", firstParamValue2);
				break;
			}
			case JobType.ShuntingUnload:
			{
				string firstParamValue = CargoTypesToString(differentCargoTypes);
				result = LocalizationAPI.L("job/desc_shunting_unload", firstParamValue);
				break;
			}
			case JobType.EmptyHaul:
				result = LocalizationAPI.L("job/desc_empty_haul");
				break;
			default:
				Debug.LogError(string.Format("Unexpected job type '{0}' in {1}", job.type, "GetJobDescription"));
				break;
			}
			return result;
		}

		public static float GetTrainValue(List<Car_data> cars, List<CargoType> cargoTypes)
		{
			float num = 0f;
			if (cars != null)
			{
				foreach (Car_data car in cars)
				{
					if (!(car.type == null))
					{
						num += car.type.parentType.damage.bodyPrice;
					}
				}
			}
			if (cargoTypes != null)
			{
				foreach (CargoType cargoType in cargoTypes)
				{
					CargoType_v2 cargoType_v = cargoType.ToV2();
					if (!(cargoType_v == null))
					{
						num += cargoType_v.fullDamagePrice;
						num += cargoType_v.environmentDamagePrice;
					}
				}
			}
			return num;
		}

		private static string CargoTypesToString(List<CargoType> cargoTypes)
		{
			if (cargoTypes == null || cargoTypes.Count == 0)
			{
				Debug.LogError("cargoTypes were not initialized, so we couldn't extract appropriate string. Returning empty string!");
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder();
			if (cargoTypes.Count == 1)
			{
				string value = LocalizationAPI.L(cargoTypes[0].ToV2().localizationKeyFull);
				stringBuilder.Append(value);
			}
			else
			{
				for (int i = 0; i < cargoTypes.Count; i++)
				{
					string firstParamValue = LocalizationAPI.L(cargoTypes[i].ToV2().localizationKeyFull);
					if (i == cargoTypes.Count - 1)
					{
						stringBuilder.Append(LocalizationAPI.L("symbol/and", firstParamValue));
					}
					else if (i == cargoTypes.Count - 2)
					{
						stringBuilder.Append(LocalizationAPI.L("symbol/second_to_last_enumeration", firstParamValue));
					}
					else
					{
						stringBuilder.Append(LocalizationAPI.L("symbol/comma", firstParamValue));
					}
				}
			}
			return stringBuilder.ToString();
		}

		public static string GetShuntingPickUpsText(int numberOfStartTracks)
		{
			return GetColoredTMPText(colorHexValue: (numberOfStartTracks >= 3) ? "#B63936" : ((numberOfStartTracks < 2) ? "#3B7826" : "#B3843A"), text: LocalizationAPI.L("job/shunting_pick_ups", numberOfStartTracks.ToString()));
		}

		public static string GetShuntingDropOffsText(int numberOfDestinationTracks)
		{
			return GetColoredTMPText(colorHexValue: (numberOfDestinationTracks >= 3) ? "#B63936" : ((numberOfDestinationTracks < 2) ? "#3B7826" : "#B3843A"), text: LocalizationAPI.L("job/shunting_drop_offs", numberOfDestinationTracks.ToString()));
		}

		public static float GetCarsTotalLength(List<Car_data> cars)
		{
			if (cars == null)
			{
				Debug.LogError("cars can't be null, returning 0 length!");
				return 0f;
			}
			float num = 0f;
			for (int i = 0; i < cars.Count; i++)
			{
				num += cars[i].length;
			}
			return num;
		}

		public static float GetCarsTotalMass(List<Car_data> cars, List<CargoType> cargoPerCar = null)
		{
			if (cars == null)
			{
				Debug.LogError("cars can't be null, returning 0 mass!");
				return 0f;
			}
			float num = 0f;
			for (int i = 0; i < cars.Count; i++)
			{
				num += cars[i].carOnlyMass;
			}
			if (cargoPerCar != null)
			{
				if (cars.Count == cargoPerCar.Count)
				{
					for (int j = 0; j < cargoPerCar.Count; j++)
					{
						CargoType_v2 cargoType_v = cargoPerCar[j].ToV2();
						if (!(cargoType_v == null))
						{
							num += cars[j].capacity * cargoType_v.massPerUnit;
						}
					}
				}
				else
				{
					Debug.LogError("Number of cars and cargoPerCar is not matching! Ignoring cargo mass.");
				}
			}
			return num;
		}
	}
}
