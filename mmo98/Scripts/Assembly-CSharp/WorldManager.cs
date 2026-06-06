using System.Collections.Generic;
using R3;
using Unity.AI.Navigation;
using UnityEngine;
using ZLinq;

public class WorldManager : MonoBehaviour
{
	[SerializeField]
	private NavMeshSurface navMeshSurface;

	private Dictionary<WorldType, WorldVisualizer> _worlds;

	private WorldVisualizer _activeWorld;

	private void Awake()
	{
		_worlds = base.transform.Children().OfComponent<WorldVisualizer>().ToDictionary((WorldVisualizer x) => x.Type, (WorldVisualizer x) => x);
		foreach (WorldVisualizer value in _worlds.Values)
		{
			value.Deactivate();
		}
	}

	private void Start()
	{
		Database.State.Game.World.Subscribe(LoadWorld).AddTo(this);
	}

	private void LoadWorld(WorldType type)
	{
		WorldVisualizer activeWorld = _activeWorld;
		if (((object)activeWorld == null || activeWorld.Type != type) && _worlds.TryGetValue(type, out var value))
		{
			_activeWorld?.Deactivate();
			_activeWorld = value;
			_activeWorld.Activate();
			navMeshSurface.BuildNavMesh();
		}
	}
}
