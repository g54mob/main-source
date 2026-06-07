using System;
using System.Collections.Generic;
using PajamaLlama.Utilities;

public class ConstructibleStatus
{
	public Action OnMalfunctionsUpdated;

	private WorldIconHandler _worldIconHandler;

	private readonly List<PlaceableAlertProperties> _malfunctions = new List<PlaceableAlertProperties>();

	private bool _malfunctionsUpdated;

	public PlaceableAlertProperties Status { get; private set; }

	public void Initialize(WorldIconHandler worldIconHandler)
	{
		_worldIconHandler = worldIconHandler;
		UpdateWorldIcons();
	}

	private void UpdateWorldIcons()
	{
		using ListPool<PlaceableAlertProperties>.List list = ListPool<PlaceableAlertProperties>.Get();
		PopulateMalfunctions(list, PlaceableAlertProperties.AlertType.Major);
		if (!(_worldIconHandler == null))
		{
			_worldIconHandler.ClearAllIcons();
			if (list.Count > 1)
			{
				_worldIconHandler.AddIcon(GameSettings.Instance.BuildableSettings.MultipleMalfunctionsIconProperties);
			}
			else if (list.Count == 1)
			{
				_worldIconHandler.AddIcon(list[0]);
			}
			else if ((bool)Status && Status.Alert == PlaceableAlertProperties.AlertType.Major)
			{
				_worldIconHandler.AddIcon(Status);
			}
		}
	}

	public void SetStatus(PlaceableAlertProperties status)
	{
		if (!(Status == status))
		{
			Status = status;
			UpdateWorldIcons();
			FlagMalfunctionsUpdated();
		}
	}

	public void AddMalfunction(PlaceableAlertProperties properties)
	{
		if (_malfunctions.AddUnique(properties))
		{
			FlagMalfunctionsUpdated();
		}
	}

	public void RemoveMalfunction(PlaceableAlertProperties properties)
	{
		if (_malfunctions.Remove(properties))
		{
			FlagMalfunctionsUpdated();
		}
	}

	public void RemoveAllMalfunctions()
	{
		if (_malfunctions.Count > 0)
		{
			_malfunctions.Clear();
			FlagMalfunctionsUpdated();
		}
	}

	public void FlagMalfunctionsUpdated()
	{
		if (!_malfunctionsUpdated)
		{
			_malfunctionsUpdated = true;
			FinalUpdate.RegisterEndOfFrameOneShot(UpdateMalfunctions);
		}
	}

	private void UpdateMalfunctions()
	{
		_malfunctionsUpdated = false;
		UpdateWorldIcons();
		OnMalfunctionsUpdated.SafeInvoke();
	}

	public void PopulateMalfunctions(List<PlaceableAlertProperties> malfunctions, PlaceableAlertProperties.AlertType minimumAlertType = PlaceableAlertProperties.AlertType.Minor)
	{
		foreach (PlaceableAlertProperties malfunction in _malfunctions)
		{
			if (minimumAlertType <= malfunction.Alert)
			{
				malfunctions.Add(malfunction);
			}
		}
	}
}
