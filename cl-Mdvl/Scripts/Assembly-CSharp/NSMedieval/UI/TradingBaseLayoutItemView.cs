using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.UI
{
	public class TradingBaseLayoutItemView : LayoutGroupItemView
	{
		[SerializeField]
		protected BasicLayoutItemView itemName;

		[SerializeField]
		protected BasicLayoutItemView itemQuality;

		[SerializeField]
		protected BasicLayoutItemView itemHitPoints;

		[SerializeField]
		protected BasicLayoutItemView itemNutrition;

		[SerializeField]
		protected BasicLayoutItemView itemWeight;

		[SerializeField]
		protected TooltipViewNew tooltipItemNameResource;

		[SerializeField]
		protected WorkerBaseTooltipViewNew tooltipItemNameHuman;

		[NonSerialized]
		private Resource resource;

		[NonSerialized]
		private CreatureBase creature;

		protected string SpriteString = string.Empty;

		private string qualityString = string.Empty;

		public string ItemNameString { get; private set; } = string.Empty;

		public string HealthString { get; private set; } = string.Empty;

		public bool IsHuman { get; private set; }

		protected bool IsEquipment
		{
			get
			{
				if (creature == null)
				{
					return (resource.Category & ResourceCategory.CtgItem) != 0;
				}
				return false;
			}
		}

		protected bool IsBuilding
		{
			get
			{
				if (creature == null)
				{
					return BuildingUtils.GetBaseBlueprint(resource.GetID()) != null;
				}
				return false;
			}
		}

		public Resource Resource => resource;

		protected void Initialize(Resource resourceType)
		{
			tooltipItemNameResource?.SetEnabled(isEnabled: true);
			tooltipItemNameHuman?.SetEnabled(isEnabled: false);
			creature = null;
			resource = resourceType;
			SetItemName();
			SetQuality();
			SetNutrition();
			SetWeight();
		}

		protected void Initialize(CreatureBase creature)
		{
			resource = null;
			this.creature = creature;
			IsHuman = creature is HumanoidInstance;
			tooltipItemNameResource?.SetEnabled(!IsHuman);
			tooltipItemNameHuman?.SetEnabled(IsHuman);
			if (IsHuman && tooltipItemNameHuman != null)
			{
				tooltipItemNameHuman.SetEnabled(isEnabled: true);
				tooltipItemNameHuman.SetOwner(creature as HumanoidInstance);
				tooltipItemNameHuman.SetLines(GetItemTooltip());
			}
			SetItemName();
			SetQuality();
			SetNutrition();
			SetWeight();
		}

		protected string GetItemName()
		{
			return SpriteString + " " + ItemNameString;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			creature = null;
			resource = null;
		}

		protected List<string> GetItemTooltip()
		{
			if (creature != null)
			{
				if (creature is HumanoidInstance)
				{
					return new List<string>();
				}
				if (creature is AnimalInstance animalInstance)
				{
					return AnimalUtils.GetTooltipLines(animalInstance);
				}
			}
			if (resource == null)
			{
				return new List<string>();
			}
			Equipment equipmentFromResource = EquipmentUtils.GetEquipmentFromResource(resource);
			if (equipmentFromResource != null)
			{
				List<string> list = new List<string>();
				list.Add(TooltipStyles.ApplyStyle(EquipmentUtils.GetTooltipTitle(equipmentFromResource), TooltipStyles.TooltipTitle));
				list.Add(MonoSingleton<LocalizationController>.Instance.GetText("menu_quality") + ": " + qualityString);
				list.Add(MonoSingleton<LocalizationController>.Instance.GetText("menu_health") + ": " + HealthString);
				list.Add(string.Format("{0}: {1}{2}", UiUtils.Localize.GetText("menu_character_weight"), resource.Weight, UiUtils.Localize.GetText("general_kg")));
				list.AddRange(EquipmentUtils.GetTooltipLines(equipmentFromResource, null));
				return list;
			}
			return ResourceUtils.GetTooltipData(resource.GetID());
		}

		protected void SetHealth(float value)
		{
			if (value > 0f)
			{
				HealthString = value.ToString("P1");
				itemHitPoints.SetText(HealthString);
				itemHitPoints.TooltipNew.enabled = true;
			}
			else
			{
				HealthString = string.Empty;
				itemHitPoints.SetText(string.Empty);
				itemHitPoints.TooltipNew.enabled = false;
			}
		}

		private void SetNutrition()
		{
			if (creature != null)
			{
				itemNutrition.SetText(string.Empty);
				itemNutrition.TooltipNew.enabled = false;
			}
			else if (!Repository<DietModelRepository, DietModel>.Instance.WorkerDietModel.CanConsume(resource))
			{
				itemNutrition.SetText(string.Empty);
				itemNutrition.TooltipNew.enabled = false;
			}
			else
			{
				string text = ((resource.Nutrition > 0f) ? $"{resource.Nutrition}" : string.Empty);
				itemNutrition.SetText(text);
				itemNutrition.TooltipNew.enabled = resource.Nutrition > 0f;
			}
		}

		private void SetItemName()
		{
			if (creature != null)
			{
				SpriteString = AssetUtils.GetSpriteAsset(creature.IconPath);
				ItemNameString = creature.TradeName;
			}
			else
			{
				SpriteString = ResourceUtils.GetTextIcon(resource);
				ItemNameString = ResourceUtils.GetLocalizedResourceName(resource);
			}
		}

		private void SetQuality()
		{
			if (resource != null && resource.HasQuality)
			{
				qualityString = MonoSingleton<LocalizationController>.Instance.GetText("quality_" + resource.Quality.ToString().ToLower());
				itemQuality.SetText(qualityString);
				itemQuality.TooltipNew.enabled = true;
				itemQuality.TooltipNew.SetLines(new List<string> { qualityString });
			}
			else
			{
				qualityString = string.Empty;
				itemQuality.SetText(qualityString);
				itemQuality.TooltipNew.enabled = false;
			}
		}

		private void SetWeight()
		{
			if (creature != null)
			{
				itemWeight.SetText(string.Empty);
			}
			else
			{
				itemWeight.SetText(string.Format("{0:N1} {1}", resource.Weight, MonoSingleton<LocalizationController>.Instance.GetText("general_kg")));
			}
		}
	}
}
