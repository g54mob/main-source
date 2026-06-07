using System.Collections.Generic;
using AwesomeTechnologies.Vegetation;
using AwesomeTechnologies.VegetationSystem;
using Unity.Jobs;
using UnityEngine;

namespace AwesomeTechnologies
{
	public class BaseMaskArea
	{
		public delegate void MultionMaskDeleteDelegate(BaseMaskArea baseMaskArea);

		public Bounds MaskBounds;

		public bool RemoveGrass = true;

		public bool RemovePlants = true;

		public bool RemoveTrees = true;

		public bool RemoveObjects = true;

		public bool RemoveLargeObjects = true;

		public float AdditionalGrassWidth;

		public float AdditionalPlantWidth;

		public float AdditionalTreeWidth;

		public float AdditionalObjectWidth;

		public float AdditionalLargeObjectWidth;

		public float AdditionalGrassWidthMax;

		public float AdditionalPlantWidthMax;

		public float AdditionalTreeWidthMax;

		public float AdditionalObjectWidthMax;

		public float AdditionalLargeObjectWidthMax;

		public float NoiseScaleGrass = 5f;

		public float NoiseScalePlant = 5f;

		public float NoiseScaleTree = 5f;

		public float NoiseScaleObject = 5f;

		public float NoiseScaleLargeObject = 5f;

		public string VegetationItemID = "";

		public List<VegetationTypeSettings> VegetationTypeList = new List<VegetationTypeSettings>();

		public MultionMaskDeleteDelegate OnMaskDeleteDelegate;

		public virtual JobHandle SampleMask(VegetationInstanceData instanceData, VegetationType vegetationType, JobHandle dependsOn)
		{
			return dependsOn;
		}

		public virtual JobHandle SampleIncludeVegetationMask(VegetationInstanceData instanceData, VegetationTypeIndex vegetationTypeIndex, JobHandle dependsOn)
		{
			return dependsOn;
		}

		public virtual bool HasVegetationTypeIndex(VegetationTypeIndex vegetationTypeIndex)
		{
			return false;
		}

		public float GetAdditionalWidth(VegetationType vegetationType)
		{
			switch (vegetationType)
			{
			case VegetationType.Grass:
				return AdditionalGrassWidth;
			case VegetationType.Plant:
				return AdditionalPlantWidth;
			case VegetationType.Tree:
				return AdditionalTreeWidth;
			case VegetationType.Objects:
				return AdditionalObjectWidth;
			case VegetationType.LargeObjects:
				return AdditionalLargeObjectWidth;
			default:
				return 0f;
			}
		}

		public VegetationTypeSettings GetVegetationTypeSettings(VegetationTypeIndex vegetationTypeIndex)
		{
			for (int i = 0; i <= VegetationTypeList.Count - 1; i++)
			{
				if (VegetationTypeList[i].Index == vegetationTypeIndex)
				{
					return VegetationTypeList[i];
				}
			}
			return null;
		}

		public bool ExcludeVegetationType(VegetationType vegetationType)
		{
			switch (vegetationType)
			{
			case VegetationType.Grass:
				return RemoveGrass;
			case VegetationType.Plant:
				return RemovePlants;
			case VegetationType.Tree:
				return RemoveTrees;
			case VegetationType.Objects:
				return RemoveObjects;
			case VegetationType.LargeObjects:
				return RemoveLargeObjects;
			default:
				return false;
			}
		}

		public float GetAdditionalWidthMax(VegetationType vegetationType)
		{
			switch (vegetationType)
			{
			case VegetationType.Grass:
				return AdditionalGrassWidthMax;
			case VegetationType.Plant:
				return AdditionalPlantWidthMax;
			case VegetationType.Tree:
				return AdditionalTreeWidthMax;
			case VegetationType.Objects:
				return AdditionalObjectWidthMax;
			case VegetationType.LargeObjects:
				return AdditionalLargeObjectWidthMax;
			default:
				return 0f;
			}
		}

		public float GetPerlinScale(VegetationType vegetationType)
		{
			switch (vegetationType)
			{
			case VegetationType.Grass:
				return NoiseScaleGrass;
			case VegetationType.Plant:
				return NoiseScalePlant;
			case VegetationType.Tree:
				return NoiseScaleTree;
			case VegetationType.Objects:
				return NoiseScaleObject;
			case VegetationType.LargeObjects:
				return NoiseScaleLargeObject;
			default:
				return 0f;
			}
		}

		public void CallDeleteEvent()
		{
			if (OnMaskDeleteDelegate != null)
			{
				OnMaskDeleteDelegate(this);
			}
		}

		public float GetMaxAdditionalDistance()
		{
			return Mathf.Max(AdditionalGrassWidth, AdditionalPlantWidth, AdditionalTreeWidth, AdditionalObjectWidth, AdditionalLargeObjectWidth, AdditionalGrassWidthMax, AdditionalPlantWidthMax, AdditionalTreeWidthMax, AdditionalObjectWidthMax, AdditionalLargeObjectWidthMax) * 1.5f;
		}

		public float SamplePerlinNoise(Vector3 point, float perlinNoiceScale)
		{
			return Mathf.PerlinNoise(point.x / perlinNoiceScale, point.z / perlinNoiceScale);
		}

		public virtual void Dispose()
		{
		}
	}
}
