using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;

namespace VampireSurvivors.Achievements;

public class Foscari_CustomAchivementHandleing : ICustomAchievements
{
	public List<AchievementType> CheckAchievements(PlayerOptions playerOptions, AchievementManager achievementManager, DataManager dataManager)
	{
		//IL_0045: Expected O, but got I
		//IL_0101: Expected O, but got I
		//IL_01bd: Expected O, but got I
		//IL_009f: Expected O, but got I
		//IL_015b: Expected O, but got I
		//IL_021c: Expected O, but got I
		List<AchievementType> list = new List<AchievementType>();
		int destroyCount = GetDestroyCount(playerOptions, PropType.FOSCARI_SEAL_1);
		if (destroyCount >= 1)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdx_v14+18]");
			if (num >= 0)
			{
				((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)173);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
				object obj2 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdx_v14+18]");
				if (num2 >= 0)
				{
					goto IL_02ad;
				}
				_ = 173;
			}
		}
		int destroyCount2 = GetDestroyCount(playerOptions, PropType.FOSCARI_SEAL_2);
		if (destroyCount2 >= 1)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rdx_v11+18]");
			if (num3 >= 0)
			{
				((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)174);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
				object obj4 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rdx_v11+18]");
				if (num4 >= 0)
				{
					goto IL_02ad;
				}
				_ = 174;
			}
		}
		int destroyCount3 = GetDestroyCount(playerOptions, PropType.FOSCARI_SEAL_3);
		if (destroyCount3 >= 1)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdx_v9+18]");
			if (num5 < 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
				object obj6 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdx_v9+18]");
				if (num6 < 0)
				{
					_ = 175;
					return list;
				}
				goto IL_02ad;
			}
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)175);
		}
		return list;
		IL_02ad:
		return (List<AchievementType>)(object)new IndexOutOfRangeException();
	}

	public List<AchievementType> GetUnlocksThatNeedFixing(PlayerOptions playerOptions)
	{
		return null;
	}

	public List<AchievementType> CheckForStartupAchievements(PlayerOptions playerOptions)
	{
		return null;
	}

	public void RunSecretsCheck(AchievementManager achievementManager, PlayerOptions playerOptions, DataManager dataManager)
	{
	}

	private int GetDestroyCount(PlayerOptions playerOptions, PropType t)
	{
		//IL_0102: Expected I4, but got O
		if (playerOptions != null)
		{
			PlayerOptionsData config = playerOptions.Config;
			if (config != null && config._003CDestroyedCount_003Ek__BackingField != null)
			{
				int num = config._003CDestroyedCount_003Ek__BackingField.FindEntry(t);
				if (num < 0)
				{
					return 0;
				}
				PlayerOptionsData config2 = playerOptions.Config;
				if (config2 != null && config2._003CDestroyedCount_003Ek__BackingField != null)
				{
					return config2._003CDestroyedCount_003Ek__BackingField.get_Item(t);
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}
}
