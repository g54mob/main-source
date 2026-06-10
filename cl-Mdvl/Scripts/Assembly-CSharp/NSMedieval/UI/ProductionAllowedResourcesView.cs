using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.Stockpiles;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class ProductionAllowedResourcesView : MonoBehaviour
	{
		[SerializeField]
		private ResourceCategoryView categoryPrefab;

		[SerializeField]
		private Transform contentView;

		[SerializeField]
		private FillBarLayoutItemView title;

		[SerializeField]
		private Button allowAll;

		[SerializeField]
		private Button clearAll;

		[SerializeField]
		private RangedSliderItemView hitpointsSliderGroup;

		[SerializeField]
		private RangedSliderItemView freshnessSliderGroup;

		[NonSerialized]
		private ProductionInstance production;

		public ProductionInstance Production => production;

		public void SetProduction(ProductionInstance productionInstance)
		{
			if (productionInstance == null || productionInstance.HasDisposed)
			{
				Close();
				return;
			}
			production = productionInstance;
			GenerateItems();
			SetUpSliders();
			string text = MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(productionInstance.Blueprint.LocKeys));
			title.SetText(MonoSingleton<LocalizationController>.Instance.GetText("menu_produce") + ": " + text);
			base.gameObject.SetActive(value: true);
		}

		public void Close()
		{
			production = null;
			DestroyAllChildren();
			base.gameObject.SetActive(value: false);
		}

		private void OnBtnAllowAllClick()
		{
			for (int i = 0; i < contentView.childCount; i++)
			{
				ResourceCategoryView component = contentView.GetChild(i).GetComponent<ResourceCategoryView>();
				if (component != null)
				{
					component.SetToggle(value: true);
				}
			}
		}

		private void OnBtnClearAllClick()
		{
			for (int i = 0; i < contentView.childCount; i++)
			{
				ResourceCategoryView component = contentView.GetChild(i).GetComponent<ResourceCategoryView>();
				if (component != null)
				{
					component.SetToggle(value: false);
				}
			}
		}

		private void GenerateItems()
		{
			DestroyAllChildren();
			bool isEnabled;
			if (production.Blueprint.Recipe == null || production.Blueprint.Recipe.Count == 0)
			{
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(26, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Selection\\Production\\ProductionAllowedResourcesView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Production ");
					messageBuilder.AppendFormatted(production.BlueprintId);
					messageBuilder.AppendLiteral(" has no recipe!");
				}
				Log.Warning(messageBuilder);
				return;
			}
			List<Resource> allUsableResources = production.Blueprint.AllUsableResources.ToPooledList();
			HashSet<ResourceCategory> hashSet = HashSetPool<ResourceCategory>.Get();
			foreach (KeyIntPair item in production.Blueprint.Recipe)
			{
				if (!int.TryParse(item.GetID(), out var result))
				{
					continue;
				}
				if ((result & (result - 1)) != 0)
				{
					FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(60, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Selection\\Production\\ProductionAllowedResourcesView.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Production ");
						messageBuilder.AppendFormatted(production.BlueprintId);
						messageBuilder.AppendLiteral(" has more than one flag category set somewhere...");
					}
					Log.Warning(messageBuilder);
				}
				hashSet.Add((ResourceCategory)result);
			}
			foreach (KeyIntPair item2 in production.Blueprint.SecondaryRecipe)
			{
				if (!int.TryParse(item2.GetID(), out var result2))
				{
					continue;
				}
				if ((result2 & (result2 - 1)) != 0)
				{
					FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(60, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Selection\\Production\\ProductionAllowedResourcesView.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Production ");
						messageBuilder.AppendFormatted(production.BlueprintId);
						messageBuilder.AppendLiteral(" has more than one flag category set somewhere...");
					}
					Log.Warning(messageBuilder);
				}
				hashSet.Add((ResourceCategory)result2);
			}
			if (hashSet.Count == 0)
			{
				Close();
			}
			foreach (ResourceCategory item3 in hashSet)
			{
				if (item3 == ResourceCategory.None)
				{
					Log.Warning("Empty or NULL string in Resource SortingGroup", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Selection\\Production\\ProductionAllowedResourcesView.cs");
					continue;
				}
				ResourceCategoryView componentInChildren = UnityEngine.Object.Instantiate(categoryPrefab, contentView.transform).GetComponentInChildren<ResourceCategoryView>();
				componentInChildren.Setup(item3, production);
				GenerateCategoryChildren(componentInChildren, ref allUsableResources);
			}
			ListPool<Resource>.Return(allUsableResources);
			HashSetPool<ResourceCategory>.Return(hashSet);
		}

		private void GenerateCategoryChildren(ResourceCategoryView categoryView, ref List<Resource> allUsableResources)
		{
			for (int i = 0; i < allUsableResources.Count; i++)
			{
				Resource resource = allUsableResources[i];
				if ((resource.Category & categoryView.Category) != ResourceCategory.None)
				{
					categoryView.AddItem(resource);
					allUsableResources.RemoveAt(i);
					i--;
				}
			}
		}

		private void DestroyAllChildren()
		{
			for (int i = 0; i < contentView.childCount; i++)
			{
				Transform child = contentView.GetChild(i);
				if (!(child == null) && !(child.gameObject == null))
				{
					UnityEngine.Object.Destroy(child.gameObject);
				}
			}
		}

		private void SetUpSliders()
		{
			if (!production.Blueprint.HasFreshness)
			{
				freshnessSliderGroup.Hide();
				hitpointsSliderGroup.Hide();
				return;
			}
			ResourcesFilter resourceFilter = production.ResourceFilter;
			hitpointsSliderGroup.Show();
			float num = (float)resourceFilter.HitPointsPercent.Min / 100f;
			float num2 = (float)resourceFilter.HitPointsPercent.Max / 100f;
			hitpointsSliderGroup.Slider.LowValue = num;
			hitpointsSliderGroup.Slider.HighValue = num2;
			OnHitpointsSliderDrag(num, num2);
			freshnessSliderGroup.Show();
			float num3 = (float)resourceFilter.FreshnessPercent.Min / 100f;
			float num4 = (float)resourceFilter.FreshnessPercent.Max / 100f;
			freshnessSliderGroup.Slider.LowValue = num3;
			freshnessSliderGroup.Slider.HighValue = num4;
			OnFreshnessSliderDrag(num3, num4);
		}

		private void OnHitpointsSliderDrag(float low, float high)
		{
			IntRange intRange = new IntRange(Mathf.RoundToInt(low * 100f), Mathf.RoundToInt(high * 100f));
			string formattedRange = $"{intRange.Min}% - {intRange.Max}%";
			hitpointsSliderGroup.SetSliderData("hit_points", formattedRange);
			if (production != null && !production.HasDisposed && production.ResourceFilter != null)
			{
				production.ResourceFilter.SetHitPointsPercent(intRange);
			}
		}

		private void OnFreshnessSliderDrag(float low, float high)
		{
			IntRange intRange = new IntRange(Mathf.RoundToInt(low * 100f), Mathf.RoundToInt(high * 100f));
			string formattedRange = $"{intRange.Min}% - {intRange.Max}%";
			freshnessSliderGroup.SetSliderData("freshness", formattedRange);
			if (production != null && !production.HasDisposed && production.ResourceFilter != null)
			{
				production.ResourceFilter.SetFreshnessPercent(intRange);
			}
		}

		private void Start()
		{
			allowAll.onClick.AddListener(OnBtnAllowAllClick);
			clearAll.onClick.AddListener(OnBtnClearAllClick);
			hitpointsSliderGroup.Slider.OnValueChanged.AddListener(OnHitpointsSliderDrag);
			freshnessSliderGroup.Slider.OnValueChanged.AddListener(OnFreshnessSliderDrag);
		}
	}
}
