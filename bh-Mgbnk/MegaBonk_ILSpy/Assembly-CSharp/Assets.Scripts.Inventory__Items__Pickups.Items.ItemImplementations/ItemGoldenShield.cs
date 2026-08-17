using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.GoldAndMoney;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemGoldenShield : ItemBase
{
	private float chancePerAmount = 1f;

	private float chance;

	private int extraGoldFromOverload;

	private int goldPerAmount = 6;

	private int goldOnHit;

	private float cooldown = 0.1f;

	private float readyAtTime;

	private float nextSelfDamageReadyTime;

	private float selfDamageCooldown = 0.2f;

	protected override void OnInitOrAmountChanged()
	{
		//IL_0088: Expected O, but got I4
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected I4, but got Unknown
		float num = (float)amount * chancePerAmount;
		chance = num;
		MyPlayer instance = MyPlayer.Instance;
		int characterLevel = instance.inventory.GetCharacterLevel();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		bool flag = characterLevel >= 20;
		int num2 = 20;
		if (!flag)
		{
			num2 = characterLevel;
		}
		object obj = goldPerAmount + num2;
		int num3 = obj * amount;
		goldOnHit = num3;
	}

	private unsafe void OnPlayerTakeDamage(PlayerHealth playerHealth, DamageContainer dc, bool b)
	{
		//IL_0056: Expected I, but got O
		//IL_00ae: Expected O, but got Ref
		//IL_00e8: Expected O, but got I
		if (readyAtTime > MyTime.time)
		{
			return;
		}
		HashSet<object> hashSet = (HashSet<object>)(object)PlayerHealth.selfDamageSources;
		if (((HashSet<object>)(object)PlayerHealth.selfDamageSources).Contains((object)dc.damageSource))
		{
			nint num = (nint)typeof(MyTime);
			if (nextSelfDamageReadyTime > MyTime.time)
			{
				return;
			}
			hashSet = (HashSet<object>)(object)typeof(MyTime);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rcx_v18 (Il2CppClass<Assets.Scripts.Utility.MyTime>)+B8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ rax_v33+4]");
			float num2 = 0f + selfDamageCooldown;
			nextSelfDamageReadyTime = num2;
		}
		float num3 = MyTime.time + cooldown;
		readyAtTime = num3;
		bool flag = ((HashSet<string>)(object)hashSet).Contains((string)null);
		bool flag2 = (flag ? 1 : 0) <= (true ? 1 : 0);
		bool flag3 = true;
		if (!flag2)
		{
			flag3 = flag;
		}
		Transform transform = MyPlayer.Instance.transform;
		Vector3 position = transform.position;
		float num4 = default(float);
		MoneyUtility.SpawnMoney(flag3 ? 1 : 0, (Vector3)(&num4));
	}

	private int GetGold()
	{
		return goldOnHit;
	}

	public override void Init()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<PlayerHealth, DamageContainer, bool> b = new Action<object, object, bool>(OnPlayerTakeDamage);
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
		Action<PlayerHealth, DamageContainer, bool> value = new Action<object, object, bool>(OnPlayerTakeDamage);
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

	public ItemGoldenShield(ItemInventory itemInventoryRef)
		: base(itemInventoryRef)
	{
	}

	public override void Tick()
	{
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
