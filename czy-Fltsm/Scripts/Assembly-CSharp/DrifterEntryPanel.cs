using System.Collections.Generic;
using UnityEngine;

public class DrifterEntryPanel : MonoBehaviour
{
	[SerializeField]
	private DrifterEntry _drifterEntryPrefab;

	[SerializeField]
	private GameObject _emptyDrifterPrefab;

	private List<DrifterEntry> _drifterEntries = new List<DrifterEntry>();

	private List<GameObject> _emptyDrifters = new List<GameObject>();

	public void UpdateDrifter(Agent agent)
	{
		if (agent == null)
		{
			if (_emptyDrifters.Count == 0)
			{
				_emptyDrifters.Add(Object.Instantiate(_emptyDrifterPrefab, base.transform));
			}
			_emptyDrifters[0].SetActive(value: true);
			for (int i = 0; i < _drifterEntries.Count; i++)
			{
				_drifterEntries[i].gameObject.SetActive(value: false);
			}
			return;
		}
		for (int j = 0; j < _emptyDrifters.Count; j++)
		{
			_emptyDrifters[j].SetActive(value: false);
		}
		for (int k = 0; k < _drifterEntries.Count; k++)
		{
			_drifterEntries[k].gameObject.SetActive(value: false);
		}
		DrifterEntry drifterEntry;
		if (_drifterEntries.Count == 0)
		{
			drifterEntry = Object.Instantiate(_drifterEntryPrefab, base.transform);
			_drifterEntries.Add(drifterEntry);
		}
		else
		{
			drifterEntry = _drifterEntries[0];
		}
		drifterEntry.Initialize(agent);
	}

	public void UpdateDrifters(List<Agent> agents, int capacity)
	{
		int count = agents.Count;
		int i;
		for (i = 0; i < count; i++)
		{
			DrifterEntry drifterEntry;
			if (_drifterEntries.Count <= i)
			{
				drifterEntry = Object.Instantiate(_drifterEntryPrefab, base.transform);
				_drifterEntries.Add(drifterEntry);
			}
			else
			{
				drifterEntry = _drifterEntries[i];
			}
			drifterEntry.transform.SetSiblingIndex(i);
			drifterEntry.Initialize(agents[i]);
		}
		for (; i < _drifterEntries.Count; i++)
		{
			_drifterEntries[i].gameObject.SetActive(value: false);
		}
		int num = capacity - agents.Count;
		for (i = 0; i < num; i++)
		{
			GameObject gameObject;
			if (_emptyDrifters.Count <= i)
			{
				gameObject = Object.Instantiate(_emptyDrifterPrefab, base.transform);
				_emptyDrifters.Add(gameObject);
			}
			else
			{
				gameObject = _emptyDrifters[i];
				gameObject.SetActive(value: true);
			}
			gameObject.transform.SetSiblingIndex(count + i);
		}
		for (; i < _emptyDrifters.Count; i++)
		{
			_emptyDrifters[i].SetActive(value: false);
		}
	}
}
