using System.Collections.Generic;
using Assets.Scripts.Audio.Music;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using UnityEngine;

[CreateAssetMenu(menuName = "Me/Character", order = 1)]
public class CharacterData : UnlockableBase
{
	[Header("Meta")]
	public ECharacter eCharacter;

	public Texture icon;

	[Header("Stats")]
	public List<StatModifier> statModifiers;

	[Header("Other")]
	public GameObject prefab;

	public AudioClip[] audioFootsteps;

	public MusicTrack themeSong;

	[Header("Data")]
	public WeaponData weapon;

	public PassiveData passive;

	public float colliderHeight;

	public float colliderWidth;

	public Dictionary<EStatCategory, float> categoryScores;

	public Dictionary<EStatCategory, float> categoryRatios;

	public List<StatCategoryRatio> StatCategoryRatios;

	[Header("Unlocks")]
	public MyAchievement achievementRequirement;

	public int numQuestsRequiredForVisibilityInCharacterSelection;

	[Header("Renderer")]
	public Mesh meshDefault;

	public Mesh meshLow;

	public Mesh meshLowest;

	public void Init()
	{
	}

	public override Texture GetIcon()
	{
		return null;
	}

	public override MyAchievement GetUnlockRequirement()
	{
		return null;
	}

	public bool IsBlackedOutInCharacterSelectionScreen()
	{
		return false;
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

	public int GetDisplayRank()
	{
		return 0;
	}
}
