using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SteamAchievement_processorWorking_default", menuName = "Tower Factory/Steam Achievements/Processor Working")]
public class SteamAchievement_processorWorking : SteamAchievement
{
	[Serializable]
	public class FProcessorInfo
	{
		[SerializeField]
		private GameplayObjectData processorData;

		[SerializeField]
		private int amount;

		private int currentAmount;

		public GameplayObjectData ProcessorData => processorData;

		public int Amount => amount;

		public int CurrentAmount
		{
			get
			{
				return currentAmount;
			}
			set
			{
				currentAmount = value;
			}
		}
	}

	[Header("Processor Working")]
	[SerializeField]
	private List<FProcessorInfo> processorInfos;

	protected override void OnStartGame()
	{
		base.OnStartGame();
		ResetCurrentProcessorInfos();
		LTFunctionLibrary.GetPlayerData().onPlayerBuildingAdded += OnPlayerBuildingAdded;
	}

	private void ResetCurrentProcessorInfos()
	{
		foreach (FProcessorInfo processorInfo in processorInfos)
		{
			processorInfo.CurrentAmount = 0;
		}
	}

	private void CheckAchievementCompleted()
	{
		foreach (FProcessorInfo processorInfo in processorInfos)
		{
			if (processorInfo.CurrentAmount < processorInfo.Amount)
			{
				return;
			}
		}
		UnlockAchievement();
		LTFunctionLibrary.GetPlayerData().onPlayerBuildingAdded -= OnPlayerBuildingAdded;
	}

	private void OnPlayerBuildingAdded(GameplayObject addedBuilding)
	{
		if (addedBuilding.TryGetComponent<Processor>(out var component))
		{
			component.onStartProcessing += OnProcessorStartProcessing;
			component.onStopProcessing += OnProcessorStopProcessing;
		}
	}

	private void OnProcessorStartProcessing(Processor processor)
	{
		if (!base.IsStarted)
		{
			return;
		}
		foreach (FProcessorInfo processorInfo in processorInfos)
		{
			if (processorInfo.ProcessorData.Id == processor.ObjectData.Id)
			{
				processorInfo.CurrentAmount++;
				CheckAchievementCompleted();
				break;
			}
		}
	}

	private void OnProcessorStopProcessing(Processor processor)
	{
		if (!base.IsStarted)
		{
			return;
		}
		foreach (FProcessorInfo processorInfo in processorInfos)
		{
			if (processorInfo.ProcessorData.Id == processor.ObjectData.Id)
			{
				processorInfo.CurrentAmount--;
				break;
			}
		}
	}
}
