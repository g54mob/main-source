using UnityEngine;

public class ConveyorBeltSplitter : GameplayObject, ISavable
{
	[SerializeField]
	[Savable("inputConveyor", true, false)]
	private ConveyorBelt_storage inputConveyor;

	[SerializeField]
	[Savable("outputConveyors", true, false)]
	private ConveyorBelt_storage[] outputConveyors;

	private StatsComponent statsComponent;

	[Savable("outputConveyorIdx", true, false)]
	private int outputConveyorIdx = -1;

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
			if (inputConveyor.Storage.IsEmpty())
			{
				break;
			}
			if (GetNextOutputConveyorIndex() != -1)
			{
				outputConveyors[outputConveyorIdx].Storage.StoreObject(inputConveyor.Storage.GetStoredObjectAtIndex(0));
				inputConveyor.Storage.RemoveStoredObjectAtIndex(0, 1);
			}
		}
	}

	private int GetNextOutputConveyorIndex()
	{
		for (int i = 0; i < outputConveyors.Length; i++)
		{
			outputConveyorIdx = (int)Mathf.Repeat(outputConveyorIdx + 1, outputConveyors.Length);
			if (CanUseOutputConveyor(outputConveyors[outputConveyorIdx]))
			{
				return outputConveyorIdx;
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
			inputConveyor.StatsComponent.SetStat(EStats.Speed, newValue);
			for (int i = 0; i < outputConveyors.Length; i++)
			{
				outputConveyors[i].StatsComponent.SetStat(EStats.Speed, newValue);
			}
		}
	}
}
