using System;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.Crops
{
	[Serializable]
	public class Cropfield : NSEipix.Base.Model
	{
		[SerializeField]
		private string id = string.Empty;

		[SerializeField]
		private string defaultPlant;

		[SerializeField]
		private float layerHideOffset;

		[SerializeField]
		private float layerShadowOffset;

		[SerializeField]
		private BuildingCategoryUI buildingCategoryUI;

		[SerializeField]
		private BuildingSubCategoryUI buildingSubCategoryUI;

		[SerializeField]
		private bool isDefault;

		[SerializeField]
		private string seedID;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private string iconPath;

		[SerializeField]
		private string iconColorOverlay;

		private Resource seedBlueprint;

		private PlantMapResource defaultPlantBlueprint;

		public PlantMapResource DefaultPlant
		{
			get
			{
				if (defaultPlantBlueprint == null)
				{
					defaultPlantBlueprint = Repository<PlantMapResourceRepository, PlantMapResource>.Instance.GetByID(defaultPlant);
				}
				return defaultPlantBlueprint;
			}
		}

		public float LayerHideOffset => layerHideOffset;

		public float LayerShadowOffset => layerShadowOffset;

		public BuildingCategoryUI BuildingCategoryUI => buildingCategoryUI;

		public BuildingSubCategoryUI BuildingSubCategoryUI => buildingSubCategoryUI;

		public string SeedId => seedID;

		public Resource SeedBlueprint
		{
			get
			{
				if (seedBlueprint == null)
				{
					seedBlueprint = Repository<ResourceRepository, Resource>.Instance.GetByID(seedID);
				}
				return seedBlueprint;
			}
		}

		public LocKeys[] LocKeys => locKeys;

		public string IconPath => iconPath;

		public string IconColorOverlay => iconColorOverlay;

		public bool IsDefault => isDefault;

		public override string GetID()
		{
			return id;
		}
	}
}
