using System;
using Assets.Scripts.Managers;
using Cpp2ILInjected;

namespace Assets.Scripts._Data.Progression.Achievements.Challenges.ChallengeWinConditions;

public class ChallengeWinConditionKillTierBoss : ChallengeWinCondition
{
	public override void Init(ChallengeData challengeData)
	{
		//IL_0273: Expected I, but got O
		//IL_0284: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_0130: Expected I, but got O
		//IL_0141: Expected O, but got I4
		//IL_0184: Expected I, but got O
		//IL_0195: Expected O, but got I4
		//IL_02f2: Expected I, but got O
		//IL_033a: Expected O, but got I4
		//IL_0350: Expected I, but got O
		//IL_037e: Expected O, but got I4
		//IL_0394: Expected I, but got O
		Action<bool> b = OnStageBossDied;
		Delegate obj = Delegate.Combine(InteractableBossSpawner.A_BossDefeated, b);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			InteractableBossSpawner.A_BossDefeated = (Action<bool>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<bool> action = default(Action<bool>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<bool>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_03b2;
			}
			InteractableBossSpawner.A_BossDefeated = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<bool>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_02b6;
			}
		}
		Action<bool> b2 = OnStageBossDied;
		Delegate obj6 = Delegate.Combine(FinalFightController.A_BossDefeated, b2);
		if ((object)obj6 == null)
		{
			FinalFightController.A_BossDefeated = (Action<bool>)obj6;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<bool> action2 = default(Action<bool>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<bool>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag2)
			{
				goto IL_02c1;
			}
			FinalFightController.A_BossDefeated = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num = (nint)typeof(Action<bool>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag3)
			{
				goto IL_02d1;
			}
		}
		num = (nint)GraveyardBossRoom.A_BossDied;
		Action action3 = OnGhostBossDied;
		Delegate obj8 = Delegate.Combine(GraveyardBossRoom.A_BossDied, action3);
		if ((object)obj8 == null)
		{
			GraveyardBossRoom.A_BossDied = null;
			return;
		}
		bool flag4 = (object)obj8.GetType() != typeof(Action);
		Delegate obj9 = null;
		if (!flag4)
		{
			obj9 = obj8;
		}
		bool flag5 = (object)obj9 == null;
		obj2 = action3;
		obj3 = 0;
		obj4 = obj8;
		nint num3 = (nint)typeof(Action);
		if (flag5)
		{
			goto IL_03a2;
		}
		GraveyardBossRoom.A_BossDied = (Action)obj9;
		bool flag6 = (object)obj8.GetType() != typeof(Action);
		Delegate obj10 = null;
		if (!flag6)
		{
			obj10 = obj8;
		}
		bool flag7 = (object)obj10 == null;
		obj2 = action3;
		obj3 = 0;
		obj4 = obj8;
		nint num4 = (nint)typeof(Action);
		if (!flag7)
		{
			return;
		}
		goto IL_03b2;
		IL_03a2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02d1;
		IL_03b2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03a2;
		IL_02d1:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_02c1;
		IL_02b6:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_02c1:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02b6;
	}

	public override void Cleanup()
	{
		//IL_0273: Expected I, but got O
		//IL_0284: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_0130: Expected I, but got O
		//IL_0141: Expected O, but got I4
		//IL_0184: Expected I, but got O
		//IL_0195: Expected O, but got I4
		//IL_02f2: Expected I, but got O
		//IL_033a: Expected O, but got I4
		//IL_0350: Expected I, but got O
		//IL_037e: Expected O, but got I4
		//IL_0394: Expected I, but got O
		Action<bool> value = OnStageBossDied;
		Delegate obj = Delegate.Remove(InteractableBossSpawner.A_BossDefeated, value);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			InteractableBossSpawner.A_BossDefeated = (Action<bool>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<bool> action = default(Action<bool>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<bool>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_03b2;
			}
			InteractableBossSpawner.A_BossDefeated = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<bool>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_02b6;
			}
		}
		Action<bool> value2 = OnStageBossDied;
		Delegate obj6 = Delegate.Remove(FinalFightController.A_BossDefeated, value2);
		if ((object)obj6 == null)
		{
			FinalFightController.A_BossDefeated = (Action<bool>)obj6;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<bool> action2 = default(Action<bool>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<bool>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag2)
			{
				goto IL_02c1;
			}
			FinalFightController.A_BossDefeated = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num = (nint)typeof(Action<bool>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag3)
			{
				goto IL_02d1;
			}
		}
		num = (nint)GraveyardBossRoom.A_BossDied;
		Action action3 = OnGhostBossDied;
		Delegate obj8 = Delegate.Remove(GraveyardBossRoom.A_BossDied, action3);
		if ((object)obj8 == null)
		{
			GraveyardBossRoom.A_BossDied = null;
			return;
		}
		bool flag4 = (object)obj8.GetType() != typeof(Action);
		Delegate obj9 = null;
		if (!flag4)
		{
			obj9 = obj8;
		}
		bool flag5 = (object)obj9 == null;
		obj2 = action3;
		obj3 = 0;
		obj4 = obj8;
		nint num3 = (nint)typeof(Action);
		if (flag5)
		{
			goto IL_03a2;
		}
		GraveyardBossRoom.A_BossDied = (Action)obj9;
		bool flag6 = (object)obj8.GetType() != typeof(Action);
		Delegate obj10 = null;
		if (!flag6)
		{
			obj10 = obj8;
		}
		bool flag7 = (object)obj10 == null;
		obj2 = action3;
		obj3 = 0;
		obj4 = obj8;
		nint num4 = (nint)typeof(Action);
		if (!flag7)
		{
			return;
		}
		goto IL_03b2;
		IL_03a2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02d1;
		IL_03b2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03a2;
		IL_02d1:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_02c1;
		IL_02b6:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_02c1:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02b6;
	}

	private void OnStageBossDied(bool didPortalOpen)
	{
		if (MapController.IsTierFinalStage())
		{
			ChallengeCompleted();
		}
	}

	private void OnGhostBossDied()
	{
		if (MapController.IsTierFinalStage())
		{
			ChallengeCompleted();
		}
	}
}
