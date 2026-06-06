using System;
using System.Collections.Generic;
using PajamaLlama.Debugs;
using UnityEngine;

[Serializable]
public class MarkerPersistentData : PersistentReference<Marker>
{
	public int PropertiesIndex;

	public Vector3 Position;

	public int ProjectPersistentIndex;

	public int CurrentRadiusIntervalIndex;

	private Dictionary<int, bool> _allowedItemPropertyIndices;

	public MarkerPersistentData(Marker marker)
		: base(marker)
	{
		PropertiesIndex = GameManager.PersistenceManager.ReturnPropertiesIndex(marker.MarkerCursorProperties);
		Position = marker.transform.position;
		CurrentRadiusIntervalIndex = marker.CurrentRadiusIntervalIndex;
		PopulateAllowedItemPropertyIndices();
	}

	public void PopulateReferences()
	{
		ProjectPersistentIndex = base.Instance.Project.PersistentIndex;
	}

	private void PopulateAllowedItemPropertyIndices()
	{
		_allowedItemPropertyIndices = new Dictionary<int, bool>();
		foreach (KeyValuePair<ItemProperties, bool> item in base.Instance.ItemFilter)
		{
			int key = GameManager.PersistenceManager.ReturnPropertiesIndex(item.Key);
			_allowedItemPropertyIndices.Add(key, item.Value);
		}
		base.Instance.UpdatedAllowedItemPropertiesEvent.Invoke();
	}

	public override void Restore()
	{
		CursorProperties reference = null;
		if (GameManager.PersistenceManager.TryReturnPropertiesReference<CursorProperties>(PropertiesIndex, out reference))
		{
			MarkerCursorProperties markerCursorProperties = (MarkerCursorProperties)reference;
			Marker markerPrefab = markerCursorProperties.MarkerPrefab;
			base.Instance = UnityEngine.Object.Instantiate(markerPrefab, Position, Quaternion.identity);
			base.Instance.Restore(markerCursorProperties, CurrentRadiusIntervalIndex, ReturnAllowedItemPropertyIndices());
			Community.PlayerCommunity.Markers.Add(base.Instance);
			base.Instance.Community = Community.PlayerCommunity;
			base.Restore();
		}
	}

	private Dictionary<ItemProperties, bool> ReturnAllowedItemPropertyIndices()
	{
		Dictionary<ItemProperties, bool> dictionary = new Dictionary<ItemProperties, bool>();
		foreach (KeyValuePair<int, bool> allowedItemPropertyIndex in _allowedItemPropertyIndices)
		{
			if (GameManager.PersistenceManager.TryReturnPropertiesReference<ItemProperties>(allowedItemPropertyIndex.Key, out var reference))
			{
				dictionary.Add(reference, allowedItemPropertyIndex.Value);
			}
		}
		return dictionary;
	}

	public void RestoreReferences()
	{
		PersistentReference<Project>.TryReturnReference(ProjectPersistentIndex, out var reference);
		if (reference == null)
		{
			Debugger.Error("The projectReference in MarkerPersistentData is not found!");
		}
		else
		{
			base.Instance.LinkProject(reference);
		}
	}
}
