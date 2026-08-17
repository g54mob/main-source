using System;
using Assets.Scripts._Data.MapsAndStages;
using Assets.Scripts.Audio.Music;
using Assets.Scripts.Game.MapGeneration;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using UnityEngine;

public class MapData : UnlockableBase
{
	public StageData[] stages;

	public EMap eMap;

	public Texture icon;

	public Texture mapIconBig;

	public EMapType mapType;

	public MyAchievement achievementRequirement;

	public int unlockOrder;

	public GameObject[] shrines;

	public RandomMapObject[] randomObjectsOverride;

	public float numShrinesMultiplier = 1f;

	public float numChestsMultiplier = 1f;

	public float numShrinesPotsAndOtherMultiplier = 1f;

	public float stageDuration = 600f;

	public AudioClip ambience;

	public MusicTrack[] musicTracks;

	public MusicTrack bossTrack;

	public bool isWaterDamaging;

	public Material finalStageMaterial;

	public override Texture GetIcon()
	{
		return icon;
	}

	public override MyAchievement GetUnlockRequirement()
	{
		return achievementRequirement;
	}

	public override UnlockableBase GetUnlockableRequirement()
	{
		return null;
	}

	public override string GetUnlockableTypeDisplayString()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317217D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return LocalizationUtility.GetLocalizedString("Unlockables", "MAP", "Map");
	}

	public unsafe override string GetInternalName()
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		return ((Enum)(&obj)).ToString();
	}
}
