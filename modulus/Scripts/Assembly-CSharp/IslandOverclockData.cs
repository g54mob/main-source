using System.Collections.Generic;
using Data.FactoryFloor.Buildings;
using Data.FactoryFloor.Maps;
using Logic.Threading.Events;
using UnityEngine;

public class IslandOverclockData
{
	private IslandObject _islandObject;

	private List<OverclockStationBehaviour> _activeOverclockStationsOnIsland;

	private List<OverclockStationBehaviour> _overclockStationsOnIsland;

	private float _currentOverclockMultiplier = 1f;

	public MainThreadEvent<OverclockStationBehaviour> OnIslandOverclockStationsAdded = new MainThreadEvent<OverclockStationBehaviour>();

	public MainThreadEvent<OverclockStationBehaviour> OnIslandOverclockStationsRemoved = new MainThreadEvent<OverclockStationBehaviour>();

	public float OverclockMultiplier => _currentOverclockMultiplier;

	public bool IsOverclocked => _activeOverclockStationsOnIsland.Count > 0;

	public List<OverclockStationBehaviour> OverclockStationsOnIsland => _overclockStationsOnIsland;

	public IslandOverclockData(IslandObject islandObject)
	{
		_islandObject = islandObject;
		_activeOverclockStationsOnIsland = new List<OverclockStationBehaviour>();
		_overclockStationsOnIsland = new List<OverclockStationBehaviour>();
	}

	public void RegisterActiveOverclockStation(OverclockStationBehaviour overclockStationBehaviour)
	{
		if (!_activeOverclockStationsOnIsland.Contains(overclockStationBehaviour))
		{
			_activeOverclockStationsOnIsland.Add(overclockStationBehaviour);
		}
	}

	public void UnregisterActiveOverclockStation(OverclockStationBehaviour overclockStationBehaviour)
	{
		_activeOverclockStationsOnIsland.Remove(overclockStationBehaviour);
	}

	public void RegisterOverclockStation(OverclockStationBehaviour overclockStationBehaviour)
	{
		bool flag = _overclockStationsOnIsland.Count == 0;
		if (!_overclockStationsOnIsland.Contains(overclockStationBehaviour))
		{
			_overclockStationsOnIsland.Add(overclockStationBehaviour);
			if (flag)
			{
				OnIslandOverclockStationsAdded.Fire(overclockStationBehaviour);
			}
		}
	}

	public void UnregisterOverclockStation(OverclockStationBehaviour overclockStationBehaviour)
	{
		bool num = _overclockStationsOnIsland.Count == 0;
		_overclockStationsOnIsland.Remove(overclockStationBehaviour);
		if (!num && _overclockStationsOnIsland.Count == 0)
		{
			OnIslandOverclockStationsRemoved.Fire(overclockStationBehaviour);
		}
	}

	public void ReCalculateOverclockMultiplier()
	{
		float num = 1f;
		foreach (OverclockStationBehaviour item in _activeOverclockStationsOnIsland)
		{
			num = Mathf.Max(num, item.GetOverclockMultiplier());
		}
		_currentOverclockMultiplier = num;
	}

	public bool IslandHasCompletedOverclockStation()
	{
		return _overclockStationsOnIsland.Count > 0;
	}
}
