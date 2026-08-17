using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using VampireSurvivors.Achievements;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Platforms;

namespace VampireSurvivors;

public class DummyAchievementsManager : IPlatformAchievementsManager, ILastErrorProvider
{
	private AchievementsManagerState m_State;

	public unsafe ErroInfo LastError
	{
		get
		{
			//IL_0013: Expected I, but got O
			//IL_0036: Expected I4, but got O
			//IL_0031: Expected native int or pointer, but got O
			//IL_004b: Expected O, but got I
			//IL_0046: Expected native int or pointer, but got O
			nint num = (nint)typeof(ErroInfo);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v3 (Il2CppClass<VampireSurvivors.Framework.Platforms.ErroInfo>)+B8]");
			nint num2 = 0;
			ErroInfo erroInfo = default(ErroInfo);
			((ErroInfo*)(nint)erroInfo)->NativeErrorCode = (int)ErroInfo.NonError;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v4 (Il2CppStaticFields<VampireSurvivors.Framework.Platforms.ErroInfo>)+10]");
			System.Runtime.CompilerServices.Unsafe.Write(&((ErroInfo*)(nint)erroInfo)->Message, (string)0);
			return erroInfo;
		}
	}

	public AchievementsManagerState State => m_State;

	public void Close()
	{
		m_State = AchievementsManagerState.NonInitialized;
	}

	public void InitAsync(Dictionary<AchievementType, AchievementData> readonly_achievementDefinitions, List<AchievementType> inout_Completed, Action<bool, List<AchievementType>> onComplete)
	{
		m_State = AchievementsManagerState.ReadyToUse;
		if (onComplete != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [onComplete @ r9 (System.Action`2<System.Boolean, System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>>)+18] (should have been resolved before IL gen)");
		}
	}

	public void ReportProgressAsync(AchievementType id, float newprogress = 1f, Action<AchievementType, bool> onComplete = null)
	{
		if (onComplete != null)
		{
			bool flag = m_State == AchievementsManagerState.NonInitialized;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [onComplete @ r9 (System.Action`2<VampireSurvivors.Data.AchievementType, System.Boolean>)+18] (should have been resolved before IL gen)");
		}
	}
}
