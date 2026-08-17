using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Game.Combat.EnemyDebuffs;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemLightningOrb : ItemBase
{
	public float procChancePerAmount;

	private float procChance;

	private float stunChancePerAmount;

	private float stunChance;

	private float baseRadius;

	public float damageRatio;

	public float damageRatioPerAmount;

	private float foundEnemiesAtTime;

	private string damageSource;

	private DamageContainer yepDc;

	private List<int> availableIndexes;

	private int numEnemies;

	private Collider[] enemies;

	public unsafe ItemLightningOrb(ItemInventory itemInventoryRef)
	{
		//IL_0094: Expected O, but got Ref
		procChancePerAmount = 0.25f;
		stunChancePerAmount = 0.25f;
		baseRadius = 40f;
		damageRatio = 0.4f;
		damageRatioPerAmount = 0.4f;
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		damageSource = text;
		DamageContainer damageContainer = new DamageContainer(0f, "");
		damageContainer._002Ector(0f, "");
		yepDc = damageContainer;
		List<int> list = new List<int>(EnemyManager.maxNumEnemiesPooled);
		availableIndexes = list;
		Collider[] array = new Collider[0];
		enemies = array;
		base._002Ector(itemInventoryRef);
	}

	protected override void OnInitOrAmountChanged()
	{
		float input = (float)amount * procChancePerAmount;
		float num = StatScaling.HyperbolicScaling(input, 0.9f, 0.6f);
		procChance = num;
		float input2 = (float)amount * stunChancePerAmount;
		float num2 = StatScaling.HyperbolicScaling(input2, 0.9f, 0.6f);
		stunChance = num2;
		float num3 = (float)amount * damageRatioPerAmount;
		damageRatio = num3;
	}

	public override void Tick()
	{
		//IL_002d: Expected I4, but got I8
		List<int> list = availableIndexes;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rdx_v1 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		numEnemies = -1;
	}

	public unsafe override void ProcOnHitEffects(DamageContainer dc)
	{
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected Ref, but got Unknown
		//IL_011d: Expected O, but got Ref
		//IL_01a1: Expected O, but got I
		//IL_01fa: Expected O, but got I
		//IL_0396: Expected F4, but got I4
		int num = default(int);
		if (dc.element == EElement.Lightning && ItemUtility.TryProc(dc.procCoefficient, stunChance))
		{
			dc.enemy.AddDebuff(EDebuff.Stun, dc, 3f, num);
		}
		if (!ItemUtility.TryProc(dc.procCoefficient, procChance))
		{
			return;
		}
		if (numEnemies == -1)
		{
			Transform transform = MyPlayer.Instance.transform;
			Vector3 position = transform.position;
			float num2 = default(float);
			int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&num2), baseRadius, out *(Collider[]*)(this + 112));
			List<int> list = availableIndexes;
			numEnemies = enemiesInRadiusSafe;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rcx_v31 (System.Collections.Generic.List`1<System.Int32>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			bool flag = numEnemies <= 0;
			int num3 = 0;
			if (!flag)
			{
				do
				{
					List<int> list2 = availableIndexes;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rcx_v33 (System.Collections.Generic.List`1<System.Int32>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rcx_v33 (System.Collections.Generic.List`1<System.Int32>)+10]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rcx_v33 (System.Collections.Generic.List`1<System.Int32>)+18]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rdx_v23+18]");
					if (num4 >= 0)
					{
						list2.AddWithResize(num3);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rcx_v33 (System.Collections.Generic.List`1<System.Int32>)+18]");
						object obj2 = (nint)0 + (nint)1;
					}
					num3++;
				}
				while (num3 < numEnemies);
			}
		}
		if (numEnemies == 0)
		{
			return;
		}
		List<int> list3 = availableIndexes;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rax_v10 (System.Collections.Generic.List`1<System.Int32>)+18]");
		if ((nint)0 <= (nint)0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rax_v10 (System.Collections.Generic.List`1<System.Int32>)+18]");
		int index = UnityEngine.Random.Range(0, 0);
		int num5 = list3.get_Item(index);
		Collider[] array = enemies;
		if (!EnemyManager.Instance.GetEnemy(array[num5], out var enemy))
		{
			return;
		}
		float stat = PlayerStats.GetStat(EStat.SizeMultiplier);
		yepDc.Reuse(0f, damageSource);
		DamageContainer damageContainer = yepDc;
		float damage = damageRatio * dc.damage;
		damageContainer.damage = damage;
		DamageContainer damageContainer2 = yepDc;
		damageContainer2.element = EElement.Lightning;
		DamageContainer damageContainer3 = yepDc;
		float bounceRange = stat * 8f;
		damageContainer3.enemy = enemy;
		WeaponUtility.LightningStrike(enemy, 0, yepDc, bounceRange, num);
		DamageContainer damageContainer4 = yepDc;
		if (ItemUtility.TryProc(1f, stunChance))
		{
			damageContainer4.enemy.AddDebuff(EDebuff.Stun, yepDc, 3f, num);
		}
		if (!enemy.IsDeadOrDyingNextFrame())
		{
			return;
		}
		List<int> list4 = availableIndexes;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v26 (System.Collections.Generic.List`1<System.Int32>)+18]");
		if ((nint)0 <= (nint)0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v26 (System.Collections.Generic.List`1<System.Int32>)+18]");
		if ((nint)num5 < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v26 (System.Collections.Generic.List`1<System.Int32>)+18]");
			int num6 = (int)(-1);
			if (num5 != num6)
			{
				int value = availableIndexes.get_Item(num6);
				availableIndexes.set_Item(num5, value);
			}
			availableIndexes.RemoveAt(num6);
		}
	}

	public override bool HasOnHitEffectProc()
	{
		return true;
	}

	private void TryProcStun(DamageContainer dc, float overrideProcCoefficient = -1f)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001804605EEh\"");
		float num = default(float);
		if (num == -1f || ItemUtility.TryProc(dc.procCoefficient, stunChance))
		{
			int stacks = default(int);
			dc.enemy.AddDebuff(EDebuff.Stun, dc, 3f, stacks);
		}
	}

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	public override void PreAttack(DamageContainer dc, StatComponents itemAttackModifier)
	{
	}

	public override bool HasPreAttackProc()
	{
		return false;
	}

	protected override Dictionary<string, object> GetLocalizationKeys()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		float num = procChancePerAmount * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		string value = $"{arg}%";
		if (dictionary != null)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value);
			return dictionary;
		}
		return (Dictionary<string, object>)(object)new NullReferenceException();
	}
}
