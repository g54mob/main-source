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

public class ItemGlovesLightning : ItemBase
{
	public float readyAtTime;

	private float cooldown = 10f;

	private float baseDamageMultiplier = 3f;

	private float baseRadius = 8f;

	private static string damageSource;

	private DamageContainer reuseDc;

	private EffectPlayer fx;

	public ItemGlovesLightning(ItemInventory itemInventoryRef)
	{
		DamageContainer damageContainer = new DamageContainer(0f, damageSource);
		reuseDc = damageContainer;
		base._002Ector(itemInventoryRef);
	}

	public unsafe override void ProcOnHitEffects(DamageContainer dc)
	{
		//IL_0069: Expected O, but got Ref
		//IL_00a5: Expected O, but got I4
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected O, but got Unknown
		//IL_0156: Expected I4, but got O
		//IL_0165: Expected F4, but got O
		//IL_0270: Expected O, but got Ref
		if (readyAtTime > MyTime.time || dc.enemy.IsDeadOrDyingNextFrame())
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
		object obj = 0;
		Vector3 vector = default(Vector3);
		Enemy enemy2 = default(Enemy);
		do
		{
			if (EnemyManager.Instance.GetEnemy(buffer[obj], out var enemy))
			{
				num = GetDamage();
				DamageContainer damageContainer = WeaponUtility.GetDamageContainer(reuseDc, num, 0f, damageSource, vector, enemy2);
				reuseDc = damageContainer;
				enemy.DamageFromPlayerOther(reuseDc);
				enemy.AddDebuff(EDebuff.Stun, reuseDc, 3f, (int)vector);
				num2 = (float)Vector3.zeroVector;
			}
			obj++;
		}
		while ((nint)obj < enemiesInRadiusSafe);
		float num3 = MyTime.time + cooldown;
		readyAtTime = num3;
		if (fx == null)
		{
			EffectManager instance = EffectManager.Instance;
			GameObject gameObject = UnityEngine.Object.Instantiate(instance.gloveLightning);
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		string value = $"{arg}s";
		if (dictionary != null)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"time_seconds", (object)value);
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

	unsafe static ItemGlovesLightning()
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		damageSource = text;
	}
}
