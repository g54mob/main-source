using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat.EnemyDebuffs;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemToxicBarrel : ItemBase
{
	public static Action<float> A_OnUse;

	private float radius;

	private float radiusPerAmount;

	private int poisonStacksPerAmount;

	private int poisonStacks;

	private float cooldown;

	private float readyAtTime;

	private float poisonDuration;

	private string damageSource;

	private DamageContainer dc;

	protected override void OnInitOrAmountChanged()
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		int num = poisonStacksPerAmount * amount;
		poisonStacks = num;
		object obj = amount * radiusPerAmount;
		float num2 = (float)obj + 7f;
		radius = num2;
	}

	public override void Init()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<PlayerHealth, DamageContainer, bool> b = new Action<object, object, bool>(OnTakeDamage);
		Delegate obj = Delegate.Combine(PlayerHealth.A_TakeDamage, b);
		if ((object)obj == null)
		{
			PlayerHealth.A_TakeDamage = (Action<PlayerHealth, DamageContainer, bool>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<PlayerHealth, DamageContainer, bool> action = default(Action<PlayerHealth, DamageContainer, bool>);
		if (action != null)
		{
			PlayerHealth.A_TakeDamage = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override void Cleanup()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<PlayerHealth, DamageContainer, bool> value = new Action<object, object, bool>(OnTakeDamage);
		Delegate obj = Delegate.Remove(PlayerHealth.A_TakeDamage, value);
		if ((object)obj == null)
		{
			PlayerHealth.A_TakeDamage = (Action<PlayerHealth, DamageContainer, bool>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<PlayerHealth, DamageContainer, bool> action = default(Action<PlayerHealth, DamageContainer, bool>);
		if (action != null)
		{
			PlayerHealth.A_TakeDamage = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnTakeDamage(PlayerHealth ph, DamageContainer dc, bool shieldDamage)
	{
		if (!(readyAtTime > MyTime.time))
		{
			float num = MyTime.time + cooldown;
			readyAtTime = num;
			Activate();
		}
	}

	private unsafe void Activate()
	{
		//IL_004e: Expected O, but got Ref
		//IL_006c: Expected O, but got Ref
		//IL_0074: Expected O, but got Ref
		//IL_0135: Expected O, but got I4
		//IL_010b: Expected O, but got I4
		float stat = PlayerStats.GetStat(EStat.SizeMultiplier);
		Transform transform = MyPlayer.Instance.transform;
		float range = stat * radius;
		Vector3 position = transform.position;
		float num = default(float);
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&num), range, out var buffer);
		bool flag = enemiesInRadiusSafe <= 0;
		object obj = (object)(&buffer);
		Vector3 vector = (Vector3)(&num);
		float num3 = default(float);
		float num2 = num3;
		int num4 = 0;
		if (!flag)
		{
			int stacks = default(int);
			bool flag3;
			do
			{
				bool enemy = EnemyManager.Instance.GetEnemy(buffer[num4], out var enemy2);
				bool flag2 = !enemy;
				vector = (Vector3)buffer[num4];
				if (!flag2)
				{
					num2 = poisonDuration;
					enemy2.AddDebuff(EDebuff.Poison, null, poisonDuration, stacks);
					vector = (Vector3)1;
				}
				num4++;
				flag3 = num4 < enemiesInRadiusSafe;
				obj = 0;
			}
			while (flag3);
		}
		Action<float> a_OnUse = A_OnUse;
		if (A_OnUse != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v359 @ rax_v25 (System.Action`1<System.Single>)+18] (should have been resolved before IL gen)");
		}
	}

	public override void Tick()
	{
	}

	public unsafe ItemToxicBarrel(ItemInventory itemInventoryRef)
	{
		//IL_006c: Expected O, but got Ref
		//IL_0083: Expected O, but got Ref
		radiusPerAmount = 1f;
		poisonStacksPerAmount = 5;
		cooldown = 0.25f;
		poisonDuration = 5f;
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		damageSource = text;
		object obj2 = default(object);
		string text2 = ((Enum)(&obj2)).ToString();
		dc = new DamageContainer(0.5f, text2);
		base._002Ector(itemInventoryRef);
	}

	public override void PreAttack(DamageContainer dc, StatComponents itemAttackModifier)
	{
	}

	public override bool HasPreAttackProc()
	{
		return false;
	}

	public override void ProcOnHitEffects(DamageContainer dc)
	{
	}

	public override bool HasOnHitEffectProc()
	{
		return false;
	}
}
