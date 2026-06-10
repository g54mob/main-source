using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.Views.Resources
{
	public class EquipmentPileView : ResourcePileView
	{
		[SerializeField]
		private MaterialMeshParameters materialMeshParameters;

		[NonSerialized]
		private Equipment item;

		public Equipment Item => item;

		public override void Setup(ResourcePileInstance resourcePileInstance)
		{
			base.Setup(resourcePileInstance);
			item = Repository<EquipmentRepository, Equipment>.Instance.GetByID(resourcePileInstance.BlueprintId);
			ApplyMaterialMeshParameters(resourcePileInstance);
		}

		private void ApplyMaterialMeshParameters(ResourcePileInstance resource)
		{
			if (materialMeshParameters == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(65, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\View\\Resources\\EquipmentPileView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(base.gameObject.name);
					messageBuilder.AppendLiteral(" is either missing reference to or script: MaterialMeshParameters");
				}
				Log.Error(messageBuilder);
			}
			materialMeshParameters = GetComponent<MaterialMeshParameters>();
			if (!(materialMeshParameters == null))
			{
				materialMeshParameters.UpdateParameters(resource.Blueprint.Material);
			}
		}

		public override InfoPanelData GetInfoPanelData()
		{
			string blueprintId = base.ResourcePileInstance.BlueprintId;
			InfoPanelHeader headerData = GetHeaderData();
			InfoPanelBody body = new InfoPanelBody(blueprintId + "_pile", ResourceUtils.GetLocalizedResourcePileName(base.ResourcePileInstance.Blueprint.GetID()), EquipmentUtils.GetLocalizedMaterialEntry(EquipmentUtils.GetEquipmentFromResource(base.ResourcePileInstance.Blueprint)), GetInfoStats(), GetModifiers(), GetResourcesInfo(), GetDescriptions(), GetInfos(), GetEquipmentStats(), DecayModifierUtils.GetDecayModifiers(base.ResourcePileInstance));
			InfoPanelFooter footer = new InfoPanelFooter(GetInfoPanelActions());
			return new InfoPanelData(InfoPanelDataType.General, headerData, body, footer);
		}

		protected override string GetResourceName()
		{
			return ResourceUtils.GetLocalizedResourceName(base.ResourcePileInstance.Blueprint);
		}

		protected override List<string> GetModifiers()
		{
			List<string> modifiers = base.GetModifiers();
			string skillLevelsLocalized = EquipmentUtils.GetSkillLevelsLocalized(Item);
			if (!string.IsNullOrEmpty(skillLevelsLocalized))
			{
				modifiers.Insert(0, string.Empty);
				modifiers.Insert(0, skillLevelsLocalized);
			}
			return modifiers;
		}

		protected override List<string> GetInfos()
		{
			Equipment equipmentFromResource = EquipmentUtils.GetEquipmentFromResource(base.ResourcePileInstance.Blueprint);
			List<string> list = new List<string>();
			list.AddIfNotNull(string.Format("{0}: <style=AltColor>{1}, {2}, {3}</style>", MonoSingleton<LocalizationController>.Instance.GetText("global_position"), base.ResourcePileInstance.WorldPosition.x, base.ResourcePileInstance.WorldPosition.y, base.ResourcePileInstance.WorldPosition.z), base.ResourcePileInstance.WorldPosition);
			list.AddRange(ResourceUtils.GetGeneralInfoLines(base.ResourcePileInstance.Blueprint));
			list.Add(EquipmentUtils.GetLocalizedMaterialEntry(equipmentFromResource));
			list.AddIfNotNullOrEmpty(EquipmentUtils.GetLocalizedIsTwoHanded(equipmentFromResource));
			list.AddIfNotNullOrEmpty(GetProducer());
			List<string> list2 = EquipmentUtils.GetQualitySpecificInfos(equipmentFromResource).ToList();
			list.Add(list2[0] + " " + UiUtils.GetLocalizedAlmanacLink("system_equipment_quality_name"));
			list2.RemoveAt(0);
			list.AddRange(list2);
			return list;
		}

		private List<InfoEquipmentStat> GetEquipmentStats()
		{
			List<InfoEquipmentStat> list = new List<InfoEquipmentStat>();
			if (base.ResourcePileInstance == null || base.ResourcePileInstance.HasDisposed || base.Health == null)
			{
				return list;
			}
			if (Item.PrimaryDamage > 0f)
			{
				float primaryDamage = Item.PrimaryDamage;
				float primaryAttackSpeed = Item.PrimaryAttackSpeed;
				float num = primaryDamage / primaryAttackSpeed;
				list.Add(new InfoEquipmentStat("damage", "damage_icon", string.Format("<style=AltColor>{0:0.00} {1}</style>", num, MonoSingleton<LocalizationController>.Instance.GetText("damage_per_second_ab")), string.Format("{0} ({1}) / {2} ({3:0.00}s)= {4:0.00}{5}", MonoSingleton<LocalizationController>.Instance.GetText("general_damage"), primaryDamage, MonoSingleton<LocalizationController>.Instance.GetText("attack_duration"), primaryAttackSpeed, num, MonoSingleton<LocalizationController>.Instance.GetText("damage_per_second_ab"))));
			}
			if (Item.PrimaryRange > 2f)
			{
				list.Add(new InfoEquipmentStat("precision", "precision_icon", $"<style=AltColor>{Item.PrimaryPrecision * 100f}%</style>", MonoSingleton<LocalizationController>.Instance.GetText("precision")));
				list.Add(new InfoEquipmentStat("range", "range_icon", $"<style=AltColor>{Item.PrimaryRange + 1f}m</style>", MonoSingleton<LocalizationController>.Instance.GetText("range")));
			}
			if (Item.WarmthModifier.Max != 0f)
			{
				TemperatureUnitsType temperatureUnits = MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.TemperatureUnits;
				int num2 = (int)WorldDate.ConvertCelsiusTemperature(Item.WarmthModifier.Min, temperatureUnits);
				int num3 = (int)WorldDate.ConvertCelsiusTemperature(Item.WarmthModifier.Max, temperatureUnits);
				list.Add(new InfoEquipmentStat("temperature_min", "temperature_min_icon", $"<style=AltColor>{num2}{MonoSingleton<LocalizationController>.Instance.GetText($"general_symbol_{temperatureUnits}")}</style>", MonoSingleton<LocalizationController>.Instance.GetText("general_min_temperature")));
				list.Add(new InfoEquipmentStat("temperature_max", "temperature_max_icon", $"<style=AltColor>{num3}{MonoSingleton<LocalizationController>.Instance.GetText($"general_symbol_{temperatureUnits}")}</style>", MonoSingleton<LocalizationController>.Instance.GetText("general_max_temperature")));
			}
			if (Item.ArmorRating > 0f)
			{
				float num4 = base.ResourcePileInstance?.GetTotalDurability() ?? Item.ArmorRating;
				float current = base.Health.Current;
				float max = base.Health.Max;
				float num5 = base.Health.Current / base.Health.Max;
				float num6 = num5 * num4;
				list.Add(new InfoEquipmentStat("armor_rating", "body_armor_icon", $"<style=AltColor>{num6:P2}</style>", string.Format("{0} ({1:P2} ( {2:F0} / {3:F0}) ) * ", MonoSingleton<LocalizationController>.Instance.GetText("armor_hitpoints_percentage"), num5, current, max) + string.Format("{0} ({1:P2}) = {2:P2}", MonoSingleton<LocalizationController>.Instance.GetText("armor_rating"), num4, num6)));
			}
			if (Item.GetCoverChance(DamageType.Melee) > 0f)
			{
				list.Add(new InfoEquipmentStat("melee_cover", "melee_cover_icon", $"<style=AltColor>{Item.GetCoverChance(DamageType.Melee) * 100f}%</style>", MonoSingleton<LocalizationController>.Instance.GetText("melee_cover_amount")));
			}
			if (Item.GetCoverChance(DamageType.Ranged) > 0f)
			{
				list.Add(new InfoEquipmentStat("ranged_cover", "ranged_cover_icon", $"<style=AltColor>{Item.GetCoverChance(DamageType.Ranged) * 100f}%</style>", MonoSingleton<LocalizationController>.Instance.GetText("ranged_cover_amount")));
			}
			return list;
		}

		private string GetColor(float value)
		{
			return "<color=#" + ColorUtility.ToHtmlStringRGB((value < 0f) ? new Color(1f, 0.2f, 0.2f) : new Color(0.2f, 1f, 0.2f)) + ">" + ((value < 0f) ? string.Empty : "+");
		}
	}
}
