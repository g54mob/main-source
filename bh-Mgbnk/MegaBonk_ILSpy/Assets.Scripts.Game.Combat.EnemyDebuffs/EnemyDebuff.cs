using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;

namespace Assets.Scripts.Game.Combat.EnemyDebuffs;

public abstract class EnemyDebuff
{
	private int _003CticksLeft_003Ek__BackingField;

	protected Enemy enemy;

	public int ticksLeft
	{
		get
		{
			return _003CticksLeft_003Ek__BackingField;
		}
		protected set
		{
			_003CticksLeft_003Ek__BackingField = value;
		}
	}

	public EnemyDebuff()
	{
	}

	public void Set(Enemy enemy, DamageContainer dc, float duration, int stacks = 1)
	{
		_003CticksLeft_003Ek__BackingField = 0;
		this.enemy = enemy;
		int numStacks = default(int);
		AddStacks(numStacks);
		int ticks = GetTicks(duration);
		if (ticks > _003CticksLeft_003Ek__BackingField)
		{
			int ticks2 = GetTicks(duration);
			_003CticksLeft_003Ek__BackingField = ticks2;
		}
		OnRefresh();
		OnAdded();
	}

	public virtual void Tick()
	{
		MyTick();
		int num = _003CticksLeft_003Ek__BackingField - 1;
		_003CticksLeft_003Ek__BackingField = num;
	}

	public bool IsDone()
	{
		int num = _003CticksLeft_003Ek__BackingField ^ _003CticksLeft_003Ek__BackingField;
		int num2 = _003CticksLeft_003Ek__BackingField & num;
		bool flag = num2 < 0;
		bool flag2 = _003CticksLeft_003Ek__BackingField < 0;
		bool flag3 = _003CticksLeft_003Ek__BackingField == 0;
		bool flag4 = flag2 != flag;
		return flag4 | flag3;
	}

	public void Refresh(float duration, int stacks)
	{
		AddStacks(stacks);
		int ticks = GetTicks(duration);
		if (ticks > _003CticksLeft_003Ek__BackingField)
		{
			int ticks2 = GetTicks(duration);
			_003CticksLeft_003Ek__BackingField = ticks2;
		}
		OnRefresh();
	}

	private int GetTicks(float duration)
	{
		//IL_01ae: Expected I, but got O
		//IL_019b: Expected I4, but got F8
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Expected O, but got Unknown
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		float stat = PlayerStats.GetStat(EStat.DurationMultiplier);
		float num = (float)DebuffUtility.debuffTicksPerSecond * duration;
		float num2 = stat * num;
		nint num3 = (nint)typeof(Math);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm6,xmm6\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm6,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v5 (Il2CppClass<System.Math>)+E4]");
		double num4 = default(double);
		double num5;
		if ((nint)0 >= (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FD990");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001804A9C69h\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v5 (Il2CppClass<System.Math>)+E4]");
			if ((nint)0 == 0)
			{
				object obj = num4 & 1;
				bool flag = obj == null;
				num5 = num4;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,qword ptr [18262EC98h]\"");
					num5 = num4;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm6,xmm1\"");
				num5 = Math.Floor(num2);
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FD990");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,qword ptr [18262ED10h]\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001804A9CA1h\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v5 (Il2CppClass<System.Math>)+E4]");
			if ((nint)0 == 0)
			{
				object obj2 = num4 & 1;
				bool flag2 = obj2 == null;
				num5 = num4;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm0,qword ptr [18262EC98h]\"");
					num5 = num4;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm6,qword ptr [18262EC90h]\"");
				num5 = Math.Ceiling(num2);
			}
		}
		return (int)num5;
	}

	private void RefreshTimeout(float duration)
	{
		int ticks = GetTicks(duration);
		_003CticksLeft_003Ek__BackingField = ticks;
	}

	public void ResetState()
	{
		_003CticksLeft_003Ek__BackingField = 0;
		OnResetState();
	}

	public abstract void AddStacks(int numStacks);

	public abstract int GetStacks();

	public abstract void MyTick();

	public abstract EDebuff GetDebuffType();

	public abstract void OnRemove(bool fromDeath);

	public abstract void OnAdded();

	public abstract void OnRefresh();

	protected abstract void OnResetState();
}
