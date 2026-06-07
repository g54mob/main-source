using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace AwesomeTechnologies.VegetationSystem
{
	[Serializable]
	public class VegetationSettings
	{
		public float PlantDistance = 150f;

		public float AdditionalTreeMeshDistance = 100f;

		public float AdditionalBillboardDistance = 3000f;

		public int Seed;

		public float LODDistanceFactor = 1f;

		public bool GrassShadows;

		public bool PlantShadows;

		public bool TreeShadows = true;

		public bool ObjectShadows = true;

		public bool LargeObjectShadows = true;

		public bool BillboardShadows;

		public bool DisableRenderDistanceFactor;

		public LayerMask GrassLayer = 0;

		public LayerMask PlantLayer = 0;

		public LayerMask TreeLayer = 0;

		public LayerMask ObjectLayer = 0;

		public LayerMask LargeObjectLayer = 0;

		public LayerMask BillboardLayer = 0;

		public float GrassDensity = 1f;

		public float PlantDensity = 1f;

		public float TreeDensity = 1f;

		public float ObjectDensity = 1f;

		public float LargeObjectDensity = 1f;

		public float VegetationScale = 1f;

		public ShadowCastingMode GetBillboardShadowCastingMode()
		{
			if (!BillboardShadows)
			{
				return ShadowCastingMode.Off;
			}
			return ShadowCastingMode.TwoSided;
		}

		public ShadowCastingMode GetShadowCastingMode(VegetationType vegetationType)
		{
			switch (vegetationType)
			{
			case VegetationType.Grass:
				if (!GrassShadows)
				{
					return ShadowCastingMode.Off;
				}
				return ShadowCastingMode.On;
			case VegetationType.Plant:
				if (!PlantShadows)
				{
					return ShadowCastingMode.Off;
				}
				return ShadowCastingMode.On;
			case VegetationType.Tree:
				if (!TreeShadows)
				{
					return ShadowCastingMode.Off;
				}
				return ShadowCastingMode.On;
			case VegetationType.Objects:
				if (!ObjectShadows)
				{
					return ShadowCastingMode.Off;
				}
				return ShadowCastingMode.On;
			case VegetationType.LargeObjects:
				if (!LargeObjectShadows)
				{
					return ShadowCastingMode.Off;
				}
				return ShadowCastingMode.On;
			default:
				return ShadowCastingMode.Off;
			}
		}

		public LayerMask GetLayer(VegetationType vegetationType)
		{
			switch (vegetationType)
			{
			case VegetationType.Grass:
				return GrassLayer;
			case VegetationType.Plant:
				return PlantLayer;
			case VegetationType.Tree:
				return TreeLayer;
			case VegetationType.Objects:
				return ObjectLayer;
			case VegetationType.LargeObjects:
				return LargeObjectLayer;
			default:
				return 0;
			}
		}

		public LayerMask GetBillboardLayer()
		{
			return BillboardLayer;
		}

		public float GetVegetationItemDensity(VegetationType vegetationType)
		{
			switch (vegetationType)
			{
			case VegetationType.Grass:
				return GrassDensity;
			case VegetationType.Plant:
				return PlantDensity;
			case VegetationType.Tree:
				return TreeDensity;
			case VegetationType.Objects:
				return ObjectDensity;
			case VegetationType.LargeObjects:
				return LargeObjectDensity;
			default:
				return 1f;
			}
		}

		public float GetVegetationDistance()
		{
			return PlantDistance;
		}

		public float GetBillboardDistance()
		{
			return PlantDistance + AdditionalTreeMeshDistance + AdditionalBillboardDistance;
		}

		public float GetTreeDistance()
		{
			return PlantDistance + AdditionalTreeMeshDistance;
		}
	}
}
