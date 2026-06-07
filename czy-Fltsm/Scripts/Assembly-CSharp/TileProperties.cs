using System;
using M4.Session;
using PajamaLlama;
using PajamaLlama.Flotsam.World;
using UnityEngine;
using UnityEngine.PajamaLlama;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Flotsam/Map/TileProperties")]
public class TileProperties : PersistentProperties
{
	[Serializable]
	private struct RegionLandmarkBehaviourCollection
	{
		public WorldRegionType Region;

		public LandmarkBehaviourCollection LandmarkBehaviourCollection;
	}

	[SerializeField]
	private GameMode _gameMode;

	[SerializeField]
	private TileGenerator _tileGenerator;

	[SerializeField]
	private TileGeneratorBase _tutorialTileGenerator;

	[SerializeField]
	private TileGeneratorBase[] _startSubTileGenerators;

	[SerializeField]
	[FormerlySerializedAs("_tileGenerators")]
	private TileGeneratorBase[] _subTileGenerators;

	[Space]
	[Range(0f, 1f)]
	[SerializeField]
	[FormerlySerializedAs("MapOverlayWeight")]
	private float _mapOverlayWeight;

	[SerializeField]
	[FormerlySerializedAs("IsCorridor")]
	private bool _isCorridor;

	[SerializeField]
	[Range(2f, 4f)]
	private int _preferredActiveTileCount = 4;

	[SerializeField]
	[Range(5f, 10f)]
	private int _maximumActiveTileCount = 7;

	[Header("Spawning")]
	[SerializeField]
	[NamedArrayElement(new string[] { "Region" })]
	private RegionLandmarkBehaviourCollection[] _rescueLandmarkBehaviourCollections;

	[SerializeField]
	private FallbackWorldTileProvider _fallbackWorldTileProvider;

	public override Types Type => Types.TileProperties;

	public GameMode GameMode => _gameMode;

	public TileGenerator TileGenerator => _tileGenerator;

	public TileGeneratorBase[] TileGenerators => _subTileGenerators;

	public float MapOverlayWeight => _mapOverlayWeight;

	public bool IsCorridor => _isCorridor;

	public int PreferredActiveTileCount => _preferredActiveTileCount;

	public int MaximumActiveTileCount => _maximumActiveTileCount;

	public FallbackWorldTileProvider FallbackWorldTileProvider => _fallbackWorldTileProvider;

	public TileGeneratorBase ReturnStartSubTileGenerator()
	{
		if (Session.Profile.ActiveRun.IsTutorial)
		{
			if (_tutorialTileGenerator != null)
			{
				return _tutorialTileGenerator;
			}
			Debug.LogError("Unable to return tutorial start tile!");
		}
		return _startSubTileGenerators[UnityEngine.Random.Range(0, _startSubTileGenerators.Length)];
	}

	public WorldTile ReturnRandomWorldTile(ILandmarkPicker landmarkPicker = null)
	{
		if (_subTileGenerators.IsNullOrEmpty())
		{
			return null;
		}
		if (landmarkPicker == null)
		{
			return new WorldTile(TileGenerator, _subTileGenerators.GetRandom());
		}
		using ListPool<TileGeneratorBase>.List list = ListPool<TileGeneratorBase>.Get();
		TileGeneratorBase[] subTileGenerators = _subTileGenerators;
		foreach (TileGeneratorBase tileGeneratorBase in subTileGenerators)
		{
			if (!landmarkPicker.CanPickFrom(tileGeneratorBase))
			{
				list.Add(tileGeneratorBase);
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		return new WorldTile(TileGenerator, list.GetRandom());
	}

	public static bool TryReturnDebugTileProperties(out TileProperties tileProperties)
	{
		TileGeneratorBase objectReference = DebugEnvironmentVariables.GetObjectReference<TileGeneratorBase>(DebugEnvironmentVariable.TileGenerator);
		if (objectReference != null)
		{
			tileProperties = ScriptableObject.CreateInstance<TileProperties>();
			tileProperties._startSubTileGenerators = new TileGeneratorBase[1] { objectReference };
			return true;
		}
		tileProperties = DebugEnvironmentVariables.GetObjectReference<TileProperties>(DebugEnvironmentVariable.TileProperties);
		return tileProperties != null;
	}

	public LandmarkBehaviour ReturnLandmarkBehaviour(IWorldRegion region)
	{
		RegionLandmarkBehaviourCollection[] rescueLandmarkBehaviourCollections = _rescueLandmarkBehaviourCollections;
		for (int i = 0; i < rescueLandmarkBehaviourCollections.Length; i++)
		{
			RegionLandmarkBehaviourCollection regionLandmarkBehaviourCollection = rescueLandmarkBehaviourCollections[i];
			if (regionLandmarkBehaviourCollection.Region == region.Type)
			{
				return regionLandmarkBehaviourCollection.LandmarkBehaviourCollection.ReturnLandmarkBehaviour(region.Type);
			}
		}
		RegionLandmarkBehaviourCollection random = _rescueLandmarkBehaviourCollections.GetRandom();
		Debug.LogWarning($"No rescue landmark behaviour collection found for region '{region.Type}', falling back on '{random.LandmarkBehaviourCollection}'");
		return random.LandmarkBehaviourCollection.ReturnLandmarkBehaviour(WorldRegionType.Any);
	}
}
