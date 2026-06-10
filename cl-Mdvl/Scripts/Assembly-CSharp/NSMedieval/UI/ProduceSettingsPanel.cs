using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class ProduceSettingsPanel : PopupView
	{
		[SerializeField]
		private ProductionAllowedResourcesView productionAllowedResourcesView;

		[SerializeField]
		private ProductionAllowedItemsView productionAllowedItemsView;

		[SerializeField]
		private FillBarLayoutItemView title;

		[SerializeField]
		private TMP_Dropdown assignDropdown;

		[SerializeField]
		private SoundButton closeButton;

		[SerializeField]
		private SoundButton blurBackgroundButton;

		[SerializeField]
		private RangedSliderItemView skillLevelSliderGroup;

		[NonSerialized]
		private ProductionInstance production;

		[NonSerialized]
		private List<HumanoidInstance> workers = new List<HumanoidInstance>();

		public Dictionary<string, IntRange> DefaultSkillLevelsForBlueprintId { get; } = new Dictionary<string, IntRange>();

		public void SetUpAndShow(ProductionInstance productionToShow)
		{
			production = productionToShow;
			AddAssignProductionOptions();
			SetUpSkillLevelSlider();
			SetUpFilterPanel();
			Show();
		}

		private void Start()
		{
			assignDropdown.onValueChanged.AddListener(OnAssignChanged);
			skillLevelSliderGroup.Slider.OnValueChanged.AddListener(OnSkillSliderDrag);
			closeButton.onClick.AddListener(OnClose);
			blurBackgroundButton.onClick.AddListener(OnClose);
		}

		private void SetUpFilterPanel()
		{
			productionAllowedResourcesView.Close();
			productionAllowedItemsView.Close();
			if ((production.Blueprint.RecipeIsNoResources() || production.Blueprint.RecipeIsExactResource()) && !production.Blueprint.IsDismantle())
			{
				string localizedResourceName = ResourceUtils.GetLocalizedResourceName(production.Blueprint.GetID());
				title.SetText(MonoSingleton<LocalizationController>.Instance.GetText("menu_produce") + ": " + localizedResourceName);
			}
			else if (production.Blueprint.IsDismantle())
			{
				productionAllowedItemsView.SetProduction(production);
			}
			else
			{
				productionAllowedResourcesView.SetProduction(production);
			}
		}

		private void SetUpSkillLevelSlider()
		{
			if (production.OwnerCreatureId != 0)
			{
				skillLevelSliderGroup.Hide();
				production.SetSkillRange(null);
				return;
			}
			List<SkillLevelPair> requiredSkills = production.Blueprint.RequiredSkills;
			if (requiredSkills.Count <= 0)
			{
				skillLevelSliderGroup.Hide();
				production.SetSkillRange(null);
				return;
			}
			SkillLevelPair skillLevelPair = requiredSkills.First();
			int num = skillLevelPair.Value;
			int num2 = GlobalSaveController.CurrentVillageData.Workers.First().Skills.GetSkill(skillLevelPair.Key).GetMaxLevel();
			skillLevelSliderGroup.Slider.MinValue = num;
			skillLevelSliderGroup.Slider.MaxValue = num2;
			if (!DefaultSkillLevelsForBlueprintId.ContainsKey(production.BlueprintId))
			{
				DefaultSkillLevelsForBlueprintId.Add(production.BlueprintId, new IntRange(num, num2));
			}
			if (production.SkillLevelRange != null)
			{
				num = production.SkillLevelRange.Min;
				num2 = production.SkillLevelRange.Max;
			}
			skillLevelSliderGroup.Slider.LowValue = num;
			skillLevelSliderGroup.Slider.HighValue = num2;
			OnSkillSliderDrag(num, num2);
			skillLevelSliderGroup.Show();
		}

		private void OnSkillSliderDrag(float low, float high)
		{
			IntRange intRange = new IntRange(Mathf.RoundToInt(low), Mathf.RoundToInt(high));
			SkillLevelPair skillLevelPair = production.Blueprint.RequiredSkills.First();
			string text = MonoSingleton<LocalizationController>.Instance.GetText("skill_name_" + skillLevelPair.GetID());
			string formattedRange = string.Format("{0} {1} {2} - {3}", AssetUtils.GetSpriteAsset(skillLevelPair.GetID().ToLower(CultureInfo.InvariantCulture) ?? ""), text, intRange.Min, intRange.Max);
			skillLevelSliderGroup.SetSliderData("production_settings_skill_range", formattedRange);
			production.SetSkillRange(intRange);
		}

		private void AddAssignProductionOptions()
		{
			assignDropdown.ClearOptions();
			List<string> list = new List<string> { MonoSingleton<LocalizationController>.Instance.GetText("general_anyone") };
			workers.Clear();
			workers.AddRange(GlobalSaveController.CurrentVillageData.Workers);
			workers.AddRange(GlobalSaveController.CurrentVillageData.WorldMapData.CaravanWorkers);
			List<SkillLevelPair> requiredSkills = production.Blueprint.RequiredSkills;
			if (requiredSkills.Count > 0)
			{
				SkillType skill = requiredSkills.First().Key;
				workers.Sort((HumanoidInstance a, HumanoidInstance b) => b.Skills.GetSkill(skill).Level - a.Skills.GetSkill(skill).Level);
			}
			else
			{
				workers.Sort((HumanoidInstance a, HumanoidInstance b) => string.CompareOrdinal(a.Info.GetFullName(), b.Info.GetFullName()));
			}
			foreach (HumanoidInstance worker in workers)
			{
				if (MonoSingleton<CaravanManager>.Instance.IsWorkerInCaravan(worker))
				{
					string item = ColorUtils.ColorText(worker.Info.GetFullName() + " (" + MonoSingleton<LocalizationController>.Instance.GetText("caravan_status_travelling") + ")", ColorUtils.GetColor("pet_owner_in_caravan"));
					list.Add(item);
				}
				else if (requiredSkills.Count > 0)
				{
					SkillType key = requiredSkills.First().Key;
					string text = key.ToString().ToLower(CultureInfo.InvariantCulture);
					list.Add($"{worker.Info.GetFullName()} <sprite=\"{text}\" name=\"{text}\"> <style=AltColor>{worker.Skills.GetSkill(key).Level}</style>");
				}
				else
				{
					list.Add(worker.Info.GetFullName());
				}
			}
			assignDropdown.AddOptions(list);
			if (production.OwnerCreatureId != 0)
			{
				CreatureBase byCreationId = MonoSingleton<CreatureManager>.Instance.GetByCreationId(production.OwnerCreatureId);
				assignDropdown.SetValueWithoutNotify(workers.IndexOf((HumanoidInstance)byCreationId) + 1);
			}
		}

		private void OnAssignChanged(int value)
		{
			if (value == 0)
			{
				production.SetOwnerCreatureId(0);
				SetUpSkillLevelSlider();
			}
			else
			{
				HumanoidInstance humanoidInstance = workers[value - 1];
				production.SetOwnerCreatureId(humanoidInstance.UniqueId);
				SetUpSkillLevelSlider();
			}
		}

		private void OnClose()
		{
			Hide();
		}
	}
}
