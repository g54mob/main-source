using System.Collections.Generic;
using Steamworks;
using UnityEngine;

public static class GoalsController
{
	public static string basePath = "Goals/";

	private static int currentGoalsVersion = 1;

	private static List<GoalObject> allGoals = new List<GoalObject>();

	private static Dictionary<string, GoalStatus> goalIDToStatusDict = new Dictionary<string, GoalStatus>();

	private static Dictionary<GoalCondition, int> conditionCounterDict = new Dictionary<GoalCondition, int>();

	private static List<GoalCondition> allConditions = new List<GoalCondition>();

	private static GUIManagerPens guiRef;

	public static SaveableGoals GetSaveableGoals()
	{
		return new SaveableGoals
		{
			goalsVersion = currentGoalsVersion,
			goalStatusDict = new SerializableDictionary<string, GoalStatus>(goalIDToStatusDict),
			goalConditions = new SerializableDictionary<GoalCondition, int>(conditionCounterDict)
		};
	}

	public static void LoadSaveableGoals(SaveableGoals goalsStructure)
	{
		if (goalsStructure == null)
		{
			SyncUnclaimedGoalIndicator();
			return;
		}
		goalsStructure.goalStatusDict.Load(goalIDToStatusDict);
		goalsStructure.goalConditions.Load(conditionCounterDict);
		for (int i = 0; i < allGoals.Count; i++)
		{
			string iD = allGoals[i].GetID();
			if (!goalIDToStatusDict.ContainsKey(iD))
			{
				goalIDToStatusDict[iD] = GoalStatus.INCOMPLETE;
			}
		}
		for (int j = 0; j < allConditions.Count; j++)
		{
			if (!conditionCounterDict.ContainsKey(allConditions[j]))
			{
				conditionCounterDict[allConditions[j]] = 0;
			}
		}
		if (goalsStructure.goalsVersion == 0)
		{
			string key = "Keepin' It Clean";
			if (goalIDToStatusDict[key] == GoalStatus.CLAIMED)
			{
				goalIDToStatusDict[key] = GoalStatus.UNCLAIMED;
			}
		}
		CheckForGoalCompletion();
		SyncUnclaimedGoalIndicator();
		UnlockSteamAchievements();
	}

	public static void Initialize()
	{
		if (guiRef == null)
		{
			guiRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
		}
		LoadGoals();
		LoadGoalConditions();
		CheckForGoalCompletion();
	}

	public static int GetGoalCount()
	{
		return allGoals.Count;
	}

	public static GoalObject GetGoalForID(string goalID)
	{
		for (int i = 0; i < allGoals.Count; i++)
		{
			if (allGoals[i].GetID() == goalID)
			{
				return allGoals[i];
			}
		}
		Debug.LogError("No goal found for goalID: " + goalID);
		return null;
	}

	public static GoalStatus GetStatusForIndex_Internal(int index)
	{
		return goalIDToStatusDict[allGoals[index].GetID()];
	}

	public static GoalStatus GetStatusForID(string goalID)
	{
		return goalIDToStatusDict[goalID];
	}

	public static string GetCompletionPercentageAsString()
	{
		float num = allGoals.Count;
		float num2 = 0f;
		for (int i = 0; (float)i < num; i++)
		{
			if (GetStatusForIndex_Internal(i) == GoalStatus.CLAIMED)
			{
				num2 += 1f;
			}
		}
		return Mathf.FloorToInt(num2 / num * 100f).ToString();
	}

	public static void SetGoalClaimed(string goalID)
	{
		goalIDToStatusDict[goalID] = GoalStatus.CLAIMED;
		CheckForUnclaimedGoals();
	}

	public static void SetGoalEvent(GoalCondition goalReported, int valueToSet)
	{
		if (!TutorialController.IsTutorialActive())
		{
			conditionCounterDict[goalReported] = valueToSet;
			CheckForGoalCompletion();
		}
	}

	public static void ReportGoalEvent(GoalCondition goalReported, int counter = 1)
	{
		if (!TutorialController.IsTutorialActive())
		{
			conditionCounterDict[goalReported] += counter;
			CheckForGoalCompletion();
		}
	}

	public static int GetCounterForCondition(GoalCondition c)
	{
		return conditionCounterDict[c];
	}

	private static void CheckForUnclaimedGoals()
	{
		if (guiRef == null)
		{
			guiRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
			if (guiRef == null)
			{
				return;
			}
		}
		bool unclaimedGoalsStatus = false;
		for (int i = 0; i < allGoals.Count; i++)
		{
			if (GetStatusForIndex_Internal(i) == GoalStatus.UNCLAIMED)
			{
				unclaimedGoalsStatus = true;
				break;
			}
		}
		guiRef.SetUnclaimedGoalsStatus(unclaimedGoalsStatus);
	}

	public static void SyncUnclaimedGoalIndicator(GUIManagerPens pensGUIRef = null)
	{
		if (guiRef == null)
		{
			if (pensGUIRef != null)
			{
				guiRef = pensGUIRef;
			}
			else
			{
				guiRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI, nullAllowed: true);
				if (guiRef == null)
				{
					return;
				}
			}
		}
		for (int i = 0; i < allGoals.Count; i++)
		{
			string iD = allGoals[i].GetID();
			if (goalIDToStatusDict[iD] == GoalStatus.UNCLAIMED)
			{
				guiRef.SetUnclaimedGoalsStatus(status: true);
				return;
			}
		}
		guiRef.SetUnclaimedGoalsStatus(status: false);
	}

	private static void CheckForGoalCompletion()
	{
		for (int i = 0; i < allGoals.Count; i++)
		{
			string iD = allGoals[i].GetID();
			if (goalIDToStatusDict[iD] == GoalStatus.INCOMPLETE && CheckGoalComplete(allGoals[i]))
			{
				OnGoalComplete(allGoals[i]);
				goalIDToStatusDict[iD] = GoalStatus.UNCLAIMED;
				if (guiRef != null)
				{
					guiRef.SetUnclaimedGoalsStatus(status: true);
				}
			}
		}
	}

	private static void UnlockSteamAchievements()
	{
		if (!SteamManager.Initialized)
		{
			return;
		}
		bool flag = false;
		for (int i = 0; i < allGoals.Count; i++)
		{
			string iD = allGoals[i].GetID();
			if (goalIDToStatusDict[iD] == GoalStatus.CLAIMED || goalIDToStatusDict[iD] == GoalStatus.UNCLAIMED)
			{
				SteamUserStats.GetAchievement(allGoals[i].steamID, out var pbAchieved);
				if (!pbAchieved)
				{
					flag = true;
					SteamUserStats.SetAchievement(allGoals[i].steamID);
				}
			}
		}
		if (flag)
		{
			SteamUserStats.StoreStats();
		}
	}

	private static void UnlockSteamAchievement(string steamID)
	{
		if (SteamManager.Initialized)
		{
			SteamUserStats.GetAchievement(steamID, out var pbAchieved);
			if (!pbAchieved)
			{
				SteamUserStats.SetAchievement(steamID);
				SteamUserStats.StoreStats();
			}
		}
	}

	private static bool CheckGoalComplete(GoalObject goalRef)
	{
		if (conditionCounterDict[goalRef.condition] >= goalRef.conditionCount)
		{
			return true;
		}
		return false;
	}

	private static void OnGoalComplete(GoalObject completedGoal)
	{
		if (guiRef != null)
		{
			guiRef.OnGoalComplete(completedGoal.localizedName);
		}
		UnlockSteamAchievement(completedGoal.steamID);
	}

	private static void LoadGoals()
	{
		allGoals.Clear();
		goalIDToStatusDict.Clear();
		LoadGoalsPath(basePath);
	}

	private static void LoadGoalsPath(string path)
	{
		Object[] array = Resources.LoadAll(path);
		for (int i = 0; i < array.Length; i++)
		{
			GoalObject goalObject = (GoalObject)array[i];
			allGoals.Add(goalObject);
			goalIDToStatusDict[goalObject.GetID()] = GoalStatus.INCOMPLETE;
		}
	}

	private static void LoadGoalConditions()
	{
		allConditions.Clear();
		conditionCounterDict.Clear();
		foreach (GoalCondition value in EnumUtils.GetValues<GoalCondition>())
		{
			if (value != GoalCondition.NONE)
			{
				allConditions.Add(value);
				conditionCounterDict[value] = 0;
			}
		}
	}
}
