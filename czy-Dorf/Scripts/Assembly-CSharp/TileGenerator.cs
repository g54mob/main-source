using System;
using System.Collections.Generic;
using System.Linq;
using Dorfromantik;
using UnityEngine;
using UnityEngine.Serialization;

public class TileGenerator : ScriptableObject
{
	private sealed class _003C_003Ec__DisplayClass33_0
	{
		public ElementGroupSegmentInformation otherSegmentInfo;

		internal bool _003CGenerateTile_003Eb__4(GroupTypeConfiguration x)
		{
			return x.groupType == otherSegmentInfo.GroupType;
		}

		internal bool _003CGenerateTile_003Eb__5(GroupTypeConfiguration x)
		{
			return x.groupType == otherSegmentInfo.GroupType;
		}
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<GroupTypeConfiguration, bool> _003C_003E9__33_1;

		public static Func<GroupTypeConfiguration, GroupTypeConfiguration> _003C_003E9__33_2;

		public static Func<GroupTypeConfiguration, float> _003C_003E9__33_3;

		public static Func<ElementGroupSegmentInformation, SegmentData002> _003C_003E9__33_0;

		internal bool _003CGenerateTile_003Eb__33_1(GroupTypeConfiguration x)
		{
			return x.probabilityInPercent != 0f;
		}

		internal GroupTypeConfiguration _003CGenerateTile_003Eb__33_2(GroupTypeConfiguration x)
		{
			return x;
		}

		internal float _003CGenerateTile_003Eb__33_3(GroupTypeConfiguration x)
		{
			return x.probabilityInPercent;
		}

		internal SegmentData002 _003CGenerateTile_003Eb__33_0(ElementGroupSegmentInformation x)
		{
			return x.segmentData;
		}
	}

	[SerializeField]
	private Tile tilePrefab;

	[SerializeField]
	[FormerlySerializedAs("biomeConfiguration")]
	private TileGenConfiguration configuration;

	[FormerlySerializedAs("atLeastOneEmptyEdgeForXTurns")]
	[SerializeField]
	private int atLeastTwoEmptyEdgesForXTurns = 5;

	[SerializeField]
	private TileFactory tileFactory;

	[SerializeField]
	private QuestManager questManager;

	[SerializeField]
	private QuestTileGenerator questTileGenerator;

	[SerializeField]
	private ElementGroupSegmentAdaptor elementGroupSegmentAdaptor;

	[SerializeField]
	private SpecialTileGenerator specialTileGenerator;

	[SerializeField]
	private List<int> debug_RandomValues = new List<int> { 0, 0, 0, 0, 0, 0 };

	private int _003CTileGenerationSeed_003Ek__BackingField;

	private int _003CGeneratedQuestCount_003Ek__BackingField;

	public int debug_OverwriteSeed = -1;

	private int generatedTileCount;

	private int tileSeedIncrementStep;

	public int TileGenerationSeed
	{
		get
		{
			return _003CTileGenerationSeed_003Ek__BackingField;
		}
		private set
		{
			_003CTileGenerationSeed_003Ek__BackingField = value;
		}
	}

	public int GeneratedQuestCount
	{
		get
		{
			return _003CGeneratedQuestCount_003Ek__BackingField;
		}
		private set
		{
			_003CGeneratedQuestCount_003Ek__BackingField = value;
		}
	}

	public int GeneratedTileCount => generatedTileCount;

	public int TileGenerationStep => tileSeedIncrementStep;

	public TileGenConfiguration Configuration => configuration;

	public event Action<Tile> OnTileGenerated;

	public void SetSeed(int seed)
	{
		TileGenerationSeed = seed;
		UnityEngine.Random.InitState(seed);
		tileSeedIncrementStep = UnityEngine.Random.Range(-100000, 100000);
		Randomizer.RandomizeSeed();
	}

	public void Setup(SaveGameData_003 loadedGame = null)
	{
		if (loadedGame != null && loadedGame.generatedTileCount == 0)
		{
			generatedTileCount = loadedGame.tiles.Count + loadedGame.tileStack.Count;
		}
		else
		{
			generatedTileCount = loadedGame?.generatedTileCount ?? 0;
		}
		TileGenerationSeed = loadedGame?.preplacedTileSeed ?? ((debug_OverwriteSeed == -1) ? Randomizer.GetRandomSeed() : debug_OverwriteSeed);
		UnityEngine.Random.InitState(TileGenerationSeed);
		tileSeedIncrementStep = UnityEngine.Random.Range(-100000, 100000);
		Randomizer.RandomizeSeed();
		GeneratedQuestCount = loadedGame?.generatedQuestCount ?? 0;
	}

	public void SetConfiguration(TileGenConfiguration targetConfiguration)
	{
		configuration = targetConfiguration;
	}

	public Tile GenerateBaseTile(int seed = -1, string tileName = "Stacked Tile")
	{
		Tile tile = UnityEngine.Object.Instantiate(tilePrefab);
		tile.name = $"{tileName} {generatedTileCount}";
		tile.InitializeSeed(seed);
		return tile;
	}

	public Tile GenerateTile(Tile baseTile, float overwriteQuestProbability = -1f)
	{
		if (baseTile == null)
		{
			baseTile = GenerateBaseTile();
		}
		int num = TileGenerationSeed + (generatedTileCount - GeneratedQuestCount) * tileSeedIncrementStep;
		generatedTileCount++;
		baseTile.InitializeSeed(num);
		TileGenFilter usedFilter = ((generatedTileCount <= atLeastTwoEmptyEdgesForXTurns) ? TileGenFilter.AtLeastTwoEmptyEdges : TileGenFilter.None);
		UnityEngine.Random.InitState(TileGenerationSeed + generatedTileCount * tileSeedIncrementStep);
		float value = UnityEngine.Random.value;
		if ((overwriteQuestProbability >= 0f && value <= overwriteQuestProbability) || (overwriteQuestProbability < 0f && value <= questManager.Configuration.QuestTileProbability(questManager.ActiveQuestCount)))
		{
			int seed = TileGenerationSeed + GeneratedQuestCount * tileSeedIncrementStep;
			GeneratedQuestCount++;
			QuestTile questTile = questTileGenerator.GenerateQuestTile(seed, usedFilter);
			this.OnTileGenerated?.Invoke(questTile);
			return questTile;
		}
		UnityEngine.Random.InitState(num);
		TilePresetConfiguration tilePresetConfiguration = Randomizer.SelectWeightedRandom(configuration.GetFilteredTilePresets(usedFilter));
		TilePreset component = tilePresetConfiguration.tilePreset.GetComponent<TilePreset>();
		List<ElementGroupSegmentInformation> list = new List<ElementGroupSegmentInformation>();
		List<int> list2 = new List<int>();
		foreach (SegmentPresetInfo segmentProbability in tilePresetConfiguration.segmentProbabilities)
		{
			SegmentType segmentType = segmentProbability.segmentType;
			ElementGroupSegmentInformation elementGroupSegmentInformation = new ElementGroupSegmentInformation
			{
				index = list.Count,
				segmentType = segmentProbability.segmentType,
				segmentData = new SegmentData002
				{
					segmentType = segmentType.id
				}
			};
			int num2 = -1;
			List<int> list3 = ElementGroupSegmentAdaptor.RotationsToFitOnTile(segmentType.edges, list2);
			if (component.generateSegmentsWithoutSpaces && list2.Count > 0)
			{
				num2 = list3[0];
			}
			else
			{
				if (list3.Count == 0)
				{
					Debug.LogError($"no place for segment {segmentType} on tile {baseTile}, preset {component}", baseTile);
				}
				num2 = list3[UnityEngine.Random.Range(0, list3.Count)];
			}
			List<int> occupiedEdges = GridCalculator.RotateDirections(segmentType.edges, num2);
			elementGroupSegmentInformation.segmentData.rotation = num2;
			elementGroupSegmentInformation.occupiedEdges = occupiedEdges;
			List<GroupTypeConfiguration> source = new List<GroupTypeConfiguration>(Enumerable.Where(segmentProbability.possibleTypes, (GroupTypeConfiguration x) => x.probabilityInPercent != 0f));
			Dictionary<GroupTypeConfiguration, float> dictionary = Enumerable.ToDictionary(source, (GroupTypeConfiguration x) => x, (GroupTypeConfiguration x) => x.probabilityInPercent);
			if (list.Count > 0)
			{
				using List<ElementGroupSegmentInformation>.Enumerator enumerator2 = list.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					_003C_003Ec__DisplayClass33_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass33_0();
					CS_0024_003C_003E8__locals5.otherSegmentInfo = enumerator2.Current;
					if (CS_0024_003C_003E8__locals5.otherSegmentInfo.GroupType.constraining)
					{
						foreach (GroupTypeConfiguration item in Enumerable.ToList(Enumerable.Where(source, (GroupTypeConfiguration x) => x.groupType == CS_0024_003C_003E8__locals5.otherSegmentInfo.GroupType)))
						{
							dictionary.Remove(item);
						}
					}
					else
					{
						if (!SegmentsAdjacent(CS_0024_003C_003E8__locals5.otherSegmentInfo, elementGroupSegmentInformation))
						{
							continue;
						}
						foreach (GroupTypeConfiguration item2 in Enumerable.ToList(Enumerable.Where(source, (GroupTypeConfiguration x) => x.groupType == CS_0024_003C_003E8__locals5.otherSegmentInfo.GroupType)))
						{
							dictionary.Remove(item2);
						}
					}
				}
			}
			if (dictionary.Count == 0)
			{
				continue;
			}
			if (ListHelper.Sum(Enumerable.ToList(dictionary.Values)) <= 0.0001f)
			{
				Debug.Log("total groupTypeProbability = 0, skip segment");
				continue;
			}
			elementGroupSegmentInformation.GroupType = Randomizer.SelectWeightedRandom(dictionary).groupType;
			HybridSegmentVariant hybridSegmentVariant = elementGroupSegmentInformation.GroupType.HybridSegmentForSegmentType(segmentType);
			float value2 = UnityEngine.Random.value;
			if (hybridSegmentVariant != null && value2 <= hybridSegmentVariant.hybridProbability)
			{
				elementGroupSegmentInformation.segmentType = hybridSegmentVariant.hybridType;
				elementGroupSegmentInformation.segmentData.segmentType = hybridSegmentVariant.hybridType.id;
			}
			list2.AddRange(elementGroupSegmentInformation.occupiedEdges);
			list.Add(elementGroupSegmentInformation);
		}
		Randomizer.RandomizeSeed();
		tileFactory.CreateTile(baseTile, Enumerable.ToList(Enumerable.Select(list, (ElementGroupSegmentInformation x) => x.segmentData)));
		baseTile.Initialize();
		this.OnTileGenerated?.Invoke(baseTile);
		return baseTile;
	}

	private bool SegmentsAdjacent(ElementGroupSegmentInformation segment1, ElementGroupSegmentInformation segment2)
	{
		foreach (int occupiedEdge in segment1.occupiedEdges)
		{
			foreach (int occupiedEdge2 in segment2.occupiedEdges)
			{
				int num = Mathf.Abs(occupiedEdge - occupiedEdge2);
				if (num == 1 || num == 5)
				{
					return true;
				}
			}
		}
		return false;
	}

	public Tile CreateTileFromSaveData(TileData_003 tileData)
	{
		if (tileData.questTileData != null && tileData.questTileData.questTileId != QuestTileId.Undefined)
		{
			return questTileGenerator.SetupLoadedQuestTile(tileData);
		}
		if (tileData.specialTileId != SpecialTileId.Undefined)
		{
			return specialTileGenerator.SetupSpecialTile(tileData);
		}
		Tile tile = GenerateBaseTile(tileData.seed, "Loaded Tile");
		tileFactory.CreateTile(tile, tileData.segments);
		return tile;
	}

	public Tile GenerateDuplicate(Tile pickedTile)
	{
		return CreateTileFromSaveData(new TileData_003(pickedTile));
	}

	public void RevertGeneratedTileCount(Tile tileToDelete)
	{
		if (tileToDelete is QuestTile)
		{
			GeneratedQuestCount--;
		}
		generatedTileCount--;
	}

	public void SetGeneratedTileCount(int generatedTileCount, int generatedQuestCount)
	{
		this.generatedTileCount = generatedTileCount;
		GeneratedQuestCount = generatedQuestCount;
	}
}
