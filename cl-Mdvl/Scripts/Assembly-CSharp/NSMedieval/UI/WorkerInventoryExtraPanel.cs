using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSMedieval.Components;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class WorkerInventoryExtraPanel : SelectionExtraPanelBase
	{
		protected static readonly StringBuilder StringBuilder = new StringBuilder();

		[SerializeField]
		private FillBarLayoutItemView massCarriedBar;

		[SerializeField]
		private FillBarLayoutItemView storageValue;

		[SerializeField]
		private LayoutGroupItemView[] stats;

		[SerializeField]
		private EquipmentSlotLayoutItemView[] inventoryItems;

		[SerializeField]
		private LayoutGroupView foodPouchEntriesParent;

		[SerializeField]
		private List<FoodStorageItemView> foodStorageEntries = new List<FoodStorageItemView>();

		[SerializeField]
		private LayoutGroupView medicinePouchEntriesParent;

		[SerializeField]
		private List<MedicineStorageItemView> medicineStorageEntries = new List<MedicineStorageItemView>();

		protected override void SetupTabPanel()
		{
			base.Humanoid.Storage.ResourceAddedEvent += StorageUpdated;
			base.Humanoid.Storage.ResourceTakenEvent += StorageUpdated;
			base.Humanoid.FoodStorage.ResourceAddedEvent += OnFoodStorageUpdated;
			base.Humanoid.FoodStorage.ResourceTakenEvent += OnFoodStorageUpdated;
			base.Humanoid.MedicineStorage.ResourceAddedEvent += OnMedicineStorageUpdated;
			base.Humanoid.MedicineStorage.ResourceTakenEvent += OnMedicineStorageUpdated;
			StorageUpdated(default(SimpleResourceCount));
			UpdateTabPanel();
			UpdateFoodStorage();
			UpdateMedicineStorage();
		}

		private void OnFoodStorageUpdated(SimpleResourceCount count)
		{
			if (base.CreatureBase != null && !base.CreatureBase.IsInIncognitoMode())
			{
				UpdateFoodStorage();
			}
		}

		private void OnMedicineStorageUpdated(SimpleResourceCount count)
		{
			if (base.CreatureBase != null && !base.CreatureBase.IsInIncognitoMode())
			{
				UpdateMedicineStorage();
			}
		}

		public override void Hide()
		{
			if (base.Humanoid?.Storage != null)
			{
				base.Humanoid.Storage.ResourceAddedEvent -= StorageUpdated;
				base.Humanoid.Storage.ResourceTakenEvent -= StorageUpdated;
			}
			if (base.Humanoid?.FoodStorage != null)
			{
				base.Humanoid.FoodStorage.ResourceAddedEvent -= OnFoodStorageUpdated;
				base.Humanoid.FoodStorage.ResourceTakenEvent -= OnFoodStorageUpdated;
			}
			if (base.Humanoid?.MedicineStorage != null)
			{
				base.Humanoid.MedicineStorage.ResourceAddedEvent -= OnMedicineStorageUpdated;
				base.Humanoid.MedicineStorage.ResourceTakenEvent -= OnMedicineStorageUpdated;
			}
			base.Hide();
		}

		protected override void UpdateTabPanel()
		{
			CreateStats();
			CreateInventory();
			UpdateFoodStorage();
			UpdateMedicineStorage();
		}

		private void ForceRebuildLayout()
		{
			RectTransform component = GetComponent<RectTransform>();
			if (!(component == null))
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(component);
			}
		}

		private void UpdateFoodStorage()
		{
			if (base.CreatureBase?.FoodStorage?.Resources == null)
			{
				foodStorageEntries?.SetAllActive(active: false);
				foodPouchEntriesParent?.gameObject.SetActive(value: false);
				ForceRebuildLayout();
				return;
			}
			foodPouchEntriesParent.gameObject.SetActive(value: true);
			int num = 0;
			foreach (ResourceInstance resourceInstance in base.CreatureBase.FoodStorage.Resources)
			{
				if (resourceInstance != null && base.CreatureBase.ForceEatResource != resourceInstance)
				{
					FoodStorageItemView foodStorageItem = foodStorageEntries.GetAt(foodPouchEntriesParent, num);
					foodStorageItem.gameObject.SetActive(value: true);
					string resourceText = GetResourceText(resourceInstance, addName: true, addNutrition: false);
					string resourceText2 = GetResourceText(resourceInstance, addName: true, addNutrition: true);
					foodStorageItem.SetData(resourceText, resourceText2, delegate
					{
						OnFoodStorageDropClicked(resourceInstance);
					}, delegate
					{
						OnFoodStorageEatClicked(foodStorageItem, resourceInstance);
					});
					foodStorageItem.DropButton.interactable = true;
					foodStorageItem.EatButton.interactable = true;
					if (base.Humanoid?.WorkerBehaviour != null && base.Humanoid.WorkerBehaviour.IsBanished)
					{
						foodStorageItem.DropButton.interactable = false;
						foodStorageItem.EatButton.interactable = false;
					}
					num++;
				}
			}
			foodStorageEntries.SetActiveFromIndex(num, active: false);
			ForceRebuildLayout();
		}

		private void UpdateMedicineStorage()
		{
			if (base.CreatureBase?.MedicineStorage?.Resources == null)
			{
				medicineStorageEntries.SetAllActive(active: false);
				medicinePouchEntriesParent.gameObject.SetActive(value: false);
				ForceRebuildLayout();
				return;
			}
			medicinePouchEntriesParent.gameObject.SetActive(value: true);
			int num = 0;
			foreach (ResourceInstance resourceInstance in base.CreatureBase.MedicineStorage.Resources)
			{
				if (resourceInstance != null)
				{
					MedicineStorageItemView at = medicineStorageEntries.GetAt(medicinePouchEntriesParent, num);
					at.gameObject.SetActive(value: true);
					string resourceText = GetResourceText(resourceInstance, addName: true, addNutrition: false);
					string resourceText2 = GetResourceText(resourceInstance, addName: true, addNutrition: false);
					at.SetData(resourceText, resourceText2, delegate
					{
						OnMedicineStorageDropClicked(resourceInstance);
					});
					at.DropButton.interactable = true;
					if (base.Humanoid?.WorkerBehaviour != null && base.Humanoid.WorkerBehaviour.IsBanished)
					{
						at.DropButton.interactable = false;
					}
					num++;
				}
			}
			medicineStorageEntries.SetActiveFromIndex(num, active: false);
			ForceRebuildLayout();
		}

		private void OnFoodStorageDropClicked(ResourceInstance resourceInstance)
		{
			if (base.CreatureBase != null && resourceInstance != null)
			{
				base.CreatureBase.FoodStorage.DropResourceInstance(resourceInstance, base.CreatureBase.GetGridPosition());
				UpdateFoodStorage();
			}
		}

		private void OnFoodStorageEatClicked(FoodStorageItemView foodStorageItemView, ResourceInstance resourceInstance)
		{
			if (base.CreatureBase != null && resourceInstance != null)
			{
				base.CreatureBase.ForceEatResource = resourceInstance;
				base.CreatureBase.CombatAi?.Abort();
				if (base.CreatureBase is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance)
				{
					humanoidInstance.WorkerBehaviour.LastDraftOrder?.OnDraftEnd(humanoidInstance);
					((WorkerGoapAgent)humanoidInstance.GetGoapAgent())?.ForceNextGoalExclusive(null);
				}
				base.CreatureBase.GetGoapAgent().Abort();
				base.CreatureBase.GetGoapAgent().ForceNextGoal("HungerGoal");
				UpdateFoodStorage();
			}
		}

		private void OnMedicineStorageDropClicked(ResourceInstance resourceInstance)
		{
			if (base.CreatureBase != null && resourceInstance != null)
			{
				base.CreatureBase.MedicineStorage.DropResourceInstance(resourceInstance, base.CreatureBase.GetGridPosition());
				UpdateMedicineStorage();
			}
		}

		private void StorageUpdated(SimpleResourceCount count)
		{
			Storage storage = base.Humanoid.GetStorage();
			float resourceWeight = storage.GetResourceWeight();
			bool num = storage.IsOverweight();
			StringBuilder.Clear();
			if (num)
			{
				StringBuilder.Append("<style=DefaultRed>");
			}
			StringBuilder.Append(storage.GetResourceWeight());
			StringBuilder.Append("/");
			StringBuilder.Append(storage.StorageBase.Capacity);
			StringBuilder.Append(base.Localize.GetText("general_kg"));
			if (num)
			{
				StringBuilder.Append("</style>");
			}
			massCarriedBar.SetBasicData(base.Localize.GetText("mass_carried"), string.Empty, string.Empty, string.Empty, null, StatTrend.None, new List<float>
			{
				0f,
				base.Humanoid.GetStorage().StorageBase.Capacity,
				resourceWeight
			}, null, null, invertArrows: false, StringBuilder.ToString());
			int resourceCount = storage.ResourceCount;
			if (resourceCount == 1)
			{
				ResourceInstance resourceInstance = storage.Resources.FirstOrDefault((ResourceInstance item) => item.Amount > 0);
				if (resourceInstance == null || resourceInstance.Amount == 0)
				{
					storageValue.gameObject.SetActive(value: false);
					return;
				}
				storageValue.gameObject.SetActive(value: true);
				storageValue.SetText(GetResourceText(resourceInstance, addName: false, addNutrition: false));
				storageValue.TooltipNew.SetLines(ResourceUtils.GetTooltipData(resourceInstance.BlueprintId));
			}
			else if (resourceCount > 1 && storage.Resources.Any((ResourceInstance res) => res.Amount > 0))
			{
				storageValue.gameObject.SetActive(value: true);
				storageValue.SetText(string.Join(", ", GetResourcesList(storage.Resources, addName: false, addNutrition: false)));
				storageValue.TooltipNew.SetLines(GetResourcesList(storage.Resources, addName: true, addNutrition: true));
			}
			else
			{
				storageValue.gameObject.SetActive(value: false);
			}
		}

		private static string GetResourceText(ResourceInstance resourceInstance, bool addName, bool addNutrition)
		{
			string textIcon = ResourceUtils.GetTextIcon(resourceInstance.Blueprint);
			_ = resourceInstance.Blueprint.Nutrition;
			if (addName)
			{
				string text = ((!addNutrition) ? string.Empty : string.Format("({0}:  {1} x {2})", MonoSingleton<LocalizationController>.Instance.GetText("menu_nutrition"), resourceInstance.Amount, resourceInstance.Blueprint.Nutrition));
				string text2 = $"{textIcon} {ResourceUtils.GetLocalizedResourceName(resourceInstance.Blueprint)} x {resourceInstance.Amount}";
				if (addNutrition)
				{
					return text2 + " " + text;
				}
				return text2;
			}
			return $"{textIcon} x {resourceInstance.Amount}";
		}

		private static List<string> GetResourcesList(IEnumerable<ResourceInstance> resources, bool addName, bool addNutrition)
		{
			List<string> list = new List<string>();
			foreach (ResourceInstance resource in resources)
			{
				if (resource != null && resource.Amount != 0)
				{
					list.Add(GetResourceText(resource, addName, addNutrition));
				}
			}
			return list;
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
			SetTooltip(stats[5].TooltipNew, base.Localize.GetText("general_temperature"), GetTemperatureFormula(base.Humanoid, num4, num5));
		}

		public static string GetTemperatureFormula(HumanoidInstance humanoid, int tempMin, int tempMax)
		{
			int num = humanoid.CurrentHumanType.Warmth.ColdThresholds[0].Trigger + 1;
			int num2 = humanoid.CurrentHumanType.Warmth.HotTresholds[0].Trigger - 1;
			float minTemperatureFromEffector = humanoid.WarmthInstance.MinTemperatureFromEffector;
			float maxTemperatureFromEffector = humanoid.WarmthInstance.MaxTemperatureFromEffector;
			FloatRange clothesWarmthModifier = humanoid.WarmthInstance.GetClothesWarmthModifier();
			FloatRange capWarmthModifier = humanoid.WarmthInstance.GetCapWarmthModifier();
			LocalizationController instance = MonoSingleton<LocalizationController>.Instance;
			return "<b>" + instance.GetText("general_min_temperature") + ": </b>\n" + instance.GetText("general_base_value") + " (<style=AltColor>" + WorldDate.GetLocalizedTemperature((float)num + minTemperatureFromEffector) + "</style>) + " + instance.GetText("general_clothes") + " (<style=AltColor>" + WorldDate.GetLocalizedTemperatureRelative(clothesWarmthModifier.Min) + "</style>) + " + instance.GetText("general_headware") + " (<style=AltColor>" + WorldDate.GetLocalizedTemperatureRelative(capWarmthModifier.Min) + "</style>) = " + $"<style=AltColor>{tempMin}</style>\n" + "<b>" + instance.GetText("general_max_temperature") + ":</b>\n" + instance.GetText("general_base_value") + " (<style=AltColor>" + WorldDate.GetLocalizedTemperature((float)num2 + maxTemperatureFromEffector) + "</style>) + " + instance.GetText("general_clothes") + " (<style=AltColor>" + WorldDate.GetLocalizedTemperatureRelative(clothesWarmthModifier.Max) + "</style>) + " + instance.GetText("general_headware") + " (<style=AltColor>" + WorldDate.GetLocalizedTemperatureRelative(capWarmthModifier.Max) + "</style>) = " + $"<style=AltColor>{tempMax}</style>";
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
					SetupInteractions(base.Humanoid, equipmentSlotLayoutItemView, null);
					equipmentSlotLayoutItemView.gameObject.SetActive(value: false);
				}
				else
				{
					equipmentSlotLayoutItemView.SetTextData(item.Id, ResourceUtils.GetLocalizedResourceName(item.Blueprint.Resource));
					SetupInteractions(base.Humanoid, equipmentSlotLayoutItemView, item);
					text = item.Id;
					equipmentSlotLayoutItemView.gameObject.SetActive(value: true);
				}
				if (!text.Equals("empty"))
				{
					equipmentSlotLayoutItemView.IconItemView.gameObject.SetActive(value: true);
					equipmentSlotLayoutItemView.SetImageData(item.Blueprint.GetID());
					if (equipmentSlotLayoutItemView.IconItemView.TooltipNew is EquipmentTooltipView equipmentTooltipView)
					{
						equipmentTooltipView.SetupData(item, base.Humanoid);
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

		private void SetupInteractions(HumanoidInstance humanoid, ButtonLayoutItemView slotObject, EquipmentInstance item)
		{
			slotObject.Button.onClick.RemoveAllListeners();
			bool flag = false;
			bool flag2 = humanoid.WorkerBehaviour != null && humanoid.WorkerBehaviour.IsBanished;
			if (item != null && !flag2)
			{
				flag = true;
				slotObject.Button.onClick.AddListener(delegate
				{
					DropItem(item);
				});
			}
			slotObject.Button.interactable = flag;
			slotObject.TextObject.raycastTarget = flag;
			slotObject.ButtonIcon.raycastTarget = flag;
		}

		private void DropItem(EquipmentInstance item)
		{
			MonoSingleton<WorkerController>.Instance.DropItem(item, base.Humanoid.Inventory);
		}
	}
}
