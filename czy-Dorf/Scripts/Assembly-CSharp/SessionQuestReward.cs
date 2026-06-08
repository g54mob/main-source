using UnityEngine;

public class SessionQuestReward : ScriptableObject
{
	public string id;

	[SerializeField]
	public UnlockType unlockType;

	public string unlockObjectKey;

	public RewardState state;

	public Tile displayTile;

	public Biome displayBiome;

	public float displayRotation;

	public int seed;

	public SessionQuest compositeSessionQuest;

	public int compositeLevel;

	public SessionQuest sessionQuest;

	public int rewardLevel;

	private Color ColorByState()
	{
		if (state == RewardState.Completed)
		{
			return new Color(0.5f, 1f, 0f);
		}
		return Color.white;
	}

	public string GetUnlockTypeKey()
	{
		return unlockType switch
		{
			UnlockType.Biome => "unlocked_newBiome", 
			UnlockType.Skin => "unlocked_newSkin", 
			_ => "unlocked_newTile", 
		};
	}
}
