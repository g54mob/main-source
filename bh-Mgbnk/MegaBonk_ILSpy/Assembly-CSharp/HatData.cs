using System;
using System.Collections.Generic;
using Assets.Scripts._Data.Hats;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using UnityEngine;

public class HatData : UnlockableBase
{
	public EHat eHat;

	public Texture icon;

	public MyAchievement unlockRequirement;

	public bool useCharacterAltMesh;

	public Mesh mesh;

	public Material material;

	public List<HatOrientation> orientations;

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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172177]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return LocalizationUtility.GetLocalizedString("Unlockables", "HAT", "Hat");
	}

	public override string GetInternalName()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172178]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string text = base.name;
		return text + "_hat";
	}

	public unsafe override int CompareTo(UnlockableBase other)
	{
		//IL_00eb: Expected I4, but got O
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected I4, but got Unknown
		if ((object)other != null)
		{
			int num = this + 44;
			int num2 = ((int*)num)->CompareTo(other.sortingPriority);
			if (num2 == 0)
			{
				int num3 = base.GetPrice();
				int value = other.GetPrice();
				int num4 = default(int);
				num2 = num4.CompareTo(value);
				if (num2 == 0)
				{
					string strA = base.GetName();
					string strB = other.GetName();
					num2 = string.Compare(strA, strB, StringComparison.Ordinal);
				}
			}
			return num2;
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}
}
