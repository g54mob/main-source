using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat.EnemyDebuffs;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Managers;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemGlovesBlood : ItemBase
{
	public float readyAtTime;

	private float cooldown = 9f;

	private float baseDamageMultiplier = 3.15f;

	private float baseRadius = 10f;

	private float healPercentage = 0.075f;

	private static string damageSource;

	private DamageContainer reuseDc;

	private EffectPlayer fx;

	public ItemGlovesBlood(ItemInventory itemInventoryRef)
	{
		DamageContainer damageContainer = new DamageContainer(0f, damageSource);
		reuseDc = damageContainer;
		base._002Ector(itemInventoryRef);
	}

	public unsafe override void ProcOnHitEffects(DamageContainer dc)
	{
		//IL_0049: Expected O, but got Ref
		//IL_0137: Expected I4, but got O
		//IL_02d4: Expected O, but got Ref
		//IL_01c9: Expected F4, but got O
		if (readyAtTime > MyTime.time)
		{
			return;
		}
		float num = MyTime.time + 0.02f;
		readyAtTime = num;
		Transform transform = dc.enemy.transform;
		Vector3 position = transform.position;
		float num2 = default(float);
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&num2), baseRadius, out var buffer);
		if (enemiesInRadiusSafe <= 0)
		{
			return;
		}
		num2 = position.x;
		int num3 = 0;
		Vector3 vector = default(Vector3);
		Enemy enemy2 = default(Enemy);
		float num5 = default(float);
		do
		{
			if (EnemyManager.Instance.GetEnemy(buffer[num3], out var enemy))
			{
				float damage = GetDamage();
				DamageContainer damageContainer = WeaponUtility.GetDamageContainer(reuseDc, damage, 0f, damageSource, vector, enemy2);
				reuseDc = damageContainer;
				enemy.DamageFromPlayerOther(reuseDc);
				enemy.AddDebuff(EDebuff.Bloodmark, reuseDc, 5f, (int)vector);
				MyPlayer instance = MyPlayer.Instance;
				PlayerInventory inventory = instance.inventory;
				PlayerHealth playerHealth = inventory.playerHealth;
				num = (float)playerHealth.maxHp * healPercentage;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
				MyPlayer instance2 = MyPlayer.Instance;
				PlayerInventory inventory2 = instance2.inventory;
				int num4 = inventory2.playerHealth.Heal(num5);
				num2 = (float)Vector3.zeroVector;
			}
			num3++;
		}
		while (num3 < enemiesInRadiusSafe);
		float num6 = MyTime.time + cooldown;
		readyAtTime = num6;
		if (fx == null)
		{
			EffectManager instance3 = EffectManager.Instance;
			GameObject gameObject = UnityEngine.Object.Instantiate(instance3.gloveBlood);
			EffectPlayer component = gameObject.GetComponent<EffectPlayer>();
			fx = component;
		}
		GameObject gameObject2 = fx.gameObject;
		gameObject2.SetActive(value: true);
		Transform transform2 = fx.transform;
		Transform transform3 = dc.enemy.transform;
		Vector3 position2 = transform3.position;
		transform2.position = (Vector3)(&num2);
		fx.Play();
	}

	public override bool HasOnHitEffectProc()
	{
		return true;
	}

	private float GetDamage()
	{
		MyPlayer instance = MyPlayer.Instance;
		float num = (float)amount * baseDamageMultiplier;
		return num * instance.baseDamage;
	}

	protected override Dictionary<string, object> GetLocalizationKeys()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		float num = healPercentage * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		string value = $"{arg}%";
		if (dictionary != null)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"value", (object)value);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg2 = default(object);
			string value2 = $"{arg2}s";
			((Dictionary<object, object>)(object)dictionary).Add((object)"time_seconds", (object)value2);
			return dictionary;
		}
		return (Dictionary<string, object>)(object)new NullReferenceException();
	}

	protected override void OnInitOrAmountChanged()
	{
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

	unsafe static ItemGlovesBlood()
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		damageSource = text;
	}
}
