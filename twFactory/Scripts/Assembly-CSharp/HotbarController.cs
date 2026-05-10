using System;
using System.Collections.Generic;
using UnityEngine;

public class HotbarController
{
	[Serializable]
	private class HotbarSavedActions
	{
		[Serializable]
		public struct FSavedAction
		{
			public int actionIdx;

			public int bankIdx;

			public string buildingID;

			public FSavedAction(int actionIdx, int bankIdx, string buildingID)
			{
				this.actionIdx = actionIdx;
				this.bankIdx = bankIdx;
				this.buildingID = buildingID;
			}
		}

		public List<FSavedAction> savedActions;

		public void SerializeActions(HotbarAction[,] actionsToSerialize)
		{
			savedActions = new List<FSavedAction>();
			for (int i = 0; i < actionsToSerialize.GetLength(0); i++)
			{
				for (int j = 0; j < actionsToSerialize.GetLength(1); j++)
				{
					if (actionsToSerialize[i, j] != null)
					{
						GameplayObjectData gameplayObjectData = actionsToSerialize[i, j].Data as GameplayObjectData;
						savedActions.Add(new FSavedAction(i, j, gameplayObjectData.Id));
					}
				}
			}
		}

		public HotbarAction[,] DeserializeActions(int actionsAmount, int bankAmount)
		{
			HotbarAction[,] array = new HotbarAction[actionsAmount, bankAmount];
			foreach (FSavedAction action in savedActions)
			{
				PlayerData.PlayerBuilding playerBuilding = LTFunctionLibrary.GetPlayerData().AvailableBuildingsAndTowers.Find((PlayerData.PlayerBuilding x) => (bool)x.BuildingData && x.BuildingData.Id == action.buildingID);
				if (playerBuilding != null && playerBuilding.IsUnlocked && (bool)playerBuilding.BuildingData)
				{
					array[action.actionIdx, action.bankIdx] = new HotbarAction_building(playerBuilding.BuildingData);
				}
			}
			return array;
		}
	}

	private HotbarAction[,] actions;

	private int currentBank;

	public int CurrentBank
	{
		get
		{
			return currentBank;
		}
		private set
		{
			currentBank = value;
		}
	}

	public HotbarController(int actionsAmount, int banksAmount)
	{
		actions = new HotbarAction[actionsAmount, banksAmount];
		LoadHotbar();
	}

	public void SetCurrentBank(int bankIdx)
	{
		CurrentBank = ValidateBankIdx(bankIdx);
	}

	public void SetNextCurrentBank()
	{
		CurrentBank = ValidateBankIdx(CurrentBank + 1);
	}

	public void SetPreviousCurrentBank()
	{
		CurrentBank = ValidateBankIdx(CurrentBank - 1);
	}

	public bool AddAction(HotbarAction action, int actionIdx)
	{
		return AddAction(action, actionIdx, CurrentBank);
	}

	public bool AddAction(HotbarAction action, int actionIdx, int bankIdx)
	{
		if (IsIndexValid(actionIdx, bankIdx))
		{
			actions[actionIdx, bankIdx] = action;
			SaveHotbar();
			return true;
		}
		return false;
	}

	public bool RemoveAction(int actionIdx)
	{
		return RemoveAction(actionIdx, CurrentBank);
	}

	public bool RemoveAction(int actionIdx, int bankIdx)
	{
		if (IsIndexValid(actionIdx, bankIdx))
		{
			actions[actionIdx, bankIdx] = null;
			SaveHotbar();
			return true;
		}
		return false;
	}

	public HotbarAction GetAction(int actionIdx)
	{
		return GetAction(actionIdx, CurrentBank);
	}

	public HotbarAction GetAction(int actionIdx, int bankIdx)
	{
		if (HasAction(actionIdx, bankIdx))
		{
			return actions[actionIdx, bankIdx];
		}
		return null;
	}

	public bool DoAction(int actionIdxk)
	{
		return DoAction(actionIdxk, CurrentBank);
	}

	public bool DoAction(int actionIdx, int bankIdx)
	{
		if (HasAction(actionIdx, bankIdx))
		{
			return actions[actionIdx, bankIdx].DoAction();
		}
		return false;
	}

	public bool CanPerformActionAtIndex(int actionIdx)
	{
		return CanPerformActionAtIndex(actionIdx, CurrentBank);
	}

	public bool CanPerformActionAtIndex(int actionIdx, int bankIdx)
	{
		return HasAction(actionIdx, bankIdx);
	}

	private bool HasAction(int actionIdx, int bankIdx)
	{
		if (IsIndexValid(actionIdx, bankIdx))
		{
			return actions[actionIdx, bankIdx] != null;
		}
		return false;
	}

	private bool IsIndexValid(int actionIdx, int bankIdx)
	{
		if (actionIdx >= 0 && bankIdx >= 0 && actions.GetLength(0) > actionIdx)
		{
			return actions.GetLength(1) > bankIdx;
		}
		return false;
	}

	private int ValidateBankIdx(int bankIdx)
	{
		return Mathf.RoundToInt(Mathf.Repeat(bankIdx, actions.GetLength(1) - 1));
	}

	public bool HasSavedData()
	{
		return PlayerPrefs.HasKey("hotbarConfig");
	}

	private void SaveHotbar()
	{
		HotbarSavedActions hotbarSavedActions = new HotbarSavedActions();
		hotbarSavedActions.SerializeActions(actions);
		string value = JsonUtility.ToJson(hotbarSavedActions);
		PlayerPrefs.SetString("hotbarConfig", value);
	}

	private void LoadHotbar()
	{
		if (HasSavedData())
		{
			HotbarSavedActions hotbarSavedActions = JsonUtility.FromJson<HotbarSavedActions>(PlayerPrefs.GetString("hotbarConfig"));
			actions = hotbarSavedActions.DeserializeActions(actions.GetLength(0), actions.GetLength(1));
		}
	}
}
