using UnityEngine;

public class ConveyorBeltCombiner : GameplayObject, ISavable
{
	[SerializeField]
	[Savable("outputConveyor", true, false)]
	private ConveyorBelt_storage outputConveyor;

	[SerializeField]
	[Savable("inputConveyors", true, false)]
	private ConveyorBelt_storage[] inputConveyors;

	private StatsComponent statsComponent;

	[Savable("inputConveyorIdx", true, false)]
	private int inputConveyorIdx = -1;

	private void Awake()
	{
		statsComponent = GetComponent<StatsComponent>();
	}

	private void Start()
	{
		statsComponent.onStatChanged += OnStatChanged;
	}

	private void Update()
	{
		for (int i = 0; i < 3; i++)
		{
			if (!CanUseOutputConveyor(outputConveyor))
			{
				break;
			}
			if (GetNextInputConveyorIndex() != -1)
			{
				outputConveyor.Storage.StoreObject(inputConveyors[inputConveyorIdx].Storage.GetStoredObjectAtIndex(0));
				inputConveyors[inputConveyorIdx].Storage.RemoveStoredObjectAtIndex(0, 1);
			}
		}
	}

	private int GetNextInputConveyorIndex()
	{
		for (int i = 0; i < inputConveyors.Length; i++)
		{
			inputConveyorIdx = (int)Mathf.Repeat(inputConveyorIdx + 1, inputConveyors.Length);
			if (!inputConveyors[inputConveyorIdx].Storage.IsEmpty())
			{
				return inputConveyorIdx;
			}
		}
		return -1;
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
			outputConveyor.StatsComponent.SetStat(EStats.Speed, newValue);
			for (int i = 0; i < inputConveyors.Length; i++)
			{
				inputConveyors[i].StatsComponent.SetStat(EStats.Speed, newValue);
			}
		}
	}
}
