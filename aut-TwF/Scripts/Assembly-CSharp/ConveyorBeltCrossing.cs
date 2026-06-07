using UnityEngine;

public class ConveyorBeltCrossing : GameplayObject, ISavable
{
	[SerializeField]
	[Savable("inputConveyors", true, false)]
	private ConveyorBelt_storage[] inputConveyors;

	[SerializeField]
	[Savable("outputConveyors", true, false)]
	private ConveyorBelt_storage[] outputConveyors;

	private StatsComponent statsComponent;

	private void Awake()
	{
		statsComponent = GetComponent<StatsComponent>();
	}

	private void Start()
	{
		statsComponent.onStatChanged += OnStatChanged;
		OnStatChanged(EStats.Speed, statsComponent.GetStat(EStats.Speed), 0f);
	}

	private void Update()
	{
		for (int i = 0; i < 2; i++)
		{
			if (!inputConveyors[i].Storage.IsEmpty() && CanUseOutputConveyor(outputConveyors[i]))
			{
				outputConveyors[i].Storage.StoreObject(inputConveyors[i].Storage.GetStoredObjectAtIndex(0));
				inputConveyors[i].Storage.RemoveStoredObjectAtIndex(0, 1);
			}
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

	private void OnStatChanged(EStats stat, float newValue, float oldValue)
	{
		if (stat == EStats.Speed)
		{
			for (int i = 0; i < inputConveyors.Length; i++)
			{
				inputConveyors[i].StatsComponent.SetStat(EStats.Speed, newValue);
			}
			for (int j = 0; j < outputConveyors.Length; j++)
			{
				outputConveyors[j].StatsComponent.SetStat(EStats.Speed, newValue);
			}
		}
	}
}
