using System;
using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
	[SerializeField]
	private TrackPoolManager trackPoolManager;

	[SerializeField]
	private TrackEventManager trackEventManager;

	[SerializeField]
	private Dictionary<int, Track> activeTracks;

	private int ahead = 2;

	private int behind = 3;

	[SerializeField]
	private Track hubTrack;

	public bool IsMotionBlurEnabled;

	public bool forceLoadHUB;

	[NonSerialized]
	public Queue<bool> isNextTurnFake;

	private int trainIndex;

	private int left;

	private int right;

	private SpriteRenderer craneSr;

	[SerializeField]
	private List<Sprite> craneArt;

	[Header("World Terrain Obstacles")]
	[Header("Obstacle Container Prefabs")]
	public SerializedDictionary<int, GameObject> worldObstacleContainers;

	[Header("Random Obstacles")]
	public SerializedDictionary<int, float> worldRandomObstacleChances;

	public SerializedDictionary<int, Vector2> worldRandomObstaclesDensityRange;

	public SerializedDictionary<int, TrackObstacleWithChance[]> worldRandomObstacleObjects;

	[Header("Fixed Obstacles")]
	public SerializedDictionary<int, float> worldFixedObstacleChances;

	public SerializedDictionary<int, Vector2> worldFixedObstaclesDensity;

	public SerializedDictionary<int, TrackObstacleWithChance[]> worldFixedObstacleObjects;

	[Header("Over Track Obstacles")]
	public SerializedDictionary<int, float> worldOverTrackObstacleChances;

	public SerializedDictionary<int, GameObject> worldOverTrackObstacleObjects;

	[SerializeField]
	private List<GameObject> minigameTrackPrefabs;

	private int trackPrefabIterator;

	private bool removeNextTurnEventTracks;

	private int turnTracksIterator;

	[NonSerialized]
	public bool destroyNextResourceBox;

	[SerializeField]
	private GameObject parallaxBackground;

	public static TrackManager Instance { get; private set; }

	public Transform PlatformTf { get; private set; }

	public GameObject ObstacleGO { get; private set; }

	public GameObject CraneGO { get; private set; }

	public bool DestroyNextObstacle { get; set; }

	[field: SerializeField]
	[field: Range(0f, 1f)]
	public float ChanceForFakeTurns { get; private set; }

	[field: SerializeField]
	[field: Range(0f, 1f)]
	public float ChanceForFakeResources { get; private set; }

	public event Action<TrackTypes> OnNewTrackSet;

	public event Action OnSwitchingToOtherPath;

	public event Action OnReturningToStraightPath;

	private void Awake()
	{
		Instance = this;
		activeTracks = new Dictionary<int, Track>();
		isNextTurnFake = new Queue<bool>();
	}

	private void Start()
	{
		LevelManager.Instance.LevelCompleted += OnLevelSlowing;
		ZoneManager.Instance.OnZoneLoaded += HandleNewZone;
		LevelManager.Instance.LevelCompleted += delegate
		{
			isNextTurnFake.Clear();
		};
	}

	private void OnDestroy()
	{
		LevelManager.Instance.LevelCompleted -= OnLevelSlowing;
		ZoneManager.Instance.OnZoneLoaded -= HandleNewZone;
	}

	private void HandleNewZone(int zoneIndex)
	{
		GameObject[] allTracks = trackPoolManager.GetAllTracks();
		for (int i = 0; i < allTracks.Length; i++)
		{
			allTracks[i].GetComponent<Track>()?.SetObstacleContainer(worldObstacleContainers[zoneIndex]);
		}
	}

	private void Update()
	{
		if (GameManager.Instance.IsJourneyStarted)
		{
			trainIndex = Mathf.FloorToInt(Train.Instance.GlobalDistance / 4.8f);
			left = trainIndex - behind;
			right = trainIndex + ahead;
			TryLoadTracks();
			TryUnloadTracks();
			UpdateTrackPositions();
			UpdateTrackBlur();
		}
	}

	private void UpdateTrackBlur()
	{
		if (activeTracks.Count != 0)
		{
			float num = Train.Instance.TrainSpeedNormalized * 0.01f;
			Shader.SetGlobalFloat("_BlurIntensityHoriz", IsMotionBlurEnabled ? num : 0f);
			Shader.SetGlobalFloat("_BlurIntensityVert", 0f);
		}
	}

	private void UpdateTrackPositions()
	{
		if (activeTracks.Count == 0)
		{
			return;
		}
		float num = (0f - Train.Instance.GlobalDistance) % 4.8f;
		foreach (KeyValuePair<int, Track> activeTrack in activeTracks)
		{
			float num2 = (float)(activeTrack.Key - trainIndex) * 4.8f;
			activeTrack.Value.transform.position = new Vector3(num2 + num + 2.4f, activeTrack.Value.transform.position.y, 0f);
		}
	}

	private void TryLoadTracks()
	{
		try
		{
			for (int i = left; i < right; i++)
			{
				if (!activeTracks.TryGetValue(i, out var _))
				{
					LoadTrack(i);
				}
			}
		}
		catch (Exception ex)
		{
			Debug.LogError(ex.Message);
		}
	}

	private void LoadTrack(int i)
	{
		if (i <= 0)
		{
			return;
		}
		if (GameManager.Instance.minigameTracksReady)
		{
			LoadTracksForMinigame(i);
			return;
		}
		int currentZoneIndex = ZoneManager.Instance.CurrentZoneIndex;
		TrackTypes trackTypes = LevelUtils.GetTrackTypeAtGlobalIndex(i);
		if (removeNextTurnEventTracks && (trackTypes == TrackTypes.SDL || trackTypes == TrackTypes.SDR || trackTypes == TrackTypes.DLS || trackTypes == TrackTypes.DRS || trackTypes == TrackTypes.DRDR || trackTypes == TrackTypes.DLDL || trackTypes == TrackTypes.DLODL || trackTypes == TrackTypes.DRODR))
		{
			turnTracksIterator = 6;
			removeNextTurnEventTracks = false;
		}
		if (turnTracksIterator > 0)
		{
			trackTypes = TrackTypes.SS;
			turnTracksIterator--;
			if (turnTracksIterator == 1)
			{
				DestroyNextObstacle = false;
			}
		}
		GameObject trackByType = trackPoolManager.GetTrackByType(trackTypes);
		if (trackTypes == TrackTypes.Yard)
		{
			PlatformTf = trackByType.transform;
		}
		else if (i == 2)
		{
			return;
		}
		trackEventManager.HandleResourceEvent(i, trackByType);
		Track component = trackByType.GetComponent<Track>();
		component.gameObject.SetActive(value: true);
		component.TrackSet();
		activeTracks.Add(i, component);
		if (trackTypes != TrackTypes.Hub)
		{
			component.gameObject.SetActiveRecursive(active: true);
		}
		if (isNextTurnFake.Count > 0)
		{
			Train.Instance.isNextTurnFake = isNextTurnFake.Peek();
		}
		if (trackTypes == TrackTypes.DRODR || trackTypes == TrackTypes.DLODL)
		{
			bool isTrap = isNextTurnFake.Dequeue();
			ObstacleGO = trackByType.gameObject.GetComponent<TrackWithObstacle>().SetupObstacle(isTrap);
			ObstacleGO.GetComponent<TrackObstacle>().SetSprite(currentZoneIndex);
			ObstacleGO.GetComponent<TrackObstacle>().isNextTurnFake = isTrap;
			ObstacleGO.GetComponent<ExplodeSprite>().SetSprite(ObstacleGO.GetComponent<SpriteRenderer>().sprite);
			if (DestroyNextObstacle)
			{
				ObstacleGO.SetActive(value: false);
			}
		}
		if ((bool)component.ObstacleCointainer && i > 2)
		{
			component.ObstacleCointainer.SetObstacles();
		}
		switch (trackTypes)
		{
		case TrackTypes.Yard:
			component.gameObject.SetActiveRecursive(active: true);
			component.gameObject.GetComponent<TrackYard>().SetupYard();
			CraneGO = trackByType.transform.Find("Background_Wagon_Yard_Crane")?.gameObject;
			craneSr = CraneGO.GetComponent<SpriteRenderer>();
			SetCraneSprite(ZoneManager.Instance.CurrentZoneIndex);
			break;
		case TrackTypes.YardBefore:
			component.gameObject.GetComponent<TrackYardBefore>().SetupPreYard();
			break;
		}
		SetTrackSprite(component, trackTypes);
		this.OnNewTrackSet?.Invoke(trackTypes);
	}

	public void DestroyTrackResources()
	{
		trackEventManager.DestroyResources();
	}

	private void SetTrackSprite(Track track, TrackTypes trackType)
	{
		string key = trackType switch
		{
			TrackTypes.DRODR => "DRDR", 
			TrackTypes.DLODL => "DLDL", 
			_ => trackType.ToString(), 
		};
		if (!ZoneManager.Instance.CurrentZone.SpriteDict.TryGetValue(key, out var value))
		{
			return;
		}
		track.trackType = trackType;
		SpriteRenderer componentInChildren = track.GetComponentInChildren<SpriteRenderer>();
		if (componentInChildren != null)
		{
			bool activeSelf = track.gameObject.activeSelf;
			if (!activeSelf)
			{
				track.gameObject.SetActive(value: true);
			}
			componentInChildren.sprite = value;
			if (!activeSelf)
			{
				track.gameObject.SetActive(value: false);
			}
		}
	}

	private void TryUnloadTracks()
	{
		for (int i = 0; i < activeTracks.Count; i++)
		{
			int num = activeTracks.Keys.ElementAt(i);
			if (activeTracks.TryGetValue(activeTracks.Keys.ElementAt(i), out var value) && (num < left || num > right))
			{
				value.gameObject.SetActive(value: false);
				activeTracks.Remove(num);
			}
		}
	}

	public Track GetTrackAtDistance(float distance)
	{
		int key = Mathf.FloorToInt(distance / 4.8f);
		activeTracks.TryGetValue(key, out var value);
		return value;
	}

	private void OnLevelSlowing()
	{
		DestroyNextObstacle = false;
	}

	public void DestroyObstacle()
	{
		GameObject obstacleGO = ObstacleGO;
		if ((bool)obstacleGO)
		{
			obstacleGO.SetActive(value: false);
		}
		else
		{
			DestroyNextObstacle = true;
		}
	}

	public void SetCraneSprite(int i)
	{
		if (i < craneArt.Count)
		{
			craneSr.sprite = craneArt[i];
		}
	}

	public void HideHub()
	{
		hubTrack.gameObject.SetActive(value: false);
	}

	public void ShowHub()
	{
		hubTrack.gameObject.SetActive(value: true);
	}

	public void LoadTracksForMinigame(int i)
	{
		Track component = minigameTrackPrefabs[trackPrefabIterator].GetComponent<Track>();
		component.gameObject.SetActive(value: true);
		activeTracks.Add(i, component);
		SetTrackSprite(component, TrackTypes.TEST);
		this.OnNewTrackSet?.Invoke(TrackTypes.TEST);
		trackPrefabIterator++;
		if (trackPrefabIterator >= minigameTrackPrefabs.Count)
		{
			EndTrackMinigame();
		}
	}

	public void EndTrackMinigame()
	{
		GameManager.Instance.ringMinigame.EndMinigame();
		trackPrefabIterator = 0;
	}

	public void RemoveNextTurnEvent()
	{
		DestroyNextObstacle = true;
		removeNextTurnEventTracks = true;
		if (LevelManager.Instance.CurrentLevel.Switches.Count > 0 && !TrackEventSwitch.IsTurnSignalActivated)
		{
			LevelManager.Instance.CurrentLevel.Switches[0].EndEvent();
			LevelManager.Instance.CurrentLevel.Switches.RemoveAt(0);
		}
	}

	public void RemoveNextResourceEvent()
	{
		DestroyTrackResources();
		destroyNextResourceBox = true;
		if (LevelManager.Instance.CurrentLevel.Resources.Count > 0 && !TrackEventResource.isResourceSignalActivated)
		{
			LevelManager.Instance.CurrentLevel.Resources[0].EndEvent();
			LevelManager.Instance.CurrentLevel.Resources.RemoveAt(0);
		}
	}

	public void SwitchToOtherTrack()
	{
		this.OnSwitchingToOtherPath?.Invoke();
	}

	public void ReturnToStraightPath()
	{
		this.OnReturningToStraightPath?.Invoke();
	}

	public void ShowParallaxBackground(bool show)
	{
		parallaxBackground.SetActive(show);
	}
}
