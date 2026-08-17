using System;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Managers;
using Assets.Scripts.Utility;
using Cpp2ILInjected;

public class ChallengeModifierSpeedrun : ChallengeModifier
{
	public float timeLimitMinutes;

	private bool isFinalBossKilled;

	private float _003CtimeLeftOnStage_003Ek__BackingField;

	public float timeLeftOnStage
	{
		get
		{
			return _003CtimeLeftOnStage_003Ek__BackingField;
		}
		private set
		{
			_003CtimeLeftOnStage_003Ek__BackingField = value;
		}
	}

	public override void Init(ChallengeData challengeData)
	{
		//IL_02bc: Expected O, but got I4
		//IL_0386: Expected I, but got O
		//IL_032f: Expected O, but got I4
		//IL_0345: Expected I, but got O
		//IL_0130: Expected I, but got O
		//IL_0141: Expected O, but got I4
		//IL_0184: Expected I, but got O
		//IL_0195: Expected O, but got I4
		//IL_0238: Expected O, but got I4
		//IL_028c: Expected O, but got I4
		Delegate obj = GameManager.A_StageStarted;
		Action action = OnStageStarted;
		Delegate obj2 = Delegate.Combine(GameManager.A_StageStarted, action);
		Action action2;
		object obj4;
		Delegate obj5;
		if ((object)obj2 == null)
		{
			GameManager.A_StageStarted = null;
		}
		else
		{
			bool flag = (object)obj2.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag)
			{
				obj3 = obj2;
			}
			if ((object)obj3 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				action2 = action;
				obj4 = 0;
				obj5 = obj2;
				goto IL_0393;
			}
			GameManager.A_StageStarted = (Action)obj3;
			bool flag2 = (object)obj2.GetType() != typeof(Action);
			Delegate obj6 = null;
			if (!flag2)
			{
				obj6 = obj2;
			}
			bool flag3 = (object)obj6 == null;
			obj4 = 0;
			obj5 = obj2;
			nint num = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_03a3;
			}
		}
		Action<bool> b = OnStageBossDied;
		Delegate obj7 = Delegate.Combine(InteractableBossSpawner.A_BossDefeated, b);
		nint num2;
		Delegate obj8;
		if ((object)obj7 == null)
		{
			InteractableBossSpawner.A_BossDefeated = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<bool> action3 = default(Action<bool>);
			bool flag4 = action3 == null;
			num2 = (nint)typeof(Action<bool>);
			obj8 = obj7;
			obj4 = 0;
			obj5 = null;
			if (flag4)
			{
				goto IL_0353;
			}
			InteractableBossSpawner.A_BossDefeated = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num2 = (nint)typeof(Action<bool>);
			obj8 = obj7;
			obj4 = 0;
			obj5 = null;
			if (flag5)
			{
				goto IL_0363;
			}
		}
		Action<bool> b2 = OnFinalBossDefeated;
		Delegate obj10 = Delegate.Combine(FinalFightController.A_BossDefeated, b2);
		if ((object)obj10 == null)
		{
			FinalFightController.A_BossDefeated = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<bool> action4 = default(Action<bool>);
		bool flag6 = action4 == null;
		obj = (Delegate)(object)typeof(Action<bool>);
		action2 = (Action)obj10;
		obj4 = 0;
		obj5 = null;
		if (flag6)
		{
			goto IL_0373;
		}
		FinalFightController.A_BossDefeated = action4;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj11 = default(object);
		bool flag7 = obj11 == null;
		obj = (Delegate)(object)typeof(Action<bool>);
		action2 = (Action)obj10;
		obj4 = 0;
		obj5 = null;
		if (!flag7)
		{
			return;
		}
		goto IL_0393;
		IL_0353:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03a3;
		IL_0373:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = (nint)obj;
		obj8 = action2;
		goto IL_0363;
		IL_03a3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0393:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0373;
		IL_0363:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0353;
	}

	public override void Cleanup()
	{
		//IL_02bc: Expected O, but got I4
		//IL_0386: Expected I, but got O
		//IL_032f: Expected O, but got I4
		//IL_0345: Expected I, but got O
		//IL_0130: Expected I, but got O
		//IL_0141: Expected O, but got I4
		//IL_0184: Expected I, but got O
		//IL_0195: Expected O, but got I4
		//IL_0238: Expected O, but got I4
		//IL_028c: Expected O, but got I4
		Delegate obj = GameManager.A_StageStarted;
		Action action = OnStageStarted;
		Delegate obj2 = Delegate.Remove(GameManager.A_StageStarted, action);
		Action action2;
		object obj4;
		Delegate obj5;
		if ((object)obj2 == null)
		{
			GameManager.A_StageStarted = null;
		}
		else
		{
			bool flag = (object)obj2.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag)
			{
				obj3 = obj2;
			}
			if ((object)obj3 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				action2 = action;
				obj4 = 0;
				obj5 = obj2;
				goto IL_0393;
			}
			GameManager.A_StageStarted = (Action)obj3;
			bool flag2 = (object)obj2.GetType() != typeof(Action);
			Delegate obj6 = null;
			if (!flag2)
			{
				obj6 = obj2;
			}
			bool flag3 = (object)obj6 == null;
			obj4 = 0;
			obj5 = obj2;
			nint num = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_03a3;
			}
		}
		Action<bool> value = OnStageBossDied;
		Delegate obj7 = Delegate.Remove(InteractableBossSpawner.A_BossDefeated, value);
		nint num2;
		Delegate obj8;
		if ((object)obj7 == null)
		{
			InteractableBossSpawner.A_BossDefeated = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<bool> action3 = default(Action<bool>);
			bool flag4 = action3 == null;
			num2 = (nint)typeof(Action<bool>);
			obj8 = obj7;
			obj4 = 0;
			obj5 = null;
			if (flag4)
			{
				goto IL_0353;
			}
			InteractableBossSpawner.A_BossDefeated = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num2 = (nint)typeof(Action<bool>);
			obj8 = obj7;
			obj4 = 0;
			obj5 = null;
			if (flag5)
			{
				goto IL_0363;
			}
		}
		Action<bool> value2 = OnFinalBossDefeated;
		Delegate obj10 = Delegate.Remove(FinalFightController.A_BossDefeated, value2);
		if ((object)obj10 == null)
		{
			FinalFightController.A_BossDefeated = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<bool> action4 = default(Action<bool>);
		bool flag6 = action4 == null;
		obj = (Delegate)(object)typeof(Action<bool>);
		action2 = (Action)obj10;
		obj4 = 0;
		obj5 = null;
		if (flag6)
		{
			goto IL_0373;
		}
		FinalFightController.A_BossDefeated = action4;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj11 = default(object);
		bool flag7 = obj11 == null;
		obj = (Delegate)(object)typeof(Action<bool>);
		action2 = (Action)obj10;
		obj4 = 0;
		obj5 = null;
		if (!flag7)
		{
			return;
		}
		goto IL_0393;
		IL_0353:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03a3;
		IL_0373:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = (nint)obj;
		obj8 = action2;
		goto IL_0363;
		IL_03a3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0393:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0373;
		IL_0363:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0353;
	}

	private void OnFinalBossDefeated(bool obj)
	{
		isFinalBossKilled = true;
	}

	private void OnStageBossDied(bool obj)
	{
		if (MapController.IsTierFinalStage())
		{
			isFinalBossKilled = true;
		}
	}

	private void OnStageStarted()
	{
		isFinalBossKilled = false;
		float num = timeLimitMinutes * 60f;
		float num2 = num - MyTime.runTimer;
		double num3 = Math.Round(num2);
		_003CtimeLeftOnStage_003Ek__BackingField = (float)num3;
	}

	public override void Tick()
	{
		if (!(GameManager.Instance != null))
		{
			return;
		}
		GameManager instance = GameManager.Instance;
		if (!instance.isPlaying || isFinalBossKilled || !(MyPlayer.Instance != null))
		{
			return;
		}
		MyPlayer instance2 = MyPlayer.Instance;
		if (instance2.inventory == null)
		{
			return;
		}
		MyPlayer instance3 = MyPlayer.Instance;
		PlayerInventory inventory = instance3.inventory;
		if (!inventory.playerHealth.IsDead())
		{
			float num = timeLimitMinutes * 60f;
			if (!(MyTime.runTimer < num))
			{
				MyPlayer instance4 = MyPlayer.Instance;
				PlayerInventory inventory2 = instance4.inventory;
				inventory2.playerHealth.KillPlayer();
			}
		}
	}
}
