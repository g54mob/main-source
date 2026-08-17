using System;
using Assets.Scripts.Game.Spawning.New;
using Cpp2ILInjected;

namespace Assets.Scripts._Data.Progression.Achievements.Challenges.ChallengeWinConditions;

public class ChallengeWinConditionReachFinalSwarm : ChallengeWinCondition
{
	public override void Init(ChallengeData challengeData)
	{
		//IL_0124: Expected I, but got O
		Action b = base.ChallengeCompleted;
		Delegate obj = Delegate.Combine(SummonerController.A_FinalSwarmStarted, b);
		if ((object)obj == null)
		{
			SummonerController.A_FinalSwarmStarted = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			SummonerController.A_FinalSwarmStarted = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override void Cleanup()
	{
		//IL_0124: Expected I, but got O
		Action value = base.ChallengeCompleted;
		Delegate obj = Delegate.Remove(SummonerController.A_FinalSwarmStarted, value);
		if ((object)obj == null)
		{
			SummonerController.A_FinalSwarmStarted = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			SummonerController.A_FinalSwarmStarted = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}
}
