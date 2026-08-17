using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Objects.Pooling;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemBonker : ItemBase
{
	private float baseChance;

	private float baseDamageMultiplier;

	private float chancePerStack;

	private float damageMultiplierPerStack;

	private float radiusPerStack;

	private float radius;

	private float maxRadius;

	private float chance;

	private float damageMultiplier;

	private string damageSource;

	private DamageContainer reuseDc;

	private int maxProcsPerTick;

	private int numProcsThisTick;

	protected override void OnInitOrAmountChanged()
	{
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected O, but got Unknown
		//IL_004a: Expected O, but got I4
		//IL_005a: Expected O, but got I4
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		chance = baseChance;
		damageMultiplier = baseDamageMultiplier;
		if (amount > 0)
		{
			object obj = amount - 1;
			object obj2 = amount - 1;
			object obj3 = obj * chancePerStack;
			float num = (float)obj3 + baseChance;
			chance = num;
			object obj4 = obj2 * damageMultiplierPerStack;
			float num2 = (float)obj4 + baseDamageMultiplier;
			damageMultiplier = num2;
		}
		object obj5 = amount * radiusPerStack;
		if ((radius = (float)obj5 + 6f) > maxRadius)
		{
			radius = maxRadius;
		}
	}

	public unsafe override void ProcOnHitEffects(DamageContainer dc)
	{
		//IL_00dc: Expected I, but got O
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0144: Expected O, but got Ref
		//IL_0266: Expected O, but got Ref
		//IL_0420: Unknown result type (might be due to invalid IL or missing references)
		//IL_0425: Expected O, but got Unknown
		//IL_03f3: Expected O, but got F4
		if (!ItemUtility.TryProc(dc.procCoefficient, chance))
		{
			return;
		}
		int num = numProcsThisTick + 1;
		numProcsThisTick = num;
		PoolManager instance = PoolManager.Instance;
		GameObject gameObject = instance.bonkPool.Get();
		float num6 = default(float);
		if (gameObject != null)
		{
			Transform transform = gameObject.transform;
			Transform transform2 = dc.enemy.transform;
			Vector3 position = transform2.position;
			nint num2 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v50 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804AD730");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v746 @ rdx_v23 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			object obj2 = default(object);
			object obj = 0 * obj2;
			float num4 = (float)obj * 0.5f;
			float num5 = num4 + position.z;
			transform.position = (Vector3)(&num6);
		}
		DamageContainer damageContainer = reuseDc;
		float damage = damageMultiplier * dc.damage;
		damageContainer.damage = damage;
		DamageContainer damageContainer2 = reuseDc;
		damageContainer2.enemy = dc.enemy;
		DamageContainer damageContainer3 = reuseDc;
		damageContainer3.damageEffect = EDamageEffect.Bonk;
		DamageContainer damageContainer4 = reuseDc;
		damageContainer4.direction = dc.direction;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [dc @ rdx (Assets.Scripts.Actors.DamageContainer)+18]");
		_ = 0;
		dc.enemy.DamageFromPlayerOther(reuseDc);
		if (numProcsThisTick >= maxProcsPerTick)
		{
			return;
		}
		Vector3 centerPosition = dc.enemy.GetCenterPosition();
		float num7 = radius;
		float x = centerPosition.x;
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&num6), radius, out var buffer);
		if (enemiesInRadiusSafe <= 0)
		{
			return;
		}
		DamageContainer damageContainer5 = null;
		DamageContainer damageContainer6 = null;
		do
		{
			if (EnemyManager.Instance.GetEnemy(buffer[(object)damageContainer6], out var enemy))
			{
				reuseDc.Reuse(0f, damageSource);
				DamageContainer damageContainer7 = reuseDc;
				damageContainer7.damage = dc.damage;
				DamageContainer damageContainer8 = reuseDc;
				damageContainer8.enemy = enemy;
				DamageContainer damageContainer9 = reuseDc;
				float knockback = dc.knockback * 1.25f;
				damageContainer9.knockback = knockback;
				damageContainer5 = reuseDc;
				Vector3 centerPosition2 = enemy.GetCenterPosition();
				Transform transform3 = MyPlayer.Instance.transform;
				Vector3 position2 = transform3.position;
				x = centerPosition2.x - position2.x;
				num7 = centerPosition2.y - position2.y;
				float num5 = centerPosition2.z - position2.z;
				damageContainer5.direction = (Vector3)x;
				enemy.DamageFromPlayerOther(reuseDc);
			}
			damageContainer6 = (DamageContainer)(damageContainer6 + 1);
		}
		while ((nint)damageContainer6 < enemiesInRadiusSafe);
	}

	public override bool HasOnHitEffectProc()
	{
		return true;
	}

	public override void Tick()
	{
		numProcsThisTick = 0;
	}

	public unsafe ItemBonker(ItemInventory itemInventoryRef)
	{
		//IL_0098: Expected O, but got Ref
		//IL_00af: Expected O, but got Ref
		baseChance = 0.02f;
		baseDamageMultiplier = 20f;
		chancePerStack = 0.015f;
		damageMultiplierPerStack = 10f;
		radiusPerStack = 1f;
		radius = 3.5f;
		maxRadius = 10f;
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		damageSource = text;
		object obj2 = default(object);
		string text2 = ((Enum)(&obj2)).ToString();
		reuseDc = new DamageContainer(0f, text2);
		maxProcsPerTick = 5;
		base._002Ector(itemInventoryRef);
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
		string text = EnumUtility.EnumToReadable(EStat.DamageMultiplier);
		if (text == null)
		{
			text = "";
		}
		if (dictionary != null)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"stat1", (object)text);
			float num = baseChance * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string value = $"{arg}%";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg2 = default(object);
			string value2 = $"{arg2}x";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value2", (object)value2);
			return dictionary;
		}
		return (Dictionary<string, object>)(object)new NullReferenceException();
	}
}
