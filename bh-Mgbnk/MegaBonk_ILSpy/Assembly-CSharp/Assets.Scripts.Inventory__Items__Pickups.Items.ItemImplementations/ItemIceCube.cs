using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Game.Combat.EnemyDebuffs;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Objects.Pooling;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemIceCube : ItemBase
{
	public float procChancePerAmount;

	private float procChance;

	private float freezeChancePerAmount;

	private float freezeChance;

	public float damageRatio;

	public float damageRatioPerAmount;

	private string damageSource;

	private DamageContainer reuseDc;

	public static Action A_FreezeEnemy;

	public unsafe ItemIceCube(ItemInventory itemInventoryRef)
	{
		//IL_006c: Expected O, but got Ref
		//IL_0083: Expected O, but got Ref
		procChancePerAmount = 0.2f;
		freezeChancePerAmount = 0.4f;
		damageRatio = 0.8f;
		damageRatioPerAmount = 0.4f;
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		damageSource = text;
		object obj2 = default(object);
		string text2 = ((Enum)(&obj2)).ToString();
		reuseDc = new DamageContainer(0f, text2);
		base._002Ector(itemInventoryRef);
	}

	protected override void OnInitOrAmountChanged()
	{
		float input = (float)amount * procChancePerAmount;
		float num = StatScaling.HyperbolicScaling(input);
		procChance = num;
		float input2 = (float)amount * freezeChancePerAmount;
		float num2 = StatScaling.HyperbolicScaling(input2, 1f, 0.6f);
		freezeChance = num2;
		float num3 = (float)amount * damageRatioPerAmount;
		damageRatio = num3;
	}

	public unsafe override void ProcOnHitEffects(DamageContainer dc)
	{
		//IL_0103: Expected O, but got Ref
		//IL_0144: Expected O, but got Ref
		int stacks = default(int);
		if (dc.element == EElement.Ice && ItemUtility.TryProc(dc.procCoefficient, freezeChance))
		{
			dc.enemy.AddDebuff(EDebuff.Freeze, dc, 3f, stacks);
			Action a_FreezeEnemy = A_FreezeEnemy;
			if (A_FreezeEnemy != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v318.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
		if (!ItemUtility.TryProc(dc.procCoefficient, procChance))
		{
			return;
		}
		PoolManager instance = PoolManager.Instance;
		GameObject gameObject = instance.freezeFxPool.Get();
		if (gameObject != null)
		{
			Transform transform = gameObject.transform;
			Vector3 centerPosition = dc.enemy.GetCenterPosition();
			Vector3 insideUnitSphere = UnityEngine.Random.insideUnitSphere;
			float num2 = default(float);
			float num = VectorExtensions.XZVector((Vector3)(&num2)).y * 0.5f;
			float num3 = num + centerPosition.y;
			transform.position = (Vector3)(&num2);
		}
		DamageContainer damageContainer = reuseDc;
		float damage = damageRatio * dc.damage;
		damageContainer.damage = damage;
		DamageContainer damageContainer2 = reuseDc;
		damageContainer2.enemy = dc.enemy;
		DamageContainer damageContainer3 = reuseDc;
		damageContainer3.element = EElement.Ice;
		dc.enemy.DamageFromPlayerOther(reuseDc);
		DamageContainer damageContainer4 = reuseDc;
		if (ItemUtility.TryProc(1f, freezeChance))
		{
			damageContainer4.enemy.AddDebuff(EDebuff.Freeze, reuseDc, 3f, stacks);
			Action a_FreezeEnemy2 = A_FreezeEnemy;
			if (A_FreezeEnemy != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v453.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	public override bool HasOnHitEffectProc()
	{
		return true;
	}

	private void TryProcFreeze(DamageContainer dc, float overrideProcCoefficient = -1f)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018045DFA9h\"");
		bool flag = overrideProcCoefficient != -1f;
		float procCoefficient = overrideProcCoefficient;
		if (!flag)
		{
			procCoefficient = dc.procCoefficient;
		}
		if (ItemUtility.TryProc(procCoefficient, freezeChance))
		{
			int stacks = default(int);
			dc.enemy.AddDebuff(EDebuff.Freeze, dc, 3f, stacks);
			Action a_FreezeEnemy = A_FreezeEnemy;
			if (A_FreezeEnemy != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v133.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	public override void Init()
	{
	}

	public override void Cleanup()
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
