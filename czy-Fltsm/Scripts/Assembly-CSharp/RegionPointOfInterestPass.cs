using System.Collections;
using System.Collections.Generic;
using PajamaLlama.Flotsam.Procedural;
using UnityEngine;
using UnityEngine.PajamaLlama;

[CreateAssetMenu(fileName = "Region POI Pass", menuName = "Flotsam/Procedural Generation/Region POI Pass", order = 3)]
public class RegionPointOfInterestPass : TileGeneratorPass
{
	[SerializeField]
	[NamedArrayElement("_region", "_pollutionLevel", " - ")]
	private RegionPointOfInterestSettings[] _regionSettings;

	private RegionPointOfInterestSettings _activeSettings;

	private TileGeneratorRegion _region;

	private float _density;

	private int _totalPOICount;

	private RegionPassGroup _regionPassGroup;

	public int SpawnCount => _totalPOICount;

	public void Initialize(TileGenerator generator)
	{
		InitializeGeneratedNodes(generator.Regions.Count * 16);
	}

	public bool InitializeRegion(TileGeneratorRegion region)
	{
		if (TryReturnRegionSettings(region, out _activeSettings))
		{
			_region = region;
			_activeSettings.Initialize();
			_density = _activeSettings.ReturnRandomizedDensity();
			_totalPOICount = Mathf.RoundToInt(region.ReturnSurface() / _density);
			return true;
		}
		_activeSettings = null;
		return false;
	}

	public override IEnumerator Run(TileGenerator generator, IRegion dataRegion)
	{
		Dictionary<PajamaLlama.Flotsam.World.IWorldRegion, TileGeneratorRegion>.Enumerator enumerator = generator.Regions.GetEnumerator();
		Initialize(generator);
		while (enumerator.MoveNext())
		{
			TileGeneratorRegion value = enumerator.Current.Value;
			if ((dataRegion == null || value.IsRegion(dataRegion)) && InitializeRegion(value))
			{
				int count = Mathf.Min(_totalPOICount, Mathf.RoundToInt(_activeSettings.LandmarkRatio.ReturnRandom() * (float)value.Landmarks.Count));
				int num = DistributeLandmarkFlotsam(generator, value, count);
				DistributeRestFlotsam(generator, value, _totalPOICount - num);
			}
		}
		yield break;
	}

	public void Run(RegionPassGroup regionPasses, TileGeneratorRegion region)
	{
		if (_activeSettings != null)
		{
			_regionPassGroup = regionPasses;
			int count = Mathf.Min(_totalPOICount, Mathf.RoundToInt(_activeSettings.LandmarkRatio.ReturnRandom() * (float)region.Landmarks.Count));
			int num = DistributeLandmarkFlotsam(regionPasses.Generator, region, count);
			DistributeRestFlotsam(regionPasses.Generator, region, _totalPOICount - num);
		}
	}

	private int DistributeLandmarkFlotsam(TileGenerator generator, TileGeneratorRegion region, int count)
	{
		int num = 0;
		using ListPool<TileGeneratorNode>.List list = ListPool<TileGeneratorNode>.Get(region.Landmarks);
		while (num < count && 0 < list.Count)
		{
			float num2 = 0f;
			int count2 = list.Count;
			while (0 < count2--)
			{
				TileGeneratorNode tileGeneratorNode = list[count2];
				if (tileGeneratorNode.TrySetLeafChance(_activeSettings))
				{
					num2 += tileGeneratorNode.LeafChance;
				}
				else
				{
					list.RemoveAt(count2);
				}
			}
			float num3 = Random.Range(0f, num2);
			float num4 = 0f;
			float num5 = 0f;
			int count3 = list.Count;
			while (0 < count3--)
			{
				TileGeneratorNode tileGeneratorNode = list[count3];
				num5 = num4 + tileGeneratorNode.LeafChance;
				if (num4 <= num3 && num3 < num5)
				{
					if (TryGenerateLandmarkFlotsamNode(out var node, region, tileGeneratorNode))
					{
						AddGeneratedNode(node, generator);
						num++;
					}
					else
					{
						list.RemoveAt(0);
					}
					break;
				}
				num4 = num5;
			}
		}
		return num;
	}

	protected bool TryGenerateLandmarkFlotsamNode(out TileGeneratorNode node, TileGeneratorRegion region, TileGeneratorNode parent, int sampleLimit = 10)
	{
		while (0 < sampleLimit)
		{
			Vector2 position = parent.Position + PoissonDiskPass.ReturnRandomOnCircle(_activeSettings.LandmarkSpawnRange.ReturnRandom());
			if (TryGenerateNode(out node, region, position))
			{
				return true;
			}
			sampleLimit--;
		}
		node = null;
		return false;
	}

	private int DistributeRestFlotsam(TileGenerator generator, TileGeneratorRegion region, int count)
	{
		if (_activeSettings.UseRegionPassesCells && _regionPassGroup != null)
		{
			RegionPassCells cells = _regionPassGroup.Cells;
			cells.SetSpawnChanceCurve(_activeSettings.RestFlotsamChancesCurve);
			return cells.DistributeNodes(generator, count, GenerateRestFlotsamNode);
		}
		using RegionPassCells regionPassCells = GetPassCells(_activeSettings, region);
		if (_activeSettings.CellSettings.CountExistingNodes)
		{
			regionPassCells.CountExistingNodes(region);
		}
		regionPassCells.SetSpawnChanceCurve(_activeSettings.RestFlotsamChancesCurve);
		return regionPassCells.DistributeNodes(generator, count, GenerateRestFlotsamNode);
	}

	private void GenerateRestFlotsamNode(Vector2 position)
	{
		TileGeneratorNode tileGeneratorNode = new TileGeneratorNode(position, null, isLeaf: true);
		tileGeneratorNode.SetSpawner(new PointOfInterestSpawner(_activeSettings.ReturnPointOfInterestProperties(), tileGeneratorNode.WorldPosition));
		_region.AddNode(tileGeneratorNode);
		_region.Generator.AddNode(tileGeneratorNode);
	}

	private bool TryGenerateNode(out TileGeneratorNode node, TileGeneratorRegion region, Vector2 position)
	{
		if (region.ReturnIsValidPosition(position, _activeSettings.LandmarkSpawnRange.Minimum))
		{
			node = new TileGeneratorNode(position, null, isLeaf: true);
			node.SetSpawner(new PointOfInterestSpawner(_activeSettings.ReturnPointOfInterestProperties(), node.WorldPosition));
			region.AddNode(node);
			return true;
		}
		node = null;
		return false;
	}

	public bool TryReturnRegionSettings(IRegion region, out RegionPointOfInterestSettings settings)
	{
		using ListPool<RegionPointOfInterestSettings>.List list = ListPool<RegionPointOfInterestSettings>.Get();
		RegionPointOfInterestSettings[] regionSettings = _regionSettings;
		foreach (RegionPointOfInterestSettings regionPointOfInterestSettings in regionSettings)
		{
			if (region.Type == regionPointOfInterestSettings.Region)
			{
				list.Add(regionPointOfInterestSettings);
			}
		}
		settings = null;
		if (0 < list.Count)
		{
			Sorting.SlowSort(list, CompareSettings);
			for (int j = 0; j < list.Count; j++)
			{
				settings = list[j];
				if (settings.PullutionLevel >= region.PollutionLevel)
				{
					break;
				}
			}
		}
		return settings != null;
	}

	public RegionPassCells GetPassCells(RegionPointOfInterestSettings settings, IRegion region)
	{
		float num = Mathf.Sqrt(_density);
		return RegionPassCells.GetFromPool(cellSize: new Vector2(num, num), settings: settings.CellSettings, region: region);
	}

	private int CompareSettings(RegionPointOfInterestSettings left, RegionPointOfInterestSettings right)
	{
		return left.PullutionLevel - right.PullutionLevel;
	}
}
