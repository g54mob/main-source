using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Objects.Pooling;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemQuinsMask : ItemBase
{
	private float thornsPerAmount = 20f;

	private float baseRadius = 5f;

	private float radiusPerAmount = 1f;

	private float maxRadius = 10f;

	private float radius;

	private float damageSpreadMultiplier = 0.5f;

	private float procChance = 0.5f;

	private HashSet<string> damageSources;

	private DamageContainer procDc;

	public static string damageSource;

	private string aegisDamageSource;

	private int maxProcsPerTick;

	private int numProcsThisTick;

	protected override void OnInitOrAmountChanged()
	{
		float stat = PlayerStats.GetStat(EStat.SizeMultiplier);
		float num = (float)amount * radiusPerAmount;
		float num2 = num + baseRadius;
		float num3 = stat * num2;
		if (!(1f > num3))
		{
			if (num3 > maxRadius)
			{
				num3 = maxRadius;
			}
		}
		else
		{
			num3 = 1f;
		}
		radius = num3;
		StatModifier statModifier = new StatModifier();
		statModifier.modifyType = EStatModifyType.Flat;
		statModifier.stat = EStat.Thorns;
		float modification = (float)amount * thornsPerAmount;
		statModifier.modification = modification;
		SetStat(statModifier);
	}

	public ItemQuinsMask(ItemInventory itemInventoryRef)
	{
		DamageContainer damageContainer = new DamageContainer(0f, "");
		procDc = damageContainer;
		maxProcsPerTick = 100;
		base._002Ector(itemInventoryRef);
	}

	public override void Init()
	{
		if (DataManager.Instance != null)
		{
			WeaponData weapon = DataManager.Instance.GetWeapon(EWeapon.Aegis);
			aegisDamageSource = weapon._003CdamageSourceName_003Ek__BackingField;
		}
		HashSet<string> hashSet = (HashSet<string>)(object)new HashSet<object>();
		bool flag = hashSet.Add(PlayerHealth.thornsDamageSource);
		bool flag2 = hashSet.Add(ItemCactus.damageSource);
		bool flag3 = hashSet.Add(aegisDamageSource);
		bool flag4 = hashSet.Add(ItemElectricPlug.damageSource);
		damageSources = hashSet;
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

	public unsafe override void ProcOnHitEffects(DamageContainer dc)
	{
		//IL_00bc: Expected O, but got Ref
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_0284: Expected O, but got Ref
		//IL_029c: Expected O, but got Ref
		if (numProcsThisTick >= maxProcsPerTick || !((HashSet<object>)(object)damageSources).Contains((object)dc.damageSource))
		{
			return;
		}
		float num = procChance;
		if (!ItemUtility.TryProc(procChance, dc.procCoefficient))
		{
			return;
		}
		int num2 = numProcsThisTick + 1;
		numProcsThisTick = num2;
		Vector3 centerPosition = dc.enemy.GetCenterPosition();
		float num3 = default(float);
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&num3), radius, out var buffer);
		bool flag = enemiesInRadiusSafe <= 0;
		Enemy enemy = null;
		if (!flag)
		{
			do
			{
				if (EnemyManager.Instance.GetEnemy(buffer[(object)enemy], out var enemy2) && enemy2 != null && !enemy2.IsDead())
				{
					procDc.Reuse(0f, damageSource);
					DamageContainer damageContainer = procDc;
					num = damageSpreadMultiplier * dc.damage;
					damageContainer.damage = num;
					DamageContainer damageContainer2 = procDc;
					damageContainer2.enemy = enemy2;
					enemy2.DamageFromPlayerOther(procDc);
				}
				enemy = (Enemy)(enemy + 1);
			}
			while ((nint)enemy < enemiesInRadiusSafe);
		}
		PoolManager instance = PoolManager.Instance;
		GameObject gameObject = instance.quinMaskPool.Get();
		if (gameObject != null)
		{
			Transform transform = gameObject.transform;
			Vector3 centerPosition2 = dc.enemy.GetCenterPosition();
			Vector3 insideUnitSphere = UnityEngine.Random.insideUnitSphere;
			Vector3 vector = VectorExtensions.XZVector((Vector3)(&num3));
			transform.position = (Vector3)(&num3);
			gameObject.SetActive(value: true);
		}
	}

	public override bool HasOnHitEffectProc()
	{
		return true;
	}

	public override void Tick()
	{
		numProcsThisTick = 0;
	}

	protected override Dictionary<string, object> GetLocalizationKeys()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		float num = procChance * 100f;
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

	unsafe static ItemQuinsMask()
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		damageSource = text;
	}
}
