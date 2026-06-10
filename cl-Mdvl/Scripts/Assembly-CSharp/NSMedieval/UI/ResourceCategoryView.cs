using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.Types;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class ResourceCategoryView : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI categoryName;

		[SerializeField]
		private Toggle toggle;

		[SerializeField]
		private AllowedResourceView allowedResourceViewPrefab;

		[NonSerialized]
		private ResourceCategory category;

		[NonSerialized]
		private ProductionInstance production;

		[NonSerialized]
		private readonly List<AllowedResourceView> list = new List<AllowedResourceView>();

		public ResourceCategory Category => category;

		public ProductionInstance Production => production;

		public void Setup(ResourceCategory category, ProductionInstance production)
		{
			this.category = category;
			this.production = production;
			categoryName.text = MonoSingleton<LocalizationController>.Instance.GetText("resource_category_name_" + category);
		}

		public void Setup(ItemMaterialCategory category, ProductionInstance production)
		{
			this.category = ResourceCategory.None;
			this.production = production;
			categoryName.text = MonoSingleton<LocalizationController>.Instance.GetText("equipment_material_" + category);
		}

		public void AddItem(Resource resource)
		{
			AllowedResourceView allowedResourceView = UnityEngine.Object.Instantiate(allowedResourceViewPrefab, base.transform);
			list.Add(allowedResourceView);
			allowedResourceView.Setup(resource);
			allowedResourceView.SetToggle(production.ResourceFilter.IsBlueprintAllowed(resource));
			allowedResourceView.AddCallback(OnChildToggleChanged);
		}

		public void SetToggle(bool value)
		{
			OnGroupToggleChanged(value);
		}

		private void OnChildToggleChanged(bool value, Resource resource)
		{
			if (!value)
			{
				if (list.All((AllowedResourceView item) => !item.IsOn))
				{
					toggle.onValueChanged.RemoveListener(OnGroupToggleChanged);
					toggle.isOn = false;
					toggle.onValueChanged.AddListener(OnGroupToggleChanged);
				}
				if (resource.EquipmentBlueprint == null)
				{
					production.ResourceFilter.RemoveAllowedResource(resource);
				}
				else
				{
					production.ResourceFilter.RemoveAllowedResourceByGroupId(resource.GroupIdentifier);
				}
			}
			else
			{
				if (!toggle.isOn)
				{
					toggle.onValueChanged.RemoveListener(OnGroupToggleChanged);
					toggle.isOn = true;
					toggle.onValueChanged.AddListener(OnGroupToggleChanged);
				}
				if (resource.EquipmentBlueprint == null)
				{
					production.ResourceFilter.AddAllowedResource(resource);
				}
				else
				{
					production.ResourceFilter.AddAllowedResourceByGroupId(resource.GroupIdentifier, resource.ItemMaterialCategory);
				}
			}
		}

		private void OnGroupToggleChanged(bool value)
		{
			foreach (AllowedResourceView item in list)
			{
				item.SetToggle(value);
			}
		}

		private void Start()
		{
			toggle.onValueChanged.AddListener(OnGroupToggleChanged);
		}
	}
}
