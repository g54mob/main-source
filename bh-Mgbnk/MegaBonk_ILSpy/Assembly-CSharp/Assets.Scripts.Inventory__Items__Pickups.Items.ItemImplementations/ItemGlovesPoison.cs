using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat.EnemyDebuffs;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Managers;
using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemGlovesPoison : ItemBase
{
	public float readyAtTime;

	private float cooldown = 8.5f;

	private float baseDamageMultiplier = 1.5f;

	private float baseRadius = 15f;

	private int poisonStacksPerAmount = 10;

	private static string damageSource;

	private DamageContainer reuseDc;

	private EffectPlayer fx;

	public ItemGlovesPoison(ItemInventory itemInventoryRef)
	{
		DamageContainer damageContainer = new DamageContainer(0f, damageSource);
		reuseDc = damageContainer;
		base._002Ector(itemInventoryRef);
	}

	public unsafe override void ProcOnHitEffects(DamageContainer dc)
	{
		//IL_0049: Expected O, but got Ref
		//IL_0137: Expected I4, but got O
		//IL_0145: Expected F4, but got O
		//IL_0250: Expected O, but got Ref
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
		do
		{
			if (EnemyManager.Instance.GetEnemy(buffer[num3], out var enemy))
			{
				num = GetDamage();
				DamageContainer damageContainer = WeaponUtility.GetDamageContainer(reuseDc, num, 0f, damageSource, vector, enemy2);
				reuseDc = damageContainer;
				enemy.DamageFromPlayerOther(reuseDc);
				enemy.AddDebuff(EDebuff.Poison, reuseDc, 5f, (int)vector);
				num2 = (float)Vector3.zeroVector;
			}
			num3++;
		}
		while (num3 < enemiesInRadiusSafe);
		float num4 = MyTime.time + cooldown;
		readyAtTime = num4;
		if (fx == null)
		{
			EffectManager instance = EffectManager.Instance;
			GameObject gameObject = UnityEngine.Object.Instantiate(instance.glovePoison);
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

	unsafe static ItemGlovesPoison()
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		damageSource = text;
	}
}
