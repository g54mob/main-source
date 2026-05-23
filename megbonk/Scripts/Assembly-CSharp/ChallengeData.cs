using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts._Data.MapsAndStages;
using UnityEngine;

[CreateAssetMenu(menuName = "Me/Progression/Challenge", order = 1)]
public class ChallengeData : MyAchievement
{
	[Header("Challenge")]
	public EMap map;

	public int tier;

	public float silverMultiplier;

	public string suggestionAuthor;

	public int requiresNumChallengesCompleted;

	public ChallengeData prerequisiteChallenge;

	public ChallengeModifier[] challengeModifiers;

	public ChallengeWinCondition winCondition;

	public override string GetDisplayName()
	{
		return null;
	}

	public override string GetUnlockRequirement()
	{
		return null;
	}

	public bool CanShow()
	{
		return false;
	}

	public string GetSilverMultiplier()
	{
		return null;
	}

	public override int CompareTo(MyAchievement otherAch)
	{
		return 0;
	}
}
