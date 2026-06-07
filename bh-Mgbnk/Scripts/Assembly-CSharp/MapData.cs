using Assets.Scripts.Audio.Music;
using Assets.Scripts.Game.MapGeneration;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts._Data.MapsAndStages;
using UnityEngine;

[CreateAssetMenu(menuName = "Me/Mapping/MapData", order = 1)]
public class MapData : UnlockableBase
{
	public StageData[] stages;

	[Header("Meta")]
	public EMap eMap;

	public Texture icon;

	public Texture mapIconBig;

	public EMapType mapType;

	[Header("Unlocks")]
	public MyAchievement achievementRequirement;

	public int unlockOrder;

	[Header("Map Generation")]
	public GameObject[] shrines;

	public RandomMapObject[] randomObjectsOverride;

	public float numShrinesMultiplier;

	public float numChestsMultiplier;

	public float numShrinesPotsAndOtherMultiplier;

	[Header("Enemy spawning")]
	public float stageDuration;

	[Header("Audio")]
	public AudioClip ambience;

	public MusicTrack[] musicTracks;

	public MusicTrack bossTrack;

	[Header("Other")]
	public bool isWaterDamaging;

	public Material finalStageMaterial;

	public override Texture GetIcon()
	{
		return null;
	}

	public override MyAchievement GetUnlockRequirement()
	{
		return null;
	}

	public override UnlockableBase GetUnlockableRequirement()
	{
		return null;
	}

	public override string GetUnlockableTypeDisplayString()
	{
		return null;
	}

	public override string GetInternalName()
	{
		return null;
	}
}
