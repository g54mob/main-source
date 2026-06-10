using System;
using NSEipix.Base;
using NSEipix.Model;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.UI
{
	public class EnemyInventoryExtraPanel : SelectionExtraPanelBase
	{
		[SerializeField]
		private FillBarLayoutItemView massCarriedBar;

		[SerializeField]
		private FillBarLayoutItemView storageLabel;

		[SerializeField]
		private FillBarLayoutItemView storageValue;

		[SerializeField]
		private LayoutGroupItemView[] stats;

		[SerializeField]
		private EquipmentSlotLayoutItemView[] inventoryItems;

		protected override void SetupTabPanel()
		{
			UpdateTabPanel();
		}

		protected override void UpdateTabPanel()
		{
			if (base.Humanoid != null && !base.Humanoid.HasDisposed)
			{
				CreateStats();
				CreateInventory();
			}
		}

		private void CreateStats()
		{
			stats[0].SetText($"{(int)(CombatCalculator.CalculateTotalArmorRating(base.Humanoid, EquipmentSlotType.Head) * 100f)}%");
			SetTooltip(stats[0].TooltipNew, base.Localize.GetText("head_armor"), GetArmorFormula(EquipmentSlotType.Head));
			stats[1].SetText($"{(int)(CombatCalculator.CalculateTotalArmorRating(base.Humanoid, EquipmentSlotType.BodyArmor) * 100f)}%");
			SetTooltip(stats[1].TooltipNew, base.Localize.GetText("body_armor"), GetArmorFormula(EquipmentSlotType.BodyArmor));
			float num = CombatCalculator.CalculateBaseDamage(base.Humanoid, null);
			float num2 = CombatCalculator.CalculateAttackSpeed(base.Humanoid);
			float num3 = num / num2;
			stats[2].SetText(string.Format("{0:F1} {1}", num3, base.Localize.GetText("damage_per_second_ab")));
			SetTooltip(stats[2].TooltipNew, base.Localize.GetText("damage_per_second"), GetDpsFormula());
			stats[3].SetText($"{(int)(CombatCalculator.CalculateHitChance(base.Humanoid) * 100f)}%");
			SetTooltip(stats[3].TooltipNew, base.Localize.GetText("precision"), GetPrecisionFormula());
			stats[4].SetText(string.Format("{0}{1}", Math.Round(CombatCalculator.CalculateAttackRange(base.Humanoid), 2), base.Localize.GetText("unit_suffix_meter")));
			SetTooltip(stats[4].TooltipNew, base.Localize.GetText("range"), GetRangeFormula());
			TemperatureUnitsType temperatureUnits = MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.TemperatureUnits;
			FloatRange warmthModifiers = base.Humanoid.WarmthInstance.GetWarmthModifiers();
			int num4 = (int)WorldDate.ConvertCelsiusTemperature((float)(base.Humanoid.CurrentHumanType.Warmth.ColdThresholds[0].Trigger + 1) + warmthModifiers.Min, temperatureUnits);
			int num5 = (int)WorldDate.ConvertCelsiusTemperature((float)(base.Humanoid.CurrentHumanType.Warmth.HotTresholds[0].Trigger - 1) + warmthModifiers.Max, temperatureUnits);
			stats[5].SetText(string.Format("{0}{1} {2} {3}{4}", num4, base.Localize.GetText($"general_symbol_{temperatureUnits}"), base.Localize.GetText("general_to"), num5, base.Localize.GetText($"general_symbol_{temperatureUnits}")));
			SetTooltip(stats[5].TooltipNew, base.Localize.GetText("general_temperature"), WorkerInventoryExtraPanel.GetTemperatureFormula(base.Humanoid, num4, num5));
		}

		private string GetRangeFormula()
		{
			float weaponRange = CombatCalculator.GetWeaponRange(base.Humanoid);
			double num = Math.Round(CombatCalculator.CalculateAttackRange(base.Humanoid), 2);
			float value = base.Humanoid.Stats.Attributes[AttributeType.RangedRange].Value;
			if (CombatCalculator.IsWeaponRanged(base.Humanoid))
			{
				return string.Format("({0} <style=AltColor>{1}m</style> + ", base.Localize.GetText("range"), weaponRange) + string.Format("{0} <style=AltColor>{1}m</style>) * ", base.Localize.GetText("base_range"), CombatConstants.BaseRange) + string.Format("{0} <style=AltColor>{1}m</style> = ", base.Localize.GetText("atb_name_RangedRange"), value) + $"<style=AltColor>{num}</style> ";
			}
			return string.Format("{0} <style=AltColor>{1}m</style> + ", base.Localize.GetText("range"), weaponRange) + string.Format("{0} <style=AltColor>{1}m</style> = ", base.Localize.GetText("base_range"), CombatConstants.BaseRange) + $"<style=AltColor>{num}m</style>";
		}

		private string GetPrecisionFormula()
		{
			float weaponPrecision = CombatCalculator.GetWeaponPrecision(base.Humanoid);
			float num = CombatCalculator.CalculatePercisionFallof(base.Humanoid, null);
			if (CombatCalculator.IsWeaponRanged(base.Humanoid))
			{
				return base.Localize.GetText("precision") + " (<style=AltColor>100</style>) * " + string.Format("{0} (<style=AltColor>{1:F}</style>) = ", base.Localize.GetText("atb_name_RangedChance"), weaponPrecision) + $"<style=AltColor>{(int)(CombatCalculator.CalculateHitChance(base.Humanoid) * 100f)}</style>\n" + string.Format("{0}: <style=AltColor>{1}%/m</style>", base.Localize.GetText("precision_falloff"), num);
			}
			return base.Localize.GetText("precision") + " (<style=AltColor>100</style>) * " + string.Format("{0} (<style=AltColor>{1:F2}</style>) = ", base.Localize.GetText("atb_name_MeleeChance"), weaponPrecision) + $"<style=AltColor>{(int)(CombatCalculator.CalculateHitChance(base.Humanoid) * 100f)}</style>";
		}

		private string GetDpsFormula()
		{
			float num = CombatCalculator.CalculateBaseDamage(base.Humanoid, null);
			float num2 = CombatCalculator.CalculateAttackSpeed(base.Humanoid);
			float num3 = num / num2;
			EquipmentInstance weapon = CombatUtils.GetWeapon(base.Humanoid);
			if (weapon == null)
			{
				return string.Format("{0} (<style=AltColor>{1:F1}</style>) / ", base.Localize.GetText("atb_name_UnarmedDamage"), num) + string.Format("{0} (<style=AltColor>{1:F1}</style>) = ", base.Localize.GetText("atb_name_UnarmedSpeed"), num2) + string.Format("<style=AltColor>{0:F1}{1}</style>", num3, base.Localize.GetText("damage_per_second_ab"));
			}
			_ = weapon.Blueprint;
			float num4 = CombatCalculator.CalculateAttributeValues(weapon.WeaponTypeSettings.Damage, base.Humanoid);
			float num5 = CombatCalculator.CalculateAttributeValues(weapon.WeaponTypeSettings.AttackSpeed, base.Humanoid);
			if (weapon.WeaponTypeSettings.AttackType == AttackType.Melee)
			{
				return string.Format("{0} (<style=AltColor>{1:F1}</style>) * ", base.Localize.GetText("base_damage"), weapon.Damage) + string.Format("{0} (<style=AltColor>{1:F1}</style>) / ", base.Localize.GetText("atb_name_MeleeDmg"), num4) + string.Format("{0} (<style=AltColor>{1:F1}</style>) * ", base.Localize.GetText("attack_duration"), num2) + string.Format("{0} (<style=AltColor>{1:F1}</style>) = ", base.Localize.GetText("atb_name_MeleeAttackSpeed"), num5) + string.Format("<style=AltColor>{0:F1}{1}</style>", num3, base.Localize.GetText("damage_per_second_ab"));
			}
			return string.Format("{0} (<style=AltColor>{1:F1}</style>) * ", base.Localize.GetText("base_damage"), weapon.Damage) + string.Format("{0} (<style=AltColor>{1:F1}</style>) / ", base.Localize.GetText("atb_name_RangedDmg"), num4) + string.Format("{0} (<style=AltColor>{1:F1}</style>) * ", base.Localize.GetText("attack_duration"), num2) + string.Format("{0} (<style=AltColor>{1:F1}) = ", base.Localize.GetText("atb_name_RangedSpeed"), num5) + string.Format("<style=AltColor>{0:F1}{1}</style>", num3, base.Localize.GetText("damage_per_second_ab"));
		}

		private string GetArmorFormula(EquipmentSlotType slotType)
		{
			EquipmentInstance equippedArmor = CombatCalculator.GetEquippedArmor(base.Humanoid, slotType);
			float num = CombatCalculator.CalculateTotalArmorRating(base.Humanoid, slotType);
			if (equippedArmor == null || equippedArmor.HasDisposed)
			{
				return base.Localize.GetText("armor_hitpoints_percentage") + " (<style=AltColor>0%</style>) * " + base.Localize.GetText("armor_rating") + " (<style=AltColor>0%</style>) = <style=AltColor>0%</style>";
			}
			StatInstance stat = equippedArmor.GetStat(StatType.Health);
			float num2 = Mathf.Floor(stat.Current / stat.Max * 100f);
			float num3 = equippedArmor.Blueprint.ArmorRating * 100f;
			return string.Format("{0} (<style=AltColor>{1}%</style>) * ", base.Localize.GetText("armor_hitpoints_percentage"), num2) + string.Format("{0} (<style=AltColor>{1}%</style>) = ", base.Localize.GetText("armor_rating"), num3) + $"<style=AltColor>{num:P2}</style>";
		}

		private void SetTooltip(TooltipViewNew tooltip, string title, string line)
		{
			tooltip.ClearLines();
			tooltip.AppendLine(title, TooltipStyles.TooltipTitle);
			tooltip.AppendLine(line, TooltipStyles.TooltipDefault);
		}

		private void CreateInventory()
		{
			int num = 0;
			foreach (EquipmentSlotType availableSlot in base.Humanoid.Inventory.AvailableSlots)
			{
				if (availableSlot == EquipmentSlotType.None)
				{
					continue;
				}
				EquipmentInstance item = base.Humanoid.Inventory.GetItem(availableSlot);
				EquipmentSlotLayoutItemView equipmentSlotLayoutItemView = inventoryItems[num++];
				equipmentSlotLayoutItemView.gameObject.SetActive(value: true);
				equipmentSlotLayoutItemView.SetImageData(availableSlot.ToString().ToLower(), availableSlot.ToString().ToLower());
				string text;
				if (base.Humanoid.Inventory.IsSlotBlocked(availableSlot) || item == null)
				{
					text = ((item == null) ? "empty" : "blocked");
					equipmentSlotLayoutItemView.SetText(equipmentSlotLayoutItemView.TextIndex, base.Localize.GetText("general_" + text));
				}
				else
				{
					equipmentSlotLayoutItemView.SetTextData(item.Id, ResourceUtils.GetLocalizedResourceName(item.Blueprint.Resource));
					text = item.Id;
				}
				if (!text.Equals("empty"))
				{
					equipmentSlotLayoutItemView.IconItemView.gameObject.SetActive(value: true);
					equipmentSlotLayoutItemView.SetImageData(item.Blueprint.GetID());
					if (equipmentSlotLayoutItemView.IconItemView.TooltipNew is EquipmentTooltipView equipmentTooltipView)
					{
						equipmentTooltipView.SetupData(item, null);
					}
				}
				else
				{
					equipmentSlotLayoutItemView.IconItemView.gameObject.SetActive(value: false);
				}
			}
			for (int i = num; i < inventoryItems.Length; i++)
			{
				inventoryItems[i].gameObject.SetActive(value: false);
			}
		}
	}
}
