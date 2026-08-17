using System;
using System.Collections.Generic;
using Assets.Scripts.Audio.Music;
using Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Saves___Serialization.Progression;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using UnityEngine;

public class CharacterData : UnlockableBase
{
	public ECharacter eCharacter;

	public Texture icon;

	public List<StatModifier> statModifiers;

	public GameObject prefab;

	public AudioClip[] audioFootsteps;

	public MusicTrack themeSong;

	public WeaponData weapon;

	public PassiveData passive;

	public float colliderHeight = 3.85f;

	public float colliderWidth = 0.7f;

	public Dictionary<EStatCategory, float> categoryScores;

	public Dictionary<EStatCategory, float> categoryRatios;

	public List<StatCategoryRatio> StatCategoryRatios;

	public MyAchievement achievementRequirement;

	public int numQuestsRequiredForVisibilityInCharacterSelection;

	public Mesh meshDefault;

	public Mesh meshLow;

	public Mesh meshLowest;

	public unsafe void Init()
	{
		//IL_004a: Expected O, but got Ref
		//IL_009a: Expected F4, but got I
		Dictionary<EStatCategory, float> dictionary = new Dictionary<EStatCategory, float>();
		categoryRatios = dictionary;
		if (StatCategoryRatios != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			object obj = default(object);
			while (enumerator.MoveNext())
			{
				bool flag = obj == null;
				List<object>.Enumerator enumerator2 = (List<object>.Enumerator)(&enumerator);
				if (!flag)
				{
					if (categoryRatios != null)
					{
						Dictionary<EStatCategory, float> dictionary2 = categoryRatios;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ stack_-30+10]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ stack_-30+14]");
						((Dictionary<System.Int32Enum, float>)(object)dictionary2).set_Item((System.Int32Enum)num, 0f);
						continue;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			if (!(passive != null))
			{
				return;
			}
			PassiveData passiveData = passive;
			if ((object)passive != null)
			{
				if (passiveData.dummyPassive == null)
				{
					PassiveAbility dummyPassive = PassiveAbilityFactory.CreatePassiveAbility(passive);
					passiveData.dummyPassive = dummyPassive;
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override Texture GetIcon()
	{
		return icon;
	}

	public override MyAchievement GetUnlockRequirement()
	{
		return achievementRequirement;
	}

	public unsafe bool IsBlackedOutInCharacterSelectionScreen()
	{
		//IL_0073: Expected O, but got Ref
		//IL_0093: Invalid comparison between F4 and I4
		//IL_00c4: Expected I4, but got O
		if (achievementRequirement != null)
		{
			if ((object)achievementRequirement == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			if (achievementRequirement.IsUnlocked())
			{
				goto IL_00b0;
			}
		}
		object obj = default(object);
		string statName = ((Enum)(&obj)).ToString();
		float stat = MyStats.GetStat(statName);
		if (stat < (float)numQuestsRequiredForVisibilityInCharacterSelection)
		{
			return true;
		}
		goto IL_00b0;
		IL_00b0:
		return false;
	}

	public override UnlockableBase GetUnlockableRequirement()
	{
		if ((object)weapon != null)
		{
			UnityEngine.Object unlockRequirement = weapon.GetUnlockRequirement();
			if (!(unlockRequirement == null))
			{
				return weapon;
			}
			return null;
		}
		return (UnlockableBase)(object)new NullReferenceException();
	}

	public override string GetUnlockableTypeDisplayString()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172173]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return LocalizationUtility.GetLocalizedString("Unlockables", "CHARACTER", "Character");
	}

	public unsafe override string GetInternalName()
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		return ((Enum)(&obj)).ToString();
	}

	public int GetDisplayRank()
	{
		//IL_00a8: Expected I4, but got O
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null && saveManager.progression != null)
		{
			CharacterProgression characterProgression = saveManager.progression.GetCharacterProgression(eCharacter);
			if (characterProgression != null)
			{
				return characterProgression.GetRank();
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}
}
