using System;
using System.Collections.Generic;
using AwesomeTechnologies.Utility.Quadtree;
using AwesomeTechnologies.Vegetation;
using AwesomeTechnologies.VegetationSystem.Biomes;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	public class VegetationCell : IHasRect
	{
		public Bounds VegetationCellBounds;

		public readonly List<VegetationPackageInstances> VegetationPackageInstancesList = new List<VegetationPackageInstances>(8);

		public readonly List<VegetationInstanceData> VegetationInstanceDataList = new List<VegetationInstanceData>();

		public int LoadedDistanceBand = 99;

		public bool LoadedBillboards;

		public bool Prepared;

		public int Index;

		public bool Important;

		public List<PolygonBiomeMask> BiomeMaskList;

		public List<BaseMaskArea> VegetationMaskList;

		public bool FlagForRemoval;

		public Rect Rectangle
		{
			get
			{
				return RectExtension.CreateRectFromBounds(VegetationCellBounds);
			}
			set
			{
				VegetationCellBounds = RectExtension.CreateBoundsFromRect(value);
			}
		}

		public bool Enabled => VegetationCellBounds.center.y > -99999f;

		public int EnabledInt
		{
			get
			{
				if (!(VegetationCellBounds.center.y > -99999f))
				{
					return 0;
				}
				return 1;
			}
		}

		public VegetationCell(Rect rectangle)
		{
			VegetationCellBounds = RectExtension.CreateBoundsFromRect(rectangle, -100000f);
		}

		public BoundingSphere GetBoundingSphere()
		{
			return new BoundingSphere(VegetationCellBounds.center, VegetationCellBounds.extents.magnitude);
		}

		public void Dispose()
		{
			if (BiomeMaskList != null)
			{
				for (int i = 0; i <= BiomeMaskList.Count - 1; i++)
				{
					PolygonBiomeMask polygonBiomeMask = BiomeMaskList[i];
					polygonBiomeMask.OnMaskDeleteDelegate = (PolygonBiomeMask.MultionMaskDeleteDelegate)Delegate.Remove(polygonBiomeMask.OnMaskDeleteDelegate, new PolygonBiomeMask.MultionMaskDeleteDelegate(OnBiomeMaskDelete));
				}
				BiomeMaskList.Clear();
			}
			for (int j = 0; j <= VegetationPackageInstancesList.Count - 1; j++)
			{
				VegetationPackageInstancesList[j].Dispose();
			}
			VegetationPackageInstancesList.Clear();
			for (int k = 0; k <= VegetationInstanceDataList.Count - 1; k++)
			{
				VegetationInstanceDataList[k].Dispose();
			}
			VegetationInstanceDataList.Clear();
		}

		public void ClearInstanceMemory()
		{
			for (int i = 0; i <= VegetationPackageInstancesList.Count - 1; i++)
			{
				VegetationPackageInstancesList[i].ClearInstanceMemory();
			}
		}

		public void ClearCache()
		{
			for (int i = 0; i <= VegetationPackageInstancesList.Count - 1; i++)
			{
				if (VegetationPackageInstancesList[i].LoadStateList.IsCreated)
				{
					for (int j = 0; j <= VegetationPackageInstancesList[i].LoadStateList.Length - 1; j++)
					{
						VegetationPackageInstancesList[i].LoadStateList[j] = 0;
					}
				}
				for (int k = 0; k <= VegetationPackageInstancesList[i].VegetationItemComputeBufferList.Count - 1; k++)
				{
					if (VegetationPackageInstancesList[i].VegetationItemComputeBufferList[k].Created)
					{
						VegetationPackageInstancesList[i].VegetationItemComputeBufferList[k].ComputeBuffer.Dispose();
						VegetationPackageInstancesList[i].VegetationItemComputeBufferList[k].Created = false;
					}
				}
				for (int l = 0; l <= VegetationPackageInstancesList[i].VegetationItemInstancedIndirectInstanceList.Count - 1; l++)
				{
					if (VegetationPackageInstancesList[i].VegetationItemInstancedIndirectInstanceList[l].Created)
					{
						if (VegetationPackageInstancesList[i].VegetationItemInstancedIndirectInstanceList[l].InstancedIndirectInstanceList.IsCreated)
						{
							VegetationPackageInstancesList[i].VegetationItemInstancedIndirectInstanceList[l].InstancedIndirectInstanceList.Dispose();
						}
						VegetationPackageInstancesList[i].VegetationItemInstancedIndirectInstanceList[l].Created = false;
					}
				}
			}
			LoadedDistanceBand = 99;
			LoadedBillboards = false;
			ClearInstanceMemory();
		}

		public void ClearCache(int vegetationPackageIndex, int vegetationItemIndex, bool tree)
		{
			if (tree)
			{
				LoadedDistanceBand = 99;
				LoadedBillboards = false;
			}
			else
			{
				LoadedDistanceBand++;
				LoadedBillboards = false;
			}
			if (VegetationPackageInstancesList.Count > vegetationPackageIndex && VegetationPackageInstancesList[vegetationPackageIndex].LoadStateList.Length > vegetationItemIndex)
			{
				VegetationPackageInstancesList[vegetationPackageIndex].LoadStateList[vegetationItemIndex] = 0;
				if (VegetationPackageInstancesList[vegetationPackageIndex].VegetationItemInstancedIndirectInstanceList[vegetationItemIndex].Created)
				{
					VegetationPackageInstancesList[vegetationPackageIndex].VegetationItemInstancedIndirectInstanceList[vegetationItemIndex].InstancedIndirectInstanceList.Dispose();
					VegetationPackageInstancesList[vegetationPackageIndex].VegetationItemInstancedIndirectInstanceList[vegetationItemIndex].Created = false;
				}
				if (VegetationPackageInstancesList[vegetationPackageIndex].VegetationItemComputeBufferList[vegetationItemIndex].Created)
				{
					VegetationPackageInstancesList[vegetationPackageIndex].VegetationItemComputeBufferList[vegetationItemIndex].ComputeBuffer.Dispose();
					VegetationPackageInstancesList[vegetationPackageIndex].VegetationItemComputeBufferList[vegetationItemIndex].Created = false;
				}
			}
		}

		public void AddBiomeMask(PolygonBiomeMask maskArea)
		{
			if (BiomeMaskList == null)
			{
				BiomeMaskList = new List<PolygonBiomeMask>();
			}
			BiomeMaskList.Add(maskArea);
			if (BiomeMaskList.Count > 1)
			{
				SortBiomeList();
			}
			maskArea.OnMaskDeleteDelegate = (PolygonBiomeMask.MultionMaskDeleteDelegate)Delegate.Combine(maskArea.OnMaskDeleteDelegate, new PolygonBiomeMask.MultionMaskDeleteDelegate(OnBiomeMaskDelete));
			ClearCache();
		}

		public void AddVegetationMask(BaseMaskArea maskArea)
		{
			if (VegetationMaskList == null)
			{
				VegetationMaskList = new List<BaseMaskArea>();
			}
			VegetationMaskList.Add(maskArea);
			maskArea.OnMaskDeleteDelegate = (BaseMaskArea.MultionMaskDeleteDelegate)Delegate.Combine(maskArea.OnMaskDeleteDelegate, new BaseMaskArea.MultionMaskDeleteDelegate(OnVegetationMaskDelete));
			ClearCache();
		}

		public void AddVegetationMask(BaseMaskArea maskArea, int vegetationPackageIndex, int vegetationItemIndex)
		{
			if (VegetationMaskList == null)
			{
				VegetationMaskList = new List<BaseMaskArea>();
			}
			VegetationMaskList.Add(maskArea);
			maskArea.OnMaskDeleteDelegate = (BaseMaskArea.MultionMaskDeleteDelegate)Delegate.Combine(maskArea.OnMaskDeleteDelegate, new BaseMaskArea.MultionMaskDeleteDelegate(OnVegetationMaskDelete));
			ClearCache(vegetationPackageIndex, vegetationItemIndex, tree: true);
		}

		private void OnVegetationMaskDelete(BaseMaskArea maskArea)
		{
			maskArea.OnMaskDeleteDelegate = (BaseMaskArea.MultionMaskDeleteDelegate)Delegate.Remove(maskArea.OnMaskDeleteDelegate, new BaseMaskArea.MultionMaskDeleteDelegate(OnVegetationMaskDelete));
			if (VegetationMaskList != null)
			{
				VegetationMaskList.Remove(maskArea);
				ClearCache();
			}
		}

		private void SortBiomeList()
		{
			BiomeMaskSortOrderComparer comparer = new BiomeMaskSortOrderComparer();
			BiomeMaskList.Sort(comparer);
		}

		private void OnBiomeMaskDelete(PolygonBiomeMask maskArea)
		{
			maskArea.OnMaskDeleteDelegate = (PolygonBiomeMask.MultionMaskDeleteDelegate)Delegate.Remove(maskArea.OnMaskDeleteDelegate, new PolygonBiomeMask.MultionMaskDeleteDelegate(OnBiomeMaskDelete));
			if (BiomeMaskList != null)
			{
				BiomeMaskList.Remove(maskArea);
				ClearCache();
			}
		}

		public bool HasBiome(BiomeType biomeType)
		{
			if (BiomeMaskList == null)
			{
				return false;
			}
			for (int i = 0; i <= BiomeMaskList.Count - 1; i++)
			{
				if (BiomeMaskList[i].BiomeType == biomeType)
				{
					return true;
				}
			}
			return false;
		}
	}
}
