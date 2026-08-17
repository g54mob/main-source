using System;
using Assets.Scripts._Data;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using UnityEngine;

public class SkinData : UnlockableBase, IComparable<SkinData>
{
	public Texture icon;

	public Material[] materials;

	public ECharacter character;

	public MyAchievement unlockRequirement;

	public ESkinType skinType;

	public override string GetName()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172198]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (localizedName != null)
		{
			if (localizedName.IsEmpty)
			{
				return "[MISSING LOCALIZATION]";
			}
			if (localizedName != null)
			{
				string localizedString = localizedName.GetLocalizedString();
				string characterName = LocalizationUtility.GetCharacterName(character);
				return localizedString + " " + characterName;
			}
		}
		return (string)(object)new NullReferenceException();
	}

	public override string GetDescription()
	{
		return GetName();
	}

	public override int GetPrice()
	{
		//IL_0010: Expected O, but got I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0053: Expected I4, but got F8
		object obj = (int)skinType * 2;
		object obj2 = skinType + obj;
		object obj3 = obj2 + obj2;
		float num = (float)obj3 * 1.75f;
		double num2 = Math.Round(num);
		return (int)num2;
	}

	public override Texture GetIcon()
	{
		return icon;
	}

	public override MyAchievement GetUnlockRequirement()
	{
		return unlockRequirement;
	}

	public override UnlockableBase GetUnlockableRequirement()
	{
		return null;
	}

	public override string GetUnlockableTypeDisplayString()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172199]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return LocalizationUtility.GetLocalizedString("Unlockables", "CHARACTER_COLOR", "Skin");
	}

	public override string GetInternalName()
	{
		//IL_001d: Expected I4, but got O
		string arg = base.name;
		object obj = default(object);
		object arg2 = (ECharacter)obj;
		return $"{arg}{arg2}";
	}

	public unsafe int CompareTo(SkinData other)
	{
		//IL_0071: Expected I4, but got O
		//IL_0083: Expected I, but got O
		//IL_00ba: Expected O, but got Ref
		//IL_0051: Expected I4, but got O
		//IL_0063: Expected I, but got O
		if ((object)this != other)
		{
			if ((object)other != null)
			{
				object target;
				object obj = default(object);
				nint num;
				if (character == other.character)
				{
					target = (ESkinType)obj;
					num = (nint)typeof(ESkinType);
				}
				else
				{
					target = (ECharacter)obj;
					num = (nint)typeof(ECharacter);
				}
				return ((Enum)(&num)).CompareTo(target);
			}
			return 1;
		}
		return 0;
	}
}
