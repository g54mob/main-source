using System.Collections.Generic;
using UnityEngine;

public class RescuePanel : MonoBehaviour
{
	[Tooltip("Prefab used to spawn the rescueable drifter' information.")]
	[SerializeField]
	private RescueableDrifterInfo _rescueableDrifterInfoPrefab;

	[Tooltip("Prefab used to spawn the rescueable seagull' information.")]
	[SerializeField]
	private RescueableSeagullInfo _rescueableSeagullInfoPrefab;

	[Tooltip("Parent of the spawned Rescueable Agent Info elements.")]
	[SerializeField]
	private RectTransform _rescueableAgentInfoParent;

	private List<RescueableDrifterInfo> _rescuableDrifterEntries;

	private List<RescueableSeagullInfo> _rescuableSeagullEntries;

	private int _activeEntriesCount;

	public void Enable()
	{
		if (0 < _activeEntriesCount)
		{
			ResetPanel();
		}
	}

	public virtual void ResetPanel()
	{
		_activeEntriesCount = 0;
		if (_rescuableDrifterEntries != null)
		{
			foreach (RescueableDrifterInfo rescuableDrifterEntry in _rescuableDrifterEntries)
			{
				rescuableDrifterEntry.gameObject.SetActive(value: false);
			}
		}
		if (_rescuableSeagullEntries == null)
		{
			return;
		}
		foreach (RescueableSeagullInfo rescuableSeagullEntry in _rescuableSeagullEntries)
		{
			rescuableSeagullEntry.gameObject.SetActive(value: false);
		}
	}

	public void AddRescuable(ActorDescriptor actorDescriptor)
	{
		if (actorDescriptor is AgentDescriptor agentDescriptor)
		{
			AddRescuableAgentInfo(agentDescriptor);
		}
		else if (actorDescriptor is AnimalDescriptor descriptor)
		{
			AddRescuableAnimalInfo(descriptor);
		}
	}

	public void AddRescuableAgentInfo(AgentDescriptor agentDescriptor)
	{
		if (_rescuableDrifterEntries == null)
		{
			_rescuableDrifterEntries = new List<RescueableDrifterInfo>();
		}
		RescueableDrifterInfo rescueableDrifterInfo;
		if (_activeEntriesCount < _rescuableDrifterEntries.Count)
		{
			rescueableDrifterInfo = _rescuableDrifterEntries[_activeEntriesCount];
		}
		else
		{
			rescueableDrifterInfo = Object.Instantiate(_rescueableDrifterInfoPrefab);
			_rescuableDrifterEntries.Add(rescueableDrifterInfo);
		}
		rescueableDrifterInfo.transform.SetParent(_rescueableAgentInfoParent, worldPositionStays: false);
		rescueableDrifterInfo.Initialize(agentDescriptor);
		rescueableDrifterInfo.gameObject.SetActive(value: true);
		_activeEntriesCount++;
	}

	public void AddRescuableAnimalInfo(AnimalDescriptor descriptor)
	{
		if (_rescuableSeagullEntries == null)
		{
			_rescuableSeagullEntries = new List<RescueableSeagullInfo>();
		}
		RescueableSeagullInfo rescueableSeagullInfo;
		if (_activeEntriesCount < _rescuableSeagullEntries.Count)
		{
			rescueableSeagullInfo = _rescuableSeagullEntries[_activeEntriesCount];
		}
		else
		{
			rescueableSeagullInfo = Object.Instantiate(_rescueableSeagullInfoPrefab);
			_rescuableSeagullEntries.Add(rescueableSeagullInfo);
		}
		rescueableSeagullInfo.transform.SetParent(_rescueableAgentInfoParent, worldPositionStays: false);
		rescueableSeagullInfo.Initialize(descriptor);
		rescueableSeagullInfo.gameObject.SetActive(value: true);
		_activeEntriesCount++;
	}
}
