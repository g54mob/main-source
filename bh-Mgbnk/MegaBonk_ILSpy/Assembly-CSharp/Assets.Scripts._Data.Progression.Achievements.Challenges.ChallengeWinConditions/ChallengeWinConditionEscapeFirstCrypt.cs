using System;
using Cpp2ILInjected;

namespace Assets.Scripts._Data.Progression.Achievements.Challenges.ChallengeWinConditions;

public class ChallengeWinConditionEscapeFirstCrypt : ChallengeWinCondition
{
	private ChallengeData challengeData;

	public override void Init(ChallengeData challengeData)
	{
		//IL_00c4: Expected I, but got O
		//IL_009c: Expected I, but got O
		this.challengeData = challengeData;
		Action<float> b = OnCryptCompleted;
		Delegate obj = Delegate.Combine(InteractableCryptLeave.A_FirstDungeonCompleted, b);
		if ((object)obj == null)
		{
			InteractableCryptLeave.A_FirstDungeonCompleted = (Action<float>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<float> action = default(Action<float>);
		if (action != null)
		{
			InteractableCryptLeave.A_FirstDungeonCompleted = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<float>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<float>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override void Cleanup()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<float> value = OnCryptCompleted;
		Delegate obj = Delegate.Remove(InteractableCryptLeave.A_FirstDungeonCompleted, value);
		if ((object)obj == null)
		{
			InteractableCryptLeave.A_FirstDungeonCompleted = (Action<float>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<float> action = default(Action<float>);
		if (action != null)
		{
			InteractableCryptLeave.A_FirstDungeonCompleted = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<float>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<float>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnCryptCompleted(float time)
	{
		//IL_001c: Invalid comparison between I4 and F4
		ChallengeData challengeData = this.challengeData;
		if (!((float)challengeData.targetValue < time))
		{
			ChallengeCompleted();
		}
	}
}
