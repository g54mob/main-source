using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Data.Buildings;
using UnityEngine;

namespace Presentation.FactoryFloor.FactoryObjectViews.Buildings
{
	public class CrateView : MonoBehaviour
	{
		[Serializable]
		private struct ResourceIconTier
		{
			public SerializedDictionary<BuildingCategoryType, Material> CategoryIcons;
		}

		[SerializeField]
		private Renderer _crateRenderer;

		[SerializeField]
		private List<Renderer> _iconRenderers;

		[Space]
		[SerializeField]
		private List<Material> _crateMaterialsBasedOnID;

		[SerializeField]
		private List<ResourceIconTier> _resourceIconTiers;

		private int _buildingFamilyID;

		public void SetBuilding(int buildingFamilyID, BuildingCategoryType buildingCategoryType)
		{
			SetBuildingFamilyID(buildingFamilyID);
			SetBuildingCategory(buildingCategoryType);
		}

		private void SetBuildingCategory(BuildingCategoryType buildingCategoryType)
		{
			if (_resourceIconTiers.Count <= _buildingFamilyID || _buildingFamilyID < 0)
			{
				return;
			}
			if (_resourceIconTiers[_buildingFamilyID].CategoryIcons.TryGetValue(buildingCategoryType, out var value))
			{
				foreach (Renderer iconRenderer in _iconRenderers)
				{
					iconRenderer.sharedMaterial = value;
					iconRenderer.gameObject.SetActive(value: true);
				}
				return;
			}
			foreach (Renderer iconRenderer2 in _iconRenderers)
			{
				iconRenderer2.gameObject.SetActive(value: false);
			}
		}

		private void SetBuildingFamilyID(int buildingFamilyID)
		{
			if (buildingFamilyID >= 0 && buildingFamilyID < _crateMaterialsBasedOnID.Count)
			{
				_crateRenderer.sharedMaterial = _crateMaterialsBasedOnID[buildingFamilyID];
				_buildingFamilyID = buildingFamilyID;
			}
		}
	}
}
