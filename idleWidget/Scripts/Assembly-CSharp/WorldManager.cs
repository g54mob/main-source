using System.Collections.Generic;
using Assets.Behaviour.Util;
using Assets.Source.Player;
using Assets.Source.Util;
using Assets.Source.World;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
	private Dictionary<string, FramePrefabSet> _indexedPrefabs = new Dictionary<string, FramePrefabSet>();

	private List<FramePrefabSet> _orderedPrefabs = new List<FramePrefabSet>();

	private ActiveWorldFrame _activeFrame;

	private bool _prefabsSorted;

	public static WorldManager Instance { get; private set; }

	public IEnumerable<FramePrefabSet> OrderedFramePrefabs
	{
		get
		{
			if (!_prefabsSorted)
			{
				_orderedPrefabs.Sort(delegate(FramePrefabSet a, FramePrefabSet b)
				{
					WorldFrame preview = a.GetPreview();
					WorldFrame preview2 = b.GetPreview();
					return (preview.Tier == preview2.Tier) ? preview.Identifier.CompareTo(preview2.Identifier) : (preview.Tier - preview2.Tier);
				});
				_prefabsSorted = true;
			}
			return _orderedPrefabs;
		}
	}

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		new TechNode("");
		Application.targetFrameRate = 120;
		if (GamePlayer.Current == null)
		{
			SaveGame.LoadLatestSave();
		}
		if (SteamManager.Initialized)
		{
			SteamStatsManager.Init();
		}
		GameUI.Instance.UpdateConstructionButton();
		GamePlayer current = GamePlayer.Current;
		foreach (WorldFrame frame in current.Map.Frames)
		{
			frame.UpdatePlacementBonus();
		}
		ShowFrame(current.Map.GetFrame(current.RecentMapPosition), !current.RecentInOverview);
		if (current.RecentInOverview)
		{
			GameUI.Instance.ShowFullScreenUI(OverviewUI.Instance);
		}
	}

	public FramePrefabSet GetFramePrefabSet(string name)
	{
		return _indexedPrefabs[name];
	}

	public void AddFramePrefabSet(FramePrefabSet prefabs)
	{
		_indexedPrefabs[prefabs.gameObject.name] = prefabs;
		_orderedPrefabs.Add(prefabs);
	}

	public void Update()
	{
	}

	public void ShowFrame(WorldFrame frame, bool showUI)
	{
		if (frame != _activeFrame?.ActiveFrame)
		{
			FrameUI.Instance?.Clear();
			if (_activeFrame != null)
			{
				_activeFrame.ClearActive();
				Object.Destroy(_activeFrame.gameObject);
				_activeFrame = null;
			}
			GamePlayer.Current.RecentMapPosition = frame.Position;
			ActiveWorldFrame activeWorldFrame = Object.Instantiate(_indexedPrefabs[frame.PrefabName].Frame, FrameUI.Instance.WorldComponent);
			activeWorldFrame.SetActiveFrame(frame);
			if (!showUI)
			{
				FrameUI.Instance.WorldComponent.gameObject.SetActive(value: true);
				FrameUI.Instance.WorldComponent.gameObject.SetActive(value: false);
			}
			_activeFrame = activeWorldFrame;
			if (frame.MusicName != null)
			{
				MusicManager.Play(frame.MusicName, frame.MusicIsImportant);
			}
		}
		if (showUI)
		{
			GameUI.Instance.ShowFrameUI();
		}
	}

	public void ReloadActiveUpgrades()
	{
		if ((bool)_activeFrame)
		{
			_activeFrame.UpdateUpgradeSlots();
		}
	}
}
