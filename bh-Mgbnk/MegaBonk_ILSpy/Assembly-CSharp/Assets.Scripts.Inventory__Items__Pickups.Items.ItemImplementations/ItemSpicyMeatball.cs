using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Objects.Pooling;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemSpicyMeatball : ItemBase
{
	private float baseRadius;

	private float radiusPerAmount;

	private float maxRadius;

	private float radius;

	private float damageSpreadMultiplier;

	private float procChance;

	private string damageSource;

	private DamageContainer reuseDc;

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
				radius = maxRadius;
			}
			else
			{
				radius = num3;
			}
		}
		else
		{
			radius = 1f;
		}
	}

	public unsafe override void ProcOnHitEffects(DamageContainer dc)
	{
		//IL_008b: Expected O, but got Ref
		//IL_00aa: Expected O, but got I4
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_0216: Expected O, but got Ref
		//IL_022e: Expected O, but got Ref
		if (numProcsThisTick >= maxProcsPerTick)
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
		object obj = 0;
		if (!flag)
		{
			do
			{
				if (EnemyManager.Instance.GetEnemy(buffer[obj], out var enemy))
				{
					reuseDc.Reuse(0f, damageSource);
					DamageContainer damageContainer = reuseDc;
					num = damageSpreadMultiplier * dc.damage;
					damageContainer.damage = num;
					DamageContainer damageContainer2 = reuseDc;
					damageContainer2.enemy = enemy;
					enemy.DamageFromPlayerOther(reuseDc);
				}
				obj++;
			}
			while ((nint)obj < enemiesInRadiusSafe);
		}
		PoolManager instance = PoolManager.Instance;
		GameObject gameObject = instance.spicyMeatballPool.Get();
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

	public unsafe ItemSpicyMeatball(ItemInventory itemInventoryRef)
	{
		//IL_0082: Expected O, but got Ref
		//IL_0099: Expected O, but got Ref
		baseRadius = 3f;
		radiusPerAmount = 1f;
		maxRadius = 8f;
		damageSpreadMultiplier = 0.65f;
		procChance = 0.25f;
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		damageSource = text;
		object obj2 = default(object);
		string text2 = ((Enum)(&obj2)).ToString();
		reuseDc = new DamageContainer(0f, text2);
		maxProcsPerTick = 50;
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
			float num = procChance * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string value = $"{arg}%";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value);
			float num2 = damageSpreadMultiplier * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg2 = default(object);
			string value2 = $"{arg2}%";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value2", (object)value2);
			return dictionary;
		}
		return (Dictionary<string, object>)(object)new NullReferenceException();
	}
}
