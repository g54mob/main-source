using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	[Serializable]
	public class PredictiveCellLoader
	{
		private readonly VegetationSystemPro _vegetationSystemPro;

		public readonly List<VegetationCell> PreloadVegetationCellList = new List<VegetationCell>();

		private readonly List<VegetationCell> _tempPreloadList = new List<VegetationCell>();

		public PredictiveCellLoader(VegetationSystemPro vegetationSystemPro)
		{
			_vegetationSystemPro = vegetationSystemPro;
		}

		public void Clear()
		{
			PreloadVegetationCellList.Clear();
		}

		public void ClearNonImportant()
		{
			for (int num = PreloadVegetationCellList.Count - 1; num >= 0; num--)
			{
				if (!PreloadVegetationCellList[num].Important)
				{
					PreloadVegetationCellList.RemoveAtSwapBack(num);
				}
			}
		}

		public void RemoveCellsFlaggedForRemoval()
		{
			for (int num = PreloadVegetationCellList.Count - 1; num >= 0; num--)
			{
				if (PreloadVegetationCellList[num].FlagForRemoval)
				{
					PreloadVegetationCellList.RemoveAtSwapBack(num);
				}
			}
		}

		public void GetCellsToLoad(List<VegetationCell> preloadList)
		{
			if (PreloadVegetationCellList.Count == 0)
			{
				return;
			}
			for (int i = 0; i <= _vegetationSystemPro.PredictiveCellLoaderCellsPerFrame - 1; i++)
			{
				VegetationCell firstUnloadedCell = GetFirstUnloadedCell();
				if (firstUnloadedCell != null)
				{
					preloadList.Add(firstUnloadedCell);
				}
			}
		}

		private VegetationCell GetFirstUnloadedCell()
		{
			while (PreloadVegetationCellList.Count > 0)
			{
				VegetationCell vegetationCell = PreloadVegetationCellList[PreloadVegetationCellList.Count - 1];
				PreloadVegetationCellList.RemoveAtSwapBack(PreloadVegetationCellList.Count - 1);
				if (vegetationCell.LoadedDistanceBand > 0)
				{
					return vegetationCell;
				}
			}
			return null;
		}

		public void PreloadArea(Rect rect, bool important)
		{
			_tempPreloadList.Clear();
			_vegetationSystemPro.VegetationCellQuadTree.Query(rect, _tempPreloadList);
			for (int i = 0; i <= _tempPreloadList.Count - 1; i++)
			{
				VegetationCell vegetationCell = _tempPreloadList[i];
				if (vegetationCell.LoadedDistanceBand > 0)
				{
					if (important)
					{
						vegetationCell.Important = true;
					}
					PreloadVegetationCellList.Add(vegetationCell);
				}
			}
		}

		public void PreloadArea(Rect rect, List<VegetationCell> overlapVegetationCellList, bool important)
		{
			_vegetationSystemPro.VegetationCellQuadTree.Query(rect, overlapVegetationCellList);
			for (int i = 0; i <= overlapVegetationCellList.Count - 1; i++)
			{
				VegetationCell vegetationCell = overlapVegetationCellList[i];
				if (vegetationCell.LoadedDistanceBand > 0)
				{
					if (important)
					{
						vegetationCell.Important = true;
					}
					PreloadVegetationCellList.Add(vegetationCell);
				}
			}
		}

		public void PreloadArea(List<VegetationCell> overlapVegetationCellList, bool important)
		{
			for (int i = 0; i <= overlapVegetationCellList.Count - 1; i++)
			{
				VegetationCell vegetationCell = overlapVegetationCellList[i];
				if (vegetationCell.LoadedDistanceBand > 0)
				{
					if (important)
					{
						vegetationCell.Important = true;
					}
					PreloadVegetationCellList.Add(vegetationCell);
				}
			}
		}

		public void PreloadArea(Vector3 position, float radiusMeter, bool important)
		{
			Rect rect = new Rect(new Vector2(position.x - radiusMeter, position.z - radiusMeter), new Vector2(radiusMeter * 2f, radiusMeter * 2f));
			PreloadArea(rect, important);
		}

		public void PreloadAllVegetationCells()
		{
			for (int i = 0; i <= _vegetationSystemPro.VegetationCellList.Count - 1; i++)
			{
				VegetationCell vegetationCell = _vegetationSystemPro.VegetationCellList[i];
				if (vegetationCell.LoadedDistanceBand > 0)
				{
					PreloadVegetationCellList.Add(vegetationCell);
				}
			}
		}
	}
}
