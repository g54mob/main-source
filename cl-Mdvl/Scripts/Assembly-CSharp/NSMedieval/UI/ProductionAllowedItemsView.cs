using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Stockpiles;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class ProductionAllowedItemsView : MonoBehaviour
	{
		[SerializeField]
		private ResourceCategoryView categoryPrefab;

		[SerializeField]
		private FillBarLayoutItemView title;

		[SerializeField]
		private Transform contentView;

		[SerializeField]
		private RangedSliderItemView hitpointsSliderGroup;

		[SerializeField]
		private RangedSliderItemView itemQualitySliderGroup;

		[SerializeField]
		private Button allowAll;

		[SerializeField]
		private Button clearAll;

		[NonSerialized]
		private ProductionInstance production;

		[NonSerialized]
		private ResourceCategoryView categoryView;

		public ProductionInstance Production => production;

		public void SetProduction(ProductionInstance productionInstance)
		{
			if (productionInstance == null || productionInstance.HasDisposed)
			{
				Close();
				return;
			}
			base.gameObject.SetActive(value: true);
			production = productionInstance;
			title.SetText(MonoSingleton<LocalizationController>.Instance.GetText("menu_produce") + ": " + ResourceUtils.GetLocalizedResourceName(production.Blueprint.GetID()));
			ResourcesFilter resourceFilter = production.ResourceFilter;
			float num = (float)resourceFilter.HitPointsPercent.Min / 100f;
			float num2 = (float)resourceFilter.HitPointsPercent.Max / 100f;
			hitpointsSliderGroup.Slider.LowValue = num;
			hitpointsSliderGroup.Slider.HighValue = num2;
			OnHitpointsSliderDrag(num, num2);
			int min = resourceFilter.Quality.Min;
			int max = resourceFilter.Quality.Max;
			itemQualitySliderGroup.Slider.LowValue = min;
			itemQualitySliderGroup.Slider.HighValue = max;
			OnQualitySliderDrag(min, max);
			GenerateItems();
		}

		public void Close()
		{
			if (production != null)
			{
				production = null;
				base.gameObject.SetActive(value: false);
				DestroyAllChildren();
			}
		}

		private void Start()
		{
			hitpointsSliderGroup.Slider.OnValueChanged.AddListener(OnHitpointsSliderDrag);
			itemQualitySliderGroup.Slider.OnValueChanged.AddListener(OnQualitySliderDrag);
			allowAll.onClick.AddListener(OnBtnAllowAllClick);
			clearAll.onClick.AddListener(OnBtnClearAllClick);
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

		private void OnQualitySliderDrag(float low, float high)
		{
			ProductQuality productQuality = (ProductQuality)low;
			ProductQuality productQuality2 = (ProductQuality)high;
			string formattedRange = MonoSingleton<LocalizationController>.Instance.GetText($"quality_{productQuality}") + " - " + MonoSingleton<LocalizationController>.Instance.GetText($"quality_{productQuality2}");
			itemQualitySliderGroup.SetSliderData("quality", formattedRange);
			if (production != null && !production.HasDisposed && production.ResourceFilter != null)
			{
				production.ResourceFilter.SetQuality(new IntRange((int)low, (int)high));
			}
		}

		private void OnBtnAllowAllClick()
		{
			if (categoryView != null)
			{
				categoryView.SetToggle(value: true);
			}
		}

		private void OnBtnClearAllClick()
		{
			if (categoryView != null)
			{
				categoryView.SetToggle(value: false);
			}
		}

		private void GenerateItems()
		{
			DestroyAllChildren();
			categoryView = UnityEngine.Object.Instantiate(categoryPrefab, contentView.transform).GetComponentInChildren<ResourceCategoryView>();
			categoryView.Setup(production.Blueprint.ItemMaterialCategory, production);
			HashSet<string> hashSet = HashSetPool<string>.Get();
			foreach (Resource item in Repository<ResourceRepository, Resource>.Instance.GetAllResourcesByMaterial(production.Blueprint.ItemMaterialCategory))
			{
				if (hashSet.Add(item.GroupIdentifier))
				{
					categoryView.AddItem(item);
				}
			}
			HashSetPool<string>.Return(hashSet);
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
	}
}
