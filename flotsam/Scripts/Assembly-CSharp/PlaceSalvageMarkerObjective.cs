using System;
using I2.Loc;
using UnityEngine;

[Serializable]
public class PlaceSalvageMarkerObjective : QuestObjectiveBase, ILocalizationParamsManager
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Place salvage marker";

	[SerializeField]
	private ItemProperties _itemProperties;

	[SerializeField]
	private bool _includePreexistingMarkers = true;

	public PlaceSalvageMarkerObjective()
	{
	}

	public PlaceSalvageMarkerObjective(PlaceSalvageMarkerObjective other)
		: base(other)
	{
		_itemProperties = other._itemProperties;
		_includePreexistingMarkers = other._includePreexistingMarkers;
	}

	public override bool IsCompleted()
	{
		if (!base.IsCompleted())
		{
			if (_includePreexistingMarkers)
			{
				return GameManager.GameStatsManager.GetMarkersPlacedCount(_itemProperties) > 0;
			}
			return false;
		}
		return true;
	}

	public override void Initialize()
	{
		if (!InitializeIsCompleted())
		{
			GameEventDispatcher.AddListener(GameEventType.MarkerPlaced, OnMarkerPlaced);
		}
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.MarkerPlaced, OnMarkerPlaced);
	}

	private void OnMarkerPlaced(GameEvent gameEvent)
	{
		if (gameEvent is MarkerEvent markerEvent && markerEvent.Marker.ItemTypesInRange.Contains(_itemProperties))
		{
			SetCompleted(completed: true);
		}
	}

	protected override string GetNonLocalizedDescription()
	{
		return "Place Salvage Marker: " + ((_itemProperties != null) ? _itemProperties.LocalizedName : "Any");
	}

	public override string GetParameterValue(string param)
	{
		if (param == "ITEM")
		{
			return (_itemProperties != null) ? _itemProperties.LocalizedName : "Any";
		}
		return base.GetParameterValue(param);
	}

	public override object Clone()
	{
		return new PlaceSalvageMarkerObjective(this);
	}
}
