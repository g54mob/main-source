using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerData))]
public class IdleManager : MonoBehaviour
{
	private PlayerData playerData;

	private List<IdleDetector> idleDetectors;

	private List<IdleDetector> currentlyIdle;

	public event Action<IdleDetector> onDetectorStartIdle;

	public event Action<IdleDetector> onDetectorStopIdle;

	private void Awake()
	{
		playerData = GetComponent<PlayerData>();
		idleDetectors = new List<IdleDetector>();
		currentlyIdle = new List<IdleDetector>();
	}

	private void Start()
	{
		playerData.onPlayerBuildingAdded += OnPlayerBuildingAdded;
		playerData.onPlayerBuildingRemoved += OnPlayerBuildingRemoved;
	}

	public int GetCurrentlyIdleDetectorsAmount()
	{
		return currentlyIdle.Count;
	}

	public IdleDetector GetCurrentlyIdleDetector(int index)
	{
		return currentlyIdle[Mathf.RoundToInt(Mathf.Repeat(index, currentlyIdle.Count))];
	}

	private void OnPlayerBuildingAdded(GameplayObject addedBuilding)
	{
		if (addedBuilding.TryGetComponent<IdleDetector>(out var component))
		{
			idleDetectors.Add(component);
			component.onStartIdle += OnDetectorStartIdle;
			component.onStopIdle += OnDetectorStopIdle;
		}
	}

	private void OnPlayerBuildingRemoved(GameplayObject removedBuilding)
	{
		if (removedBuilding.TryGetComponent<IdleDetector>(out var component))
		{
			idleDetectors.Remove(component);
			if (currentlyIdle.Contains(component))
			{
				OnDetectorStopIdle(component);
			}
			component.onStartIdle -= OnDetectorStartIdle;
			component.onStopIdle -= OnDetectorStopIdle;
		}
	}

	private void OnDetectorStartIdle(IdleDetector idleDetector)
	{
		currentlyIdle.Add(idleDetector);
		this.onDetectorStartIdle?.Invoke(idleDetector);
	}

	private void OnDetectorStopIdle(IdleDetector idleDetector)
	{
		currentlyIdle.Remove(idleDetector);
		this.onDetectorStopIdle?.Invoke(idleDetector);
	}
}
