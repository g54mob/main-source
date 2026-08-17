using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;

namespace VampireSurvivors.Achievements;

public class Chalcedony_CustomAchivementHandleing : ICustomAchievements
{
	public List<AchievementType> CheckAchievements(PlayerOptions playerOptions, AchievementManager achievementManager, DataManager dataManager)
	{
		//IL_0057: Expected O, but got I
		//IL_00b1: Expected O, but got I
		List<AchievementType> list = new List<AchievementType>();
		int num = achievementManager.CountKilledEnemiesAndVariants(EnemyType.CHAL_SUS_COUNTER);
		if (num >= 6000)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v6+18]");
			if (num2 >= 0)
			{
				((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)214);
				return list;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v6+18]");
			if (num3 >= 0)
			{
				return (List<AchievementType>)(object)new IndexOutOfRangeException();
			}
			_ = 214;
		}
		return list;
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
}
