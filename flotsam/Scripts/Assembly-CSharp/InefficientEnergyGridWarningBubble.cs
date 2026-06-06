using UnityEngine;

public class InefficientEnergyGridWarningBubble : WarningBubble
{
	protected override void Start()
	{
		base.Start();
		foreach (EnergyGrid grid in EnergyGridManager.Grids)
		{
			UpdateEnergyGridEfficiency(grid);
		}
	}

	private void OnEnable()
	{
		StartAnimation(PulseTweenCoroutine(_background, 1f, 1.3f));
	}

	protected override void Subscribe()
	{
		GameEventDispatcher.AddListener(GameEventType.EnergyGridEfficiencyUpdated, OnEnergyGridEvent);
		GameEventDispatcher.AddListener(GameEventType.EnergyGridsUpdated, OnEnergyGridEvent);
	}

	protected override void Unsubscribe()
	{
		GameEventDispatcher.RemoveListener(GameEventType.EnergyGridEfficiencyUpdated, OnEnergyGridEvent);
		GameEventDispatcher.RemoveListener(GameEventType.EnergyGridsUpdated, OnEnergyGridEvent);
	}

	private void OnEnergyGridEvent(GameEvent gameEvent)
	{
		EnergyGridEvent energyGridEvent = gameEvent as EnergyGridEvent;
		UpdateEnergyGridEfficiency(energyGridEvent.Grid);
	}

	private void UpdateEnergyGridEfficiency(EnergyGrid grid)
	{
		if (!EnergyGridManager.Grids.Contains(grid))
		{
			RemoveInefficientGrid(grid);
		}
		else if (Mathf.Approximately(grid.GridEfficiency, 1f))
		{
			RemoveInefficientGrid(grid);
		}
		else
		{
			AddInefficientGrid(grid);
		}
	}

	private void AddInefficientGrid(EnergyGrid grid)
	{
		if (AddObjectOfInterest(grid.ObjectOfInterest))
		{
			if (_objectOfInterestContainer.ObjectsOfInterest.Count == 1)
			{
				StartAnimation(BounceOutTweenCoroutine(_background));
			}
			else if (_objectOfInterestContainer.ObjectsOfInterest.Count > 1)
			{
				StartAnimation(BounceOutTweenCoroutine(_counter));
			}
		}
	}

	private void RemoveInefficientGrid(EnergyGrid grid)
	{
		RemoveObjectOfInterest(grid.ObjectOfInterest);
	}
}
