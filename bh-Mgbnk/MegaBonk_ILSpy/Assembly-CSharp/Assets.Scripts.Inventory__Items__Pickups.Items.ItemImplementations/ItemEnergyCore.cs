using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Objects.Pooling;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemEnergyCore : ItemBase
{
	private int orbsPerAmount;

	private int numOrbs;

	private float range;

	private float cooldown;

	private float cooldownPerOrb;

	private float nextSpawnTime;

	private int orbsLeftToShoot;

	private float nextOrbTime;

	private string damageSource;

	protected override void OnInitOrAmountChanged()
	{
		//IL_0011: Expected O, but got I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected I4, but got Unknown
		//IL_0049: Invalid comparison between F4 and I
		//IL_0070: Expected F4, but got I
		object obj = orbsPerAmount * amount;
		int num = (numOrbs = obj + 5);
		float num2 = (float)num * 0.3f;
		float num3 = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262EC84]");
		if (num3 > 0f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262EC84]");
			num2 = 0f;
		}
		float num4 = num2 / (float)num;
		cooldownPerOrb = num4;
	}

	private float GetDamage()
	{
		MyPlayer instance = MyPlayer.Instance;
		float num = instance.baseDamage + instance.baseDamage;
		return num + 8f;
	}

	public override void Tick()
	{
		if (orbsLeftToShoot <= 0)
		{
			if (!(MyTime.time < nextSpawnTime))
			{
				float num = MyTime.time + cooldown;
				orbsLeftToShoot = numOrbs;
				nextSpawnTime = num;
				nextOrbTime = MyTime.time;
			}
			if (orbsLeftToShoot <= 0)
			{
				return;
			}
		}
		if (!(MyTime.time < nextOrbTime))
		{
			int index = numOrbs - orbsLeftToShoot;
			FireOrb(index);
			int num2 = orbsLeftToShoot - 1;
			orbsLeftToShoot = num2;
			float num3 = MyTime.time + cooldownPerOrb;
			nextOrbTime = num3;
		}
	}

	private unsafe void FireOrb(int index)
	{
		//IL_00dd: Expected F4, but got O
		//IL_00dd: Expected F4, but got O
		//IL_00dd: Expected O, but got Ref
		PoolManager instance = PoolManager.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002620");
		UnityEngine.Object obj = default(UnityEngine.Object);
		if (obj != null)
		{
			((GameObject)obj).SetActive(true);
			ItemProjectile component = ((GameObject)obj).GetComponent<ItemProjectile>();
			Transform transform = MyPlayer.Instance.transform;
			Vector3 position = transform.position;
			MyPlayer instance2 = MyPlayer.Instance;
			float num = instance2.baseDamage + instance2.baseDamage;
			float damage = num + 8f;
			PoolManager instance3 = PoolManager.Instance;
			object obj2 = default(object);
			string text = default(string);
			ObjectPool<GameObject> projectilePool = default(ObjectPool<GameObject>);
			int projectileIndex = default(int);
			int totalProjectiles = default(int);
			component.Set((Vector3)(&obj2), damage, 1f, text, projectilePool, projectileIndex, totalProjectiles, (float)damageSource, (float)instance3.orbPool);
		}
	}

	public unsafe ItemEnergyCore(ItemInventory itemInventoryRef)
	{
		//IL_0046: Expected O, but got Ref
		orbsPerAmount = 2;
		numOrbs = 4;
		range = 70f;
		cooldown = 4f;
		cooldownPerOrb = 0.2f;
		object obj = default(object);
		damageSource = ((Enum)(&obj)).ToString();
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

	public override void ProcOnHitEffects(DamageContainer dc)
	{
	}

	public override bool HasOnHitEffectProc()
	{
		return false;
	}
}
