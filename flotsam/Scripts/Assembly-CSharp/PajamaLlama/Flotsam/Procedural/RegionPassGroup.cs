using System.Collections;
using PajamaLlama.Flotsam.World;
using UnityEngine;

namespace PajamaLlama.Flotsam.Procedural
{
	[CreateAssetMenu(fileName = "Region Pass Group", menuName = "Flotsam/Procedural Generation/Region Pass Group", order = 3)]
	public class RegionPassGroup : TileGeneratorPass
	{
		public enum CellSizeMethod
		{
			Manual = 0,
			LongestSideCount = 1,
			ShortestSideCount = 2
		}

		[Header("Region Pass")]
		[SerializeField]
		private WorldRegionType[] _regions;

		[SerializeReference]
		[SubclassSelector]
		private IRegionPass[] _passes;

		[SerializeField]
		private RegionPassCells.Settings _cellSettings;

		[SerializeField]
		private CellSizeMethod _cellSizeMethod;

		[SerializeField]
		[ConditionalEnumHide("_cellSizeMethod", 0, true)]
		private Vector2 _cellSize;

		[SerializeField]
		[ConditionalEnumHide("_cellSizeMethod", 1, 2, true)]
		private int _cellCount;

		public TileGenerator Generator { get; private set; }

		public RegionPassCells Cells { get; private set; }

		public override IEnumerator Run(TileGenerator generator, IRegion dataRegion)
		{
			bool acceptsAnyRegion = _regions.Contains(WorldRegionType.Any);
			Initialize(generator);
			if (dataRegion != null)
			{
				if (!acceptsAnyRegion && !_regions.Contains(dataRegion.Type))
				{
					yield break;
				}
				foreach (TileGeneratorRegion value in generator.Regions.Values)
				{
					if (value.IsRegion(dataRegion))
					{
						Run(generator, value);
						yield break;
					}
				}
			}
			else
			{
				TileGeneratorRegion startRegion = null;
				if (generator.IsStartingTile)
				{
					foreach (TileGeneratorRegion value2 in generator.Regions.Values)
					{
						if ((acceptsAnyRegion || _regions.Contains(value2.Type)) && value2.ReturnContainsPosition(generator.StartPosition))
						{
							startRegion = value2;
							Run(generator, value2);
						}
					}
				}
				foreach (TileGeneratorRegion value3 in generator.Regions.Values)
				{
					if (value3 != startRegion)
					{
						if (acceptsAnyRegion || _regions.Contains(value3.Type))
						{
							Run(generator, value3);
						}
						yield return null;
					}
				}
			}
			Uninitialize();
		}

		private void Run(TileGenerator generator, TileGeneratorRegion region)
		{
			int num = 0;
			IRegionPass[] passes = _passes;
			foreach (IRegionPass regionPass in passes)
			{
				regionPass.InitializeRegion(region);
				num += regionPass.SpawnCount;
			}
			Generator = generator;
			Cells = RegionPassCells.GetFromPool(_cellSettings, region, GetCellSize(region));
			passes = _passes;
			for (int i = 0; i < passes.Length; i++)
			{
				passes[i].Run(this, region);
			}
			Cells.Dispose();
			Cells = null;
		}

		private void Initialize(TileGenerator tileGenerator)
		{
			IRegionPass[] passes = _passes;
			for (int i = 0; i < passes.Length; i++)
			{
				passes[i].Initialize(tileGenerator);
			}
		}

		private void Uninitialize()
		{
			IRegionPass[] passes = _passes;
			for (int i = 0; i < passes.Length; i++)
			{
				passes[i].Uninitialize();
			}
		}

		private Vector2 GetCellSize(IRegion region)
		{
			switch (_cellSizeMethod)
			{
			case CellSizeMethod.LongestSideCount:
			{
				float num = ((!(region.Bounds.width < region.Bounds.height)) ? (region.Bounds.width / (float)_cellCount) : (region.Bounds.height / (float)_cellCount));
				return new Vector2(num, num);
			}
			case CellSizeMethod.ShortestSideCount:
			{
				float num = ((!(region.Bounds.width < region.Bounds.height)) ? (region.Bounds.height / (float)_cellCount) : (region.Bounds.width / (float)_cellCount));
				return new Vector2(num, num);
			}
			default:
				return _cellSize;
			}
		}
	}
}
