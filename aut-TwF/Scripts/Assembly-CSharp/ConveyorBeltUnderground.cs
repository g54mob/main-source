using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltUnderground : GameplayObject, ISavable
{
	[SerializeField]
	[Savable("inputConveyor", true, false)]
	private ConveyorBelt_storage inputConveyor;

	[SerializeField]
	[Savable("outputConveyor", true, false)]
	private ConveyorBelt_storage outputConveyor;

	private StatsComponent statsComponent;

	private float undergroundDistance;

	[Savable("inputTimes", true, false)]
	private List<float> inputTimes;

	private float conveyorSpeed;

	private void Awake()
	{
		inputTimes = new List<float>();
		statsComponent = GetComponent<StatsComponent>();
	}

	private void Start()
	{
		conveyorSpeed = inputConveyor.GetComponent<StatsComponent>().GetStat(EStats.Speed);
		undergroundDistance = 2f - inputConveyor.GetBeltDistance() + 1f - outputConveyor.GetBeltDistance();
		GetComponent<PlacementComponent>().onUnplace += OnUnplace;
		inputConveyor.onStoreResource += OnInputStoreResource;
		statsComponent.onStatChanged += OnStatChanged;
		OnStatChanged(EStats.Speed, statsComponent.GetStat(EStats.Speed), 0f);
	}

	private void Update()
	{
		if (!inputConveyor.Storage.IsEmpty() && CanUseOutputConveyor(outputConveyor) && LTFunctionLibrary.GetTimeManager().GetTimeSeconds() >= (double)(inputTimes[0] + undergroundDistance / conveyorSpeed))
		{
			inputTimes.RemoveAt(0);
			outputConveyor.Storage.StoreObject(inputConveyor.Storage.GetStoredObjectAtIndex(0));
			inputConveyor.Storage.RemoveStoredObjectAtIndex(0, 1);
		}
	}

	private bool CanUseOutputConveyor(ConveyorBelt_storage outputConveyor)
	{
		if (outputConveyor.CurrentBeltGroup != null && outputConveyor.CurrentBeltGroup.Belts.Count > 1)
		{
			return !outputConveyor.Storage.IsFull();
		}
		return false;
	}

	private void OnInputStoreResource(ResourceData resource, int amount)
	{
		inputTimes.Add((float)LTFunctionLibrary.GetTimeManager().GetTimeSeconds());
	}

	private void OnUnplace(PlacementComponent component)
	{
		inputTimes.Clear();
	}

	private void OnStatChanged(EStats stat, float newValue, float oldValue)
	{
		if (stat == EStats.Speed)
		{
			inputConveyor.StatsComponent.SetStat(EStats.Speed, newValue);
			outputConveyor.StatsComponent.SetStat(EStats.Speed, newValue);
		}
	}
}
