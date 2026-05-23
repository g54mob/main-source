using System.Collections.Generic;
using Data.FactoryFloor.Maps;
using Events;
using Events.FactoryFloor.Islands;
using Events.Generic;
using TMPro;
using UnityEngine;

public class MapEditorIslandViewLabels : MonoBehaviour
{
	[SerializeField]
	private IslandObjectEvent _createIslandObjectEvent;

	[SerializeField]
	private UpdateIslandEvent _updateIslandEvent;

	[SerializeField]
	private IntEvent _deleteIslandEvent;

	[SerializeField]
	private BaseEvent _clearMapEvent;

	[SerializeField]
	private TMP_Text _textPrefab;

	private readonly Dictionary<int, TMP_Text> _textInstances = new Dictionary<int, TMP_Text>();

	private void Start()
	{
		_createIslandObjectEvent.Register(OnCreateIslandEvent);
		_updateIslandEvent.Register(OnUpdateIslandEvent);
		_deleteIslandEvent.Register(OnDeleteIslandEvent);
		_clearMapEvent.Register(OnClearMapEvent);
		_textPrefab.gameObject.SetActive(value: false);
	}

	private void OnDestroy()
	{
		_createIslandObjectEvent.UnRegister(OnCreateIslandEvent);
		_updateIslandEvent.UnRegister(OnUpdateIslandEvent);
		_deleteIslandEvent.UnRegister(OnDeleteIslandEvent);
		_clearMapEvent.UnRegister(OnClearMapEvent);
	}

	private void OnCreateIslandEvent(IslandObject island)
	{
		TMP_Text instance = GetInstance();
		instance.SetText(island.IslandConfig.IslandData.Name);
		instance.transform.position = new Vector3(island.Position.x, instance.transform.parent.position.y, island.Position.z);
		instance.rectTransform.sizeDelta = island.Size;
		_textInstances.Add(island.IslandConfig.CreatedID, instance);
	}

	private void OnUpdateIslandEvent(UpdateIslandDto dto)
	{
		if (_textInstances.TryGetValue(dto.CreatedId, out var value))
		{
			value.transform.position = new Vector3(dto.Position.x, value.transform.parent.position.y, dto.Position.z);
		}
	}

	private void OnDeleteIslandEvent(int createdId)
	{
		if (_textInstances.TryGetValue(createdId, out var value))
		{
			_textInstances.Remove(createdId);
			Object.Destroy(value);
		}
	}

	private void OnClearMapEvent()
	{
		foreach (TMP_Text value in _textInstances.Values)
		{
			Object.Destroy(value.gameObject);
		}
		_textInstances.Clear();
	}

	private TMP_Text GetInstance()
	{
		TMP_Text component = Object.Instantiate(_textPrefab.gameObject).GetComponent<TMP_Text>();
		component.transform.SetParent(_textPrefab.transform.parent);
		component.transform.localRotation = Quaternion.identity;
		component.gameObject.SetActive(value: true);
		return component;
	}
}
