using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using I2.Loc;
using UnityEngine;

namespace VampireSurvivors.Data;

public static class ContentGroupMethods
{
	public static bool IsLoaded(ContentGroupType content)
	{
		if (content == ContentGroupType.BASE || content == ContentGroupType.EXTRA)
		{
			return true;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 26 Invalid \"Jump target not found in method: 0x186BCB3F0\"");
		bool result = default(bool);
		return result;
	}

	public unsafe static bool IsDlcLoadedForContentGroup(ContentGroupType contentGroupType)
	{
		//IL_0038: Expected O, but got Ref
		Dictionary<DlcType, VampireSurvivors.Framework.DLC.DlcData>.Enumerator enumerator = default(Dictionary<DlcType, VampireSurvivors.Framework.DLC.DlcData>.Enumerator);
		if (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			System.Int32Enum int32Enum = (System.Int32Enum)0;
			Dictionary<DlcType, VampireSurvivors.Framework.DLC.DlcData>.Enumerator enumerator2 = (Dictionary<DlcType, VampireSurvivors.Framework.DLC.DlcData>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return false;
	}

	public static string GetLocalizedName(ContentGroupType content)
	{
		string term;
		switch (content)
		{
		case ContentGroupType.BASE:
			term = "lang/menu_CollectionVersion";
			break;
		case ContentGroupType.EXTRA:
			term = "lang/menu_CollectionExtra";
			break;
		default:
		{
			string locKeyForDlcContentGroup = GetLocKeyForDlcContentGroup(content);
			term = locKeyForDlcContentGroup;
			break;
		}
		}
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		return LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
	}

	public unsafe static DlcType? GetDlcTypeContentGroup(ContentGroupType contentGroupType)
	{
		//IL_007a: Expected O, but got I4
		//IL_0034: Expected O, but got Ref
		//IL_006f: Expected O, but got I4
		Dictionary<DlcType, VampireSurvivors.Framework.DLC.DlcData>.Enumerator enumerator = default(Dictionary<DlcType, VampireSurvivors.Framework.DLC.DlcData>.Enumerator);
		object obj = default(object);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				bool flag = obj == null;
				Dictionary<DlcType, VampireSurvivors.Framework.DLC.DlcData>.Enumerator enumerator2 = (Dictionary<DlcType, VampireSurvivors.Framework.DLC.DlcData>.Enumerator)(&enumerator);
				if (flag)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ stack_-20+38]");
				if ((nint)0 == (nint)contentGroupType)
				{
					return (DlcType?)(object)1;
				}
				continue;
			}
			return (DlcType?)(object)0;
		}
		throw new NullReferenceException();
	}

	public unsafe static string GetLocKeyForDlcContentGroup(ContentGroupType contentGroupType)
	{
		//IL_0034: Expected O, but got Ref
		//IL_0076: Expected O, but got I
		Dictionary<DlcType, VampireSurvivors.Framework.DLC.DlcData>.Enumerator enumerator = default(Dictionary<DlcType, VampireSurvivors.Framework.DLC.DlcData>.Enumerator);
		object obj = default(object);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				bool flag = obj == null;
				Dictionary<DlcType, VampireSurvivors.Framework.DLC.DlcData>.Enumerator enumerator2 = (Dictionary<DlcType, VampireSurvivors.Framework.DLC.DlcData>.Enumerator)(&enumerator);
				if (flag)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ stack_-20+38]");
				if ((nint)0 == (nint)contentGroupType)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ stack_-20+20]");
					return (string)0;
				}
				continue;
			}
			return "";
		}
		throw new NullReferenceException();
	}
}
