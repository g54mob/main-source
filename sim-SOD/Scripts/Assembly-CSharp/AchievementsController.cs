using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class AchievementsController : MonoBehaviour
{
	[InfoBox("Flags/data that is used to help detect achievements", EInfoBoxType.Normal)]
	[Tooltip("Used to help detect whether we are escaping from hospital without paying...")]
	[Header("Achievement Flags")]
	public bool freeHealthCareFlag;

	[Tooltip("Used to help detect whether we are participating in a murder case without using violence. The number is a reference to a case ID, while active the player is not allowed to use violence...")]
	public int notTheAnswerFlag;

	[Tooltip("As above but seen trespassing instead of violence caused")]
	public int privateSlyFlag;

	[Tooltip("Records how many unique things we have pinned in a single game")]
	public List<string> allConnectedReference;

	[Tooltip("If at any point the player KO's anyone in their game, this is set to true and the achievement cannot complete")]
	public bool pacifistFlag;

	[Tooltip("If at any point the player is KO'd, this is set to true and the achievement cannot complete")]
	public bool notAScratchFlag;

	[Tooltip("Tracks who the player has KO'd in this game by citizen ID. Used for the achivement for KO'ing everybody")]
	public List<int> spareNoOneReference;

	private static AchievementsController _instance;

	public static AchievementsController Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public bool GetAchievementStatus(string id)
	{
		return false;
	}

	public void UnlockAchievement(string nameReference, string id)
	{
	}

	public void AddToStat(string nameReference, string id, int add)
	{
	}

	public void ClearAchievement(string id)
	{
	}

	public void LoadTrackingDataFromSave(ref StateSaveData data)
	{
	}

	[Button("Testing: KO Everybody", EButtonEnableMode.Always)]
	public void TestKOEverybody()
	{
	}
}
