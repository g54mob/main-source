using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using Utility;

namespace Assets.Scripts.Inventory__Items__Pickups.Weapons.WeaponPassives;

public class WeaponPassiveBloodMagic : WeaponPassive
{
	private int stacks;

	private float stackChance = 0.05f;

	private static string bloodMagicDamageSource;

	private static float maxRollsUpgradesPerMinute;

	private float rollCooldown = maxRollsUpgradesPerMinute / 60f;

	private float nextReadyTime;

	public override void Init()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<Enemy, DamageContainer> b = OnEnemyDied;
		Delegate obj = Delegate.Combine(Enemy.A_EnemyDied, b);
		if ((object)obj == null)
		{
			Enemy.A_EnemyDied = (Action<Enemy, DamageContainer>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy, DamageContainer> action = default(Action<Enemy, DamageContainer>);
		if (action != null)
		{
			Enemy.A_EnemyDied = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<Enemy, DamageContainer>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<Enemy, DamageContainer>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override void Cleanup()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<Enemy, DamageContainer> value = OnEnemyDied;
		Delegate obj = Delegate.Remove(Enemy.A_EnemyDied, value);
		if ((object)obj == null)
		{
			Enemy.A_EnemyDied = (Action<Enemy, DamageContainer>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy, DamageContainer> action = default(Action<Enemy, DamageContainer>);
		if (action != null)
		{
			Enemy.A_EnemyDied = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<Enemy, DamageContainer>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<Enemy, DamageContainer>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnEnemyDied(Enemy enemy, DamageContainer dc)
	{
		//IL_0094: Expected F4, but got I4
		if (dc != null && !(nextReadyTime > MyTime.time) && dc.damageSource == bloodMagicDamageSource)
		{
			double num = MyRandom.random.NextDouble();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm0\"");
			if ((nint)MyRandom.random > 0)
			{
				int num2 = stacks + 1;
				stacks = num2;
				float num3 = MyTime.time + rollCooldown;
				nextReadyTime = num3;
				MyPlayer instance = MyPlayer.Instance;
				PlayerInventory inventory = instance.inventory;
				StatModifier statModifier = new StatModifier();
				statModifier.modifyType = EStatModifyType.Flat;
				statModifier.stat = EStat.MaxHealth;
				statModifier.modification = stacks;
				inventory.statInventory.ChangeMovingStat(bloodMagicDamageSource, statModifier);
				MyStats.AddValue(EMyStat.bloodMagicProcs, 1f);
			}
		}
	}

	public WeaponPassiveBloodMagic(WeaponBase weaponBase)
		: base(weaponBase)
	{
	}

	unsafe static WeaponPassiveBloodMagic()
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		bloodMagicDamageSource = text;
		maxRollsUpgradesPerMinute = 100f;
	}
}
