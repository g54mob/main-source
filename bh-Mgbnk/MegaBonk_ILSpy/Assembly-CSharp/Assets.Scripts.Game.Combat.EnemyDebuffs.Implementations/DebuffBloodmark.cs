using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Game.Combat.EnemyDebuffs.Implementations;

public class DebuffBloodmark : EnemyDebuff
{
	public const float defaultDuration = 4f;

	private int stacks;

	public static string damageSource;

	private DamageContainer dc;

	private float baseDamageMultiplier;

	private float damage;

	private bool isDone;

	private bool isSubscribed;

	public override int GetStacks()
	{
		return stacks;
	}

	public override void MyTick()
	{
	}

	public float GetDamage()
	{
		return damage;
	}

	public override void AddStacks(int numStacks)
	{
		int num = stacks + numStacks;
		stacks = num;
		MyPlayer instance = MyPlayer.Instance;
		float stat = PlayerStats.GetStat(EStat.DamageMultiplier);
		Enemy enemy = base.enemy;
		float num2 = baseDamageMultiplier * instance.baseDamage;
		float num3 = num2 * (float)stacks;
		if (!((damage = stat * num3) < enemy._003Chp_003Ek__BackingField))
		{
			base._003CticksLeft_003Ek__BackingField = 0;
			isDone = true;
			dc.Reuse(0f, damageSource);
			DamageContainer damageContainer = dc;
			damageContainer.damage = damage;
			DamageContainer damageContainer2 = dc;
			damageContainer2.enemy = base.enemy;
			DamageContainer damageContainer3 = dc;
			damageContainer3.damageEffect = EDamageEffect.Bloodmark;
			base.enemy.DamageFromPlayerOther(dc);
			stacks = 0;
			damage = 0f;
		}
	}

	public override EDebuff GetDebuffType()
	{
		return EDebuff.Bloodmark;
	}

	public override void OnRemove(bool fromDeath)
	{
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_0303: Expected O, but got I4
		//IL_00bb: Expected O, but got I4
		//IL_00c0: Expected I, but got O
		//IL_00ce: Expected I, but got O
		//IL_0094: Expected I, but got O
		//IL_0118: Expected I, but got O
		//IL_0129: Expected O, but got I4
		//IL_012e: Expected I, but got O
		//IL_013c: Expected I, but got O
		//IL_0166: Expected O, but got I4
		//IL_016b: Expected I, but got O
		Delegate obj;
		nint num;
		Delegate obj5;
		object obj2;
		nint num2;
		nint num3;
		if (isSubscribed)
		{
			Enemy enemy = base.enemy;
			if ((object)base.enemy != null)
			{
				Action<Enemy, DamageContainer> value = OnEnemyDamaged;
				obj = Delegate.Remove(enemy.A_DamageNonStatic, value);
				if ((object)obj == null)
				{
					enemy.A_DamageNonStatic = (Action<Enemy, DamageContainer>)obj;
					num = (nint)enemy.A_DamageNonStatic;
					goto IL_014a;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				Action<Enemy, DamageContainer> action = default(Action<Enemy, DamageContainer>);
				bool flag = action == null;
				obj2 = 0;
				num2 = unchecked((nint)null);
				num3 = (nint)typeof(Action<Enemy, DamageContainer>);
				Delegate obj3 = obj;
				if (!flag)
				{
					enemy.A_DamageNonStatic = action;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					object obj4 = default(object);
					bool flag2 = obj4 == null;
					num = (nint)typeof(Action<Enemy, DamageContainer>);
					obj5 = obj;
					obj2 = 0;
					num2 = unchecked((nint)null);
					num3 = (nint)typeof(Action<Enemy, DamageContainer>);
					if (!flag2)
					{
						goto IL_014a;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
					obj3 = obj5;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				return;
			}
			goto IL_02aa;
		}
		goto IL_0311;
		IL_0311:
		bool flag3 = stacks == 0;
		if (stacks > 0)
		{
			Enemy enemy2 = base.enemy;
			if ((object)base.enemy == null)
			{
				goto IL_02aa;
			}
			object obj6 = 0 - enemy2._003Chp_003Ek__BackingField;
			flag3 = obj6 == null;
		}
		object obj7 = !flag3;
		if (obj7 != null)
		{
			return;
		}
		DamageContainer damageContainer = dc;
		if (dc != null)
		{
			damageContainer.damage = damage;
			DamageContainer damageContainer2 = dc;
			if (dc != null)
			{
				damageContainer2.enemy = base.enemy;
				DamageContainer damageContainer3 = dc;
				if (dc != null)
				{
					damageContainer3.damageEffect = EDamageEffect.Bloodmark;
					if ((object)base.enemy != null)
					{
						base.enemy.DamageFromPlayerOther(dc);
						return;
					}
				}
			}
		}
		goto IL_02aa;
		IL_02aa:
		throw new NullReferenceException();
		IL_014a:
		isSubscribed = false;
		obj5 = obj;
		obj2 = 0;
		num2 = unchecked((nint)null);
		num3 = num;
		goto IL_0311;
	}

	public override void OnAdded()
	{
		//IL_009f: Expected O, but got I4
		//IL_00a8: Expected O, but got I4
		//IL_00b6: Expected I, but got O
		if (isSubscribed)
		{
			return;
		}
		Enemy enemy = base.enemy;
		isDone = false;
		Action<Enemy, DamageContainer> b = OnEnemyDamaged;
		Delegate obj = Delegate.Combine(enemy.A_DamageNonStatic, b);
		if ((object)obj == null)
		{
			enemy.A_DamageNonStatic = (Action<Enemy, DamageContainer>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy, DamageContainer> action = default(Action<Enemy, DamageContainer>);
		bool flag = action == null;
		object obj2 = 0;
		object obj3 = 0;
		nint num = (nint)typeof(Action<Enemy, DamageContainer>);
		Delegate obj4 = obj;
		if (!flag)
		{
			enemy.A_DamageNonStatic = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			if (obj5 != null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			object obj6 = default(object);
			obj2 = obj6;
			object obj7 = default(object);
			obj3 = obj7;
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			Delegate obj8 = default(Delegate);
			obj4 = obj8;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnEnemyDamaged(Enemy e, DamageContainer dc)
	{
		//IL_0043: Invalid comparison between I4 and F4
		if (e == base.enemy)
		{
			Enemy enemy = base.enemy;
			if (0f < enemy._003Chp_003Ek__BackingField && !enemy.isDyingNextFrame && !(damage < e._003Chp_003Ek__BackingField))
			{
				bool flag = e.debuffsToRemove.Add(EDebuff.Bloodmark);
			}
		}
	}

	public override void OnRefresh()
	{
		if (isDone)
		{
			base._003CticksLeft_003Ek__BackingField = 0;
		}
	}

	protected override void OnResetState()
	{
		stacks = 0;
		damage = 0f;
		isDone = false;
	}

	public DebuffBloodmark()
	{
		//IL_0013: Expected O, but got I4
		string text = default(string);
		DamageContainer damageContainer = new DamageContainer(0f, text)
		{
			damageSource = damageSource,
			procCoefficient = 0f,
			direction = (Vector3)0
		};
		_ = 0;
		damageContainer.crit = false;
		damageContainer.knockback = 0f;
		damageContainer.enemy = null;
		damageContainer.damageEffect = EDamageEffect.None;
		damageContainer.damageBlockedByArmor = 0;
		damageContainer.isExecute = false;
		damageContainer.canProcJoe = false;
		dc = damageContainer;
		baseDamageMultiplier = 0.75f;
		MyTick();
	}

	unsafe static DebuffBloodmark()
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		damageSource = text;
	}
}
