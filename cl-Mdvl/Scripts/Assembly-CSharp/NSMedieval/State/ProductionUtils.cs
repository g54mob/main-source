using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Model;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Extensions;
using NSMedieval.GameEventSystem;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.RoomDetection;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.State
{
	public static class ProductionUtils
	{
		public static IntRange DefaultQualityRange { get; } = new IntRange(1, (int)EnumValues.ProductionQualities[^1]);

		public static bool CanAnyWorkerDoThisProduction(ProductionInstance instance)
		{
			NSMedieval.Model.Production blueprint = instance.Blueprint;
			if (blueprint?.RequiredSkills == null)
			{
				return true;
			}
			return WorkerManager.GetMaxSkillLevel(blueprint.RequiredSkills[0].Key, instance.Blueprint.JobType) >= blueprint.RequiredSkills[0].Value;
		}

		public static bool CanAnyWorkerDoThisProductionRefactored(ProductionInstance instance)
		{
			if (instance == null)
			{
				return false;
			}
			NSMedieval.Model.Production blueprint = instance.Blueprint;
			foreach (HumanoidInstance worker in GlobalSaveController.CurrentVillageData.Workers)
			{
				SkillLevelPair skillLevelPair = blueprint?.RequiredSkills?[0];
				if (skillLevelPair == null)
				{
					return true;
				}
				SkillType key = skillLevelPair.Key;
				float num = skillLevelPair.Value;
				if ((float)worker.GetSkillLevel(key) >= num)
				{
					return true;
				}
			}
			return false;
		}

		public static float CalculateProductionSpeedMultiplier(ProductionComponentInstance productionComponentInstance)
		{
			ProductionComponentBlueprint blueprint = productionComponentInstance.Blueprint;
			ProductionSpeedMultiplier productionSpeedMultiplier = blueprint.ProductionSpeedMultiplier;
			if (productionSpeedMultiplier == null || productionComponentInstance.Map?.TemperatureManager == null)
			{
				return 1f;
			}
			Vec3Int gridDataPosition = productionComponentInstance.GridDataPosition;
			GetEnvironmentForProduction(productionComponentInstance.GetNode(), out var isRoofed, out var isInRoom, out var isRain, out var isFog, out var isSnow, out var room);
			float num = 1f;
			if (isInRoom)
			{
				num = ((room.RoomType != null) ? room.RoomType.GetProductionSpeedMultiplier(productionComponentInstance.ComponentBlueprintID) : 1f);
			}
			productionComponentInstance.TryScheduleCalculateSkepProductionMultiplier();
			float skepMultiplier = productionComponentInstance.GetSkepMultiplier();
			Season season = GlobalSaveController.CurrentVillageData.DateAndTime.Season;
			float temperature = productionComponentInstance.Map.TemperatureManager.GetTemperature(gridDataPosition);
			float speedMultiplierForTemperature = blueprint.GetSpeedMultiplierForTemperature(temperature, season);
			speedMultiplierForTemperature *= num * productionSpeedMultiplier.Get(isRoofed, isInRoom, isRain, isFog, isSnow);
			if (!skepMultiplier.IsCloseToZero())
			{
				speedMultiplierForTemperature *= skepMultiplier;
			}
			return speedMultiplierForTemperature;
		}

		public static List<string> GetProductionInfo(ProductionComponentInstance componentInstance)
		{
			List<string> list = new List<string>();
			float num = CalculateProductionSpeedMultiplier(componentInstance);
			string text = UiUtils.FormatPositiveNegative((num * 100f).ToString("F1") + "%", num, 1f, invert: false, addPlusSign: false);
			list.Add(MonoSingleton<LocalizationController>.Instance.GetText("production_speed") + ": " + text);
			string productionCircumstances = GetProductionCircumstances(componentInstance);
			list.Add(productionCircumstances);
			if (CalculateProductionSpeedMultiplier(componentInstance) < 0f)
			{
				list.Add(MonoSingleton<LocalizationController>.Instance.GetText("no_active_productions"));
			}
			return list;
		}

		public static void GetEnvironmentForProduction(MapNode node, out bool isRoofed, out bool isInRoom, out bool isRain, out bool isFog, out bool isSnow, out Room room)
		{
			isRoofed = node.Coverage == CoverageType.Roofed;
			room = node.Map.RoomDetection.GetRoom(node);
			isInRoom = room != null;
			isRain = MonoSingleton<WeatherManager>.Instance.IsEventRunning("rain") || MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.Instance.IsEventRunning("game_event_thunderstorm") || MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.Instance.IsEventRunning("game_event_hailstorm");
			isFog = MonoSingleton<WeatherManager>.Instance.IsEventRunning("fog");
			isSnow = MonoSingleton<WeatherManager>.Instance.IsEventRunning("snow");
		}

		public static string GetProductionCircumstances(ProductionComponentInstance componentInstance)
		{
			if (componentInstance.OwnerBuilding?.Map?.TemperatureManager == null)
			{
				return string.Empty;
			}
			GetEnvironmentForProduction(componentInstance.OwnerBuilding.GetNode(), out var isRoofed, out var isInRoom, out var isRain, out var isFog, out var isSnow, out var room);
			ProductionSpeedMultiplier productionSpeedMultiplier = componentInstance?.Blueprint?.ProductionSpeedMultiplier;
			string text;
			if (!isInRoom || room == null)
			{
				text = (isRoofed ? (MonoSingleton<LocalizationController>.Instance.GetText("roofed") + " (" + UiUtils.GetColoredPercentStr(productionSpeedMultiplier?.Roofed) + ")") : (isRain ? (MonoSingleton<LocalizationController>.Instance.GetText("outsideRain") + " (" + UiUtils.GetColoredPercentStr(productionSpeedMultiplier?.OutsideRaid) + ")") : (isFog ? (MonoSingleton<LocalizationController>.Instance.GetText("outsideFog") + " (" + UiUtils.GetColoredPercentStr(productionSpeedMultiplier?.OutsideFog) + ")") : ((!isSnow) ? (MonoSingleton<LocalizationController>.Instance.GetText("outside") + " (" + UiUtils.GetColoredPercentStr(productionSpeedMultiplier?.Outside) + ")") : (MonoSingleton<LocalizationController>.Instance.GetText("outsideSnow") + " (" + UiUtils.GetColoredPercentStr(productionSpeedMultiplier?.OutsideSnow) + ")")))));
			}
			else
			{
				float num = ((room.RoomType != null) ? room.RoomType.GetProductionSpeedMultiplier(componentInstance.OwnerBuilding.Blueprint.GetID()) : 1f);
				string text2 = string.Empty;
				if (Mathf.Abs(num - 1f) > 0.0001f)
				{
					text2 = "(" + MonoSingleton<LocalizationController>.Instance.GetText("room_speed_multiplier_bonus") + " " + UiUtils.GetColoredPercentStr(num) + ")";
				}
				string text3 = MonoSingleton<LocalizationController>.Instance.GetText("inside");
				text = text3 + " (" + UiUtils.GetColoredPercentStr(productionSpeedMultiplier?.Inside) + ")";
				string text4 = ColorUtility.ToHtmlStringRGB((room.RoomType != null) ? room.RoomType.Color : Color.white);
				text = text + "\n" + text3 + ": <color=#" + text4 + "><link=\"select_room\"><style=LinkRoom>" + room.GetRoomTypeLocalized() + " (" + room.Impressiveness?.NameLocalized + ")</style></link></color> " + text2;
			}
			float temperature = componentInstance.OwnerBuilding.Map.TemperatureManager.GetTemperature(componentInstance.OwnerBuilding.GridDataPosition);
			Season season = GlobalSaveController.CurrentVillageData.DateAndTime.Season;
			float num2 = componentInstance?.Blueprint?.GetSpeedMultiplierForTemperature(temperature, season) ?? 1f;
			if (Math.Abs(num2 - 1f) > 1E-05f)
			{
				text = text + (string.IsNullOrEmpty(text) ? string.Empty : "\n") + MonoSingleton<LocalizationController>.Instance.GetText("info_temperature") + " (" + UiUtils.GetColoredPercentStr(num2) + ")";
			}
			if (componentInstance.Blueprint == null)
			{
				return text;
			}
			componentInstance.TryScheduleCalculateSkepProductionMultiplier();
			if (componentInstance.GetSkepMultiplier().IsCloseToZero())
			{
				return text;
			}
			SkepProductionMultiplierData skepMultiplierData = componentInstance.SkepMultiplierData;
			string text5 = UiUtils.FormatPositiveNeutralNegative($"{skepMultiplierData.PlantsCount}", skepMultiplierData.PlantsCount, 50f, 80f, addPlusSign: false);
			string text6 = UiUtils.FormatPositiveNeutralNegative($"{skepMultiplierData.TotalPlantBonus * 100f:F1}%", skepMultiplierData.PlantsCount, 50f, 80f);
			text = text + "\n" + text5 + " " + MonoSingleton<LocalizationController>.Instance.GetText("plants_around_skep") + " (" + text6 + ")";
			if (componentInstance.SkepMultiplierData.SkepCount > 0)
			{
				string text7 = UiUtils.FormatPositiveNegative($"{skepMultiplierData.SkepCount}", skepMultiplierData.SkepCount, 0.5f, invert: true, addPlusSign: false);
				string text8 = UiUtils.FormatPositiveNegative($"{skepMultiplierData.TotalSkepPenalty * 100f:F1}%", skepMultiplierData.SkepCount, 0.5f, invert: true, addPlusSign: false);
				text = text + "\n" + text7 + " " + MonoSingleton<LocalizationController>.Instance.GetText("skeps_around_skep") + " (" + text8 + ")";
			}
			return text;
		}
	}
}
